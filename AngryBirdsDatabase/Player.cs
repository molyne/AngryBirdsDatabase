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
        [Key]
        public int PlayerKey { get; set; }

        [Required]
        [MaxLength(20)]
        public string PlayerName { get; set; }

        public virtual ICollection<Score> Scores { get; set; }



    }
}
