using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class Go : Non_Purchasable
{
    //defualt constructor.
    public Go():base()
    {
    }
    //Parameterized constructor.
    public Go(Monopoly.Monopoly P, int fieldnumber, Point fieldpostion) : base(P,fieldnumber, fieldpostion)
    {
    }
    //overriding the pure virtual function Action.
    override public void Action(Player player)
    {
        player.Collect_Money(200);
    }
}

