using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String name, username, buddyName, buddyUserName, prompt;
        String[] buddy = { "Esther", "Sonia", "Aimee", "Melanie" };
        String[] buddyUser = { "Angel616", "xXx_Sony_xXx", "aimaggot666", "MelanieS" };
        String promptsMade = "";
        String[] greetings = { "HELLO", "HI", "HEY", "YO " };
        String[] wellbeings = { "HRU", "HOW R U", "HOW ARE U", "HYD", "HOW U DOIN", "HOW YOU DOIN", "HOW ARE YOU","HOW'S LIFE","HOWS LIFE"};
        String[] wyd = { "SUP", "WASSUP", "WATS UP", "WAT U DOIN", "WHAT ARE YOU DOIN", "WHAT R U DOIN", "WHATS UP", "WHAT U DOIN", "WHAT YOU DOIN", "WHAT YOU UP 2", "WHAT YOU UP TO", "WUT R U DOIN", "WUT R U DOIN", "WUTS UP", "WUT U UP TO", "WUU2", "WUUT", "WYD" };
        String[] goOut = { "GO OUT", "BREAK THE RULES", "SHOULD LEAVE THE HOUSE", "SHOULD LEAVE UR HOUSE" };
        String[] stayHome = { "STAY HOME", "STAY AT HOME", "DONT LEAVE", "DON'T LEAVE", "DO NOT LEAVE", "HAVE TO STAY", "MUST STAY", "RISKY" };
        String[] compliments = { "UR COOL", "YOU'RE COOL", "U R COOL", "U ARE COOL", "UR SWEET", "YOU'RE SWEET", "U R SWEET", "U ARE SWEET", "UR FUNNY", "YOU'RE FUNNY", "U R FUNNY", "U ARE FUNNY", "LIKE TALKING TO U", "LIKE TALKING TO YOU", "LOVE TALKING TO U", "LOVE TALKING TO YOU", "UR GREAT", "YOU'RE GREAT", "U R GREAT", "U ARE GREAT", "UR AMAZING", "YOU'RE AMAZING", "U R AMAZING", "U ARE AMAZING" };
        String[] affection = { " I LIKE YOU", "I LIKE U", "I LOVE YOU", "I LOVE U", "ILY", "IN LOVE WITH U", "IN LOVE WITH YOU" };
        String[] thanks = { "TY ", "THANK", "MERCI", "GRACIAS", "CHEERS", " TY" };
        String[] laughing = {"LOL", "LMAO","ROFL","HAHA"};
        Random rnd = new Random();
        SoundPlayer sound;
        int buddyNo;
        int relationshipPts;
        int covidPts;

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
            relationshipPts = 0;
            covidPts = 0;

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

            listMessage.Items.Clear();
            listMessage.Items.Add("Connected");

            


        }

        private async void sendButton_Click(object sender, EventArgs e)
        { 
            //EMPTY MESSAGE BOX ERROR
            if (messageBox.Text == "")
            {
                MessageBox.Show("Please enter text into the textbox.", "Error");
            }
            else
            {
                prompt = messageBox.Text.ToUpper();
                listMessage.Items.Add(username + ":");
                listMessage.Items.Add(messageBox.Text);
                listMessage.Items.Add("");
                messageBox.Clear();
                await Task.Delay(rnd.Next(1000,4000));
                listMessage.Items.Add(buddyUserName + ":");
                listMessage.Items.Add(promptResponse(prompt));
                listMessage.Items.Add("");
                
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
            bioBox.Image = Properties.Resources.EstherBio;
        }

        private void chooseSonia_MouseHover(object sender, EventArgs e)
        {
            bioBox.Image = Properties.Resources.SoniaBio;
        }

        private void chooseAimee_MouseHover(object sender, EventArgs e)
        {
            bioBox.Image = Properties.Resources.AimeeBio;
        }

        private void chooseMelanie_MouseHover(object sender, EventArgs e)
        {
            bioBox.Image = Properties.Resources.MelanieBio;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listMessage.ForeColor = Color.Red;
            listMessage.BackColor = Color.White;
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listMessage.ForeColor = Color.Orange;
            listMessage.BackColor = Color.Black;
            messageBox.ForeColor = Color.White;
            messageBox.BackColor = Color.Black;
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listMessage.ForeColor = Color.Yellow;
            listMessage.BackColor = Color.Black;
            messageBox.ForeColor = Color.White;
            messageBox.BackColor = Color.Black;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listMessage.ForeColor = Color.Green;
            listMessage.BackColor = Color.White;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listMessage.ForeColor = Color.Blue;
            listMessage.BackColor = Color.White;
        }

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listMessage.ForeColor = Color.Pink;
            listMessage.BackColor = Color.Black;
            messageBox.ForeColor = Color.White;
            messageBox.BackColor = Color.Black;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listMessage.ForeColor = Color.Black;
            listMessage.BackColor = Color.White;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listMessage.ForeColor = Color.White;
            listMessage.BackColor = Color.Black;
        }

        private void colorBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBox_Enter(object sender, EventArgs e)
        {

        }

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click((object)sender, (EventArgs)e);
            }
            else
            {
                Console.WriteLine("lol");
            }
        }


        public String promptResponse(String prompt)
        {
            String response = "";
            bool greeting = false;
            bool wellbeing = false;
            bool wydCheck = false;
            bool goOutCheck = false;
            bool stayHomeCheck = false;
            bool complimented = false;
            bool affectionate = false;
            bool thanked = false;
            bool lol = false;

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
                for (int i = 0; i < goOut.Length; i++)
                {
                    if (prompt.Contains(goOut[i]))
                    {
                        goOutCheck = true;
                    }
                }
                for (int i = 0; i < stayHome.Length; i++)
                {
                    if (prompt.Contains(stayHome[i]))
                    {
                        stayHomeCheck = true;
                    }
                }
                for (int i = 0; i < compliments.Length; i++)
                {
                    if (prompt.Contains(compliments[i]))
                    {
                        complimented = true;
                    }
                }
                for (int i = 0; i < affection.Length; i++)
                {
                    if (prompt.Contains(affection[i]))
                    {
                        affectionate = true;
                    }
                }
                for (int i = 0; i < thanks.Length; i++)
                {
                    if (prompt.Contains(thanks[i]))
                    {
                        thanked = true;
                    }
                    else if (prompt == "TY")
                    {
                        thanked = true;
                    }
                }
                for (int i = 0; i < laughing.Length; i++)
                {
                    if(prompt.Contains(laughing[i]))
                    {
                        lol = true;
                    }
                }
            }


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
            String[] estherWellbeing = { "I’m doing great!! Thank you for asking " + name + ".", "Everything is good, today has been nice! :D", "So and so, it’s not so bad I guess...", ":( Feeling a tiny bit sad but it will pass… ", "Just stressing about lockdown :P You?" };
            String[] soniaWellbeing = { "BIEN... kinda just stuck indoors lol", "nooooo awfullllll im bored and i wanna go outsideeee aaaaaaaa", "meh could be better but it could be VERY BAD TOO SO ITS OKAY LOL IM JUST LOWKEY FREAKING OUT" };
            String[] aimeeWellbeing = { "breathing.", "bad.", "i don’t know. does it matter?", "okay. you?", "wow boring question. i'm fine.", "bored.", "it’s whatever.", "locking down." };
            String[] melanieWellbeing = {"Had a good day, no one pissed me off today. Don’t change that.", "Stressed, but when am I not? That was rhetoric, by the way.", "In this environment that’s the type of question that you get fired for. So refrain from asking stupid questions like that ever again.", "Oh. How nice. You care. I'm managing.", "Annoyed so please don’t test that."};

            //WYD RESPONSES
            String[] estherWYD = { "It is a lovely day, the sun would feel great! Maybe I should take a walk :P", "Just getting ready to get to the comic book store... The new chapter of UNA comics just came out!!!",  };
            String[] soniaWYD = { "ABSOLUTELY NOTHING I RLLY WANNA GO OUT but i could get in trouble 😭😭😭😭😭😭", "literally NOTHING " + name.ToUpper() + "!!! i need to leave the house ASAP.", "I WISH I WAS DOING SMTH MORE INTERESTING TO TELL U BUT..... nothing :O i wanna do something tho", "DYING I CANT BE CRAMPED IN HERE FOR ANY LONGER " + name.ToUpper() + " PLS SEND HELP" };
            String[] aimeeWYD = {"rotting.","nothing as always.","staring into the endless void","surprisingly looking outside and kinda wanting to escape this cage."};
            String[] melanieWYD = { "Currently busy with work.","Responding to e-mails at the moment. Somehow they are more taxing than conversing with you.","Just gave myself a break because I can. Might go for a well-deserved Melanie Promenade." };

            //GO OUT RESPONSES
            String[] estherGoOut = {"Yay! Glad you agree " + name + ".","Let's go!!!! About time hehe","Heck yeah! I will do just that :)"};
            String[] soniaGoOut = { "MAYBE I WILL.", "very good idea :) i just need to be sneaky beaky >.>", "YESSIRRRRRRR GREAT IDEA"};
            String[] aimeeGoOut = { "sure, but only when it gets darker...", "you're one to talk, but i guess i should","ill do it but only because i want to.","yea nah nevermind","actually cant be bothered tbf"};
            String[] melanieGoOut = { "I am far too busy today to 'go out', but I'll keep your unsolicited advice in mind.", "You're right, I've been stuck in the office for too long. I need some air.", "God yes, I need a drink too." };

            //STAY HOME RESPONSES
            String[] estherStayHome = {"Okie... I should be more responsible, you're right!","Awh :("};
            String[] soniaStayHome = { "AAAAAA BUT I NEED TO ESCAPE THIS NETHER HOLE", "I KNOW I SHOULD STAY BUT ITS KILLING MEEEE","it's worth the risk at this point " + name.ToLower() + "😭", "OKAY FINE ILL STAY PFFT", "YEAH? yeah. ye.... u rite"};
            String[] aimeeStayHome = {"you don't tell me what to do.","ugh. fine.", "my eyes cannot roll further back into my skull"};
            String[] melanieStayHome = { "Ah yes. It is clear now that I have way too much work to focus on.", "On second thought, I'd have to confer with my assistant, so I'd rather not leave the house.", "I have a meeting soon, so perhaps I shouldn't waste time." };

            //COMPLIMENT RESPONSES
            String[] estherComp = {"Eek! That's so nice, thank you " + name + "!!! :D","Oh my- That means so much thank you!","D'awh... That is so sweet thank you so much :P","Ah! So unexpected but much appreciated, likewise!"};
            String[] soniaComp = { "OMG " + name.ToUpper() + "THATS SO NICE THANK U AND LIKEWISE :)", "AKLSJDLKSAJJDFU TY U TOOOOOO", "thats so sweet 🤧🤧 thank u i feel the same", "MON DIEU MERCI BEAUCOUP <3 you too", "wtf where did this come from????? im flattered ty " + name.ToLower() + "!!!!" };
            
            //AFFECTION ACCEPTED RESPONSES
            String[] soniaAffection = { "KAFNOEISHIOFEJFEWSOUGB I THINK I FEEL THE SAME <.<", "omg really what what what i do too wtf this isnt happening", "OMG ME TOO AAAAAAAAA :)))))" };

            //AFFECTION DENIED RESPONSES
            String[] soniaNoAffection = { "AAAA IM SO SORRY BUT ITS WAY TOO SOON FOR THAT LMAOOO PLEASE", "WTFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF " + name.ToUpper() + "its too early to catch feelings :((("};

            //THANKS RESPONES
            String[] estherTY = { "Happy to help :)","No worries!","You're very welcome!"};
            String[] soniaTY = { "no problemo ;)", "NP!!!!", "I GOCHU " + name.ToUpper(), "anytime famalam", "ur very very very very very welcome", "it is mon pleasure hehe" };
            String[] aimeeTY = {"ok.","whatever.","you owe me"};

            //LAUGHING RESPONSES
            String[] estherLOL = { "Hehe D",":P","XD","Glad I could make you laugh xD"};
            String[] soniaLOL = {"HA I MADE U LAUGH", ":)", ":D", "HAHAHAHAHA", "LMAO"};
            String[] aimeeLOL = {"wasnt that funny.","hilarious.","lol.","haha.","shut up."};
            String[] melanieLOL = { }; //GET ANA TO DO IT LOL

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
                    else if (wydCheck)
                    {
                        response += estherWYD[rnd.Next(estherWYD.Length)];
                    }
                    else if (goOutCheck)
                    {
                        covidPts++;
                        response += estherGoOut[rnd.Next(estherGoOut.Length)];
                    }
                    else if (stayHomeCheck)
                    {
                        covidPts--;
                        response += estherStayHome[rnd.Next(estherStayHome.Length)];
                    }
                    else if (complimented)
                    {
                        relationshipPts++;
                        response += estherComp[rnd.Next(estherComp.Length)];
                    }
                    /*
                    else if (affectionate)
                    {
                        if (relationshipPts > 4)
                        {
                            response += estherAffection[rnd.Next(estherAffection.Length)];
                        }
                        else
                        {
                            response += estherNoAffection[rnd.Next(estherNoAffection.Length)];
                        }
                    }
                    */
                    else if (thanked)
                    {
                        response += estherTY[rnd.Next(estherTY.Length)];
                    }
                    else if (lol)
                    {
                        response += estherLOL[rnd.Next(estherLOL.Length)];
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
                    else if (goOutCheck)
                    {
                        covidPts++;
                        response += soniaGoOut[rnd.Next(soniaGoOut.Length)];
                    }
                    else if (stayHomeCheck)
                    {
                        covidPts--;
                        response += soniaStayHome[rnd.Next(soniaStayHome.Length)];
                    }
                    else if (complimented)
                    {
                        relationshipPts++;
                        response += soniaComp[rnd.Next(soniaComp.Length)];
                    }
                    else if (affectionate)
                    {
                        if (relationshipPts > 4)
                        {
                            response += soniaAffection[rnd.Next(soniaAffection.Length)];
                        }
                        else
                        {
                            response += soniaNoAffection[rnd.Next(soniaNoAffection.Length)];
                        }
                    }
                    else if (thanked)
                    {
                        response += soniaTY[rnd.Next(soniaTY.Length)];
                    }
                    else if (lol)
                    {
                        response += soniaLOL[rnd.Next(soniaLOL.Length)];
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
                    else if (wydCheck)
                    {
                        response += aimeeWYD[rnd.Next(aimeeWYD.Length)];
                    }
                    else if (goOutCheck)
                    {
                        covidPts++;
                        response += aimeeGoOut[rnd.Next(aimeeGoOut.Length)];
                    }
                    else if (stayHomeCheck)
                    {
                        covidPts--;
                        response += aimeeStayHome[rnd.Next(aimeeStayHome.Length)];
                    }
                    else if (thanked)
                    {
                        response += aimeeTY[rnd.Next(aimeeTY.Length)];
                    }
                    else if (lol)
                    {
                        response += aimeeLOL[rnd.Next(aimeeLOL.Length)];
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
                    else if (wydCheck)
                    {
                        response += melanieWYD[rnd.Next(melanieWYD.Length)];
                    }
                    else if (goOutCheck)
                    {
                        covidPts++;
                        response += melanieGoOut[rnd.Next(melanieGoOut.Length)];
                    }
                    else if (stayHomeCheck)
                    {
                        covidPts--;
                        response += melanieStayHome[rnd.Next(melanieStayHome.Length)];
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
