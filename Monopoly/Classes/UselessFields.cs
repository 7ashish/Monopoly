using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


class UselessFields : Non_Purchasable
{
    public UselessFields():base()
    {
    }
    public UselessFields(Monopoly.Monopoly P, int fieldnumber, Point fieldpostion) : base(P,fieldnumber, fieldpostion)
    {
    }
    override public void Action(Player player)
    {
    }
}
