using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperDemoCSharp_43;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DepartmentRepo(conn);

//departmentRepo.InsertDepartment("Cool Stuff");

var departments = departmentRepo.GetAllDepartments();

foreach(var dept in departments)
{
    Console.WriteLine($"{dept.DepartmentID} | {dept.Name}");
}