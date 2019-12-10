using GeneticSharp.Domain.Chromosomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdversarialImage
{
    class MyChromosome : BinaryChromosomeBase
    {
        // Change the argument value passed to base construtor to change the length 
        // of your chromosome.
        public MyChromosome() : base(MainGA.indidvlength)
        {
            CreateGenes();
        }


        public override IChromosome CreateNew()
        {
            return new MyChromosome();
        }
    }
}
