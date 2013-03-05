using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableRex
{
    // List of all the function names
    enum Functions
    {
        greater_than = 0,
        less_than = 1,
        equal = 2,
        addition = 3,
        subtraction = 4,
        multiplication = 5,
        division = 6,
        absolute_value = 7,
        and = 8,
        or = 9,
        not = 10,
        generate_constant = 11,
        modulo = 12,
        random_float = 13,
        normalize_relative_angle = 14,
        control_actuator = 15
    };

    public class TableRex
    {
        private const uint NROWS = 8; // Number of Rows on the table
        private int[] table = new int[NROWS];
        public string binaryString
        {
            get
            {
                binaryString = "";
                for (int i = 0; i < table.Length; i++)
                    binaryString += IntToBinaryString(table[i], 18);
                return binaryString;
            }
            set
            {
                binaryString = value;
            }
        }

        public TableRex()
        {
            for (int i = 0; i < table.Length; i++)
                table[i] = 666;
        }

        // Returns a string representating the binary form of X at a fixed size (filled with zeros at left)
        private string IntToBinaryString(int x, int size) // TODO: Poner en un fichero AUX o UTILS o algo así
        {
            char[] bits = new char[size];
            int i = 0;

            while (i < size)
            {
                if (x != 0)
                {
                    bits[i++] = (x & 1) == 1 ? '1' : '0';
                    x >>= 1;
                }
                else
                {
                    bits[i++] = '0';
                }
            }

            Array.Reverse(bits, 0, i);
            return new string(bits);
        }

    }
/*
    class TRrow
    {
        public int function;
        public int input1;
        public int input2;
        public int output;

        public TRrow(int f, int in1, int in2, int o)
        {
            function = f;
            input1 = in1;
            input2 = in2;
            output = o;
        }
    }

    class TableRex
    {
        private const uint NROWS = 8; // Number of Rows on the table
        private TRrow[] table = new TRrow[NROWS];
        
        public string binaryString
        {
            get
            {
                return binaryString;
            }
            set
            {
                binaryString = value;
            }
        }

        public static string Separator = " "; // Separator between lines of the table

        // Default Constructor: Generate a random TableRex
        public TableRex()
        {
            //Random rand = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);
            for (uint i = 0; i < NROWS; i++)
            {
                //table[i] = new TRrow(rand.Next(16), rand.Next(108), rand.Next(108), 0);
                table[i] = new TRrow(16, 108, 108, 0);
            }
            SetBinaryString();
        }

        // Returns the binary String with all the table data
        public void SetBinaryString ()
        {
            binaryString = "";
            for (uint i = 0; i < NROWS; i++)
            {
                string fila = IntToBinaryString(table[i].function, 4);
                fila += IntToBinaryString(table[i].input1, 7);
                fila += IntToBinaryString(table[i].input2, 7);
                binaryString += fila + Separator;
            }
        }
        




        // Returns a string representating the binary form of X at a fixed size (filled with zeros at left)
        public string IntToBinaryString(int x, int size) // TODO: Poner en un fichero AUX o UTILS o algo así
        {
            char[] bits = new char[size];
            int i = 0;

            while (i < size)
            {
                if (x != 0)
                {
                    bits[i++] = (x & 1) == 1 ? '1' : '0';
                    x >>= 1;
                }
                else
                {
                    bits[i++] = '0';
                }
            }

            Array.Reverse(bits, 0, i);
            return new string(bits);
        }

    }
 */
}
