using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class Go : Non_Purchasable
{
    public Go():base()
    {
    }
    public Go(int fieldnumber, Point fieldpostion) : base(fieldnumber, fieldpostion)
    {
    }
    override public void action(Player player)
    {
        player.Collect_Money(200);
    }
}

