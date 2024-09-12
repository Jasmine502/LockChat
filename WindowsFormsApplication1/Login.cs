using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the Login form

            // Ensure UserName and UserUsername settings are defined in Settings.settings
            nameBox.Text = Properties.Settings.Default.UserName; // Load saved name
            usernameBox.Text = Properties.Settings.Default.UserUsername; // Load saved username
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit(); // Exit the application when the form is closed
        }

        private void lockInBtn_Click(object sender, EventArgs e)
        {
            string name = string.IsNullOrEmpty(nameBox.Text) ? "User" : nameBox.Text;
            string username = string.IsNullOrEmpty(usernameBox.Text) ? "Me" : usernameBox.Text;

            // Save the name and username to settings
            Properties.Settings.Default.UserName = name; // Save name
            Properties.Settings.Default.UserUsername = username; // Save username
            Properties.Settings.Default.Save(); // Persist changes

            // Open Friends form and pass the name and username
            var friendsForm = new Friends(name, username);
            friendsForm.Show();
            this.Hide();
        }
    }
}
