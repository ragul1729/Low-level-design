public class Chess
{
    private static Board _chessBoard;
    private static Colour _playerTurn;

    public Chess()
    {
        _chessBoard = new Board();
        _playerTurn = Colour.White;
    }

    public static void UpdatePlayerTurn()
    {
        if (_playerTurn == Colour.White)
            _playerTurn = Colour.Black;
        else
            _playerTurn = Colour.White;
    }

    public static Colour PlayerTurn { get { return _playerTurn; } }
    public static Board ChessBoard { get { return _chessBoard; } }
}

public class Board
{
    private static Piece[,] _positions  = new Piece[8, 8];

    public Board()
    {
        InitializeBoard();
    }

    public Piece getPiece(Position pos)
    {
        return _positions[pos.X, pos.Y];
    }

    public static bool isCellEmpty(Position pos)
    {
        return _positions[pos.X,pos.Y] == null;
    }

    public static void UpdateBoard(Piece piece, in Position initialPos, in Position destination)
    {
        _positions[initialPos.X, initialPos.Y] = null;
        _positions[destination.X, destination.Y] = piece;
    }

    private void InitializeBoard()
    {
        
    }
}

public class Piece
{
    private Position _initialPosition;
    private Colour _colour;

    protected Position InitialPosition { get { return _initialPosition; } }
    protected Colour Colour { get { return _colour; } }
    public Piece(Position initialPos, Colour colour)
    {
        _initialPosition = initialPos;
        _colour = colour;
    }

    private bool DoesResultInCheck(Position destination)
    {
        return true;
    }
    protected bool IsValidMove(Position destination)
    {
        return Chess.PlayerTurn == this._colour && Chess.ChessBoard.getPiece(destination) == null && !DoesResultInCheck(destination);
    }
    public virtual void move(Position destination)
    {
        Board.UpdateBoard(this, _initialPosition, destination);
        Chess.UpdatePlayerTurn();
        _initialPosition = destination;    
    }
}

public enum Colour { Black, White }

public class Position
{
    private int _x;
    private int _y;

    public int X { get { return _x; } set { _x = value; } }
    public int Y { get { return _y; } set { _y = value; } }
}

public class Pawn : Piece
{
    public Pawn(Position initialPos, Colour colour) : base(initialPos, colour)
    {
    }

    private bool IsSingleMove(Position destination)
    {
        return destination.X == InitialPosition.X && destination.Y == InitialPosition.Y + 1 && Board.isCellEmpty(destination) ;
    }

    private bool IsDoubleMove(Position destination)
    {
       
    }
    private bool IsValidPawnMove(Position destination)
    {
        return destination.X == InitialPosition.X && destination.Y == InitialPosition.Y + 1;
    }
    private bool IsValidMove(Position destination)
    {
        return base.IsValidMove(destination) && IsValidPawnMove(destination);
    }
    public override void move(Position destination)
    {
        if (IsValidMove(destination))
        {
            base.move(destination);
        }
    }
}

public class Rook : Piece
{
    public Rook(Position initialPos, Colour colour) : base(initialPos, colour)
    {
    }
}

public class Knight : Piece
{
    public Knight(Position initialPos, Colour colour) : base(initialPos, colour)
    {
    }
}

public class Bishop : Piece
{
    public Bishop(Position initialPos, Colour colour) : base(initialPos, colour)
    {
    }
}

public class King : Piece
{
    public King(Position initialPos, Colour colour) : base(initialPos, colour)
    {
    }
}

public class Queen : Piece
{
    public Queen(Position initialPos, Colour colour) : base(initialPos, colour)
    {
    }
}