using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SecurityInformation
{
    public partial class NewPasswordForm : System.Windows.Forms.Form
    {
        string userLogin, userPassword;

        public NewPasswordForm()  // FORM CONSTRUCTOR
        {
            this.TopMost = true;
            InitializeComponent();
        }

        public bool CheckPasswordLimits(string password)  // TASK FUNCTION
        {
            string RusLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string EngLetters = "abcdefghijklmnopqrstuvwxyz";
            bool EngFlag = false;
            bool RusFlag = false;

            if (!String.IsNullOrEmpty(password))  // IF STRING EXIST
            {
                foreach (char letter in RusLetters)  // CHECK RUS LETTERS
                    RusFlag |= (password.ToLower().IndexOf(letter) != -1);

                foreach (char letter in EngLetters)  // CHECK ENG LETTERS
                    EngFlag |= (password.ToLower().IndexOf(letter) != -1);
            }

            return RusFlag & EngFlag;
        }

        public void FirstPassword()  // SITUATION WHEN USER DON'T HAS PASSWORD AND WE SET IT THE FIRST TIME
        {
            this.OldPasswordBox.Hide();
            this.OldPasswordLabel.Hide();
        }

        public void SetOldPassword(string password)  // SET OLD PASSWORD TO CELL
        {
            OldPasswordBox.Text = password;
        }

        public void GetData(string login, string password, System.Drawing.Point Location)  // PREPARE FORM
        {
            this.userLogin = login;
            this.userPassword = password;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Location;

            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string findUserLimits = $"SELECT `limits` FROM `users` WHERE `login` = \"{userLogin}\";";
            MySqlCommand commandOne = new MySqlCommand(findUserLimits, connection);
            string userLimits = commandOne.ExecuteScalar().ToString();

            LimitsLabel.Text +=  " " + userLimits;
        }

        private void ChangePasswordButton(object sender, EventArgs e)  // ATTEMPT TO CHANGE PASSWORD
        {
            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string findUserLimits = $"SELECT `limits` FROM `users` WHERE `login` = \"{userLogin}\";";
            MySqlCommand commandOne = new MySqlCommand(findUserLimits, connection);
            string userLimits = commandOne.ExecuteScalar().ToString();

            String oldPassword = OldPasswordBox.Text;
            String newPassword = newPasswordBox.Text;
            String confirmPassword = confirmPasswordBox.Text;


            if (string.IsNullOrWhiteSpace(oldPassword) & OldPasswordBox.Visible == true)  // INPUT OLD PASSWORD
            {
                ErrorPage emptyOldPassword = new ErrorPage();
                emptyOldPassword.GetData(this.Location);
                emptyOldPassword.ChangeLabelText("INPUT OLD PASSWORD!");
                emptyOldPassword.ShowDialog();
            }
            else if (string.IsNullOrWhiteSpace(newPassword))  // INPUT NEW PASSWORD
            {
                ErrorPage emptyNewPassword = new ErrorPage();
                emptyNewPassword.GetData(this.Location);
                emptyNewPassword.ChangeLabelText("INPUT NEW PASSWORD!");
                emptyNewPassword.ShowDialog();
            }
            else if (string.IsNullOrWhiteSpace(confirmPassword))  // CONFIRM NEW PASSWORD
            {
                ErrorPage emptyConfirmPassword = new ErrorPage();
                emptyConfirmPassword.GetData(this.Location);
                emptyConfirmPassword.ChangeLabelText("CONFIRM NEW PASSWORD!");
                emptyConfirmPassword.ShowDialog();
            }
            else if (newPassword != confirmPassword)  // INPUT CORRECT NEW PASSWORDS
            {
                ErrorPage nonequalPasswords = new ErrorPage();
                nonequalPasswords.GetData(this.Location);
                nonequalPasswords.ChangeLabelText("YOU NEW PASSWORDS AREN'T EQUAL!");
                nonequalPasswords.ShowDialog();
            }
            else if (String.Equals(newPassword, oldPassword))  // INPUT THE SAME PASSWORD
            {
                ErrorPage samePassword = new ErrorPage();
                samePassword.GetData(this.Location);
                samePassword.ChangeLabelText("YOU INPUT THE SAME PASSWORD!");
                samePassword.ShowDialog();
            }
            else if (String.Equals(userLimits, "True") & !CheckPasswordLimits(newPassword))  // CHECK SUCCESS LIMITS
            {
                ErrorPage incorrectLimits = new ErrorPage();
                incorrectLimits.GetData(this.Location);
                incorrectLimits.ChangeLabelText("PASSWORD DOESN'T PASS LIMITS!");
                incorrectLimits.ShowDialog();
            }
            else if (String.Equals(oldPassword, userPassword))  // CHANGE PASSWORD
            {
                string changePasswordCommand = $"UPDATE `users` SET `password` = '{newPassword}' WHERE `login` = '{userLogin}';";
                MySqlCommand commandTwo = new MySqlCommand(changePasswordCommand, connection);

                commandTwo.ExecuteScalar();
                this.Close();
                MessageBox.Show("PASSWORD WAS SET!");
            }
            else  // INCORRECT OLD PASSWORD
            {
                ErrorPage incorrectPassword = new ErrorPage();
                incorrectPassword.GetData(this.Location);
                incorrectPassword.ChangeLabelText("INCORRECT PASSWORD!");
                incorrectPassword.ShowDialog();
            }

            connection.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)  // CLOSE BUTTON
        {
            this.Close();
        }
    }
}