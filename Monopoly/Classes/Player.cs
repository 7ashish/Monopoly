using System.Collections.Generic;
using System.Drawing;

public class Player
{
    public string Name { get; set; }
    public int Balance { get; set; }
    public int Token { get; set; }
    public int BalanceFeedback { get; set; }
    public int MyProperty { get; set; }
    public int Fieldnumber { get; set; }
    public List<City> OwnedCities { get; set; }
    public List<Station> OwnedStations { get; set; }
    public Point Position { get; set; }
    //Defualt Constructor.
    public Player()
    {
        Fieldnumber = 0;
        Balance = 1500;
        BalanceFeedback = 0;
        OwnedCities = new List<City>();
        OwnedStations = new List<Station>();
    }
    //Parameterized constructor.
    public Player(string name, int token, int balance, Point position, int fieldnumber)
    {
        Name = name;
        Token = token;
        Balance = balance;
        Position = position;
        Fieldnumber = fieldnumber;
        OwnedCities = new List<City>();
        OwnedStations = new List<Station>();
    }
    //This Function increments the Balance of the player with the money int.
    public void Collect_Money(int money)
    {
        BalanceFeedback = 0;
        Balance += money;
        BalanceFeedback += money;
    }
    //This Function decrements the Balance of the player with the tax int.
    public void Pay_Tax(int tax)
    {
        BalanceFeedback = 0;
        Balance -= tax;
        BalanceFeedback -= tax;
    }
    //This function buys a specific city.
    public bool Buy_City(City city)
    {
        if (Balance >= city.Price)
        {
            BalanceFeedback = 0;
            OwnedCities.Add(city);
            Balance -= city.Price;
            BalanceFeedback -= city.Price;
            city.Owned = true;
            city.Owner = this;
            return true;
        }
        else
        {
            return false;
        }
    }
    //This function buys a sepcific station.
    public bool Buy_Station(Station station)
    {
        if (Balance >= station.Price)
        {
            BalanceFeedback = 0;
            OwnedStations.Add(station);
            Balance -= station.Price;
            BalanceFeedback -= station.Price;
            station.Owned = true;
            station.Owner = this;
            return true;
        }
        else
        {
            return false;
        }
    }
    //This function checks whether this player owns a specific city or not.
    //returns true if he owns it and false if not.
    public bool IsCityOwned(City city)
    {
        if (OwnedCities.Contains(city))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //This function checks whether this player owns a specific Station or not.
    //returns true if he owns it and false if not.
    public bool IsStationOwned(Station station)
    {
        if (OwnedStations.Contains(station))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //This function Mortagage a specific city.
    public void MortagageCity(City city)
    {
        BalanceFeedback = 0;
        Balance += city.MortagagePrice;
        BalanceFeedback += city.MortagagePrice;
        city.ISMortagaged = true;
    }
    //This function Mortagage a specific Station.
    public void MortagageStation(Station station)
    {
        BalanceFeedback = 0;
        Balance += station.MortagagePrice;
        BalanceFeedback += station.MortagagePrice;
        station.ISMortagaged = true;
    }
    //This function takes a city to remove it's mortagage.
    public bool Remove_City_Mortagage(City city)
    {
        if (Balance >= city.MortagagePrice)
        {
            BalanceFeedback = 0;
            Balance -= city.MortagagePrice;
            BalanceFeedback -= city.MortagagePrice;
            city.ISMortagaged=false;
            return true;
        }
        return false;
    }
    //This function takes a station to remove it's mortagage.
    public bool Remove_Station_Mortagage(Station station)
    {
        if (Balance >= station.MortagagePrice)
        {
            BalanceFeedback = 0;
            Balance -= station.MortagagePrice;
            BalanceFeedback -= station.MortagagePrice;
            station.ISMortagaged=false;
            return true;
        }
        return false;

    }
    //This function pays rents for a specific city.
    public void Pay_CityRents(City city)
    {
        if (city.HouseModification)
        {
            if (city.HotelModification)
            {
                BalanceFeedback = 0;
                Balance -= city.RentWithHotel;
                BalanceFeedback -= city.RentWithHotel;
                city.Owner.Balance += city.RentWithHotel;
            }
            else
            {
                BalanceFeedback = 0;
                int Houses = city.NumberofHouses;
                Balance -= city.HouseRentPrices[Houses - 1];
                BalanceFeedback -= city.HouseRentPrices[Houses - 1]; 
                city.Owner.Balance += city.HouseRentPrices[Houses - 1];
            }
        }
        else
        {
            BalanceFeedback = 0;
            Balance -= city.CityRentPrice;
            BalanceFeedback -= city.CityRentPrice;
            city.Owner.Balance += city.CityRentPrice;
        }
    }
    //This function pays rents for a specific city.
    public void Pay_StationRents(Station station)
    {
        BalanceFeedback = 0;
        Balance -= station.Get_RentPrices()[station.Owner.OwnedStations.Count - 1];
        BalanceFeedback -= station.Get_RentPrices()[station.Owner.OwnedStations.Count - 1];
        station.Owner.Balance += station.Get_RentPrices()[station.Owner.OwnedStations.Count - 1];
    }
    //Check whether I could buy a house on this city or not.
    public bool Buy_House(City city)
    {
        if (Balance >= city.HousePrice)
        {
            if (city.NumberofHouses == 4)
            {
                return false;
            }
            else
            {
                if (city.NumberofHouses == 0)
                {
                    BalanceFeedback = 0;
                    city.AddHouse();
                    city.HouseModification = true;
                    Balance -= city.HousePrice;
                    BalanceFeedback -= city.HousePrice;
                    return true;
                }
                else
                {
                    BalanceFeedback = 0;
                    city.AddHouse();
                    Balance -= city.HousePrice;
                    BalanceFeedback -= city.HousePrice;
                    return true;
                }
            }

        }
        else
        {
            return false;
        }
    }
    //Sells a house on a specific city.
    public void Sell_House(City city)
    {
        if (city.NumberofHouses == 1)
        {
            BalanceFeedback = 0;
            city.SellHouse();
            city.HouseModification = false;
            Balance += city.HousePrice;
            BalanceFeedback += city.HousePrice;
        }
        else
        {
            BalanceFeedback = 0;
            city.SellHouse();
            Balance += city.HousePrice;
            BalanceFeedback += city.HousePrice;
        }
    }
    //Checks whether I could buy a hotel on this city or not.
    public bool Buy_Hotel(City city)
    {
        if (Balance >= city.HotelPrice)
        {
            BalanceFeedback = 0;
            Balance -= city.HotelPrice;
            BalanceFeedback -= city.HotelPrice;
            city.HotelModification = true;
            return true;
        }
        else
        {
            return false;
        }
    }
    //Sells a hotel on a specific city.
    public void Sell_Hotel(City city)
    {
        BalanceFeedback = 0;
        city.HotelModification = false;
        Balance += city.HotelPrice;
        BalanceFeedback += city.HotelPrice;
    }
    //This Function Checks if the player owns the whole Group of Cities or not.
    public bool IsGroupOwned(City city, Monopoly_Master Temp)
    {
        bool owned = false;
        var ThisGroup = (List<City>)Temp.Groups[city.GroupNumber];
        foreach(City GroupCity in ThisGroup)
        {
            if (OwnedCities.Contains(GroupCity))
            {
                owned = true;
            }
            else
            {
                owned = false;
                break;
            }
        }
        return owned;
    }
    //This function returns all the Cities and Stations owned by this player to it's original status.
    public void Surrender()
    {
        if (OwnedCities.Count != 0)
        {
            foreach(City city in OwnedCities)
            {
                city.ReturnCity();
            }
        }
        if (OwnedStations.Count != 0)
        {
            foreach (Station station in OwnedStations)
            {
                station.Return_Station();
            }
        }
    }
}
