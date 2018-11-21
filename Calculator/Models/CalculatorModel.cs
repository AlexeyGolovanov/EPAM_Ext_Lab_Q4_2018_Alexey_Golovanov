using Calculator.Resources;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class CalcModel
    {
        [Display(Name = "x", ResourceType = typeof(CalcResources))]
        [Required]
        public int X { get; set; }

        [Display(Name = "y", ResourceType = typeof(CalcResources))]
        [Required]
        public int Y { get; set; }

        [Display(Name = "Result", ResourceType = typeof(CalcResources))]
        public string Result { get; set; }

        [Display(Name = "OpName", ResourceType = typeof(CalcResources))]
        public Operation Op { get; set; }
    }
}