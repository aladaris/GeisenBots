using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aladaris {

    public static class Support {
        // Returns a string representating the binary form of X at a fixed size (filled with zeros at left)
        public static string IntToBinaryString(int x, int size) // TODO: Poner en un fichero AUX o UTILS o algo así
        {
            char[] bits = new char[size];
            int i = 0;

            while (i < size) {
                if (x != 0) {
                    bits[i++] = (x & 1) == 1 ? '1' : '0';
                    x >>= 1;
                } else {
                    bits[i++] = '0';
                }
            }

            Array.Reverse(bits, 0, i);
            return new string(bits);
        }

        public static int BinaryStringToInt(string bs) // TODO: Poner en un fichero AUX o UTILS o algo así
        {
            int result = 0;
            //Out.WriteLine("[BtI] In = " + bs); // DEBUG
            char[] bits = bs.ToCharArray();

            Array.Reverse(bits);
            //Out.WriteLine("[BtI] bits.reverse = " + bits.ToString()); // DEBUG
            for (int i = 0; i < bits.Length; i++) {
                //Out.WriteLine("[BtI] bits[" + i.ToString() + "] * Math.Pow(2, " + exp.ToString() + ") = " + ((int)Char.GetNumericValue(bits[i])).ToString() + " * " + ((int)Math.Pow(2, i)).ToString()); // DEBUG
                //Out.WriteLine("[BtI] " + i.ToString() + " Result = " + result.ToString()); // DEBUG
                result += (int)Char.GetNumericValue(bits[i]) * (int)Math.Pow(2, i);
            }
            return result;
        }

        public static double PointsDistance(double x1, double y1, double x2, double y2) {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
