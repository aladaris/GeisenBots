using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aladaris {

    // Class containing all the data related with the TABLEREX system
    public static class TableRexBase {
        public const int NROWS = 128;          // Numbers of rows on the table
        public const int ROWLENGHT = 18;       // Row Lenght in bits
        public const string SEPARATOR = ";";   // Rows Separator for the RAW string binary data files
        public const string TSEPARATOR = "|"; // TableRex programs separator
        public const int BFUNCTIONSIZE = 4;
        public const int BPARAMETERSIZE = 7;
        public const int NINPUTS = 20; // Number of inputs on the table (first NINPUTS rows of the table)
        // List of all the function names and its respective (decimal) value
        public enum FunctionIndex {
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
    }
}
