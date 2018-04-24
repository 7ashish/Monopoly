using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

public class City : Purchasable
{
    int GroupNumber;
    int HotelPrice;
    int HousePrice;
    int[] HouseRentPrices;
    int RentWithHotel;
    int CityRentPrice;
    static int NumberofHouses = 0;
    bool HouseModification;
    bool HotelModification;

    public City() : base()
    {
        HouseRentPrices = new int[4];
        HouseModification = false;
        HotelModification = false;
        HotelPrice = 0;
        HousePrice = 0;
        RentWithHotel = 0;
        CityRentPrice = 0;
    }
    public City(Monopoly.Monopoly p, int fieldnumber, Point fieldpostion, string name, int price, int mortageprice, int groupnumber, int hotelprice, int houseprice, int[] rentwithhouse, int rentwithhotel, int cityrentprice) : base(p, fieldnumber, fieldpostion, name, price, mortageprice)
    {
        HouseModification = false;
        HotelModification = false;
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
    public override void Action(Player player)
    {
        if (Get_Owned())
        {
            if (player.Get_OwnedCities().Contains(this))
            {
                return;
            }
            else
            {
                player.Pay_CityRents(this);
            }
        }
        else
        {
            string FolderPath = Directory.GetCurrentDirectory();//"C:\Users\shetos\Documents\Visual Studio 2017\Projects\Monopoly\Monopoly\bin\Debug";
            switch (Get_FieldNumber())
            {
                case 1:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath+@"\Park Lane.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 3:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Mayfair.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 5:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath+@"\Fleet street.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 6:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Strand.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 8:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\White Hall.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 9:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Pall Mall.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 10:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\whitechapel.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 11:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\old kent road.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 13:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Leicester square.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 15:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Conventy street.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 17:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Oxford street.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 18:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Regent street.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 20:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Vine street.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 21:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Bow street.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 22:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Euston road.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 23:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Pentonville road.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
            }

        }
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
