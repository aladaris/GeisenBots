using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Robocode;

namespace ManagerTool {
    [Serializable]
    public class BattleResultsSerializble {
        public int BulletDamage { get; set; }
        public int BulletDamageBonus { get; set; }
        public int First { get; set; }
        public int LastSurvivorBonus { get; set; }
        public int RamDamage { get; set; }
        public int RamDamageBonus { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }
        public int Seconds { get; set; }
        public int Survival { get; set; }
        public string TeamLeaderName { get; set; }
        public int Thirds { get; set; }

        public BattleResultsSerializble(BattleResults br) {
            if (br != null) {
                BulletDamage = br.BulletDamage;
                BulletDamageBonus = br.BulletDamageBonus;
                First = br.Firsts;
                LastSurvivorBonus = br.LastSurvivorBonus;
                RamDamage = br.RamDamage;
                RamDamageBonus = br.RamDamageBonus;
                Rank = br.Rank;
                Score = br.Score;
                Seconds = br.Seconds;
                Survival = br.Survival;
                TeamLeaderName = br.TeamLeaderName;
                Thirds = br.Thirds;
            }
        }

        public BattleResultsSerializble() { }

    }
}
