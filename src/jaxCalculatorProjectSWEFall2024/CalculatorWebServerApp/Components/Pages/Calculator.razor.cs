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
    private string ResultMessage { get; set; } = "";
    
    //thing i send to code
    private List<string> _formattedStringInput = new();
    
    //allows me to change color of background if an error is thrown
    private string _upperColor = "background: #FFECD7; color: black";
    
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
        _upperColor = "alert alert-warning text-center background: #FFECD7; color: black";
        Message = "Enter values below, then select operation";
        ResultMessage = "";
    }
    
    private void ComputeSampleStandardDev(MouseEventArgs mouseEventArgs)
    {
        double calculatedMean = DescriptiveStatistics.ComputeMean(_formattedStringInput).GetResult(); 
        string mean = "" + calculatedMean;
        CalculationResult result = DescriptiveStatistics.ComputeStandardDeviation(_formattedStringInput, mean, false);
        if (result.GetWorking())
        {
            _upperColor = "background: #FFECD7; color: black";
            Message = result.GetMethodType();
            ResultMessage = "" + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            _upperColor = "background: #B70F0A; color: white";
            Message = "Invalid Input";
            ResultMessage = result.GetErrorMessage();
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
            _upperColor = "background: #FFECD7; color: black";
            Message = result.GetMethodType();
            ResultMessage = "" + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            _upperColor = "background: #B70F0A; color: white";
            Message = "Invalid Input";
            ResultMessage = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputeMean(MouseEventArgs mouseEventArgs)
    {
        CalculationResult result = DescriptiveStatistics.ComputeMean(_formattedStringInput);
        if (result.GetWorking())
        {
            _upperColor = "background: #FFECD7; color: black";
            Message = result.GetMethodType();
            ResultMessage = "" + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            _upperColor = "background: #B70F0A; color: white";
            Message = "Invalid Input";
            ResultMessage = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputeZScore(MouseEventArgs mouseEventArgs)
    {
        CalculationResult result = DescriptiveStatistics.ComputeZScore(_formattedStringInput);
        if (result.GetWorking())
        {
            _upperColor = "background: #FFECD7; color: black";
            Message = result.GetMethodType();
            ResultMessage = "" + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            _upperColor = "background: #B70F0A; color: white";
            Message = "Invalid Input";
            ResultMessage = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputeSingleLinearRegressionFormula(MouseEventArgs mouseEventArgs)
    {
        CalculationResult result = LinearRegression.ComputeSingularLinearRegression(_formattedStringInput);
        if (result.GetWorking())
        {
            _upperColor = "background: #FFECD7; color: black";
            Message = result.GetMethodType();
            ResultMessage = "" + result.GetEquationResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            _upperColor = "background: #B70F0A; color: white";
            Message = "Invalid Input";
            ResultMessage = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
    
    private void ComputeYPrediction(MouseEventArgs mouseEventArgs)
    {
        CalculationResult result = LinearRegression.ComputeYFromLinearRegression(_formattedStringInput);
        if (result.GetWorking())
        {
            _upperColor = "background: #FFECD7; color: black";
            Message = result.GetMethodType();
            ResultMessage = "" + result.GetResult();
            Data = "";
            _formattedStringInput.Clear();
        }
        else
        {
            _upperColor = "background: #B70F0A; color: white";
            Message = "Invalid Input";
            ResultMessage = result.GetErrorMessage();
            Data = "";
            _formattedStringInput.Clear();
        }
    }
}