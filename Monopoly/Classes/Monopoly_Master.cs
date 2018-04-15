using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Monopoly_Master
{
    List<Player> Players;
    List<Field> Fields;
    List<List<Pair<int,City>>> Groups;
    static int Hotels = 10;
    static int Houses = 18;
    Player PlayerTurn;

    Monopoly_Master()
    {
        Players = new List<Player>();
        Fields = new List<Field>();
        Groups = new List<List<Pair<int, City>>>();
    }
    public bool Sell_City(Player playerturn,City city)
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
    public bool Sell_Station(Player playerturn,Station station)
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
    public bool Mortagage_City(Player playerturn,City city)
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
    public bool RemoveCityMortagage(Player playerturn,City city)
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
    public bool RemoveStationMortagage(Player playerturn,Station station)
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
    public bool Pay_RentsOfCity(Player playerturn,City city)
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

}
