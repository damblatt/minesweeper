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

        private Field? _right;
        private Field? _left;
        private Field? _top;
        private Field? _bottom;

        public Field(bool isMine)
        {
                        IsMine = isMine;
            IsUnfold = false;
        }
        
        public string GetRepresentation()
        {
            // für programmierung 
            if (!IsUnfold)
            {
                return "■";
            }
            else if (IsUnfold && !IsMine)
            {
                return " ";
            }
            else if (IsUnfold && IsMine)
            {
                return "X";
            }
            return default;
        }

        public bool UnfoldAndCheckGameOver()
        {
            if (IsUnfold)
            {
                return false;
            }
            IsUnfold = true;

            _right?.UnfoldAndCheckGameOver();
            _right?._top?.UnfoldAndCheckGameOver();

            return IsMine;
        }
    }
}
