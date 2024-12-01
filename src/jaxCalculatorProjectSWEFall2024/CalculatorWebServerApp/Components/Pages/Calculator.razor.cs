using Microsoft.AspNetCore.Components;

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
    
    private void ComputeHandleDataChange(string uInput)
    {
        Data = uInput;
        var singleLineInput = Data.Split('\n');
        foreach (var pair in singleLineInput)
        {
            var xy = pair.Split(',');
            if (xy.Length != 2) continue;

            if (!double.TryParse(xy[0], out var x) || !double.TryParse(xy[1], out var y)) continue;
            UserInput.Add(new Points(x, y));
        }

        Message = string.Join(", ", UserInput);
    }

    private void ComputeChangeMessage()
    {
        Message = "Test Message";
    }
}