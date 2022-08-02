namespace AdventOfCodeDay1
{
    public interface IFloorCalculator
    {
        int CalculateFinalFloor(string input);
        int CalculateBasementPosition(string input);
    }
    
    public class FloorCalculator : IFloorCalculator
    {
        public int CalculateFinalFloor(string input)
        {
            var floor = 0;

            foreach (var ch in input)
            {
                if (ch == '(')
                {
                    floor++;
                } else if (ch == ')')
                {
                    floor--;
                }
            }

            return floor;
        }

        public int CalculateBasementPosition(string input)
        {
            var floor = 0;
            var position = 0;

            foreach (var ch in input)
            {
                position++;
                
                if (ch == '(')
                {
                    floor++;
                } 
                else if (ch == ')')
                {
                    floor--;
                    if (floor < 0)
                    {
                        return position;
                    }
                }
            }

            return 0;
        }
    }
}