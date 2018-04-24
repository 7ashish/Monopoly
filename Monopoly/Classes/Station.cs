using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

public class Station : Purchasable
{
    int[] RentPrices;

    public Station():base()
    {
        RentPrices = new int[2];
    }
    public void Set_RentPrices(int[] prices)
    {
        RentPrices = prices;
    }
    public int[] Get_RentPrices()
    {
        return RentPrices;
    }
    public Station(Monopoly.Monopoly p,int fieldnumber, Point fieldpostion,string name, int price, int mortageprice, int[] rentprices) : base(p,fieldnumber,fieldpostion,name, price, mortageprice)
    {
        RentPrices = new int[2];
        for (int i = 0; i < 2; i++)
        {
            RentPrices[i] = rentprices[i];
        }
    }
    public override void Action(Player player)
    {
        if (Get_Owned())
        {
            if (player.Get_OwnedStations().Contains(this))
            {
                return;
            }
            else
            {
                player.Pay_StationRents(this);
            }
        }
        else
        {
            string FolderPath = Directory.GetCurrentDirectory();
            switch (Get_FieldNumber())
            {
                case 4:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath+@"\Reading RailRoad.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
                case 16:
                    GetForm().Get_CityPanel().BackgroundImage = Image.FromFile(FolderPath+@"\B&O Rail Road.PNG");
                    GetForm().Get_BuyingCityPanel().Show();
                    break;
            }
        }
    }
}

