﻿using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Tank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.GeneticTests
{
    [TestClass]
    public class MutationMethods_Test
    {
        private Mutation mutation;

        [TestInitialize]
        public void TestInitialize()
        {
            mutation = new Mutation();
        }

        [TestMethod]
        public void GetMutatesSpecies_on_mutation_count_2_returns_2_species()
        {
            var population = new List<TankStrategy>
            {
                new TankStrategy(new List<Command> {Command.MoveBackward, Command.MoveBackward}),
                new TankStrategy(new List<Command> {Command.MoveForward, Command.MoveForward})
            };

            var mutatedSpecies = mutation.GetMutatedSpecies(population, 2);
            Assert.AreEqual(2, mutatedSpecies.Count());
        }
    }
}
