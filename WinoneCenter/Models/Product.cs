using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinoneCenter.Models
{
    /// <summary>
    /// 商品
    /// </summary>
    [BsonIgnoreExtraElements]    
    public class Product
    {
        /// <summary>
        /// Object Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 商品編號
        /// </summary>
        [BsonElement("ProductId")]
        public string ProductId { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 商品種類
        /// </summary>
        [BsonElement("Category")]
        public string Category { get; set; }

        /// <summary>
        /// 商品類別
        /// </summary>
        [BsonElement("Kind")]
        public string Kind { get; set; }

        /// <summary>
        /// 商品尺寸
        /// </summary>
        [BsonElement("Size")]
        public string Size { get; set; }

        /// <summary>
        /// 供貨商 Object Id
        /// </summary>
        [BsonElement("SupplierObjectId")]
        public string SupplierObjectId { get; set; }

        /// <summary>
        /// 最新變更時間
        /// </summary>
        [BsonElement("LastModified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// 資料狀態
        /// </summary>
        [BsonElement("DataStatus")]
        public string DataStatus { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [BsonElement("Memo")]
        public string Memo { get; set; }
    }
}
