using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinoneCenter.Models
{
    public class DBSettings : IDBSettings
    {
        public string ConnStr { get; set; }
        public string DBName { get; set; }
    }

    public interface IDBSettings
    {
        string ConnStr { get; set; }
        string DBName { get; set; }
    }
}
