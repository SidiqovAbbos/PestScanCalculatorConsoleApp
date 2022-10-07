using System.ComponentModel.DataAnnotations;

namespace PestScanCalculatorConsoleApp.Model
{
    public enum Operation
    {
        [Display(Name = "+")]
        Addition = 1,

        [Display(Name = "-")]
        Subtraction,

        [Display(Name = "*")]
        Multiplication,

        [Display(Name = "/")]
        Division,
    }


}
