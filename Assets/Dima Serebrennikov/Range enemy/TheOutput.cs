// TheOutput.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Range enemy\TheOutput.csTheOutput.cs
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;
namespace Serebrennikov {
    public static class TheOutput {
        public static string RoundToThreeSignificantDigits(float value) {
            string text = value.ToString(CultureInfo.InvariantCulture);
            StringBuilder result = new(4);
            int digitCount = 0;
            foreach (char symbol in text) {
                if (symbol >= '0' && symbol <= '9') {
                    result.Append(symbol);
                    digitCount++;
                    if (digitCount == 3) {
                        break;
                    }
                    continue;
                }
                if (symbol == '.' && digitCount > 0) {
                    result.Append(symbol);
                }
            }
            return result.ToString();
        }
    }
}
