using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BopuchoDotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Run()
        {
            Read();
            //Edit(4);
            //Create("War War", "30.4.1956", "Hlaing");
            //Update(5, "Mg Mg Kyaw", "19.07.1956", "Hlaing");
            //Delete(5);
        }

        private void Read()
        {
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
            }
        }
        private void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "BopuchoDotNetCore",
                UserID = "sa",
                Password = "sa@123"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"SELECT [ID]
                            ,[Name]
                            ,[DOB]
                            ,[Address]
                            FROM [dbo].[Person] where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            DataRow dr = dt.Rows[0];
            //Console.WriteLine($"Id => {dr["ID"]}");
            Console.WriteLine("ID => " + dr["ID"]);
            Console.WriteLine("Name => " + dr["Name"]);
            Console.WriteLine("DOB => " + dr["DOB"]);
            Console.WriteLine("Address => " + dr["Address"]);
            Console.WriteLine("----------------------------");
        }
        private void Create(string name, string dob, string address)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "BopuchoDotNetCore",
                UserID = "sa",
                Password = "sa@123"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"INSERT INTO [dbo].[Person]
           ([Name]
           ,[DOB]
           ,[Address])
     VALUES
           (@Name
            ,@DOB
            ,@Address)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@DOB", dob);
            command.Parameters.AddWithValue("@Address", address);
            int result = command.ExecuteNonQuery();
            connection.Close();
            
            string message = result > 0 ? "Successful" : "Fail";
            Console.WriteLine(message);
        }
        private void Update(int id, string name, string dob, string address)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "BopuchoDotNetCore",
                UserID = "sa",
                Password = "sa@123"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"UPDATE [dbo].[Person]
                            SET [Name] = @Name
                            ,[DOB] = @DOB
                            ,[Address] = @Address
                             WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@DOB", dob);
            command.Parameters.AddWithValue("@Address", address);
            int result = command.ExecuteNonQuery();
            connection.Close();
            
            string message = result > 0 ? "Updating Successful" : "Updating Fail";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "BopuchoDotNetCore",
                UserID = "sa",
                Password = "sa@123"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"DELETE FROM [dbo].[Person]
                             WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);            
            int result = command.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Deleting Successful" : "Deleting Fail";
            Console.WriteLine(message);
        }

    }
}
