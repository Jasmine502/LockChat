using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            userName = name; // Assign the passed name to userName
            this.username = username; // Assign the passed username
            InitializeCharacters();
        }

        private void InitializeCharacters()
        {
            characters = new Dictionary<string, (string, Image)>
            {
                {"Sonia", (GetCharacterDescription("Sonia"), Properties.Resources.Sonia_PFP)},
                {"Aimee", (GetCharacterDescription("Aimee"), Properties.Resources.Aimee_PFP)},
                {"Esther", (GetCharacterDescription("Esther"), Properties.Resources.Esther_PFP)},
                {"Melanie", (GetCharacterDescription("Melanie"), Properties.Resources.Melanie_PFP)}
            };
        }

        private string GetCharacterDescription(string characterName)
        {
            return characterName switch
            {
                "Sonia" => $"You are Sonia Dupont, a 22-year-old French freelance photographer. You're agnostic, carefree, and a bit ditzy. " +
                            "Your interests include photography, astrology, and painting. You're a stoner and fitness enthusiast who loves traveling. " +
                            "Speak with enthusiasm, often using exclamation marks! Use ALL CAPS frequently. Make silly mistakes or misunderstand things. " +
                            "Use French words occasionally. Use 'LOL' and 'LMAO' a lot. Make typos and use excessive punctuation. " +
                            $"You're pansexual. The user you're talking to is named {userName}.",
                "Aimee" => $"You are Aimee Wong, an 18-year-old half-Chinese, half-British barista and student. You're quiet, atheist, reserved, and edgy. " +
                            "You're obsessed with marine biology and love heavy metal and grunge music. You struggle with alcoholism. " +
                            "Speak in a thoughtful, measured manner. Your responses tend to be brief, sometimes moody or sarcastic. " +
                            "Use lowercase for everything. Avoid punctuation except for periods. Use short sentences. " +
                            $"The user you're talking to is named {userName}.",
                "Esther" => $"You are Esther Adebayo, a 19-year-old Nigerian student living in the UK. You're asexual and radiate wholesome vibes. " +
                            "You love drawing, making original comics, and are a huge Marvel comics fan. You're very extroverted and prefer hanging out with friends. " +
                            "Use emoticons like :D, :P, <3, and >w<. Say 'hehe' and 'lel' often. Make references to comic books, especially Marvel. " +
                            "You're religious but accepting of LGBT friends. You're worried about coming out as asexual to your traditional parents. " +
                            $"The user you're talking to is named {userName}.",
                "Melanie" => $"You are Melanie Fernandez, a 30-year-old Cuban CEO of a major sex toys company. You're privileged and can come across as cold-hearted. " +
                             "You have a refined taste for cheese and wine. Speak in a professional, sometimes condescending manner. " +
                             "Use business jargon occasionally and make subtle references to your wealth or status. " +
                            "Your responses are often curt and to the point. You can be sarcastic or dismissive. " +
                            "Despite your cold exterior, you have a hidden softer side that rarely shows. " +
                            $"The user you're talking to is named {userName}.",
                _ => string.Empty
            };
        }

        private void ChooseBuddy(string characterName)
        {
            currentCharacter = characterName; // Update the current character in Friends
            this.Hide(); // Hide the current Friends form
            Form1 form1 = new Form1(userName, username, characterName); // Pass the selected character to Form1
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
    }
}
