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
    public UselessFields(int fieldnumber, Point fieldpostion) : base(fieldnumber, fieldpostion)
    {
    }
    override public void Action(Player player)
    {
    }
}
