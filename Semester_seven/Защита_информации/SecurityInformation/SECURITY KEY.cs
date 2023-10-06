using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Security.Cryptography; 

public struct SecureNode  // NODE FOR ENCRYPTION
{
    public string userLogin;
    public string userPassword;
    public string userLimits;
    public string userBlocked;
    public string userRules;
};

namespace SecurityInformation
{       
    public partial class SecurityKeyForm : System.Windows.Forms.Form
    {
        private static readonly string passwordKey = "123";  // ENCRYPTION KEY
        readonly List<SecureNode> usersList = new List<SecureNode>();

        public SecurityKeyForm()  // INITIALIZE FORM
        {
            InitializeComponent();
        }

        private void SecurityKeyForm_Load(object sender, System.EventArgs e)  // LOAD FORM
        {
            this.TopMost = true;
        }

        public int FromStringToInt(string value)  // METHOD FOR BOOL CELLS OF SQL
        {
            if (String.Equals("True", value))
                return 1;
            else
                return 0;
        }

        public string Decryption(string argument)  // DECRYPTION USER
        {
            string answer = "";  // FINAL RESULT

            if (!string.IsNullOrEmpty(argument))
            {
                byte[] data = Convert.FromBase64String(argument);

                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())  // CREATE ALGORITHM FUNCTION
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(passwordKey));

                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()  // CLASS OF CIPHER TOOLS
                    {
                        // ПОТОКОВОСТЬ ЗАДАЁТСЯ РАЗМЕРОМ ПАКЕТОВ ДАННЫХ И МОДОМ, КОТОРЫЙ ИСПОЛЬЗУЕТ XOR
                        FeedbackSize = 8,  // SIZE OF INFORMATION BLOCK
                        Key = keys,  // INPUT KEY
                        Mode = CipherMode.ECB
                        //Mode = CipherMode.CBC  // CIPHER MODE - https://learn.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.ciphermode?view=net-7.0
                    })
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        answer = UTF8Encoding.UTF8.GetString(results);
                    }
                }
            }

            return answer;
        }

        public void AddDecryption()  // DECRYPTION DATABASE
        {
            SecureNode encryptionUser = new SecureNode();
            Database database = new Database();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand getTable = new MySqlCommand("SELECT * FROM `secureusers`", database.GetConnection());

            adapter.SelectCommand = getTable;
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)  // DECRYPTION ALL CELLS
            {
                encryptionUser.userLogin = Decryption(row["login"] as string);
                encryptionUser.userPassword = Decryption(row["password"] as string);
                encryptionUser.userLimits = Decryption(row["limits"] as string);
                encryptionUser.userBlocked = Decryption(row["blocked"] as string);
                encryptionUser.userRules = Decryption(row["root"] as string);

                usersList.Add(encryptionUser);
            }

            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string createTable = $"CREATE TABLE `usersdatabase`.`users` ( `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT , " +
                                 $"`login` VARCHAR(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `password` VARCHAR(32) CHARACTER " +
                                 $"SET utf8 COLLATE utf8_general_ci NOT NULL , `limits` TINYINT(1) NOT NULL , `blocked` TINYINT(1) NOT NULL , " +
                                 $"`root` TINYINT(1) NOT NULL DEFAULT '0' , PRIMARY KEY (`login`), INDEX (`id`)) ENGINE = InnoDB;";
            MySqlCommand commandOne = new MySqlCommand(createTable, connection);
            commandOne.ExecuteScalar();

            foreach (SecureNode user in usersList)  // ENCRYPTION USERS ADD
            {
                string createEncryptionUser = $"INSERT INTO `users` (`id`, `login`, `password`, `limits`, `blocked`, `root`) VALUES (NULL, " +
                   $"'{user.userLogin}', '{user.userPassword}', '{FromStringToInt(user.userLimits).ToString()}', " +
                   $"'{FromStringToInt(user.userBlocked).ToString()}', '{FromStringToInt(user.userRules).ToString()}');";
                MySqlCommand loginCommand = new MySqlCommand(createEncryptionUser, connection);
                loginCommand.ExecuteScalar();
            }

            connection.Close();
        }

        private void CloseButton_Click(object sender, System.EventArgs e)  // CLOSE APPLICATION
        {
            System.Windows.Forms.Application.Exit();
        }

        private void OkButton_Click(object sender, System.EventArgs e)  // TRY TO DECRYPT TABLES
        {
            string inputPassword = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(inputPassword))  // IF USER DON'T INPUT ANYTHING
            {
                ErrorPage emptyInputPassword = new ErrorPage();
                emptyInputPassword.GetData(this.Location);
                emptyInputPassword.ChangeLabelText("YOU DON'T INPUT PASSWORD!");
                emptyInputPassword.ShowDialog();
            }
            else if (!String.Equals(inputPassword, passwordKey))  // INCORRECT PASSWORD
            {
                ErrorPage incorrectPassword = new ErrorPage();
                incorrectPassword.GetData(this.Location);
                incorrectPassword.ChangeLabelText("YOU INPUT INCORRECT PASSWORD!");
                incorrectPassword.ShowDialog();
            }
            else
            {
                AddDecryption();
                
                this.Hide();

                HomePage homePage = new HomePage();
                homePage.GetPassword(passwordKey);
                homePage.Show();
            }
        }
    }
}
