using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


class UselessFields : Non_Purchasable
{
    //defualt constructor.C:\Users\Hashish\Desktop\Monopoly\Monopoly\Classes\UselessFields.cs
    public UselessFields():base()
    {
    }
    //Parameterized constructor.
    public UselessFields(Monopoly.Monopoly P, int fieldnumber, Point fieldpostion) : base(P,fieldnumber, fieldpostion)
    {
    }
    //overriding the pure virtual function Action.
    override public void Action(Player player)
    {
        //this is the Fields that when the player step on it, it doesn't change in his status.
    }
}
