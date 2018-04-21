using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class Player
{
    string Name;
    int Token;
    int Balance;
    List<City> OwnedCities;
    List<Station> OwnedStations;
    Point Position;
    int Fieldnumber;

    public Player()
    {
        Balance = 2000;
        OwnedCities = new List<City>();
        OwnedStations = new List<Station>();
    }
    public void Set_Fieldnumber(int number)
    {
        Fieldnumber = number;
    }
    public int Get_Fieldnumber()
    {
        return Fieldnumber;
    }
    public void Set_Name(string name)
    {
        Name = name;
    }
    public string Get_Name()
    {
        return Name;
    }
    public void Set_Token(int token)
    {
        Token = token;
    }
    public int Get_Token()
    {
        return Token;
    }
    public void Set_Balance(int balance)
    {
        Balance = balance;
    }
    public int Get_Balance()
    {
        return Balance;
    }
    public List<City> Get_OwnedCities()
    {
        return OwnedCities;
    }
    public List<Station> Get_OwnedStations()
    {
        return OwnedStations;
    }
    public void Set_PlayerPosition(Point position)
    {
        Position = position;
    }
    public Point Get_PlayerPosition()
    {
        return Position;
    }
    public bool Buy_City(City city)
    {
        if (Balance >= city.Get_Price())
        {
            OwnedCities.Add(city);
            Balance -= city.Get_Price();
            city.Set_Owned();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Buy_Station(Station station)
    {
        if (Balance >= station.Get_Price())
        {
            OwnedStations.Add(station);
            Balance -= station.Get_Price();
            station.Set_Owned();
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MortagageCity(City city)
    {
        Balance += city.Get_MortagagePrice();
        city.Set_ISMortagaged();
    }
    public void MortagageStation(Station station)
    {
        Balance += station.Get_MortagagePrice();
        station.Set_ISMortagaged();
    }
    public bool Remove_City_Mortagage(City city)
    {
        if (Balance >= city.Get_MortagagePrice())
        {
            Balance -= city.Get_MortagagePrice();
            city.Remove_Mortagage();
            return true;
        }
        return false;
    }
    public bool Remove_Station_Mortagage(Station station)
    {
        if (Balance >= station.Get_MortagagePrice())
        {
            Balance -= station.Get_MortagagePrice();
            station.Remove_Mortagage();
            return true;
        }
        return false;

    }
    public bool Pay_CityRents(City city)
    {
        if (city.Get_HouseModification())
        {
            if (city.Get_HotelModification())
            {
                if (Balance >= city.Get_RentWithHotel())
                {
                    Balance -= city.Get_RentWithHotel();
                    city.Get_Owner().Balance += city.Get_RentWithHotel();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int Houses = city.Get_NumberOfHouses();
                if (Balance >= city.Get_HouseRentPrices()[Houses - 1])
                {
                    Balance -= city.Get_HouseRentPrices()[Houses - 1];
                    city.Get_Owner().Balance += city.Get_HouseRentPrices()[Houses - 1];
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            if (Balance >= city.Get_CityRentPrice())
            {
                Balance -= city.Get_CityRentPrice();
                city.Get_Owner().Balance += city.Get_CityRentPrice();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool Pay_StationRents(Station station)
    {
        if (Balance >= station.Get_RentPrices()[station.Get_Owner().Get_OwnedStations().Count - 1])
        {
            Balance -= station.Get_RentPrices()[station.Get_Owner().Get_OwnedStations().Count - 1];
            station.Get_Owner().Balance += station.Get_RentPrices()[station.Get_Owner().Get_OwnedStations().Count - 1];
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Buy_House(City city)
    {
        if (Balance >= city.Get_HousePrice())
        {
            if (city.Get_NumberOfHouses() == 4)
            {
                return false;
            }
            else
            {
                if (city.Get_NumberOfHouses() == 0)
                {
                    city.AddHouse();
                    city.Set_HouseModification();
                    Balance -= city.Get_HousePrice();
                    return true;
                }
                else
                {
                    city.AddHouse();
                    Balance -= city.Get_HousePrice();
                    return true;
                }
            }

        }
        else
        {
            return false;
        }
    }
    public void Sell_House(City city)
    {
        if (city.Get_NumberOfHouses() == 1)
        {
            city.SellHouse();
            city.Remove_HouseMofidication();
            Balance += city.Get_HousePrice();
        }
        else
        {
            city.SellHouse();
            Balance += city.Get_HousePrice();
        }
    }
    public bool Buy_Hotel(City city)
    {
        if (Balance >= city.Get_HotelPrice())
        {
            Balance -= city.Get_HotelPrice();
            city.Set_HotelModification();
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Sell_Hotel(City city)
    {
        city.Remove_HotelMofidication();
        Balance += city.Get_HotelPrice();
    }
}
