using System.Diagnostics.CodeAnalysis;

namespace jaxCalculatorProjectSWEFall2024;
using System.Collections.Generic;

// stop saying I need to put Compute in front of these methods
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class CalculationResult
{
    private double _result;
    private string _equationResult = "";
    private bool _isWorking = true;
    private string _methodType = "";
    private string _errorMessage = "";

    public double GetResult()
    {
        return _result;
    }
    public void SetResult(double input)
    {
        _result = input;
    }

    public string GetEquationResult()
    {
        return _equationResult;
    }

    public void SetEquationResult(string equationResult)
    {
        _equationResult = equationResult;
    }
    public bool GetWorking()
    {
        return _isWorking;
    }

    public void SetWorking(bool input)
    {
        _isWorking = input;
    }

    public string GetMethodType()
    {
        return _methodType;
    }

    public void SetMethodType(string input)
    {
        _methodType = input;
    }

    public string GetErrorMessage()
    {
        return _errorMessage;
    }

    public void SetErrorMessage(string input)
    {
        _errorMessage = input;
    }
}

public class DescriptiveStatistics
{
    public static CalculationResult ComputeMean(List<string> values)
    {
        CalculationResult result = new CalculationResult();
        List<float> toCompute = new List<float>();
        foreach (string value in values)
        {
            if (!float.TryParse(value, out float parsedValue))
            {
                result.SetWorking(false);
                result.SetMethodType("Mean");
                result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
                return result;
            }
            toCompute.Add(parsedValue);
        }

        if (toCompute.Count == 0)
        {
            result.SetWorking(false);
            result.SetMethodType("Mean");
            result.SetErrorMessage("Error: Input is empty.");
            return result;
        }
        float mean = 0;
        foreach (float x in toCompute)
        {
            mean += x;
        }
        result.SetResult(mean/toCompute.Count);
        result.SetEquationResult("" + mean + " / " + toCompute.Count);
        result.SetWorking(true);
        result.SetMethodType("Mean");
        return result;
    }

    //input is 1 value per line, likely take in a List/Array of values (could also use a Stack or Queue)
    public static CalculationResult ComputeStandardDeviation(List<string> values, string inMean, bool isPopulation)
    {
        CalculationResult result = new CalculationResult();
        List<float> toCompute = new List<float>();
        foreach (string value in values)
        {
            if (!float.TryParse(value, out float parsedValue))
            {
                result.SetWorking(false);
                result.SetMethodType("Standard Deviation");
                result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
                return result;
            }
            toCompute.Add(parsedValue);
        }

        if (!float.TryParse(inMean, out float parsedMean))
        {
            result.SetWorking(false);
            result.SetMethodType("Standard Deviation");
            result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
            return result;
        }

        float mean = parsedMean;
        float standardDeviation;
        float tempValueHolder = 0;
        if (isPopulation && toCompute.Count < 2)
        {
            result.SetWorking(false);
            result.SetMethodType("Standard Deviation");
            result.SetErrorMessage("Error: Input Population is Too Small/Empty.");
            return result;
        }

        if (toCompute.Count < 1)
        {
            result.SetWorking(false);
            result.SetMethodType("Standard Deviation");
            result.SetErrorMessage("Error: Input is Empty.");
            return result;
        }

        //account for both Sample and Population, likely just use a boolean to differentiate between the two
        if (isPopulation)
        {
            foreach (float x in toCompute)
            {
                tempValueHolder += (float)Math.Pow(Math.Abs(x - mean), 2);
            }

            result.SetEquationResult("\u221a(" + tempValueHolder + " / " + toCompute.Count + ")");
            standardDeviation = (float)Math.Sqrt(tempValueHolder/values.Count);
        }
        else
        {
            foreach (float x in toCompute)
            {
                tempValueHolder += (float)Math.Pow(Math.Abs(x - mean), 2);
            }

            result.SetEquationResult("\u221a(" + tempValueHolder + " / " + (toCompute.Count-1) + ")");
            standardDeviation = (float)Math.Sqrt(tempValueHolder/(values.Count-1));
        }
        result.SetResult(standardDeviation);
        result.SetWorking(true);
        result.SetMethodType("Standard Deviation");
        
        return result;
    }
    
    //input is all on the same line
    public static CalculationResult ComputeZScore(string stringToParse, string inMean, string inStandardDeviation)
    {
        CalculationResult result = new CalculationResult();
        if (!float.TryParse(stringToParse, out float parsedValueI))
        {
            result.SetWorking(false);
            result.SetMethodType("Z Score");
            result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
            return result;
        }
        float mean = parsedValueI;
        
        if (!float.TryParse(inMean, out float parsedValueM))
        {
            result.SetWorking(false);
            result.SetMethodType("Z Score");
            result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
            return result;
        }
        float inputToSolve = parsedValueM;
        
        if (!float.TryParse(inStandardDeviation, out float parsedValueStDev))
        {
            result.SetWorking(false);
            result.SetMethodType("Z Score");
            result.SetErrorMessage("Error: Cannot input non numbers into the calculation.");
            return result;
        }
        float standardDeviation = parsedValueStDev;
        
        if (standardDeviation == 0)
        {
            result.SetWorking(false);
            result.SetMethodType("Z Score");
            result.SetErrorMessage("Error: Cannot Divide by Zero.");
        }
        
        result.SetResult((inputToSolve + mean)/(standardDeviation));
        result.SetEquationResult("(" + inputToSolve + mean + ") / " + standardDeviation);
        result.SetWorking(true);
        result.SetMethodType("Z Score");
        return result;
    }
}