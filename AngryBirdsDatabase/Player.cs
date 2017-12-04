using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirdsDatabase
{
    class Player
    {
        [Key] public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int CurrentLevel { get; set; }
        public int TotalScore { get; set; }

        public virtual ICollection<Score> Scores { get; set; }


    }
}
