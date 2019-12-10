using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdversarialImage
{
    class MainGA
    {
       public static int genelength = 2;
       public static int indidvlength = 8;

        public static void ga()
        {
            AlgorithmList.loadformnistfsgm();
            var selection = new EliteSelection();
            var crossover = new OrderedCrossover();
            var mutation = new ReverseSequenceMutation();
            var fitness = new MyProblemFitness();
            var chromosome = new MyChromosome();
            var population = new Population(4, 6, chromosome);

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new GenerationNumberTermination(4);

            Console.WriteLine("GA running...");
            ga.Start();

            Console.WriteLine("Best solution found has {0} fitness.", ga.BestChromosome.Fitness);
            
            var a = ga.BestChromosome.GetGenes();
            string s = "";
            foreach (var b in a)
            {
                s = s + b.Value.ToString();
            }
            Console.WriteLine("Best solution found has {0} ", s);
        }
    }
}
