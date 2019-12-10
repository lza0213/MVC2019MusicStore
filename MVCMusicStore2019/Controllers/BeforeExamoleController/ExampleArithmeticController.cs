using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class ExampleArithmeticController : Controller
    {
        //四则运算实现，+、-、*、/
        public ActionResult Index(float num1,float num2,string operation)
        {
            float result;
            switch (operation)
            {
                case "+":result = num1 + num2;
                    break;
                case "-":result = num1 - num2;
                    break;
                case "*":result = num1 * num2;
                    break;
                case "/":result = num1 / num2;
                    break;
                default:Console.Write("您的输入有误");
                    break;
            }
            return View();
        }
    }
}