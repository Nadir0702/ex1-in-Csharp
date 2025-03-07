﻿using System;

namespace Ex1_01 // change 4 to 9 , check how to print
{
    public class Program
    {
        private static void Main()
        {
            string firstNumberStr;
            string secondNumberStr;
            string thirdNumberStr;
            int firstDecimal;
            int secondDecimal;
            int thirdDecimal;
            int minNumberDecimal;
            int maxNumberDecimal;

            getInputFromUser(out firstNumberStr,out secondNumberStr,out thirdNumberStr);
            binaryToDecimal(out firstDecimal,firstNumberStr);
            binaryToDecimal(out secondDecimal, secondNumberStr);
            binaryToDecimal(out thirdDecimal, thirdNumberStr);
            getMax(firstDecimal, secondDecimal, thirdDecimal, out maxNumberDecimal);
            getMin(firstDecimal, secondDecimal, thirdDecimal, out minNumberDecimal);
            printDecimalAscendingOrder(firstDecimal, secondDecimal, thirdDecimal, minNumberDecimal, maxNumberDecimal);
            handleStatics(firstNumberStr, secondNumberStr, thirdNumberStr, 
                firstDecimal, secondDecimal, thirdDecimal, 
                minNumberDecimal, maxNumberDecimal);
        }

        private static void printStatics(float i_avgNumberOfOnes, float i_avgNumberOfZeroes, int i_numPowersOfTwo, int i_NumOfAscendigsNumbersint,
            int i_Min, int i_Max)
        {
            string statisticsStr;
            statisticsStr = string.Format(@"The avg number of 0 is: {0}
The avg number of 1 is: {1}
The number of powers of two is:{2}
The number of ascendingsDigits is:{3}
The max number is: {4}
The min number is: {5}",
i_avgNumberOfZeroes, i_avgNumberOfOnes, i_numPowersOfTwo, i_NumOfAscendigsNumbersint, i_Max, i_Min);
            System.Console.WriteLine(statisticsStr);
        }

        private static void handleStatics(string i_FirstStr, string i_SecondStr, string i_ThirdStr, 
            int i_FirstNum, int i_SecondNum, int i_ThirdNum,
            int i_MinNuMber, int i_MaxNumber)
        {
            float avgNumberOfOnes;
            float avgNumberOfZeroes;
            int numPowersOfTwo;
            int numOfAscendigsNumbers;

            getAvgNumberOfChar(i_FirstStr, i_SecondStr, i_ThirdStr, '0', out avgNumberOfZeroes);
            getAvgNumberOfChar(i_FirstStr, i_SecondStr, i_ThirdStr, '1', out avgNumberOfOnes);
            getNumOfPowsOfTwo(i_FirstStr, i_SecondStr, i_ThirdStr, out numPowersOfTwo);
            getNumOfAscendingsDigitNumber(i_FirstNum, i_SecondNum, i_ThirdNum,out numOfAscendigsNumbers);
            printStatics(avgNumberOfOnes, avgNumberOfZeroes, numPowersOfTwo, numOfAscendigsNumbers, i_MinNuMber, i_MaxNumber);
        }
        private static void getMax(int i_FirstNum, int i_SecondNum, int i_ThirdNum,out int i_Max)
        {
            i_Max = System.Math.Max(i_ThirdNum, System.Math.Max(i_FirstNum, i_SecondNum));
        }

        private static void getMin(int i_FirstNum, int i_SecondNum, int i_ThirdNum, out int i_Min)
        {
            i_Min = System.Math.Min(i_ThirdNum, System.Math.Min(i_FirstNum, i_SecondNum));
        }
        private static void getNumOfAscendingsDigitNumber(int i_FirstNum, int i_SecondNum, int i_ThirdNum, out int o_NumPowersOfTwo)
        {
            int numPowersOfTwo = 0;

            if (isAcendingDigits(i_FirstNum))
            {
                numPowersOfTwo++;
            }

            if (isAcendingDigits(i_SecondNum))
            {
                numPowersOfTwo++;
            }

            if (isAcendingDigits(i_ThirdNum))
            {
                numPowersOfTwo++;
            }
            o_NumPowersOfTwo = numPowersOfTwo;
        }
        private static bool isAcendingDigits(int i_Number)
        {
            bool acendingDigits = true;
            int currentOnesDigit = i_Number % 10;
            int nextOnesDigit;

            if(i_Number > 10)
            {
                acendingDigits = false;
            }

            while (acendingDigits && i_Number > 0)
            {
                i_Number /= 10;
                nextOnesDigit = i_Number % 10;
                if(nextOnesDigit >= currentOnesDigit)
                {
                    acendingDigits = false;
                }

                currentOnesDigit = nextOnesDigit;
            }

            return acendingDigits;
        }

        private static void getNumOfPowsOfTwo(string i_FirstStr, string i_SecondStr, string i_ThirdStr, out int o_NumPowersOfTwo)
        {
            int numPowersOfTwo = 0;

            if(isPowOfTwo(i_FirstStr))
            {
                numPowersOfTwo++;
            }

            if (isPowOfTwo(i_SecondStr))
            {
                numPowersOfTwo++;
            }

            if (isPowOfTwo(i_ThirdStr))
            {
                numPowersOfTwo++;
            }

            o_NumPowersOfTwo = numPowersOfTwo;
        }
        private static bool isPowOfTwo(string i_StrToCheck)
        {
            int numOfOnes = 0;
            int digits = 0;
            bool powOfTwo = true;

            if(i_StrToCheck == "000000000")
            {
                powOfTwo = false;
            }

            while(powOfTwo && digits < 9)
            {
                if (i_StrToCheck[digits]  == '1')
                {
                    numOfOnes++;
                }

                if(numOfOnes > 1)
                {
                    powOfTwo = false;
                }

                digits++;
            }
            
            return powOfTwo;
        }
        private static void getAvgNumberOfChar(string i_FirstStr, string i_SecondStr, string i_ThirdStr, char i_Char, out float o_avgNumberOfOccurrences)
        {
            float numOfCharOccurrences = 0;

            for (int i = 0; i < 9; i++)
            {
                if (i_FirstStr[i] == i_Char)
                {
                    numOfCharOccurrences++;
                }

                if (i_SecondStr[i] == i_Char)
                {
                    numOfCharOccurrences++;
                }

                if (i_ThirdStr[i] == i_Char)
                {
                    numOfCharOccurrences++;
                }
            }

            o_avgNumberOfOccurrences = numOfCharOccurrences/3;
        }
        private static void printDecimalAscendingOrder (int i_firstNum, int i_SecondNum, int i_ThirdNum,int i_maxNumber, int i_minNumber)
        {
            int middleNumber;
            string resultStr;

            if(i_firstNum != i_maxNumber && i_firstNum != i_minNumber)
            {
                middleNumber = i_firstNum;
            }
            else if(i_SecondNum != i_maxNumber && i_SecondNum != i_minNumber)
            {
                middleNumber = i_SecondNum;
            }
            else
            {
                middleNumber = i_ThirdNum;
            }

          resultStr = string.Format("The Decimals numbers are: {0}, {1}, {2}",i_minNumber,middleNumber,i_maxNumber);

          System.Console.WriteLine(resultStr);
        }
        private static void binaryToDecimal(out int o_DecimalNumber, string i_binaryStr)
        {
            int decimalNumber = 0;
            int binaryNumber = int.Parse(i_binaryStr);
            int binaryDigit = 0;
            int currentBinaryMsb;

            while (binaryNumber > 0)
            {
                currentBinaryMsb = binaryNumber % 10;
                currentBinaryMsb *= (int)System.Math.Pow(2, binaryDigit);
                decimalNumber += currentBinaryMsb;
                binaryDigit++;
                binaryNumber /= 10;
            }

            o_DecimalNumber = decimalNumber;
        }
        private static void getInputFromUser(out string o_FirstNumberStr,
            out string o_SecondNumberStr,
            out string o_ThirdNumberStr)
        {
            System.Console.WriteLine("Please enter 3 binary numbers with 9 digits each:");
            o_FirstNumberStr = System.Console.ReadLine();
            checkIfInputValid(ref o_FirstNumberStr);
            o_SecondNumberStr = System.Console.ReadLine();
            checkIfInputValid(ref o_SecondNumberStr);
            o_ThirdNumberStr = System.Console.ReadLine();
            checkIfInputValid(ref o_ThirdNumberStr);
        }

        private static void checkIfInputValid(ref string io_StrToCheck)// change 4 to 9
        {
            while(io_StrToCheck.Length != 9 ||
                  !isBinaryNumber(io_StrToCheck))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                io_StrToCheck = System.Console.ReadLine();
            }
        }

        private static bool isBinaryNumber(string i_StrToCheck)
        {
            bool binaryValid = true;
            int currCharIndexInStr = 0;

            while(currCharIndexInStr < 9 && binaryValid)
            {
                if (i_StrToCheck[currCharIndexInStr] != '1' &&
                    i_StrToCheck[currCharIndexInStr] != '0')
                {
                    binaryValid = false;
                }

                currCharIndexInStr++;
            }

            return binaryValid;
        }
    }
}
