﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            return View();
        }
    }
}