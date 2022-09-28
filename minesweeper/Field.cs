using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Field
    {
        private ConsoleHelper _helper;

        private Field? _right;
        private Field? _left;
        private Field? _top;
        private Field? _bottom;

        // Properties
        public Field? Right => _right;
        public Field? Left => _left;
        public Field? Top => _top;
        public Field? Bottom => _bottom;

        public int Index { get; }
        public bool IsMine { get; }
        public bool IsRevealed { get; private set; }
        public bool IsMarked { get; private set; }
        public int MinesNearby { get; private set; }


        public Field(int index, bool isMine)
        {
            Index = index;
            IsMine = isMine;
            IsRevealed = false;
        }
        
        public void SetFields(Field? left, Field? top, Field? right, Field? bottom)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }

        public int MinesArroundMe()
        {
            int count = 0;

            if ((_left?.IsMine) ?? false)
            {
                count++;
            }

            if ((_top?.IsMine) ?? false)
            {
                count++;
            }

            if ((_right?.IsMine) ?? false)
            {
                count++;
            }

            if ((_bottom?.IsMine) ?? false)
            {
                count++;
            }

            return count;
        }

        public string GetRepresentation()
        {
            // für manuel: hier den wert von IsMarked prüfen und dann symbol returnen
            if (!IsRevealed && !IsMarked)
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
            else if (!IsRevealed && IsMarked)
            {
                return "#";
            }
            return default;
        }

        public void MarkField()
        {
            if (!IsMarked)
            {
                IsMarked = true;
            }
            else if (IsMarked)
            {
                IsMarked = false;
            }
        }
        
        public void SetMinesNearby(int minesNearby)
        {
            MinesNearby = minesNearby;
        }

        public void RevealField()
        {
            IsRevealed = true;

            if (IsMine)
            {
             // Experimental
             // field.GetRepresentation();
                GameOver.PrintGameOver();
            }
        }

        public bool IsFieldRevealed()
        {
            if (IsRevealed) { return true; }
            return false;
        }

        public int MineCounter()
        {
            if (IsMine)
            {
                return 1;
            }
            return 0;
        }

        //public bool UnfoldAndCheckGameOver()
        //{
        //    if (IsRevealed)
        //    {
        //        return false;
        //    }
        //    IsRevealed = true;

        //    _top?._left?.UnfoldAndCheckGameOver();
        //    _top?.UnfoldAndCheckGameOver();
        //    _top?._right?.UnfoldAndCheckGameOver();

        //    _left?.UnfoldAndCheckGameOver();
        //    _right?.UnfoldAndCheckGameOver();

        //    _bottom?._left?.UnfoldAndCheckGameOver();
        //    _bottom?.UnfoldAndCheckGameOver();
        //    _bottom?._right?.UnfoldAndCheckGameOver();

        //    return IsMine;
        //}
    }
}
