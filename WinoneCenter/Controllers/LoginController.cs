using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinoneCenter.Services;
using WinoneCenter.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WinoneCenter.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly EmployeeService _employeeService;
        private readonly LogService _logService;

        public LoginController(EmployeeService employeeService, CustomerService customerService, LogService logService)
        {
            _employeeService = employeeService;
            _customerService = customerService;
            _logService = logService;
        }

        [HttpGet]
        public IActionResult Login(string account, string password)
        {
            var employeeList = _employeeService.GetOneByEmployeeId(account);
            var customerList = _customerService.GetOneByCustomerId(account);
            var returnMsg = "";
            var returnObj = new Object();


            Employee employee = employeeList.Count() > 0 ? employeeList.First() : null;
            Customer customer = customerList.Count() > 0 ? customerList.First() : null;

            if(employee == null && customer == null)
            {
                returnMsg = "no_account";

                Log log = new Log
                {
                    Function = "LOGIN",
                    Description = string.Format("Account:{0}, Password:{1}", account, password),
                    ReturnMsg = returnMsg,
                    LastModified = DateTime.Now,
                    DataStatus = "Normal"
                };

                _logService.InsertOne(log);

            }else if(employee == null && customer != null)
            {
                if(customer.Password == password)
                {
                    returnObj = customer;

                    Log log = new Log
                    {
                        Function = "LOGIN",
                        Description = string.Format("Account:{0}, Password:{1}", account, password),
                        ReturnMsg = JsonConvert.SerializeObject(returnObj),
                        LastModified = DateTime.Now,
                        DataStatus = "Normal",
                    };

                    _logService.InsertOne(log);
                }
                else
                {
                    returnMsg = "customer_wrongpassword";

                    Log log = new Log
                    {
                        Function = "LOGIN",
                        Description = string.Format("Account:{0}, Password:{1}", account, password),
                        ReturnMsg = returnMsg,
                        LastModified = DateTime.Now,
                        DataStatus = "Normal"
                    };

                    _logService.InsertOne(log);
                }
            }
            else if(employee != null && customer == null)
            {
                if (employee.Password == password)
                {
                    returnObj = employee;

                    Log log = new Log
                    {
                        Function = "LOGIN",
                        Description = string.Format("Account:{0}, Password:{1}", account, password),
                        ReturnMsg = JsonConvert.SerializeObject(returnObj),
                        LastModified = DateTime.Now,
                        DataStatus = "Normal"
                    };

                _logService.InsertOne(log);
                }
                else
                {
                    returnMsg = "employee_wrongpassword";

                    Log log = new Log
                    {
                        Function = "LOGIN",
                        Description = string.Format("Account:{0}, Password:{1}", account, password),
                        ReturnMsg = returnMsg,
                        LastModified = DateTime.Now,
                        DataStatus = "Normal"
                    };

                    _logService.InsertOne(log);
                }
            }

            return Ok(new { code = "0000", msg = returnMsg, obj = returnObj });
        }
    }
}
