﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirdsDatabase
{
    class Level
    {
        [Key] public int LevelId { get; set; }
        public int Birds { get; set; }

        public virtual IList<Score> Scores{ get; set; }
    }
}
