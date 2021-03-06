﻿using AHP.Model.Common.Model_Interfaces;
using AHP.Service.Common.AHPCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.CalculationClasses
{
    public class DataPreparation : IDataPreparation
    {
        #region methods
        public double[] NormalizeVector(double[] vector)
        {
            /// <summary>
            /// Method for normalizing vector.
            /// </summary>
            /// <param name="vector">Input vector that needs to be normalized</param>
            /// <returns>
            /// Normalized vector.
            /// </returns>

            int len = vector.Length;
            double sum = 0;

            double[] NormalizedVector = new double[len];

            for (int i = 0; i < len; i++)
            {
                sum += vector[i];
            }

            for (int i = 0; i < len; i++)
            {
                NormalizedVector[i] = vector[i] / sum;
            }

            return NormalizedVector;
        } 

        public double[][] Get2dArray(List<ICriteriaModel> criterias)
        {
            List<List<double>> lista = new List<List<double>>();
            var sorted = criterias.OrderBy(c => c.Order).ToList();
            foreach(var crit in sorted)
            {
                List<double>priorities = new List<double>();
                var sortedByAlternatives = crit.AlternativeRanks.OrderBy(ar => ar.Alternative1).ThenBy(ar => ar.Alternative2).ToList();
                foreach(var priority in sortedByAlternatives)
                {
                    priorities.Add(priority.Preference);
                }               
                lista.Add(priorities);
            }
            return lista.Select(a => a.ToArray()).ToArray();
        }

        public double[] GetCriteriaRanks(List<ICriteriaModel> criterias)
        {
            List<double> priorities = new List<double>();
            foreach(var crit in criterias.OrderBy(c=>c.Order))
            {                
                foreach (var criteriaRank in crit.CriteriaRanks.OrderBy(ce=>ce.Column))
                {
                    priorities.Add(criteriaRank.Priority);
                }
            }
            return priorities.ToArray();
        }
        #endregion methods

       

    }
}
