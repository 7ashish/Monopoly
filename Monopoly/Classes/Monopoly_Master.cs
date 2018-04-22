using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class Monopoly_Master
{
    List<Player> Players;
    List<Field> Fields;
    List<List<City>> Groups;
    static int Hotels = 10;
    static int Houses = 18;
    int Dice1;
    int Dice2;
    Point DefaultPosition;

   public Monopoly_Master()
    {
        Players = new List<Player>();
        Groups = new List<List<City>>();
        DefaultPosition = new Point(850, 530);
        Fields = new List<Field>()
        {
            new Go(0,new Point{X=850,Y=530}),
            new City(1,new Point{X=718,Y=530 },"Park Lane",350,175,8,200,200,new int[]{175,500,1100,1300},1500,35),
            new Chances(2,new Point{X=618,Y=530}),
            new City(3,new Point{X=515,Y=530 },"Mayfair",300,200,8,200,200,new int[]{200,600,1400,1700},2000,50),
            new Station(4,new Point{X=410,Y=530},"Reading Rail Road",200,100,new int[] {25,50,75,100}),
            new City(5,new Point{X=305,Y=530},"Fleet Street",220,110,5,150,150,new int[]{90,250,700,875},1050,18),
            new City(6,new Point{X=200,Y=530},"Strand",220,110,5,150,150,new int[]{90,250,700,875},1050,18),
            new UselessFields(7,new Point{X=80,Y=530}),
            new City(8,new Point{X=79,Y=430 },"White Hall", 140, 70, 3, 100, 100, new int[] { 50, 150, 450, 625 }, 750, 10 ),
            new City(9,new Point{X=79,Y=340 },"Pall Mall", 140, 70, 3, 100, 100, new int[]{ 50, 150, 450, 650 }, 750, 10),
            new City(10,new Point{X=79,Y=260 },"White Chapel ROad", 60, 50, 1, 30, 30, new int[] { 20, 60, 180, 360 }, 550, 6),
            new City(11,new Point{X=80,Y=175 },"old Kent Road", 60, 50, 1, 30, 30, new int[]{ 10,30,90,160}, 250,2),
            new UselessFields(12,new Point{X=80,Y=80 }),
            new City(13,new Point(210,80),"Leicester Square",260,150,6,150,150,new int[]{110,330,800,975},1150,22),
            new Community_Chest(14,new Point(310,80)),
            new City(15,new Point(410,80),"Coventry Street",220,150,6,150,150,new int[]{110,330,800,975},1150,22),
            new Station(16,new Point(510,80),"B&O Rail Road",200,100,new int[]{25,50,75,100}),
            new City(17,new Point(620,80),"Oxford Street",300,200,7,150,150,new int[]{130,390,900,1100},1275,26),
            new City(18,new Point(722,80),"Regent Street",220,200,7,150,150,new int[]{130,390,900,1100},1275,36),
            new GoToJail(19,new Point(850,80)),
            new City(20,new Point(850,175),"Vine sreet",200,100,4,100,100,new int[]{80,220,600,800 },1000,16),
            new City(21,new Point(850,260),"Bow Stret", 180, 90, 4, 100, 100,new int[] { 70, 200, 550, 750 }, 950, 14),
            new City(22,new Point(850,345),"Euston Road", 100, 50, 2, 50, 50, new int[] { 30, 90, 270, 400 }, 550, 6),
            new City(23,new Point(850,430),"Pen Tonville Road", 120, 60, 2, 50, 50, new int[] { 40, 100, 300, 450 }, 600, 8)
        };
    }
    public Point GetDefaultPosition()
    {
        return DefaultPosition;
    }
    public List<Field> Get_Fields()
    {
        return Fields;
    }
    public int RollDice()
    {
        Random rmd = new Random(new DateTime().Millisecond);
        return rmd.Next(0, 7);
    }
    public void Set_Dice1(int number)
    {
        Dice1 = number;
    }
    public void Set_Dice2(int number)
    {
        Dice2 = number;
    }
    public int Get_Dice1()
    {
        return Dice1;
    }
    public int Get_Dice2()
    {
        return Dice2;
    }
    public bool Sell_City(Player playerturn, City city)
    {
        if (!city.Get_Owned())
        {
            if (playerturn.Buy_City(city))
            {
                city.Set_Owner(playerturn);
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
    public bool Sell_Station(Player playerturn, Station station)
    {
        if (!station.Get_Owned())
        {
            if (playerturn.Buy_Station(station))
            {
                station.Set_Owner(playerturn);
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
    public bool Mortagage_City(Player playerturn, City city)
    {
        if (city.Get_Owner() == playerturn)
        {
            if (!city.Get_ISMortagaged())
            {
                playerturn.MortagageCity(city);
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
    public bool Pay_RentsOfCity(Player playerturn, City city)
    {
        if (city.Get_ISMortagaged())
        {
            return false;
        }
        else
        {
            if (playerturn.Pay_CityRents(city))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool Pay_RentsOfStation(Player playerturn, Station station)
    {

        if (station.Get_ISMortagaged())
        {
            return false;
        }
        else
        {
            if (playerturn.Pay_StationRents(station))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool Sell_House(Player playerturn, City city)
    {
        if (!city.Get_ISMortagaged())
        {
            bool owned = false;
            for (int i = 0; i < Groups[city.Get_GroupNumber()].Count; i++)
            {
                if (playerturn.Get_OwnedCities().Contains(Groups[city.Get_GroupNumber()][i]))
                {
                    owned = true;
                }
                else
                {
                    owned = false;
                    break;
                }
            }
            if (owned)
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
        else if (!city.Get_HotelModification())            //Making sure that the City have a hotel + 4 houses on it.
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
}
