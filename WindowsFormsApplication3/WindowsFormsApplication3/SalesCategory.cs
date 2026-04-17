using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public enum SalesCategory
    {
        [Display(Name ="원자재")]
        RawMaterials=1,

        [Display(Name ="부자재")]
        SubMaterials=2,

        [Display(Name ="완성품")]
        FinishedGoods=3
    }
}
