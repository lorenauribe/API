// <snippet7>
using System;

public class IsLowerSample {
	public static void Main() {
		char ch = 'a';

		Console.WriteLine(char.IsLower(ch));				// Output: "True"
		Console.WriteLine(char.IsLower("upperCase", 5));	// Output: "False"
	}
}
// </snippet7>
