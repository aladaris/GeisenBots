using System;
using System.IO;
using System.Drawing;

using Robocode;

namespace Aladaris {

    public class EisenBot : AdvancedRobot {
        #region Atributes
        private enum TableRexPrograms { main, onScannedRobot, onHitByBullet, onHitRobot, onHitWall };
        // TableRex Programs(tables)
        private TableRex mainTable;
        private TableRex onScannedTable;
        private TableRex onHitByBulletTable;
        private TableRex onHitBotTable;
        private TableRex onHitWallTable;

        // Global variables among all the TableRex programs of the robot
        double lastEnemyVelocity = 0.0;
        double lastEnemyEnergy = 0.0;
        double lastEnemyHeading = 0.0;
        double lastEnemyBearing = 0.0;
        double lastEnemyDistance = 0.0;
        #endregion

        #region TableRex Inputs
        // TableRex Inputs (20 firsts rows)
        private double InputVelocity() { return Velocity; }
        private double InputEnergy() { return Energy; }
        private double InputHeading() { return Heading; }
        private double InputGunHeading() { return GunHeading; }
        private double InputGunHeat() { return GunHeat; }
        private double InputRadarHeading() { return RadarHeading; }
        private double InputRadarTurnRemaining() { return RadarTurnRemaining; }
        private double InputDistanceToWestWall() { return Support.PointsDistance(X, Y, 0, Y); }
        private double InputDistanceToNorthWall() { return Support.PointsDistance(X, Y, X, BattleFieldHeight); }
        private double InputDistanceToEastWall() { return Support.PointsDistance(X, Y, BattleFieldWidth, Y); }
        private double InputDistanceToSouthWall() { return Support.PointsDistance(X, Y, X, 0); }
        private double InputConstant1() { return 1; }
        private double InputConstant2() { return 2; }
        private double InputConstant10() { return 10; }
        private double InputConstant90() { return 90; }
        private double InputEnemyVelocity() { return lastEnemyVelocity; }
        private double InputEnemyEnergy() { return lastEnemyEnergy; }
        private double InputEnemyHeading() { return lastEnemyHeading; }
        private double InputEnemyBearing() { return lastEnemyBearing; }
        private double InputEnemyDistance() { return lastEnemyDistance; }
        #endregion

        #region TableRex Functions
        // TableRex functions
        // TODO: Desacoplar; Esto debería ir en TableRex, pero 'ControlActuator' is a bitch
        private double GreaterThan(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando GreaterThan con " + i1.ToString() + ", " + i2.ToString());
            if (t[i1].output > t[i2].output)
                return 1;
            return 0;
        }
        private double LessThan(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando LessThan con " + i1.ToString() + ", " + i2.ToString());
            if (t[i1].output < t[i2].output)
                return 1;
            return 0;
        }
        private double Equal(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando Equal con " + i1.ToString() + ", " + i2.ToString());
            if (t[i1].output == t[i2].output)
                return 1;
            return 0;
        }
        private double Add(TableRex t, int i1, int i2) { /*Out.WriteLine("Ejecutando Add con " + i1.ToString() + ", " + i2.ToString());*/ return (t[i1].output + t[i2].output); }
        private double Subtract(TableRex t, int i1, int i2) { /*Out.WriteLine("Ejecutando Subtract con " + i1.ToString() + ", " + i2.ToString());*/ return (t[i1].output - t[i2].output); }
        private double Product(TableRex t, int i1, int i2) { /*Out.WriteLine("Ejecutando Product con " + i1.ToString() + ", " + i2.ToString());*/ return (t[i1].output * t[i2].output); }
        private double Divide(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando Divide con " + i1.ToString() + ", " + i2.ToString());
            if (t[i2].output != 0)
                return (t[i1].output / t[i2].output);
            return (t[i1].output / (t[i2].output + 1));
        }
        private double Absolute(TableRex t, int i1) { /*Out.WriteLine("Ejecutando Absolute con " + i1.ToString());*/ return Math.Abs(t[i1].output); }
        private enum LogicOps { and, or, not };
        private double LogicOperators(TableRex t, int i1, int i2, LogicOps op) {
            bool b1 = true;
            bool b2 = true;
            bool r = true;

            if (t[i1].output < 1)
                b1 = false;
            if (t[i2].output < 1)
                b2 = false;

            switch (op) {
                case LogicOps.and: r = b1 && b2; break;
                case LogicOps.or: r = b1 || b2; break;
                case LogicOps.not: r = !b1; break;
                default: return 0;
            }
            if (r)
                return 1;
            return 0;
        }
        private double And(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando And con " + i1.ToString() + ", " + i2.ToString());
            return LogicOperators(t, i1, i2, LogicOps.and);
        }
        private double Or(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando Or con " + i1.ToString() + ", " + i2.ToString());
            return LogicOperators(t, i1, i2, LogicOps.or);
        }
        private double Not(TableRex t, int i1) {
            //Out.WriteLine("Ejecutando Not con " + i1.ToString());
            return LogicOperators(t, i1, 0, LogicOps.not);
        }
        private double GenerateConstant(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando GenerateConstant con " + i1.ToString() + ", " + i2.ToString());
            return i2 - i1;
        }
        private double Modulo(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando Modulo con " + i1.ToString() + ", " + i2.ToString());
            if ((int)t[i2].output != 0)
                return ((int)t[i1].output % ((int)t[i2].output));
            return ((int)t[i1].output % ((int)t[i2].output + 1));
        }
        private double RandomFloat(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando RandomFloat con " + i1.ToString() + ", " + i2.ToString());
            Random rand = new Random((int)X % ((int)Energy + 1) + (int)Time);
            return (rand.NextDouble() * t[i1].output + t[i2].output);
        }
        private double NormalizeRelativeAngle(TableRex t, int i1) {
            //Out.WriteLine("Ejecutando NormalizeRelativeAngle con " + i1.ToString());
            // Source: http://www.java2s.com/Tutorial/Java/0120__Development/Normalizesanangletoarelativeangle.htm
            //return (t[i1].output %= 360) >= 0 ? (t[i1].output < 180) ? t[i1].output : t[i1].output - 360 : (t[i1].output >= -180) ? t[i1].output : t[i1].output + 360;
            return Robocode.Util.Utils.NormalRelativeAngleDegrees(t[i1].output);
        }
        private double ControlActuator(TableRex t, int i1, int i2) {
            //Out.WriteLine("Ejecutando ControlActuator con " + i1.ToString() + ", " + i2.ToString());
            //Ahead(GenerateConstant(i1, i2)); // DEBUG
            switch (i1) {
                case 0: return ActAhead(t[i2].output);
                case 1: return ActAhead50();
                case 2: return ActAheadDistanceToCenter();
                case 3: return ActAheadHalfDistanceToWestWall();
                case 4: return ActAheadHalfDistanceToNorthWall();
                case 5: return ActAheadHalfDistanceToEastWall();
                case 6: return ActAheadHalfDistanceToSouthWall();
                case 7: return ActAheadDistanceToEnemy();
                case 8: return ActAheadHalfDistanceToEnemy();
                case 9: return ActBack(t[i2].output);
                case 10: return ActBack50();
                case 11: return ActBackDistanceToCenter();
                case 12: return ActBackHalfDistanceToWestWall();
                case 13: return ActBackHalfDistanceToNorthWall();
                case 14: return ActBackHalfDistanceToEastWall();
                case 15: return ActBackHalfDistanceToSouthWall();
                case 16: return ActBackDistanceToEnemy();
                case 17: return ActBackHalfDistanceToEnemy();
                case 18: return ActTurnRight(t[i2].output);
                case 19: return ActTurnRight10();
                case 20: return ActTurnRight45();
                case 21: return ActTurnRight90();
                case 22: return ActTurnLeft(t[i2].output);
                case 23: return ActTurnLeft10();
                case 24: return ActTurnLeft45();
                case 25: return ActTurnLeft90();
                case 26: return ActTurnToCenter();
                case 27: return ActTurnAwayFromCenter();
                case 28: return ActTurnToEnemy();
                case 29: return ActTurnAwayFromEnemy();
                case 30: return ActTurnPerpendicularToEnemy();
                case 31: return ActTurnParallelToNearestWall();
                case 32: return ActTurnPerpendicularToNearestWall();
                case 33: return ActFire(t[i2].output);
                case 34: return ActFire1();
                case 35: return ActFire2();
                case 36: return ActFire3();
                case 37: return ActTurnGunRight(t[i2].output);
                case 38: return ActTurnGunRight10();
                case 39: return ActTurnGunRight45();
                case 40: return ActTurnGunRight90();
                case 41: return ActTurnGunLeft(t[i2].output);
                case 42: return ActTurnGunLeft10();
                case 43: return ActTurnGunLeft45();
                case 44: return ActTurnGunLeft90();
                case 45: return ActTurnGunToCenter();
                case 46: return ActTurnGunToEnemy();


                default: break;
            }
            return 1;
        }
        #endregion

        #region Actuators/Action Functions
        // Actuators/Action Functions

        // MOVEMENT
        private int ActAhead(double value) {
            //Out.WriteLine("[Actuator] ActAhead " + value.ToString()); // DEBUG
            Ahead(value);
            return 1;
        }
        private int ActAhead50() {
            //Out.WriteLine("[Actuator] ActAhead50"); // DEBUG
            Ahead(50);
            return 1;
        }
        private int ActAheadDistanceToCenter() {
            double centerX = BattleFieldWidth / 2;  // Center X
            double centerY = BattleFieldHeight / 2; // Center Y
            double distance = Support.PointsDistance(centerX, centerY, X, Y);
            //Out.WriteLine("[Actuator] ActAheadDistanceToCenter: " + distance.ToString()); // DEBUG
            Ahead(distance);
            return 1;
        }
        private int ActAheadHalfDistanceToWestWall() {
            double distance = InputDistanceToWestWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToWestWall: " + distance.ToString()); // DEBUG
            Ahead(distance / 2);
            return 1;
        }
        private int ActAheadHalfDistanceToNorthWall() {
            double distance = InputDistanceToNorthWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToNorthWall: " + distance.ToString()); // DEBUG
            Ahead(distance / 2);
            return 1;
        }
        private int ActAheadHalfDistanceToEastWall() {
            double distance = InputDistanceToEastWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToEastWall: " + distance.ToString()); // DEBUG
            Ahead(distance / 2);
            return 1;
        }
        private int ActAheadHalfDistanceToSouthWall() {
            double distance = InputDistanceToSouthWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToSouthWall" + distance.ToString()); // DEBUG
            Ahead(distance / 2);
            return 1;
        }
        private int ActAheadDistanceToEnemy() {
            //Out.WriteLine("[Actuator] ActAheadDistanceToEnemy: " + lastEnemyDistance.ToString()); // DEBUG
            Ahead(lastEnemyDistance);
            return 1;
        }
        private int ActAheadHalfDistanceToEnemy() {
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToEnemy: " + (lastEnemyDistance / 2).ToString()); // DEBUG
            Ahead(lastEnemyDistance / 2);
            return 1;
        }
        private int ActBack(double value) {
            //Out.WriteLine("[Actuator] ActBack " + value.ToString()); // DEBUG
            Back(value);
            return 1;
        }
        private int ActBack50() {
            //Out.WriteLine("[Actuator] ActBack50"); // DEBUG
            Back(50);
            return 1;
        }
        private int ActBackDistanceToCenter() {
            double centerX = BattleFieldWidth / 2;  // Center X
            double centerY = BattleFieldHeight / 2; // Center Y
            double distance = Support.PointsDistance(centerX, centerY, X, Y);
            //Out.WriteLine("[Actuator] ActBackDistanceToCenter: " + distance.ToString()); // DEBUG
            Back(distance);
            return 1;
        }
        private int ActBackHalfDistanceToWestWall() {
            double distance = InputDistanceToWestWall();
            //Out.WriteLine("[Actuator] ActBackHalfDistanceToWestWall: " + distance.ToString()); // DEBUG
            Back(distance / 2);
            return 1;
        }
        private int ActBackHalfDistanceToNorthWall() {
            double distance = InputDistanceToNorthWall();
            //Out.WriteLine("[Actuator] ActBackHalfDistanceToNorthWall: " + distance.ToString()); // DEBUG
            Back(distance / 2);
            return 1;
        }
        private int ActBackHalfDistanceToEastWall() {
            double distance = InputDistanceToEastWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToEastWall: " + distance.ToString()); // DEBUG
            Back(distance / 2);
            return 1;
        }
        private int ActBackHalfDistanceToSouthWall() {
            double distance = InputDistanceToSouthWall();
            //Out.WriteLine("[Actuator] ActBackHalfDistanceToSouthWall: " + distance.ToString()); // DEBUG
            Back(distance / 2);
            return 1;
        }
        private int ActBackDistanceToEnemy() {
            //Out.WriteLine("[Actuator] ActBackDistanceToEnemy: " + lastEnemyDistance.ToString()); // DEBUG
            Back(lastEnemyDistance);
            return 1;
        }
        private int ActBackHalfDistanceToEnemy() {
            //Out.WriteLine("[Actuator] ActBackHalfDistanceToEnemy: " + (lastEnemyDistance / 2).ToString()); // DEBUG
            Back(lastEnemyDistance / 2);
            return 1;
        }
        // TURNNING
        private int ActTurnRight(double value) {
            TurnRight(value);
            return 1;
        }
        private int ActTurnRight10() {
            return ActTurnRight(10);
        }
        private int ActTurnRight45() {
            return ActTurnRight(45);
        }
        private int ActTurnRight90() {
            return ActTurnRight(90);
        }
        private int ActTurnLeft(double value) {
            TurnLeft(value);
            return 1;
        }
        private int ActTurnLeft10() {
            return ActTurnLeft(10);
        }
        private int ActTurnLeft45() {
            return ActTurnLeft(45);
        }
        private int ActTurnLeft90() {
            return ActTurnLeft(90);
        }
        private double AbsBearing(double px, double py) {
            return (((py - Y) < 0 ? Math.PI : 0) + Math.Atan((px - X) / (py - Y)));
        }
        private double NormalizeBearing(double angle) {
            while (angle > 180) angle -= 360;
            while (angle < -180) angle += 360;
            return angle;
        }
        private int ActTurnToCenter() {
            double centerX = BattleFieldWidth / 2;
            double centerY = BattleFieldHeight / 2;
            //Out.WriteLine("[Actuator] ActTurnToCenter: " + AbsBearing(centerX, centerY).ToString()); // DEBUG
            TurnRight(AbsBearing(centerX, centerY));
            return 1;
        }
        private int ActTurnAwayFromCenter() {
            double centerX = BattleFieldWidth / 2;
            double centerY = BattleFieldHeight / 2;
            //Out.WriteLine("[Actuator] ActTurnAwayFromCenter: " + AbsBearing(centerX, centerY).ToString()); // DEBUG
            TurnRight(NormalizeBearing(AbsBearing(centerX, centerY) + 180));
            return 1;
        }
        private int ActTurnToEnemy() {
            TurnRight(NormalizeBearing(Heading - GunHeading + lastEnemyBearing));
            return 1;
        }
        private int ActTurnAwayFromEnemy() {
            TurnRight(NormalizeBearing(Heading - GunHeading + lastEnemyBearing + 180));
            return 1;
        }
        private int ActTurnPerpendicularToEnemy() {
            TurnRight(NormalizeBearing(Heading - GunHeading + lastEnemyBearing + 90));
            return 1;
        }
        enum walls { North, East, South, West };
        private walls GetNearestWall() {
            double dN, dE, dS, dW; // Distance to North, East, South and West
            walls nearest = walls.North;
            double nearestDistance = 0.0;
            dN = Support.PointsDistance(X, BattleFieldHeight, X, Y);
            dE = Support.PointsDistance(BattleFieldWidth, Y, X, Y);
            dS = Support.PointsDistance(X, 0, X, Y);
            dW = Support.PointsDistance(0, Y, X, Y);
            nearestDistance = dN;
            if (dE < nearestDistance) {
                nearest = walls.East;
                nearestDistance = dE;
            }
            if (dS < nearestDistance) {
                nearest = walls.South;
                nearestDistance = dS;
            }
            if (dW < nearestDistance) {
                nearest = walls.West;
                nearestDistance = dW;
            }
            return nearest;
        }
        private int ActTurnParallelToNearestWall() {
            double bearing = 0.0;
            switch (GetNearestWall()) {
                case walls.North: bearing = NormalizeBearing(AbsBearing(X, BattleFieldHeight)); break;
                case walls.East: bearing = NormalizeBearing(AbsBearing(BattleFieldWidth, Y)); break;
                case walls.South: bearing = NormalizeBearing(AbsBearing(X, 0)); break;
                case walls.West: bearing = NormalizeBearing(AbsBearing(0, Y)); break;
            }
            if (bearing > 0)
                TurnRight(bearing - (bearing - 90));
            else
                TurnLeft(bearing - (bearing - 90));
            return 1;
        }
        private int ActTurnPerpendicularToNearestWall() {
            double bearing = 0.0;
            switch (GetNearestWall()) {
                case walls.North: bearing = NormalizeBearing(AbsBearing(X, BattleFieldHeight) + 180); break;
                case walls.East: bearing = NormalizeBearing(AbsBearing(BattleFieldWidth, Y) + 180); break;
                case walls.South: bearing = NormalizeBearing(AbsBearing(X, 0) + 180); break;
                case walls.West: bearing = NormalizeBearing(AbsBearing(0, Y) + 180); break;
            }
            TurnRight(bearing);
            return 1;
        }

        // GUN
        private int ActFire(double value) {
            Fire(Math.Abs(value));
            return 1;
        }
        private int ActFire1() {
            return ActFire(1);
        }
        private int ActFire2() {
            return ActFire(2);
        }
        private int ActFire3() {
            return ActFire(3);
        }
        private int ActTurnGunRight(double value) {
            TurnGunRight(value);
            return 1;
        }
        private int ActTurnGunRight10() {
            return ActTurnGunRight(10);
        }
        private int ActTurnGunRight45() {
            return ActTurnGunRight(45);
        }
        private int ActTurnGunRight90() {
            return ActTurnGunRight(90);
        }
        private int ActTurnGunLeft(double value) {
            TurnGunLeft(value);
            return 1;
        }
        private int ActTurnGunLeft10() {
            return ActTurnGunLeft(10);
        }
        private int ActTurnGunLeft45() {
            return ActTurnGunLeft(45);
        }
        private int ActTurnGunLeft90() {
            return ActTurnGunLeft(90);
        }
        private int ActTurnGunToCenter() {
            double centerX = BattleFieldWidth / 2;
            double centerY = BattleFieldHeight / 2;
            //Out.WriteLine("[Actuator] ActTurnGunToCenter: " + AbsBearing(centerX, centerY).ToString()); // DEBUG
            return ActTurnGunRight(AbsBearing(centerX, centerY));
        }
        private int ActTurnGunToEnemy() {
            return ActTurnGunRight(lastEnemyBearing);
        }
        #endregion

        #region Execution Methods
        // Refresh the output value of the input rows (first NINPUTS of the table)
        private void RefreshTableInputs(TableRex t) {
            for (int i = 0; i < TableRexBase.NINPUTS; i++) {
                switch (i) {
                    case 0: t[i].output = InputVelocity(); break;
                    case 1: t[i].output = InputEnergy(); break;
                    case 2: t[i].output = InputHeading(); break;
                    case 3: t[i].output = InputGunHeading(); break;
                    case 4: t[i].output = InputGunHeat(); break;
                    case 5: t[i].output = InputRadarHeading(); break;
                    case 6: t[i].output = InputRadarTurnRemaining(); break;
                    case 7: t[i].output = InputDistanceToWestWall(); break;
                    case 8: t[i].output = InputDistanceToNorthWall(); break;
                    case 9: t[i].output = InputDistanceToEastWall(); break;
                    case 10: t[i].output = InputDistanceToSouthWall(); break;
                    case 11: t[i].output = InputConstant1(); break;
                    case 12: t[i].output = InputConstant2(); break;
                    case 13: t[i].output = InputConstant10(); break;
                    case 14: t[i].output = InputConstant90(); break;
                    case 15: t[i].output = InputEnemyVelocity(); break;
                    case 16: t[i].output = InputEnemyEnergy(); break;
                    case 17: t[i].output = InputEnemyHeading(); break;
                    case 18: t[i].output = InputEnemyBearing(); break;
                    case 19: t[i].output = InputEnemyDistance(); break;
                    default: break;

                }
            }
        }
        // Runs the selected program once
        private void RunProgram(TableRexPrograms prog) // TODO: Estudiar visibilidad (public, private...)
        {
            //Out.WriteLine("Ejecutando tabla " + prog.ToString()); // DEBUG
            // Load working table
            TableRex currentProgram = new TableRex();
            switch (prog) {
                case TableRexPrograms.main: currentProgram = mainTable; break;
                case TableRexPrograms.onScannedRobot: currentProgram = onScannedTable; break;
                case TableRexPrograms.onHitByBullet: currentProgram = onHitByBulletTable; break;
                case TableRexPrograms.onHitRobot: currentProgram = onHitBotTable; break;
                case TableRexPrograms.onHitWall: currentProgram = onHitWallTable; break;
                default: currentProgram = mainTable; break;
            }
            // Cycle throught every program line
            for (int trPointer = TableRexBase.NINPUTS; trPointer < TableRexBase.NROWS; trPointer++) {
                //currentProgram[trPointer] = CallFunction(currentProgram, trPointer);
                CallFunction(currentProgram, trPointer);
                //Out.WriteLine(trPointer.ToString() + ">   " + currentProgram[trPointer].output.ToString()); // DEBUG
            }
            // Persist changes
            switch (prog) {
                case TableRexPrograms.main: mainTable = currentProgram; RefreshTableInputs(mainTable); break;
                case TableRexPrograms.onScannedRobot: onScannedTable = currentProgram; RefreshTableInputs(onScannedTable); break;
                case TableRexPrograms.onHitByBullet: onHitByBulletTable = currentProgram; RefreshTableInputs(onHitByBulletTable); break;
                case TableRexPrograms.onHitRobot: onHitBotTable = currentProgram; RefreshTableInputs(onHitBotTable); break;
                case TableRexPrograms.onHitWall: onHitWallTable = currentProgram; RefreshTableInputs(onHitWallTable); break;
                default: mainTable = currentProgram; break;
            }

        }
        // TODO: Optimizar esta funcion (demasiado trasiego de ROW...)(Comprobar si se persisten los cambios a los parámetros, para ahorrar devolver una row)
        private void CallFunction(TableRex t, int trPointer) {
            //TableRex.Row result = new TableRex.Row(progRow.function, progRow.param1, progRow.param2);
            switch (t[trPointer].function) {
                case (int)TableRexBase.FunctionIndex.absolute_value: t[trPointer].output = Absolute(t, t[trPointer].param1); break;
                case (int)TableRexBase.FunctionIndex.addition: t[trPointer].output = Add(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.and: t[trPointer].output = And(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.division: t[trPointer].output = Divide(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.equal: t[trPointer].output = Equal(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.generate_constant: t[trPointer].output = GenerateConstant(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.greater_than: t[trPointer].output = GreaterThan(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.less_than: t[trPointer].output = LessThan(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.modulo: t[trPointer].output = Modulo(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.multiplication: t[trPointer].output = Product(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.normalize_relative_angle: t[trPointer].output = NormalizeRelativeAngle(t, t[trPointer].param1); break;
                case (int)TableRexBase.FunctionIndex.not: t[trPointer].output = Not(t, t[trPointer].param1); break;
                case (int)TableRexBase.FunctionIndex.or: t[trPointer].output = Or(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.random_float: t[trPointer].output = RandomFloat(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.subtraction: t[trPointer].output = Subtract(t, t[trPointer].param1, t[trPointer].param2); break;
                case (int)TableRexBase.FunctionIndex.control_actuator: t[trPointer].output = ControlActuator(t, t[trPointer].param1, t[trPointer].param2); break;
            }
        }
        #endregion

        #region RUN
        public override void Run() {
            // Reading the data from the file
            string rawBin = "";
            try {
                using (Stream count = GetDataFile(Name + ".rxt")) {
                    if (count.Length != 0) {
                        using (TextReader tr = new StreamReader(count)) {
                            rawBin = tr.ReadToEnd();
                            //Out.WriteLine("rawBin = " + rawBin);  // DEBUG
                            //Out.WriteLine("rawBin = "); // DEBUG
                            // OUT DEBUG
                            //rawBin.Trim(char.Parse(TableRexBase.SEPARATOR));
                            //string[] rows = tRaw.Split(char.Parse(TableRexBase.SEPARATOR)
                            // OUT DEBUG
                        }
                    }
                }
            } catch (Exception) {
                Out.WriteLine("Could not read the TableRex table.");
            }

            rawBin = rawBin.Trim(char.Parse(TableRexBase.TSEPARATOR));
            string[] tables = rawBin.Split(char.Parse(TableRexBase.TSEPARATOR));

            if (tables.Length != 5) {
                Out.WriteLine("Invalid file data. Five (5) programs (sections sepparated by \"|\") are needed.");
                return;
            }

            for (int i = 0; i < tables.Length; i++) {
                switch (i) {
                    case 0: mainTable = new TableRex(tables[i]); break;
                    case 1: onScannedTable = new TableRex(tables[i]); break;
                    case 2: onHitByBulletTable = new TableRex(tables[i]); break;
                    case 3: onHitBotTable = new TableRex(tables[i]); break;
                    case 4: onHitWallTable = new TableRex(tables[i]); break;
                }
            }

            while (true)
                RunProgram(TableRexPrograms.main);

            //Out.WriteLine("Transformando 101110011110101100 en int: " + Support.BinaryStringToInt("101110011110101100").ToString()); // DEBUG
        }
        #endregion

        #region EventHandling
        public override void OnScannedRobot(ScannedRobotEvent evnt) {
            // Enemy attributes
            lastEnemyVelocity = evnt.Velocity;
            lastEnemyEnergy = evnt.Energy;
            lastEnemyHeading = evnt.Heading;
            lastEnemyBearing = evnt.Bearing;
            lastEnemyDistance = evnt.Distance;
            RunProgram(TableRexPrograms.onScannedRobot);
        }
        public override void OnHitByBullet(HitByBulletEvent evnt) {
            RunProgram(TableRexPrograms.onHitByBullet);
        }
        public override void OnHitRobot(HitRobotEvent evnt) {
            RunProgram(TableRexPrograms.onHitRobot);
        }
        public override void OnHitWall(HitWallEvent evnt) {
            RunProgram(TableRexPrograms.onHitWall);
        }
        #endregion

    }
}