using System.ComponentModel.DataAnnotations;

namespace CSharpCommon.Utils.UnitConversion {

    public enum UnitOfMeasure {
        [Display(Name = "Meter")]
        Meter = 0,
        [Display(Name = "Yards")]
        Yards = 1,
        [Display(Name = "Feet")]
        Feet = 2,
        [Display(Name = "Inches")]
        Inches = 3,
        [Display(Name = "Centimeters")]
        Centimeters = 4,
        [Display(Name = "Millimeters")]
        Millimeters = 5
    }

}
