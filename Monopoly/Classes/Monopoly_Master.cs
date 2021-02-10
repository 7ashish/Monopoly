using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Collections;

public class Monopoly_Master
{
    public List<Player> Players { get; set; }
    public List<Field> Fields { get; set; }
    public Hashtable Groups { get; set; }
    public static int Hotels { get; set; } = 10;
    public static int Houses { get; set; } = 40;
    public int Dice1 { get; set; }
    public int Dice2 { get; set; }
    public Point DefaultPosition { get; set; }
    public Monopoly.Monopoly Form { get; set; }
    //Parameterized constructor.
    public Monopoly_Master(Monopoly.Monopoly p)
    {
        Form = p;
        Players = new List<Player>();
        Groups = new Hashtable();
        DefaultPosition = new Point(850, 530);
        Fields = new List<Field>()
        {
            new UselessFields(p,0,new Point{X=850,Y=530}),
            new City(p,1,new Point{X=718,Y=530 },"Park Lane",350,175,0,200,200,new int[]{175,500,1100,1300},1500,35,p.Get_CityLabelPanel(1)),
            new Chances(p,2,new Point{X=618,Y=530}),
            new City(p,3,new Point{X=515,Y=530 },"Mayfair",400,200,0,200,200,new int[]{200,600,1400,1700},2000,50,p.Get_CityLabelPanel(3)),
            new Station(p,4,new Point{X=410,Y=530},"Reading Rail Road",200,100,new int[] {25,50,75,100},p.Get_CityLabelPanel(4)),
            new City(p,5,new Point{X=305,Y=530},"Fleet Street",220,110,1,150,150,new int[]{90,250,700,875},1050,18,p.Get_CityLabelPanel(5)),
            new City(p,6,new Point{X=200,Y=530},"Strand",220,110,1,150,150,new int[]{90,250,700,875},1050,18,p.Get_CityLabelPanel(6)),
            new UselessFields(p,7,new Point{X=80,Y=530}),
            new City(p,8,new Point{X=80,Y=430 },"White Hall", 140, 70, 2, 100, 100, new int[] { 50, 150, 450, 625 }, 750, 10,p.Get_CityLabelPanel(8) ),
            new City(p,9,new Point{X=80,Y=340 },"Pall Mall", 140, 70, 2, 100, 100, new int[]{ 50, 150, 450, 650 }, 750, 10,p.Get_CityLabelPanel(9)),
            new City(p,10,new Point{X=79,Y=260 },"Whitechapel", 60, 50, 3, 30, 30, new int[] { 20, 60, 180, 360 }, 550, 6,p.Get_CityLabelPanel(10)),
            new City(p,11,new Point{X=80,Y=175 },"Old Kent", 60, 50, 3, 30, 30, new int[]{ 10,30,90,160}, 250,2,p.Get_CityLabelPanel(11)),
            new UselessFields(p,12,new Point{X=80,Y=80 }),
            new City(p,13,new Point(210,80),"Leicester Square",260,150,4,150,150,new int[]{110,330,800,975},1150,22,p.Get_CityLabelPanel(13)),
            new Community_Chest(p,14,new Point(310,80)),
            new City(p,15,new Point(410,80),"Coventry Street",220,150,4,150,150,new int[]{110,330,800,975},1150,22,p.Get_CityLabelPanel(15)),
            new Station(p,16,new Point(510,80),"B&O Rail Road",200,100,new int[]{25,50,75,100},p.Get_CityLabelPanel(16)),
            new City(p,17,new Point(620,80),"Oxford Street",300,200,5,150,150,new int[]{130,390,900,1100},1275,26,p.Get_CityLabelPanel(17)),
            new City(p,18,new Point(722,80),"Regent Street",220,200,5,150,150,new int[]{130,390,900,1100},1275,36,p.Get_CityLabelPanel(18)),
            new GoToJail(p,19,new Point(850,80)),
            new City(p,20,new Point(850,175),"Vine Street",200,100,6,100,100,new int[]{80,220,600,800 },1000,16,p.Get_CityLabelPanel(20)),
            new City(p,21,new Point(850,260),"Bow Street", 180, 90, 6, 100, 100,new int[] { 70, 200, 550, 750 }, 950, 14,p.Get_CityLabelPanel(21)),
            new City(p,22,new Point(850,345),"Euston Road", 100, 50, 7, 50, 50, new int[] { 30, 90, 270, 400 }, 550, 6,p.Get_CityLabelPanel(22)),
            new City(p,23,new Point(850,430),"Pentonville Road", 120, 60, 7, 50, 50, new int[] { 40, 100, 300, 450 }, 600, 8,p.Get_CityLabelPanel(23))
        };
        List<City> Tempo = new List<City>();
        Tempo.Add((City)Fields[1]);
        Tempo.Add((City)Fields[3]);
        Groups.Add(0,Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[5]);
        Tempo.Add((City)Fields[6]);
        Groups.Add(1,Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[8]);
        Tempo.Add((City)Fields[9]);
        Groups.Add(2,Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[10]);
        Tempo.Add((City)Fields[11]);
        Groups.Add(3,Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[13]);
        Tempo.Add((City)Fields[15]);
        Groups.Add(4,Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[17]);
        Tempo.Add((City)Fields[18]);
        Groups.Add(5,Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[20]);
        Tempo.Add((City)Fields[21]);
        Groups.Add(6,Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[22]);
        Tempo.Add((City)Fields[23]);
        Groups.Add(7,Tempo);
    }
    static Random r = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);
    //This function choose number from 1-6 randomly.
    public int RollDice()
    {
        return r.Next(1, 7);
    }
    //This Function takes a player and City he wish to Mortagage and Checks if he can Mortagage it or not.
    public bool Mortagage_City(Player playerturn, City city)
    {
        if (city.Owner == playerturn)
        {
            if (!city.ISMortagaged)
            {
                if (city.HouseModification)
                {
                    return false;
                }
                else
                {
                    playerturn.MortagageCity(city);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    //This Function takes a player and Station he wish to Mortagage and Checks if he can Mortagage it or not.
    public bool Mortagage_Station(Player playerturn, Station station)
    {
        if (station.Owner == playerturn)
        {
            if (!station.ISMortagaged)
            {
                playerturn.MortagageStation(station);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    //This Function takes a player and City he wish to Remove the Mortagage and Checks if he can Remove Mortagage or not.
    public bool RemoveCityMortagage(Player playerturn, City city)
    {
        if (city.Owner == playerturn)
        {
            if (city.ISMortagaged)
            {
                if (playerturn.Remove_City_Mortagage(city))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        return false;
    }
    //This Function takes a player and Station he wish to Remove the Mortagage and Checks if he can Remove Mortagage or not.
    public bool RemoveStationMortagage(Player playerturn, Station station)
    {
        if (station.Owner == playerturn)
        {
            if (station.ISMortagaged)
            {
                if (playerturn.Remove_Station_Mortagage(station))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        return false;
    }
    //This Function takes a Player and City he wish to Upgrade & Checks if he can Buy a house or not.
    public bool Sell_House(Player playerturn, City city)
    {
        if (!city.ISMortagaged)
        {
            if (playerturn.IsGroupOwned(city,this))
            {
                if (Houses != 0)
                {
                    if (playerturn.Buy_House(city))
                    {
                        Houses--;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    //This Function takes a Player and City he wish to Upgrade & Checks if he can Sell a house or not.
    public bool Remove_House(Player playerturn, City city)
    {
        if (!playerturn.OwnedCities.Contains(city))  //I'm making sure that this player own this city
        {
            return false;
        }
        else if (!city.HouseModification)           //I'm making sure that this city has houses on it and not mortagaged
        {
            return false;
        }
        else if (city.HotelModification)            //Making sure that the City have no hotels.
        {
            return false;
        }
        else
        {
            playerturn.Sell_House(city);
            Houses++;
            return true;
        }
    }
    //This Function takes a Player and City he wish to Upgrade & Checks if he can Buy a hotel or not.
    public bool Sell_Hotel(Player playerturn, City city)
    {
        if (city.Owner == playerturn)
        {
            if (!city.HouseModification)
            {
                return false;
            }
            else if (city.NumberofHouses != 4)
            {
                return false;
            }
            else if (city.HotelModification)
            {
                return false;
            }
            else if (Hotels == 0)
            {
                return false;
            }
            else
            {
                if (playerturn.Buy_Hotel(city))
                {
                    Hotels--;
                    return true;
                }
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    //This Function takes a Player and City he wish to Upgrade & Checks if he can sell a hotel or not.
    public bool Remove_Hotel(Player playerturn, City city)
    {
        if (!playerturn.OwnedCities.Contains(city))  //I'm making sure that this player own this city
        {
            return false;
        }
        else if (!city.HouseModification)           //I'm making sure that this city has houses on it and not mortagaged
        {
            return false;
        }
        else if (!city.HotelModification)            //Making sure that the City has a hotel + 4 houses on it.
        {
            return false;
        }
        else
        {
            playerturn.Sell_Hotel(city);
            Hotels++;
            return true;
        }
    }
    // This Function takes a Player & Checks if his balance is negative or not.
    // If the Balance is Negative it returns false, else it returns true.
    public bool Check_PlayerBalance(Player playerturn)
    {
        if (playerturn.Balance < 0)
        {
            return false;
        }
        else return true;
    }
    /// <summary>
    /// Moves the Player
    /// </summary>
    /// <param name="player">The player that needs to be moved</param>
    public void Move_Player(Player player)
    {
        Form.GetTimer(player.Token).Start();
    }
}
