using BopuchoDotNetCore.ConsoleApp.AdoDotNetExamples;
using System.Data;
using System.Data.SqlClient;

/*SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";
sqlConnectionStringBuilder.InitialCatalog = "BopuchoDotNetCore";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sa@123";
SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
{
    DataSource = ".",
    InitialCatalog = "BopuchoDotNetCore",
    UserID = "sa",
    Password = "sa@123"
};
SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

Console.WriteLine("Connection Opening");
connection.Open();
Console.WriteLine("Connection Open");

string query = @"SELECT [ID]
      ,[Name]
      ,[DOB]
      ,[Address]
  FROM [dbo].[Person]";

SqlCommand command = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(command);
DataTable dt = new DataTable();
adapter.Fill(dt);

Console.WriteLine("Connection Closing");
connection.Close();
Console.WriteLine("Connection Close");

foreach (DataRow dr in dt.Rows)
{
    //Console.WriteLine($"Id => {dr["ID"]}");
    Console.WriteLine("ID => " + dr["ID"]);
    Console.WriteLine("Name => " + dr["Name"]);
    Console.WriteLine("DOB => " + dr["DOB"]);
    Console.WriteLine("Address => " + dr["Address"]);
    Console.WriteLine("----------------------------");
}*/

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Run();

Console.ReadKey();