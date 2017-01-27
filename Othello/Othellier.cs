using System.Collections.Generic;
using System.Numerics;

namespace Othello
{
    class Othellier
    {
        private List<Case> board;
        private Player white;
        private Player black;

        //Player constants
        public static readonly int PLAYER_WHITE = 0;
        public static readonly int PLAYER_BLACK = 1;

        //Movement constants
        public static readonly Vector2 CASE_TOP = new Vector2( 0, -1 );
        public static readonly Vector2 CASE_TOPRIGHT = new Vector2( 1, -1 );
        public static readonly Vector2 CASE_RIGHT = new Vector2( 1, 0 );
        public static readonly Vector2 CASE_BOTTOMRIGHT = new Vector2( 1, 1 );
        public static readonly Vector2 CASE_BOTTOM = new Vector2( 0, 1 );
        public static readonly Vector2 CASE_BOTTOMLEFT = new Vector2( -1, 1 );
        public static readonly Vector2 CASE_LEFT = new Vector2( -1, 0 );
        public static readonly Vector2 CASE_TOPLEFT = new Vector2( -1, -1 );


        private int playerTurn = PLAYER_BLACK;
        private MainWindow graphicContext;


        public List<Case> Board
        {
            get
            {
                return board;
            }
        }

        public Othellier(MainWindow graphicContext)
        {
            white = new Player(false);
            black = new Player(true);
            board = new List<Case>();
            this.graphicContext = graphicContext;
            for(char i = 'a'; i <= 'h'; i++)
            {
                for(int j = 1; j <= 8; j++)
                {
                    board.Add(new Case(i, j));
                }
            }
            gameInit();
        }

        public Case getAdjacentWithDirection(Case c, Vector2 dir)
        {
            return getCase((char)(c.Column + dir.X), (int)(c.Row + dir.Y));
        }

        public Case[] getAdjacent(Case c)
        {
            return new Case[] {getAdjacentWithDirection(c, CASE_TOP), getAdjacentWithDirection(c, CASE_TOPRIGHT),
                                getAdjacentWithDirection(c, CASE_RIGHT) , getAdjacentWithDirection(c, CASE_BOTTOMRIGHT),
                                getAdjacentWithDirection(c, CASE_BOTTOM) , getAdjacentWithDirection(c, CASE_BOTTOMLEFT),
                                getAdjacentWithDirection(c, CASE_LEFT), getAdjacentWithDirection(c, CASE_TOPLEFT)};
        }

        public bool isPlayable(Case c)
        {/*
            Case[] adjacentCase = getAdjacent(c);
            int otherPlayer = getOtherPlayer();
            foreach (Case cc in adjacentCase)
            {
                if(cc.Owner != null)
                {
                    if (cc.Owner.PlayerColor == otherPlayer)
                    {
                        Vector2 direction = Vector2.Normalize(new Vector2(cc.Column - c.Column, cc.Row - c.Row));
                        Case nextCase = getAdjacentWithDirection(cc, direction);
                        while (nextCase.Owner.PlayerColor != playerTurn || nextCase.Owner == null || nextCase == null)
                        {
                            nextCase = getAdjacentWithDirection(nextCase, direction);
                        }
                        return (nextCase != null && nextCase.Owner != null && nextCase.Owner.PlayerColor == playerTurn);
                    }
                }
            }*/
            return false;
        }

        private void gameInit()
        {
            getCase('d', 4).Owner = white;
            getCase('e', 5).Owner = white;
            getCase('e', 4).Owner = black;
            getCase('d', 5).Owner = black;
        }

        public Case getCase(char col, int row)
        {
            foreach(Case c in board)
            {
                if(c.Column == col && c.Row == row)
                {
                    return c;
                }
            }
            return null;
        }

        public void playMove(char col, int row)
        {
            Case selectedCase = getCase(col, row);

            if(selectedCase.Owner == null)
            {
                if(playerTurn == PLAYER_BLACK)
                {
                    selectedCase.Owner = black;
                    playerTurn = PLAYER_WHITE;
                } else
                {
                    selectedCase.Owner = white;
                    playerTurn = PLAYER_BLACK;
                }
            }
            graphicContext.update();
        }

        public int getOtherPlayer()
        {
            return playerTurn == PLAYER_BLACK ? PLAYER_WHITE : PLAYER_BLACK;
        }

       
    }
}
