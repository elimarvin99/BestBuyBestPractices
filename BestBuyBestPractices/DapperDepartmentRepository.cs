using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        //field
        private readonly IDbConnection _connection;
        //Custom Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;  //when constructed the connection to our database will be created and since it's readonly it can't be changed
        }
        //this way each time we create a repository we create the sql connection that can't be changed

        public IEnumerable<Department> GetAllDepartments()  //this method of the repos returns an Ienumerable of department type objects (containing id and name)
        {
            //into our connection to our database we are going to pass in this sql query which is returned as a colleciton that has properties of departmentId and name
            //this is using dapper to actually do the query based on our connection to our sql server throught the json file
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }
        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }
        //query is used to get info/reaf
        //execute is used for everything else
    }
}
