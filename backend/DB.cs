using System;
using System.Data.SQLite;
using System.IO;

class DB
{
    private string connectionString = "Data Source=tubes3.db;Version=3;";
    public void readDB()
    {   

        // Read SQL dump file
        string dumpFilePath = "tubes3_stima24.sql";
        string sqlCommands = File.ReadAllText(dumpFilePath);

        try
        {
            // Connect to SQLite database
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Execute SQL commands
                using (SQLiteCommand command = new SQLiteCommand(sqlCommands, connection))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("SQL dump executed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error executing SQL dump: " + ex.Message);
        }
    }

    public void InsertSidikJariData(string citra, string nama)
    {
        try
        {
            // Connect to SQLite database
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Prepare SQL statement
                string sql = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@citra, @nama)";

                // Create command and set parameters
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@citra", citra);
                    command.Parameters.AddWithValue("@nama", nama);

                    // Execute command
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Data inserted successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error inserting data: " + ex.Message);
        }
    }

    public List<(string, string)> GetSidikJariDataList()
    {
        List<(string, string)> data = new List<(string, string)>();
        try
        {
            // Connect to SQLite database
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Prepare SQL statement
                string sql = "SELECT * FROM sidik_jari";

                // Create command and execute query
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are any rows returned
                        if (reader.HasRows)
                        {
                            // Iterate through the rows and display data
                            while (reader.Read())
                            {
                                string berkasCitra = reader["berkas_citra"].ToString();
                                string nama = reader["nama"].ToString();
                                data.Add((nama, berkasCitra));
                                // Console.WriteLine($"Nama: {nama}, Berkas Citra: {berkasCitra}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found in the sidik_jari table.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error displaying data: " + ex.Message);
        }

        return data;
    }
}
