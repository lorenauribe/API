﻿// <Snippet1>
using System;

// This derived class converts the uniformly distributed random
// numbers generated by base.Sample( ) to another distribution.
public class RandomProportional : Random
{
    // The Sample method generates a distribution proportional to the value
    // of the random numbers, in the range [0.0, 1.0].
    protected override double Sample( )
    {
        return Math.Sqrt( base.Sample( ) );
    }

    public override int Next()
    {
       return (int) (Sample() * int.MaxValue);
    }
}

public class RandomSampleDemo
{
    static void Main( )
    {	
        const int rows = 4, cols = 6;
        const int runCount = 1000000;
        const int distGroupCount = 10;
        const double intGroupSize =
            ( (double)int.MaxValue + 1.0 ) / (double)distGroupCount;

        RandomProportional randObj = new RandomProportional( );

        int[ ]      intCounts = new int[ distGroupCount ];
        int[ ]      realCounts = new int[ distGroupCount ];

        Console.WriteLine(
            "\nThe derived RandomProportional class overrides " +
            "the Sample method to \ngenerate random numbers " +
            "in the range [0.0, 1.0]. The distribution \nof " +
            "the numbers is proportional to their numeric values. " +
            "For example, \nnumbers are generated in the " +
            "vicinity of 0.75 with three times the \n" +
            "probability of those generated near 0.25." );
        Console.WriteLine(
            "\nRandom doubles generated with the NextDouble( ) " +
            "method:\n" );

        // Generate and display [rows * cols] random doubles.
        for( int i = 0; i < rows; i++ )
        {
            for( int j = 0; j < cols; j++ )
                Console.Write( "{0,12:F8}", randObj.NextDouble( ) );
            Console.WriteLine( );
        }

        Console.WriteLine(
            "\nRandom integers generated with the Next( ) " +
            "method:\n" );

        // Generate and display [rows * cols] random integers.
        for( int i = 0; i < rows; i++ )
        {
            for( int j = 0; j < cols; j++ )
                Console.Write( "{0,12}", randObj.Next( ) );
            Console.WriteLine( );
        }

        Console.WriteLine(
            "\nTo demonstrate the proportional distribution, " +
            "{0:N0} random \nintegers and doubles are grouped " +
            "into {1} equal value ranges. This \n" +
            "is the count of values in each range:\n",
            runCount, distGroupCount );
        Console.WriteLine(
            "{0,21}{1,10}{2,20}{3,10}", "Integer Range",
            "Count", "Double Range", "Count" );
        Console.WriteLine(
            "{0,21}{1,10}{2,20}{3,10}", "-------------",
            "-----", "------------", "-----" );

        // Generate random integers and doubles, and then count
        // them by group.
        for( int i = 0; i < runCount; i++ )
        {
            intCounts[ (int)( (double)randObj.Next( ) /
                intGroupSize ) ]++;
            realCounts[ (int)( randObj.NextDouble( ) *
                (double)distGroupCount ) ]++;
        }

        // Display the count of each group.
        for( int i = 0; i < distGroupCount; i++ )
            Console.WriteLine(
                "{0,10}-{1,10}{2,10:N0}{3,12:N5}-{4,7:N5}{5,10:N0}",
                (int)( (double)i * intGroupSize ),
                (int)( (double)( i + 1 ) * intGroupSize - 1.0 ),
                intCounts[ i ],
                ( (double)i ) / (double)distGroupCount,
                ( (double)( i + 1 ) ) / (double)distGroupCount,
                realCounts[ i ] );
    }
}

/*
This example of Random.Sample() displays the following output:

   The derived RandomProportional class overrides the Sample method to
   generate random numbers in the range [0.0, 1.0). The distribution
   of the numbers is proportional to the number values. For example,
   numbers are generated in the vicinity of 0.75 with three times the
   probability of those generated near 0.25.

   Random doubles generated with the NextDouble( ) method:

     0.59455719  0.17589882  0.83134398  0.35795862  0.91467727  0.54022658
     0.93716947  0.54817519  0.94685080  0.93705478  0.18582318  0.71272428
     0.77708682  0.95386216  0.70412393  0.86099417  0.08275804  0.79108316
     0.71019941  0.84205103  0.41685082  0.58186880  0.89492302  0.73067715

   Random integers generated with the Next( ) method:

     1570755704  1279192549  1747627711  1705700211  1372759203  1849655615
     2046235980  1210843924  1554274149  1307936697  1480207570  1057595022
      337854215   844109928  2028310798  1386669369  2073517658  1291729809
     1537248240  1454198019  1934863511  1640004334  2032620207   534654791

   To demonstrate the proportional distribution, 1,000,000 random
   integers and doubles are grouped into 10 equal value ranges. This
   is the count of values in each range:

           Integer Range     Count        Double Range     Count
           -------------     -----        ------------     -----
            0- 214748363    10,079     0.00000-0.10000    10,148
    214748364- 429496728    29,835     0.10000-0.20000    29,849
    429496729- 644245093    49,753     0.20000-0.30000    49,948
    644245094- 858993458    70,325     0.30000-0.40000    69,656
    858993459-1073741823    89,906     0.40000-0.50000    90,337
   1073741824-1288490187   109,868     0.50000-0.60000   110,225
   1288490188-1503238552   130,388     0.60000-0.70000   129,986
   1503238553-1717986917   149,231     0.70000-0.80000   150,428
   1717986918-1932735282   170,234     0.80000-0.90000   169,610
   1932735283-2147483647   190,381     0.90000-1.00000   189,813
*/
// </Snippet1>
