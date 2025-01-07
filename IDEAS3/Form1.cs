using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

// Game protocol definitions
public enum GameMove { Rock, Paper, Scissors }

public class GameMessage
{
    public string Type { get; set; }
    public string Content { get; set; }
    public GameMove? PlayerMove { get; set; }
    public int? Score { get; set; }
}

public class GameClient : Form
{
    // Networking
    private TcpClient client;
    private NetworkStream stream;
    private StreamReader reader;
    private StreamWriter writer;
    private string playerName;

    // UI Controls
    private Label titleLabel;
    private Label connectionLabel;
    private Label timerLabel;
    private Button rockButton;
    private Button paperButton;
    private Button scissorsButton;
    private Label resultLabel;
    private Label scoreLabel;
    private Label leaderboardLabel;
    private Panel gamePanel;

    public GameClient()
    {
        ShowLoginScreen();
    }

    private void ShowLoginScreen()
    {
        var loginForm = new Form
        {
            Text = "Enter Your Name",
            Size = new Size(300, 150),
            StartPosition = FormStartPosition.CenterScreen
        };

        var nameBox = new TextBox
        {
            PlaceholderText = "Enter your name",
            Width = 200,
            Top = 20,
            Left = 40
        };

        var connectButton = new Button
        {
            Text = "Connect",
            Top = 60,
            Left = 100
        };

        connectButton.Click += async (sender, e) =>
        {
            playerName = nameBox.Text;
            loginForm.Close();


        };

        loginForm.Controls.Add(nameBox);
        loginForm.Controls.Add(connectButton);
        loginForm.ShowDialog();
    }
}