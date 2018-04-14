using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Monopoly_Master
{
    List<Player> Players;
    List<Field> Fields;
    List<List<Pair<int,City>>> Groups;
    static int Hotels = 10;
    static int Houses = 18;
    Player PlayerTurn;

    Monopoly_Master()
    {
        Players = new List<Player>();
        Fields = new List<Field>();
        Groups = new List<List<Pair<int, City>>>();
    }
}
