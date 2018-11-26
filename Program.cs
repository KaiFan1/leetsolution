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
            int[] s = new int[] { 2, 7, 11, 15 };
            int[] r = TwoSum(s, 9);
            foreach(var x in r)
            {
                Console.WriteLine(x.ToString());
            }
            Console.ReadLine();
            //1. Two Sum
            /* solution 1 */
            int[] TwoSum(int[] x,int target)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    for (int j = 1; i < x.Length; j++)
                    {
                        if(x[i] + x[j] == target)
                        {
                            return new int[2] { i, j };
                        }
                    }
                }
                return null;
            }
            /* solution 2 */
            
            int[] twoSum(int[] nums,int target)
            {
                Dictionary<int, int> d = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    d.Add(nums[i],i);
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (d.ContainsKey(complement) && d[complement] != i)
                    {
                        return new int[] { i, d[complement] };
                    }
                }
                return null;
            }

        }
    }
}
