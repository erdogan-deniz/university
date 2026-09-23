using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SecurityInformation
{
    public partial class HomePage : System.Windows.Forms.Form
    {
        public int incorrectInputs = 0;
        public string securityPassword = "123";
        readonly List<SecureNode> usersList = new List<SecureNode>();
        private readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public HomePage()  // CREATE HOME PAGE
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)  // OPEN HOME PAGE AND CHECK TABLE
        {
            this.TopMost = true;
            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string defineUsers = $"SELECT COUNT(*) FROM `secureusers`;";
            MySqlCommand commandOne = new MySqlCommand(defineUsers, connection);

            try  // CHECK THAT TABLE IS EXIST
            {
                commandOne.ExecuteScalar();
                string dropTable = "DROP TABLE `usersdatabase`.`secureusers`";
                MySqlCommand commandTwo = new MySqlCommand(dropTable, connection);
                commandTwo.ExecuteScalar();
            }
            catch  // CREATE TABLE AND ADD ADMIN IF THERE AREN'T
            {
                string createTable = $"CREATE TABLE `usersdatabase`.`users` ( `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT , " +
                    $"`login` VARCHAR(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `password` VARCHAR(32) CHARACTER " +
                    $"SET utf8 COLLATE utf8_general_ci NOT NULL , `limits` TINYINT(1) NOT NULL , `blocked` TINYINT(1) NOT NULL , `root` " +
                    $"TINYINT(1) NOT NULL DEFAULT '0' , PRIMARY KEY (`login`), INDEX (`id`)) ENGINE = InnoDB;";
                MySqlCommand commandTwo = new MySqlCommand(createTable, connection);
                commandTwo.ExecuteScalar();

                string addAdmin = $"INSERT INTO `users` (`id`, `login`, `password`, `limits`, `blocked`, `root`) VALUES (NULL, 'ADMIN', '', '0', '0', '1');";
                MySqlCommand commandThree = new MySqlCommand(addAdmin, connection);
                commandThree.ExecuteScalar();
            }

            connection.Close();
        }

        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)  // ENCRYPTION BY THE END OF PROGRAMM
        {
            AddEncryption();
        }

        void TimerOn(object sender, System.EventArgs e)  // TURN ON BLOCK TIMER
        {
            SignInButton.Enabled = true;
            timer.Stop();
        }

        public void GetPassword(string password)  // GET KEY PASSWORD FROM LAST FORM
        { 
            this.securityPassword = password;
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

        public string Encryption(string argument)  // ENCRYPTION USER
        {
            string answer = "";  // FINAL RESULT

            if (!string.IsNullOrEmpty(argument))
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(argument);  // CONVERT ARGUMENT TO BYTES

                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())  // CREATE ALGORITHM FUNCTION
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityPassword));

                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()  // CLASS OF CIPHER TOOLS
                    {
                        // ПОТОКОВОСТЬ ЗАДАЁТСЯ РАЗМЕРОМ ПАКЕТОВ ДАННЫХ И МОДОМ, КОТОРЫЙ ИСПОЛЬЗУЕТ XOR
                        FeedbackSize = 8,  // SIZE OF INFORMATION BLOCK
                        Key = keys,  // INPUT KEY
                        Mode = CipherMode.ECB,
                        //Mode = CipherMode.CBC  // CIPHER MODE - https://learn.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.ciphermode?view=net-7.0
                    })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        answer = Convert.ToBase64String(results, 0, results.Length);
                    }
                }
            }

            return answer;
        }

        public void AddEncryption()  // ENDCRYPTION USERS TABLE
        {
            SecureNode decryptionUser = new SecureNode();
            Database database = new Database();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand getTable = new MySqlCommand("SELECT * FROM `users`", database.GetConnection());

            adapter.SelectCommand = getTable;
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)  // ENCRYPTION ALL DATABASE
            {
                decryptionUser.userLogin = Encryption(row["login"] as string);
                decryptionUser.userPassword = Encryption(row["password"] as string);
                decryptionUser.userLimits = Encryption(row["limits"].ToString());
                decryptionUser.userBlocked = Encryption(row["blocked"].ToString());
                decryptionUser.userRules = Encryption(row["root"].ToString());

                usersList.Add(decryptionUser);
            }

            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string createTable = "CREATE TABLE `usersdatabase`.`secureusers` ( `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, `login` VARCHAR(64) CHARACTER " +
                "SET utf8 COLLATE utf8_general_ci NOT NULL , `password` VARCHAR(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `limits` " +
                "VARCHAR(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '0' , `blocked` VARCHAR(32) CHARACTER SET utf8 COLLATE " +
                "utf8_general_ci NOT NULL DEFAULT '0' , `root` VARCHAR(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '0' , " +
                "PRIMARY KEY(`login`), INDEX(`id`)) ENGINE = InnoDB;";
            MySqlCommand commandOne = new MySqlCommand(createTable, connection);
            commandOne.ExecuteScalar();

            foreach (SecureNode user in usersList)  // ENCRYPTION ALL DATABASE
            {
                string createEncryptionUser = $"INSERT INTO `secureusers` (`id`, `login`, `password`, `limits`, `blocked`, `root`) " +
                    $"VALUES (NULL, '{user.userLogin}', '{user.userPassword}', '{user.userLimits}', '{user.userBlocked}', '{user.userRules}');";
                MySqlCommand commandTwo = new MySqlCommand(createEncryptionUser, connection);
                commandTwo.ExecuteScalar();
            }

            string dropTable = "DROP TABLE `usersdatabase`.`users`";
            MySqlCommand commandThree = new MySqlCommand(dropTable, connection);
            commandThree.ExecuteScalar();
            connection.Close();
        }

        private void AboutUsToolStripMenuItem_Click(object sender, EventArgs e)  // MENU PAGE
        {
            AboutUs aboutUs = new AboutUs();
            aboutUs.ShowDialog();
        }

        private void ButtonExit_Click(object sender, EventArgs e)  // EXIT BUTTON WAS PRESSED
        {
            System.Windows.Forms.Application.Exit();
        }

        private void SignIn_Click(object sender, EventArgs e)  // CLICK BUTTON SIGN IN
        {
            String userLogin = UserNameTextBox.Text;
            String userPassword = UserPasswordTextBox.Text;

            if (string.IsNullOrEmpty(userLogin))  // IF USER DON'T INPUT USER NAME
            {
                ErrorPage emptyInputUserLogin = new ErrorPage();
                emptyInputUserLogin.GetData(this.Location);
                emptyInputUserLogin.ChangeLabelText("YOU DON'T INPUT USER LOGIN!");
                emptyInputUserLogin.ShowDialog();
            }
            else  // CHECK THAT USER EXIST IN DATABASE
            {
                string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string findUserCommand = $"SELECT COUNT(*) FROM `users` WHERE `login` = \"{userLogin}\";";
                MySqlCommand commandOne = new MySqlCommand(findUserCommand, connection);
                string userFind = commandOne.ExecuteScalar().ToString();

                if (!String.Equals(userFind, "1"))  // IF USER WASN'T FOUND
                {
                    ErrorPage userDoesntExist = new ErrorPage();
                    userDoesntExist.GetData(this.Location);
                    userDoesntExist.ChangeLabelText("USER DOESN'T EXIST!");
                    userDoesntExist.ShowDialog();
                    connection.Close();
                }
                else
                {
                    string checkUserPasswordCommand = $"SELECT `password` FROM `users` WHERE `users`.`login` = \"{userLogin}\";";
                    MySqlCommand commandTwo = new MySqlCommand(checkUserPasswordCommand, connection);
                    string userPasswordFind = commandTwo.ExecuteScalar().ToString();

                    if (String.Equals(userPasswordFind, userPassword))  // IF PASSWORD CORRECT
                    {
                        string checkUserBlockCommand = $"SELECT `blocked` FROM `users` WHERE `users`.`login` = \"{userLogin}\";";
                        MySqlCommand commandThree = new MySqlCommand(checkUserBlockCommand, connection);
                        string userBlockFind = commandThree.ExecuteScalar().ToString();

                        string checkUserStatus = $"SELECT `limits` FROM `users` WHERE `users`.`login` = \"{userLogin}\";";
                        MySqlCommand commandFour = new MySqlCommand(checkUserStatus, connection);
                        string userLimitsFind = commandFour.ExecuteScalar().ToString();

                        if (String.Equals(userBlockFind, "True"))
                        {
                            ErrorPage userBlocked = new ErrorPage();
                            userBlocked.GetData(this.Location);
                            userBlocked.ChangeLabelText("USER HAS BEEN BLOCKED!");
                            userBlocked.ShowDialog();
                        }
                        else if (string.IsNullOrEmpty(userPassword))  // IF USER DON'T HAVE PASSWORD
                        {
                            MessageBox.Show("YOU DON'T HAVE PASSWORD! PLEASE SET IT.");
                            NewPasswordForm setFirstPassword = new NewPasswordForm();
                            setFirstPassword.GetData(userLogin, userPassword, this.Location);
                            setFirstPassword.FirstPassword();
                            setFirstPassword.ShowDialog();
                        }
                        else if (String.Equals("True", userLimitsFind) & !CheckPasswordLimits(userPassword))  // IF USER HAVE LIMITS WE NEED TO CHECK HIS PASSWORD
                        {
                            MessageBox.Show("YOUR PASSWORD DOESN'T PASS LIMITS!");

                            NewPasswordForm setNewPassword = new NewPasswordForm();
                            setNewPassword.GetData(userLogin, userPassword, this.Location);
                            setNewPassword.ShowDialog();
                        }
                        else
                        {
                            UserForm userPage = new UserForm();
                            userPage.GetData(userLogin, userPassword, this.Location);
                            this.UserNameTextBox.Clear();
                            this.UserPasswordTextBox.Clear();
                            userPage.ShowDialog();
                            this.UserNameTextBox.Clear();
                            this.UserPasswordTextBox.Clear();
                        }

                        connection.Close();
                    }
                    else
                    {
                        ++incorrectInputs;
                        ErrorPage incorrectPassword = new ErrorPage();
                        incorrectPassword.GetData(this.Location);
                        incorrectPassword.ChangeLabelText("INCORRECT PASSWORD!");
                        incorrectPassword.ShowDialog();

                        if (incorrectInputs > 2)
                        {
                            incorrectInputs = 0;
                            timer.Interval = 45000;  // HERE A TIME IN MILISECONDS
                            MessageBox.Show($"YOU HAVE BEEN BLOCKED ON {timer.Interval / 1000} SECONDS!");
                            timer.Tick += TimerOn;
                            timer.Start();
                            SignInButton.Enabled = false;
                        }
                    }
                }
            }
        }
    }
}