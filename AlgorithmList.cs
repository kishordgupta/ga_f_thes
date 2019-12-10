using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdversarialImage
{
    class AlgorithmList
    {
        public static int  length =0;

        public static string DoNothing = "";
        public static string AdaptiveSmoothing = "";
        public static string BilateralSmoothing = "";
        public static string AdditiveNoise = "";
        public static string Thinning = "";
        public static string Pixellete = "";
        public static string GussianBlur = "";
        public static string Sharpening = "";

        public static void loadformnistfsgm()
        {
            length = 2;
            DoNothing = "00";
            AdaptiveSmoothing = "01";
            BilateralSmoothing = "10";
            AdditiveNoise = "11";

        }

        public static void loadformnistjsma()
        {
            length = 2;
            DoNothing = "00";
            Sharpening = "01";
            BilateralSmoothing = "10";
            AdditiveNoise = "11";

        }

        public static void loadformnistcw()
        {
            length = 2;
            DoNothing = "00";
            Sharpening = "01";
            Pixellete = "10";
            AdditiveNoise = "11";

        }

        public static void loadformnistcifar()
        {
            length = 3;
            DoNothing = "000";
            AdaptiveSmoothing = "001";
            BilateralSmoothing = "010";
            AdditiveNoise = "011";
            Thinning = "010";
            Pixellete = "100";
            GussianBlur = "101";
            Sharpening = "111";
        }

    }
}
