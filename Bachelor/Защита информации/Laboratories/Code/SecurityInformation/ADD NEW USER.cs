using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SecurityInformation
{
    public partial class AddNewUserForn : System.Windows.Forms.Form
    {
        public AddNewUserForn()  // CREATE FORM PAGE
        {
            this.TopMost = true;
            InitializeComponent();
        }

        public void GetData(System.Drawing.Point Location)  // SET PREVIOUS FORM LOCATION
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Location;
        }

        private void AddButton_Click(object sender, EventArgs e)  // TRY TO ADD NEW USER
        {
            string newUserLogin = UserLoginTextBox.Text;

            if (string.IsNullOrWhiteSpace(newUserLogin))  // IF USER DON'T INPUT ANYTHING
            {
                ErrorPage emptyInputLogin = new ErrorPage();
                emptyInputLogin.ChangeLabelText("YOU DON'T INPUT ANYTHING!");
                emptyInputLogin.GetData(this.Location);
                emptyInputLogin.ShowDialog();
            }
            else
            {
                string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string commandOne = $"SELECT COUNT(*) FROM `users` WHERE `login` = \"{newUserLogin}\";";
                string commandTwo = $"INSERT INTO `users`(`id`, `login`, `password`, `limits`, `blocked`, `root`) VALUES (NULL, '{newUserLogin}', '', '0', '0', '0');";
                MySqlCommand commandFind = new MySqlCommand(commandOne, connection);
                string result = commandFind.ExecuteScalar().ToString();

                if (String.Equals(result, "1"))  // CHECK THAT USER IS ALREADY EXIST
                {
                    ErrorPage existUser = new ErrorPage();
                    existUser.GetData(this.Location);
                    existUser.ChangeLabelText("USER IS ALREADY EXIST!");
                    existUser.ShowDialog();
                }
                else  // ADD USER
                {
                    MySqlCommand commandAdd = new MySqlCommand(commandTwo, connection);
                    commandAdd.ExecuteScalar();
                    MessageBox.Show("USER WAS ADDED!");
                }

                connection.Close();
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)  // CLOSE FORM
        {
            this.Close();
        }
    }
}