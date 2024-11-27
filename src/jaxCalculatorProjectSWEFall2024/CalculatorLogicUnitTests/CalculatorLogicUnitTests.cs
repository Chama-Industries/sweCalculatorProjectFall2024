using jaxCalculatorProjectSWEFall2024;

namespace CalculatorLogicUnitTests;

public class CalculatorLogicUnitTests
{
    // Calculation Result Tests for Coverage (make sure it works)
    
    // Descriptive Statistics Logic Tests
    [Test]
    public void ComputeMean_ListOfFloatingPointValues_ReturnsCorrectMean()
    {
        // Arrange (declare variables needed for testing)
        List<float> values = new List<float>();
        values.Add(9);
        values.Add(6);
        values.Add(8);
        values.Add(5);
        values.Add(7);
        const double expected = 7;
        
        // Act (Call the Method/System you wish to test
        var result = DescriptiveStatistics.ComputeMean(values);
        
        // Assert (Check to see that the result is what you expected)
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeMean_ListOfFloatingPointValues_ReturnsZero()
    {
        // Arrange (declare variables needed for testing)
        List<float> values = new List<float>();
        values.Add(10);
        values.Add(-10);
        values.Add(45);
        values.Add(0);
        values.Add(-45);
        const double expected = 0;
        
        // Act (Call the Method/System you wish to test
        var result = DescriptiveStatistics.ComputeMean(values);
        
        // Assert (Check to see that the result is what you expected)
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeMean_EmptyList_ReturnsError()
    {
        // Arrange
        List<float> values = new List<float>();
        const string expected = "Error: Input is empty.";
        
        // Act
        var result = DescriptiveStatistics.ComputeMean(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeStandardDeviation_ListOfFloatingPointValuesFloatAndBoolean_ReturnsSampleStandardDeviation()
    {
        // Arrange
        const float mean = 7.0f;
        const bool isPopulation = false;
        List<float> values = new List<float>();
        values.Add(9);
        values.Add(6);
        values.Add(8);
        values.Add(5);
        values.Add(7);
        const double expected = 1.5811388492584229;
        
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeStandardDeviation_ListOfFloatingPointValuesFloatAndBoolean_ReturnsPopulationStandardDeviation()
    {
        // Arrange
        const float mean = 7.0f;
        const bool isPopulation = true;
        List<float> values = new List<float>();
        values.Add(9);
        values.Add(6);
        values.Add(8);
        values.Add(5);
        values.Add(7);
        const double expected = 1.4142135381698608;
        
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeStandardDeviation_SmallPopulationList_ReturnsPopulationError()
    {
        // Arrange
        List<float> values = new List<float>();
        values.Add(9);
        const float mean = 0.0f;
        const bool isPopulation = true;
        const string expected = "Error: Input Population is Too Small/Empty.";
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeStandardDeviation_EmptyPopulationList_ReturnsError()
    {
        // Arrange
        List<float> values = new List<float>();
        const float mean = 0.0f;
        const bool isPopulation = true;
        const string expected = "Error: Input Population is Too Small/Empty.";
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeStandardDeviation_EmptySampleList_ReturnsError()
    {
        // Arrange
        List<float> values = new List<float>();
        const float mean = 0.0f;
        const bool isPopulation = false;
        const string expected = "Error: Input is Empty.";
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeZScore_ThreeFloatingPointValues_ReturnsZScore()
    {
        // Arrange
        const float inputValue = 3.0f;
        const float mean = 7.0f;
        const float standardDeviation = 2.0f;
        const float expected = 5.0f;
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(inputValue, mean, standardDeviation);
        
        // Assert
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeZScore_ZeroStandardDeviation_ReturnsDivideByZeroError()
    {
        // Arrange
        const float inputValue = 3.0f;
        const float mean = 7.0f;
        const float standardDeviation = 0.0f;
        const string expected = "Error: Cannot Divide by Zero.";
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(inputValue, mean, standardDeviation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    // Linear Regression Logic Tests
    [Test]
    public void ComputeSingleLinearRegression_TwoListsOfFloatingPointValues_ReturnsSingleLinearRegressionFormula()
    {
        // Arrange
        List<double> xValues =
        [
            1.47,
            1.5,
            1.52,
            1.55,
            1.57,
            1.6,
            1.63,
            1.65,
            1.68,
            1.7,
            1.73,
            1.75,
            1.78,
            1.8,
            1.83
        ];
        List<double> yValues =
        [
            52.21,
            53.12,
            54.48,
            55.84,
            57.2,
            58.57,
            59.93,
            61.29,
            63.11,
            64.47,
            66.28,
            68.1,
            69.92,
            72.19,
            74.46
        ];
        //we round to 2 decimal places here, looks nicer (and prevents everything from setting ablaze)
        const string expected = "61.27x + -39.06";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(xValues, yValues);
        
        // Assert
        Assert.That(result.GetEquationResult(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeSingleLinearRegression_AtLeastOneListEmpty_ReturnsError()
    {
        // Arrange
        List<double> xValues = new List<double>();
        List<double> yValues = new List<double>();
        const string expected = "Error: You cannot input an Empty List.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(xValues, yValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeSingleLinearRegression_XListOfDuplicates_ReturnsError()
    {
        // Arrange
        List<double> xValues = [
            1,
            1,
            1,
            1,
            1,
            1.0,
            1,
            1,
            1,
            1,
            1,
            1,
            1.0,
            1,
            1
        ];
        List<double> yValues = [
            52.21,
            53.12,
            54.48,
            55.84,
            57.2,
            58.57,
            59.93,
            61.29,
            63.11,
            64.47,
            66.28,
            68.1,
            69.92,
            72.19,
            74.46
        ];
        const string expected = "Error: You cannot input a list with only duplicate values.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(xValues, yValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_YListOfDuplicates_ReturnsError()
    {
        // Arrange
        List<double> xValues = [
            1.47,
            1.5,
            1.52,
            1.55,
            1.57,
            1.6,
            1.63,
            1.65,
            1.68,
            1.7,
            1.73,
            1.75,
            1.78,
            1.8,
            1.83
        ];
        List<double> yValues = [
            5,
            5,
            5,
            5,
            5,
            5,
            5.0,
            5,
            5,
            5,
            5,
            5,
            5.0,
            5,
            5
        ];
        const string expected = "Error: You cannot input a list with only duplicate values.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(xValues, yValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_TwoListOfZeroes_ReturnsError()
    {
        // Arrange
        List<double> xValues = [
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        ];
        List<double> yValues = [
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        ];
        const string expected = "Error: You cannot input two lists with only Zeroes.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(xValues, yValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    //still need a test with a negative slope

    [Test]
    public void ComputeYFromLinearRegression_ThreeFloats_ReturnsYValue()
    {
        // Arrange
        const float xInput = 1.6f;
        const float slope = 2.4f;
        const float bCoefficient = 10.0f;
        const float expected = 13.84f;
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(xInput, slope, bCoefficient);
        
        // Assert
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }
    
}