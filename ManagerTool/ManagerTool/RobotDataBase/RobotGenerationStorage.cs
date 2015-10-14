using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerTool {
    [Serializable]
    public class RobotGenerationStorage {
        public const string FILE_EXTENSION = "rgdb";

        public string Name { get; set; }
        public uint Generation { get; set; }
        public List<RobotEntry> Robots { get; set; }

        public RobotGenerationStorage(string name = "noname", uint gen = 0) : this() {
            Name = name;
            Generation = gen;
        }
        public RobotGenerationStorage() {
            Robots = new List<RobotEntry>();
        }
    }
}
