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
     public List<string> GetAllBiodataNama()
    {
        List<string> data = new List<string>();
        try
        {
            // Connect to SQLite database
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Prepare SQL statement
                string sql = "SELECT * FROM biodata";

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
                                data.Add(reader["nama"].ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found in the biodata table.");
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
    public List<string> GetBiodataByNama(string nama)
    {
        List<string> data = new List<string>();
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM biodata WHERE nama = @nama";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nama", nama);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                data.Add(reader["NIK"].ToString());
                                data.Add(reader["nama"].ToString());
                                data.Add(reader["tempat_lahir"].ToString());
                                data.Add(reader["tanggal_lahir"].ToString());
                                data.Add(reader["jenis_kelamin"].ToString());
                                data.Add(reader["golongan_darah"].ToString());
                                data.Add(reader["alamat"].ToString());
                                data.Add(reader["agama"].ToString());
                                data.Add(reader["status_perkawinan"].ToString());
                                data.Add(reader["pekerjaan"].ToString());
                                data.Add(reader["kewarganegaraan"].ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found for the given name.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving data: " + ex.Message);
        }

        return data;
    }
}
