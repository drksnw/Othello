using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class Player
    {
        private bool isBlack;
        
        public int PlayerColor
        {
            get
            {
                if (isBlack)
                {
                    return Othellier.PLAYER_BLACK;
                } else
                {
                    return Othellier.PLAYER_WHITE;
                }
            }
        }
        
        public Player(bool isBlack)
        {
            this.isBlack = isBlack;
        } 

    }
}
