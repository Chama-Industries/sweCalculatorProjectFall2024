namespace CalculatorEnd_to_EndTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    //preq-E2E-TEST-5
    [Test]
    public async Task CalculatorWebUi_PageTitle_IsCalculator()
    {
        const string url = "http://localhost:5096/";
        const string pageTitle = "Calculator";
        await Page.GotoAsync(url);
        
        await Expect(Page).ToHaveTitleAsync(pageTitle);
    }
}