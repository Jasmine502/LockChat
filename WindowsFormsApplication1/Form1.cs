using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String name, username, foreColor, buddyName, buddyUserName, prompt;
        String[] buddy = { "Esther", "Sonia", "Aimee", "Melanie" };
        String[] buddyUser = { "Angel616", "xXx_Sony_xXx", "aimaggot666", "MelanieS" };
        String[] promptsMade;
        String[] greetings = { "HELLO", "HI", "YO", "HEY" };
        Random rnd = new Random();
        int buddyNo;
        private void connectButton_Click(object sender, EventArgs e)
        {
            //CHOOSING RANDOM BUDDY
            buddyNo = rnd.Next(buddy.Length);
            buddyName = buddy[buddyNo];
            buddyUserName = buddyUser[buddyNo];
            


            //CONNECT/DISCONNECT BUTTON
            if (connectButton.Text == "CONNECT")
            {
                //SETTING BUDDY PFP
                if (buddyName == "Esther")
                {
                    buddyPFP.Image = Properties.Resources.Esther_PFP;
                }
                else if (buddyName == "Sonia")
                {
                    buddyPFP.Image = Properties.Resources.Sonia_PFP;
                }
                else if (buddyName == "Aimee")
                {
                    buddyPFP.Image = Properties.Resources.Aimee_PFP;
                }
                else if (buddyName == "Melanie")
                {
                    buddyPFP.Image = Properties.Resources.Melanie_PFP;
                }

                nameBox.Enabled = false;
                usernameBox.Enabled = false;
                foreColorBox.Enabled = false;
                pfpBtn.Enabled = false;
                sendButton.Enabled = true;
                messageBox.Enabled = true;
                listMessage.Enabled = true;
                connectButton.Text = "DISCONNECT";
            //FORMATTING LIST BOX
                //MANAGING EMPTY LOG-IN
                if (nameBox.Text == "")
                {
                    name = "Gaster";
                }
                else
                {
                    name = nameBox.Text;
                }

                if (usernameBox.Text == "")
                {
                    username = "Me";
                }
                else
                {
                    username = usernameBox.Text;
                }

                if (userPFP.Image == null)
                {
                    userPFP.Image = Properties.Resources.GasterPFP;
                }

                foreColor = foreColorBox.Text.ToUpper();
                listMessage.Items.Clear();
                listMessage.Items.Add("Connected");

                if (foreColor == "RED")
                {
                    listMessage.ForeColor = Color.Red;
                    listMessage.BackColor = Color.White;
                }
                else if (foreColor == "ORANGE")
                {
                    listMessage.ForeColor = Color.Orange;
                    listMessage.BackColor = Color.Black;
                    messageBox.ForeColor = Color.White;
                    messageBox.BackColor = Color.Black;
                }
                else if (foreColor == "YELLOW")
                {
                    listMessage.ForeColor = Color.Yellow;
                    listMessage.BackColor = Color.Black;
                    messageBox.ForeColor = Color.White;
                    messageBox.BackColor = Color.Black;
                }
                else if (foreColor == "GREEN")
                {
                    listMessage.ForeColor = Color.Green;
                    listMessage.BackColor = Color.White;
                }
                else if (foreColor == "BLUE")
                {
                    listMessage.ForeColor = Color.Blue;
                    listMessage.BackColor = Color.White;
                }
                else if (foreColor == "PINK" || foreColor == "VIOLET")
                {
                    listMessage.ForeColor = Color.Pink;
                    listMessage.BackColor = Color.Black;
                    messageBox.ForeColor = Color.White;
                    messageBox.BackColor = Color.Black;
                }
                else if (foreColor == "PURPLE" || foreColor == "INDIGO")
                {
                    listMessage.ForeColor = Color.Purple;
                    listMessage.BackColor = Color.White;
                }
                else if (foreColor == "BLACK")
                {
                    listMessage.ForeColor = Color.Black;
                    listMessage.BackColor = Color.White;
                }
                else if (foreColor == "WHITE")
                {
                    listMessage.ForeColor = Color.White;
                    listMessage.BackColor = Color.Black;
                }
                else
                {
                    listMessage.ForeColor = Color.Black;
                    listMessage.BackColor = Color.White;
                }
            }
            else
            {
                listMessage.Items.Add("Disconnected");
                connectButton.Text = "CONNECT";
                sendButton.Enabled = false;
                pfpBtn.Enabled = true;
                messageBox.Enabled = false;
                nameBox.Enabled = true;
                usernameBox.Enabled = true;
                foreColorBox.Enabled = true;
            }

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            //EMPTY MESSAGE BOX ERROR
            if (messageBox.Text == "")
            {
                MessageBox.Show("Please enter text into the textbox.", "Error");
            }
            else
            {
                prompt = messageBox.Text.ToUpper();
                listMessage.Items.Add(username + ": " + messageBox.Text);
                listMessage.Items.Add(promptResponse(prompt));
                messageBox.Clear();
            }
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void listMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pfpBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose Profile Picture";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    userPFP.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void solidColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    BackColor = dlg.Color;
                }
            }
        }

        private void rosesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Properties.Resources.RosesBG;
            changeForeColor(Color.White);
        }

        private void cloudsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Properties.Resources.SkyBG;
            changeForeColor(Color.Black);
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose Custom Background";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    BackgroundImage = new Bitmap(dlg.FileName);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void spaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Properties.Resources.SpaceBG;
            changeForeColor(Color.White);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void colorBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (connectButton.Text == "DISCONNECT")
                {
                    sendButton_Click((object)sender, (EventArgs)e);
                }
                else
                {
                    connectButton_Click((object)sender, (EventArgs)e);
                }
            }
        }


        public String promptResponse(String prompt)
        {
            String response = "";
            bool greeting = false;
            for (int i = 0; i < greetings.Length; i++)
            {
                if (prompt.Contains(greetings[i]))
                {
                    greeting = true;

                }
            }
            response = buddyUserName + ": ";

            //ERROR RESPONSES
            String[] estherError = { "What xD", "D: " + name + ", you okay?", "Um... ?_?", "Hehe :) I don't understand, but understood!" };
            String[] soniaError = { "LOL WHAT???", "HAHAHAHA WTF R U ON ABOUT", ".", "R U BIEN?", "oki doki ami" };
            String[] aimeeError = { "?", "wtf?", "ok.", "moving on." };
            String[] melanieError = { "Start making sense.", "You tire me.", "Amazing.", "What?" };

            //GREETING RESPONSES
            String[] estherGreetings = { "Hey hey " + name + "!" , "Heyo!", "Excelsior!", "Yoyo!" };
            String[] estherEarlyGreetings = {"Morning" + name + "!", "Rise and shine!"};
            String[] estherLateGreetings = {};
            
            String[] soniaGreetings = { "hai", "hey lol", "bonjour!!!!", "HELLO " + name.ToUpper()};
            String[] soniaEarlyGreetings = { };
            String[] soniaLateGreetings = { };
            
            String[] aimeeGreetings = { "hi " + name.ToLower() + ".", "hm.", "what", "can i help u?"};
            String[] aimeeEarlyGreetings = { };
            String[] aimeeLateGreetings = { };
            
            String[] melanieGreetings = {"Greetings, " + name + "." , "Oh. It's you.", "Yes?"};
            String[] melanieEarlyGreetings = {"Good morning.", "I didn't take you for a morning person."};
            String[] melanieLateGreetings = {"Good evening.", "Why are you awake at this hour?"};
            

            //WELLBEING RESPONSES
            String[] estherWellbeing = {"I'm great! Thanks for asking " + name + " :)"};
            String[] estherMorningWellbeing = { };
            String[] estherLateWellbeing = { };

            String[] soniaWellbeing = { };
            String[] soniaMorningWellbeing = { };
            String[] soniaLateWellbeing = { };

            String[] aimeeWellbeing = { };
            String[] aimeeMorningWellbeing = { };
            String[] aimeeLateWellbeing = { };

            String[] melanieWellbeing = { };
            String[] melanieMorningWellbeing = { };
            String[] melanieLateWellbeing = { };

            if (buddyName == "Esther")
            {
                if (greeting)
                {
                    response += estherGreetings[rnd.Next(estherGreetings.Length)];
                }
                //ERROR
                else
                {
                    response += estherError[rnd.Next(estherError.Length)];
                }
            }
            else if (buddyName == "Sonia")
            {
                if (greeting)
                {
                    response += soniaGreetings[rnd.Next(soniaGreetings.Length)];
                }
                //ERROR
                else
                {
                    response += soniaError[rnd.Next(soniaError.Length)];
                }
            }

            else if (buddyName == "Aimee")
            {
                if (greeting)
                {
                    response += aimeeGreetings[rnd.Next(aimeeGreetings.Length)];
                }
                //ERROR
                else
                {
                    response += aimeeError[rnd.Next(aimeeError.Length)];
                }
            }
            else if (buddyName == "Melanie")
            {
                if (greeting)
                {
                    response += melanieGreetings[rnd.Next(melanieGreetings.Length)];
                }
                else
                {
                    response += melanieError[rnd.Next(melanieError.Length)];
                }
            }
            else
            {
                MessageBox.Show("You shouldn't be able to see this","How did you see this?");
            }
                
            return response;
        }
        public void changeForeColor(Color color)
        {
            nameLbl.ForeColor = color;
            usernameLbl.ForeColor = color;
            txtColourLbl.ForeColor = color;
            pfpLbl.ForeColor = color;
            loginBox.ForeColor = color;
        }
    }
}
