using System.Text.Json;

var sol = new Solution();
Console.WriteLine(sol.IsAnagram("racecar", "caerace"));

public class Solution
{
  /* 
  My original solution.
  This is a decent solution but could have been better if I had initially checked if the strings are the same length so I didn't have to duplicate the for loops for each of the strings.
  I also could have made better use of built-in dict methods and LINQ methods.
  the better example is below
  */
    public bool IsAnagram(string s, string t)
    {
        var sDict = new Dictionary<char, int>();
        var tDict = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (sDict.ContainsKey(s[i]))
            {
                sDict[s[i]]++;
            }
            else
            {
                sDict.Add(s[i], 1);
            }

        }

        for (int i = 0; i < t.Length; i++)
        {
            if (tDict.ContainsKey(t[i]))
            {
                tDict[t[i]]++;
            }
            else
            {
                tDict.Add(t[i], 1);
            }

        }

        var sSortedKeys = sDict.Keys.ToArray();
        Array.Sort(sSortedKeys);
        var tSortedKeys = tDict.Keys.ToArray();
        Array.Sort(tSortedKeys);



        if (!sSortedKeys.SequenceEqual(tSortedKeys)) return false;

        foreach (var key in sDict.Keys)
        {
            if (sDict[key] != tDict[key]) return false;
        }

        return true;
    }

  /* This works similarly to the first solution, but with way less lines of code. */
  public bool IsAnagram_BETTER(string s, string t)
    {
        if (s.Length != t.Length) return false; // Fail quickly if the arrays are different lengths. this also allows us to use a single for-loop when building our character dictionaries.

        var sDict = new Dictionary<char, int>();
        var tDict = new Dictionary<char, int>();
        
        for (int i = 0; i < s.Length; i++)
        {
            sDict[s[i]] = sDict.GetValueOrDefault(s[i], 0) + 1; // If we have not seen this character in the string yet, add it as a key to the dict and set the value to 1. Otherwise, get the current value and add 1.
            tDict[t[i]] = tDict.GetValueOrDefault(t[i], 0) + 1;
        }

        // return false quickly if the strings consist of different characters.
        // If they have the same number of characters, check to see if there are any difference in the kay/value pairs that make up the dictionaries
        //   If there are differences in the key value pairs, return false
        //   otherwise, return true.
        return sDict.Count == tDict.Count && !sDict.Except(tDict).Any(); 
    }

  /*
  This was another solution for NeetCode.
  Not sure I would have thought of this one.
  Create an int array with a length of 26 (the number of characters in the alphabet) and every value = 0.
  Then, for each character you encounter as you iterate the strings:
    For the first string, INCREMENT the index in the array that corresponds with the character.
    For the second string, DECREMENT the index in the array that corresponds with the character.
    
  After following this, if the string are anagrams, every value in the array will equal 0, because all the characters from the strings cancelled each other out.
  */
  public bool IsAnagram_HashTableWithArray(string s, string t)
  {
        if (s.Length != t.Length) {
            return false;
        }

        int[] count = new int[26];
        for (int i = 0; i < s.Length; i++) {
            /*
            Note that `- 'a'` is important because characters in c# are really integers.
            'a' = 97.
            So subtracting each character we encounter by 'a'. gives us the numerical value that corresponds with the index of our array.
            'a' - 'a' = 0
            'z' - 'a' = 25
            */
            count[s[i] - 'a']++; 
            count[t[i] - 'a']--;
        }

        foreach (int val in count) {
            if (val != 0) {
                return false;
            }
        }
        return true;
  }
}
