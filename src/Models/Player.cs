namespace n_in_row.src.Models {
    internal class Player {
    
    private string _name;
    private int _victories;
    private int _gamesPlayed;

     public string Name
     {
        get {return _name;}
        get {_name = value;}
     }

     public int _victories
     {
        get {return _victories;}
        set {_victories = value;}
     }


     public int GamesPlayed{
        get {return _gamesPlayed;}
        set {_gamesPlayed = value;}
     }

     public Player(string name)
     {
        _name = name;
        victories = 0;
        _gamesPlayed = 0;
     }

    
    }
}
