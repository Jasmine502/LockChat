using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public partial class Friends : Form
    {
        private string currentCharacter = "Sonia";
        private string userName; // Store user name
        private string username; // Store username
        private Dictionary<string, (string systemMessage, Image pfp)> characters;

        public Friends(string name, string username) // Modify the constructor
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the Friends form
            userName = name; // Assign the passed name to userName
            this.username = username; // Assign the passed username
            buddyListGroupBox.Text = $"{userName}'s Buddy List"; // Set the buddy list text
            InitializeCharacters();
        }

        private void InitializeCharacters()
        {
            characters = new Dictionary<string, (string, Image)>
            {
                {"Sonia", (CharacterDescriptions.GetCharacterDescription("Sonia", userName), Properties.Resources.Sonia_PFP)},
                {"Aimee", (CharacterDescriptions.GetCharacterDescription("Aimee", userName), Properties.Resources.Aimee_PFP)},
                {"Esther", (CharacterDescriptions.GetCharacterDescription("Esther", userName), Properties.Resources.Esther_PFP)},
                {"Melanie", (CharacterDescriptions.GetCharacterDescription("Melanie", userName), Properties.Resources.Melanie_PFP)}
            };
        }

        private void ChooseBuddy(string characterName)
        {
            currentCharacter = characterName; // Update the current character in Friends
            this.Hide(); // Hide the current Friends form
            Chat form1 = new Chat(userName, username, characterName); // Pass the selected character to Form1
            form1.Show(); // Show Form1
        }

        private void chooseSonia_Click(object sender, EventArgs e) => ChooseBuddy("Sonia");
        private void chooseEsther_Click(object sender, EventArgs e) => ChooseBuddy("Esther");
        private void chooseAimee_Click(object sender, EventArgs e) => ChooseBuddy("Aimee");
        private void chooseMelanie_Click(object sender, EventArgs e) => ChooseBuddy("Melanie");

        private void chooseSonia_MouseHover(object sender, EventArgs e) => SetBioImage("SoniaBio");
        private void chooseEsther_MouseHover(object sender, EventArgs e) => SetBioImage("EstherBio");
        private void chooseAimee_MouseHover(object sender, EventArgs e) => SetBioImage("AimeeBio");
        private void chooseMelanie_MouseHover(object sender, EventArgs e) => SetBioImage("MelanieBio");

        private void SetBioImage(string resourceName) => bioBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceName);

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit(); // Exit the application when the form is closed
        }

        private void coltonBtn_MouseHover(object sender, EventArgs e) => SetBioImage("ColtonBio");
        private void eastonBtn_MouseHover(object sender, EventArgs e) => SetBioImage("EastonBio");
        private void lilyBtn_MouseHover(object sender, EventArgs e) => SetBioImage("LilyBio");
        private void birdBtn_MouseHover(object sender, EventArgs e) => SetBioImage("BirdBio");
        private void robinBtn_MouseHover(object sender, EventArgs e) => SetBioImage("RobinBio"); // Added hover for Robin

        private void lockOutButton_Click(object sender, EventArgs e) // Added lockOutButton_Click method
        {
            this.Hide(); // Hide the current Friends form
            Login loginForm = new Login(); // Create a new instance of the Login form
            loginForm.Show(); // Show the Login form
        }
    }
}
