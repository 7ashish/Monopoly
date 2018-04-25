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
            newplayer = new Player(Playername_TXT.Text, Token, 1500, DefaultPosition, 0);
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
            if (Player1.Location.X == 850 && Player1.Location.Y == 530)
            {
                playerturn.Collect_Money(200);
            }
            if (Math.Sqrt(Math.Pow(Math.Abs(Player1.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player1.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player1.Location);
                Player1_Timer.Stop();
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                if (Payrent.Visible)
                {
                    if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(City))
                    {
                        City C = (City)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];

                        if (C.Get_HouseModification())
                        {
                            if (C.Get_HotelModification())
                            {
                                RentTextBox.Text = C.Get_RentWithHotel().ToString() + "$";
                            }
                            else
                            {
                                int Houses = C.Get_NumberOfHouses();
                                RentTextBox.Text = C.Get_HouseRentPrices()[Houses - 1].ToString() + "$";
                            }
                        }
                        else
                        {
                            RentTextBox.Text = C.Get_CityRentPrice().ToString() + "$";
                        }
                    }

                    if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(Station))
                    {
                        Station S = (Station)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];
                        RentTextBox.Text = S.Get_RentPrices()[S.Get_Owner().Get_OwnedStations().Count - 1].ToString() + "$";
                    }
                }
                FinishTurn.Enabled = true;
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
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                if (Payrent.Visible)
                {
                    if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(City))
                    {
                        City C = (City)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];

                        if (C.Get_HouseModification())
                        {
                            if (C.Get_HotelModification())
                            {
                                RentTextBox.Text = C.Get_RentWithHotel().ToString() + "$";
                            }
                            else
                            {
                                int Houses = C.Get_NumberOfHouses();
                                RentTextBox.Text = C.Get_HouseRentPrices()[Houses - 1].ToString() + "$";
                            }
                        }
                        else
                        {
                            RentTextBox.Text = C.Get_CityRentPrice().ToString() + "$";
                        }
                    }

                    if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(Station))
                    {
                        Station S = (Station)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];
                        RentTextBox.Text = S.Get_RentPrices()[S.Get_Owner().Get_OwnedStations().Count - 1].ToString() + "$";
                    }
                }
                FinishTurn.Enabled = true;
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
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                if (Payrent.Visible)
                {
                    if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(City))
                    {
                        City C = (City)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];

                        if (C.Get_HouseModification())
                        {
                            if (C.Get_HotelModification())
                            {
                                RentTextBox.Text = C.Get_RentWithHotel().ToString() + "$";
                            }
                            else
                            {
                                int Houses = C.Get_NumberOfHouses();
                                RentTextBox.Text = C.Get_HouseRentPrices()[Houses - 1].ToString() + "$";
                            }
                        }
                        else
                        {
                            RentTextBox.Text = C.Get_CityRentPrice().ToString() + "$";
                        }
                    }

                    if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(Station))
                    {
                        Station S = (Station)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];
                        RentTextBox.Text = S.Get_RentPrices()[S.Get_Owner().Get_OwnedStations().Count - 1].ToString() + "$";
                    }
                }
                FinishTurn.Enabled = true;
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
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                if (Payrent.Visible)
                {
                    if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(City))
                    {
                        City C = (City)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];

                        if (C.Get_HouseModification())
                        {
                            if (C.Get_HotelModification())
                            {
                                RentTextBox.Text = C.Get_RentWithHotel().ToString() + "$";
                            }
                            else
                            {
                                int Houses = C.Get_NumberOfHouses();
                                RentTextBox.Text = C.Get_HouseRentPrices()[Houses - 1].ToString() + "$";
                            }
                        }
                        else
                        {
                            RentTextBox.Text = C.Get_CityRentPrice().ToString() + "$";
                        }
                    }

                    if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(Station))
                    {
                        Station S = (Station)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];
                        RentTextBox.Text = S.Get_RentPrices()[S.Get_Owner().Get_OwnedStations().Count - 1].ToString() + "$";
                    }
                }
                FinishTurn.Enabled = true;
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
        private void AllGameTimer_Tick(object sender, EventArgs e)
        {
            if (Main.GetPlayers().Count != 0)
            {
                switch (playerturn.Get_Token())
                {
                    case 1:
                        PlayerLabel.BackColor = Player1.BackColor;
                        PlayerLabel2.BackColor = Player1.BackColor;
                        PlayerNameTextBox.Text = playerturn.Get_Name().ToString();
                        break;
                    case 2:
                        PlayerLabel.BackColor = Player2.BackColor;
                        PlayerLabel2.BackColor = Player2.BackColor;
                        PlayerNameTextBox.Text = playerturn.Get_Name().ToString();
                        break;
                    case 3:
                        PlayerLabel.BackColor = Player3.BackColor;
                        PlayerLabel2.BackColor = Player3.BackColor;
                        PlayerNameTextBox.Text = playerturn.Get_Name().ToString();
                        break;
                    case 4:
                        PlayerLabel.BackColor = Player4.BackColor;
                        PlayerLabel2.BackColor = Player4.BackColor;
                        PlayerNameTextBox.Text = playerturn.Get_Name().ToString();
                        break;
                }
                BalanceTXT.Text = playerturn.Get_Balance().ToString() + "$";
                string[] Lines = new string[25];
                Lines[0] = "Cities & Stations:";
                int index = 0;
                if (playerturn.Get_OwnedCities().Count != 0)
                {
                    for (int i = 0; i < playerturn.Get_OwnedCities().Count; i++)
                    {
                        Lines[++index] = playerturn.Get_OwnedCities()[i].Get_Name().ToString() + " --> " + playerturn.Get_OwnedCities()[i].Get_FieldNumber().ToString();
                    }
                }
                if (playerturn.Get_OwnedStations().Count != 0)
                {
                    for (int i = 0; i < playerturn.Get_OwnedStations().Count; i++)
                    {
                        Lines[++index] = playerturn.Get_OwnedStations()[i].Get_Name().ToString()+ "--> "+playerturn.Get_OwnedStations()[i].Get_FieldNumber().ToString();
                    }
                }
                PlayersInfo.Lines = Lines;
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

        public void Set_Payrent()
        {
            Payrent.Show();
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

        public void Set_CityPriceTextBox(int price)
        {
            CityPrice.Text = price.ToString() + "$";
        }

        private void FinishTurn_Click(object sender, EventArgs e)
        {
            RollDice.Enabled = true;
            FinishTurn.Enabled = false;
            playerturnnumber = (playerturnnumber + 1) % Token;
            playerturn = Players[playerturnnumber];
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void BuyCity_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(City))
            {
                if (playerturn.Buy_City((City)Main.GetFields()[playerturn.Get_Fieldnumber() % 24]))
                {
                    MessageBox.Show("Congratulations New City was added to your Collection!");
                    BuyingCity.Hide();
                    switch (playerturn.Get_Fieldnumber() % 24)
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
                    switch (playerturn.Get_Fieldnumber() % 24)
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
            CityPrice.Text = "";

        }
        private void BuyingCity_Paint(object sender, PaintEventArgs e)
        {

        }
        public Panel Get_ActionPicPanel()
        {
            return ActionPic;
        }
        public Panel GetActionPanel()
        {
            return ActionPanel;
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

        private void OkBTN_Click(object sender, EventArgs e)
        {
            ActionPanel.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(City))
            {
                City C = (City)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];
                playerturn.Pay_CityRents(C);
                Payrent.Hide();
            }
            else if (Main.GetFields()[playerturn.Get_Fieldnumber() % 24].GetType() == typeof(Station))
            {
                Station S = (Station)Main.GetFields()[playerturn.Get_Fieldnumber() % 24];
                playerturn.Pay_StationRents(S);
                Payrent.Hide();
            }

        }

        private void surrender_Click(object sender, EventArgs e)
        {
            playerturn.Surrender();
            if (playerturn.Get_OwnedCities().Count != 0)
            {
                for (int i = 0; i < playerturn.Get_OwnedCities().Count; i++)
                {
                    switch (playerturn.Get_OwnedCities()[i].Get_FieldNumber())
                    {
                        case 1:
                            ParkLaneLabel.BackColor = Game.BackColor;
                            break;
                        case 3:
                            MayfairLabel.BackColor = Game.BackColor;
                            break;
                        case 5:
                            FleetLabel.BackColor = Game.BackColor;
                            break;
                        case 6:
                            StrandLabel.BackColor = Game.BackColor;
                            break;
                        case 8:
                            WhiteHallLabel.BackColor = Game.BackColor;
                            break;
                        case 9:
                            PallMallLabel.BackColor = Game.BackColor;
                            break;
                        case 10:
                            WhitechapelLabel.BackColor = Game.BackColor;
                            break;
                        case 11:
                            OldKentLabel.BackColor = Game.BackColor;
                            break;
                        case 13:
                            LeicesterLabel.BackColor = Game.BackColor;
                            break;
                        case 15:
                            CoventryLabel.BackColor = Game.BackColor;
                            break;
                        case 17:
                            OxfordLabel.BackColor = Game.BackColor;
                            break;
                        case 18:
                            RegentLabel.BackColor = Game.BackColor;
                            break;
                        case 20:
                            VineLabel.BackColor = Game.BackColor;
                            break;
                        case 21:
                            BowLabel.BackColor = Game.BackColor;
                            break;
                        case 22:
                            EustonLabel.BackColor = Game.BackColor;
                            break;
                        case 23:
                            PentonvilleLabel.BackColor = Game.BackColor;
                            break;
                    }

                }
            }
            if (playerturn.Get_OwnedStations().Count != 0)
            {
                for (int i = 0; i < playerturn.Get_OwnedStations().Count; i++)
                {
                    switch (playerturn.Get_OwnedStations()[i].Get_FieldNumber())
                    {
                        case 4:
                            Station1Label.BackColor = Game.BackColor;
                            break;
                        case 16:
                            Station2Label.BackColor = Game.BackColor;
                            break;
                    }
                }
            }
            switch (playerturn.Get_Token())
            {
                case 1:
                    Player1.Hide();
                    break;
                case 2:
                    Player2.Hide();
                        break;
                case 3:
                    Player3.Hide();
                    break;
                case 4:
                    Player4.Hide();
                    break;
            }
            Players.Remove(playerturn);
            Token--;
            Main.GetPlayers().Remove(playerturn);
            if (Main.GetPlayers().Count == 1)
            {
                MessageBox.Show(Main.GetPlayers()[0].Get_Name().ToString()+" is the Winner!!");
                Close();
            }
            playerturnnumber = (playerturnnumber) % Token;
            playerturn = Players[playerturnnumber];
            RollDice.Enabled = true;
            FinishTurn.Enabled = false;
            Payrent.Hide();
        }

        private void surrenderbtn_Click(object sender, EventArgs e)
        {
            playerturn.Surrender();
            if (playerturn.Get_OwnedCities().Count != 0)
            {
                for (int i = 0; i < playerturn.Get_OwnedCities().Count; i++)
                {
                    switch (playerturn.Get_OwnedCities()[i].Get_FieldNumber())
                    {
                        case 1:
                            ParkLaneLabel.BackColor = Game.BackColor;
                            break;
                        case 3:
                            MayfairLabel.BackColor = Game.BackColor;
                            break;
                        case 5:
                            FleetLabel.BackColor = Game.BackColor;
                            break;
                        case 6:
                            StrandLabel.BackColor = Game.BackColor;
                            break;
                        case 8:
                            WhiteHallLabel.BackColor = Game.BackColor;
                            break;
                        case 9:
                            PallMallLabel.BackColor = Game.BackColor;
                            break;
                        case 10:
                            WhitechapelLabel.BackColor = Game.BackColor;
                            break;
                        case 11:
                            OldKentLabel.BackColor = Game.BackColor;
                            break;
                        case 13:
                            LeicesterLabel.BackColor = Game.BackColor;
                            break;
                        case 15:
                            CoventryLabel.BackColor = Game.BackColor;
                            break;
                        case 17:
                            OxfordLabel.BackColor = Game.BackColor;
                            break;
                        case 18:
                            RegentLabel.BackColor = Game.BackColor;
                            break;
                        case 20:
                            VineLabel.BackColor = Game.BackColor;
                            break;
                        case 21:
                            BowLabel.BackColor = Game.BackColor;
                            break;
                        case 22:
                            EustonLabel.BackColor = Game.BackColor;
                            break;
                        case 23:
                            PentonvilleLabel.BackColor = Game.BackColor;
                            break;
                    }

                }
            }
            if (playerturn.Get_OwnedStations().Count != 0)
            {
                for (int i = 0; i < playerturn.Get_OwnedStations().Count; i++)
                {
                    switch (playerturn.Get_OwnedStations()[i].Get_FieldNumber())
                    {
                        case 4:
                            Station1Label.BackColor = Game.BackColor;
                            break;
                        case 16:
                            Station2Label.BackColor = Game.BackColor;
                            break;
                    }
                }
            }
            switch (playerturn.Get_Token())
            {
                case 1:
                    Player1.Hide();
                    break;
                case 2:
                    Player2.Hide();
                    break;
                case 3:
                    Player3.Hide();
                    break;
                case 4:
                    Player4.Hide();
                    break;
            }
            Players.Remove(playerturn);
            Token--;
            Main.GetPlayers().Remove(playerturn);
            if (Main.GetPlayers().Count == 1)
            {
                MessageBox.Show(Main.GetPlayers()[0].Get_Name().ToString() + " is the Winner!!");
                Close();
            }
            playerturnnumber = (playerturnnumber) % Token;
            playerturn = Players[playerturnnumber];
            RollDice.Enabled = true;
            FinishTurn.Enabled = false;
        }

        private void Mortagage_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Citynumber_TextChanged(object sender, EventArgs e)
        {
            Mortagage.Enabled = true;
            BuyHotel.Enabled = true;
            BuyHouse.Enabled = true;
            SellHouse.Enabled = true;
            SellHotel.Enabled = true;
            RemoveMortagage.Enabled = true;
        }
    }
}
