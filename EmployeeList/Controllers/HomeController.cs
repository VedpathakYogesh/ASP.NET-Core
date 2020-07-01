using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeList.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeList.Controllers
{
    public class HomeController : Controller
    {

        private readonly EmployeeContext _dbContext;

        public HomeController(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var _emplst = _dbContext.tblEmployees.
                            Join(_dbContext.tblSkills, e => e.SkillID, s => s.SkillID,
                            (e, s) => new EmployeeViewModel
                            {
                                EmployeeID = e.EmployeeID,
                                EmployeeName = e.EmployeeName,
                                PhoneNumber = e.PhoneNumber,
                                Skill = s.Title,
                                YearsExperience = e.YearsExperience
                            }).ToList();
            IList<EmployeeViewModel> emplst = _emplst;
            return View(emplst);
        }

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Save Data into table
        /// </summary>
        /// <param name="Ev"></param>
        /// <returns></returns>
        [HttpPost]
       
        public IActionResult Create(EmployeeViewModel Ev)
        {
            if (Ev !=null)
            {
                var tblEmployee = new tblEmployee()
                {
                    EmployeeID = Ev.EmployeeID,
                    EmployeeName = Ev.EmployeeName,
                    PhoneNumber = Ev.PhoneNumber,
                 //   Skil = Ev.Skill,
                    YearsExperience = Ev.YearsExperience
                        
                };

                var tblSkill = new tblSkill()
                {
                    Title = Ev.Skill
                };

                _dbContext.tblEmployees.Add(tblEmployee);
                _dbContext.tblSkills.Add(tblSkill);
                _dbContext.SaveChanges();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
