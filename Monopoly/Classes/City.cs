using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class City : Purchasable
{
    public int GroupNumber { get; set; }
    public int HotelPrice { get; set; }
    public int HousePrice { get; set; }
    public int RentWithHotel { get; set; }
    public int CityRentPrice { get; set; }
    public int NumberofHouses { get; set; }
    public bool HouseModification { get; set; }
    public bool HotelModification { get; set; }
    public int[] HouseRentPrices { get; set; }
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
    public City(Monopoly.Monopoly p, int fieldnumber, Point fieldpostion, string name, int price, int mortageprice, int groupnumber, int hotelprice, int houseprice, int[] rentwithhouse, int rentwithhotel, int cityrentprice , Panel PurshableLabel) : base(p, fieldnumber, fieldpostion, name, price, mortageprice, PurshableLabel)
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
        if (this.Owned)
        {
            if (player.IsCityOwned(this))
            {
                return;
            }
            else
            {
                if (!this.ISMortagaged)
                {
                    GetForm().Set_Payrent();
                }
            }
        }
        else
        {
            string FolderPath = Directory.GetCurrentDirectory();
            FolderPath += @"\Pictures";
            var CityName = this.Name;
            GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath + @"\" + CityName + ".PNG");
            GetForm().Get_BuyingCityPanel().Show();
            GetForm().Set_CityPriceTextBox(this.Price);
        }
    }
    //Returns the city to it's original status.
    public void ReturnCity()
    {
        NumberofHouses = 0;
        this.HouseModification = false;
        this.HotelModification = false;
        this.ISMortagaged = false;
        Remove_Owner();
    }
    //Sets the group number of the city.
    public void Set_GroupNumber(int group)
    {
        GroupNumber = group;
    }
    //increment the number of Houses of the city.
    public void AddHouse()
    {
        NumberofHouses++;
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
    //Sets the rent of the city.
    public void Set_CityRentPrice(int price)
    {
        CityRentPrice = price;
    }
    //Sets the rent of City with Hotel.
    public void Set_RentWithHotel(int price)
    {
        RentWithHotel = price;
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
}
