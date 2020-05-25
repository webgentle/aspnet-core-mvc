using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name = "Hindi language")]
        Hindi = 10,
        [Display(Name = "English language")]
        English = 11,
        [Display(Name = "German language")]
        German = 12,
        [Display(Name = "Chinese language")]
        Chinese = 13,
        [Display(Name = "Urdu language")]
        Urdu =  14
    }
}
