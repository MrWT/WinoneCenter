using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinoneCenter.Models
{
    /// <summary>
    /// 系統 Log
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Log
    {
        /// <summary>
        /// Object Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 功能別
        /// </summary>
        [BsonElement("Function")]
        public string Function { get; set; }

        /// <summary>
        /// Log 描述
        /// </summary>
        [BsonElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 系統回覆訊息
        /// </summary>
        [BsonElement("ReturnMsg")]
        public string ReturnMsg { get; set; }

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
