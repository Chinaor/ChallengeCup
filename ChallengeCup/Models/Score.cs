using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class Score
    {
        public string Id { get; set; }

        //得分
        public int Mark { get; set; }

        //评价
        public string Description { get; set; }
    }
}
