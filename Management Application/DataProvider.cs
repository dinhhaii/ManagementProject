using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Application.Model;

namespace Management_Application
{
    class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider ins
        {
            get
            {
                if(_ins == null)
                {
                    _ins = new DataProvider();
                }
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public ManagementDBEntities db { get; set; }

        private DataProvider()
        {
            db = new ManagementDBEntities();
        }

        //PRODUCT
        //CATEGORIES
        //CUSTOMER
        //INPUTS
        //OUTPUTS
        //STATISTIC DATE      
        //STATUS
    }
}
