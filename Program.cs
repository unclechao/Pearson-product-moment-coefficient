using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//假设医院监测随机选择的18个成年人年龄和身体脂肪数据，得到如下结果。计算皮尔逊积矩系数。
//---------------------------------------------------------------------------------------------------------------------------------------------
//年龄  23      23      27      27      39      41      47      49      50      52      54      54      56      57      58      58      60      61
//脂肪  9.5     26.5    7.8    17.8    31.4    25.9    27.4    27.2   31.2    34.6    42.5    28.8    33.4    30.2    34.1    32.9    41.2   35.7              
//---------------------------------------------------------------------------------------------------------------------------------------------
//
//zhangchao,2013-5-15
//5-19  添加Calculator函数


namespace 皮尔逊积矩系数
{
    class Program
    {
        /// <summary>
        /// 计算数组平均值
        /// </summary>
        /// <param name="input">要计算的数组</param>
        public static double AvgArray(double [] input)
        {
            double sum = 0.0f;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }
            return sum / input.Length;
        }

        /// <summary>
        /// 求两个数组对应元素乘积和
        /// </summary>
        public static double TwoArraySum(double[] arrayFirst, double[] arraySecond)
        {
            double sum = 0.0f;
            for (int i = 0; i < arrayFirst.Length; i++)
            {
                sum += arrayFirst[i] * arraySecond[i];
            }
            return sum;
        }

        /// <summary>
        /// 计算一个数组的标准差
        /// </summary>
        public static double Deviation(double[] input)
        {
            double average = AvgArray(input);
            double sum = 0.0f;
            double result = 0.0f;
            for (int i = 0; i < input.Length; i++)
            {
                sum += (input[i] - average) * (input[i] - average);
            }
            result = sum / input.Length;
            result = Math.Sqrt(result);
            return result;
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        public static void Init()
        {
            Console.WriteLine("假设医院监测随机选择的18个成年人年龄和身体脂肪数据，得到如下结果：");
            Console.WriteLine("计算皮尔逊积矩系数。");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("年龄  23      23      27      27      39      41      47      49      50");
            Console.WriteLine("脂肪  9.5     26.5    7.8     17.8    31.4    25.9    27.4    27.2   31.2");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("年龄  52      54      54      56      57      58      58      60      61");
            Console.WriteLine("脂肪  34.6    42.5    28.8    33.4    30.2    34.1    32.9    41.2   35.7");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------------");
        }

        /// <summary>
        /// 计算皮尔逊积矩系数
        /// </summary>
        /// <returns>计算结果</returns>
        public static double Calculator(double[] age,double[] fat)
        {
            double result = 0.0f;
            double twoArraySum = TwoArraySum(age, fat);
            double averageAge = AvgArray(age);
            double averageFat = AvgArray(fat);
            int n = age.Length;
            double deviationAge = Deviation(age);
            double deviationFat = Deviation(fat);
            return result = (twoArraySum - n * averageAge * averageFat) / (n * deviationAge * deviationFat);
        }

        static void Main(string[] args)
        {
            double[] age = { 23, 23, 27, 27, 39, 41, 47, 49, 50, 52, 54, 54, 56, 57, 58, 58, 60, 61 };
            double[] fat = { 9.5, 26.5, 7.8, 17.8, 31.4, 25.9, 27.4, 27.2, 31.2, 34.6, 42.5, 28.8, 33.4, 30.2, 34.1, 32.9, 41.2, 35.7 };
            Init();
            Console.WriteLine("计算得出的皮尔逊积矩系数为 " + Calculator(age, fat));
            Console.ReadKey();
        }
    }
}
