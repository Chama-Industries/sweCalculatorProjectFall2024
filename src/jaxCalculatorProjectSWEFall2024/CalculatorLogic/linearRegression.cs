namespace jaxCalculatorProjectSWEFall2024;
using System;
using System.Collections.Generic;

public class LinearRegression
{
    //returns data in the form of y = mx + b
    public static string ComputerSingularLinearRegression(List<float> xValues, List<float> yValues)
    {
        float sumOfXValues = 0;
        float sumOfYValues = 0;
        float sumOfXValuesSquared = 0;
        float sumOfXAndYValues = 0;
        float slope = 0;
        float coefficient = 0;
        foreach (float x in xValues)
        {
            sumOfXValues += x;
        }

        foreach (float x in xValues)
        {
            sumOfXValuesSquared += (float)Math.Pow(x, 2);
        }

        foreach (float y in yValues)
        {
            sumOfYValues += y;
        }

        for (int i = 0; i < xValues.Count; i++)
        {
            sumOfXAndYValues += xValues[i] * yValues[i];
        }

        slope = ((xValues.Count * sumOfXAndYValues) - (sumOfXValues * sumOfYValues)) /
                ((xValues.Count * sumOfXValuesSquared) - (float)System.Math.Pow(sumOfXValues, 2));
        coefficient = (sumOfYValues - slope * sumOfXValues) / xValues.Count;

        return "" + slope + "x + " + coefficient;
    }

public static float ComputerYFromLinearRegression(float x, float slope, float b)
    {
        //uses y = mx + b (classic formula)
        return slope * x + b;
    }
}