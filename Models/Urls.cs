using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace nav.Models
{
    public class Urls
    {
        public int Id { get; set; }
        [Display(Name = "网址")]
        public string HpyerHref { get; set; }
        [Display(Name = "内容")]
        public string HpyerUrl { get; set; }
        [Display(Name = "状态")]
        public string HpyerCatalog { get; set; }
        
    }
}
