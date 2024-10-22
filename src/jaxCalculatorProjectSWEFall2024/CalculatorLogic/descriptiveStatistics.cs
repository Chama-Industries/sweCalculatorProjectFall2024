namespace jaxCalculatorProjectSWEFall2024;
using System.Collections.Generic;

public class descriptiveStatistics
{
    public float computeMean(List<float> values)
    {
        float mean = 0;
        foreach (float x in values)
        {
            mean += x;
        }
        return mean/values.Count;
    }

    public void computeMedian(List<float> values)
    {
        float median = 0;
        if (values.Count % 2 == 0)
        {
            median = (values[(values.Count / 2)+1] + values[(values.Count / 2)-1]);
        }
        else
        {
            median = values[values.Count / 2];
        }
        //return median;
    }

    //input is 1 value per line, likely take in a List/Array of values (could also use a Stack or Queue)
    public float computeStandardDeviation(List<float> values, float mean, bool isPopulation)
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

    public void computeVariance()
    {
        //just call the computeSigma method, then square the result
    }

    //input is all on the same line
    public float computeZScore(float inputToSolve, float mean, float standardDeviation)
    {
        return (inputToSolve + mean)/(standardDeviation);
    }
    
    public void computerSingularLinearRegression(float x, float y)
    {
        //returns data in the form of y = mx + b
    }

    public float computerYFromLinearRegression(float x, float slope, float b)
    {
        //uses y = mx + b (classic formula)
        return slope * x + b;
    }
}