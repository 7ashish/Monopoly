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
        Monopoly_Master Main = new Monopoly_Master();
        Point p = new Point();
        List<Player> Players = new List<Player>(4);
        int NumberofPlayers;
        int Token = 0;
        int playerturnnumber = 0;
        Player playerturn = new Player();
        Point DefaultPosition = new Point(850, 530);
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
            Token++;
            Token_TXT.Text = Token.ToString();
            Token--;
            Player1.Hide();
            Player2.Hide();
            Player3.Hide();
            Player4.Hide();
            ParkLane_House.Hide(); ParkLane_Hotel.Hide();
            MayFair_House.Hide(); MayFair_Hotel.Hide();
            FleetStreet_House.Hide(); FleetST_Hotel.Hide();
            Strand_House.Hide(); Strand_Hotel.Hide();
            WhiteHall_House.Hide(); WhiteHall_Hotel.Hide();
            PallMall_House.Hide(); PallMall_Hotel.Hide();
            Whitechapel_House.Hide(); Whitechapel_Hotel.Hide();
            OldKent_House.Hide(); OldKent_Hotel.Hide();
            LeicesterSq_House.Hide(); Leicester_Hotel.Hide();
            Coventry_House.Hide(); Coventry_Hotel.Hide();
            Oxford_House.Hide(); Oxford_Hotel.Hide();
            Regent_House.Hide(); Regent_Hotel.Hide();
            Vine_House.Hide(); VineST_Hotel.Hide();
            Bow_House.Hide(); BowST_Hotel.Hide();
            Euston_House.Hide(); Euston_Hotel.Hide();
            Pentonville_House.Hide(); Pentonville_Hotel.Hide();
            Upgradee.Hide();
        }

        private void Playername_TXT_TextChanged(object sender, EventArgs e)
        {
            Add_BTN.Enabled = true;
        }

        private void Add_BTN_Click(object sender, EventArgs e)
        {
            Token++;
            NumberofPlayers--;
            if (NumberofPlayers == 0)
            {
                Next_BTN2.Enabled = true;
                Add_BTN.Enabled = false;
                Token_TXT.Text = "";
                Playername_TXT.Enabled = false;
            }
            else
            {
                Token++;
                Token_TXT.Text = Token.ToString();
                Token--;
            }
            Player newplayer = new Player(Playername_TXT.Text,Token,2000, DefaultPosition,0);
            Players.Add(newplayer);
            switch (Token)
            {
                case 1:
                    Player1.Show();
                    break;
                case 2:
                    Player2.Show();
                    break;
                case 3:
                    Player3.Show();
                    break;
                case 4:
                    Player4.Show();
                    break;
            };
            Playername_TXT.Text = "";
            Add_BTN.Enabled = false;
        }

        private void Next_BTN2_Click(object sender, EventArgs e)
        {
            Game.Show();
            Registeration.Hide();
            playerturn = Players[playerturnnumber];
        }
        private void Player1_Timer_Tick(object sender, EventArgs e)
        {
            if (Math.Sqrt(Math.Pow(Math.Abs(Player1.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() +playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player1.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player1.Location);
                Player1_Timer.Stop();
            }
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
        private void Player2_Timer_Tick(object sender, EventArgs e)
        {
            if (Math.Sqrt(Math.Pow(Math.Abs(Player2.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                   Math.Pow(Math.Abs(Player2.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player2.Location);
                Player2_Timre.Stop();
            }
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
        private void Player3_Timer_Tick(object sender, EventArgs e)
        {
            if (Math.Sqrt(Math.Pow(Math.Abs(Player3.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player3.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player3.Location);
                Player3_Timer.Stop();
            }
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
            if (Math.Sqrt(Math.Pow(Math.Abs(Player4.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player4.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player4.Location);
                Player4_Timer.Stop();
            }
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

        private void RollDice_Click(object sender, EventArgs e)
        {
            RollDice.Enabled = false;
            Main.Set_Dice1(Main.RollDice());
            Main.Set_Dice2(Main.RollDice());
            Dice1TXT.Text = Main.Get_Dice1().ToString();
            Dice2TXT.Text = Main.Get_Dice2().ToString();
            switch (playerturn.Get_Token())
            {
                case 1:
                    Player1_Timer.Start();
                    break;
                case 2:
                    Player2_Timre.Start();
                    break;
                case 3:
                    Player3_Timer.Start();
                    break;
                case 4:
                    Player4_Timer.Start();
                    break;
            };
        }

        private void FinishTurn_Click(object sender, EventArgs e)
        {
            RollDice.Enabled = true;
            playerturnnumber = (playerturnnumber + 1) % Token;
            playerturn = Players[playerturnnumber];
            /*for (int i = 0; i < playerturn.Get_OwnedCities().Count; i++)
            {
                CitiesAvailable.Text = playerturn.Get_OwnedCities()[i].Get_Name().ToString() + " ------> " + playerturn.Get_OwnedCities()[0].Get_FieldNumber().ToString() + "\n";
            }*/
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (Main.Sell_Hotel(playerturn, playerturn.Get_PlayerCity_UsingNumber(int.Parse(CityNumber.Text))))
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("You couldn't Buy a house on this city");
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CityNumber_TextChanged(object sender, EventArgs e)
        {
            BuyHouse.Enabled = true;
            Buy_Hotel.Enabled = true;
        }

        private void BuyHouse_Click(object sender, EventArgs e)
        {
            if (Main.Sell_House(playerturn, playerturn.Get_PlayerCity_UsingNumber(int.Parse(CityNumber.Text))))
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("You couldn't Buy a house on this city");
            }
        }

        private void Upgrade_Click(object sender, EventArgs e)
        {
            Upgradee.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Upgradee.Hide();
        }
    }
}
