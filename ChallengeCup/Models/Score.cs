using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class Score
    {
        [Key]
        public string ScoreId { get; set; }

        //得分
        public int Mark { get; set; }

        //评价
        public string Evaluate { get; set; }
    }
}
