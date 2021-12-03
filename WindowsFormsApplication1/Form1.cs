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
        String promptsMade = "";
        String[] greetings = { "HELLO", "HI","HEY" };
        String[] wellbeings = {"HRU","HOW R U","HOW ARE U","HYD","HOW U DOIN","HOW YOU DOIN", "HOW ARE YOU"};
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
                promptsMade = "";
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
                    BackgroundImage = null;
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

        private void underwaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Properties.Resources.UnderwaterBG;
            changeForeColor(Color.White);
        }

        private void meadowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Properties.Resources.MeadowBG;
            changeForeColor(Color.Black);
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
            bool wellbeing = false;
            bool hasPromptBeenMade = false;

            if (promptsMade.Contains(prompt))
            {
                hasPromptBeenMade = true;
            }
            if (!hasPromptBeenMade)
            {
                for (int i = 0; i < greetings.Length; i++)
                {
                    if (prompt.Contains(greetings[i]))
                    {
                        greeting = true;
                    }
                }
                for (int i = 0; i < wellbeings.Length; i++)
                {
                    if (prompt.Contains(wellbeings[i]))
                    {
                        wellbeing = true;
                    }
                }
            }
            response = buddyUserName + ": ";


            //ERROR RESPONSES
            String[] estherError = { "What xD", "D: " + name + ", you okay?", "Um... ?_?", "Hehe :) I don't understand, but understood!" };
            String[] soniaError = { "LOL WHAT???", "HAHAHAHA WTF R U ON ABOUT", ".", "R U BIEN?", "oki doki ami" };
            String[] aimeeError = { "?", "wtf?", "ok.", "moving on." };
            String[] melanieError = { "Start making sense.", "You tire me.", "Amazing.", "What?" };

            //REPEAT RESPONSES
            // ----- CHANGE THESE --------
            String[] estherRepeat = {"Oh! Didn’t we talk about this already ?", "I can see that you’re tired, you’ve said that before, maybe you should rest :(", "Woah, am I in a time loop? I swear you’ve said that before!", "Uhh… are you confused? This isn’t the first time you said this :P", "Hahaha you’re repeating yourself xD" };
            String[] soniaRepeat = { "LOL R U HIGH???? youve said that dumb face", "que?? again?? deja vu", prompt.ToLower(), " lol", "ur having a brainfart fjkahkjdsfa or am i? u have said this non?", "are u testing me to see if i pay attention in the conversations, bcz i do!! u have said this lmao", "SAY SOMETHING NEW AAAAAAAAAAAA"};
            String[] aimeeRepeat = { "this again? get better lines npc.", "stop repeating yourself.", "are you stupid? you just said that.", "my response isnt gonna change the more you bring it up.", "riiiiiiight… should i pretend this is the first time you said that?"};
            String[] melanieRepeat = { "Perhaps take a break. You seem to be forgetting what we have already discussed.", "Do watch yourself, I don’t like repeating myself unlike you.", "Alright. Lovely conversation. Talk to me again when you have practiced having real conversations.", "Do you need me to call you a paramedic? Repetition is a sign of memory loss, and you seem to be suffering from it.", "You have said this. Did you already forget?" };

            //GREETING RESPONSES
            String[] estherGreetings = { "Hey hey " + name + "!" , "Heyo!", "Excelsior!", "Yoyo!" };
            
            String[] soniaGreetings = { "hai", "hey lol", "bonjour!!!!", "HELLO " + name.ToUpper()};
            
            String[] aimeeGreetings = { "hi " + name.ToLower() + ".", "hm.", "what", "can i help u?"};

            String[] melanieGreetings = {"Greetings, " + name + "." , "Oh. It's you.", "Yes?"};
            

            //WELLBEING RESPONSES
            String[] estherWellbeing = {"I’m doing great!! Thank you for asking " + name + ".", "Everything is good, today has been nice! :D", "So and so, it’s not so bad, how about you?", ":( Feeling a tiny bit sad but it will pass… how about you?", "Just stressing about school :P You?" };

            String[] soniaWellbeing = {"BIEN", "omg ty for asking i was just about to ask u how u were but look at us in synch TOTALLY AMAZING!!!! just did like 3 meters of the white powder!! i dont actually know what that means I was jk dont report me " + name.ToLower(), "nooooo awfullllll its raininggggggg aaaaaaaa", "doing okiedokie how u are doing too?", "im just doing nothing soooo pretty bored… are u doing lots of things now?", "meh could be better but it could be VERY BAD TOO SO ITS OKAY LOL" };

            String[] aimeeWellbeing = {"breathing.", "bad.", "i don’t know. does it matter?", "okay. you?", "wow boring question. i'm fine.", "bored.", "it’s whatever. how about you?"};

            String[] melanieWellbeing = { "Currently busy with work. I hope you are doing something useful with your time too?", "Had a good day, no one pissed me off today. Don’t change that.", "Stressed, but when am I not? Are you faring better than I am?", "In this environment that’s the type of question that you get fired for. So refrain from asking stupid questions like that ever again.", "Oh. How nice. You care.", "Annoyed so please don’t test that. Either way, how are you " + name + "?"};

            if (buddyName == "Esther")
            {
                if (hasPromptBeenMade)
                {
                    response += estherRepeat[rnd.Next(estherRepeat.Length)];
                }
                else
                {
                    if (greeting)
                    {
                        response += estherGreetings[rnd.Next(estherGreetings.Length)];
                    }
                    else if (wellbeing)
                    {
                        response += estherWellbeing[rnd.Next(estherWellbeing.Length)];
                    }
                    //ERROR
                    else
                    {
                        response += estherError[rnd.Next(estherError.Length)];
                    }
                }
            }
            else if (buddyName == "Sonia")
            {
                if (hasPromptBeenMade)
                {
                    response += soniaRepeat[rnd.Next(estherRepeat.Length)];
                }
                else
                {
                    if (greeting)
                    {
                        response += soniaGreetings[rnd.Next(soniaGreetings.Length)];
                    }
                    else if (wellbeing)
                    {
                        response += soniaWellbeing[rnd.Next(soniaWellbeing.Length)];
                    }
                    //ERROR
                    else
                    {
                        response += soniaError[rnd.Next(soniaError.Length)];
                    }
                }
            }

            else if (buddyName == "Aimee")
            {
                if (hasPromptBeenMade)
                {
                    response += aimeeRepeat[rnd.Next(estherRepeat.Length)];
                }
                else
                {
                    if (greeting)
                    {
                        response += aimeeGreetings[rnd.Next(aimeeGreetings.Length)];
                    }
                    else if (wellbeing)
                    {
                        response += aimeeWellbeing[rnd.Next(aimeeWellbeing.Length)];
                    }
                    //ERROR
                    else
                    {
                        response += aimeeError[rnd.Next(aimeeError.Length)];
                    }
                }
            }
            else if (buddyName == "Melanie")
            {
                if (hasPromptBeenMade)
                {
                    response += melanieRepeat[rnd.Next(estherRepeat.Length)];
                }
                else
                {
                    if (greeting)
                    {
                        response += melanieGreetings[rnd.Next(melanieGreetings.Length)];
                    }
                    else if (wellbeing)
                    {
                        response += melanieWellbeing[rnd.Next(melanieWellbeing.Length)];
                    }
                    else
                    {
                        response += melanieError[rnd.Next(melanieError.Length)];
                    }
                }
            }
            else
            {
                MessageBox.Show("You shouldn't be able to see this","How did you see this?");
            }

            promptsMade += prompt;
            Console.WriteLine(promptsMade);
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
