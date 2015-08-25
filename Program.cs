using System;
using System.Collections.Generic;
using System.Text;


namespace Soundex
{
	class Program
	{

		private static string Soundex(string word)
		{
			const string soundex = "0123012#02245501262301#202";
			string sdx = "";
			char last = '?';
			word = word.ToUpper();

			foreach (char c in word) {
				if ((c >= 'A') && (c <= 'Z') && (sdx.Length < 4)) {
					char s = soundex[c - 'A'];
					if (sdx.Length == 0)
						sdx += c;
					else if (s == '#') continue;
					else if (s != '0' && s != last) sdx += s;
					last = s;
				}
			}

			return sdx.PadRight(4, '0');
		}


		static void Main(string[] args)
		{
			string[] testWords = {
				"Ashcraft", "A261",
				"Burroughs", "B620",
				"Burrows", "B620",
				"Ekzampul", "E251",
				"Ellery", "E460",
				"Euler", "E460",
				"Example", "E251",
				"Gauss", "G200",
				"Ghosh", "G200",
				"Gutierrez", "G362",
				"Heilbronn", "H416",
				"Hilbert", "H416",
				"Jackson", "J250",
				"Kant", "K530",
				"Knuth", "K530",
				"Ladd", "L300",
				"Lee", "L000",
				"Lissajous", "L222",
				"Lloyd", "L300",
				"Lukasiewicz", "L222",
				"O'Hara", "O600",
				"Pfister", "P236",
				"Soundex", "S532",
				"Sownteks", "S532",
				"Tymczak", "T522",
				"VanDeusen", "V532",
				"Washington", "W252",
				"Wheaton", "W350"
			};

			for (int i = 0; i < testWords.Length; i += 2) {
				if (Soundex(testWords[i]) == testWords[i + 1]) {
					Console.WriteLine(testWords[i] + " " + testWords[i + 1]);
				}
				else {
					Console.WriteLine("* " + testWords[i] + "GOOD: " + testWords[i + 1] + " BAD:" + Soundex(testWords[i]) );
				}
			}

			Console.WriteLine();			
		}
	}
}
