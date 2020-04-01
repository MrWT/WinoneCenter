using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinoneCenter.Models;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace WinoneCenter.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IDBSettings settings)
        {
            var client = new MongoClient(settings.ConnStr);
            var db = client.GetDatabase(settings.DBName);
            _customer = db.GetCollection<Customer>("Customer");
        }

        public IQueryable<Customer> GetAll()
        {
            return _customer.AsQueryable<Customer>().Where(x => true);
        }

        public IQueryable<Customer> GetOneByCustomerId(string customerId)
        {
            return _customer.AsQueryable<Customer>().Where(x => x.CustomerId == customerId);
        }

        public Customer GetOneByName(string name)
        {
            return _customer.AsQueryable<Customer>().Where(x => x.Name == name).First();
        }

        public Customer GetOneById(string id)
        {
            return _customer.AsQueryable<Customer>().Where(x => x.Id == id).First();
        }

        public IQueryable<Customer> GetManyByLevel(string level)
        {
            return _customer.AsQueryable<Customer>().Where(x => x.Level == level);
        }

        public void InsertOne(Customer customer)
        {
            // 取得最新的 CustomerId
            var lastCustomer = _customer.AsQueryable<Customer>().Where(x => x.Id != null).OrderByDescending(x => x.CustomerId).First();
            if (lastCustomer.CustomerId.Substring(1, 6) == DateTime.Now.ToString("yyyyMM"))
            {
                customer.CustomerId = "C" + (Convert.ToInt32(lastCustomer.CustomerId.Substring(1)) + 1).ToString();
            }
            else
            {
                customer.CustomerId = string.Format("C{0}{1}", DateTime.Now.ToString("yyyyMM"), "0001");
            }

            customer.LastModified = DateTime.Now;

            _customer.InsertOne(customer);
        }

        public void UpdateOne(Customer customer)
        {
            var builder = Builders<Customer>.Filter;
            var filter = builder.Eq("Id", customer.Id);

            var update = Builders<Customer>.Update.Set("Level", customer.Level)
                                                  .Set("Name", customer.Name)
                                                  .Set("Phone", customer.Phone)
                                                  .Set("Memo", customer.Memo)
                                                  .Set("CustomerId", customer.CustomerId)
                                                  .Set("DataStatus", customer.DataStatus)
                                                  .Set("Password", customer.Password)
                                                  .CurrentDate("LastModified");
            _customer.UpdateOne(filter, update);

        }

    }
}
