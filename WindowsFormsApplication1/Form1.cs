using System;
using System.Drawing;
using System.Media;
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
        String[] greetings = { "HELLO", "HI", "HEY", "YO " };
        String[] wellbeings = { "HRU", "HOW R U", "HOW ARE U", "HYD", "HOW U DOIN", "HOW YOU DOIN", "HOW ARE YOU" };
        String[] wyd = { "SUP", "WASSUP", "WATS UP", "WAT U DOIN", "WHAT ARE YOU DOIN", "WHAT R U DOIN", "WHATS UP", "WHAT U DOIN", "WHAT YOU DOIN", "WHAT YOU UP 2", "WHAT YOU UP TO", "WUT R U DOIN", "WUT R U DOIN", "WUTS UP", "WUT U UP TO", "WUU2", "WUUT", "WYD" };
        Random rnd = new Random();
        SoundPlayer sound;
        bool greeting;
        int buddyNo;

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(862, 584);
            sound = new SoundPlayer(Properties.Resources.LockChat_LOOP);
            sound.PlayLooping();
            listMessage.Hide();
            buddyPFP.Hide();
            userPFP.Hide();
            messageBox.Hide();
            sendButton.Hide();
            groupBox1.Hide();
            bioBox.Hide();
            chooseEsther.Hide();
            chooseSonia.Hide();
            chooseAimee.Hide();
            chooseMelanie.Hide();
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            Size = new Size(548, 584);
            CenterToScreen();
            //SHOW/HIDE ELEMENTS
            loginBox.Hide();
            loginButton.Hide();
            groupBox1.Show();
            bioBox.Show();
            chooseEsther.Show();
            chooseSonia.Show();
            chooseAimee.Show();
            chooseMelanie.Show();


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

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void bKYUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.B__KYU;
        }

        private void eUPHORIA6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.EUPHORIA_6;
        }

        private void mutationSyndromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Mutation_Syndrome;
        }

        private void nITROUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.NITROUS;
        }

        private void stargazingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.stargazing;
        }

        private void uNAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.UNA;
        }

        private void ashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Ash;
        }

        private void gokuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Goku;
        }

        private void kanekiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Kaneki;
        }

        private void narutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Naruto;
        }

        private void nicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Nico;
        }

        private void pikachuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Pikachu;
        }

        private void sailorMoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Sailor_Moon;
        }

        private void yunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Yuno;
        }

        private void catToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Cat;
        }

        private void clownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Clown;
        }

        private void dogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Dog;
        }

        private void eyeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Eye;
        }

        private void flowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Flower;
        }

        private void guitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Guitar;
        }

        private void loveHeartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Love_Heart;
        }

        private void pirateSKullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Pirate_Skull;
        }

        private void beachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Beach;
        }

        private void forestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Forest;
        }

        private void mountainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Mountains;
        }

        private void sunsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Sunset;
        }

        private void daBabyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.DaBaby;
        }

        private void dogeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Doge;
        }

        private void evilPatrickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Evil_Patrick;
        }

        private void illuminatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Illuminati;
        }

        private void mattToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Matt;
        }

        private void obamiumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Obamium;
        }

        private void rickRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Rick_Roll;
        }

        private void sIUUUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.SIUUU;
        }

        private void spongeMockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Sponge_Mock;
        }

        private void trollfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Trollface;
        }

        private void whiteDrakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.White_Drake;
        }

        private void findingNemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Finding_Nemo;
        }

        private void fridayThe13thToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Friday_the_13th;
        }

        private void frozenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Frozen;
        }

        private void harryPotterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Harry_Potter;
        }

        private void jurassicParkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Jurassic_Park;
        }

        private void nightmareOnElmStreetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Nightmare_on_Elm_Street;
        }

        private void starWarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Star_Wars;
        }

        private void terminatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Terminator;
        }

        private void theMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.The_Matrix;
        }

        private void toyStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Toy_Story;
        }

        private void batmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Batman;
        }

        private void asexualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Asexual;
        }

        private void bisexualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Bisexual;
        }

        private void lesbianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Lesbian;
        }

        private void nonbinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Non_binary;
        }

        private void pansexualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Pansexual;
        }

        private void rainbowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Rainbow;
        }

        private void transgenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Transgender;
        }

        private void basketballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Basketball;
        }

        private void footballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Football;
        }

        private void tennisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Tennis;
        }

        private void spidermanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Spiderman;
        }

        private void supermanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Superman;
        }

        private void theFlashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.The_Flash;
        }

        private void carToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Car;
        }

        private void motorcycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Motorcycle;
        }

        private void planeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Plane;
        }


        private void arthurMorganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Arthur_Morgan;
        }

        private void bigbyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Bigby;
        }

        private void chloePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Chloe_Price;
        }

        private void clementineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Clementine;
        }

        private void henryStickminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Henry_Stickmin;
        }

        private void imposterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Imposter;
        }

        private void jonesyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Jonesy;
        }

        private void leeEverettToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Lee_Everett;
        }

        private void plumbobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Plumbob;
        }

        private void sansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Sans;
        }

        private void steveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Steve;
        }

        private void trevorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Trevor;
        }

        private void zagreusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.Zagreus;
        }

        private void chooseSonia_Click(object sender, EventArgs e)
        {
            buddyNo = 2;
            mainChatShowHideElements();
            buddyName = buddy[1];
            buddyUserName = buddyUser[1];
            buddyPFP.Image = Properties.Resources.Sonia_PFP;
        }

        private void chooseEsther_Click(object sender, EventArgs e)
        {
            buddyNo = 1;
            mainChatShowHideElements();
            buddyName = buddy[0];
            buddyUserName = buddyUser[0];
            buddyPFP.Image = Properties.Resources.Esther_PFP;
        }

        private void chooseAimee_Click(object sender, EventArgs e)
        {
            buddyNo = 3;
            mainChatShowHideElements();
            buddyName = buddy[2];
            buddyUserName = buddyUser[2];
            buddyPFP.Image = Properties.Resources.Aimee_PFP;
        }

        private void chooseMelanie_Click(object sender, EventArgs e)
        {
            buddyNo = 4;
            mainChatShowHideElements();
            buddyName = buddy[3];
            buddyUserName = buddyUser[3];
            buddyPFP.Image = Properties.Resources.Melanie_PFP;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void freddyFazbearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPFP.Image = Properties.Resources.FreddyFazbear;
        }

        private void chooseEsther_MouseHover(object sender, EventArgs e)
        {
            bioBox.Image = Properties.Resources.EstherBio_Temp;
        }

        private void chooseSonia_MouseHover(object sender, EventArgs e)
        {
            bioBox.Image = Properties.Resources.SoniaBio_Temp;
        }

        private void chooseAimee_MouseHover(object sender, EventArgs e)
        {
            bioBox.Image = Properties.Resources.AimeeBio_Temp;
        }

        private void chooseMelanie_MouseHover(object sender, EventArgs e)
        {
            bioBox.Image = Properties.Resources.MelanieBio_Temp;
        }

        private void colorBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click((object)sender, (EventArgs)e);
            }
        }


        public String promptResponse(String prompt)
        {
            String response = "";
            bool greeting = false;
            bool wellbeing = false;
            bool wydCheck = false;
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
                for (int i = 0; i < wyd.Length; i++)
                {
                    if (prompt.Contains(wyd[i]))
                    {
                        wydCheck = true;
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
            String[] estherRepeat = { "Oh! Didn’t we talk about this already ?", "I can see that you’re tired, you’ve said that before, maybe you should rest :(", "Woah, am I in a time loop? I swear you’ve said that before!", "Uhh… are you confused? This isn’t the first time you said this :P", "Hahaha you’re repeating yourself xD" };
            String[] soniaRepeat = { "LOL R U HIGH???? youve said that dumb face", "que?? again?? deja vu", prompt.ToLower(), " lol", "ur having a brainfart fjkahkjdsfa or am i? u have said this non?", "are u testing me to see if i pay attention in the conversations, bcz i do!! u have said this lmao", "SAY SOMETHING NEW AAAAAAAAAAAA" };
            String[] aimeeRepeat = { "this again? get better lines npc.", "stop repeating yourself.", "are you stupid? you just said that.", "my response isnt gonna change the more you bring it up.", "riiiiiiight… should i pretend this is the first time you said that?" };
            String[] melanieRepeat = { "Perhaps take a break. You seem to be forgetting what we have already discussed.", "Do watch yourself, I don’t like repeating myself unlike you.", "Alright. Lovely conversation. Talk to me again when you have practiced having real conversations.", "Do you need me to call you a paramedic? Repetition is a sign of memory loss, and you seem to be suffering from it.", "You have said this. Did you already forget?" };

            //GREETING RESPONSES
            String[] estherGreetings = { "Hey hey " + name + "!", "Heyo!", "Excelsior!", "Yoyo!" };

            String[] soniaGreetings = { "hai", "hey lol", "bonjour!!!!", "HELLO " + name.ToUpper() };

            String[] aimeeGreetings = { "hi " + name.ToLower() + ".", "hm.", "what", "can i help u?" };

            String[] melanieGreetings = { "Greetings, " + name + ".", "Oh. It's you.", "Yes?" };


            //WELLBEING RESPONSES
            String[] estherWellbeing = { "I’m doing great!! Thank you for asking " + name + ".", "Everything is good, today has been nice! :D", "So and so, it’s not so bad, how about you?", ":( Feeling a tiny bit sad but it will pass… how about you?", "Just stressing about lockdown :P You?" };

            String[] soniaWellbeing = { "BIEN", "omg ty for asking i was just about to ask u how u were but look at us in synch TOTALLY AMAZING!!!! just did like 3 meters of the white powder!! i dont actually know what that means I was jk dont report me " + name.ToLower(), "nooooo awfullllll im bored and i wanna go outsideeee aaaaaaaa", "doing okiedokie how u are doing too?", "meh could be better but it could be VERY BAD TOO SO ITS OKAY LOL IM JUST LOWKEY FREAKING OUT" };

            String[] aimeeWellbeing = { "breathing.", "bad.", "i don’t know. does it matter?", "okay. you?", "wow boring question. i'm fine.", "bored.", "it’s whatever. how about you?", "locking down." };

            String[] melanieWellbeing = { "Currently busy with work. I hope you are doing something useful with your time too?", "Had a good day, no one pissed me off today. Don’t change that.", "Stressed, but when am I not? Are you faring better than I am?", "In this environment that’s the type of question that you get fired for. So refrain from asking stupid questions like that ever again.", "Oh. How nice. You care.", "Annoyed so please don’t test that. Either way, how are you " + name + "?" };

            //WYD RESPONSES
            String[] estherWYD = { };
            String[] soniaWYD = {"ABSOLUTELY NOTHING I RLLY WANNA GO OUT but i could get in trouble 😭😭😭😭😭😭", "literally NOTHING " + name.ToUpper() + "!!! i need to leave the house ASAP.", "I WISH I WAS DOING SMTH MORE INTERESTING TO TELL U BUT..... nothing :O i wanna do something tho","DYING I CANT BE CRAMPED IN HERE FOR ANY LONGER " + name.ToUpper() + " PLS SEND HELP"};
            String[] aimeeWYD = { };
            String[] melanieWYD = { };

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
                    else if (wydCheck)
                    {
                        response += soniaWYD[rnd.Next(soniaWYD.Length)];
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
                MessageBox.Show("You shouldn't be able to see this", "How did you see this?");
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
            loginBox.ForeColor = color;
        }

        public void mainChatShowHideElements()
        {
            groupBox1.Hide();
            bioBox.Hide();
            chooseEsther.Hide();
            chooseSonia.Hide();
            chooseAimee.Hide();
            chooseMelanie.Hide();
            listMessage.Show();
            userPFP.Show();
            buddyPFP.Show();
            messageBox.Show();
            sendButton.Show();
            Size = new Size(862, 584);
            CenterToScreen();

        }
    }
}
