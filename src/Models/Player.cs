namespace n_in_row.src.Models {
   
    internal class Player {
    
    private string _name;
    private int _victories;
    private int _symbol;
    private int _color;
    private int _TotalGamesPlayed;
   private int _draws;
   private int _loses;

     public string Name
     {
        get {return _name;}
        get {_name = value;}
     }

     public int Color
     {
        get {return _color;}
        set {_color = value;}
     }

      public int Symbol
      {
         get {return _symbol;}
         set {_symbol = value;}
      }

     public int Victories
     {
        get {return _victories;}
        set {_victories = value;}
     }


     public int TotalGamesPlayed{
        get {return _TotalGamesPlayed;}
        set {_TotalGamesPlayed = value;}
     }

     public int Draws
     {
        get {return _draws;}
        set {_draws = value;}
     }

     public int Loses
     {
        get {return _loses;}
        set {_loses = value;}
     }

     public Player(string name)
     {
        _name = name;
        victories = 0;
        _gamesPlayed = 0;
     }

    
    }
}
