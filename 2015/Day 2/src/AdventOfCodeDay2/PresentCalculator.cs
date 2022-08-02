using System;
using System.Linq;

namespace AdventOfCodeDay2
{
    public interface IPresentCalculator
    {
        int CalculateWrappingPaperRequired(int length, int width, int height);
        int CalculateRibbonRequired(int length, int width, int height);
    }
    
    public class PresentCalculator : IPresentCalculator
    {
        public int CalculateWrappingPaperRequired(int length, int width, int height)
        {
            int wrappingPaperAreaRequired = 0;

            wrappingPaperAreaRequired += (2 * length * width);
            wrappingPaperAreaRequired += (2 * width * height);
            wrappingPaperAreaRequired += (2 * height * length);

            var dimensions = new int[] { length, width, height };
            var orderedDimensions = dimensions
                .OrderBy(x => x)
                .ToList();
            wrappingPaperAreaRequired += orderedDimensions[0] * orderedDimensions[1];
            
            return wrappingPaperAreaRequired;
        }

        public int CalculateRibbonRequired(int length, int width, int height)
        {
            int ribbonLengthRequired = length * width * height;
            
            var dimensions = new int[] { length, width, height };
            var orderedDimensions = dimensions
                .OrderBy(x => x)
                .ToList();

            ribbonLengthRequired += 2 * orderedDimensions[0];
            ribbonLengthRequired += 2 * orderedDimensions[1];

            return ribbonLengthRequired;
        }

        private int CalculateExcessWrappingPaperRequired(int[] dimensions)
        {
            if (dimensions == null || dimensions.Length < 3)
            {
                throw new ArgumentException("Invalid dimension array");
            }
            
            var orderedDimensions = dimensions
                .OrderBy(x => x)
                .ToList();

            return orderedDimensions[0] * orderedDimensions[1];
        }
    }
}