using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class Field
{
    int FieldNumber;
    Point FieldPosition;

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
