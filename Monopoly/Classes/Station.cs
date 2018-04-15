using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Station : Purchasable
{
    List<int> RentPrices;

    public Station()
    {
        RentPrices = new List<int>();
    }
    public void Set_RentPrices(List<int> prices)
    {
        RentPrices = prices;
    }
    public List<int> Get_RentPrices()
    {
        return RentPrices;
    }
}
