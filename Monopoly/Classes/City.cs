using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class City : Purchasable
{
    int GroupNumber;
    int HotelPrice;
    int HousePrice;
    List<int> HouseRentPrices;
    int RentWithHotel;
    int CityRentPrice;
    static int NumberofHouses=0;
    bool HouseModification;
    bool HotelModification;

    public City()
    {
        HouseRentPrices = new List<int>();
        HouseModification = false;
        HotelModification = false;
    }
    public void Set_GroupNumber(int group)
    {
        GroupNumber = group;
    }
    public int Get_GroupNumber()
    {
        return GroupNumber;
    }
    public void AddHouse()
    {
        NumberofHouses++;
    }
    public int Get_NumberOfHouses()
    {
        return NumberofHouses;
    }
    public void SellHouse()
    {
        NumberofHouses--;
    }
    public void Set_HousePrice(int price)
    {
        HousePrice = price;
    }
    public int Get_HousePrice()
    {
        return HousePrice;
    }
    public void Set_CityRentPrice(int price)
    {
        CityRentPrice = price;
    }
    public int Get_CityRentPrice()
    {
        return CityRentPrice;
    }
    public void Set_RentWithHotel(int price)
    {
        RentWithHotel = price;
    }
    public int Get_RentWithHotel()
    {
        return RentWithHotel;
    }
    public void Set_HouseRentPrices(List<int> prices)
    {
        HouseRentPrices = prices;
    }  
    public List<int> Get_HouseRentPrices()
    {
        return HouseRentPrices;
    }
    public void Set_HotelPrice(int price)
    {
        HotelPrice = price;
    }
    public int Get_HotelPrice()
    {
        return HotelPrice;
    }
    public void Set_HouseModification()
    {
        HouseModification = true;
    }
    public void Remove_HouseMofidication()
    {
        HouseModification = false;
    }
    public bool Get_HouseModification()
    {
        return HouseModification;
    }
    public void Set_HotelModification()
    {
        HotelModification = true;
    }
    public void Remove_HotelMofidication()
    {
        HotelModification = false;
    }
    public bool Get_HotelModification()
    {
        return HotelModification;
    }
}
