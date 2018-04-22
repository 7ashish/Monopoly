using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class City : Purchasable
{
    int GroupNumber;
    int HotelPrice;
    int HousePrice;
    int[] HouseRentPrices;
    int RentWithHotel;
    int CityRentPrice;
    static int NumberofHouses=0;
    bool HouseModification;
    bool HotelModification;

    public City():base()
    {
        HouseRentPrices = new int[4];
        HouseModification = false;
        HotelModification = false;
        HotelPrice = 0;
        HousePrice = 0;
        RentWithHotel = 0;
        CityRentPrice = 0;
    }
    public City(int fieldnumber, Point fieldpostion,string name, int price, int mortageprice, int groupnumber, int hotelprice, int houseprice, int[] rentwithhouse, int rentwithhotel, int cityrentprice) : base(fieldnumber,fieldpostion,name, price, mortageprice)
    {
        GroupNumber = groupnumber;
        HotelPrice = hotelprice;
        HouseRentPrices = new int[4];
        for (int i = 0; i < 4; i++)
        {
            HouseRentPrices[i] = rentwithhouse[i];
        }
        HousePrice = hotelprice;
        RentWithHotel = rentwithhotel;
        CityRentPrice = cityrentprice;
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
    public void Set_HouseRentPrices(int[] prices)
    {
        HouseRentPrices = prices;
    }  
    public int[] Get_HouseRentPrices()
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
