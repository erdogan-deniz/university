using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SecurityInformation
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool databaseIsExist = false;

            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string defineUsers = $"SELECT COUNT(*) FROM `secureusers`;";
            MySqlCommand commandOne = new MySqlCommand(defineUsers, connection);

            System.Media.SoundPlayer player = new System.Media.SoundPlayer
            {
                SoundLocation = "..\\..\\Resources\\Music\\BackgroundMusic.wav"
            };

            player.PlayLooping();

            try  // CHECK THAT TABLE IS EXIST
            {
                commandOne.ExecuteScalar();
                databaseIsExist = true;
            }
            catch  // CREATE TABLE AND ADD ADMIN IF THERE AREN'T
            {
                databaseIsExist = false;
            }

            if (databaseIsExist)
            {
                Application.Run(new SecurityKeyForm());
            }
            else
            {
                Application.Run(new HomePage());
            }

            connection.Close();
        }
    }
}
