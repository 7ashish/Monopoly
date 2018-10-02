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
    int NumberofHouses;
    bool HouseModification;
    bool HotelModification;
    //Defualt constructor.
    public City() : base()
    {
        HouseRentPrices = new int[4];
        HouseModification = false;
        HotelModification = false;
        HotelPrice = 0;
        HousePrice = 0;
        RentWithHotel = 0;
        CityRentPrice = 0;
        NumberofHouses = 0;
    }
    //Parameterized constructor.
    public City(Monopoly.Monopoly p, int fieldnumber, Point fieldpostion, string name, int price, int mortageprice, int groupnumber, int hotelprice, int houseprice, int[] rentwithhouse, int rentwithhotel, int cityrentprice) : base(p, fieldnumber, fieldpostion, name, price, mortageprice)
    {
        HouseModification = false;
        HotelModification = false;
        GroupNumber = groupnumber;
        HotelPrice = hotelprice;
        NumberofHouses = 0;
        HouseRentPrices = new int[4];
        for (int i = 0; i < 4; i++)
        {
            HouseRentPrices[i] = rentwithhouse[i];
        }
        HousePrice = hotelprice;
        RentWithHotel = rentwithhotel;
        CityRentPrice = cityrentprice;
    }
    //overriding the pure virtual function Action.
    public override void Action(Player player)
    {
        if (Get_Owned())
        {
            if (player.IsCityOwned(this))
            {
                return;
            }
            else
            {
                if (!Get_ISMortagaged())
                {
                    GetForm().Set_Payrent();
                }
            }
        }
        else
        {
            string FolderPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
            FolderPath += @"\Pictures";
            switch (Get_FieldNumber())
            {
                case 1:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Park Lane.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 3:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Mayfair.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 5:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Fleet street.PNG");
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
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\Coventry street.PNG");
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
            GetForm().Set_CityPriceTextBox(Get_Price());
        }
    }
    //Returns the city to it's original status.
    public void ReturnCity()
    {
        NumberofHouses = 0;
        Remove_HouseMofidication();
        Remove_HotelMofidication();
        Remove_Mortagage();
        Remove_Owner();
    }
    //Sets the group number of the city.
    public void Set_GroupNumber(int group)
    {
        GroupNumber = group;
    }
    //Gets the group number of the city.
    public int Get_GroupNumber()
    {
        return GroupNumber;
    }
    //increment the number of Houses of the city.
    public void AddHouse()
    {
        NumberofHouses++;
    }
    //returns the number of houses of this city.
    public int Get_NumberOfHouses()
    {
        return NumberofHouses;
    }
    //decrement the number of houses of the city.
    public void SellHouse()
    {
        NumberofHouses--;
    }
    //Sets the house price.
    public void Set_HousePrice(int price)
    {
        HousePrice = price;
    }
    //returns the house price.
    public int Get_HousePrice()
    {
        return HousePrice;
    }
    //Sets the rent of the city.
    public void Set_CityRentPrice(int price)
    {
        CityRentPrice = price;
    }
    //gets the rent of the city.
    public int Get_CityRentPrice()
    {
        return CityRentPrice;
    }
    //Sets the rent of City with Hotel.
    public void Set_RentWithHotel(int price)
    {
        RentWithHotel = price;
    }
    //returns the rent price of city with hotel.
    public int Get_RentWithHotel()
    {
        return RentWithHotel;
    }
    //Sets the House rent prices of a specific city.
    public void Set_HouseRentPrices(int[] prices)
    {
        HouseRentPrices = prices;
    }
    //Returns the House rent prices of a specific city.
    public int[] Get_HouseRentPrices()
    {
        return HouseRentPrices;
    }
    //Sets the Hotel price of the city.
    public void Set_HotelPrice(int price)
    {
        HotelPrice = price;
    }
    //Returns the Hotel price of the city.
    public int Get_HotelPrice()
    {
        return HotelPrice;
    }
    //Sets the HouseModification bool to true.
    public void Set_HouseModification()
    {
        HouseModification = true;
    }
    //Sets the HouseModification bool to false.
    public void Remove_HouseMofidication()
    {
        HouseModification = false;
    }
    //Returns the HouseModification bool.
    public bool Get_HouseModification()
    {
        return HouseModification;
    }
    //Sets the HotelModification bool to true.
    public void Set_HotelModification()
    {
        HotelModification = true;
    }
    //Sets the HotelModification bool to false.
    public void Remove_HotelMofidication()
    {
        HotelModification = false;
    }
    //Returns the HotelModification bool.
    public bool Get_HotelModification()
    {
        return HotelModification;
    }
}
