using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class Database_Manager
{
    static void Main(string[] args) 
    {
        //String con parametros de conexión
        const string connectionString = "Server=db4free.net;Port=3306;database=enti_test_db;Uid=ismael_rivero;password=;SSL Mode=None;connect timeout=3600;default command timeout=3600;";

        //Instancio clase MySQL
        MySqlConnection conn = new MySqlConnection(connectionString);

        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        void SelectExample(MySqlConnection conn)
        {
            MySqlDataReader reader;
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText= "Select * from characters";
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    Console.WriteLine(reader.GetString(1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

        DeleteExample(conn);
        SelectExample(conn);


        conn.Close();
    }

}
