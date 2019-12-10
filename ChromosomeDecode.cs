using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdversarialImage
{
    class ChromosomeDecode
    {
        public static List<string> algorithm = new List<string>();
        public static void checkstring(string value)
        {


            
            int i = 0;
            string s = "";
            foreach (char c in value)
            {
              s = s + c;
                i++;
                if(i==MainGA.genelength)
                {

                    algorithm.Add(s);
                    s = "";
                    i = 0;
                }

            }

        }
    }
}
