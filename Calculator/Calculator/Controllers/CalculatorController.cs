﻿namespace Calculator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Helpers;
    using Models;
    using Resources;
 
    public class CalculatorController : Controller
    {
        private const int XDefault = 20;
        private const int YDefault = 18;
        private const string ResDefault = "empty";

        public static List<string> Results { get; protected set; } = new List<string>();

        public ActionResult Add()
        {
            return this.View(new CalcModel() { X = XDefault, Y = YDefault, Result = ResDefault });
        }

        [HttpPost]
        public ActionResult Add(CalcModel model)
        {
            var result = string.Empty;

            switch (model.Op)
            {
                case Operation.Add:
                    result = (model.X + model.Y).ToString();
                    break;
                case Operation.Prod:
                    result = ((long)model.X * model.Y).ToString();
                    break;
                case Operation.Substract:
                    result = (model.X - model.Y).ToString();
                    break;
                case Operation.Div:
                    result = (model.Y == 0) ? CalcResources.zeroDivision : Math.Round((double)model.X / model.Y, 3).ToString();
                    break;
                case Operation.Eq:
                    result = (model.X == model.Y).ToString();
                    break;
                case Operation.CompB:
                    result = (model.X > model.Y).ToString();
                    break;
                case Operation.CompM:
                    result = (model.X < model.Y).ToString();
                    break;
                case Operation.Pow:
                    result = Math.Pow(model.X, model.Y).ToString();
                    break;
            }

            model.Result = string.Format("{4:d MMMM H:mm} {0}{2}{1} = {3}", model.X, model.Y, model.Op.DisplayName(), result, DateTime.Now);

            Results.Add(model.Result);

            return this.View(model);
        }
    }
}