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
        [Range(1,100)]
        [Required]
        public int Mark { get; set; }

        //评价
        [DataType(DataType.Text)]
        public string Evaluate { get; set; }
    }
}
