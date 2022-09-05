Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}."); 
Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}."); 
Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");

// output
/*
int uses 4 bytes and can store numbers in the range -2,147,483,648 to 2,147,483,647.

double uses 8 bytes and can store numbers in the range -179,769,313,486,231,570,814,527,423,731,704,356,798,070,567,525,844,996,598,917,476,803,157,260,780,028,538,760,589,558,632,766,878,171,540,458,953,514,382,464,234,321,326,889,464,182,768,467,546,703,537,516,986,049,910,576,551,282,076,245,490,090,389,328,944,075,868,508,455,133,942,304,583,236,903,222,948,165,808,559,332,123,348,274,797,826,204,144,723,168,738,177,180,919,299,881,250,404,026,184,124,858,368 to 179,769,313,486,231,570,814,527,423,731,704,356,798,070,567,525,844,996,598,917,476,803,157,260,780,028,538,760,589,558,632,766,878,171,540,458,953,514,382,464,234,321,326,889,464,182,768,467,546,703,537,516,986,049,910,576,551,282,076,245,490,090,389,328,944,075,868,508,455,133,942,304,583,236,903,222,948,165,808,559,332,123,348,274,797,826,204,144,723,168,738,177,180,919,299,881,250,404,026,184,124,858,368.

decimal uses 16 bytes and can store numbers in the range -79,228,162,514,264,337,593,543,950,335 to 79,228,162,514,264,337,593,543,950,335.
*/

// Then how the double store more numbers than decimal with using less amount of bytes????

Console.WriteLine("Using doubles:"); 
double a = 0.1;
double b = 0.2;

if (a + b == 0.3)
{
  Console.WriteLine($"{a} + {b} equals 0.3");
}
else
{
  Console.WriteLine($"{a} + {b} does NOT equal 0.3");
  System.Console.WriteLine($"{a} + {b} is equal to {a+b}");
}

//output 

/*
0.1 + 0.2 does NOT equal 0.3
0.1 + 0.2 is equal to 0.30000000000000004
*/

// The double type is not guaranteed to be accurate because some numbers like 0.1 literally can not be represented as floating point values.
// You should only use double when accuracy is not important. If you want to compare double values make sure that the equity of those numbers are not important.

Console.WriteLine("Using decimals:"); 
decimal c = 0.1M; // M suffix means a decimal literal value.
decimal d = 0.2M;

if (c + d == 0.3M)
{
  Console.WriteLine($"{c} + {d} equals 0.3");
}
else
{
  Console.WriteLine($"{c} + {d} does NOT equal 0.3");
  System.Console.WriteLine($"{c} + {d} is equal to {c+d}");
}

//Output: 
/*
0.1 + 0.2 equals 0.3
*/

// As we can see here decimal values are accurate.
// Use decimal for money, general engineering and whenever the accuracy of real number is important.
