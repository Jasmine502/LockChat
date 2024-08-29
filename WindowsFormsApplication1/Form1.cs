using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.IO;

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
        String[] greetings = { "HELLO", "HI", "HEY ", "YO ", "HEY", };
        String[] wellbeings = { "HRU", "HOW R U", "HOW ARE U", "HYD", "HOW U DOIN", "HOW YOU DOIN", "HOW ARE YOU", "HOW'S LIFE", "HOWS LIFE", "HOW WAS UR DAY", "HOW WAAS YOUR DAY" };
        String[] wyd = { "SUP", "WASSUP", "WATS UP", "WAT U DOIN", "WHAT ARE YOU DOIN", "WHAT R U DOIN", "WHATS UP", "WHAT U DOIN", "WHAT YOU DOIN", "WHAT YOU UP 2", "WHAT YOU UP TO","WHAT U UP TO", "WUT R U DOIN", "WUT R U DOIN", "WUTS UP", "WUT U UP TO", "WUU2", "WUUT", "WYD" };
        String[] goOut = { "GO OUT", "BREAK THE RULES", "SHOULD LEAVE THE HOUSE", "SHOULD LEAVE UR HOUSE" };
        String[] stayHome = { "STAY HOME", "STAY AT HOME", "DONT LEAVE", "DON'T LEAVE", "DO NOT LEAVE", "HAVE TO STAY", "MUST STAY", "RISKY" };
        String[] compliments = { "UR COOL", "YOU'RE COOL", "U R COOL", "U ARE COOL", "UR SWEET", "YOU'RE SWEET", "U R SWEET", "U ARE SWEET", "UR FUNNY", "YOU'RE FUNNY", "U R FUNNY", "U ARE FUNNY", "LIKE TALKING TO U", "LIKE TALKING TO YOU", "LOVE TALKING TO U", "LOVE TALKING TO YOU", "UR GREAT", "YOU'RE GREAT", "U R GREAT", "U ARE GREAT", "UR AMAZING", "YOU'RE AMAZING", "U R AMAZING", "U ARE AMAZING" };
        String[] affection = { " I LIKE YOU", "I LIKE U", "LOVE YOU", "LOVE U", "ILY", "IN LOVE WITH U", "IN LOVE WITH YOU" };
        String[] thanks = { "TY ", "THANK", "MERCI", "GRACIAS", "CHEERS", " TY" };
        String[] laughing = { "LOL", "LMAO", "ROFL", "HAHA", "XD" };
        String[] goodbye = { "LATERZ", "TTYL", "GBYE", "LATERS", "BAI", "CYA", "GOODBAI", "BYE", "CIAO", "GOODBYE", "CYA LATER", "TALK TO U LATER", "TALK TO YOU LATER", "UNTIL NEXT TIME", "C U", "SEE U", "C YA", "SEE YA", "C YOU", "FAREWELL" };

        Random rnd = new Random();
        SoundPlayer sound;
        int buddyNo;
        int relationshipPts;
        int covidPts;
        bool muted;
        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(862, 584);
            sound = new SoundPlayer(Properties.Resources.LockChat_LOOP);
            sound.PlayLooping();

            HideInitialControls();
            InitializeGameVariables();
        }

        private void HideInitialControls()
        {
            Control[] controlsToHide = { listMessage, buddyPFP, userPFP, messageBox, sendButton, 
                                         groupBox1, bioBox, chooseEsther, chooseSonia, 
                                         chooseAimee, chooseMelanie };
            foreach (var control in controlsToHide)
            {
                control.Hide();
            }
        }

        private void InitializeGameVariables()
        {
            buddyNo = 0;
            relationshipPts = 0;
            covidPts = 0;
            muted = false;
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            Size = new Size(548, 584);
            CenterToScreen();

            ToggleUIElements();
            SetUserInfo();
            ResetGamePoints();
            InitializeChat();
        }

        private void ToggleUIElements()
        {
            loginBox.Hide();
            loginButton.Hide();
            groupBox1.Show();
            bioBox.Show();
            chooseEsther.Show();
            chooseSonia.Show();
            chooseAimee.Show();
            chooseMelanie.Show();
        }

        private void SetUserInfo()
        {
            name = string.IsNullOrEmpty(nameBox.Text) ? "Gaster" : nameBox.Text;
            username = string.IsNullOrEmpty(usernameBox.Text) ? "Me" : usernameBox.Text;

            if (userPFP.Image == null)
            {
                userPFP.Image = Properties.Resources.GasterPFP;
            }
        }

        private void ResetGamePoints()
        {
            relationshipPts = 0;
            covidPts = 0;
        }

        private void InitializeChat()
        {
            listMessage.Items.Clear();
            listMessage.Items.Add("Connected");
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageBox.Text))
            {
                MessageBox.Show("Please enter text into the textbox.", "Error");
                return;
            }

            prompt = messageBox.Text.ToUpper();
            AddMessageToList(username, messageBox.Text);
            messageBox.Clear();

            await Task.Delay(rnd.Next(1000, 4000));

            AddMessageToList(buddyUserName, promptResponse(prompt));
        }

        private void AddMessageToList(string sender, string message)
        {
            listMessage.Items.Add($"{sender}:");
            listMessage.Items.Add(message);
            listMessage.Items.Add(string.Empty);
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void listMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void SetBackgroundImage(Image image, Color foreColor)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = image;
            changeForeColor(foreColor);
        }

        private void SetUserProfilePicture(Image image)
        {
            userPFP.Image = image;
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
            SetBackgroundImage(Properties.Resources.RosesBG, Color.White);
        }

        private void cloudsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBackgroundImage(Properties.Resources.SkyBG, Color.Black);
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose Custom Background";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SetBackgroundImage(new Bitmap(dlg.FileName), BackColor);
                }
            }
        }

        private void spaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBackgroundImage(Properties.Resources.SpaceBG, Color.White);
        }

        private void underwaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBackgroundImage(Properties.Resources.UnderwaterBG, Color.White);
        }

        private void meadowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBackgroundImage(Properties.Resources.MeadowBG, Color.Black);
        }

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose Profile Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SetUserProfilePicture(new Bitmap(dlg.FileName));
                }
            }
        }

        private void SetProfilePictureFromResource(string resourceName)
        {
            SetUserProfilePicture((Image)Properties.Resources.ResourceManager.GetObject(resourceName));
        }

        private void bKYUToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("B__KYU");
        private void eUPHORIA6ToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("EUPHORIA_6");
        private void mutationSyndromeToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Mutation_Syndrome");
        private void nITROUSToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("NITROUS");
        private void stargazingToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("stargazing");
        private void uNAToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("UNA");
        private void ashToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Ash");
        private void gokuToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Goku");
        private void kanekiToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Kaneki");
        private void narutoToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Naruto");
        private void nicoToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Nico");
        private void pikachuToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Pikachu");
        private void sailorMoonToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Sailor_Moon");
        private void yunoToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Yuno");
        private void catToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Cat");
        private void clownToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Clown");
        private void dogToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Dog");
        private void eyeToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Eye");
        private void flowerToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Flower");
        private void guitarToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Guitar");
        private void loveHeartToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Love_Heart");
        private void pirateSKullToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Pirate_Skull");
        private void beachToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Beach");
        private void forestToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Forest");
        private void mountainsToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Mountains");
        private void sunsetToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Sunset");
        private void daBabyToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("DaBaby");
        private void dogeToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Doge");
        private void evilPatrickToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Evil_Patrick");
        private void illuminatiToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Illuminati");
        private void mattToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Matt");
        private void obamiumToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Obamium");
        private void rickRollToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Rick_Roll");
        private void sIUUUToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("SIUUU");
        private void spongeMockToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Sponge_Mock");
        private void trollfaceToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Trollface");
        private void whiteDrakeToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("White_Drake");
        private void findingNemoToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Finding_Nemo");
        private void fridayThe13thToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Friday_the_13th");
        private void frozenToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Frozen");
        private void harryPotterToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Harry_Potter");
        private void jurassicParkToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Jurassic_Park");
        private void nightmareOnElmStreetToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Nightmare_on_Elm_Street");
        private void starWarsToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Star_Wars");
        private void terminatorToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Terminator");
        private void theMatrixToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("The_Matrix");
        private void toyStoryToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Toy_Story");
        private void batmanToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Batman");
        private void asexualToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Asexual");
        private void bisexualToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Bisexual");
        private void lesbianToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Lesbian");
        private void nonbinaryToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Non_binary");
        private void pansexualToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Pansexual");
        private void rainbowToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Rainbow");
        private void transgenderToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Transgender");
        private void basketballToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Basketball");
        private void footballToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Football");
        private void tennisToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Tennis");
        private void spidermanToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Spiderman");
        private void supermanToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Superman");
        private void theFlashToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("The_Flash");
        private void carToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Car");
        private void motorcycleToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Motorcycle");
        private void planeToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Plane");
        private void arthurMorganToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Arthur_Morgan");
        private void bigbyToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Bigby");
        private void chloePriceToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Chloe_Price");
        private void clementineToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Clementine");
        private void henryStickminToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Henry_Stickmin");
        private void imposterToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Imposter");
        private void jonesyToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Jonesy");
        private void leeEverettToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Lee_Everett");
        private void plumbobToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Plumbob");
        private void sansToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Sans");
        private void steveToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Steve");
        private void trevorToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Trevor");
        private void zagreusToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("Zagreus");
        private void ChooseBuddy(int index, string pfpResourceName)
        {
            buddyNo = index + 1;
            mainChatShowHideElements();
            buddyName = buddy[index];
            buddyUserName = buddyUser[index];
            buddyPFP.Image = (Image)Properties.Resources.ResourceManager.GetObject(pfpResourceName);
        }

        private void chooseSonia_Click(object sender, EventArgs e) => ChooseBuddy(1, "Sonia_PFP");

        private void chooseEsther_Click(object sender, EventArgs e) => ChooseBuddy(0, "Esther_PFP");

        private void chooseAimee_Click(object sender, EventArgs e) => ChooseBuddy(2, "Aimee_PFP");

        private void chooseMelanie_Click(object sender, EventArgs e) => ChooseBuddy(3, "Melanie_PFP");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void freddyFazbearToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("FreddyFazbear");

        private void chooseEsther_MouseHover(object sender, EventArgs e) => SetBioImage("EstherBio");

        private void chooseSonia_MouseHover(object sender, EventArgs e) => SetBioImage("SoniaBio");

        private void chooseAimee_MouseHover(object sender, EventArgs e) => SetBioImage("AimeeBio");

        private void chooseMelanie_MouseHover(object sender, EventArgs e) => SetBioImage("MelanieBio");

        private void SetBioImage(string resourceName) => bioBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceName);

        private void SetChatColors(Color foreColor, Color backColor, bool changeMessageBox = false)
        {
            listMessage.ForeColor = foreColor;
            listMessage.BackColor = backColor;
            if (changeMessageBox)
            {
                messageBox.ForeColor = Color.White;
                messageBox.BackColor = Color.Black;
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e) => SetChatColors(Color.Red, Color.White);

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e) => SetChatColors(Color.Orange, Color.Black, true);

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e) => SetChatColors(Color.Yellow, Color.Black, true);

        private void greenToolStripMenuItem_Click(object sender, EventArgs e) => SetChatColors(Color.Green, Color.White);

        private void blueToolStripMenuItem_Click(object sender, EventArgs e) => SetChatColors(Color.Blue, Color.White);

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e) => SetChatColors(Color.Pink, Color.Black, true);

        private void blackToolStripMenuItem_Click(object sender, EventArgs e) => SetChatColors(Color.Black, Color.White);

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e) => SetChatColors(Color.White, Color.Black);

        private void colorBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBox_Enter(object sender, EventArgs e)
        {

        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            muted = !muted;
            if (muted)
            {
                sound.Stop();
            }
            else
            {
                sound = new SoundPlayer(Properties.Resources.LockChat_LOOP);
                sound.PlayLooping();
            }
            muteToolStripMenuItem.Text = muted ? "Unmute" : "Mute";
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.Title = "Save Game Data";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine($"Name:{name}");
                    writer.WriteLine($"Username:{username}");
                    writer.WriteLine($"BuddyNo:{buddyNo}");
                    writer.WriteLine($"RelationshipPts:{relationshipPts}");
                    writer.WriteLine($"CovidPts:{covidPts}");
                    writer.WriteLine($"Muted:{muted}");
                    // Add more data as needed
                }
                MessageBox.Show("Game data saved successfully!");
            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.Title = "Load Game Data";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            switch (parts[0])
                            {
                                case "Name":
                                    name = parts[1];
                                    break;
                                case "Username":
                                    username = parts[1];
                                    break;
                                case "BuddyNo":
                                    buddyNo = int.Parse(parts[1]);
                                    break;
                                case "RelationshipPts":
                                    relationshipPts = int.Parse(parts[1]);
                                    break;
                                case "CovidPts":
                                    covidPts = int.Parse(parts[1]);
                                    break;
                                case "Muted":
                                    muted = bool.Parse(parts[1]);
                                    break;
                                // Add more cases as needed
                            }
                        }
                    }
                }
                MessageBox.Show("Game data loaded successfully!");
                // Update UI elements with loaded data
                UpdateUIWithLoadedData();
            }
        }

        private void UpdateUIWithLoadedData()
        {
            // Update UI elements based on loaded data
            // For example:
            nameBox.Text = name;
            usernameBox.Text = username;
            // Update other UI elements as needed
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
            bool[] flags = new bool[10];
            string[] flagTypes = { "Greetings", "Wellbeing", "WYD", "GoOut", "StayHome", "Comp", "Affection", "TY", "LOL", "Bye" };
            string[][] checkArrays = { greetings, wellbeings, wyd, goOut, stayHome, compliments, affection, thanks, laughing, goodbye };

            bool hasPromptBeenMade = promptsMade.Contains(prompt);

            if (!hasPromptBeenMade)
            {
                for (int i = 0; i < flagTypes.Length; i++)
                {
                    flags[i] = checkArrays[i].Any(item => prompt.Contains(item));
                }

                // Special case for "TY"
                if (prompt == "TY")
                {
                    flags[7] = true; // thanked
                }
            }

            Dictionary<string, string[]> responses = new Dictionary<string, string[]>
            {
                {"estherError", new[] {"What xD", "D: " + name + ", you okay?", "Um... ?_?", "Hehe :) I don't understand, but understood!"}},
                {"soniaError", new[] {"LOL WHAT???", "HAHAHAHA WTF R U ON ABOUT", ".", "R U BIEN?", "oki doki ami"}},
                {"aimeeError", new[] {"?", "wtf?", "ok.", "moving on."}},
                {"melanieError", new[] {"Start making sense.", "You tire me.", "Amazing.", "What?"}},
                {"estherRepeat", new[] {"Oh! Didn't we talk about this already ?", "I can see that you're tired, you've said that before, maybe you should rest :(", "Woah, am I in a time loop? I swear you've said that before!", "Uhh… are you confused? This isn't the first time you said this :P", "Hahaha you're repeating yourself xD"}},
                {"soniaRepeat", new[] {"LOL R U HIGH???? youve said that dumb face", "que?? again?? deja vu", prompt.ToLower(), " lol", "ur having a brainfart fjkahkjdsfa or am i? u have said this non?", "are u testing me to see if i pay attention in the conversations, bcz i do!! u have said this lmao", "SAY SOMETHING NEW AAAAAAAAAAAA"}},
                {"aimeeRepeat", new[] {"this again? get better lines npc.", "stop repeating yourself.", "are you stupid? you just said that.", "my response isnt gonna change the more you bring it up.", "riiiiiiight… should i pretend this is the first time you said that?"}},
                {"melanieRepeat", new[] {"Perhaps take a break. You seem to be forgetting what we have already discussed.", "Do watch yourself, I don't like repeating myself unlike you.", "Alright. Lovely conversation. Talk to me again when you have practiced having real conversations.", "Do you need me to call you a paramedic? Repetition is a sign of memory loss, and you seem to be suffering from it.", "You have said this. Did you already forget?"}},
                {"estherGreetings", new[] {"Hey hey " + name + "!", "Heyo!", "Excelsior!", "Yoyo!"}},
                {"soniaGreetings", new[] {"hai", "hey lol", "bonjour!!!!", "HELLO " + name.ToUpper()}},
                {"aimeeGreetings", new[] {"hi " + name.ToLower() + ".", "hm.", "what", "can i help u?"}},
                {"melanieGreetings", new[] {"Greetings, " + name + ".", "Oh. It's you.", "Yes?"}},
                {"estherWellbeing", new[] {"I'm doing great!! Thank you for asking " + name + ".", "Everything is good, today has been nice! :D", "So and so, it's not so bad I guess...", ":( Feeling a tiny bit sad but it will pass… ", "Just stressing about lockdown :P You?"}},
                {"soniaWellbeing", new[] {"BIEN... kinda just stuck indoors lol", "nooooo awfullllll im bored and i wanna go outsideeee aaaaaaaa", "meh could be better but it could be VERY BAD TOO SO ITS OKAY LOL IM JUST LOWKEY FREAKING OUT"}},
                {"aimeeWellbeing", new[] {"breathing.", "bad.", "i don't know. does it matter?", "okay. you?", "wow boring question. i'm fine.", "bored.", "it's whatever.", "locking down."}},
                {"melanieWellbeing", new[] {"Had a good day, no one pissed me off today. Don't change that.", "Stressed, but when am I not? That was rhetoric, by the way.", "In this environment that's the type of question that you get fired for. So refrain from asking stupid questions like that ever again.", "Oh. How nice. You care. I'm managing.", "Annoyed so please don't test that."}},
                {"estherWYD", new[] {"It is a lovely day, the sun would feel great! Maybe I should take a walk :P", "Just getting ready to get to the comic book store... The new chapter of UNA comics just came out!!!"}},
                {"soniaWYD", new[] {"ABSOLUTELY NOTHING I RLLY WANNA GO OUT but i could get in trouble 😭😭😭😭😭😭", "literally NOTHING " + name.ToUpper() + "!!! i need to leave the house ASAP.", "I WISH I WAS DOING SMTH MORE INTERESTING TO TELL U BUT..... nothing :O i wanna do something tho", "DYING I CANT BE CRAMPED IN HERE FOR ANY LONGER " + name.ToUpper() + " PLS SEND HELP"}},
                {"aimeeWYD", new[] {"rotting.", "nothing as always.", "staring into the endless void", "surprisingly looking outside and kinda wanting to escape this cage."}},
                {"melanieWYD", new[] {"Currently busy with work.", "Responding to e-mails at the moment. Somehow they are more taxing than conversing with you.", "Just gave myself a break because I can. Might go for a well-deserved Melanie Promenade."}},
                {"estherGoOut", new[] {"Yay! Glad you agree " + name + ".", "Let's go!!!! About time hehe", "Heck yeah! I will do just that :)"}},
                {"soniaGoOut", new[] {"MAYBE I WILL.", "very good idea :) i just need to be sneaky beaky >.>", "YESSIRRRRRRR GREAT IDEA"}},
                {"aimeeGoOut", new[] {"sure, but only when it gets darker...", "you're one to talk, but i guess i should", "ill do it but only because i want to.", "yea nah nevermind", "actually cant be bothered tbf"}},
                {"melanieGoOut", new[] {"I am far too busy today to 'go out', but I'll keep your unsolicited advice in mind.", "You're right, I've been stuck in the office for too long. I need some air.", "God yes, I need a drink too."}},
                {"estherStayHome", new[] {"Okie... I should be more responsible, you're right!", "Awh :("}},
                {"soniaStayHome", new[] {"AAAAAA BUT I NEED TO ESCAPE THIS NETHER HOLE", "I KNOW I SHOULD STAY BUT ITS KILLING MEEEE", "it's worth the risk at this point " + name.ToLower() + "😭", "OKAY FINE ILL STAY PFFT", "YEAH? yeah. ye.... u rite"}},
                {"aimeeStayHome", new[] {"you don't tell me what to do.", "ugh. fine.", "my eyes cannot roll further back into my skull"}},
                {"melanieStayHome", new[] {"Ah yes. It is clear now that I have way too much work to focus on.", "On second thought, I'd have to confer with my assistant, so I'd rather not leave the house.", "I have a meeting soon, so perhaps I shouldn't waste time."}},
                {"estherComp", new[] {"Eek! That's so nice, thank you " + name + "!!! :D", "Oh my- That means so much thank you!", "D'awh... That is so sweet thank you so much :P", "Ah! So unexpected but much appreciated, likewise!"}},
                {"soniaComp", new[] {"OMG " + name.ToUpper() + "THATS SO NICE THANK U AND LIKEWISE :)", "AKLSJDLKSAJJDFU TY U TOOOOOO", "thats so sweet 🤧🤧 thank u i feel the same", "MON DIEU MERCI BEAUCOUP <3 you too", "wtf where did this come from????? im flattered ty " + name.ToLower() + "!!!!"}},
                {"soniaAffection", new[] {"KAFNOEISHIOFEJFEWSOUGB I THINK I FEEL THE SAME <.<", "omg really what what what i do too wtf this isnt happening", "OMG ME TOO AAAAAAAAA :)))))"} },
                {"soniaNoAffection", new[] {"AAAA IM SO SORRY BUT ITS WAY TOO SOON FOR THAT LMAOOO PLEASE", "WTFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF " + name.ToUpper() + "its too early to catch feelings :((("} },
                {"estherTY", new[] {"Happy to help :)", "No worries!", "You're very welcome!"}},
                {"soniaTY", new[] {"no problemo ;)", "NP!!!!", "I GOCHU " + name.ToUpper(), "anytime famalam", "ur very very very very very welcome", "it is mon pleasure hehe"}},
                {"aimeeTY", new[] {"ok. no prob", "whatever.", "you owe me"}},
                {"estherLOL", new[] {"Hehe D", ":P", "XD", "Glad I could make you laugh xD"}},
                {"soniaLOL", new[] {"HA I MADE U LAUGH", ":)", ":D", "HAHAHAHAHA", "LMAO"}},
                {"aimeeLOL", new[] {"wasnt that funny.", "hilarious.", "lol.", "haha.", "shut up."}},
                {"melanieLOL", new[] {"Glad I could amuse you.", "How humourous.", "Yeah."}},
                {"estherBye", new[] {"Okie, take care " + name + "!", "See you on the other side!", "Smell ya later!", "Later gator!"}},
                {"soniaBye", new[] {"OKOKOKKO BAI", "BYEBYEBYEYBEYBYEYBEYBE", "kbye lmao", "AU REVOIR " + name.ToUpper()}},
                {"aimeeBye", new[] {"bye ig.", "see u in hell.", "cya never.", "bye.", "ok bye."}},
                {"melanieBye", new[] {"Farewell, " + name + ".", "Until next meeting.", "Cheers.", "Goodbye. Signed, Melanie"}}
            };

            string response = "";
            if (hasPromptBeenMade)
            {
                response = responses[buddyName.ToLower() + "Repeat"][rnd.Next(responses[buddyName.ToLower() + "Repeat"].Length)];
            }
            else
            {
                for (int i = 0; i < flagTypes.Length; i++)
                {
                    if (flags[i])
                    {
                        string responseKey = buddyName.ToLower() + flagTypes[i];
                        if (responses.ContainsKey(responseKey))
                        {
                            response = responses[responseKey][rnd.Next(responses[responseKey].Length)];
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(response))
                {
                    response = responses[buddyName.ToLower() + "Error"][rnd.Next(responses[buddyName.ToLower() + "Error"].Length)];
                }

                if (flags[3] || flags[4]) // goOutCheck or stayHomeCheck
                {
                    covidPts += flags[3] ? 1 : -1;
                }
                if (flags[5]) // complimented
                {
                    relationshipPts++;
                }
            }

            promptsMade += prompt + "|";
            Console.WriteLine(promptsMade);
            return response;
        }
        public void changeForeColor(Color color)
        {
            Control[] controlsToChange = { nameLbl, usernameLbl, loginBox };
            foreach (var control in controlsToChange)
            {
                control.ForeColor = color;
            }
        }

        public void mainChatShowHideElements()
        {
            Control[] controlsToHide = { groupBox1, bioBox, chooseEsther, chooseSonia, chooseAimee, chooseMelanie };
            Control[] controlsToShow = { listMessage, userPFP, buddyPFP, messageBox, sendButton };

            foreach (var control in controlsToHide)
            {
                control.Hide();
            }

            foreach (var control in controlsToShow)
            {
                control.Show();
            }

            Size = new Size(862, 584);
            CenterToScreen();
        }
    }
}
