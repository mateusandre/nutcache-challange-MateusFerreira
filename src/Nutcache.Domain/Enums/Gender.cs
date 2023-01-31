using System.ComponentModel.DataAnnotations;

namespace Nutcache.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        Female,
        Other
    }
}
