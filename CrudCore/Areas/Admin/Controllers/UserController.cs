using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCore.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Utility.RoleName.Admin)]
    public class UserController : Controller
    {
        private readonly ICommonService commonService;
        private readonly IUserService userService;

        public UserController(ICommonService commonService, IUserService userService)
        {
            this.commonService = commonService;
            this.userService = userService;
        }






        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            UserViewModel userViewModel = new UserViewModel();
            ViewBag.CountryList = commonService.GetAllCountries();
            ViewBag.StateList = commonService.GetStatesByCountryId(userViewModel.User.Address.CountryId);
            ViewBag.CityList = commonService.GetCityByStateId(userViewModel.User.Address.StateId);

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult SaveUser(UserViewModel userViewModel)
        {
            userViewModel.User.AddressId = commonService.SaveAddress(userViewModel.User.Address);
            userService.SaveUser(userViewModel.User);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetUserList()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();


            //Paging Size (10,20,50,100)    
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var employeeList = userService.GetUserList(pageSize, skip, sortColumn, sortColumnDir, searchValue);
            recordsTotal = userService.GetUserCount(searchValue);

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = employeeList });
        }


        public IActionResult AddUser(int userId)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.User = userService.GetUserById(userId);

            ViewBag.CountryList = commonService.GetAllCountries();
            ViewBag.StateList = commonService.GetStatesByCountryId(userViewModel.User.Address.CountryId);
            ViewBag.CityList = commonService.GetCityByStateId(userViewModel.User.Address.StateId);

            return View("AddEmployee", userViewModel);
        }

        [HttpPost]
        public JsonResult DeleteUsereById(int userId)
        {
            userService.DeleteUserById(userId);
            return Json(true);
        }

         


        #region General

        public JsonResult GetCountryList()
        {
            var countries = commonService.GetAllCountries();
            return Json(countries);
        }

        public JsonResult GetStatesByCountryId(int countryId)
        {
            var states = commonService.GetStatesByCountryId(countryId);
            return Json(states);
        }

        public JsonResult GetCityByStateId(int stateId)
        {
            var cities = commonService.GetCityByStateId(stateId);
            return Json(cities);
        }

        #endregion



    }
}
