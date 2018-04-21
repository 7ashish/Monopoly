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
        Monopoly_Master Main=new Monopoly_Master();
        Point p = new Point();
        List<Player> Players = new List<Player>(4);
        int NumberofPlayers;
        int Temp = 1;
        Player playerturn= new Player();
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
            Game.Show();
            Registeration.Hide();
            Player1_Timer.Start();
            Player2_Timre.Start();
        }
        private void Player1_Timer_Tick(object sender, EventArgs e)
        {
            if (Player1.Location.X == 310)
            {
                Player1_Timer.Stop();
            }
            /*if(Player1.Location==Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2()) % 21].Get_FieldPosition())
          {
              Player1_Timer.Stop();
          }*/
            if (Player1.Location.X < 80 && Player1.Location.Y > 80)
            {
                p = Player1.Location;
                p.Y -= 1;
                Player1.Location = p;
            }
            else if (Player1.Location.Y <= 80 && Player1.Location.X <= 850)
            {
                p = Player1.Location;
                p.X += 1;
                Player1.Location = p;
            }
            else if (Player1.Location.X > 850 && Player1.Location.Y <= 530)
            {
                p = Player1.Location;
                p.Y += 1;
                Player1.Location = p;
            }
            else
            {
                p = Player1.Location;
                p.X -= 1;
                Player1.Location = p;
            }
            /*Panel[] players = { Player1, Player2, Player3, Player4 };
            for (int i = 0; i < 4; i++)
            {
                //Get The direction towards which we should move
                Point direction = new Point()
                {
                    //ab = b - a (old vector rule)
                    X = Players[i].Get_PlayerPosition().X - players[i].Location.X,
                    Y = Players[i].Get_PlayerPosition().Y - players[i].Location.Y
                };
                //Normalizing value of X and Y by dividing them over their maginitude
                direction.X = (int)(direction.X / Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y));
                direction.Y = (int)(direction.Y / Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y));
                players[i].Location.Offset(direction);
            }*/
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Player2.Location.X < 80 && Player2.Location.Y > 80)
            {
                p = Player2.Location;
                p.Y -= 1;
                Player2.Location = p;
            }
            else if (Player2.Location.Y <= 80 && Player2.Location.X <= 850)
            {
                p = Player2.Location;
                p.X += 1;
                Player2.Location = p;
            }
            else if (Player2.Location.X > 850 && Player2.Location.Y <= 530)
            {
                p = Player2.Location;
                p.Y += 1;
                Player2.Location = p;
            }
            else
            {
                p = Player2.Location;
                p.X -= 1;
                Player2.Location = p;
            }
        }

        private void GoToJail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void Test_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void Player3_Timer_Tick(object sender, EventArgs e)
        {
            if (Player3.Location.X < 80 && Player3.Location.Y > 80)
            {
                p = Player3.Location;
                p.Y -= 1;
                Player3.Location = p;
            }
            else if (Player3.Location.Y <= 80 && Player3.Location.X <= 850)
            {
                p = Player3.Location;
                p.X += 1;
                Player3.Location = p;
            }
            else if (Player3.Location.X > 850 && Player3.Location.Y <= 530)
            {
                p = Player3.Location;
                p.Y += 1;
                Player3.Location = p;
            }
            else
            {
                p = Player3.Location;
                p.X -= 1;
                Player3.Location = p;
            }
        }

        private void Player4_Timer_Tick(object sender, EventArgs e)
        {
            if (Player4.Location.X < 80 && Player4.Location.Y > 80)
            {
                p = Player4.Location;
                p.Y -= 1;
                Player4.Location = p;
            }
            else if (Player4.Location.Y <= 80 && Player4.Location.X <= 850)
            {
                p = Player4.Location;
                p.X += 1;
                Player4.Location = p;
            }
            else if (Player4.Location.X > 850 && Player4.Location.Y <= 530)
            {
                p = Player4.Location;
                p.Y += 1;
                Player4.Location = p;
            }
            else
            {
                p = Player4.Location;
                p.X -= 1;
                Player4.Location = p;
            }
        }

        private void RollDice_Click(object sender, EventArgs e)
        {
            Main.Set_Dice1(Main.RollDice());
            Main.Set_Dice2(Main.RollDice());
            //Main.Move_Player(playerturn, Main.Get_Dice1() + Main.Get_Dice2());
            Player1_Timer.Start();
        }
    }
}
