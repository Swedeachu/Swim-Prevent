using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim_Prevent {

    // a lot of this is from https://www.geeksforgeeks.org/program-find-skewness-statistical-data/
    // and also translated some pocketmine php from https://github.com/ethaniccc/Mockingbird/blob/stable/src/ethaniccc/Mockingbird/utils/MathUtils.php
    class MathUtil {

        static float mean(int[] arr, int n) {
            double sum = 0;
            for (int i = 0; i < n; i++) {
                sum = sum + arr[i];
            }
            return (float)sum / n;
        }

        static float standardDeviation(int[] arr, int n) {
            double sum = 0;
            for (int i = 0; i < n; i++) {
                sum = (arr[i] - mean(arr, n)) * (arr[i] - mean(arr, n));
            }
            return (float)Math.Sqrt(sum / n);
        }

        public static float getSkewness(int[] arr) {
            double sum = 0;
            int n = arr.Length;
            for (int i = 0; i < n; i++) {
                sum = (arr[i] - mean(arr, n)) * (arr[i] - mean(arr, n)) * (arr[i] - mean(arr, n));
            }
            return (float)sum / (n * standardDeviation(arr, n) * standardDeviation(arr, n) * standardDeviation(arr, n) * standardDeviation(arr, n));
        }

        // I probably did the math wrong so just not going to use this one
        public static double getKurtosis(int[] arr) {
            int sum = arr.Sum();
            int length = arr.Length;
            double average = sum / length;
            double first = length * (length + 1) / ((length - 1) * (length - 2) * (length - 3));
            double second = 3 * Math.Pow(length - 1, 2) / ((length - 2) * (length - 3));
            double variance = 0.0;
            double varianceSquared = 0.0;
            foreach (int num in arr) {
                variance += Math.Pow(average - num, 2);
                varianceSquared += Math.Pow(average - num, 4);
            }
            return first * (varianceSquared / Math.Pow(variance / sum, 2)) - second;
        }

    }
}
