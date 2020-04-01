using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinoneCenter.Models
{
    /// <summary>
    /// 員工
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Employee
    {
        /// <summary>
        /// Object Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 員工等級
        /// </summary>
        [BsonElement("Level")]
        public string Level { get; set; }

        /// <summary>
        /// 員工帳號
        /// </summary>
        [BsonElement("EmployeeId")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 員工姓名
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }
        
        /// <summary>
        /// 員工聯絡電話
        /// </summary>
        [BsonElement("Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 員工聯絡地址
        /// </summary>
        [BsonElement("Address")]
        public string Address { get; set; }

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
        /// 密碼
        /// </summary>
        [BsonElement("Password")]
        public string Password { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [BsonElement("Memo")]
        public string Memo { get; set; }


    }
}
