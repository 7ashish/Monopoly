using System.Drawing;
using System.Windows.Forms;

public abstract class Purchasable : Field
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int MortagagePrice { get; set; }
    public bool ISMortagaged { get; set; }
    public Player Owner { get; set; }
    public bool Owned { get; set; }
    public Panel PurshableLabel { get; set; }
    //defualt constructor.
    public Purchasable():base()
    {
        Name = " ";
        Price = 0;
        MortagagePrice = 0;
        Owned = false;
        ISMortagaged = false;
        PurshableLabel = null;
    }
    //Parameterized constructor.
    public Purchasable(Monopoly.Monopoly P,int fieldnumber, Point fieldpostion,string name, int price, int mortagagedprice,Panel PurshableLabel) :base(P,fieldnumber,fieldpostion)
    {
        Name = name;
        Price = price;
        MortagagePrice = mortagagedprice;
        ISMortagaged = false;
        Owned = false;
        this.PurshableLabel = PurshableLabel;
    }
    //sets the owner to null, and make the owned bool equal false;
    public void Remove_Owner()
    {
        Owned = false;
        Owner = null;
    }
}
