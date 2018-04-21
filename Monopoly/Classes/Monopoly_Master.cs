using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Monopoly_Master
{
    List<Player> Players;
    List<Field> Fields;
    List<List<City>> Groups;
    static int Hotels = 10;
    static int Houses = 18;
    int Dice1;
    int Dice2;

   public  Monopoly_Master()
    {
        Players = new List<Player>();
        Fields = new List<Field>();
        Groups = new List<List<City>>();
    }
    public List<Field> Get_Fields()
    {
        return Fields;
    }
    public void Move_Player(Player playerturn, int Dicenumber)
    {
        int target = playerturn.Get_Fieldnumber() % 21;
        playerturn.Set_PlayerPosition(Fields[target].Get_FieldPosition());
        playerturn.Set_Fieldnumber(Fields[target].Get_FieldNumber());
    }
    public int RollDice()
    {
        Random rmd = new Random(new DateTime().Millisecond);
        return rmd.Next(1, 7);
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
