using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

public class Monopoly_Master
{
    List<Player> Players;
    public List<Field> Fields;
    List<List<City>> Groups;
    static int Hotels = 10;
    static int Houses = 40;
    int Dice1;
    int Dice2;
    Point DefaultPosition;
    public Monopoly.Monopoly Form;
    //Parameterized constructor.
    public Monopoly_Master(Monopoly.Monopoly p)
    {
        Form = p;
        Players = new List<Player>();
        Groups = new List<List<City>>();
        DefaultPosition = new Point(850, 530);
        Fields = new List<Field>()
        {
            new UselessFields(p,0,new Point{X=850,Y=530}),
            new City(p,1,new Point{X=718,Y=530 },"Park Lane",350,175,0,200,200,new int[]{175,500,1100,1300},1500,35),
            new Chances(p,2,new Point{X=618,Y=530}),
            new City(p,3,new Point{X=515,Y=530 },"Mayfair",400,200,0,200,200,new int[]{200,600,1400,1700},2000,50),
            new Station(p,4,new Point{X=410,Y=530},"Reading Rail Road",200,100,new int[] {25,50,75,100}),
            new City(p,5,new Point{X=305,Y=530},"Fleet Street",220,110,1,150,150,new int[]{90,250,700,875},1050,18),
            new City(p,6,new Point{X=200,Y=530},"Strand",220,110,1,150,150,new int[]{90,250,700,875},1050,18),
            new UselessFields(p,7,new Point{X=80,Y=530}),
            new City(p,8,new Point{X=80,Y=430 },"White Hall", 140, 70, 2, 100, 100, new int[] { 50, 150, 450, 625 }, 750, 10 ),
            new City(p,9,new Point{X=80,Y=340 },"Pall Mall", 140, 70, 2, 100, 100, new int[]{ 50, 150, 450, 650 }, 750, 10),
            new City(p,10,new Point{X=79,Y=260 },"Whitechapel", 60, 50, 3, 30, 30, new int[] { 20, 60, 180, 360 }, 550, 6),
            new City(p,11,new Point{X=80,Y=175 },"Old Kent", 60, 50, 3, 30, 30, new int[]{ 10,30,90,160}, 250,2),
            new UselessFields(p,12,new Point{X=80,Y=80 }),
            new City(p,13,new Point(210,80),"Leicester Square",260,150,4,150,150,new int[]{110,330,800,975},1150,22),
            new Community_Chest(p,14,new Point(310,80)),
            new City(p,15,new Point(410,80),"Coventry Street",220,150,4,150,150,new int[]{110,330,800,975},1150,22),
            new Station(p,16,new Point(510,80),"B&O Rail Road",200,100,new int[]{25,50,75,100}),
            new City(p,17,new Point(620,80),"Oxford Street",300,200,5,150,150,new int[]{130,390,900,1100},1275,26),
            new City(p,18,new Point(722,80),"Regent Street",220,200,5,150,150,new int[]{130,390,900,1100},1275,36),
            new GoToJail(p,19,new Point(850,80)),
            new City(p,20,new Point(850,175),"Vine Street",200,100,6,100,100,new int[]{80,220,600,800 },1000,16),
            new City(p,21,new Point(850,260),"Bow Street", 180, 90, 6, 100, 100,new int[] { 70, 200, 550, 750 }, 950, 14),
            new City(p,22,new Point(850,345),"Euston Road", 100, 50, 7, 50, 50, new int[] { 30, 90, 270, 400 }, 550, 6),
            new City(p,23,new Point(850,430),"Pentonville Road", 120, 60, 7, 50, 50, new int[] { 40, 100, 300, 450 }, 600, 8)
        };
        List<City> Tempo = new List<City>();
        Tempo.Add((City)Fields[1]);
        Tempo.Add((City)Fields[3]);
        Groups.Add(Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[5]);
        Tempo.Add((City)Fields[6]);
        Groups.Add(Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[8]);
        Tempo.Add((City)Fields[9]);
        Groups.Add(Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[10]);
        Tempo.Add((City)Fields[11]);
        Groups.Add(Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[13]);
        Tempo.Add((City)Fields[15]);
        Groups.Add(Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[17]);
        Tempo.Add((City)Fields[18]);
        Groups.Add(Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[20]);
        Tempo.Add((City)Fields[21]);
        Groups.Add(Tempo);
        Tempo = new List<City>();
        Tempo.Add((City)Fields[22]);
        Tempo.Add((City)Fields[23]);
        Groups.Add(Tempo);
    }
    //returns Point(X,Y) with the defualt position.
    public Point GetDefaultPosition()
    {
        return DefaultPosition;
    }
    //returns the List of the Fields.
    public List<Field> Get_Fields()
    {
        return Fields;
    }
    static Random r = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);
    //This function choose number from 1-6 randomly.
    public int RollDice()
    {
        return r.Next(1, 7);
    }
    //Sets the players by a List.
    public void SetPlayers(List<Player> players)
    {
        Players = players;
    }
    //returns the Groups list.
    public List<List<City>> GetGroups()
    {
        return Groups;
    }
    //returns the Fields list.
    public List<Field> GetFields()
    {
        return Fields;
    }
    //returns the players list.
    public List<Player> GetPlayers()
    {
        return Players;
    }
    //Sets the first Dice after using the Random function.
    public void Set_Dice1(int number)
    {
        Dice1 = number;
    }
    //Sets the second Dice after using the Random function.
    public void Set_Dice2(int number)
    {
        Dice2 = number;
    }
    //returns the number of the first Dice.
    public int Get_Dice1()
    {
        return Dice1;
    }
    //returns the number of the second Dice.
    public int Get_Dice2()
    {
        return Dice2;
    }
    //This Function takes a player and City he wish to Mortagage and Checks if he can Mortagage it or not.
    public bool Mortagage_City(Player playerturn, City city)
    {
        if (city.Get_Owner() == playerturn)
        {
            if (!city.Get_ISMortagaged())
            {
                if (city.Get_HouseModification())
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
        if (station.Get_Owner() == playerturn)
        {
            if (!station.Get_ISMortagaged())
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
        if (city.Get_Owner() == playerturn)
        {
            if (city.Get_ISMortagaged())
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
        if (station.Get_Owner() == playerturn)
        {
            if (station.Get_ISMortagaged())
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
        if (!city.Get_ISMortagaged())
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
        if (!playerturn.Get_OwnedCities().Contains(city))  //I'm making sure that this player own this city
        {
            return false;
        }
        else if (!city.Get_HouseModification())           //I'm making sure that this city has houses on it and not mortagaged
        {
            return false;
        }
        else if (city.Get_HotelModification())            //Making sure that the City have no hotels.
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
        if (city.Get_Owner() == playerturn)
        {
            if (!city.Get_HouseModification())
            {
                return false;
            }
            else if (city.Get_NumberOfHouses() != 4)
            {
                return false;
            }
            else if (city.Get_HotelModification())
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
        if (!playerturn.Get_OwnedCities().Contains(city))  //I'm making sure that this player own this city
        {
            return false;
        }
        else if (!city.Get_HouseModification())           //I'm making sure that this city has houses on it and not mortagaged
        {
            return false;
        }
        else if (!city.Get_HotelModification())            //Making sure that the City has a hotel + 4 houses on it.
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
        if (playerturn.Get_Balance() < 0)
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
        Form.GetTimer(player.Get_Token()).Start();
    }
}
