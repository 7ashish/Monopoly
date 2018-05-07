using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

abstract class Non_Purchasable : Field
{
    //defualt constructor
    public Non_Purchasable() : base()
    {
    }
    //Parameterized constructor.
    public Non_Purchasable(Monopoly.Monopoly P,int fieldnumber, Point fieldpostion) :base(P,fieldnumber,fieldpostion)
    {
    }
    //overriding the pure virtual function Action.
    public abstract override void Action(Player player);
}
