﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context context = new Context();

        public ActionResult Index()
        {
            var statistic1 = context.Categories.Count().ToString();
            var statistic2 = context.Headings.Where(x => x.Category.CategoryName == "Yazılım").Count().ToString();
            var statistic3 = context.Writers.Where(x => x.WriterName.Contains("a")).Count().ToString();
            var statistic4 = context.Headings
                .GroupBy(x => x.Category.CategoryName)
                .OrderByDescending(x => x.Count())
                .Select(y => y.Key)
                .FirstOrDefault();
            var statistic5 = 
                context.Categories.Where(x=>x.CategoryStatus==true).Count() -
                context.Categories.Where(x=>x.CategoryStatus==false).Count();

            List<object> statistic = new List<object>();
            statistic.Add(statistic1);
            statistic.Add(statistic2);
            statistic.Add(statistic3);
            statistic.Add(statistic4);
            statistic.Add(statistic5);

            ViewBag.statistic = statistic;
            return View();
        }
    }
}