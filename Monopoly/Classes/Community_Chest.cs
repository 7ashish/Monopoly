using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class Community_Chest : Non_Purchasable
{
    public Community_Chest():base()
    {
    }
    public Community_Chest(int fieldnumber, Point fieldpostion) : base(fieldnumber, fieldpostion)
    {
    }
    public int choose()
    {
        Random rmd = new Random(new DateTime().Millisecond);
        return rmd.Next(1, 5);
    }
    override public void action(Player player)
    {
        int result = choose();
        if (result == 1)
        {
            player.Pay_Tax(15);
        }
        else if (result == 2)
        {
            player.Collect_Money(200);
        }
        else if (result == 3)
        {
            //Go To Jail
        }
        else if (result == 4)
        {
            player.Collect_Money(150);
        }
        //else
            //Go Back tree Spaces

    }
}
