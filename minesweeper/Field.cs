using minesweeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static minesweeper.Model.Representation;

namespace minesweeper
{
    internal class Field
    {
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

            if ((_top?._left?.IsMine) ?? false)
            {
                count++;
            }

            if ((_top?.IsMine) ?? false)
            {
                count++;
            }

            if ((_top?._right?.IsMine) ?? false)
            {
                count++;
            }

            if ((_right?.IsMine) ?? false)
            {
                count++;
            }

            if ((_bottom?._right?.IsMine) ?? false)
            {
                count++;
            }

            if ((_bottom?.IsMine) ?? false)
            {
                count++;
            }

            if ((_bottom?._left?.IsMine) ?? false)
            {
                count++;
            }

            if ((_left?.IsMine) ?? false)
            {
                count++;
            }

            return count;
        }

        public bool IsInvalidMarked => (IsMine && !IsMarked) || (!IsMine && IsMarked);

        public Representation GetRepresentation()
        {
            // //cheat mode
            //if (!IsRevealed && IsMine)
            //{
            //    return Red("X");
            //}
            //else if (!IsRevealed && IsMarked)
            //{
            //    return Yellow("#");
            //}
            //else
            //{
            //    int minesNearby = MinesArroundMe();
            //    return $"{minesNearby}";
            //}

            if (!IsRevealed && !IsMarked)
            {
                return "■";
            }
            else if (!IsRevealed && IsMarked)
            {
                return Magenta("#");
            }
            else if (IsRevealed && !IsMine)
            {
                int minesNearby = MinesArroundMe();
                if (minesNearby == 0) { return " "; }
                else if (minesNearby == 1) { return Blue($"{minesNearby}"); }
                else if (minesNearby == 2) { return Green($"{minesNearby}"); }
                else if (minesNearby == 3) { return Yellow($"{minesNearby}"); }
                else if (minesNearby == 4) { return Orange($"{minesNearby}"); }
                else { return Red($"{minesNearby}"); }
            }
            else { return Red("X"); }
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

        public void RevealField()
        {
            IsRevealed = true;
            if (IsMine)
            {
                WinLose.IsLost = true;
            }
            if (MinesArroundMe() == 0)
            {
                FlipNearbyFields();
            }
        }

        public void FlipNearbyFields()
        {
            if (Top != null)
            {
                if (Top.Left != null && Top.Left.IsRevealed == false)
                {
                    Top.Left.RevealField();
                }

                if (Top.IsRevealed == false)
                {
                    Top.RevealField();
                }

                if (Top.Right != null && Top.Right.IsRevealed == false)
                {
                    Top.Right.RevealField();
                }
            }

            if (Right != null && Right.IsRevealed == false)
            {
                Right.RevealField();
            }

            if (Bottom != null)
            {
                if (Bottom.Right != null && Bottom.Right.IsRevealed == false)
                {
                    Bottom.Right.RevealField();
                }

                if (Bottom.IsRevealed == false)
                {
                    Bottom.RevealField();
                }

                if (Bottom.Left != null && Bottom.Left.IsRevealed == false)
                {
                    Bottom.Left.RevealField();
                }
            }

            if (Left != null && Left.IsRevealed == false)
            {
                Left.RevealField();
            }
        }
    }
}
