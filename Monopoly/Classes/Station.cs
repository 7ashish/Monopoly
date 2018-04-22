using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class Station : Purchasable
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
    public Station(int fieldnumber, Point fieldpostion,string name, int price, int mortageprice, int[] rentprices) : base(fieldnumber,fieldpostion,name, price, mortageprice)
    {
        RentPrices = new int[2];
        for (int i = 0; i < 2; i++)
        {
            RentPrices[i] = rentprices[i];
        }
    }
}

