using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinoneCenter.Models;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace WinoneCenter.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _product;

        public ProductService(IDBSettings settings)
        {
            var client = new MongoClient(settings.ConnStr);
            var db = client.GetDatabase(settings.DBName);
            _product = db.GetCollection<Product>("Product");
        }

        public IQueryable<Product> GetAll()
        {
            return _product.AsQueryable<Product>().Where(x => true);
        }

        public Product GetOneByName(string name)
        {
            return _product.AsQueryable<Product>().Where(x => x.Name == name).First();
        }

        public Product GetOneById(string id)
        {
            return _product.AsQueryable<Product>().Where(x => x.Id == id).First();
        }

        public void InsertOne(Product product)
        {
            // 取得最新的 ProductId
            var lastProduct = _product.AsQueryable<Product>().Where(x => x.Id != null).OrderByDescending(x => x.ProductId).First();
            if (lastProduct.ProductId.Substring(1, 6) == DateTime.Now.ToString("yyyyMM"))
            {
                product.ProductId = "P" + (Convert.ToInt32(lastProduct.ProductId.Substring(1, 6)) + 1).ToString();
            }
            else
            {
                product.ProductId = string.Format("P{0}{1}", DateTime.Now.ToString("yyyyMM"), "0001");
            }

            product.LastModified = DateTime.Now;

            _product.InsertOne(product);
        }

        public void UpdateOne(Product product)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Eq("Id", product.Id);

            var update = Builders<Product>.Update.Set("Name", product.Name)
                                                  .Set("Category", product.Category)
                                                  .Set("Kind", product.Kind)
                                                  .Set("Size", product.Size)
                                                  .Set("SupplierObjectId", product.SupplierObjectId)
                                                  .Set("Memo", product.Memo)
                                                  .Set("ProductId", product.ProductId)
                                                  .Set("DataStatus", product.DataStatus)
                                                  .CurrentDate("LastModified");
            _product.UpdateOne(filter, update);
        }

    }
}
