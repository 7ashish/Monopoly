using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class Monopoly : Form
    {
        Monopoly_Master Main;
        Point p = new Point();
        List<Player> Players = new List<Player>(4);
        int NumberofPlayers;
        int Token = 0;
        int playerturnnumber = 0;
        Player playerturn = new Player();
        Point DefaultPosition = new Point(850, 530);
        public Monopoly()
        {
            Main = new Monopoly_Master(this);
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
            BuyingCity.Hide();
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
            Player newplayer;
            if (Token == 1)
            {
                newplayer = new Player("🔴", Playername_TXT.Text, Token, 1500, DefaultPosition, 0);
            }
            else
            {
                newplayer = new Player("🔵", Playername_TXT.Text, Token, 1500, DefaultPosition, 0);
            }
            Players.Add(newplayer);
            Main.SetPlayers(Players);
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
            if (Math.Sqrt(Math.Pow(Math.Abs(Player1.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player1.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player1.Location);
                Player1_Timer.Stop();
                FinishTurn.Enabled = true;
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
            }
            if (Player1.Location.X == 850 && Player1.Location.Y == 530)
            {
                playerturn.Collect_Money(200);
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
            if (Player1.Location.X == 850 && Player1.Location.Y == 530)
            {
                playerturn.Collect_Money(200);
            }
            if (Math.Sqrt(Math.Pow(Math.Abs(Player2.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                   Math.Pow(Math.Abs(Player2.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player2.Location);
                Player2_Timre.Stop();
                FinishTurn.Enabled = true;
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                /*if(Main.Check_PlayerBalance(playerturn))
               {
                   MessageBox.Show("Your Have Negative Balance you have to Mortagage or Sell your Properties or Surrender!");
               }*/
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
            if (Player1.Location.X == 850 && Player1.Location.Y == 530)
            {
                playerturn.Collect_Money(200);
            }
            if (Math.Sqrt(Math.Pow(Math.Abs(Player3.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player3.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player3.Location);
                Player3_Timer.Stop();
                FinishTurn.Enabled = true;
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                /*if(Main.Check_PlayerBalance(playerturn))
               {
                   MessageBox.Show("Your Have Negative Balance you have to Mortagage or Sell your Properties or Surrender!");
               }*/
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
            if (Player1.Location.X == 850 && Player1.Location.Y == 530)
            {
                playerturn.Collect_Money(200);
            }
            if (Math.Sqrt(Math.Pow(Math.Abs(Player4.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player4.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player4.Location);
                Player4_Timer.Stop();
                FinishTurn.Enabled = true;
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                /*if(Main.Check_PlayerBalance(playerturn))
               {
                   MessageBox.Show("Your Have Negative Balance you have to Mortagage or Sell your Properties or Surrender!");
               }*/
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
            FinishTurn.Enabled = false;
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
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (Main.Sell_Hotel(playerturn, playerturn.Get_PlayerCity_UsingNumber(int.Parse(CityNumber.Text))))
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("You couldn't Buy a hotel on this city");
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

        private void BuyCity_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(City))
            {
                if (playerturn.Buy_City((City)Main.GetFields()[playerturn.Get_Fieldnumber() % 24]))
                {
                    MessageBox.Show("Congratulations New City was added to your Collection!");
                    BuyingCity.Hide();
                    switch (playerturn.Get_Fieldnumber()%24)
                    {
                        case 1:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    ParkLaneLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    ParkLaneLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    ParkLaneLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    ParkLaneLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 3:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    MayfairLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    MayfairLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    MayfairLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    MayfairLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 5:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    FleetLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    FleetLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    FleetLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    FleetLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 6:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    StrandLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    StrandLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    StrandLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    StrandLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 8:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    WhiteHallLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    WhiteHallLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    WhiteHallLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    WhiteHallLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 9:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    PallMallLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    PallMallLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    PallMallLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    PallMallLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 10:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    WhitechapelLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    WhitechapelLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    WhitechapelLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    WhitechapelLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 11:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    OldKentLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    OldKentLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    OldKentLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    OldKentLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 13:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    LeicesterLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    LeicesterLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    LeicesterLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    LeicesterLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 15:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    CoventryLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    CoventryLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    CoventryLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    CoventryLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 17:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    OxfordLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    OxfordLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    OxfordLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    OxfordLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 18:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    RegentLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    RegentLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    RegentLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    RegentLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 20:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    VineLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    VineLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    VineLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    VineLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 21:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    BowLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    BowLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    BowLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    BowLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 22:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    EustonLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    EustonLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    EustonLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    EustonLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 23:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    PentonvilleLabel.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    PentonvilleLabel.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    PentonvilleLabel.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    PentonvilleLabel.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Oh you couldn't buy this City!");
                    BuyingCity.Hide();
                }
            }
            else
            {
                if (playerturn.Buy_Station((Station)Main.GetFields()[playerturn.Get_Fieldnumber() % 24]))
                {
                    MessageBox.Show("Congratulations New Station was added to your Collection!");
                    BuyingCity.Hide();
                    switch (playerturn.Get_Fieldnumber()%24)
                    {
                        case 4:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    Station1Label.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    Station1Label.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    Station1Label.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    Station1Label.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                        case 16:
                            switch (playerturn.Get_Token())
                            {
                                case 1:
                                    Station2Label.BackColor = GetPlayer1Panel().BackColor;
                                    break;
                                case 2:
                                    Station2Label.BackColor = GetPlayer2Panel().BackColor;
                                    break;
                                case 3:
                                    Station2Label.BackColor = GetPlayer3Panel().BackColor;
                                    break;
                                case 4:
                                    Station2Label.BackColor = GetPlayer4Panel().BackColor;
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Oh you couldn't buy this Station!");
                    BuyingCity.Hide();
                }

            }

        }
        private void BuyingCity_Paint(object sender, PaintEventArgs e)
        {

        }
        public Panel Get_BuyingCityPanel()
        {
            return BuyingCity;
        }
        public Panel Get_CityPanel()
        {
            return City;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            BuyingCity.Hide();
        }

        private void AllGameTimer_Tick(object sender, EventArgs e)
        {
            if (Main.GetPlayers().Count != 0)
            {
                /* PlayersInfo.Text = "";
            PlayersInfo.Text += "Player Name ---> " + playerturn.Get_Name().ToString() + "\n";
            PlayersInfo.Text += "Player Token --> " + playerturn.Get_Token().ToString() + "\n";
            PlayersInfo.Text += "Player Colour ---> " + playerturn.Get_Colour().ToString() + "\n";*/

                PlayersInfo.Text = "Player Balance -----> " + playerturn.Get_Balance().ToString() + "\n";
                if (!Main.Check_PlayerBalance(playerturn))
                {
                    FinishTurn.Enabled = false;
                    MessageBox.Show("Your Have Negative Balance you have to Mortagage or Sell your Properties or Surrender!");
                }
                else if (Player1_Timer.Enabled == false && Player2_Timre.Enabled == false && Player3_Timer.Enabled == false && Player4_Timer.Enabled == false)
                {
                    FinishTurn.Enabled = true;
                }
            }
        }
        public Panel GetPlayer1Panel()
        {
            return Player1;
        }
        public Panel GetPlayer2Panel()
        {
            return Player2;
        }
        public Panel GetPlayer3Panel()
        {
            return Player3;
        }
        public Panel GetPlayer4Panel()
        {
            return Player4;
        }
    }
}
