using jaxCalculatorProjectSWEFall2024;

namespace CalculatorLogicUnitTests;

public class CalculatorLogicUnitTests
{
    // Calculation Result Tests for Coverage (make sure it works)
    [Test]
    public void CalculationResult_GetBoolean_ReturnsBoolean()
    {
        // Arrange
        var calcResult = new CalculationResult();
        const bool expected = true;
        
        // Act
        var result = calcResult.GetWorking();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void CalculationResult_GetString_ReturnsString()
    {
        // Arrange
        var calcResult = new CalculationResult();
        const string expected = "";
        
        // Act
        var result = calcResult.GetMethodType();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    // Descriptive Statistics Logic Tests
    // Compute Mean 
    [Test]
    public void ComputeMean_ListOfFloatingPointValues_ReturnsCorrectMean()
    {
        // Arrange (declare variables needed for testing)
        List<string> values = new List<string>();
        values.Add("9");
        values.Add("6");
        values.Add("8");
        values.Add("5");
        values.Add("7");
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
        List<string> values = new List<string>();
        values.Add("10");
        values.Add("-10");
        values.Add("45");
        values.Add("0");
        values.Add("-45");
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
        List<string> values = new List<string>();
        const string expected = "Error: Input is empty.";
        
        // Act
        var result = DescriptiveStatistics.ComputeMean(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeMean_NonNumberInList_ReturnsSyntaxError()
    {
        // Arrange
        List<string> values = new List<string>();
        values.Add("baboon");
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = DescriptiveStatistics.ComputeMean(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    // Compute Standard Deviation
    [Test]
    public void ComputeStandardDeviation_ListOfFloatingPointValuesFloatAndBoolean_ReturnsSampleStandardDeviation()
    {
        // Arrange
        const string mean = "7.0";
        const bool isPopulation = false;
        List<string> values = new List<string>();
        values.Add("9");
        values.Add("6");
        values.Add("8");
        values.Add("5");
        values.Add("7");
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
        const string mean = "7.0";
        const bool isPopulation = true;
        List<string> values = new List<string>();
        values.Add("9");
        values.Add("6");
        values.Add("8");
        values.Add("5");
        values.Add("7");
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
        List<string> values = new List<string>();
        values.Add("9");
        const string mean = "0";
        const bool isPopulation = true;
        const string expected = "Error: Input Population is Too Small/Empty.";
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeStandardDeviation_NonNumberInList_ReturnsSyntaxError()
    {
        // Arrange
        List<string> values = new List<string>();
        values.Add("kangaroo");
        const string mean = "0";
        const bool isPopulation = true;
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeStandardDeviation_NonNumberInMean_ReturnsSyntaxError()
    {
        // Arrange
        List<string> values = new List<string>();
        values.Add("2");
        values.Add("22");
        values.Add("222");
        values.Add("2222");
        const string mean = "bird";
        const bool isPopulation = true;
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeStandardDeviation_EmptyPopulationList_ReturnsError()
    {
        // Arrange
        List<string> values = new List<string>();
        const string mean = "0";
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
        List<string> values = new List<string>();
        const string mean = "0";
        const bool isPopulation = false;
        const string expected = "Error: Input is Empty.";
        
        // Act
        var result = DescriptiveStatistics.ComputeStandardDeviation(values, mean, isPopulation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    // Compute Z Score
    [Test]
    public void ComputeZScore_ThreeFloatingPointValues_ReturnsZScore()
    {
        // Arrange
        const string inputValue = "3.0";
        const string mean = "7.0";
        const string standardDeviation = "2.0";
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
        const string inputValue = "3.0";
        const string mean = "7.0";
        const string standardDeviation = "0.0";
        const string expected = "Error: Cannot Divide by Zero.";
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(inputValue, mean, standardDeviation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeZScore_NonNumberInputToSolve_ReturnsDivideByZeroError()
    {
        // Arrange
        const string inputValue = "cat";
        const string mean = "7.0";
        const string standardDeviation = "2.0";
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(inputValue, mean, standardDeviation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeZScore_NonNumberMean_ReturnsDivideByZeroError()
    {
        // Arrange
        const string inputValue = "3.0";
        const string mean = "dog";
        const string standardDeviation = "2.0";
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(inputValue, mean, standardDeviation);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeZScore_NonNumberStDev_ReturnsDivideByZeroError()
    {
        // Arrange
        const string inputValue = "3.0";
        const string mean = "7.0";
        const string standardDeviation = "mouse";
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
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
    public void ComputeSingleLinearRegression_TwoListsOfFloatsOfDifferentLengths_ReturnsError()
    {
        // Arrange
        List<double> xValues = [
            1,
            1,
            1,
            2,
            1,
            1.0,
            1,
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
        const string expected = "Error: The number of xValues and yValues do not match.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(xValues, yValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_TwoListsOfFloatingPointValues_ReturnsSingleLinearRegressionFormulaWithNegativeSlope()
    {
        // Arrange
        List<double> xValues =
        [
            9,
            6,
            4,
            1.5,
            0.25
        ];
        List<double> yValues =
        [
            50,
            55,
            60.5,
            70,
            85.5
        ];
        //we round to roughly 2 decimal places here, looks nicer (and prevents everything from setting ablaze)
        const string expected = "-3.735x + 79.70";
        
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

    [Test]
    public void ComputeYFromLinearRegression_ThreeFloats_ReturnsYValue()
    {
        // Arrange
        const string xInput = "1.6";
        const string slope = "2.4";
        const string bCoefficient = "10.0";
        const float expected = 13.84f;
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(xInput, slope, bCoefficient);
        
        // Assert
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeYFromLinearRegression_NonNumberXInput_ReturnsSyntaxError()
    {
        // Arrange
        const string xInput = "owl";
        const string slope = "2.4";
        const string bCoefficient = "10.0";
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(xInput, slope, bCoefficient);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeYFromLinearRegression_NonNumberSlopeInput_ReturnsSyntaxError()
    {
        // Arrange
        const string xInput = "1.6";
        const string slope = "ostrich";
        const string bCoefficient = "10.0";
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(xInput, slope, bCoefficient);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeYFromLinearRegression_NonNumberBInput_ReturnsSyntaxError()
    {
        // Arrange
        const string xInput = "1.6";
        const string slope = "2.4";
        const string bCoefficient = "rat";
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(xInput, slope, bCoefficient);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
}