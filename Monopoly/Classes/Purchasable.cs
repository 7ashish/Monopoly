using System.Drawing;

public abstract class Purchasable : Field
{
    string Name;
    int Price;
    int MortagagePrice;
    bool ISMortagaged;
    Player Owner;
    bool Owned;
    //defualt constructor.
    public Purchasable():base()
    {
        Name = " ";
        Price = 0;
        MortagagePrice = 0;
        Owned = false;
        ISMortagaged = false;
    }
    //Parameterized constructor.
    public Purchasable(Monopoly.Monopoly P,int fieldnumber, Point fieldpostion,string name, int price, int mortagagedprice):base(P,fieldnumber,fieldpostion)
    {
        Name = name;
        Price = price;
        MortagagePrice = mortagagedprice;
        ISMortagaged = false;
        Owned = false;
    }
    //sets the owner to null, and make the owned bool equal false;
    public void Remove_Owner()
    {
        Owned = false;
        Owner = null;
    }
    //Set the owner of the city by a specific player.
    public void Set_Owner(Player player)
    {
        Owner = player;
    }
    //returns the player who owns the city.
    public Player Get_Owner()
    {
        return Owner;
    }
    //Set the owned bool to true.
    public void Set_Owned()
    {
        Owned = true;
    }
    //returns the owned bool.
    public bool Get_Owned()
    {
        return Owned;
    }
    //Sets the Name of the City or Station.
    public void Set_Name(string name)
    {
        Name = name;
    }
    //returns the name of the City or Station.
    public string Get_Name()
    {
        return Name;
    }
    //Set the Price of a City or Station.
    public void Set_Price(int price)
    {
        Price = price;
    }
    //Return the Price of the City or Station.
    public int Get_Price()
    {
        return Price;
    }
    //Sets the Mortagage Price.
    public void Set_MortagagePrice(int price)
    {
        MortagagePrice = price;
    }
    //Returns the Mortagage price.
    public int Get_MortagagePrice()
    {
        return MortagagePrice;
    }
    //returns the Bool of the Mortagage of a city or a station.
    public  bool Get_ISMortagaged()
    {
        return ISMortagaged;
    }
    //Sets the Mortagage bool of a city or a station to true.
    public void Set_ISMortagaged()
    {
        ISMortagaged = true;
    }
    //Sets the Mortagage bool of a city or a station to false.
    public void Remove_Mortagage()
    {
        ISMortagaged = false;
    }
}
