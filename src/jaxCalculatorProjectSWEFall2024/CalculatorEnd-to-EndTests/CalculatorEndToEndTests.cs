using Microsoft.Playwright;

namespace CalculatorEnd_to_EndTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task CalculatorWebUi_PageTitle_IsCalculator()
    {
        //preq-E2E-TEST-5
        const string url = "http://localhost:5096/";
        const string pageTitle = "Calculator";
        await Page.GotoAsync(url);
        
        await Expect(Page).ToHaveTitleAsync(pageTitle);
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputeSampleStandardDeviation_IsDouble()
    {
        //preq-E2E-TEST-6
        const string url = "http://localhost:5096/";
        const string calculationResult = "3.060788";
        await Page.GotoAsync(url);
        await Page.ClickAsync("'Clear'");

        await Page.GetByRole(AriaRole.Textbox)
            .FillAsync("9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4");

        await Page.ClickAsync("'Compute Sample Standard Deviation | one value per line'");

        await Expect(Page.GetByTestId("resultDisplay")).ToHaveTextAsync(calculationResult);
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputePopulationStandardDeviationWithEmptyList_ReturnsError()
    {
        //preq-E2E-TEST-7
        const string url = "http://localhost:5096/";
        const string calculationResult = "Error: Input Population is Too Small/Empty.";
        await Page.GotoAsync(url);
        await Page.ClickAsync("'Clear'");
        
        await Page.GetByRole(AriaRole.Textbox)
            .FillAsync("");

        await Page.ClickAsync("'Compute Population Standard Deviation | one value per line'");

        await Expect(Page.GetByTestId("resultDisplay")).ToHaveTextAsync(calculationResult);
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputeSampleStandardDeviationWithTinyList_ReturnsError()
    {
        //preq-E2E-TEST-8
        const string url = "http://localhost:5096/";
        const string calculationResult = "Error: Input Population is Too Small/Empty.";
        await Page.GotoAsync(url);
        await Page.ClickAsync("'Clear'");
        
        await Page.GetByRole(AriaRole.Textbox)
            .FillAsync("1");

        await Page.ClickAsync("'Compute Population Standard Deviation | one value per line'");

        await Expect(Page.GetByTestId("resultDisplay")).ToHaveTextAsync(calculationResult);
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputeMean_IsDouble()
    {
        //preq-E2E-TEST-9
        const string url = "http://localhost:5096/";
        const string calculationResult = "7";
        await Page.GotoAsync(url);
        await Page.ClickAsync("'Clear'");

        await Page.GetByRole(AriaRole.Textbox)
            .FillAsync("9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4");

        await Page.ClickAsync("'Compute Mean | one value per line'");

        await Expect(Page.GetByTestId("resultDisplay")).ToHaveTextAsync(calculationResult);
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputeZScore_IsDouble()
    {
        //preq-E2E-TEST-10
        const string url = "http://localhost:5096/";
        const string calculationResult = "0.49007";
        await Page.GotoAsync(url);
        await Page.ClickAsync("'Clear'");

        await Page.GetByRole(AriaRole.Textbox)
            .FillAsync("5.5,7,3.060787652326");

        await Page.ClickAsync("'Compute Z Score | value, mean, stdDev on one line'");

        await Expect(Page.GetByTestId("resultDisplay")).ToHaveTextAsync(calculationResult);
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputeSingleLinearRegressionFormula_IsAnEquation()
    {
        //preq-E2E-TEST-11
        const string url = "http://localhost:5096/";
        const string calculationResult = "-0.045x + 6.933";
        await Page.GotoAsync(url);
        await Page.ClickAsync("'Clear'");

        await Page.GetByRole(AriaRole.Textbox)
            .FillAsync("5,3\n3,2\n2,15\n1,12.3\n7.5,-3\n4,5\n3,17\n4,3\n6.42,4\n34,5\n12,17\n3,-1");

        await Page.ClickAsync("'Compute Single Linear Regression Formula | one X,Y pair per line'");

        await Expect(Page.GetByTestId("resultDisplay")).ToHaveTextAsync(calculationResult);
    }
    
    [Test]
    public async Task CalculatorWebUi_PredictYUsingLinearRegressionFormula_IsDouble()
    {
        //preq-E2E-TEST-12
        const string url = "http://localhost:5096/";
        const string calculationResult = "6.65784";
        await Page.GotoAsync(url);
        await Page.ClickAsync("'Clear'");

        await Page.GetByRole(AriaRole.Textbox)
            .FillAsync("6,-0.04596,6.9336");

        await Page.ClickAsync("'Predict Y from Linear Regression Formula | x, m, b on one line'");

        await Expect(Page.GetByTestId("resultDisplay")).ToHaveTextAsync(calculationResult);
    }
}