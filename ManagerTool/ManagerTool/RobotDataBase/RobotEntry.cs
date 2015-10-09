using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Robocode;

namespace ManagerTool {
    [Serializable]
    public class RobotEntry {
        public uint Id { get; set; }
        public string ProgFilePath { get; set; }
        public BattleResultsSerializble LastResults { get; set; }

        public RobotEntry(uint id, string file = ".", BattleResultsSerializble results = null) {
            Id = id;
            ProgFilePath = file;
            LastResults = results;
        }

        public RobotEntry() : this(0) { }
    }
}
