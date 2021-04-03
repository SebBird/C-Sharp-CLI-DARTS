using System;
using System.Collections.Generic;
using System.Text;

namespace CLI_Darts
{
    public enum BoardArea
    {
        Default,
        Double,
        Triple,
        BullOuter,
        BullInner,
        OOB
    }
    class DartBoard
    {
        public BoardArea boardArea;

        public DartBoard (BoardArea board)
        {
            board = boardArea;
        }
    }
}
