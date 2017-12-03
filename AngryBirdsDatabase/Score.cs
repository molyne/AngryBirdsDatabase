using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirdsDatabase
{
    class Score
    {
        public string PlayerId { get; set; }
        public int LevelId { get; set; }
        public int LevelScore { get; set; }
        public int BirdsLeft { get; set; }

    }
}
