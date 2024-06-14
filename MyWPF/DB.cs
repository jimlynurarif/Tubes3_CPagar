using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MyWPF
{
    internal class DB
    {
        private string connectionString = "Data Source=tubes3.db;Version=3;";
        public void readDB()
        {

            // Read SQL dump file
            string dumpFilePath = "tubes3.sql";
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
                                    string berkasCitra = reader.GetString(reader.GetOrdinal("berkas_citra"));
                                    string nama = reader.GetString(reader.GetOrdinal("nama"));
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

        
        public void seedSidikJari(){
            string folderPath = "./sidiks";
            List<string> fullNames = new List<string>
            {
                "Alice Johnson", "Bob Smith", "Charlie Brown", "David Wilson", "Eva Davis",
                "Frank Miller", "Grace Taylor", "Hannah White", "Ivy Clark", "Jack Hall",
                "Karen Lewis", "Leo Young", "Mona Walker", "Nina King", "Oscar Green",
                "Paul Adams", "Quincy Baker", "Rachel Nelson", "Steve Carter", "Tina Roberts"
            };
            Random random = new Random();

            try
            {
                string[] files = Directory.GetFiles(folderPath);

                for (int i = 0; i < files.Length && i < 100; i++)
                {
                    int randomIndex = random.Next(fullNames.Count);
                    Console.WriteLine(fullNames[randomIndex]);
                    Console.WriteLine(Path.GetFileName(files[i]));
                    string citra = "sidiks\\" + Path.GetFileName(files[i]);
                    string name = fullNames[randomIndex];
                    InsertSidikJariData(citra, name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }

}
