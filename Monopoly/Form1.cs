using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class Monopoly : Form
    {
        Point p = new Point();
        List<Player> Players = new List<Player>(4);
        int NumberofPlayers;
        int Temp = 1;
        public Monopoly()
        {
            InitializeComponent();
        }

        private void NumberOfPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumberofPlayers = int.Parse(NumberOfPlayers.Text);
            Next_btn.Enabled = true;
        }

        private void Next_btn_Click(object sender, EventArgs e)
        {
            PlayerReg_Panel.Show();
            NumberofplayerPanel.Hide();
            Token_TXT.Text = Temp.ToString();
        }

        private void Playername_TXT_TextChanged(object sender, EventArgs e)
        {
            Add_BTN.Enabled = true;
        }

        private void Add_BTN_Click(object sender, EventArgs e)
        {
            Playername_TXT.Text = "";
            NumberofPlayers--;
            if (NumberofPlayers == 0)
            {
                Next_BTN2.Enabled = true;
                Add_BTN.Enabled = false;
                Token_TXT.Text = "";
                Playername_TXT.Enabled = false;
                return;
            }
            Player newplayer = new Player();
            newplayer.Set_Name(Playername_TXT.Text);
            newplayer.Set_Token(Temp);
            Players.Add(newplayer);
            Temp++;
            Token_TXT.Text = Temp.ToString();
            Add_BTN.Enabled = false;
            
        }

        private void Next_BTN2_Click(object sender, EventArgs e)
        {
            GamePanel.Show();
            Registeration.Hide();
        }
        private void tmr1_Tick(object sender, EventArgs e)
        {
            if (Player1.Location.X < 30&& Player1.Location.Y>30)
            {
                p = Player1.Location;
                p.Y -= 5;
                Player1.Location = p;
            }
            else if(Player1.Location.Y<30 && Player1.Location.X<680)
            {
                p = Player1.Location;
                p.X += 5;
                Player1.Location = p;
            }
            else if (Player1.Location.X > 680)
            {
                p = Player1.Location;
                p.Y += 5;
                Player1.Location = p;
            }
            else if(Player1.Location.Y>570)
            {
                p = Player1.Location;
                p.X -= 5;
                Player1.Location = p;
            }
            else
            {
                p = Player1.Location;
                p.Y += 5;
                Player1.Location = p;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Player2.Location.X < 30 && Player2.Location.Y > 30)
            {
                p = Player2.Location;
                p.Y -= 5;
                Player2.Location = p;
            }
            else if (Player2.Location.Y < 30 && Player2.Location.X < 680)
            {
                p = Player2.Location;
                p.X += 5;
                Player2.Location = p;
            }
            else if (Player2.Location.X > 680)
            {
                p = Player2.Location;
                p.Y += 5;
                Player2.Location = p;
            }
            else if (Player2.Location.Y > 570)
            {
                p = Player2.Location;
                p.X -= 5;
                Player2.Location = p;
            }
            else
            {
                p = Player2.Location;
                p.Y += 5;
                Player2.Location = p;
            }
        }
    }
}
