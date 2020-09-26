using System.Collections.Generic;
using System.Drawing;

public class Player
{
    string Name;
    int Token;
    int Balance;
    int BalanceFeedback;
    List<City> OwnedCities;
    List<Station> OwnedStations;
    Point Position;
    int Fieldnumber;
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
    //Sets the Fieldnumber of the player.
    public void Set_Fieldnumber(int number)
    {
        Fieldnumber = number;
    }
    //Gets the Field number of the player.
    public int Get_Fieldnumber()
    {
        return Fieldnumber;
    }
    //Sets the name of the player.
    public void Set_Name(string name)
    {
        Name = name;
    }
    //Gets the name of the player.
    public string Get_Name()
    {
        return Name;
    }
    //Sets the token of the player.
    public void Set_Token(int token)
    {
        Token = token;
    }
    //Gets the token of the player.
    public int Get_Token()
    {
        return Token;
    }
    //Sets the balance of the player.
    public void Set_Balance(int balance)
    {
        Balance = balance;
    }
    //Gets the balance of the player.
    public int Get_Balance()
    {
        return Balance;
    }
    public void Set_Balance_Feedback(int balance)
    {
        BalanceFeedback = balance;
    }
    public int Get_Balance_Feedback()
    {
        return BalanceFeedback;
    }
    //Gets the list of the owned cities.
    public List<City> Get_OwnedCities()
    {
        return OwnedCities;
    }
    //Gets the list of the owned stations.
    public List<Station> Get_OwnedStations()
    {
        return OwnedStations;
    }
    //Sets the player position.
    public void Set_PlayerPosition(Point position)
    {
        Position = position;
    }
    //Gets player position.
    public Point Get_PlayerPosition()
    {
        return Position;
    }
    //This function buys a specific city.
    public bool Buy_City(City city)
    {
        if (Balance >= city.Get_Price())
        {
            BalanceFeedback = 0;
            OwnedCities.Add(city);
            Balance -= city.Get_Price();
            BalanceFeedback -= city.Get_Price();
            city.Set_Owned();
            city.Set_Owner(this);
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
        if (Balance >= station.Get_Price())
        {
            BalanceFeedback = 0;
            OwnedStations.Add(station);
            Balance -= station.Get_Price();
            BalanceFeedback -= station.Get_Price();
            station.Set_Owned();
            station.Set_Owner(this);
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
        Balance += city.Get_MortagagePrice();
        BalanceFeedback += city.Get_MortagagePrice();
        city.Set_ISMortagaged();
    }
    //This function Mortagage a specific Station.
    public void MortagageStation(Station station)
    {
        BalanceFeedback = 0;
        Balance += station.Get_MortagagePrice();
        BalanceFeedback += station.Get_MortagagePrice();
        station.Set_ISMortagaged();
    }
    //This function takes a city to remove it's mortagage.
    public bool Remove_City_Mortagage(City city)
    {
        if (Balance >= city.Get_MortagagePrice())
        {
            BalanceFeedback = 0;
            Balance -= city.Get_MortagagePrice();
            BalanceFeedback -= city.Get_MortagagePrice();
            city.Remove_Mortagage();
            return true;
        }
        return false;
    }
    //This function takes a station to remove it's mortagage.
    public bool Remove_Station_Mortagage(Station station)
    {
        if (Balance >= station.Get_MortagagePrice())
        {
            BalanceFeedback = 0;
            Balance -= station.Get_MortagagePrice();
            BalanceFeedback -= station.Get_MortagagePrice();
            station.Remove_Mortagage();
            return true;
        }
        return false;

    }
    //This function pays rents for a specific city.
    public void Pay_CityRents(City city)
    {
        if (city.Get_HouseModification())
        {
            if (city.Get_HotelModification())
            {
                BalanceFeedback = 0;
                Balance -= city.Get_RentWithHotel();
                BalanceFeedback -= city.Get_RentWithHotel();
                city.Get_Owner().Balance += city.Get_RentWithHotel();
            }
            else
            {
                BalanceFeedback = 0;
                int Houses = city.Get_NumberOfHouses();
                Balance -= city.Get_HouseRentPrices()[Houses - 1];
                BalanceFeedback -= city.Get_HouseRentPrices()[Houses - 1]; 
                city.Get_Owner().Balance += city.Get_HouseRentPrices()[Houses - 1];
            }
        }
        else
        {
            BalanceFeedback = 0;
            Balance -= city.Get_CityRentPrice();
            BalanceFeedback -= city.Get_CityRentPrice();
            city.Get_Owner().Balance += city.Get_CityRentPrice();
        }
    }
    //This function pays rents for a specific city.
    public void Pay_StationRents(Station station)
    {
        BalanceFeedback = 0;
        Balance -= station.Get_RentPrices()[station.Get_Owner().Get_OwnedStations().Count - 1];
        BalanceFeedback -= station.Get_RentPrices()[station.Get_Owner().Get_OwnedStations().Count - 1];
        station.Get_Owner().Balance += station.Get_RentPrices()[station.Get_Owner().Get_OwnedStations().Count - 1];
    }
    //Check whether I could buy a house on this city or not.
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
                    BalanceFeedback = 0;
                    city.AddHouse();
                    city.Set_HouseModification();
                    Balance -= city.Get_HousePrice();
                    BalanceFeedback -= city.Get_HousePrice();
                    return true;
                }
                else
                {
                    BalanceFeedback = 0;
                    city.AddHouse();
                    Balance -= city.Get_HousePrice();
                    BalanceFeedback -= city.Get_HousePrice();
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
        if (city.Get_NumberOfHouses() == 1)
        {
            BalanceFeedback = 0;
            city.SellHouse();
            city.Remove_HouseMofidication();
            Balance += city.Get_HousePrice();
            BalanceFeedback += city.Get_HousePrice();
        }
        else
        {
            BalanceFeedback = 0;
            city.SellHouse();
            Balance += city.Get_HousePrice();
            BalanceFeedback += city.Get_HousePrice();
        }
    }
    //Checks whether I could buy a hotel on this city or not.
    public bool Buy_Hotel(City city)
    {
        if (Balance >= city.Get_HotelPrice())
        {
            BalanceFeedback = 0;
            Balance -= city.Get_HotelPrice();
            BalanceFeedback -= city.Get_HotelPrice();
            city.Set_HotelModification();
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
        city.Remove_HotelMofidication();
        Balance += city.Get_HotelPrice();
        BalanceFeedback += city.Get_HotelPrice();
    }
    //This Function Checks if the player owns the whole Group of Cities or not.
    public bool IsGroupOwned(City city, Monopoly_Master Temp)
    {
        bool owned = false;
        for (int i = 0; i < Temp.GetGroups()[city.Get_GroupNumber()].Count; i++)
        {
            if (OwnedCities.Contains(Temp.GetGroups()[city.Get_GroupNumber()][i]))
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
            return true;
        }
        else
        {
            return false;
        }
    }
    //This function returns all the Cities and Stations owned by this player to it's original status.
    public void Surrender()
    {
        if (OwnedCities.Count != 0)
        {
            for (int i = 0; i < OwnedCities.Count; i++)
            {
                OwnedCities[i].ReturnCity();
            }
        }
        if (OwnedStations.Count != 0)
        {
            for (int i = 0; i < OwnedStations.Count; i++)
            {
                OwnedStations[i].Return_Station();
            }
        }
    }
}
