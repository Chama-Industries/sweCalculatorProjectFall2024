namespace jaxCalculatorProjectSWEFall2024;
using System;
using System.Collections.Generic;

public class LinearRegression
{
    //returns data in the form of y = mx + b
    public static CalculationResult ComputeSingularLinearRegression(List<double> xValues, List<double> yValues)
    {
        CalculationResult result = new CalculationResult();
        if (xValues.Count < 1 || yValues.Count < 1)
        {
            result.SetErrorMessage("Error: You cannot input an Empty List.");
            result.SetWorking(false);
            result.SetMethodType("Singular Linear Regression");
            return result;
        }

        if (xValues.Count != yValues.Count)
        {
            result.SetErrorMessage("Error: The number of xValues and yValues do not match.");
            result.SetWorking(false);
            result.SetMethodType("Singular Linear Regression");
            return result;
        }
        
        int counter = 0;
        int yCounter = 0;
        foreach (var x in xValues)
        {
            if (x == 0)
            {
                counter++;
            }
        }
        foreach (var y in yValues)
        {
            if (y == 0)
            {
                yCounter++;
            }
        }
        if (counter == xValues.Count && yCounter == yValues.Count)
        {
            result.SetErrorMessage("Error: You cannot input two lists with only Zeroes.");
            result.SetWorking(false);
            result.SetMethodType("Singular Linear Regression");
            return result;
        }


        counter = 0;
        var checker = xValues[0];
        foreach (var x in xValues)
        {
            //floats are weird, got a suggestion on where to cutoff numbers being too similar
            if (Math.Abs(x - checker) < 0.001)
            {
                counter++;
            }
        }
        if (counter == xValues.Count)
        {
            result.SetErrorMessage("Error: You cannot input a list with only duplicate values.");
            result.SetWorking(false);
            result.SetMethodType("Singular Linear Regression");
            return result;
        }
        counter = 0;
        checker = yValues[0];
        foreach (var y in yValues)
        {
            if (Math.Abs(y - checker) < 0.001)
            {
                counter++;
            }
        }
        if (counter == yValues.Count)
        {
            result.SetErrorMessage("Error: You cannot input a list with only duplicate values.");
            result.SetWorking(false);
            result.SetMethodType("Singular Linear Regression");
            return result;
        }


        float sumOfXValues = 0;
        float sumOfYValues = 0;
        float sumOfXValuesSquared = 0;
        double sumOfXAndYValues = 0;
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

        var slope = ((xValues.Count * sumOfXAndYValues) - (sumOfXValues * sumOfYValues)) /
                    ((xValues.Count * sumOfXValuesSquared) - (float)Math.Pow(sumOfXValues, 2));
        var coefficient = (sumOfYValues - slope * sumOfXValues) / xValues.Count;
        string slopeConvert = "" + slope;
        string coefficientConvert = "" + coefficient;

        int isSlopeNegative = 0;
        if (slope < 0)
        {
            isSlopeNegative = 1;
        }
        int isCoefficientNegative = 0;
        if (coefficient < 0)
        {
            isCoefficientNegative = 1;
        }
        
        result.SetEquationResult(slopeConvert.Substring(0,5+isSlopeNegative) + "x + " + coefficientConvert.Substring(0,5+isCoefficientNegative));
        result.SetWorking(true);
        result.SetMethodType("Singular Linear Regression");
        return result;
    }

    public static CalculationResult ComputeYFromLinearRegression(string inX, string inSlope, string inB)
    {
        CalculationResult result = new CalculationResult();
        if (!float.TryParse(inX, out float parsedValueX))
        {
            result.SetWorking(false);
            result.SetMethodType("Compute Y from Linear Regression");
            result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
            return result;
        }
        float x = parsedValueX;
        
        if (!float.TryParse(inSlope, out float parsedValueS))
        {
            result.SetWorking(false);
            result.SetMethodType("Compute Y from Linear Regression");
            result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
            return result;
        }
        float slope = parsedValueS;
        
        if (!float.TryParse(inB, out float parsedValueB))
        {
            result.SetWorking(false);
            result.SetMethodType("Compute Y from Linear Regression");
            result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
            return result;
        }
        float b = parsedValueB;
        
        //uses y = mx + b (classic formula)
        result.SetResult(slope * x + b);
        result.SetEquationResult("" + slope + " * " + x + " + " + b);
        result.SetWorking(true);
        result.SetMethodType("Compute Y from Linear Regression");
        return result;
    }
}