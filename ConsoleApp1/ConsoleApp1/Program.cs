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
            string s = "hello";
            Console.WriteLine(s.IndexOf(s));
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
            Dictionary<int, int> hash = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (!hash.ContainsKey(nums[i]))
                {
                    hash.Add(nums[i], i);
                }

                var needed = target - nums[i];

                if (hash.ContainsKey(needed) && hash[needed] != i)
                {
                    return new int[] { i, hash[needed] };
                }
            }

            return default(int[]);
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
            //if x is nagtive number or a number ended with 0
            if(x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }
            int rev = 0;
            while(x > rev)
            {   
                //rev will add one more number from the last digit of x
                rev = rev * 10 + x % 10;
                //x will remove one digit
                x /= 10;
            }
            //if x has odd number of digits. rev / 10 will remove the middle one,eg. 12321, rev / 10 will be 12
            return x == rev || x == rev / 10;
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

        //6. Valid Parentheses
        static bool IsValidParenthese(string s)
        {
            //Stack Represents a simple last-in-first-out (LIFO) non-generic collection of objects. 
            Stack<char> stack = new Stack<char>();
            if (s.Length % 2 != 0) return false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(')');
                }
                else if (s[i] == '[')
                {
                    stack.Push(']');
                }
                else if (s[i] == '{')
                {
                    stack.Push('}');
                }
                else
                {
                    if (stack.Count == 0 || s[i] != stack.Pop())
                    {
                        return false;
                    }
                }
            }
            return (stack.Count == 0);
        }

        //7. Merge Two Sorted Lists
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        static ListNode MergeTwoLists(ListNode l1,ListNode l2)
        {
            ListNode res;
            if (l1 == null && l2 == null)
            {
                return null;
            }
            else if (l1 == null)
            {
                res = l2;
            }
            else if (l2 == null)
            {
                res = l1;
            }
            else
            {
                res = (l1.val < l2.val ? l1 : l2);
            }

            res.next = MergeTwoLists((res == l1 ? l2 : l1), (res == l1 ? l1.next : l2.next));

            return res;
        }

        //8. Remove Duplicates from Sorted Array
        static int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int min = nums[0], duplicateNum = 0, len = nums.Length;
            for (int i = 1; i < nums.Length; i++)
            {
                if(nums[i] == min)
                {
                    duplicateNum++;
                }
                else
                {
                    min = nums[i];
                    nums[i - duplicateNum] = nums[i];
                }
            }
            return len - duplicateNum;
        }
    }
}
