using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinoneCenter.Models
{
    /// <summary>
    /// 供應商
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Supplier
    {
        /// <summary>
        /// Object Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 供應商編號
        /// </summary>
        [BsonElement("SupplierId")]
        public string SupplierId { get; set; }

        /// <summary>
        /// 供應商等級
        /// </summary>
        [BsonElement("Level")]
        public string Level { get; set; }

        /// <summary>
        /// 供應商名稱
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 供應商聯絡電話
        /// </summary>
        [BsonElement("Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 供應商聯絡地址
        /// </summary>
        [BsonElement("Address")]
        public string Address { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [BsonElement("Memo")]
        public string Memo { get; set; }

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
    }
}
