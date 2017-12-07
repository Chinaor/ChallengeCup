using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class Medicine
    {
        [Key]
        public string Id { get; set; }

        //药名
        [Required]
        public string  Name { get; set; }

        //种类，处方药/非处方药
        [Required]
        public string Type { get; set; }
        
        //适应症
        [Required]
        public string Indication { get; set; }

        //禁忌症
        [Required]
        public string Contraindication { get; set; }

        //使用说明
        [Required]
        public string Description { get; set; }

        //药品价格
        [Required]
        public double Price { get; set; }
    }
}
