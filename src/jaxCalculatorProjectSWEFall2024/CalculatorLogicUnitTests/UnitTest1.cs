using jaxCalculatorProjectSWEFall2024;

namespace CalculatorLogicUnitTests;

public class Tests
{
    [Test]
    public void ComputeMean_ListOfFloatingPointValues_ReturnsCorrectMean()
    {
        // Assert (declare variables needed for testing)
        List<float> values = new List<float>();
        values.Add(9);
        values.Add(6);
        values.Add(8);
        values.Add(5);
        values.Add(7);
        const float expected = 7.0f;
        
        // Act (Call the Method/System you wish to test
        var result = DescriptiveStatistics.ComputeMean(values);
        
        // Assert (Check to see that the result is what you expected)
        Assert.That(result, Is.EqualTo(expected));
    }
}