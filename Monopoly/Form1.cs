using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class Monopoly : Form
    {
        bool IsHost = false;
        bool IsMultiPlayer = false;
        bool GameStarted = false;
        public Monopoly_Master Main;
        Point p = new Point();
        List<Player> Players = new List<Player>(4);
        int NumberofPlayers;
        int Token = 0;
        int playerturnnumber = 0;
        Player playerturn = new Player();
        Point DefaultPosition = new Point(850, 530);
        bool Bankrupt = false;
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
            Information.Show();
            Registeration.Hide();
            Player1Name.Text = Players[0].Get_Name() + " Token Colour: ";
            Player2Name.Text = Players[1].Get_Name() + " Token Colour: ";
            switch (Token)
            {
                case 3:
                    Player3Panel.Show();
                    Player3Name.Text = Players[2].Get_Name() + " Token Colour: ";
                    break;
                case 4:
                    Player3Panel.Show();
                    Player4Panel.Show();
                    Player3Name.Text = Players[2].Get_Name() + " Token Colour: ";
                    Player4Name.Text = Players[3].Get_Name() + " Token Colour: ";
                    break;
            }
            playerturn = Players[playerturnnumber];
        }
        bool[] GoMoney = { false, false, false, false };
        const int Speed = 2;
        private void Player1_Timer_Tick(object sender, EventArgs e)
        {
            FinishTurn.Enabled = false;
            if (Math.Sqrt(Math.Pow(Math.Abs(Player1.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player1.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player1.Location);
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                if (!Main.Check_PlayerBalance(playerturn))
                {
                    Player1_Timer.Stop();
                    MessageBox.Show("You Have Negative Balance!! you have to Mortagage or Sell your Properties or Surrender!", "Game Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
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
                Player1_Timer.Stop();
            }
            if (Player1.Location.X < 80 && Player1.Location.Y > 80)
            {
                p = Player1.Location;
                p.Y -= Speed;
                Player1.Location = p;
            }
            else if (Player1.Location.Y <= 80 && Player1.Location.X <= 850)
            {
                p = Player1.Location;
                p.X += Speed;
                Player1.Location = p;
            }
            else if (Player1.Location.X > 850 && Player1.Location.Y <= 530)
            {
                p = Player1.Location;
                p.Y += Speed;
                Player1.Location = p;
            }
            else
            {
                p = Player1.Location;
                p.X -= Speed;
                Player1.Location = p;
            }
            if (Math.Sqrt(Math.Pow(Math.Abs(Player1.Location.X - 850), 2) + Math.Pow(Math.Abs(Player1.Location.Y - 530), 2)) <= 5)
            {
                if (GoMoney[0])
                {
                    playerturn.Collect_Money(200);
                    GoMoney[0] = false;
                }
            }
            else
            {
                GoMoney[0] = true;
            }
        }
        private void Player2_Timer_Tick(object sender, EventArgs e)
        {
            FinishTurn.Enabled = false;
            if (Math.Sqrt(Math.Pow(Math.Abs(Player2.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player2.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player2.Location);
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                if (!Main.Check_PlayerBalance(playerturn))
                {
                    Player2_Timre.Stop();
                    MessageBox.Show("You Have Negative Balance!! you have to Mortagage or Sell your Properties or Surrender!", "Game Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
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
                Player2_Timre.Stop();
            }
            if (Player2.Location.X < 80 && Player2.Location.Y > 80)
            {
                p = Player2.Location;
                p.Y -= Speed;
                Player2.Location = p;
            }
            else if (Player2.Location.Y <= 80 && Player2.Location.X <= 850)
            {
                p = Player2.Location;
                p.X += Speed;
                Player2.Location = p;
            }
            else if (Player2.Location.X > 850 && Player2.Location.Y <= 530)
            {
                p = Player2.Location;
                p.Y += Speed;
                Player2.Location = p;
            }
            else
            {
                p = Player2.Location;
                p.X -= Speed;
                Player2.Location = p;
            }
            if (Math.Sqrt(Math.Pow(Math.Abs(Player2.Location.X - 850), 2) + Math.Pow(Math.Abs(Player2.Location.Y - 530), 2)) <= 5)
            {
                if (GoMoney[1])
                {
                    playerturn.Collect_Money(200);
                    GoMoney[1] = false;
                }
            }
            else
            {
                GoMoney[1] = true;
            }
        }
        private void Player3_Timer_Tick(object sender, EventArgs e)
        {
            FinishTurn.Enabled = false;
            if (Math.Sqrt(Math.Pow(Math.Abs(Player3.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player3.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player3.Location);
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                if (!Main.Check_PlayerBalance(playerturn))
                {
                    Player3_Timer.Stop();
                    MessageBox.Show("You Have Negative Balance!! you have to Mortagage or Sell your Properties or Surrender!", "Game Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
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
                Player3_Timer.Stop();
            }
            if (Player3.Location.X < 80 && Player3.Location.Y > 80)
            {
                p = Player3.Location;
                p.Y -= Speed;
                Player3.Location = p;
            }
            else if (Player3.Location.Y <= 80 && Player3.Location.X <= 850)
            {
                p = Player3.Location;
                p.X += Speed;
                Player3.Location = p;
            }
            else if (Player3.Location.X > 850 && Player3.Location.Y <= 530)
            {
                p = Player3.Location;
                p.Y += Speed;
                Player3.Location = p;
            }
            else
            {
                p = Player3.Location;
                p.X -= Speed;
                Player3.Location = p;
            }
            if (Math.Sqrt(Math.Pow(Math.Abs(Player3.Location.X - 850), 2) + Math.Pow(Math.Abs(Player3.Location.Y - 530), 2)) <= 5)
            {
                if (GoMoney[2])
                {
                    playerturn.Collect_Money(200);
                    GoMoney[2] = false;
                }
            }
            else
            {
                GoMoney[2] = true;
            }
        }
        private void Player4_Timer_Tick(object sender, EventArgs e)
        {
            FinishTurn.Enabled = false;
            if (Math.Sqrt(Math.Pow(Math.Abs(Player4.Location.X - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().X), 2) +
                Math.Pow(Math.Abs(Player4.Location.Y - Main.Get_Fields()[(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber()) % 24].Get_FieldPosition().Y), 2)) <= 5)
            {
                playerturn.Set_Fieldnumber(Main.Get_Dice1() + Main.Get_Dice2() + playerturn.Get_Fieldnumber());
                playerturn.Set_PlayerPosition(Player4.Location);
                Main.GetFields()[playerturn.Get_Fieldnumber() % 24].Action(playerturn);
                if (!Main.Check_PlayerBalance(playerturn))
                {
                    Player4_Timer.Stop();
                    MessageBox.Show("You Have Negative Balance!! you have to Mortagage or Sell your Properties or Surrender!", "Game Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
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
                Player4_Timer.Stop();
            }
            if (Player4.Location.X < 80 && Player4.Location.Y > 80)
            {
                p = Player4.Location;
                p.Y -= Speed;
                Player4.Location = p;
            }
            else if (Player4.Location.Y <= 80 && Player4.Location.X <= 850)
            {
                p = Player4.Location;
                p.X += Speed;
                Player4.Location = p;
            }
            else if (Player4.Location.X > 850 && Player4.Location.Y <= 530)
            {
                p = Player4.Location;
                p.Y += Speed;
                Player4.Location = p;
            }
            else
            {
                p = Player4.Location;
                p.X -= Speed;
                Player4.Location = p;
            }
            if (Math.Sqrt(Math.Pow(Math.Abs(Player4.Location.X - 850), 2) + Math.Pow(Math.Abs(Player4.Location.Y - 530), 2)) <= 5)
            {
                if (GoMoney[3])
                {
                    playerturn.Collect_Money(200);
                    GoMoney[3] = false;
                }
            }
            else
            {
                GoMoney[3] = true;
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
                        Lines[++index] = playerturn.Get_OwnedStations()[i].Get_Name().ToString() + "--> " + playerturn.Get_OwnedStations()[i].Get_FieldNumber().ToString();
                    }
                }
                PlayersInfo.Lines = Lines;
                if (!Main.Check_PlayerBalance(playerturn))
                {
                    FinishTurn.Enabled = false;
                    Bankrupt = true;
                }
                else if (Player1_Timer.Enabled == false && Player2_Timre.Enabled == false && Player3_Timer.Enabled == false && Player4_Timer.Enabled == false && Bankrupt)
                {
                    Bankrupt = false;
                    FinishTurn.Enabled = true;
                }
            }
        }

        public Timer GetTimer(int token)
        {
            switch (token)
            {
                case 1:
                    return Player1_Timer;
                case 2:
                    return Player2_Timre;
                case 3:
                    return Player3_Timer;
                default: return Player4_Timer;
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
            if (Bankrupt)
            {
                MessageBox.Show("You Have Negative Balance!! you have to Mortagage or Sell your Properties or Surrender!", "Game Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Main.Move_Player(playerturn);
            }
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
            Dice1TXT.Text = "0";
            Dice2TXT.Text = "0";
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
                    MessageBox.Show("Congratulations New City was added to your Collection!", "Cities", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Oh you couldn't buy this City!", "Cities", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BuyingCity.Hide();
                }
            }
            else
            {
                if (playerturn.Buy_Station((Station)Main.GetFields()[playerturn.Get_Fieldnumber() % 24]))
                {
                    MessageBox.Show("Congratulations New Station was added to your Collection!", "Stations", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Oh you couldn't buy this Station!", "Stations", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void SetPlayer1PanelLocation(Point v)
        {
            Player1.Location = v;
        }
        public Panel GetPlayer2Panel()
        {
            return Player2;
        }
        public void SetPlayer2PanelLocation(Point v)
        {
            Player2.Location = v;
        }
        public Panel GetPlayer3Panel()
        {
            return Player3;
        }
        public void SetPlayer3PanelLocation(Point v)
        {
            Player3.Location = v;
        }
        public Panel GetPlayer4Panel()
        {
            return Player4;
        }
        public void SetPlayer4PanelLocation(Point v)
        {
            Player4.Location = v;
        }
        private void OkBTN_Click(object sender, EventArgs e)
        {
            ActionPanel.Hide();
        }
        //Pay rents button.
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
            if (!Main.Check_PlayerBalance(playerturn))
            {
                MessageBox.Show("You Have Negative Balance!! you have to Mortagage or Sell your Properties or Surrender!", "Game Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void surrender_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Surrender ?!", "Game Information", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
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
                                ParkLaneMortagage.Hide();
                                ParkLane_House.Hide();
                                ParkLane_Hotel.Hide();
                                break;
                            case 3:
                                MayfairLabel.BackColor = Game.BackColor;
                                MayFairMortagagePanel.Hide();
                                MayFair_House.Hide();
                                MayFair_Hotel.Hide();
                                break;
                            case 5:
                                FleetLabel.BackColor = Game.BackColor;
                                FleetMortagagePanel.Hide();
                                FleetStreet_House.Hide();
                                FleetST_Hotel.Hide();
                                break;
                            case 6:
                                StrandLabel.BackColor = Game.BackColor;
                                StrandMortagagePanel.Hide();
                                Strand_House.Hide();
                                Strand_Hotel.Hide();
                                break;
                            case 8:
                                WhiteHallLabel.BackColor = Game.BackColor;
                                WhiteHallMortagagePanel.Hide();
                                WhiteHall_House.Hide();
                                WhiteHall_Hotel.Hide();
                                break;
                            case 9:
                                PallMallLabel.BackColor = Game.BackColor;
                                PallMallMortagagePanel.Hide();
                                PallMall_House.Hide();
                                PallMall_Hotel.Hide();
                                break;
                            case 10:
                                WhitechapelLabel.BackColor = Game.BackColor;
                                WhiteChapelMortagagePanel.Hide();
                                Whitechapel_House.Hide();
                                Whitechapel_Hotel.Hide();
                                break;
                            case 11:
                                OldKentLabel.BackColor = Game.BackColor;
                                OldKentMortagagePanel.Hide();
                                OldKent_House.Hide();
                                OldKent_Hotel.Hide();
                                break;
                            case 13:
                                LeicesterLabel.BackColor = Game.BackColor;
                                LeicesterMortagagePanel.Hide();
                                LeicesterSq_House.Hide();
                                Leicester_Hotel.Hide();
                                break;
                            case 15:
                                CoventryLabel.BackColor = Game.BackColor;
                                CoventryMortagagePanel.Hide();
                                Coventry_House.Hide();
                                Coventry_Hotel.Hide();
                                break;
                            case 17:
                                OxfordLabel.BackColor = Game.BackColor;
                                OxfordMortagagePanel.Hide();
                                Oxford_House.Hide();
                                Oxford_Hotel.Hide();
                                break;
                            case 18:
                                RegentLabel.BackColor = Game.BackColor;
                                RegentMortagagePanel.Hide();
                                Regent_House.Hide();
                                Regent_Hotel.Hide();
                                break;
                            case 20:
                                VineLabel.BackColor = Game.BackColor;
                                VineMortagagePanel.Hide();
                                Vine_House.Hide();
                                VineST_Hotel.Hide();
                                break;
                            case 21:
                                BowLabel.BackColor = Game.BackColor;
                                BowMortagagePanel.Hide();
                                Bow_House.Hide();
                                BowST_Hotel.Hide();
                                break;
                            case 22:
                                EustonLabel.BackColor = Game.BackColor;
                                EustonMortagagePanel.Hide();
                                Euston_House.Hide();
                                Euston_Hotel.Hide();
                                break;
                            case 23:
                                PentonvilleLabel.BackColor = Game.BackColor;
                                PentonvilleMortagagePanel.Hide();
                                Pentonville_House.Hide();
                                Pentonville_Hotel.Hide();
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
                                Station1MortagagePanel.Hide();
                                break;
                            case 16:
                                Station2Label.BackColor = Game.BackColor;
                                Station2MortagagePanel.Hide();
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
                    MessageBox.Show(Main.GetPlayers()[0].Get_Name().ToString() + " is the Winner!!", "Game Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                playerturnnumber = (playerturnnumber) % Token;
                playerturn = Players[playerturnnumber];
                RollDice.Enabled = true;
                FinishTurn.Enabled = false;
                Payrent.Hide();
            }
        }

        private void surrenderbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Surrender ?!", "Game Information", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
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
                                ParkLaneMortagage.Hide();
                                ParkLane_House.Hide();
                                ParkLane_Hotel.Hide();
                                break;
                            case 3:
                                MayfairLabel.BackColor = Game.BackColor;
                                MayFairMortagagePanel.Hide();
                                MayFair_House.Hide();
                                MayFair_Hotel.Hide();
                                break;
                            case 5:
                                FleetLabel.BackColor = Game.BackColor;
                                FleetMortagagePanel.Hide();
                                FleetStreet_House.Hide();
                                FleetST_Hotel.Hide();
                                break;
                            case 6:
                                StrandLabel.BackColor = Game.BackColor;
                                StrandMortagagePanel.Hide();
                                Strand_House.Hide();
                                Strand_Hotel.Hide();
                                break;
                            case 8:
                                WhiteHallLabel.BackColor = Game.BackColor;
                                WhiteHallMortagagePanel.Hide();
                                WhiteHall_House.Hide();
                                WhiteHall_Hotel.Hide();
                                break;
                            case 9:
                                PallMallLabel.BackColor = Game.BackColor;
                                PallMallMortagagePanel.Hide();
                                PallMall_House.Hide();
                                PallMall_Hotel.Hide();
                                break;
                            case 10:
                                WhitechapelLabel.BackColor = Game.BackColor;
                                WhiteChapelMortagagePanel.Hide();
                                Whitechapel_House.Hide();
                                Whitechapel_Hotel.Hide();
                                break;
                            case 11:
                                OldKentLabel.BackColor = Game.BackColor;
                                OldKentMortagagePanel.Hide();
                                OldKent_House.Hide();
                                OldKent_Hotel.Hide();
                                break;
                            case 13:
                                LeicesterLabel.BackColor = Game.BackColor;
                                LeicesterMortagagePanel.Hide();
                                LeicesterSq_House.Hide();
                                Leicester_Hotel.Hide();
                                break;
                            case 15:
                                CoventryLabel.BackColor = Game.BackColor;
                                CoventryMortagagePanel.Hide();
                                Coventry_House.Hide();
                                Coventry_Hotel.Hide();
                                break;
                            case 17:
                                OxfordLabel.BackColor = Game.BackColor;
                                OxfordMortagagePanel.Hide();
                                Oxford_House.Hide();
                                Oxford_Hotel.Hide();
                                break;
                            case 18:
                                RegentLabel.BackColor = Game.BackColor;
                                RegentMortagagePanel.Hide();
                                Regent_House.Hide();
                                Regent_Hotel.Hide();
                                break;
                            case 20:
                                VineLabel.BackColor = Game.BackColor;
                                VineMortagagePanel.Hide();
                                Vine_House.Hide();
                                VineST_Hotel.Hide();
                                break;
                            case 21:
                                BowLabel.BackColor = Game.BackColor;
                                BowMortagagePanel.Hide();
                                Bow_House.Hide();
                                BowST_Hotel.Hide();
                                break;
                            case 22:
                                EustonLabel.BackColor = Game.BackColor;
                                EustonMortagagePanel.Hide();
                                Euston_House.Hide();
                                Euston_Hotel.Hide();
                                break;
                            case 23:
                                PentonvilleLabel.BackColor = Game.BackColor;
                                PentonvilleMortagagePanel.Hide();
                                Pentonville_House.Hide();
                                Pentonville_Hotel.Hide();
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
                                Station1MortagagePanel.Hide();
                                break;
                            case 16:
                                Station2Label.BackColor = Game.BackColor;
                                Station2MortagagePanel.Hide();
                                break;
                        }
                    }
                }
                switch (playerturn.Get_Token())
                {
                    case 1:
                        Player1.Hide();
                        Player1_Timer.Stop();
                        break;
                    case 2:
                        Player2.Hide();
                        Player2_Timre.Stop();
                        break;
                    case 3:
                        Player3.Hide();
                        Player3_Timer.Stop();
                        break;
                    case 4:
                        Player4.Hide();
                        Player4_Timer.Stop();
                        break;
                }
                Players.Remove(playerturn);
                Token--;
                Main.GetPlayers().Remove(playerturn);
                if (Main.GetPlayers().Count == 1)
                {
                    MessageBox.Show(Main.GetPlayers()[0].Get_Name().ToString() + " is the Winner!!", "Game Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                playerturnnumber = (playerturnnumber) % Token;
                playerturn = Players[playerturnnumber];
                RollDice.Enabled = true;
                FinishTurn.Enabled = false;
            }
        }

        private void Mortagage_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[int.Parse(Citynumber.Text)].GetType() == typeof(City))
            {
                City C = (City)Main.GetFields()[int.Parse(Citynumber.Text)];
                if (Main.Mortagage_City(playerturn, C))
                {
                    MessageBox.Show("You have Mortagaged this city", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (int.Parse(Citynumber.Text))
                    {
                        case 1:
                            ParkLaneMortagage.Show();
                            break;
                        case 3:
                            MayFairMortagagePanel.Show();
                            break;
                        case 5:
                            FleetMortagagePanel.Show();
                            break;
                        case 6:
                            StrandMortagagePanel.Show();
                            break;
                        case 8:
                            WhiteHallMortagagePanel.Show();
                            break;
                        case 9:
                            PallMallMortagagePanel.Show();
                            break;
                        case 10:
                            WhiteChapelMortagagePanel.Show();
                            break;
                        case 11:
                            OldKentMortagagePanel.Show();
                            break;
                        case 13:
                            LeicesterMortagagePanel.Show();
                            break;
                        case 15:
                            CoventryMortagagePanel.Show();
                            break;
                        case 17:
                            OxfordMortagagePanel.Show();
                            break;
                        case 18:
                            RegentMortagagePanel.Show();
                            break;
                        case 20:
                            VineMortagagePanel.Show();
                            break;
                        case 21:
                            BowMortagagePanel.Show();
                            break;
                        case 22:
                            EustonMortagagePanel.Show();
                            break;
                        case 23:
                            PentonvilleMortagagePanel.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There was an error in Mortagaging this City, Try Again!\n", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (Main.GetFields()[int.Parse(Citynumber.Text)].GetType() == typeof(Station))
            {
                Station S = (Station)Main.GetFields()[int.Parse(Citynumber.Text)];
                if (Main.Mortagage_Station(playerturn, S))
                {
                    MessageBox.Show("You have Mortagaged this Station", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (int.Parse(Citynumber.Text))
                    {
                        case 4:
                            Station1MortagagePanel.Show();
                            break;
                        case 16:
                            Station2MortagagePanel.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There was an error in Mortagaging this Station, Try Again!", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("There was an error in Mortagaging this City, Try Again!", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Citynumber.Text = "";
            Mortagage.Enabled = false;
            BuyHotel.Enabled = false;
            BuyHouse.Enabled = false;
            SellHouse.Enabled = false;
            SellHotel.Enabled = false;
            RemoveMortagage.Enabled = false;
        }
        //Buy house button.
        private void button3_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[int.Parse(Citynumber.Text)].GetType() == typeof(City))
            {
                City C = new City();
                C = (City)Main.GetFields()[int.Parse(Citynumber.Text)];
                if (Main.Sell_House(playerturn, C))
                {
                    MessageBox.Show("You have Bought new House on this city", "House Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (int.Parse(Citynumber.Text))
                    {
                        case 1:
                            ParkLane_House.Show();
                            ParkLane_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 3:
                            MayFair_House.Show();
                            MayFair_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 5:
                            FleetStreet_House.Show();
                            Fleet_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 6:
                            Strand_House.Show();
                            Strand_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 8:
                            WhiteHall_House.Show();
                            WhiteHall_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 9:
                            PallMall_House.Show();
                            PallMall_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 10:
                            Whitechapel_House.Show();
                            Whitechapel_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 11:
                            OldKent_House.Show();
                            OldKent_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 13:
                            LeicesterSq_House.Show();
                            Leicester_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 15:
                            Coventry_House.Show();
                            Coventry_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 17:
                            Oxford_House.Show();
                            Oxford_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 18:
                            Regent_House.Show();
                            Regent_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 20:
                            Vine_House.Show();
                            Vine_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 21:
                            Bow_House.Show();
                            Bow_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 22:
                            Euston_House.Show();
                            Euston_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                        case 23:
                            Pentonville_House.Show();
                            Pentonville_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There was an error in Buying a House on this City, Try Again!", "House Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("There was an error in Buying a House on this City, Try Again!", "House Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Citynumber.Text = "";
            Mortagage.Enabled = false;
            BuyHotel.Enabled = false;
            BuyHouse.Enabled = false;
            SellHouse.Enabled = false;
            SellHotel.Enabled = false;
            RemoveMortagage.Enabled = false;
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void UpdateBTN_Click(object sender, EventArgs e)
        {
            UpdatePanel.Show();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            UpdatePanel.Hide();
        }

        private void RemoveMortagage_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[int.Parse(Citynumber.Text)].GetType() == typeof(City))
            {
                City C = (City)Main.GetFields()[int.Parse(Citynumber.Text)];
                if (Main.RemoveCityMortagage(playerturn, C))
                {
                    MessageBox.Show("You have Removed Mortagaged on this city", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (int.Parse(Citynumber.Text))
                    {
                        case 1:
                            ParkLaneMortagage.Hide();
                            break;
                        case 3:
                            MayFairMortagagePanel.Hide();
                            break;
                        case 5:
                            FleetMortagagePanel.Hide();
                            break;
                        case 6:
                            StrandMortagagePanel.Hide();
                            break;
                        case 8:
                            WhiteHallMortagagePanel.Hide();
                            break;
                        case 9:
                            PallMallMortagagePanel.Hide();
                            break;
                        case 10:
                            WhiteChapelMortagagePanel.Hide();
                            break;
                        case 11:
                            OldKentMortagagePanel.Hide();
                            break;
                        case 13:
                            LeicesterMortagagePanel.Hide();
                            break;
                        case 15:
                            CoventryMortagagePanel.Hide();
                            break;
                        case 17:
                            OxfordMortagagePanel.Hide();
                            break;
                        case 18:
                            RegentMortagagePanel.Hide();
                            break;
                        case 20:
                            VineMortagagePanel.Hide();
                            break;
                        case 21:
                            BowMortagagePanel.Hide();
                            break;
                        case 22:
                            EustonMortagagePanel.Hide();
                            break;
                        case 23:
                            PentonvilleMortagagePanel.Hide();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There was an error in Removing Mortagage on this City, Try Again!", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (Main.GetFields()[int.Parse(Citynumber.Text)].GetType() == typeof(Station))
            {
                Station S = (Station)Main.GetFields()[int.Parse(Citynumber.Text)];
                if (Main.RemoveStationMortagage(playerturn, S))
                {
                    MessageBox.Show("You have Mortagaged this Station", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (int.Parse(Citynumber.Text))
                    {
                        case 4:
                            Station1MortagagePanel.Hide();
                            break;
                        case 16:
                            Station2MortagagePanel.Hide();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There was an error in Mortagaging this Station, Try Again!", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("There was an error in Removing Mortagage on this City, Try Again!", "Mortagage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Citynumber.Text = "";
            Mortagage.Enabled = false;
            BuyHotel.Enabled = false;
            BuyHouse.Enabled = false;
            SellHouse.Enabled = false;
            SellHotel.Enabled = false;
            RemoveMortagage.Enabled = false;
        }

        private void SellHouse_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[int.Parse(Citynumber.Text)].GetType() == typeof(City))
            {
                City C = new City();
                C = (City)Main.GetFields()[int.Parse(Citynumber.Text)];
                if (Main.Remove_House(playerturn, C))
                {
                    MessageBox.Show("You have sold a House on this city", "House Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (int.Parse(Citynumber.Text))
                    {
                        case 1:
                            ParkLane_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                ParkLane_House.Hide();
                            }
                            break;
                        case 3:
                            MayFair_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                MayFair_House.Hide();
                            }
                            break;
                        case 5:
                            Fleet_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                FleetStreet_House.Hide();
                            }
                            break;
                        case 6:
                            Strand_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Strand_House.Hide();
                            }
                            break;
                        case 8:
                            WhiteHall_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                WhiteHall_House.Hide();
                            }
                            break;
                        case 9:
                            PallMall_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                PallMall_House.Hide();
                            }
                            break;
                        case 10:
                            Whitechapel_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Whitechapel_House.Hide();
                            }
                            break;
                        case 11:
                            OldKent_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                OldKent_House.Hide();
                            }
                            break;
                        case 13:
                            Leicester_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                LeicesterSq_House.Hide();
                            }
                            break;
                        case 15:
                            Coventry_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Coventry_House.Hide();
                            }
                            break;
                        case 17:
                            Oxford_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Oxford_House.Hide();
                            }
                            break;
                        case 18:
                            Regent_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Regent_House.Hide();
                            }
                            break;
                        case 20:
                            Vine_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Vine_House.Hide();
                            }
                            break;
                        case 21:
                            Bow_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Bow_House.Hide();
                            }
                            break;
                        case 22:
                            Euston_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Euston_House.Hide();
                            }
                            break;
                        case 23:
                            Pentonville_HouseTXT.Text = C.Get_NumberOfHouses().ToString();
                            if (C.Get_NumberOfHouses() == 0)
                            {
                                Pentonville_House.Hide();
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There was an error in Selling a House on this City, Try Again!", "House Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            Citynumber.Text = "";
            Mortagage.Enabled = false;
            BuyHotel.Enabled = false;
            BuyHouse.Enabled = false;
            SellHouse.Enabled = false;
            SellHotel.Enabled = false;
            RemoveMortagage.Enabled = false;
        }

        private void BuyHotel_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[int.Parse(Citynumber.Text)].GetType() == typeof(City))
            {
                City C = new City();
                C = (City)Main.GetFields()[int.Parse(Citynumber.Text)];
                if (Main.Sell_Hotel(playerturn, C))
                {
                    MessageBox.Show("You have Bought a Hotel on this city", "Hotel Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (int.Parse(Citynumber.Text))
                    {
                        case 1:
                            ParkLane_Hotel.Show();
                            break;
                        case 3:
                            MayFair_Hotel.Show();
                            break;
                        case 5:
                            FleetST_Hotel.Show();
                            break;
                        case 6:
                            Strand_Hotel.Show();
                            break;
                        case 8:
                            WhiteHall_Hotel.Show();
                            break;
                        case 9:
                            PallMall_Hotel.Show();
                            break;
                        case 10:
                            Whitechapel_Hotel.Show();
                            break;
                        case 11:
                            OldKent_Hotel.Show();
                            break;
                        case 13:
                            Leicester_Hotel.Show();
                            break;
                        case 15:
                            Coventry_Hotel.Show();
                            break;
                        case 17:
                            Oxford_Hotel.Show();
                            break;
                        case 18:
                            Regent_Hotel.Show();
                            break;
                        case 20:
                            VineST_Hotel.Show();
                            break;
                        case 21:
                            BowST_Hotel.Show();
                            break;
                        case 22:
                            Euston_Hotel.Show();
                            break;
                        case 23:
                            Pentonville_Hotel.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There was an error in Buying a Hotel on this City, Try Again!", "Hotel Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("There was an error in Buying a Hotel on this City, Try Again!", "Hotel Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Citynumber.Text = "";
            Mortagage.Enabled = false;
            BuyHotel.Enabled = false;
            BuyHouse.Enabled = false;
            SellHouse.Enabled = false;
            SellHotel.Enabled = false;
            RemoveMortagage.Enabled = false;
        }

        private void SellHotel_Click(object sender, EventArgs e)
        {
            if (Main.GetFields()[int.Parse(Citynumber.Text)].GetType() == typeof(City))
            {
                City C = (City)Main.GetFields()[int.Parse(Citynumber.Text)];
                if (Main.Remove_Hotel(playerturn, C))
                {
                    MessageBox.Show("You have Sold the hotel on this city", "Hotel Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (int.Parse(Citynumber.Text))
                    {
                        case 1:
                            ParkLane_Hotel.Hide();
                            break;
                        case 3:
                            MayFair_Hotel.Hide();
                            break;
                        case 5:
                            FleetST_Hotel.Hide();
                            break;
                        case 6:
                            Strand_Hotel.Hide();
                            break;
                        case 8:
                            WhiteHall_Hotel.Hide();
                            break;
                        case 9:
                            PallMall_Hotel.Hide();
                            break;
                        case 10:
                            Whitechapel_Hotel.Hide();
                            break;
                        case 11:
                            OldKent_Hotel.Hide();
                            break;
                        case 13:
                            Leicester_Hotel.Hide();
                            break;
                        case 15:
                            Coventry_Hotel.Hide();
                            break;
                        case 17:
                            Oxford_Hotel.Hide();
                            break;
                        case 18:
                            Regent_Hotel.Hide();
                            break;
                        case 20:
                            VineST_Hotel.Hide();
                            break;
                        case 21:
                            BowST_Hotel.Hide();
                            break;
                        case 22:
                            Euston_Hotel.Hide();
                            break;
                        case 23:
                            Pentonville_Hotel.Hide();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There was an error in Selling the Hotel on this City, Try Again!", "Hotel Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("There was an error in Selling the Hotel on this City, Try Again!", "Hotel Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Citynumber.Text = "";
            Mortagage.Enabled = false;
            BuyHotel.Enabled = false;
            BuyHouse.Enabled = false;
            SellHouse.Enabled = false;
            SellHotel.Enabled = false;
            RemoveMortagage.Enabled = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            if (IsHost)
            {
                NetworkManager.Cout("StartGame");
            }
            Information.Hide();
            Game.Show();
        }

        private void SinglePlayerBTN_Click(object sender, EventArgs e)
        {
            Registeration.Show();
            Mode.Hide();
            MultiPlayer.Hide();
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            HostBTN.Enabled = false;
            JoinBTN.Enabled = false;
            await NetworkManager.FindServer();
            MessageBox.Show("Connected to " + NetworkManager.GetConnectedIP(),"Network",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            IsMultiPlayer = true;
            IsHost = false;
            MultiRegister.Show();
            MultiPlayer.Hide();
        }

        private async void HostBTN_Click(object sender, EventArgs e)
        {
            HostBTN.Enabled = false;
            JoinBTN.Enabled = false;
            await NetworkManager.AnnouncePresence();
            MessageBox.Show("Connected to " + NetworkManager.GetConnectedIP(), "Network", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            IsMultiPlayer = true;
            IsHost = true;
            MultiRegister.Show();
            MultiPlayer.Hide();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Mode.Show();
            MultiPlayer.Hide();
            HostBTN.Enabled = true;
            JoinBTN.Enabled = true;
        }

        private void MultiPlayerBTN_Click(object sender, EventArgs e)
        {
            MultiPlayer.Show();
            Mode.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Player1Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void HostTXT_TextChanged(object sender, EventArgs e)
        {
            if (IsHost)
            {
                NetworkManager.Cout("HostName=" + HostTXT.Text);
                HostCheckBox.Enabled = true;
            }
        }

        private void ClientCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsHost)
            {
                NetworkManager.Cout("ClientIsReady");
            }
            ClientCheckBox.Enabled = false;
            ClientTXT.Enabled = false;
            Player newplayer;
            newplayer = new Player(ClientTXT.Text, Token, 1500, DefaultPosition, 0);
            Players.Add(newplayer);
            Main.SetPlayers(Players);
            if (ClientCheckBox.Checked==true && HostCheckBox.Checked == true)
            {
                Player1Name.Text = Players[0].Get_Name() + " Token Colour: ";
                Player2Name.Text = Players[1].Get_Name() + " Token Colour: ";
                Information.Show();
                MultiRegister.Hide();
                Player1.Show();
                Player2.Show();
            }
        }

        private void ClientTXT_TextChanged(object sender, EventArgs e)
        {
            if (!IsHost)
            {
                NetworkManager.Cout("ClientName=" + ClientTXT.Text);
                ClientCheckBox.Enabled = true;
            }
        }

        private void HostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsHost)
            {
                NetworkManager.Cout("HostIsReady");
            }
            HostCheckBox.Enabled = false;
            HostTXT.Enabled = false;
            Player newplayer;
            newplayer = new Player(HostTXT.Text, Token, 1500, DefaultPosition, 0);
            Players.Add(newplayer);
            Main.SetPlayers(Players);
            if (ClientCheckBox.Checked == true && HostCheckBox.Checked == true)
            {
                Player1Name.Text = Players[0].Get_Name() + " Token Colour: ";
                Player2Name.Text = Players[1].Get_Name() + " Token Colour: ";
                Information.Show();
                MultiRegister.Hide();
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void MultiRegister_VisibleChanged(object sender, EventArgs e)
        {
            if (!MultiRegister.Visible)
            {
                return;
            }
            if (IsHost)
            {
                ClientCheckBox.Enabled = false;
                ClientTXT.Enabled = false;
            }
            else
            {
                HostCheckBox.Enabled = false;
                HostTXT.Enabled = false;
            }
            while (true)
            {
                string[] strings = await NetworkManager.Cin();
                foreach (string str in strings)
                {
                    if(string.IsNullOrWhiteSpace(str))
                    {
                        continue;
                    }
                    string[] Spliter = str.Split('=');
                    if (Spliter[0] == "HostName")
                    {
                        HostTXT.Text = Spliter[1];
                    }
                    else if(Spliter[0] == "ClientName")
                    {
                        ClientTXT.Text = Spliter[1];
                    }
                    else
                    {
                        if (!IsHost)
                        {
                            HostCheckBox.Checked = true;
                        }
                        else
                        {
                            ClientCheckBox.Checked = true;
                        }
                        return;
                    }
                }
            }
        }

        private async void Information_VisibleChanged(object sender, EventArgs e)
        {
            if (!Information.Visible)
            {
                return;
            }
            if (IsHost)
            {
                StartGame.Enabled = true;
                return;
            }
            else
            {
                StartGame.Enabled = false;
            }
            string[] strings = await NetworkManager.Cin();
            if(strings[0]=="StartGame")
            {
                StartGame.Enabled = true;
                StartGame.PerformClick();
            }
            else
            {
                throw new Exception("Unexcepted command : "+strings[0]);
            }
        }

        private void Player1TokenColour_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
