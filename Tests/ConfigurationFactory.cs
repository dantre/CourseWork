﻿using System;
using GeneticProgramming.Configurations;
using GeneticProgramming.Configurations.PartialConfigs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public static class ConfigurationFactory
    {
        public static Configuration Configuration => new Configuration
        {
            GeneticConfig = new GeneticConfig
            {
                PopulationSize = 5,
                CrossoverProb = 0.90,
                MutationProb = 0.05,
                PanmixiaRatio = 0.4,
                InbreedRatio = 0.3,
                OutbreedRatio = 0.3,
                MaxStrategySize = 10
            },
            MapConfig = new MapConfig
            {
                Height = 10,
                Width = 15,
                EnemiesCount = 5,
                ObstaclesCount = 10,
                FireArea = 2,
                ViewArea = 4
            },
            StrategyGeneratorConfig = new StrategyGeneratorConfig
            {
                CloseBracketCoefficient = 0.7,
                NewFunctionCoefficient = 0.5
            }
        };
    }

    [TestClass]
    public class TestConfiguration
    {
        [TestMethod]
        public void Deserialize()
        {
            ConfigurationFactory.Configuration.SerializeToFile("ASD");

            var index = 3;
            add(index);
            Console.WriteLine(index);

            var c = new ComplexClass
            {
                i = 3
            };
            add2(c);
            Console.WriteLine(c.i);
        }

        void add2(ComplexClass c)
        {
            c.i++;
            Console.WriteLine(c.i);

        }
        class ComplexClass
        {
            public int i;
        }
        void add(int i)
        {
            i++;
            Console.WriteLine($"add {i}");
        }
    }
}
