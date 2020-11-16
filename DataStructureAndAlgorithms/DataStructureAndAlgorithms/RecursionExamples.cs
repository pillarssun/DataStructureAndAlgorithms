using System;
using System.Collections.Generic;

namespace DataStructureAndAlgorithms
{
    public class RecursionExamples
    {
        private Dictionary<int, int> hasSolvedList;

        public RecursionExamples()
        {
            hasSolvedList = new Dictionary<int, int>();
        }

        /*
        To calculate how many possibilities of climbing some stairs, e.g. 2 stairs one move, or 1 stair one move.        
        f(1) = 1;
        f(2) = 2;
        f(n) = f(n-1) + f(n-2) This means the sum of last 2 types of moves
        */

        public int climbingPlan(int n)
        {
            if (n <= 0)
            {
                return 0;
            } else if (n == 1)
            {
                return 1;
            } else if (n == 2)
            {
                return 2;
            } else
            {
                if (hasSolvedList.ContainsKey(n))
                {
                    return hasSolvedList[n];
                }
                int value = climbingPlan(n - 1) + climbingPlan(n - 2);
                hasSolvedList[n] = value;
                return value;

                //The following has problem of repeating calculation 
                //return f1(n - 1) + f1(n - 2);  
            }
        }

        //non-recursion function
        public int climbingPlanNonRecur(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 2;
            }
            else
            {
                int res = 0;
                int pre = 2;
                int prepre = 1;
                for (int i = 3; i <= n; i++)
                {
                    res = pre + prepre;
                    prepre = pre;
                    pre = res;
                }
                return res;
            }
        }
    }
}
