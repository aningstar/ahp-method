﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHP.Models;

namespace AHP.Controllers
{
    public class CriterionController : Controller
    {
        // GET: Criterion/AddCriterion
        public ActionResult AddCriterion()
        {
            var criterion = new Criterion()
            {
                CriterionName = "Kriterij1"
            };

            return View(criterion);
        }

        // GET: Criterion/EditCriterion
        public ActionResult EditCriteria()
        {
            var criterion = new Criterion()
            {
                CriterionName = "Kriterij1"
            };

            return View(criterion);
        }
    }
}