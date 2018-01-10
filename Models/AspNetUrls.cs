using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace nav.Models
{
    public class AspNetUrls
    {
        public int Id { get; set; }
        [Display(Name = "网址")]
        public string HpyerUrl { get; set; }
        [Display(Name = "内容")]
        public string HpyerText { get; set; }
        [Display(Name = "分类")]
        public string HpyerCatalog { get; set; }

    }
}
