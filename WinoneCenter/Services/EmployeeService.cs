using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinoneCenter.Models;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace WinoneCenter.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;

        public EmployeeService(IDBSettings settings)
        {
            var client = new MongoClient(settings.ConnStr);
            var db = client.GetDatabase(settings.DBName);
            _employee = db.GetCollection<Employee>("Employee");
        }

        public IQueryable<Employee> GetAll()
        {
            return _employee.AsQueryable<Employee>();
        }

        public IQueryable<Employee> GetOneByEmployeeId(string employeeId)
        {
            return _employee.AsQueryable<Employee>().Where(x => x.EmployeeId == employeeId);
        }

        public Employee GetOneByName(string name)
        {
            return _employee.AsQueryable<Employee>().Where(x => x.Name == name).First();
        }

        public IQueryable<Employee> GetOneById(string id)
        {
            return _employee.AsQueryable<Employee>().Where(x => x.Id == id);
        }

        public IQueryable<Employee> GetManyByLevel(string level)
        {
            return _employee.AsQueryable<Employee>().Where(x => x.Level == level);
        }

        public void InsertOne(Employee employee)
        {
            // 取得最新的 EmployeeId
            var lastEmployee = _employee.AsQueryable<Employee>().Where(x => x.Id != null).OrderByDescending(x => x.EmployeeId).First();
            if(lastEmployee.EmployeeId.Substring(1, 6) == DateTime.Now.ToString("yyyyMM"))
            {
                employee.EmployeeId = "E" + (Convert.ToInt32(lastEmployee.EmployeeId.Substring(1)) + 1).ToString();
            }
            else
            {
                employee.EmployeeId = string.Format("E{0}{1}", DateTime.Now.ToString("yyyyMM"), "0001");
            }
            
            employee.LastModified = DateTime.Now;
            
            _employee.InsertOne(employee);
        }

        public void UpdateOne(Employee employee)
        {
            var builder = Builders<Employee>.Filter;
            var filter = builder.Eq("Id", employee.Id);

            var update = Builders<Employee>.Update.Set("Level", employee.Level)
                                                  .Set("Name", employee.Name)
                                                  .Set("Phone", employee.Phone)
                                                  .Set("Memo", employee.Memo)
                                                  .Set("EmployeeId", employee.EmployeeId)
                                                  .Set("DataStatus", employee.DataStatus)
                                                  .Set("Password", employee.Password)
                                                  .CurrentDate("LastModified");
            _employee.UpdateOne(filter, update);
               
        }

    }
}
