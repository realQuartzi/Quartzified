using System;
using System.Collections.Generic;

namespace Quartzified.Mathematics.Finance
{
    public class Finance
    {
        public static int GetAssets(int liability, int ownersEquity)
        {
            return liability + ownersEquity;
        }
        public static float GetAssets(float liability, float ownersEquity)
        {
            return liability + ownersEquity;
        }
        public static double GetAssets(double liability, double ownersEquity)
        {
            return liability + ownersEquity;
        }
        public static decimal GetAssets(decimal liability, decimal ownersEquity)
        {
            return liability + ownersEquity;
        }

        public static int GetNetIncome(int revenues, int expenses)
        {
            return revenues - expenses;
        }
        public static float GetNetIncome(float revenues, float expenses)
        {
            return revenues - expenses;
        }
        public static double GetNetIncome(double revenues, double expenses)
        {
            return revenues - expenses;
        }
        public static decimal GetNetIncome(decimal revenues, decimal expenses)
        {
            return revenues - expenses;
        }

        public static int GetBreakEvenPoint(int fixedCosts, int salesPrice, int variableCostPU)
        {
            return (fixedCosts / salesPrice) - variableCostPU;
        }
        public static float GetBreakEvenPoint(float fixedCosts, float salesPrice, float variableCostPU)
        {
            return (fixedCosts / salesPrice) - variableCostPU;
        }
        public static double GetBreakEvenPoint(double fixedCosts, double salesPrice, double variableCostPU)
        {
            return (fixedCosts / salesPrice) - variableCostPU;
        }
        public static decimal GetBreakEvenPoint(decimal fixedCosts, decimal salesPrice, decimal variableCostPU)
        {
            return (fixedCosts / salesPrice) - variableCostPU;
        }

        public static int GetCashRatio(int cash, int currentLiabilities)
        {
            return cash / currentLiabilities;
        }
        public static float GetCashRatio(float cash, float currentLiabilities)
        {
            return cash / currentLiabilities;
        }
        public static double GetCashRatio(double cash, double currentLiabilities)
        {
            return cash / currentLiabilities;
        }
        public static decimal GetCashRatio(decimal cash, decimal currentLiabilities)
        {
            return cash / currentLiabilities;
        }

        public static int GetProfitMargin(int netIncome, int sales)
        {
            return netIncome / sales;
        }
        public static float GetProfitMargin(float netIncome, float sales)
        {
            return netIncome / sales;
        }
        public static double GetProfitMargin(double netIncome, double sales)
        {
            return netIncome / sales;
        }
        public static decimal GetProfitMargin(decimal netIncome, decimal sales)
        {
            return netIncome / sales;
        }

        public static int GetDebt2EquityRatio(int totalLiabilities, int totalEquity)
        {
            return totalLiabilities / totalEquity;
        }
        public static float GetDebt2EquityRatio(float totalLiabilities, float totalEquity)
        {
            return totalLiabilities / totalEquity;
        }
        public static double GetDebt2EquityRatio(double totalLiabilities, double totalEquity)
        {
            return totalLiabilities / totalEquity;
        }
        public static decimal GetDebt2EquityRatio(decimal totalLiabilities, decimal totalEquity)
        {
            return totalLiabilities / totalEquity;
        }

        public static int GetCostofGoodsSold(int costOfMaterial, int costOfOutputs)
        {
            return costOfMaterial - costOfOutputs;
        }
        public static float GetCostofGoodsSold(float costOfMaterial, float costOfOutputs)
        {
            return costOfMaterial - costOfOutputs;
        }
        public static double GetCostofGoodsSold(double costOfMaterial, double costOfOutputs)
        {
            return costOfMaterial - costOfOutputs;
        }
        public static decimal GetCostofGoodsSold(decimal costOfMaterial, decimal costOfOutputs)
        {
            return costOfMaterial - costOfOutputs;
        }

        public static int GetRetainedEarnings(int startRetainedEarnings, int netIncome, int cashDividends)
        {
            return (startRetainedEarnings + netIncome) - cashDividends;
        }
        public static float GetRetainedEarnings(float startRetainedEarnings, float netIncome, float cashDividends)
        {
            return (startRetainedEarnings + netIncome) - cashDividends;
        }
        public static double GetRetainedEarnings(double startRetainedEarnings, double netIncome, double cashDividends)
        {
            return (startRetainedEarnings + netIncome) - cashDividends;
        }
        public static decimal GetRetainedEarnings(decimal startRetainedEarnings, decimal netIncome, decimal cashDividends)
        {
            return (startRetainedEarnings + netIncome) - cashDividends;
        }
    }
}
