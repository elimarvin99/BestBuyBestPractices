using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public class Department
    {
        public Department()
        {
        }
        //the property names must match exactly the properties of the database we are trying to acccess.
        public int DepartmentID { get; set; }
        public string Name { get; set; }

    }
}
