using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

class Community_Chest : Non_Purchasable
{
    public Community_Chest() : base()
    {
    }
    public Community_Chest(Monopoly.Monopoly P,int fieldnumber, Point fieldpostion) : base(P,fieldnumber, fieldpostion)
    {
    }
    static Random r = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);
    public int Choose()
    {
        return r.Next(1, 4);
    }
    override public void Action(Player player)
    {
        string FolderPath = Directory.GetCurrentDirectory();
        int result = Choose();
        switch (result)
        {
            case 1:
                GetForm().Get_ActionPicPanel().BackgroundImage = Image.FromFile(FolderPath + @"\CC1.jpg");
                GetForm().GetActionPanel().Show();
                player.Collect_Money(100);
                break;
            case 2:
                GetForm().Get_ActionPicPanel().BackgroundImage = Image.FromFile(FolderPath + @"\CC2.jpg");
                GetForm().GetActionPanel().Show();
                player.Collect_Money(100);
                break;
            case 3:
                GetForm().Get_ActionPicPanel().BackgroundImage = Image.FromFile(FolderPath + @"\CC3.jpg");
                GetForm().GetActionPanel().Show();
                player.Pay_Tax(150);
                break;
        }

    }
}
