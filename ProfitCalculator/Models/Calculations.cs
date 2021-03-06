using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculator
{
    class Calculations
    {
        public double CalculateBuyCost(double BuyPrice, double BuyCommission)
        {
            return (BuyPrice - (BuyPrice * BuyCommission));
        }

        public double CalculateSellCost(double SellPrice, double SellCommission)
        {
            return (SellPrice - (SellPrice * SellCommission));
        }

        public double CalculateProfit(double BuyPrice, double SellPrice, double SellCommission, double BuyCommission)
        {
            return (CalculateSellCost(SellPrice, SellCommission) - CalculateBuyCost(BuyPrice, BuyCommission));
        }

        public double CalculateProfitPercent(double BuyPrice, double SellPrice, double SellCommission, double BuyCommission)
        {
            return (CalculateSellCost(SellPrice, SellCommission) - CalculateBuyCost(BuyPrice, BuyCommission)) / CalculateBuyCost(BuyPrice, BuyCommission);
        }

        public double CalculateTaxCost(double BuyPrice, double SellPrice, double SellCommission, double BuyCommission, double TaxPerc)
        {
            return CalculateProfit(BuyPrice, SellPrice, SellCommission, BuyCommission) * TaxPerc;
        }

        public double CalculateProfitAfterTax(double BuyPrice, double SellPrice, double SellCommission, double BuyCommission, double TaxPerc)
        {
            return (CalculateProfit(BuyPrice, SellPrice, SellCommission, BuyCommission) - (CalculateProfit(BuyPrice, SellPrice, SellCommission, BuyCommission)) * TaxPerc);
        }
    }
}
