﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service
{
    class AlternativeService
    {
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
        public double[,] CreateMatrix(int[] array, int dimension)
        {
            /// <summary>
            /// Method for creating square matrix out of a given array.
            /// </summary>
            /// <param name="array">Desired array for matrix</param>
            /// <param name="dimension">Desired matrix dimension</param>
            /// <returns>
            /// Matrix (dimension x dimension) with array elements as upper triangle, ones on diagonal 
            /// and lower triangle with values symmetrically reciprocal to upper triangle.
            /// </returns>

            int d = dimension;

            double[,] Matrix = new double[dimension, dimension];

            // Number of elements in upper triangle has to be (d * d - d) / 2
            if (array.Length == (d * d - d) / 2)
            {
                int k = 0;
                for (int i = 0; i < d; i++)
                {
                    Matrix[i, i] = 1;
                    for (int j = 0; j < d; j++)
                    {
                        if (j > i)
                        {

                            Matrix[i, j] = array[k];
                            k++;
                            Matrix[j, i] = 1 / Matrix[i, j];
                        }
                    }
                }
                return Matrix;
            }
            else
            {
                return null;
            }
        }

        public double[] CalculatePriority(double[,] Matrix)
        {
            /// <summary>
            /// Method for calculating priorities of given parameters (criterion or alternatives).
            /// </summary>
            /// <param name="Matrix">Square parameter matrix.</param>
            /// <returns>
            /// Array of priorities.
            /// </returns>

            // Matrix size
            int len = Matrix.GetLength(0);

            // Array of geometric means
            double[] GeoMeans = new double[len];

            double sum = 0;
            for (int i = 0; i < len; i++)
            {
                double prod = 1;
                for (int j = 0; j < len; j++)
                {
                    prod *= Matrix[i, j];
                }
                GeoMeans[i] = Math.Pow(prod, (1 / (float)len));
                sum += GeoMeans[i];
            }

            return NormalizeVector(GeoMeans);
        }

        public double[] AHPMethod(int[] CriteriaPreference, int[][] AlternativePreferences)
        {
            /// <summary>
            /// Method for calculating final decision using AHP method, with given criteria preferences and alternative preference for every criterion.
            /// </summary>
            /// <param name="CriteriaPreference">Array of criterion preferences</param>
            /// <param name="AlternativePreferences">Jagged array of alternative preferences for every criterion</param>
            /// <returns>
            /// Array of priorities for every alternative.
            /// </returns>

            //int[] Kriterij = new int[(m * m - m) / 2];
            //int[] Kriterij = new int[] { 1, 3, 5 };

            int numberOfCriterions = CriteriaPreference.Length;
            int numberOfAlternatives = AlternativePreferences.Length;

            double[] CriteriaPriority = new double[numberOfCriterions];
            CriteriaPriority = CalculatePriority(CreateMatrix(CriteriaPreference, numberOfCriterions));

            // Matrix containing final weights
            // w_{i,j} = priority of i-th alternative considering j-th criterion
            double[,] W = new double[numberOfAlternatives, numberOfCriterions];

            for (int i = 0; i < numberOfCriterions; i++)
            {
                // Array of Alternative preferences considering i-th criterion
                int[] currentAlternatives = AlternativePreferences[i];

                // Array of priorities considering i-th criterion
                double[] AlternativePriority = CalculatePriority(CreateMatrix(currentAlternatives, numberOfAlternatives));

                for (int j = 0; j < numberOfAlternatives; j++)
                {
                    // Setting i-th column of matrix W to priorities of all alternatives
                    W[j, i] = AlternativePriority[j];
                }
            }

            double[] FinalDecision = new double[numberOfAlternatives];

            for (int i = 0; i < numberOfAlternatives; i++)
            {
                for (int j = 0; j < numberOfCriterions; j++)
                {
                    FinalDecision[i] += W[i, j] * CriteriaPriority[j];
                }
            }
            return NormalizeVector(FinalDecision);
        }
    }
}