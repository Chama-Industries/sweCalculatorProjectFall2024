using Microsoft.AspNetCore.Components;

namespace CalculatorWebServerApp.Components.Pages;

public partial class Calculator : ComponentBase
{
    //this is where you send the stuff to your code
    private string Data { get; set; } = "";

    private string Message { get; set; } = "Enter values below, then select operation";
    
    public record Points(double X, double Y);
    
    private List<Points> _userInput = new List<Points>();
}