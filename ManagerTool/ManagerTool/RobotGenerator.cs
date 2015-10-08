using System;

namespace ManagerTool {
    class RobotGenerator {
        // TODO: Dejar de ser const y permitir edición mediante GUI??  => Overdoing?
        private const byte NINPUTS = 20;
        private const byte NROWS = 128 - NINPUTS;
        private const byte BFUNCTIONSIZE = 4;
        private const byte BPARAMETERSIZE = 7;
        private const byte ROWLENGHT = BFUNCTIONSIZE + (2 * BPARAMETERSIZE);
        private const byte NPROGRAMS = 5;
        private const char SEPARATOR = ';';
        private const char TSEPARATOR = '|';
        //private const string FILEEXTENSION = "rxt";
        private Random _rand;

        public RobotGenerator() {
            _rand = new Random((int)DateTime.Now.ToBinary());
        }

        public RobotGenerator(int seed) {
            _rand = new Random(seed);
        }

        private string RandomBinNum(int length) {
            string result = Convert.ToString(_rand.Next((int)Math.Pow(2, length)), 2);
            while (result.Length < length) {
                result = "0" + result;
            }
            return result;
        }

        private string RandomRow() {
            return RandomBinNum(ROWLENGHT);
        }

        private string RandomTableRex(){
            string table = String.Empty;
            for (int i = 0; i < NROWS; i++){
                table += RandomRow();
                if (i < NROWS - 1){
                    table += SEPARATOR;
                }
            }
            return table;
        }

        public string RandomRobotProgram(){
            string program = String.Empty;
            for (int i = 0; i < NPROGRAMS; i++) {
                program += RandomTableRex();
                if (i < NPROGRAMS - 1) {
                    program += TSEPARATOR;
                }
            }
            return program;
        }
    }
}