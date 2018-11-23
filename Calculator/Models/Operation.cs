namespace Calculator.Models
{
    using System.ComponentModel.DataAnnotations;
    using Resources;
    
    public enum Operation
    {
        [Display(Name = "Add", ResourceType = typeof(CalcResources))]
        Add,

        [Display(Name = "Prod", ResourceType = typeof(CalcResources))]
        Prod,

        [Display(Name = "Substract", ResourceType = typeof(CalcResources))]
        Substract,

        [Display(Name = "Divide", ResourceType = typeof(CalcResources))]
        Div,

        [Display(Name = "Equal", ResourceType = typeof(CalcResources))]
        Eq,

        [Display(Name = "CompB", ResourceType = typeof(CalcResources))]
        CompB,

        [Display(Name = "CompM", ResourceType = typeof(CalcResources))]
        CompM,

        [Display(Name = "Pow", ResourceType = typeof(CalcResources))]
        Pow
    }
}