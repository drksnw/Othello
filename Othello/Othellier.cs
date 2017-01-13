using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class Othellier
    {
        private List<Case> board;
        private Player white;
        private Player black;

        public static readonly int PLAYER_WHITE = 0;
        public static readonly int PLAYER_BLACK = 1;

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
    }
}
