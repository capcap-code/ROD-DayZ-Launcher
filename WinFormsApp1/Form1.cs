using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Media;
using System.Net.Http;

namespace WinFormsApp1
{
    public partial class Luncher : Form
    {
        private const string VersionUrl = "https://drive.google.com/uc?export=download&id=121vj_pQQ3bE2zYtbh8-BN4pZXmo9L3hH";
        private const string UpdatePackageUrl = "https://drive.google.com/uc?export=download&id=1AtIkk2c5OFFQwkbjTKugQY9dW5K0Ox6H&confirm=t&uuid=e14a4669-ba65-4e8b-99c2-252322dd454a&at=AB6BwCC3YzqIS0FHOl807yxYYQVt:1697156533522";
        private const string WhitelistUrl = "https://drive.google.com/uc?export=download&id=1RE35drxXM0kS-xZuwkerkMgkHxlD7jDt";
        private readonly string gameFolderPath;
        private readonly string localVersionFilePath;
        private readonly string appDirectory;
        private const string BatchFilePath = "play.bat";
        private string X = "Ten whitelist";
        private bool isDefault = true;

        public Luncher()
        {
            InitializeComponent();
            appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            gameFolderPath = Path.Combine(appDirectory, "..\\DayZ ROD");
            localVersionFilePath = Path.Combine(appDirectory, "..\\DayZ ROD\\version.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string batchFilePath = Path.Combine(appDirectory, BatchFilePath);
            string batchFileContents = File.ReadAllText(batchFilePath);
            string currentCharacterName = ParseCharacterName(batchFileContents);
            txt_username.Text = currentCharacterName;
            progressBar1.Hide();
            if (X != currentCharacterName)
            {
                nameBtn.Visible = false;
            }
            else
            {
                nameBtn.Visible = true;
            }
            string currentVersion = File.Exists(localVersionFilePath) ? File.ReadAllText(localVersionFilePath) : "N/A";
            versionLabel.Text = "Version: " + currentVersion;

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            int centerX = (screenWidth - formWidth) / 2;
            int centerY = (screenHeight - formHeight) / 2;
            this.Location = new Point(centerX, centerY);
            SoundPlayer bgmusic = new SoundPlayer("bgmusic.wav");
            bgmusic.Play();
        }

        private void registBtn_Click(object sender, EventArgs e)
        {
            if (isDefault)
            {
                string newCharacterName = this.txt_username.Text;
                DialogResult result = MessageBox.Show("Bạn chỉ có thể đặt tên một lần, liên hệ ADMIN nếu muốn đổi tên khác", "Xác nhận", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    ChangeCharacterName(newCharacterName);

                    MessageBox.Show("Xin chào " + newCharacterName + " ! Chơi game vui vẻ <3");
                    isDefault = false;
                    nameBtn.Visible = false;
                }
            }
        }

        private void ChangeCharacterName(string newCharacterName)
        {
            string batchFilePath = Path.Combine(appDirectory, BatchFilePath);
            string batchFileContents = File.ReadAllText(batchFilePath);
            string updatedBatchFileContents = ReplaceCharacterName(batchFileContents, newCharacterName);
            File.WriteAllText(batchFilePath, updatedBatchFileContents);
            X = newCharacterName;
        }

        private void CloseLauncher()
        {
            this.Close();
        }

        private async Task<int> CheckWhitelistAsync(string characterName)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(WhitelistUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string whitelistContent = await response.Content.ReadAsStringAsync();
                        string[] whitelist = whitelistContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        bool isCharacterInWhitelist = Array.Exists(whitelist, line => line.Trim().Equals(characterName, StringComparison.OrdinalIgnoreCase));
                        return isCharacterInWhitelist ? 1 : 0;
                    }
                    else
                    {
                        MessageBox.Show("Failed to download the whitelist file.");
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking whitelist: " + ex.Message);
                return 0;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string batchFilePath = Path.Combine(appDirectory, BatchFilePath);
            ProcessStartInfo info = new ProcessStartInfo(batchFilePath);
            info.UseShellExecute = false;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            string characterName = txt_username.Text;
            int result = await CheckWhitelistAsync(characterName);

            if (nameBtn.Visible == true)
            {
                MessageBox.Show("Bạn chưa đặt tên!");
            }
            else if ((result == 1) && (nameBtn.Visible == false))
            {
                Process.Start(info);
                CloseLauncher();
            }
            else
            {
                MessageBox.Show("Tên nhân vật chưa được whitelist, vui lòng make ticket với Admin!");
            }
        }

        private string ParseCharacterName(string batchFileContents)
        {
            int startIndex = batchFileContents.IndexOf("-name=") + 6;
            int endIndex = batchFileContents.IndexOf("\"", startIndex);
            if (startIndex >= 0 && endIndex >= 0)
            {
                return batchFileContents.Substring(startIndex, endIndex - startIndex);
            }
            return "";
        }

        private string ReplaceCharacterName(string batchFileContents, string newCharacterName)
        {
            int startIndex = batchFileContents.IndexOf("-name=") + 6;
            int endIndex = batchFileContents.IndexOf("\"", startIndex);
            if (startIndex >= 0 && endIndex >= 0)
            {
                return batchFileContents.Substring(0, startIndex) + newCharacterName + batchFileContents.Substring(endIndex);
            }
            return batchFileContents;
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            PlayBtn.Enabled = false;
            updateButton.Enabled = false;

            // Set the ProgressBar to the marquee style
            progressBar1.Style = ProgressBarStyle.Marquee;

            try
            {
                using var httpClient = new HttpClient();
                httpClient.Timeout = Timeout.InfiniteTimeSpan;
                {
                    string newVersion = await httpClient.GetStringAsync(VersionUrl);
                    string newVersionFilePath = Path.Combine(gameFolderPath, "newVersion.txt");
                    string currentVersion = File.Exists(localVersionFilePath) ? File.ReadAllText(localVersionFilePath) : "N/A";

                    if (newVersion.Trim() != currentVersion.Trim())
                    {
                        progressBar1.Visible = true;
                        MessageBox.Show("Có update mới, tiến hành cài đặt, vui lòng đợi......");


                        byte[] updateData = await httpClient.GetByteArrayAsync(UpdatePackageUrl);

                        File.WriteAllBytes("update.zip", updateData);
                        ZipFile.ExtractToDirectory("update.zip", gameFolderPath, true);
                        File.Delete("update.zip");


                        File.WriteAllText(localVersionFilePath, newVersion.Trim());
                        MessageBox.Show("Cập nhật thành công. Phiên bản mới: " + newVersion.Trim());

                        versionLabel.Text = "Version: " + newVersion;

                        File.WriteAllText(newVersionFilePath, newVersion.Trim());
                        File.Delete(newVersionFilePath);
                    }
                    else
                    {
                        MessageBox.Show("Đây là phiên bản mới nhất!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại: " + ex.Message);
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Value = 0;

                PlayBtn.Enabled = true;
                updateButton.Enabled = true;
            }
        }



        private void mutebtn_Click(object sender, EventArgs e)
        {
            bool isPlaying = true;
            SoundPlayer bgmusic = new SoundPlayer("bgmusic.wav");
            bgmusic.Play();
            if (isPlaying)
            {
                bgmusic.Stop();
                isPlaying = false;
            }
            else
            {
                bgmusic.Play();
                isPlaying = true;
            }
        }
    }
}