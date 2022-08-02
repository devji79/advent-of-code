namespace AdventOfCodeDay3
{
    public interface IDeliveryCounter
    {
        int CalculateDeliveredHouses(string input, int delivererCount = 1);
    }
    
    public class DeliveryCounter : IDeliveryCounter
    {
        public int CalculateDeliveredHouses(string input, int delivererCount = 1)
        {
            IDeliveryCache cache = new DeliveryCache();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            
            var inputs = new string[delivererCount];
            
            for (int i = 0; i < input.Length; i++)
            {
                inputs[i % delivererCount] += input[i];
            }

            foreach (var inp in inputs)
            {
                int x = 0;
                int y = 0;
                cache.AddOrIncrement(new GridReference(x, y));
            
                foreach (var ch in inp)
                {
                    switch (ch)
                    {
                        case '<':
                            x--;
                            break;
                        case '>':
                            x++;
                            break;
                        case '^':
                            y++;
                            break;
                        case 'v':
                            y--;
                            break;
                    }
                    cache.AddOrIncrement(new GridReference(x, y));
                }
            }
            
            return cache.GetTotalEntries();
        }
    }
}