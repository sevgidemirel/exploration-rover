using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Constans;

namespace Utilities.Validation
{
    public class LetterLineValidator
    {
        public bool MaxLenghtValidator(string[] array, int value)
        {
            if (array.Length > value)
            {
                return false;
            }
            return true;
        }

        public bool MaxLenghtValidator(int[] array, int value)
        {
            if (array.Length > value)
            {
                return false;
            }
            return true;
        }
        public bool MinimumValueValidator(int[] maximumCordinates)
        {
            if (maximumCordinates[0] == LocationConstans.MinimumX || maximumCordinates[1] == LocationConstans.MinimumY)
            {
                return false;
            }
            return true;
        }

        public bool RotationValidator(char[] rotations)
        {
            if (rotations != null)
            {
                foreach (var item in rotations)
                {
                    if (!LocationConstans.PossibleRotationValues.Contains(item)) return false;
                }
            }

            return true;
        }
    }
}
