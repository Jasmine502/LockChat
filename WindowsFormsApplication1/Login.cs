using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lockInBtn_Click(object sender, EventArgs e)
        {
            string name = string.IsNullOrEmpty(nameBox.Text) ? "User" : nameBox.Text;
            string username = string.IsNullOrEmpty(usernameBox.Text) ? "Me" : usernameBox.Text;

            // Open Friends form and pass the name and username
            var friendsForm = new Friends(name, username);
            friendsForm.Show();
            this.Hide();
        }
    }
}
