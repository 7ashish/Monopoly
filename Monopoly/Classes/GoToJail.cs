using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class GoToJail : Non_Purchasable
{
    //defualt constructor.
    public GoToJail() : base()
    {
    }
    //Parameterized constructor.
    public GoToJail(Monopoly.Monopoly P, int fieldnumber, Point fieldpostion) : base(P,fieldnumber, fieldpostion)
    {
    }
    //overriding the pure virtual function Action.
    override public void Action(Player player)
    {
        Point jail = new Point(80, 530);
        player.Position = jail;
        player.Fieldnumber = 7;
        player.Pay_Tax(50);
        GetForm().Main.Check_PlayerBalance(player);
        GetForm().SetPlayerPanelLocation(jail, player.Token);
        GetForm().Main.Move_Player(player);
    }
}
