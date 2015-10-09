using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ManagerTool {
    static class Serializers {
        public static string Serialize(RobotEntry re) {
            XmlSerializer xs = null;
            try {
                xs = new XmlSerializer(typeof(RobotEntry));
            }catch (Exception e){
                Console.WriteLine("########## ERROR ##########");
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("########## ERROR ##########");
            }
            string result = String.Empty;
            using (StringWriter sw = new StringWriter()) using (XmlTextWriter xw = new XmlTextWriter(sw) { Formatting = Formatting.Indented }) {
                xs.Serialize(xw, re);
                result = sw.ToString();
            }
            return result;
        }
        public static string Serialize(RobotGenerationStorage rgs) {
            XmlSerializer xs = null;
            try {
                xs = new XmlSerializer(typeof(RobotGenerationStorage));
            }catch (Exception e){
                Console.WriteLine("########## ERROR ##########");
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("########## ERROR ##########");
            }
            string result = String.Empty;
            using (StringWriter sw = new StringWriter()) using (XmlTextWriter xw = new XmlTextWriter(sw) { Formatting = Formatting.Indented }) {
                xs.Serialize(xw, rgs);
                result = sw.ToString();
            }
            return result;
        }
    }
}
