using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdversarialImage
{
    class MyProblemFitness: IFitness
{  
	public double Evaluate(IChromosome chromosome)
    {
            // Evaluate the fitness of chromosome.

            fitnesstcheck(chromosome);
            RunAlgorithm.RunAlgorithmchromosomes();
            return RunAlgorithm.diff;
    }

        private void fitnesstcheck(IChromosome chromosome)
        {
            var a = chromosome.GetGenes();
            string s = "";
            foreach (var b in a)
            {
                s=s+b.Value.ToString();
            }
            ChromosomeDecode.checkstring(s);
           
        }
    }
}
