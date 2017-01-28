using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class Case
    {
        private char column;
        private int row;

        public char Column
        {
            get
            {
                return column;
            }
        }
        public int Row
        {
            get
            {
                return row;
            }
        }
        private Player owner;

        public Player Owner
        {
            get
            {
                return owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public Case(char column, int row)
        {
            this.column = column;
            this.row = row;
            owner = null;
        }
        public Case(char column, int row, Player owner)
        {
            this.column = column;
            this.row = row;
            this.owner = owner;
        }


    }
}
