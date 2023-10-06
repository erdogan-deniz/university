using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SecurityInformation
{
    public partial class UserForm : System.Windows.Forms.Form
    {
        string userLogin, userPassword;

        public UserForm()  // LOAD FORM
        {
            this.TopMost = true;
            InitializeComponent();
        }

        public void GetData(string login, string password, System.Drawing.Point Location)  // SET FORM REFERENCES
        {
            this.userLogin = login;
            this.userPassword = password;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Location;

            UserLoginLabel.Text += " " + userLogin.ToUpper();

            if (String.Equals(userLogin.ToLower(), "admin"))
                UserStatusLabel.Text += " ADMINISTRATOR";
            else
            {
                UserStatusLabel.Text += " USER";
                CheckUsersButton.Hide();
                AddUserButton.Hide();
            }
        }

        private void ShowUsersList(object sender, EventArgs e)  // OPEN USER LIST FORM
        {
            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string updateLimitsCommand = $"SELECT COUNT(*) FROM  `users`;";
            MySqlCommand commandOne = new MySqlCommand(updateLimitsCommand, connection);
            string result = commandOne.ExecuteScalar().ToString();

            if (String.Equals(result, "1"))
            {
                MessageBox.Show("YOU DON'T HAVE USERS");
            }
            else
            {
                UsersList usersList = new UsersList();
                usersList.GetData(this.Location);
                usersList.ShowDialog();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)  // EXIT
        {
            HomePage newHomePage = new HomePage();
            newHomePage.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)  // CLOSE FORM
        {
            this.Close();
        }

        private void AddUserButton_Click(object sender, EventArgs e)  // OPEN FORM ADD USER
        {
            AddNewUserForn newUser = new AddNewUserForn();
            newUser.GetData(this.Location);
            newUser.ShowDialog();
        }

        private void ChangePassword_Click(object sender, EventArgs e)  // CHANGE PASSWORD BUTTON PRESSED
        {
            NewPasswordForm newAdminPassword = new NewPasswordForm();
            newAdminPassword.GetData(userLogin, userPassword, this.Location);
            newAdminPassword.ShowDialog();

            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string sqlCommand = $"SELECT `password` FROM `users` WHERE `login` = '{userLogin}';";
            MySqlCommand command = new MySqlCommand(sqlCommand, connection);
            userPassword = command.ExecuteScalar().ToString();
            connection.Close();
        }
    }
}