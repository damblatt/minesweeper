using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Field
    {
        public bool IsMine { get; }
        public bool IsUnfold { get; private set; }

        public Field(bool isMine)
        {
            IsMine = isMine;
            IsUnfold = false;
        }

        public string GetRepresentation()
        {
            // für programmierung 
            if (IsMine)
            {
                return "o";
            }
            else if (!IsUnfold)
            {
                return "■";
            }

            // todo andere möglochkeiten abdecken
            return " ";
        }

        public bool UnfoldAndCheckGameOver()
        {
            IsUnfold = true;
            return IsMine;
        }
    }
}
