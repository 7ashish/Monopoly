using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

abstract class Field
{
    int FieldNumber;
    Point FieldPosition;

    public Field()
    {
        FieldNumber = 0;
        FieldPosition = new Point();
    }
    public Field(int fieldnumber, Point fieldpostion)
    {
        FieldNumber = fieldnumber;
        FieldPosition = fieldpostion;
    }
    public void Set_FieldNumber(int FN)
    {
        FieldNumber = FN;
    }
    public int Get_FieldNumber()
    {
        return FieldNumber;
    }
    public void Set_FieldPosition(Point position)
    {
        FieldPosition = position;
    }
    public Point Get_FieldPosition()
    {
        return FieldPosition;
    }
}
