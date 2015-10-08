using System;
using System.Collections.Generic;

using Robocode;
using Robocode.Control;
using Robocode.Control.Events;

namespace ManagerTool {
    class BattleRunner {
        RobocodeEngine _engine;

        public BattleRunner(String roboPath = @"C:\robocode") {
            _engine = new RobocodeEngine(roboPath);
            // Show the Robocode battle view
            _engine.Visible = true;

            int numberOfRounds = 5;
            BattlefieldSpecification battlefield = new BattlefieldSpecification(800, 600); // 800x600
            RobotSpecification[] selectedRobots = _engine.GetLocalRepository("sample.RamFire,sample.Corners");

            BattleSpecification battleSpec = new BattleSpecification(numberOfRounds, battlefield, selectedRobots);

            // Run our specified battle and let it run till it is over
            _engine.RunBattle(battleSpec, true /* wait till the battle is over */);

            // Cleanup our RobocodeEngine
            _engine.Close();
        }
    }
}
