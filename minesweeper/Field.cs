using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Field
    {
        public bool IsMine { get; }
        public bool IsRevealed { get; private set; }

        private Field? _right;
        private Field? _left;
        private Field? _top;
        private Field? _bottom;

        public Field(bool isMine)
        {
                        IsMine = isMine;
            IsRevealed = false;
        }
        
        public string GetRepresentation()
        {
            // für programmierung 
            if (!IsRevealed)
            {
                return "■";
            }
            else if (IsRevealed && !IsMine)
            {
                return " ";
            }
            else if (IsRevealed && IsMine)
            {
                return "X";
            }
            return default;
        }

        public bool IsFieldRevealed()
        {
            if (IsRevealed) { return true; }
            return false;
        }

        public void RevealField()
        {
            IsRevealed = IsFieldRevealed();
            if (!IsRevealed)
            {
                IsRevealed = true;
            }
        }

        public bool UnfoldAndCheckGameOver()
        {
            if (IsRevealed)
            {
                return false;
            }
            IsRevealed = true;

            _right?.UnfoldAndCheckGameOver();
            _right?._top?.UnfoldAndCheckGameOver();

            return IsMine;
        }
    }
}
