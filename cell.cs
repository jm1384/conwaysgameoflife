namespace lifeGame
{
    class Cell
    {
        private bool state; //false == dead, true == live
        private int neighborCount;
        public Cell(bool initialState)
        {
            state = initialState;
        }
        
        public bool GetState()
        {
            return state;
        }
        public int GetValue()
        {
            if(state)
            {
                return 1;
            }
            return 0;
        }

        public int GetNeighborCount()
        {
            return neighborCount;
        }

        public void SetNeighborCount(int num)
        {
            neighborCount = num;
        }

        public void EvaluateState()
        {
            if(neighborCount > 3 || neighborCount < 2)
            {
                state = false;
            }
            else if(!state && neighborCount == 3)
            {
                state = true;
            }
        }
        public void ChangeState()
        {
            if (state)
            {
                state = false;
            }
            else
            {
                state = true;
            }
        }
        public void PrintCell()
        {
            if(state)
            {
                Console.Write('X');
            }
            else
            {
                Console.Write('O');
            }
        }
    }
}
