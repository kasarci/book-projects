using System.Text;
using BenchmarkDotNet.Attributes;

namespace _17_benchmark;

public class StringBenchmarks {
  int[] numbers;

  public StringBenchmarks()
  {
    numbers = Enumerable.Range(1,20).ToArray();
  }

  [Benchmark(Baseline = true)]
  public string StringConcatenationTest() {
    string s = String.Empty;
    for (int i = 0; i < numbers.Length; i++) {
      s += numbers[i] + ", ";
    }
    return s;
  }

  [Benchmark]
  public string StringBuilderTest() {
    StringBuilder builder = new ();
    
    for(int i = 0; i < numbers.Length; i++) {
      builder.Append(numbers[i]);
      builder.Append(", ");
    }

    return builder.ToString();
  }
}