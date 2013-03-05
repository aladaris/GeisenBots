using System;
using System.IO;
using System.Drawing;

using Robocode;

namespace Aladaris
{
    public static class Support
    {
        // Returns a string representating the binary form of X at a fixed size (filled with zeros at left)
        public static string IntToBinaryString(int x, int size) // TODO: Poner en un fichero AUX o UTILS o algo así
        {
            char[] bits = new char[size];
            int i = 0;

            while (i < size)
            {
                if (x != 0)
                {
                    bits[i++] = (x & 1) == 1 ? '1' : '0';
                    x >>= 1;
                }
                else
                {
                    bits[i++] = '0';
                }
            }

            Array.Reverse(bits, 0, i);
            return new string(bits);
        }

        public static int BinaryStringToInt(string bs) // TODO: Poner en un fichero AUX o UTILS o algo así
        {
            int result = 0;
            //Out.WriteLine("[BtI] In = " + bs); // DEBUG
            char[] bits = bs.ToCharArray();

            Array.Reverse(bits);
            //Out.WriteLine("[BtI] bits.reverse = " + bits.ToString()); // DEBUG
            for (int i = 0; i < bits.Length; i++)
            {
                //Out.WriteLine("[BtI] bits[" + i.ToString() + "] * Math.Pow(2, " + exp.ToString() + ") = " + ((int)Char.GetNumericValue(bits[i])).ToString() + " * " + ((int)Math.Pow(2, i)).ToString()); // DEBUG
                //Out.WriteLine("[BtI] " + i.ToString() + " Result = " + result.ToString()); // DEBUG
                result += (int)Char.GetNumericValue(bits[i]) * (int)Math.Pow(2, i);
            }
            return result;
        }

        public static double PointsDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }

    // Class containing all the data related with the TABLEREX system
    public static class TableRexBase
    {
        public const int NROWS = 128;          // Numbers of rows on the table
        public const int ROWLENGHT = 18;       // Row Lenght in bits
        public const string SEPARATOR = ";";   // Rows Separator for the RAW string binary data files
        public const string TSEPARATOR = "|"; // TableRex programs separator
        public const int BFUNCTIONSIZE = 4;
        public const int BPARAMETERSIZE = 7;
        public const int NINPUTS = 20; // Number of inputs on the table (first NINPUTS rows of the table)
        // List of all the function names and its respective (decimal) value
        public enum FunctionIndex
        {
            greater_than = 0,
            less_than = 1,
            equal = 2,
            addition = 3,
            subtraction = 4,
            multiplication = 5,
            division = 6,
            absolute_value = 7,
            and = 8,
            or = 9,
            not = 10,
            generate_constant = 11,
            modulo = 12,
            random_float = 13,
            normalize_relative_angle = 14,
            control_actuator = 15
        };
    }

    public class TableRex
    {
        // Class that represent each row of a TableRex table
        public class Row
        {
            public int function;  // 16  - 2^4 - 4 bits
            public int param1;    // 128 - 2^7 - 7 bits
            public int param2;    // 128 - 2^7 - 7 bits
            public double output;

            // Default builder
            public Row()
            {
                function = param1 = param2 = 0;
                output = 0.0;
            }
            // Parametric builder
            public Row(int f, int p1, int p2, int o)
            {
                function = f;
                param1 = p1;
                param2 = p2;
                output = o;
            }
            // Parametric builder
            public Row(int f, int p1, int p2)
            {
                function = f;
                param1 = p1;
                param2 = p2;
                output = 0;
            }

        }

        // Base table structure, just an array of 'Row' objects
        private Row[] tabla;

        // Default builder
        public TableRex()
        {
            tabla = new Row[TableRexBase.NROWS];
            //trPointer = 0;
        }
        // Parametric builder
        public TableRex(string rawBinaryString)
        {
            tabla = new Row[TableRexBase.NROWS];
            //trPointer = 0;
            ParseRawBinaryData(rawBinaryString);
        }
        // Parse a RAW binary string, containning all the TableRex program, into the table.
        private void ParseRawBinaryData(string rawBinaryString)
        {
            rawBinaryString = rawBinaryString.Trim(char.Parse(TableRexBase.SEPARATOR));
            string[] rows = rawBinaryString.Split(char.Parse(TableRexBase.SEPARATOR));
            for (int i = 0; i < rows.Length + TableRexBase.NINPUTS; i++)
            {
                if (i < TableRexBase.NINPUTS)  // First NINPUTS rows are inputs
                    tabla[i] = new Row(0, 0, 0, 0);
                else
                {
                    // Comprobación de funcionamiento: http://ideone.com/QLkJfu
                    int funct = Support.BinaryStringToInt(rows[i - TableRexBase.NINPUTS].Substring(0, TableRexBase.BFUNCTIONSIZE));
                    int p1 = Support.BinaryStringToInt(rows[i - TableRexBase.NINPUTS].Substring(4, TableRexBase.BPARAMETERSIZE));
                    int p2 = Support.BinaryStringToInt(rows[i - TableRexBase.NINPUTS].Substring(11, TableRexBase.BPARAMETERSIZE));
                    tabla[i] = new Row(funct, p1, p2);
                }
            }
        }

        // [] operator overload
        public TableRex.Row this[int i]
        {
            get { return tabla[i]; }
            set { tabla[i] = value; }
        }

        // Table's Lenght
        public int Lenght
        {
            get { return tabla.Length; }
        }
        
        //// TableRex functions
        //public double GreaterThan(int i1, int i2)
        //{
        //    if (tabla[i1].output > tabla[i2].output)
        //        return 1;
        //    return 0;
        //}
        //public double LessThan(int i1, int i2)
        //{
        //    if (tabla[i1].output < tabla[i2].output)
        //        return 1;
        //    return 0;
        //}
        //public double Equal(int i1, int i2)
        //{
        //    if (tabla[i1].output == tabla[i2].output)
        //        return 1;
        //    return 0;
        //}
        //public double Add(int i1, int i2) { return (tabla[i1].output + tabla[i2].output); }
        //public double Product(int i1, int i2) { return (tabla[i1].output * tabla[i2].output); }
        //public double Divide(int i1, int i2) { return ((int)(tabla[i1].output / tabla[i2].output)); } // TODO: Comprobar que (int)(i1 / i2) se comporta como se espera
        //public double Absolute(int i1) { return Math.Abs(tabla[i1].output); }
        //private double LogicOperators(int i1, int i2, string op)
        //{
        //    bool b1 = true;
        //    bool b2 = true;
        //    bool r = true;

        //    if (tabla[i1].output < 1)
        //        b1 = false;
        //    if (tabla[i2].output < 1)
        //        b2 = false;

        //    switch (op.ToLower())
        //    {
        //        case "and": r = b1 && b2; break;
        //        case "or": r = b1 || b2; break;
        //        case "not": r = !b1; break;
        //        default: return 0;
        //    }
        //    if (r)
        //        return 1;
        //    return 0;
        //}
        //public double And(int i1, int i2)
        //{
        //    return LogicOperators(i1, i2, "and");
        //}
        //public double Or(int i1, int i2)
        //{
        //    return LogicOperators(i1, i2, "or");
        //}
        //public double Not(int i1, int i2)
        //{
        //    return LogicOperators(i1, i2, "not");
        //}
        //public double GenerateConstant(int i1, int i2)
        //{
        //    return i2 - i1;
        //}
        //public double Modulo(int i1, int i2) { return (tabla[i1].output % tabla[i2].output); }
        //public double RandomFloat()
        //{
        //    Random rand = new Random((int)(DateTime.Now.Millisecond / DateTime.Now.Second));
        //    return rand.Next(-99999, 99999) / (rand.Next() + 1);
        //}
        //public double NormalizeRelativeAngle(int i1)
        //{
        //    // Source: http://www.java2s.com/Tutorial/Java/0120__Development/Normalizesanangletoarelativeangle.htm
        //    return (tabla[i1].output %= 360) >= 0 ? (tabla[i1].output < 180) ? tabla[i1].output : tabla[i1].output - 360 : (tabla[i1].output >= -180) ? tabla[i1].output : tabla[i1].output + 360;
        //}
        //public double ControlActuator(int i1, int i2) // TODO: Implementar un modo de hacer llamadas a los actuadores del robot
        //{
        //    return 1;
        //} 

    }

    public class EisenBot : AdvancedRobot
    {
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


        // TableRex functions
        // TODO: Desacoplar; Esto debería ir en TableRex, pero 'ControlActuator' is a bitch
        private double GreaterThan(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando GreaterThan con " + i1.ToString() + ", " + i2.ToString());
            if (t[i1].output > t[i2].output)
                return 1;
            return 0;
        }
        private double LessThan(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando LessThan con " + i1.ToString() + ", " + i2.ToString());
            if (t[i1].output < t[i2].output)
                return 1;
            return 0;
        }
        private double Equal(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando Equal con " + i1.ToString() + ", " + i2.ToString());
            if (t[i1].output == t[i2].output)
                return 1;
            return 0;
        }
        private double Add(TableRex t, int i1, int i2) { /*Out.WriteLine("Ejecutando Add con " + i1.ToString() + ", " + i2.ToString());*/ return (t[i1].output + t[i2].output); }
        private double Subtract(TableRex t, int i1, int i2) { /*Out.WriteLine("Ejecutando Subtract con " + i1.ToString() + ", " + i2.ToString());*/ return (t[i1].output - t[i2].output); }
        private double Product(TableRex t, int i1, int i2) { /*Out.WriteLine("Ejecutando Product con " + i1.ToString() + ", " + i2.ToString());*/ return (t[i1].output * t[i2].output); }
        private double Divide(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando Divide con " + i1.ToString() + ", " + i2.ToString());
            if (t[i2].output != 0)
                return (t[i1].output / t[i2].output);
            return (t[i1].output / (t[i2].output + 1));
        }
        private double Absolute(TableRex t, int i1) { /*Out.WriteLine("Ejecutando Absolute con " + i1.ToString());*/ return Math.Abs(t[i1].output); }
        private enum LogicOps { and, or, not };
        private double LogicOperators(TableRex t, int i1, int i2, LogicOps op)
        {
            bool b1 = true;
            bool b2 = true;
            bool r = true;

            if (t[i1].output < 1)
                b1 = false;
            if (t[i2].output < 1)
                b2 = false;

            switch (op)
            {
                case LogicOps.and : r = b1 && b2; break;
                case LogicOps.or  : r = b1 || b2; break;
                case LogicOps.not : r = !b1; break;
                default           : return 0;
            }
            if (r)
                return 1;
            return 0;
        }
        private double And(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando And con " + i1.ToString() + ", " + i2.ToString());
            return LogicOperators(t, i1, i2, LogicOps.and);
        }
        private double Or(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando Or con " + i1.ToString() + ", " + i2.ToString());
            return LogicOperators(t, i1, i2, LogicOps.or);
        }
        private double Not(TableRex t, int i1)
        {
            //Out.WriteLine("Ejecutando Not con " + i1.ToString());
            return LogicOperators(t, i1, 0, LogicOps.not);
        }
        private double GenerateConstant(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando GenerateConstant con " + i1.ToString() + ", " + i2.ToString());
            return i2 - i1;
        }
        private double Modulo(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando Modulo con " + i1.ToString() + ", " + i2.ToString());
            if ((int)t[i2].output != 0)
                return ((int)t[i1].output % ((int)t[i2].output));
            return ((int)t[i1].output % ((int)t[i2].output + 1));
        }
        private double RandomFloat(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando RandomFloat con " + i1.ToString() + ", " + i2.ToString());
            Random rand = new Random((int)X % ((int)Energy + 1) + (int)Time );
            return (rand.NextDouble() * t[i1].output + t[i2].output);
        }
        private double NormalizeRelativeAngle(TableRex t, int i1)
        {
            //Out.WriteLine("Ejecutando NormalizeRelativeAngle con " + i1.ToString());
            // Source: http://www.java2s.com/Tutorial/Java/0120__Development/Normalizesanangletoarelativeangle.htm
            //return (t[i1].output %= 360) >= 0 ? (t[i1].output < 180) ? t[i1].output : t[i1].output - 360 : (t[i1].output >= -180) ? t[i1].output : t[i1].output + 360;
            return Robocode.Util.Utils.NormalRelativeAngleDegrees(t[i1].output);
        }
        private double ControlActuator(TableRex t, int i1, int i2)
        {
            //Out.WriteLine("Ejecutando ControlActuator con " + i1.ToString() + ", " + i2.ToString());
            //Ahead(GenerateConstant(i1, i2)); // DEBUG
            switch (i1)
            {
                case 0   : return ActAhead(t[i2].output);
                case 1   : return ActAhead50();
                case 2   : return ActAheadDistanceToCenter();
                case 3   : return ActAheadHalfDistanceToWestWall();
                case 4   : return ActAheadHalfDistanceToNorthWall();
                case 5   : return ActAheadHalfDistanceToEastWall();
                case 6   : return ActAheadHalfDistanceToSouthWall();
                case 7   : return ActAheadDistanceToEnemy();
                case 8   : return ActAheadHalfDistanceToEnemy();
                case 9   : return ActBack(t[i2].output);
                case 10  : return ActBack50();
                case 11  : return ActBackDistanceToCenter();
                case 12  : return ActBackHalfDistanceToWestWall();
                case 13  : return ActBackHalfDistanceToNorthWall();
                case 14  : return ActBackHalfDistanceToEastWall();
                case 15  : return ActBackHalfDistanceToSouthWall();
                case 16  : return ActBackDistanceToEnemy();
                case 17  : return ActBackHalfDistanceToEnemy();
                case 18  : return ActTurnRight(t[i2].output);
                case 19  : return ActTurnRight10();
                case 20  : return ActTurnRight45();
                case 21  : return ActTurnRight90();
                case 22  : return ActTurnLeft(t[i2].output);
                case 23  : return ActTurnLeft10();
                case 24  : return ActTurnLeft45();
                case 25  : return ActTurnLeft90();
                case 26  : return ActTurnToCenter();
                case 27  : return ActTurnAwayFromCenter();
                case 28  : return ActTurnToEnemy();
                case 29  : return ActTurnAwayFromEnemy();
                case 30  : return ActTurnPerpendicularToEnemy();
                case 31  : return ActTurnParallelToNearestWall();
                case 32  : return ActTurnPerpendicularToNearestWall();
                case 33  : return ActFire(t[i2].output);
                case 34  : return ActFire1();
                case 35  : return ActFire2();
                case 36  : return ActFire3();
                case 37  : return ActTurnGunRight(t[i2].output);
                case 38  : return ActTurnGunRight10();
                case 39  : return ActTurnGunRight45();
                case 40  : return ActTurnGunRight90();
                case 41  : return ActTurnGunLeft(t[i2].output);
                case 42  : return ActTurnGunLeft10();
                case 43  : return ActTurnGunLeft45();
                case 44  : return ActTurnGunLeft90();
                case 45  : return ActTurnGunToCenter();
                case 46  : return ActTurnGunToEnemy();


                default  : break;
            }
            return 1;
        }

        // Actuators/Action Functions

        // MOVEMENT
        private int ActAhead(double value)
        {
            //Out.WriteLine("[Actuator] ActAhead " + value.ToString()); // DEBUG
            Ahead(value);
            return 1;
        }
        private int ActAhead50()
        {
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
        private int ActAheadHalfDistanceToWestWall( )
        {
            double distance = InputDistanceToWestWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToWestWall: " + distance.ToString()); // DEBUG
            Ahead(distance/2);
            return 1;
        }
        private int ActAheadHalfDistanceToNorthWall()
        {
            double distance = InputDistanceToNorthWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToNorthWall: " + distance.ToString()); // DEBUG
            Ahead(distance/2);
            return 1;
        }
        private int ActAheadHalfDistanceToEastWall()
        {
            double distance = InputDistanceToEastWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToEastWall: " + distance.ToString()); // DEBUG
            Ahead(distance / 2);
            return 1;
        }
        private int ActAheadHalfDistanceToSouthWall()
        {
            double distance = InputDistanceToSouthWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToSouthWall" + distance.ToString()); // DEBUG
            Ahead(distance / 2);
            return 1;
        }
        private int ActAheadDistanceToEnemy()
        {
            //Out.WriteLine("[Actuator] ActAheadDistanceToEnemy: " + lastEnemyDistance.ToString()); // DEBUG
            Ahead(lastEnemyDistance);
            return 1;
        }
        private int ActAheadHalfDistanceToEnemy()
        {
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToEnemy: " + (lastEnemyDistance / 2).ToString()); // DEBUG
            Ahead(lastEnemyDistance / 2);
            return 1;
        }
        private int ActBack(double value)
        {
            //Out.WriteLine("[Actuator] ActBack " + value.ToString()); // DEBUG
            Back(value);
            return 1;
        }
        private int ActBack50()
        {
            //Out.WriteLine("[Actuator] ActBack50"); // DEBUG
            Back(50);
            return 1;
        }
        private int ActBackDistanceToCenter()
        {
            double centerX = BattleFieldWidth / 2;  // Center X
            double centerY = BattleFieldHeight / 2; // Center Y
            double distance = Support.PointsDistance(centerX, centerY, X, Y);
            //Out.WriteLine("[Actuator] ActBackDistanceToCenter: " + distance.ToString()); // DEBUG
            Back(distance);
            return 1;
        }
        private int ActBackHalfDistanceToWestWall()
        {
            double distance = InputDistanceToWestWall();
            //Out.WriteLine("[Actuator] ActBackHalfDistanceToWestWall: " + distance.ToString()); // DEBUG
            Back(distance / 2);
            return 1;
        }
        private int ActBackHalfDistanceToNorthWall()
        {
            double distance = InputDistanceToNorthWall();
            //Out.WriteLine("[Actuator] ActBackHalfDistanceToNorthWall: " + distance.ToString()); // DEBUG
            Back(distance / 2);
            return 1;
        }
        private int ActBackHalfDistanceToEastWall()
        {
            double distance = InputDistanceToEastWall();
            //Out.WriteLine("[Actuator] ActAheadHalfDistanceToEastWall: " + distance.ToString()); // DEBUG
            Back(distance / 2);
            return 1;
        }
        private int ActBackHalfDistanceToSouthWall()
        {
            double distance = InputDistanceToSouthWall();
            //Out.WriteLine("[Actuator] ActBackHalfDistanceToSouthWall: " + distance.ToString()); // DEBUG
            Back(distance / 2);
            return 1;
        }
        private int ActBackDistanceToEnemy()
        {
            //Out.WriteLine("[Actuator] ActBackDistanceToEnemy: " + lastEnemyDistance.ToString()); // DEBUG
            Back(lastEnemyDistance);
            return 1;
        }
        private int ActBackHalfDistanceToEnemy()
        {
            //Out.WriteLine("[Actuator] ActBackHalfDistanceToEnemy: " + (lastEnemyDistance / 2).ToString()); // DEBUG
            Back(lastEnemyDistance / 2);
            return 1;
        }
        // TURNNING
        private int ActTurnRight(double value)
        {
            TurnRight(value);
            return 1;
        }
        private int ActTurnRight10()
        {
            return ActTurnRight(10);
        }
        private int ActTurnRight45()
        {
            return ActTurnRight(45);
        }
        private int ActTurnRight90()
        {
            return ActTurnRight(90);
        }
        private int ActTurnLeft(double value)
        {
            TurnLeft(value);
            return 1;
        }
        private int ActTurnLeft10()
        {
            return ActTurnLeft(10);
        }
        private int ActTurnLeft45()
        {
            return ActTurnLeft(45);
        }
        private int ActTurnLeft90()
        {
            return ActTurnLeft(90);
        }
        private double AbsBearing(double px, double py)
        {
            return (((py - Y) < 0 ? Math.PI : 0) + Math.Atan((px - X) / (py - Y)));
        }
        private double NormalizeBearing(double angle)
        {
            while (angle >  180) angle -= 360;
            while (angle < -180) angle += 360;
            return angle;
        }
        private int ActTurnToCenter()
        {
            double centerX = BattleFieldWidth / 2;
            double centerY = BattleFieldHeight / 2;
            //Out.WriteLine("[Actuator] ActTurnToCenter: " + AbsBearing(centerX, centerY).ToString()); // DEBUG
            TurnRight(AbsBearing(centerX, centerY));
            return 1;
        }
        private int ActTurnAwayFromCenter()
        {
            double centerX = BattleFieldWidth / 2;
            double centerY = BattleFieldHeight / 2;
            //Out.WriteLine("[Actuator] ActTurnAwayFromCenter: " + AbsBearing(centerX, centerY).ToString()); // DEBUG
            TurnRight(NormalizeBearing(AbsBearing(centerX, centerY) + 180));
            return 1;
        }
        private int ActTurnToEnemy()
        {
            TurnRight(NormalizeBearing(Heading - GunHeading + lastEnemyBearing));
            return 1;
        }
        private int ActTurnAwayFromEnemy()
        {
            TurnRight(NormalizeBearing(Heading - GunHeading + lastEnemyBearing + 180));
            return 1;
        }
        private int ActTurnPerpendicularToEnemy()
        {
            TurnRight(NormalizeBearing(Heading - GunHeading + lastEnemyBearing + 90));
            return 1;
        }
        enum walls { North, East, South, West };
        private walls GetNearestWall()
        {
            double dN, dE, dS, dW; // Distance to North, East, South and West
            walls nearest = walls.North;
            double nearestDistance = 0.0;
            dN = Support.PointsDistance(X, BattleFieldHeight, X, Y);
            dE = Support.PointsDistance(BattleFieldWidth, Y, X, Y);
            dS = Support.PointsDistance(X, 0, X, Y);
            dW = Support.PointsDistance(0, Y, X, Y);
            nearestDistance = dN;
            if (dE < nearestDistance)
            {
                nearest = walls.East;
                nearestDistance = dE;
            }
            if (dS < nearestDistance)
            {
                nearest = walls.South;
                nearestDistance = dS;
            }
            if (dW < nearestDistance)
            {
                nearest = walls.West;
                nearestDistance = dW;
            }
            return nearest;
        }
        private int ActTurnParallelToNearestWall()
        {
            double bearing = 0.0;
            switch (GetNearestWall())
            {
                case walls.North: bearing = NormalizeBearing(AbsBearing(X, BattleFieldHeight)); break;
                case walls.East: bearing = NormalizeBearing(AbsBearing(BattleFieldWidth, Y)); break;
                case walls.South: bearing = NormalizeBearing(AbsBearing(X, 0)); break;
                case walls.West: bearing = NormalizeBearing(AbsBearing(0, Y)); break;
            }
            if (bearing > 0)
                TurnRight(bearing-(bearing-90));
            else
                TurnLeft(bearing-(bearing-90));
            return 1;
        }
        private int ActTurnPerpendicularToNearestWall()
        {
            double bearing = 0.0;
            switch (GetNearestWall())
            {
                case walls.North: bearing = NormalizeBearing(AbsBearing(X, BattleFieldHeight) + 180); break;
                case walls.East: bearing = NormalizeBearing(AbsBearing(BattleFieldWidth, Y) + 180); break;
                case walls.South: bearing = NormalizeBearing(AbsBearing(X, 0) + 180); break;
                case walls.West: bearing = NormalizeBearing(AbsBearing(0, Y) + 180); break;
            }
            TurnRight(bearing);
            return 1;
        }

        // GUN
        private int ActFire(double value)
        {
            Fire(Math.Abs(value));
            return 1;
        }
        private int ActFire1()
        {
            return ActFire(1);
        }
        private int ActFire2()
        {
            return ActFire(2);
        }
        private int ActFire3()
        {
            return ActFire(3);
        }
        private int ActTurnGunRight(double value)
        {
            TurnGunRight(value);
            return 1;
        }
        private int ActTurnGunRight10()
        {
            return ActTurnGunRight(10);
        }
        private int ActTurnGunRight45()
        {
            return ActTurnGunRight(45);
        }
        private int ActTurnGunRight90()
        {
            return ActTurnGunRight(90);
        }
        private int ActTurnGunLeft(double value)
        {
            TurnGunLeft(value);
            return 1;
        }
        private int ActTurnGunLeft10()
        {
            return ActTurnGunLeft(10);
        }
        private int ActTurnGunLeft45()
        {
            return ActTurnGunLeft(45);
        }
        private int ActTurnGunLeft90()
        {
            return ActTurnGunLeft(90);
        }
        private int ActTurnGunToCenter()
        {
            double centerX = BattleFieldWidth / 2;
            double centerY = BattleFieldHeight / 2;
            //Out.WriteLine("[Actuator] ActTurnGunToCenter: " + AbsBearing(centerX, centerY).ToString()); // DEBUG
            return ActTurnGunRight(AbsBearing(centerX, centerY));
        }
        private int ActTurnGunToEnemy()
        {
            return ActTurnGunRight(lastEnemyBearing);
        }



        // Refresh the output value of the input rows (first NINPUTS of the table)
        private void RefreshTableInputs(TableRex t)
        {
            for (int i = 0; i < TableRexBase.NINPUTS; i++)
            {
                switch (i)
                {
                    case 0 : t[i].output = InputVelocity(); break;
                    case 1 : t[i].output = InputEnergy(); break;
                    case 2 : t[i].output = InputHeading(); break;
                    case 3 : t[i].output = InputGunHeading(); break;
                    case 4 : t[i].output = InputGunHeat(); break;
                    case 5 : t[i].output = InputRadarHeading(); break;
                    case 6 : t[i].output = InputRadarTurnRemaining(); break;
                    case 7 : t[i].output = InputDistanceToWestWall(); break;
                    case 8 : t[i].output = InputDistanceToNorthWall(); break;
                    case 9 : t[i].output = InputDistanceToEastWall(); break;
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
            Out.WriteLine("Ejecutando tabla " + prog.ToString()); // DEBUG
            // Load working table
            TableRex currentProgram = new TableRex();
            switch (prog)
            {
                case TableRexPrograms.main : currentProgram = mainTable; break;
                case TableRexPrograms.onScannedRobot: currentProgram = onScannedTable; break;
                case TableRexPrograms.onHitByBullet: currentProgram = onHitByBulletTable; break;
                case TableRexPrograms.onHitRobot: currentProgram = onHitBotTable; break;
                case TableRexPrograms.onHitWall: currentProgram = onHitWallTable; break;
                default                    : currentProgram = mainTable; break;
            }
            // Cycle throught every program line
            for (int trPointer = TableRexBase.NINPUTS; trPointer < TableRexBase.NROWS; trPointer++)
            {
                //currentProgram[trPointer] = CallFunction(currentProgram, trPointer);
                CallFunction(currentProgram, trPointer);
                //Out.WriteLine(trPointer.ToString() + ">   " + currentProgram[trPointer].output.ToString()); // DEBUG
            }
            // Persist changes
            switch (prog)
            {
                case TableRexPrograms.main: mainTable = currentProgram; RefreshTableInputs(mainTable); break;
                case TableRexPrograms.onScannedRobot: onScannedTable = currentProgram; RefreshTableInputs(onScannedTable); break;
                case TableRexPrograms.onHitByBullet: onHitByBulletTable = currentProgram; RefreshTableInputs(onHitByBulletTable); break;
                case TableRexPrograms.onHitRobot: onHitBotTable = currentProgram; RefreshTableInputs(onHitBotTable); break;
                case TableRexPrograms.onHitWall: onHitWallTable = currentProgram; RefreshTableInputs(onHitWallTable); break;
                default: mainTable = currentProgram;  break;
            }
            
        }
        // TODO: Optimizar esta funcion (demasiado trasiego de ROW...)(Comprobar si se persisten los cambios a los parámetros, para ahorrar devolver una row)
        private void CallFunction(TableRex t, int trPointer)
        {
            //TableRex.Row result = new TableRex.Row(progRow.function, progRow.param1, progRow.param2);
            switch (t[trPointer].function)
            {
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

        private void GenerateAllRandomTableRex()
        {
            int[] tabla = new int[TableRexBase.NROWS - TableRexBase.NINPUTS];
            Random r = new Random((int)this.X % ((int)this.Y + 1));

            // Writting the codded table to a file
            //try
            //{
                using (Stream fstream = GetDataFile(Name + ".rxt"))
                {
                    fstream.SetLength(0);
                    using (TextWriter tw = new StreamWriter(fstream))
                    {
                        // Create 5 tables
                        for (int nTabla = 0; nTabla < 5; nTabla++)  // 5 because we use five tables. TODO: Quitar el magic number '5'
                        {
                            // Generating random values for current table
                            for (int i = 0; i < tabla.Length; i++)
                            {
                                //Out.WriteLine(i.ToString() + " r"); // DEBUG
                                tabla[i] = r.Next((int)Math.Pow(2, TableRexBase.ROWLENGHT));
                            }

                            for (int i = 0; i < tabla.Length; i++)
                            {
                                tw.Write(Support.IntToBinaryString(tabla[i], TableRexBase.ROWLENGHT) + TableRexBase.SEPARATOR);
                                //Out.WriteLine(nTabla.ToString() + " Escribiendo linea número " + i.ToString()); // DEBUG
                            }
                            tw.Write(TableRexBase.TSEPARATOR);
                        }
                        //tw.Write("WTF MATHAFACKA"); // DEBUG
                    }
                }
            //}
            //catch (Exception)
            //{
                //Out.WriteLine("Could not write the TableRex table.");
            //}
        }

        public override void Run()
        {
            /*
            // Random Example Table
            int[] tabla = new int[TableRexBase.NROWS - TableRexBase.NINPUTS];
            Random r = new Random((int)this.X % ((int)this.Y+1));
            for (int i = 0; i < tabla.Length; i++)
            {
                tabla[i] = r.Next((int)Math.Pow(2, TableRexBase.ROWLENGHT));
            }

            // Writting the codded table to a file
            try
            {
                using (Stream count = GetDataFile(Name + ".rxt"))
                {
                    count.SetLength(0);
                    using (TextWriter tw = new StreamWriter(count))
                    {
                        for (int i = 0; i < TableRexBase.NROWS; i++)
                        {
                            tw.Write(Support.IntToBinaryString(tabla[i], TableRexBase.ROWLENGHT) + TableRexBase.SEPARATOR);
                            //Out.WriteLine("Escribiendo linea número: " + i.ToString()); // DEBUG
                        }
                    }
                }
            }
            catch (Exception)
            {
                Out.WriteLine("Could not write the TableRex table.");
            }
            */
            GenerateAllRandomTableRex();

            // Reading the data from the file
            string rawBin = "";
            try
            {
                using (Stream count = GetDataFile(Name + ".rxt"))
                {
                    if (count.Length != 0)
                    {
                        using (TextReader tr = new StreamReader(count))
                        {
                            rawBin = tr.ReadToEnd();
                            //Out.WriteLine("rawBin = "); // DEBUG
                            // OUT DEBUG
                            //rawBin.Trim(char.Parse(TableRexBase.SEPARATOR));
                            //string[] rows = tRaw.Split(char.Parse(TableRexBase.SEPARATOR)
                            // OUT DEBUG
                        }
                    }
                }
            }
            catch (Exception)
            {
                Out.WriteLine("Could not read the TableRex table.");
            }




            rawBin = rawBin.Trim(char.Parse(TableRexBase.TSEPARATOR));
            string[] tables = rawBin.Split(char.Parse(TableRexBase.TSEPARATOR));

            for (int i = 0; i < tables.Length; i++)
            {
                switch (i)
                {
                    case 0: mainTable = new TableRex(tables[i]); break;
                    case 1: onScannedTable = new TableRex(tables[i]); break;
                    case 2: onHitByBulletTable = new TableRex(tables[i]); break;
                    case 3: onHitBotTable = new TableRex(tables[i]); break;
                    case 4: onHitWallTable = new TableRex(tables[i]); break;
                }
            }


//            mainTable = new TableRex(rawBin);
            /*
            for (int i = 0; i < mainTable.Lenght; i++)
            {
                Out.WriteLine("i : " + i.ToString()); // DEBUG
                Out.WriteLine("[" + i.ToString() + "] " + mainTable[i].function.ToString() + " : " + mainTable[i].param1.ToString() + " : " + mainTable[i].param2.ToString()); // DEBUG
            }
            */

            while (1==1)
                RunProgram(TableRexPrograms.main);

            //Out.WriteLine("Transformando 101110011110101100 en int: " + Support.BinaryStringToInt("101110011110101100").ToString()); // DEBUG
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            // Enemy attributes
            lastEnemyVelocity = evnt.Velocity;
            lastEnemyEnergy   = evnt.Energy;
            lastEnemyHeading  = evnt.Heading;
            lastEnemyBearing  = evnt.Bearing;
            lastEnemyDistance = evnt.Distance;
            RunProgram(TableRexPrograms.onScannedRobot);
        }
        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            RunProgram(TableRexPrograms.onHitByBullet);
        }
        public override void OnHitRobot(HitRobotEvent evnt)
        {
            RunProgram(TableRexPrograms.onHitRobot);
        }
        public override void OnHitWall(HitWallEvent evnt)
        {
            RunProgram(TableRexPrograms.onHitWall);
        }

    }
}
