﻿using MVCMusicStore2019.ViewModels.ExampleDome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class ExampleStudentController : Controller
    {
        // GET: ExampleStudent
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student bo = new Student
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Gender = model.Gender,
                    UserName = model.UserName,
                    NiName = model.NiName,
                    Birthday = model.Birthday,
                    Age = model.Age,
                    Password = model.Password,
                    ConfirmPassword=model.ConfirmPassword,
                    Email=model .Email,
                    Contribution=model.Contribution,
                    CreatTime=model.CreatTime
                };
                return View(model);
            }
            return View(model);
            
        }
        public ActionResult jQueryValidation()
        {
             return View();
        }
    }
}