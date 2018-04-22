using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class GoToJail : Non_Purchasable
{ 
    public GoToJail() : base()
    {
    }
    public GoToJail(int fieldnumber, Point fieldpostion) :base(fieldnumber,fieldpostion)
    {
    }
    override public void action(Player player)
    {
    }
}
