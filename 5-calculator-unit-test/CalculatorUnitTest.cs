using _5_calculator;
using Xunit;

namespace _5_calculator_unit_test;

public class UnitTest1 {
  [Fact]
  public void TestAdding2And2() {
    //arrange
    double a = 2;
    double b = 2;
    double expected = 4;
    Calculator calculator = new ();

    //act
    double act = calculator.Add(a,b);

    //assert
    Assert.Equal(expected, act);
  }

  [Fact]
  public void TestAdding3And4() {
    // arrange
    double a = 3;
    double b = 4;
    double expected = 7;
    Calculator calculator = new ();
    
    // act
    double act = calculator.Add(a,b);
  
    // assert
    Assert.Equal(expected, act);
  } 
}