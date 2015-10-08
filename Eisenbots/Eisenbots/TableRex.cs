using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aladaris {

    public class TableRex {
        // Class that represent each row of a TableRex table
        public class Row {

            private int _funct;
            private int _p1;
            private int _p2;

            public int function {  // 16  - 2^4 - 4 bits
                get { return _funct; }
                set {
                    if ((value > 15))
                        _funct = 15;
                    else if (value >= 0)
                        _funct = value;
                    else
                        _funct = 0;
                }

            }
            public int param1 {    // 128 - 2^7 - 7 bits
                get {return _p1;}
                set {
                    if (value > 127)
                        _p1 = 127;
                    else if (value >= 0)
                        _p1 = value;
                    else
                        _p1 = 0;
                }
                
            }
            public int param2 {    // 128 - 2^7 - 7 bits
                get {return _p2;}
                set {
                    if (value > 127)
                        _p2 = 127;
                    else if (value >= 0)
                        _p2 = value;
                    else
                        _p1 = 0;
                }
                
            }
            public double output;

            // Default builder
            public Row() {
                function = param1 = param2 = 0;
                output = 0.0;
            }
            // Parametric builder
            public Row(int f, int p1, int p2, int o) {
                function = f;
                param1 = p1;
                param2 = p2;
                output = o;
            }
            // Parametric builder
            public Row(int f, int p1, int p2) {
                function = f;
                param1 = p1;
                param2 = p2;
                output = 0;
            }

        }

        // Base table structure, just an array of 'Row' objects
        private Row[] tabla;

        // Default builder
        public TableRex() {
            tabla = new Row[TableRexBase.NROWS];
            //trPointer = 0;
        }
        // Parametric builder
        public TableRex(string rawBinaryString) {
            tabla = new Row[TableRexBase.NROWS];
            //trPointer = 0;
            ParseRawBinaryData(rawBinaryString);
        }
        // Parse a RAW binary string, containning all the TableRex program, into the table.
        private void ParseRawBinaryData(string rawBinaryString) {
            Console.WriteLine(rawBinaryString);  // DEBUG

            rawBinaryString = rawBinaryString.Trim(char.Parse(TableRexBase.SEPARATOR));
            string[] rows = rawBinaryString.Split(char.Parse(TableRexBase.SEPARATOR));
            for (int i = 0; i < rows.Length + TableRexBase.NINPUTS; i++) {
                if (i < TableRexBase.NINPUTS)  // First NINPUTS rows are inputs
                    tabla[i] = new Row(0, 0, 0, 0);
                else {
                    // Comprobación de funcionamiento: http://ideone.com/QLkJfu
                    int funct = Support.BinaryStringToInt(rows[i - TableRexBase.NINPUTS].Substring(0, TableRexBase.BFUNCTIONSIZE));
                    int p1 = Support.BinaryStringToInt(rows[i - TableRexBase.NINPUTS].Substring(4, TableRexBase.BPARAMETERSIZE));
                    int p2 = Support.BinaryStringToInt(rows[i - TableRexBase.NINPUTS].Substring(11, TableRexBase.BPARAMETERSIZE));
                    tabla[i] = new Row(funct, p1, p2);
                }
            }
        }

        // [] operator overload
        public TableRex.Row this[int i] {
            get { return tabla[i]; }
            set { tabla[i] = value; }
        }

        // Table's Lenght
        public int Lenght {
            get { return tabla.Length; }
        }

    }
}
