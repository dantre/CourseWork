﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.Panzer;
using Ninject;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        public GeneticConfiguration GeneticConfiguration { get; private set; }
        public GeneticPopulation GeneticPopulation { get; private set; }
        public IGeneticEngine GeneticEngine { get; private set; }

        public GeneticAlgorithm(GeneticConfiguration configuration, IGeneticEngine geneticEngine)
        {
            GeneticPopulation = new GeneticPopulation(configuration);
        }
    }
}
