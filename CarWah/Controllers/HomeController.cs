﻿using CarWah.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarWah.Controllers
{
    
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            List<Empleado> empleados = new List<Empleado>();
            ViewBag.Empleado = empleados.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}