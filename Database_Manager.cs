using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class Database_Manager
{
    private MySqlConnection conn;

    /*public static Database_Manager _DB_MANAGER = null;

    public void InitDB()
    {
        if (_DB_MANAGER == null)
        {
            _DB_MANAGER = new Database_Manager();
        }
        else
        {
            _DB_MANAGER = this;
            
        }
    }
    */

    public void StartDatabaseService() {
        //String con parametros de conexión
        const string connectionString = "Server=db4free.net;Port=3306;database=enti_test_db;Uid=ismael_rivero;password=warrior000;SSL Mode=None;connect timeout=3600;default command timeout=3600;";

        //Instancio clase MySQL
        conn = new MySqlConnection(connectionString);

        //try
        //{
        //    conn.Open();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //conn.Close();
    }
    public string GetLatestVersion()
    {
        string query = "SELECT * FROM versions";
        return  DataSelect(DataType.VERSION, query);
        
    }
    public string GetGameData()
    {
        string query = "SELECT * FROM races";
        return DataSelect(DataType.GAMEDATA, query);
        
    }


    public string DataSelect(DataType type, string query)
    {
        string result = "";
        
        try {
            conn.Open();

            MySqlDataReader reader;
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    switch (type)
                    {
                        /// USERDATA
                        /// Login
                        /// If only one row GOOD
                        case DataType.USERDATA:
                            break;

                        /// GAMEDATA
                        /// Retrieve data for races
                        /// 6 rows
                        case DataType.GAMEDATA:

                            result += reader.GetString(0) + ".";
                            result += reader.GetString(1) + ".";
                            result += reader.GetString(2) + ".";
                            result += reader.GetString(3) + ".";
                            result += reader.GetString(4) + ".";
                            result += reader.GetString(5) + "-";

                            break;

                        /// CHARACTERDATA
                        /// Retrieve user's characters
                        case DataType.CHARACTERDATA:
                            Console.WriteLine(reader.GetString(0));
                            Console.WriteLine(reader.GetString(1));
                            Console.WriteLine(reader.GetString(2));
                            Console.WriteLine(reader.GetString(3));
                            break;

                        /// VERSION
                        /// Check version
                        case DataType.VERSION:
                            result += reader.GetString(0).ToString() ;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            conn.Close();
            return result;
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.Message); 
            
        }

        return result;


    }


    void Select(MySqlConnection conn)
        {
            

        }
       


        void InsertExample(MySqlConnection conn)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO characters(name,speed, maxHp, dmg) VALUES ('PEdro la Piedra', 1, 20,20);";

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }

        }

        void DeleteExample(MySqlConnection conn)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM characters WHERE name='PEdro la Piedra';";

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }

        }
}
