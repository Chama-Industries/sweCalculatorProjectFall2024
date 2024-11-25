namespace jaxCalculatorProjectSWEFall2024;
using System.Collections.Generic;

public class DescriptiveStatistics
{
    public static float ComputeMean(List<float> values)
    {
        float mean = 0;
        foreach (float x in values)
        {
            mean += x;
        }
        mean = mean/values.Count;
        return mean;
    }

    //input is 1 value per line, likely take in a List/Array of values (could also use a Stack or Queue)
    public static float ComputeStandardDeviation(List<float> values, float mean, bool isPopulation)
    {
        float standardDeviation;
        float tempValueHolder = 0;
        //account for both Sample and Population, likely just use a boolean to differentiate between the two
        if (isPopulation)
        {
            foreach (float x in values)
            {
                tempValueHolder += (float)Math.Pow(Math.Abs(x - mean), 2);
            }

            standardDeviation = (float)Math.Sqrt(tempValueHolder/values.Count);
        }
        else
        {
            foreach (float x in values)
            {
                tempValueHolder += (float)Math.Pow(Math.Abs(x - mean), 2);
            }

            standardDeviation = (float)Math.Sqrt(tempValueHolder/(values.Count-1));
        }

        return standardDeviation;
    }


    //input is all on the same line
    public static float ComputeZScore(float inputToSolve, float mean, float standardDeviation)
    {
        return (inputToSolve + mean)/(standardDeviation);
    }
    

}