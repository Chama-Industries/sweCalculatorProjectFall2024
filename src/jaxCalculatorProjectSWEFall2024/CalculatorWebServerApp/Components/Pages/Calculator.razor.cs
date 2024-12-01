using jaxCalculatorProjectSWEFall2024;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CalculatorWebServerApp.Components.Pages;

public partial class Calculator : ComponentBase
{
    //this is where you send the stuff to your code
    private string Data { get; set; } = "";

    //getters and setters can be included in the base initialization, that's cool
    private string Message { get; set; } = "Enter values below, then select operation";
    
    private List<string> _formattedStringInput = new();
    
    private void ComputeHandleDataChange(ChangeEventArgs uInput)
    {
        //splits up the input into a list of strings, other stuff is handled by Calculator Logic
        Data = uInput.Value?.ToString() ?? string.Empty;
        var singleLineInput = Data.Split('\n');
        foreach (var line in singleLineInput)
        {
            //saved so we can use it in other methods without having to come back here
            _formattedStringInput.Add(line);
        }
    }

    private void OnClickResetCalculator(MouseEventArgs mouseEventArgs)
    {
        Data = "";
        _formattedStringInput.Clear();
        Message = "Enter values below, then select operation";
    }
    
    private void ComputeSampleStandardDev(MouseEventArgs mouseEventArgs)
    {
        double calculatedMean = DescriptiveStatistics.ComputeMean(_formattedStringInput).GetResult(); 
        string mean = "" + calculatedMean;
        CalculationResult result = DescriptiveStatistics.ComputeStandardDeviation(_formattedStringInput, mean, false);
        if (result.GetWorking())
        {
            Message = result.GetEquationResult() + "\n " + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            Message = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputePopulationStandardDev(MouseEventArgs mouseEventArgs)
    {
        double calculatedMean = DescriptiveStatistics.ComputeMean(_formattedStringInput).GetResult(); 
        string mean = "" + calculatedMean;
        CalculationResult result = DescriptiveStatistics.ComputeStandardDeviation(_formattedStringInput, mean, true);
        if (result.GetWorking())
        {
            Message = result.GetEquationResult() + "\n " + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            Message = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputeMean(MouseEventArgs mouseEventArgs)
    {
        CalculationResult result = DescriptiveStatistics.ComputeMean(_formattedStringInput);
        if (result.GetWorking())
        {
            Message = result.GetEquationResult() + "\n " + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            Message = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputeZScore(MouseEventArgs mouseEventArgs)
    {
        var inputMaterials = Data.Split(",");
        CalculationResult result = DescriptiveStatistics.ComputeZScore(inputMaterials[0], inputMaterials[1], inputMaterials[2]);
        if (result.GetWorking())
        {
            Message = result.GetEquationResult() + "\n " + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            Message = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputeSingleLinearRegressionFormula(MouseEventArgs mouseEventArgs)
    {
        CalculationResult result = LinearRegression.ComputeSingularLinearRegression(_formattedStringInput);
        if (result.GetWorking())
        {
            Message = result.GetEquationResult() + "\n " + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            Message = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputeYPrediction(MouseEventArgs mouseEventArgs)
    {
        var inputMaterials = Data.Split(",");
        CalculationResult result = LinearRegression.ComputeYFromLinearRegression(inputMaterials[0], inputMaterials[1], inputMaterials[2]);
        if (result.GetWorking())
        {
            Message = result.GetEquationResult() + "\n " + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            Message = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
}