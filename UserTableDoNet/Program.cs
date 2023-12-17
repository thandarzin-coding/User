using UserTableDoNet.DapperExamples;
using Microsoft.Data.SqlClient;
using System.Data;
using UserTableDoNet.Models;
using UserTableDoNet.DB;

Console.WriteLine("Hello, World!");
//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();

Console.ReadKey();
//Console.ReadLine();
