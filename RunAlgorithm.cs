using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Imaging;
namespace AdversarialImage
{
    class RunAlgorithm
    {
        private static double adversupperrange = 0.0;
        private static double adverselowerrange = 0.0;
        private static double cleanupperrange = 0.0;
        private static double cleanlowerrange = 0.0;
        public static double diff = 0.0;
        public static void RunAlgorithmchromosomes()
        {
            
                runonclean();
                runonadverse();
                DifferenceMethod();
                
           
        }

        private static void DifferenceMethod()
        {
            double distance = 0.0;
            if (cleanupperrange > adversupperrange && cleanlowerrange > adversupperrange)
            {
                distance = cleanlowerrange - adversupperrange;
                distance = distance * distance;

            }
            else if (adversupperrange > cleanupperrange && adverselowerrange > cleanupperrange)
            {
                distance = adverselowerrange - cleanupperrange;
                distance = distance * distance;
            }
            else 
            {

                distance = -Math.Abs(adversupperrange + adverselowerrange - cleanupperrange - cleanlowerrange);
            }
            diff = distance;
        }

        private static void runonadverse()
        {
            List<double> means = new List<double>();
            List<double> stddeva = new List<double>();

            string[] file = Directory.GetFiles(Form1.adverse);
            for (int i = 0; i < file.Length; i++)
            {
                if (i == 30) break;
                string dupImagePath = file[i];
                Bitmap org0 = (Bitmap)Accord.Imaging.Image.FromFile(dupImagePath);
                Bitmap org1 = org0.Clone(System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Bitmap noiserem = org1;
                foreach (string filterid in ChromosomeDecode.algorithm)
                {
                    if (filterid.Equals("01"))
                    {
                        // Console.WriteLine("AdaptiveSmoothing");
                        Accord.Imaging.Filters.AdaptiveSmoothing noisefilter = new Accord.Imaging.Filters.AdaptiveSmoothing();
                        noiserem = noisefilter.Apply(noiserem);

                    }
                    else if (filterid.Equals("11"))
                    {
                        //  Console.WriteLine("AdditiveNoise");
                        Accord.Imaging.Filters.AdditiveNoise noisefilter = new Accord.Imaging.Filters.AdditiveNoise();
                        noiserem = noisefilter.Apply(noiserem);
                    }
                    else if (filterid.Equals("10"))
                    {
                        // Console.WriteLine("BilateralSmoothing");
                        Accord.Imaging.Filters.BilateralSmoothing noisefilter = new Accord.Imaging.Filters.BilateralSmoothing();
                        noiserem = noisefilter.Apply(noiserem);
                    }
                    else
                    {
                        ///donothing
                    }
                }
                Accord.Imaging.Filters.Difference filter = new Accord.Imaging.Filters.Difference(org1);              
                // apply the filter
                Bitmap resultImage = filter.Apply(noiserem);
                Accord.Imaging.ImageStatistics statistics = new Accord.Imaging.ImageStatistics(resultImage);
              
                double mean = 0.0;// histogram.Mean;     // mean red value
                double stddev = 0.0;// histogram.StdDev
                if (MainGA.genelength == 2)
                {
                    var histogram = statistics.Red;
                    mean = histogram.Mean;     // mean red value
                    stddev = histogram.StdDev;
                }
                else
                {
                    var histogram = statistics.Gray;
                    mean = histogram.Mean;     // mean red value
                    stddev = histogram.StdDev;
                }
                means.Add(mean);
                stddeva.Add(stddev);
                org0.Dispose();
                org1.Dispose();
                noiserem.Dispose();
                resultImage.Dispose();

            }

             adversupperrange = stddeva.Average() + means.Average();
             adverselowerrange = Math.Abs(means.Average()- stddeva.Average() );
        }

        private static void runonclean()
        {

            List<double> means = new List<double>();
            List<double> stddeva = new List<double>();

            string[] file = Directory.GetFiles(Form1.clean);
            for (int i = 0; i < file.Length; i++)
            {
                if (i == 30) break;
                string dupImagePath = file[i];
                Bitmap org0 = (Bitmap)Accord.Imaging.Image.FromFile(dupImagePath);
                Bitmap org1 = org0.Clone(System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Bitmap noiserem = org1;
                foreach (string filterid in ChromosomeDecode.algorithm)
                {
                    if (filterid.Equals("01"))
                    {
                        // Console.WriteLine("AdaptiveSmoothing");
                        Accord.Imaging.Filters.AdaptiveSmoothing noisefilter = new Accord.Imaging.Filters.AdaptiveSmoothing();
                        noiserem = noisefilter.Apply(noiserem);

                    }
                    else if (filterid.Equals("11"))
                    {
                        //  Console.WriteLine("AdditiveNoise");
                        Accord.Imaging.Filters.AdditiveNoise noisefilter = new Accord.Imaging.Filters.AdditiveNoise();
                        noiserem = noisefilter.Apply(noiserem);
                    }
                    else if (filterid.Equals("10"))
                    {
                        // Console.WriteLine("BilateralSmoothing");
                        Accord.Imaging.Filters.BilateralSmoothing noisefilter = new Accord.Imaging.Filters.BilateralSmoothing();
                        noiserem = noisefilter.Apply(noiserem);
                    }
                    else
                    {
                        ///donothing
                    }
                }
                Accord.Imaging.Filters.Difference filter = new Accord.Imaging.Filters.Difference(org1);
                // apply the filter
                Bitmap resultImage = filter.Apply(noiserem);
                Accord.Imaging.ImageStatistics statistics = new Accord.Imaging.ImageStatistics(resultImage);

                double mean = 0.0;// histogram.Mean;     // mean red value
                double stddev = 0.0;// histogram.StdDev
                if (MainGA.genelength == 2)
                {
                    var histogram = statistics.Red;
                    mean = histogram.Mean;     // mean red value
                    stddev = histogram.StdDev;
                }
                else
                {
                    var histogram = statistics.Gray;
                    mean = histogram.Mean;     // mean red value
                    stddev = histogram.StdDev;
                }
                means.Add(mean);
                stddeva.Add(stddev);
                org0.Dispose();
                org1.Dispose();
                noiserem.Dispose();
                resultImage.Dispose();

            }

            cleanupperrange = stddeva.Average() + means.Average();
            cleanlowerrange = Math.Abs(stddeva.Average() - means.Average());
        }

      
    }
}
