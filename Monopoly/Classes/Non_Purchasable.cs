using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

abstract class Non_Purchasable : Field
{
    public Non_Purchasable() : base()
    {
    }
    public Non_Purchasable(int fieldnumber, Point fieldpostion) :base(fieldnumber,fieldpostion)
    {
    }
}
