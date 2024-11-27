namespace jaxCalculatorProjectSWEFall2024;
using System.Collections.Generic;

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
    public static CalculationResult ComputeMean(List<float> values)
    {
        CalculationResult result = new CalculationResult();
        if (values.Count == 0)
        {
            result.SetWorking(false);
            result.SetMethodType("Mean");
            result.SetErrorMessage("Error: Input is empty.");
            return result;
        }
        float mean = 0;
        foreach (float x in values)
        {
            mean += x;
        }
        result.SetResult(mean/values.Count);
        result.SetWorking(true);
        result.SetMethodType("Mean");
        return result;
    }

    //input is 1 value per line, likely take in a List/Array of values (could also use a Stack or Queue)
    public static CalculationResult ComputeStandardDeviation(List<float> values, float mean, bool isPopulation)
    {
        CalculationResult result = new CalculationResult();
        float standardDeviation;
        float tempValueHolder = 0;
        if (isPopulation && values.Count < 2)
        {
            result.SetWorking(false);
            result.SetMethodType("Standard Deviation");
            result.SetErrorMessage("Error: Input Population is Too Small/Empty.");
            return result;
        }

        if (values.Count < 1)
        {
            result.SetWorking(false);
            result.SetMethodType("Standard Deviation");
            result.SetErrorMessage("Error: Input is Empty.");
            return result;
        }

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
        result.SetResult(standardDeviation);
        result.SetWorking(true);
        result.SetMethodType("Standard Deviation");
        
        return result;
    }


    //input is all on the same line
    public static CalculationResult ComputeZScore(float inputToSolve, float mean, float standardDeviation)
    {
        CalculationResult result = new CalculationResult();
        
        if (standardDeviation == 0)
        {
            result.SetWorking(false);
            result.SetMethodType("Z Score");
            result.SetErrorMessage("Error: Cannot Divide by Zero.");
        }
        
        result.SetResult((inputToSolve + mean)/(standardDeviation));
        result.SetWorking(true);
        result.SetMethodType("Z Score");
        return result;
    }
    

}