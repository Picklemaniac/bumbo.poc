using bumbo.poc.data.Repositories;
using bumbo.poc.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Xml.Linq;

namespace bumbo.poc.web.Controllers
{
    public class PrognoseController : Controller
    {

        public PrognoseController()
        {
        }
        //Voor POC is branchID weg gelaten.

        public IActionResult Index(int? year, int? week)
        {
            return View();
        }

        
        [HttpGet("Prognose/{year?}/{week?}")]
        public IActionResult Create([FromRoute] int? year, [FromRoute] int? week)
        {
            if (!year.HasValue || !week.HasValue)
            {
                year = DateTime.Today.Year;
                week = ISOWeek.GetWeekOfYear(DateTime.Today);
            }

            PrognoseViewModel prognoseViewModel = new PrognoseViewModel();

            prognoseViewModel.BranchId = 1;
            prognoseViewModel.year = year.Value;
            prognoseViewModel.week = week.Value;
            prognoseViewModel.FirstDayOfWeek = ISOWeek.ToDateTime(year.Value, week.Value, DayOfWeek.Monday);

            return View(prognoseViewModel);
        }

        [HttpPost("Prognose/{year}/{week}")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ExpectedPackages", "ExpectedCustomers")] [FromRoute] int year, [FromRoute] int week, PrognoseViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                for (int i = 0; i < viewModel.ExpectedCustomers?.Count; i++)
                {
                    DateTime date = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday).AddDays(i);
                    int numberOfCustomers = viewModel.ExpectedCustomers[i];

                    //Als er nog geen prognose input is voor deze DateTime, maak een nieuwe aan

                    //Anders updaten 
                }

                for (int i = 0; i < viewModel.ExpectedPackages?.Count; i++)
                {
                    DateTime date = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday).AddDays(i);
                    int numberOfCustomers = viewModel.ExpectedPackages[i];
                    //Als er nog geen prognose input is voor deze DateTime, maak een nieuwe aan

                    //Anders updaten
                }
            }

            return View(viewModel);
        }
    }
}
