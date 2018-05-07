using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

class Chances : Non_Purchasable
{
    //defualt constructor.
    public Chances():base()
    {
    }
    //Parameterized constructor.
    public Chances(Monopoly.Monopoly P, int fieldnumber, Point fieldpostion) : base(P,fieldnumber, fieldpostion)
    {
    }
    static Random r = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);
    //Function that choose random number from 1-3.
    public int Choose()
    {
        return r.Next(1, 4);
    }
    //overriding the pure virtual function Action.
    override public void Action(Player player)
    {
        string FolderPath = Directory.GetCurrentDirectory();
        int result = Choose();
        switch (result)
        {
            case 1:
                GetForm().Get_ActionPicPanel().BackgroundImage = Image.FromFile(FolderPath + @"\C1.jpg");
                GetForm().GetActionPanel().Show();
                player.Pay_Tax(15);
                break;
            case 2:
                GetForm().Get_ActionPicPanel().BackgroundImage = Image.FromFile(FolderPath + @"\C2.JPG");
                GetForm().GetActionPanel().Show();
                player.Collect_Money(50);
                break;
            case 3:
                GetForm().Get_ActionPicPanel().BackgroundImage = Image.FromFile(FolderPath + @"\C3.jpg");
                GetForm().GetActionPanel().Show();
                player.Pay_Tax(250);
                break;
        }

    }
}
