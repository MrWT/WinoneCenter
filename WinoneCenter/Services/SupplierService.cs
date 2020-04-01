using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinoneCenter.Models;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace WinoneCenter.Services
{
    public class SupplierService
    {
        private readonly IMongoCollection<Supplier> _supplier;

        public SupplierService(IDBSettings settings)
        {
            var client = new MongoClient(settings.ConnStr);
            var db = client.GetDatabase(settings.DBName);
            _supplier = db.GetCollection<Supplier>("Supplier");
        }

        public IQueryable<Supplier> GetAll()
        {
            return _supplier.AsQueryable<Supplier>().Where(x => true);
        }

        public IQueryable<Supplier> GetOneBySupplierId(string supplierId)
        {
            return _supplier.AsQueryable<Supplier>().Where(x => x.SupplierId == supplierId);
        }

        public Supplier GetOneByName(string name)
        {
            return _supplier.AsQueryable<Supplier>().Where(x => x.Name == name).First();
        }

        public Supplier GetOneById(string id)
        {
            return _supplier.AsQueryable<Supplier>().Where(x => x.Id == id).First();
        }

        public IQueryable<Supplier> GetManyByLevel(string level)
        {
            return _supplier.AsQueryable<Supplier>().Where(x => x.Level == level);
        }

        public void InsertOne(Supplier supplier)
        {
            // 取得最新的 SupplierId
            var lastSupplier = _supplier.AsQueryable<Supplier>().Where(x => x.Id != null).OrderByDescending(x => x.SupplierId).First();
            if (lastSupplier.SupplierId.Substring(1, 6) == DateTime.Now.ToString("yyyyMM"))
            {
                supplier.SupplierId = "S" + (Convert.ToInt32(lastSupplier.SupplierId.Substring(1)) + 1).ToString();
            }
            else
            {
                supplier.SupplierId = string.Format("C{0}{1}", DateTime.Now.ToString("yyyyMM"), "0001");
            }

            supplier.LastModified = DateTime.Now;

            _supplier.InsertOne(supplier);
        }

        public void UpdateOne(Supplier supplier)
        {
            var builder = Builders<Supplier>.Filter;
            var filter = builder.Eq("Id", supplier.Id);

            var update = Builders<Supplier>.Update.Set("Level", supplier.Level)
                                                  .Set("Name", supplier.Name)
                                                  .Set("Phone", supplier.Phone)
                                                  .Set("Address", supplier.Address)
                                                  .Set("Memo", supplier.Memo)
                                                  .Set("SupplierId", supplier.SupplierId)
                                                  .Set("DataStatus", supplier.DataStatus)
                                                  .CurrentDate("LastModified");
            _supplier.UpdateOne(filter, update);

        }

    }
}
