using System.Collections.Generic;

namespace AdventOfCodeDay3
{
    public interface IDeliveryCache
    {
        int GetValue(GridReference gridReference);
        int GetTotalEntries();
        void AddOrIncrement(GridReference gridReference);
    }
    
    public class DeliveryCache : IDeliveryCache
    {
        private readonly IDictionary<GridReference, int> _deliveryCache = new Dictionary<GridReference, int>();

        public int GetValue(GridReference gridReference)
        {
            if (_deliveryCache.ContainsKey(gridReference))
            {
                return _deliveryCache[gridReference];
            }

            return 0;
        }

        public int GetTotalEntries()
        {
            return _deliveryCache.Keys.Count;
        }
        
        public void AddOrIncrement(GridReference gridReference)
        {
            if (_deliveryCache.ContainsKey(gridReference))
            {
                _deliveryCache[gridReference] += 1;
            }
            else
            {
                _deliveryCache.Add(gridReference, 1);
            }
            
        }
    }
}