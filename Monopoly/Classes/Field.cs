using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

public abstract class Field
{
    int FieldNumber;
    Point FieldPosition;
    Monopoly.Monopoly ParentForm;

    public Monopoly.Monopoly GetForm()
    {
        return ParentForm;
    }
    //defualt constructor.
    public Field()
    {
        FieldNumber = 0;
        FieldPosition = new Point();
    }
    //Parameterized constructor.
    public Field(Monopoly.Monopoly P,int fieldnumber, Point fieldpostion)
    {
        ParentForm = P;
        FieldNumber = fieldnumber;
        FieldPosition = fieldpostion;
    }
    //sets field number of a specific field.
    public void Set_FieldNumber(int FN)
    {
        FieldNumber = FN;
    }
    //returns field number.
    public int Get_FieldNumber()
    {
        return FieldNumber;
    }
    //Sets field position by point(X,Y).
    public void Set_FieldPosition(Point position)
    {
        FieldPosition = position;
    }
    //returns Point(X,Y).
    public Point Get_FieldPosition()
    {
        return FieldPosition;
    }
    //pure virtual function, defined on all inherited classes.
    public abstract void Action(Player player);
}
