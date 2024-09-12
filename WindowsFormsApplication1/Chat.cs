using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;
using WindowsFormsApplication1;


namespace WindowsFormsApplication1
{
    public partial class Chat : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string API_KEY = "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";

        private string currentCharacter;
        private string userName;
        private string username;
        private Image userPfp = Properties.Resources.GasterPFP;

        private Dictionary<string, (string systemMessage, Image pfp)> characters;
        private Dictionary<string, string> characterUsernames = new Dictionary<string, string>
        {
            {"Esther", "Angel616"},
            {"Sonia", "xXx_Sony_xXx"},
            {"Aimee", "aimaggot666"},
            {"Melanie", "MelanieS"}
        };

        private List<object> conversationHistory = new List<object>();
        private NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer typingAnimationTimer;
        private int typingAnimationDots = 0;

        public Chat(string name, string username, string characterName = "Sonia")
        {
            InitializeComponent();
            this.userName = name;
            this.username = username;
            this.currentCharacter = characterName;
            InitializeCharacters();
            SetUserInfo();
            ChooseBuddy(characterName);
            InitializeNotifyIcon();
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon()
            {
                Text = "LockChat",
                Visible = true
            };
            notifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Activate();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeChat();
        }

        private void SetUserInfo()
        {
            buddyPFP.Image = characters[currentCharacter].pfp;
            
            if (userPFP.Image == null)
            {
                userPFP.Image = Properties.Resources.GasterPFP;
            }
            
            UpdateCharacterDescriptions();
        }

        private async void NotifyProfilePictureChange(string pictureName)
        {
            string systemMessage = $"[{userName} has changed their Icon to {pictureName}]";
            AddMessageToList("System", systemMessage);

            string aiResponse = await GetGroqResponse($"The user has changed their profile picture to {pictureName}. Comment on this change briefly.");
            await Task.Delay(new Random().Next(1000, 4001));
            
            int typingDelay = CalculateTypingDelay(aiResponse);
            int typingIndicatorIndex = listMessage.Items.Add($"{characterUsernames[currentCharacter]} is typing...");

            typingAnimationTimer = new System.Windows.Forms.Timer();
            typingAnimationTimer.Interval = 500;
            typingAnimationTimer.Tick += (s, ev) => UpdateTypingAnimation(typingIndicatorIndex);
            typingAnimationTimer.Start();

            await Task.Delay(typingDelay);

            typingAnimationTimer.Stop();
            typingAnimationTimer.Dispose();

            listMessage.Items.RemoveAt(typingIndicatorIndex);
            AddMessageToList(characterUsernames[currentCharacter], aiResponse);
        }

        private void UpdateCharacterDescriptions()
        {
            foreach (var character in characters.Keys.ToList())
            {
                var (systemMessage, pfp) = characters[character];
                systemMessage = systemMessage.Replace("The user you're talking to is named User", $"The user you're talking to is named {userName}");
                characters[character] = (systemMessage, pfp);
            }
        }

        private void InitializeChat()
        {
            listMessage.Items.Clear();
            listMessage.Items.Add("Connected");
        }

        private string[] WrapText(string message, int maxLineLength)
        {
            var words = message.Split(' ');
            var lines = new List<string>();
            var currentLine = new StringBuilder();

            foreach (var word in words)
            {
                if (currentLine.Length + word.Length + 1 > maxLineLength)
                {
                    lines.Add(currentLine.ToString());
                    currentLine.Clear();
                }
                currentLine.Append(word + " ");
            }
            if (currentLine.Length > 0)
            {
                lines.Add(currentLine.ToString());
            }
            return lines.ToArray();
        }

        private void AddMessageToList(string sender, string message)
        {
            listMessage.Items.Add($"{sender}:");
            string[] wrappedMessage = WrapText(message, 70);
            foreach (string line in wrappedMessage)
            {
                listMessage.Items.Add(line);
            }
            listMessage.Items.Add(string.Empty);

            listMessage.TopIndex = listMessage.Items.Count - 1;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageBox.Text))
            {
                MessageBox.Show("Please enter text into the textbox.", "Error");
                return;
            }

            string userMessage = messageBox.Text;
            AddMessageToList(username, userMessage);
            conversationHistory.Add(new { role = "user", content = userMessage });
            messageBox.Clear();

            listMessage.TopIndex = listMessage.Items.Count - 1;

            try
            {
                string response = await GetGroqResponse(userMessage);
                int typingDelay = CalculateTypingDelay(response);
                
                int typingIndicatorIndex = listMessage.Items.Add($"{characterUsernames[currentCharacter]} is typing...");
                
                typingAnimationTimer = new System.Windows.Forms.Timer();
                typingAnimationTimer.Interval = 500;
                typingAnimationTimer.Tick += (s, ev) => UpdateTypingAnimation(typingIndicatorIndex);
                typingAnimationTimer.Start();
                
                await Task.Delay(typingDelay);
                
                typingAnimationTimer.Stop();
                typingAnimationTimer.Dispose();
                
                listMessage.Items.RemoveAt(typingIndicatorIndex);
                
                AddMessageToList(characterUsernames[currentCharacter], response);
                conversationHistory.Add(new { role = "assistant", content = response });

                if (!this.ContainsFocus)
                {
                    ShowWindowsNotification(characterUsernames[currentCharacter], response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        private void UpdateTypingAnimation(int typingIndicatorIndex)
        {
            typingAnimationDots = (typingAnimationDots + 1) % 4;
            string dots = new string('.', typingAnimationDots);
            listMessage.Items[typingIndicatorIndex] = $"{characterUsernames[currentCharacter]} is typing{dots.PadRight(3)}";
        }

        private void ShowWindowsNotification(string sender, string message)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                characters[currentCharacter].pfp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                using (Bitmap bmp = new Bitmap(ms))
                {
                    notifyIcon.Icon = Icon.FromHandle(bmp.GetHicon());
                }
            }

            notifyIcon.BalloonTipTitle = sender;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(3000);
        }

        private int CalculateTypingDelay(string message)
        {
            int wordsPerMinute = 110;
            int wordCount = message.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int delayInSeconds = (int)Math.Ceiling((double)wordCount / wordsPerMinute * 60);
            
            Random random = new Random();
            int randomFactor = random.Next(-20, 21);
            delayInSeconds = (int)(delayInSeconds * (1 + randomFactor / 100.0));
            
            return Math.Max(1000, Math.Min(5000, delayInSeconds * 1000));
        }

        private async Task<string> GetGroqResponse(string userMessage)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", API_KEY);
            
            var systemMessage = characters.ContainsKey(currentCharacter) ? characters[currentCharacter].systemMessage : "";
            var messages = new List<object>
            {
                new { role = "system", content = systemMessage },
                new { role = "system", content = "Keep your responses brief, ideally 1-3 sentences, as you're talking to the user on a chat app. It's currently 2019, and COVID-19 has just started. We're in the early months of lockdown. The app you're talking on is called LockChat, specifically made for people to chat during the pandemic. Only speak a lot when appropriate. Stay in character." }
            };

            messages.AddRange(conversationHistory);
            messages.Add(new { role = "user", content = userMessage });

            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                messages,
                model = "llama3-8b-8192",
                max_tokens = 1000
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
            
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseBody);
            return result.choices[0].message.content;
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
        }

        private void SetUserProfilePicture(Image image, string pictureName)
        {
            userPFP.Image = image;
            NotifyProfilePictureChange(pictureName);
        }

        private void SetProfilePictureFromResource(string resourceName)
        {
            SetUserProfilePicture((Image)Properties.Resources.ResourceManager.GetObject(resourceName), resourceName);
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
                    string fileName = Path.GetFileNameWithoutExtension(dlg.FileName);
                    SetUserProfilePicture(new Bitmap(dlg.FileName), fileName);
                }
            }
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
        private void sIUUUUToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("SIUUU");
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

        private void ChooseBuddy(string characterName)
        {
            currentCharacter = characterName;
            buddyPFP.Image = characters[characterName].pfp;
            listMessage.Items.Clear();
            listMessage.Items.Add("Connected");
            conversationHistory.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void freddyFazbearToolStripMenuItem_Click(object sender, EventArgs e) => SetProfilePictureFromResource("FreddyFazbear");

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

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void friendsButton_Click(object sender, EventArgs e)
        {
            Friends friendsForm = new Friends(userName, username);
            friendsForm.Show();
            this.Hide();
        }

        private void HideChatElements()
        {
            listMessage.Hide();
            userPFP.Hide();
            buddyPFP.Hide();
            messageBox.Hide();
            sendButton.Hide();
            friendsButton.Hide();
        }

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click((object)sender, (EventArgs)e);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            notifyIcon.Dispose(); // Dispose of the notifyIcon
            base.OnFormClosing(e);
            Application.Exit();
        }

    }
}
