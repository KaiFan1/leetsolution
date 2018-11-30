using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leecode
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 121;
            bool result = IsPaslindrome(x);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        //1. Two Sum
        /* solution 1 */
        static int[] TwoSum(int[] x, int target)
        {
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 1; i < x.Length; j++)
                {
                    if (x[i] + x[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return null;
        }
        /* solution 2 */
        static int[] twoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(target - nums[i], i);
                }
                else
                {
                    return new int[] { dict[nums[i]], i };
                }
                throw new ArgumentNullException("NO SUM SOLUTION");
            }
        }

        //2. Reverse Integer
        static int Reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;//find the last digit
                x /= 10; //remove the last digit from origin number
                         //incase rev num is overflow(2147483647 to -214748347)
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
                if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;//push the last digit to the first position in rev;
            }
            return rev;
        }

        //3. Palindrome Number
        static bool IsPaslindrome(int x)
        {
            //if x is nagtive number
            if (x < 0)
            {
                return false;
            }
            else
            {
                //reverse x in order to compare them
                int rev = 0;
                int origin = x;
                while (x != 0)
                {
                    int tem = x % 10;
                    x /= 10;
                    rev = rev * 10 + tem;
                }
                Console.WriteLine(rev);
                Console.WriteLine(x);

                if (rev.Equals(origin))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //4. Roman to integer
        static int RomanToInteger(string x)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);
            int result = 0;
            for (int i = 0; i < x.Length; i++)
            {
                //sepcial case
                if (x[i] == 'I')
                {
                    if (i <= x.Length - 1)
                    {
                        if (x[i + 1] != 'I')
                        {
                            result += dict[x[i + 1]] - 1;
                            i++;
                            continue;
                        }
                    }
                    result += 1;
                }
                else
                {
                    result += dict[x[i]];
                }
            }
            return result;
        }

        //5. Longest Common Prefix
        static string LongestCommonPrefix(string[] strs)
        {
            //if strs is null return ""
            if (strs.Length == 0) return "";
            //initialize the first common prefix
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while(strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (string.IsNullOrEmpty(prefix)) return "";
                }
            }
            return prefix;
        }
    }
}
