using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

public struct UsersNode  // NODE FOR LIST
{
    public string userLogin;
    public string userPassword;
    public bool userLimits;
    public bool userBlocked;
    public bool userRules;
};

namespace SecurityInformation
{
    public partial class UsersList : System.Windows.Forms.Form
    {
        readonly List <UsersNode> usersList = new List<UsersNode>();

        readonly int minUserIndex = 0;
        private int maxUserIndex;
        private int currentUserIndex = 0;
        bool blockBox;
        bool limitsBox;

        public UsersList()  // CREATE PAGE
        {
            InitializeComponent();
        }

        private void UsersList_Load(object sender, EventArgs e)  // PREPARE FORM
        {
            this.TopMost = true;
            this.UserNameTextBox.ReadOnly = true;
            this.SaveButton.Enabled = false;

            UsersNode user = new UsersNode();
            Database database = new Database();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand getTable = new MySqlCommand("SELECT * FROM `users`", database.GetConnection());

            adapter.SelectCommand = getTable;
            adapter.Fill(table);
            maxUserIndex = table.Rows.Count - 2;

            foreach (DataRow row in table.Rows)  // ADD USERS TO LIST
            {
                user.userLogin = row["login"] as string;

                if (String.Equals(user.userLogin, "ADMIN"))
                    continue;

                user.userPassword = row["password"] as string;
                user.userLimits = FromStringToBool(row["limits"].ToString());
                user.userBlocked = FromStringToBool(row["blocked"].ToString());
                user.userRules = FromStringToBool(row["root"].ToString());

                usersList.Add(user);
            }

            SetCurrentUserData();
        }

        public bool FromStringToBool(string value)  // METHOD FOR BOOL CELLS OF SQL
        {
            if (String.Equals("True", value))
                return true;
            else
                return false;
        }

        public void GetData(System.Drawing.Point Location)  // SET FORM REFERENCES
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Location;
        }

        public void SetCurrentUserData()  // SET USER LIST DATA
        {
            blockBox = UserBlockedCheckBox.Checked;
            limitsBox = UserLimitsCheckedBox.Checked;

            this.PreviousButton.Enabled = true;
            this.NextButton.Enabled = true;

            if (maxUserIndex < 0)  // WHEN WE HAVE ONLY ADMIN OR EMPTY DATABASE
            {
                this.NextButton.Enabled = false;
                this.PreviousButton.Enabled = false;
                this.SaveButton.Enabled = false;
                this.UserBlockedCheckBox.Enabled = false;
                this.UserLimitsCheckedBox.Enabled = false;
            }
            else
            {
                UserNameTextBox.Text = usersList[currentUserIndex].userLogin;
                UserBlockedCheckBox.Checked = usersList[currentUserIndex].userBlocked;
                UserLimitsCheckedBox.Checked = usersList[currentUserIndex].userLimits;

                if (currentUserIndex >= maxUserIndex)
                    this.NextButton.Enabled = false;
                
                if (currentUserIndex <= minUserIndex)
                    this.PreviousButton.Enabled = false;
            }

            this.SaveButton.Enabled = false;
        }

        public int GetNodeIndex(string userLogin)  // FOR UPDATING USER DATA
        {
            int nodeIndex = 0;

            foreach (UsersNode node in usersList)
            {
                nodeIndex += 1;

                if (String.Equals(userLogin, node.userLogin))
                    return nodeIndex - 1;
            }

            return -1;
        }

        private void PreviousButton_Click(object sender, EventArgs e)  // CHECK PREVIOUS USER
        {
            this.SaveButton.Enabled = false;

            currentUserIndex -= 1;
            SetCurrentUserData();
        }

        private void NextButton_Click(object sender, EventArgs e)  // CHECK NEXT USER
        {
            this.SaveButton.Enabled = false;
            
            currentUserIndex += 1;
            SetCurrentUserData();
        }

        private void SaveButton_Click(object sender, EventArgs e)  // UPDATE USERS LIST AND ACCLAIM CHANGES
        {
            string status = "";

            string connectionString = "server=localhost;user=root;database=usersdatabase;password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            
            string updateLimitsCommand = $"UPDATE `users` SET `limits` = '{Convert.ToInt32(UserLimitsCheckedBox.Checked).ToString()}' WHERE `users`.`login` = '{UserNameTextBox.Text}';";
            MySqlCommand commandOne = new MySqlCommand(updateLimitsCommand, connection);
            commandOne.ExecuteScalar();
            
            if (UserLimitsCheckedBox.Checked != limitsBox)
                status += "LIMITS WAS CHANGED ";

            string updateBlockedCommand = $"UPDATE `users` SET `blocked` = '{Convert.ToInt32(UserBlockedCheckBox.Checked).ToString()}' WHERE `login` = '{UserNameTextBox.Text}';";
            MySqlCommand commandTwo = new MySqlCommand(updateBlockedCommand, connection);
            commandTwo.ExecuteScalar();
            connection.Close();

            if (UserBlockedCheckBox.Checked != blockBox)
                status += "USER WAS BLOCKED!";

            if (!string.IsNullOrEmpty(status))
                MessageBox.Show(status);

            UsersNode node = new UsersNode
            {
                userLogin = usersList[GetNodeIndex(UserNameTextBox.Text)].userLogin,
                userPassword = usersList[GetNodeIndex(UserNameTextBox.Text)].userPassword,
                userBlocked = UserBlockedCheckBox.Checked,
                userLimits = UserLimitsCheckedBox.Checked,
                userRules = usersList[GetNodeIndex(UserNameTextBox.Text)].userRules
            };

            usersList[GetNodeIndex(UserNameTextBox.Text)] = node;
            SetCurrentUserData();

            this.SaveButton.Enabled = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)  // CLOSE THIS WINDOW
        {
            this.Close();
        }

        private void UserBlockedCheckBox_CheckedChanged(object sender, EventArgs e)  // SWITCH BLOCK CELL
        {
            this.SaveButton.Enabled = true;
        }

        private void UserLimitsCheckedBox_CheckedChanged(object sender, EventArgs e)  // SWITCH LIMITS CELL
        {
            this.SaveButton.Enabled = true;
        }
    }
}