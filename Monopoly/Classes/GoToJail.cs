﻿using System;
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
    public GoToJail(Monopoly.Monopoly P, int fieldnumber, Point fieldpostion) : base(P,fieldnumber, fieldpostion)
    {
    }
    override public void Action(Player player)
    {
        Monopoly.Monopoly P=new Monopoly.Monopoly();
        Point jail = new Point(80, 530);
        player.Set_PlayerPosition(jail);
        player.Set_Fieldnumber(7);
        player.Pay_Tax(50);
        switch (player.Get_Token())
        {
            case 1:
                P.SetPlayer1PanelLocation(jail);
                break;
            case 2:
                P.SetPlayer2PanelLocation(jail);
                break;
            case 3:
                P.SetPlayer3PanelLocation(jail);
                break;
            case 4:
                P.SetPlayer4PanelLocation(jail);
                break;
        }
    }
}
