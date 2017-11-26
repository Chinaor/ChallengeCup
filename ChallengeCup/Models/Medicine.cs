using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class Medicine
    {
        public string Id { get; set; }

        //药名
        public string  Name { get; set; }

        //种类，处方药/非处方药
        public string Type { get; set; }
        
        //适应症
        public string Indication { get; set; }

        //禁忌症
        public string Contraindication { get; set; }

        //使用说明
        public string Description { get; set; }

        //药品价格
        public double Price { get; set; }
    }
}
