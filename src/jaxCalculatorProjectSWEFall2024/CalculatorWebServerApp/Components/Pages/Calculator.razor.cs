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
    
    private void ComputeHandleDataChange(ChangeEventArgs uInput)
    {
        //if it ain't broke don't fix it
        Data = uInput.Value?.ToString() ?? string.Empty;
        var singleLineInput = Data.Split('\n');
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
        Message = "This does something in the future for the Mean.";
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