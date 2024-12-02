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
        //preq-UNIT-TEST-4
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
        //preq-UNIT-TEST-4
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
        //preq-UNIT-TEST-4
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
        //preq-UNIT-TEST-4
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
        //preq-UNIT-TEST-2
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
        //preq-UNIT-TEST-3
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
        //preq-UNIT-TEST-2
        //preq-UNIT-TEST-3
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
        //preq-UNIT-TEST-2
        //preq-UNIT-TEST-3
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
        //preq-UNIT-TEST-2
        //preq-UNIT-TEST-3
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
        //preq-UNIT-TEST-3
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
        //preq-UNIT-TEST-2
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
        //preq-UNIT-TEST-5
        // Arrange
        List<string> values = new List<string>();
        values.Add("11.5, 7, 2");
        const double expected = 2.25;
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(values);
        
        // Assert
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeZScore_ZeroStandardDeviation_ReturnsDivideByZeroError()
    {
        //preq-UNIT-TEST-5
        // Arrange
        List<string> values = new List<string>();
        values.Add("11.5, 7, 0");
        const string expected = "Error: Cannot Divide by Zero.";
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeZScore_NonNumberInputToSolve_ReturnsSyntaxError()
    {
        //preq-UNIT-TEST-5
        // Arrange
        List<string> values = new List<string>();
        values.Add("cat, 7, 2");
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeZScore_NonNumberMean_ReturnsSyntaxError()
    {
        //preq-UNIT-TEST-5
        // Arrange
        List<string> values = new List<string>();
        values.Add("11.5, dog, 2");
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeZScore_NonNumberStDev_ReturnsSyntaxError()
    {
        //preq-UNIT-TEST-5
        // Arrange
        List<string> values = new List<string>();
        values.Add("11.5, 7, mouse");
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = DescriptiveStatistics.ComputeZScore(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    // Linear Regression Logic Tests
    // Compute SLR Formula
    [Test]
    public void ComputeSingleLinearRegression_TwoListsOfFloatingPointValues_ReturnsSingleLinearRegressionFormula()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "1.47, 52.21",
            "1.5, 53.12",
            "1.52, 54.48",
            "1.55, 55.84",
            "1.57, 57.2",
            "1.6, 58.57",
            "1.63, 59.93",
            "1.65, 61.29",
            "1.68, 63.11",
            "1.7, 64.47",
            "1.73, 66.28",
            "1.75, 68.1",
            "1.78, 69.92",
            "1.8, 72.19",
            "1.83, 74.46"
        ];
        //we round to 2 decimal places here, looks nicer (and prevents everything from setting ablaze)
        const string expected = "61.27x + -39.06";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetEquationResult(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_TwoListsOfFloatsOfDifferentLengthsXSide_ReturnsError()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "1.47, 52.21",
            "1.5, 53.12",
            " , 54.48",
            "1.55, 55.84",
            "1.57, 57.2",
            "1.6, 58.57",
            "1.63, 59.93",
            " , 61.29",
            "1.68, 63.11",
            "1.7, 64.47",
            "1.73, 66.23",
            "1.75, 68.1",
            "  , 69.92",
            "1.8, 72.19",
            "1.83, 74.46"
        ];
        const string expected = "Error: The number of xValues and yValues do not match.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_TwoListsOfFloatsOfDifferentLengthsYSide_ReturnsError()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "1.47, 52.21",
            "1.5, 53.12",
            "1.52, 54.48",
            "1.55, 55.84",
            "1.57, 57.2",
            "1.6, 58.57",
            "1.63,   ",
            "1.65, 61.29",
            "1.68, 63.11",
            "1.7,    ",
            "1.73, 66.23",
            "1.75, 68.1",
            "1.78, 69.92",
            "1.8,    ",
            "1.83, 74.46"
        ];
        const string expected = "Error: The number of xValues and yValues do not match.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_TwoListsOfFloatingPointValues_ReturnsSingleLinearRegressionFormulaWithNegativeSlope()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "9, 50",
            "6, 55",
            "4, 60.5",
            "1.5, 70",
            "0.25, 85.5"
        ];
        //we round to roughly 2 decimal places here, looks nicer (and prevents everything from setting ablaze)
        const string expected = "-3.735x + 79.70";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetEquationResult(), Is.EqualTo(expected));
    }


    [Test]
    public void ComputeSingleLinearRegression_AtLeastOneListEmpty_ReturnsError()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> values = new List<string>();
        const string expected = "Error: You cannot input an Empty List.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeSingleLinearRegression_XListOfDuplicates_ReturnsError()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "1, 50",
            "1.0, 55",
            "1, 60.5",
            "1, 70",
            "1.0, 85.5"
        ];
        const string expected = "Error: You cannot input a list with only duplicate values.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_YListOfDuplicates_ReturnsError()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "9, 50",
            "6, 50",
            "4, 50",
            "1.5, 50",
            "0.25, 50"
        ];
        const string expected = "Error: You cannot input a list with only duplicate values.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_NonNumberInXList_ReturnsSyntaxError()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "fox, 49",
            "6, 50",
            "4, 52",
            "1.5, 53",
            "0.25, 56"
        ];
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_NonNumberInYList_ReturnsSyntaxError()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "9, 49",
            "6, 50",
            "4, worm",
            "1.5, 53",
            "0.25, 56"
        ];
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeSingleLinearRegression_TwoListOfZeroes_ReturnsError()
    {
        //preq-UNIT-TEST-6
        // Arrange
        List<string> inputValues =
        [
            "0, 0",
            "0, 0",
            "0, 0",
            "0, 0",
            "0, 0"
        ];
        const string expected = "Error: You cannot input two lists with only Zeroes.";
        
        // Act
        var result = LinearRegression.ComputeSingularLinearRegression(inputValues);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }

    // Compute Y
    [Test]
    public void ComputeYFromLinearRegression_ThreeFloats_ReturnsYValue()
    {
        //preq-UNIT-TEST-7
        // Arrange
        List<string> values = new List<string>();
        values.Add("1.6, 2.4, 10.0");
        const float expected = 13.84f;
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(values);
        
        // Assert
        Assert.That(result.GetResult(), Is.EqualTo(expected));
    }

    [Test]
    public void ComputeYFromLinearRegression_NonNumberXInput_ReturnsSyntaxError()
    {
        //preq-UNIT-TEST-7
        // Arrange
        List<string> values = new List<string>();
        values.Add("owl, 2.4, 10.0");
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeYFromLinearRegression_NonNumberSlopeInput_ReturnsSyntaxError()
    {
        //preq-UNIT-TEST-7
        // Arrange
        List<string> values = new List<string>();
        values.Add("1.6, ostrich, 10.0");
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ComputeYFromLinearRegression_NonNumberBInput_ReturnsSyntaxError()
    {
        //preq-UNIT-TEST-7
        // Arrange
        List<string> values = new List<string>();
        values.Add("1.6, 2.4, rat");
        const string expected = "Error: Cannot input non numbers into the calculation.";
        
        // Act
        var result = LinearRegression.ComputeYFromLinearRegression(values);
        
        // Assert
        Assert.That(result.GetErrorMessage(), Is.EqualTo(expected));
    }
}