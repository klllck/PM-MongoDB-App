using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend.Data
{
    public class AppDbConfig
    {
        public string Database_Name { get; set; }
        public string Products_Collection_Name { get; set; }
        public string Connection_String { get; set; }
    }
}
