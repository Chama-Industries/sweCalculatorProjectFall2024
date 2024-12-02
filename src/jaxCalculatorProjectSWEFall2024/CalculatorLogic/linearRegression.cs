namespace jaxCalculatorProjectSWEFall2024;
using System;
using System.Collections.Generic;

public class LinearRegression
{
    //returns data in the form of y = mx + b
    public static CalculationResult ComputeSingularLinearRegression(List<string> uInput)
    {
        //preq-LOGIC-7
        List<double> xValues = new List<double>();
        List<double> yValues = new List<double>();
        CalculationResult result = new CalculationResult();
        //Logic to ensure that we have a set of variables we can work with
        if (uInput.Count < 1)
        {
            result.SetErrorMessage("Error: You cannot input an Empty List.");
            result.SetWorking(false);
            result.SetMethodType("Singular Linear Regression");
            return result;
        }


        //Logic to ensure that we have Numbers in both lists
        foreach (var u in uInput)
        {
            var points = u.Split(',');
            var xValueIsNumber = double.TryParse(points[0], out double x);
            if (xValueIsNumber)
            {
                xValues.Add(x);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(points[0]))
                {
                    {
                        result.SetErrorMessage("Error: The number of xValues and yValues do not match.");
                        result.SetWorking(false);
                        result.SetMethodType("Singular Linear Regression");
                        return result;
                    }
                }
                result.SetWorking(false);
                result.SetMethodType("Singular Linear Regression");
                result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
                return result;
            }
            var yValueIsNumber = double.TryParse(points[1], out double y);
            if (yValueIsNumber)
            {
                yValues.Add(y);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(points[1]))
                {
                    {
                        result.SetErrorMessage("Error: The number of xValues and yValues do not match.");
                        result.SetWorking(false);
                        result.SetMethodType("Singular Linear Regression");
                        return result;
                    }
                }
                result.SetWorking(false);
                result.SetMethodType("Singular Linear Regression");
                result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
                return result;
            }
        }
        
        //Logic to ensure that we have unique values
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
            //math is weird, got a suggestion on where to cutoff numbers being too similar
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


        double sumOfXValues = 0;
        double sumOfYValues = 0;
        double sumOfXValuesSquared = 0;
        double sumOfXAndYValues = 0;
        foreach (double x in xValues)
        {
            sumOfXValues += x;
        }

        foreach (double x in xValues)
        {
            sumOfXValuesSquared += Math.Pow(x, 2);
        }

        foreach (double y in yValues)
        {
            sumOfYValues += y;
        }

        for (int i = 0; i < xValues.Count; i++)
        {
            sumOfXAndYValues += xValues[i] * yValues[i];
        }

        var slope = ((xValues.Count * sumOfXAndYValues) - (sumOfXValues * sumOfYValues)) /
                    ((xValues.Count * sumOfXValuesSquared) - Math.Pow(sumOfXValues, 2));
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

    public static CalculationResult ComputeYFromLinearRegression(List<string> fullInput)
    {
        //preq-LOGIC-8
        var uInput = fullInput[0].Split(",");
        string inX = uInput[0];
        string inSlope = uInput[1];
        string inB = uInput[2];
        
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
        result.SetResult(Math.Round(slope * x + b, 5));
        result.SetEquationResult("" + slope + " * " + x + " + " + b);
        result.SetWorking(true);
        result.SetMethodType("Compute Y from Linear Regression");
        return result;
    }
}