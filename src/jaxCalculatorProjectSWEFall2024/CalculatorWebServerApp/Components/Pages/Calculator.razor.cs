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
    
    // only used for Single Linear Regression, all the others just have different formatting
    public record Points(double X, double Y);
    
    private List<Points> UserInput { get; set; } = new();
    
    private List<string> _formattedStringInput = new();
    
    private void ComputeHandleDataChange(ChangeEventArgs uInput)
    {
        //Relevant Code to put input into a workable format for the Linear Regression call, otherwise its just left as a list of strings if applicable
        Data = uInput.Value?.ToString() ?? string.Empty;
        var singleLineInput = Data.Split('\n');
        foreach (var line in singleLineInput)
        {
            //saved so we can use it in other methods without having to come back here
            _formattedStringInput.Add(line);
        }
        foreach (var pair in singleLineInput)
        {
            var xy = pair.Split(',');
            if (xy.Length != 2) continue;

            if (!double.TryParse(xy[0], out var x) || !double.TryParse(xy[1], out var y)) continue;
            UserInput.Add(new Points(x, y));
        }

        Message = string.Join(", ", UserInput);
        StateHasChanged();
    }

    private void OnClickResetCalculator(MouseEventArgs mouseEventArgs)
    {
        Data = "";
        Message = "Enter values below, then select operation";
    }
    
    private void ComputeSampleStandardDev(MouseEventArgs mouseEventArgs)
    {
        Message = "This does something in the future for the Sample Standard Dev.";
    }
    
    private void ComputePopulationStandardDev(MouseEventArgs mouseEventArgs)
    {
        Message = "This does something in the future for the Population Standard Dev.";
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
        Message = "This does something in the future for the Z Score.";
    }
    
    private void ComputeSingleLinearRegressionFormula(MouseEventArgs mouseEventArgs)
    {
        Message = "This does something in the future for the Maths.";
    }
    
    private void ComputeYPrediction(MouseEventArgs mouseEventArgs)
    {
        Message = "This does something in the future for the thing that uses the points.";
    }
}