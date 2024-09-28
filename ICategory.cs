using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystemsTest
{
    public interface ICategory
    {
        string Classify(ITrade trade, DateTime referenceDate);
    }

    public class ExpiredCategory : ICategory
    {
        public string Classify(ITrade trade, DateTime referenceDate)
        {
            if (trade.NextPaymentDate.AddDays(30) < referenceDate)
                return "EXPIRED";
            return null;
        }
    }

    public class HighRiskCategory : ICategory
    {
        public string Classify(ITrade trade, DateTime referenceDate)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Private")
                return "HIGHRISK";
            return null;
        }
    }

    public class MediumRiskCategory : ICategory
    {
        public string Classify(ITrade trade, DateTime referenceDate)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Public")
                return "MEDIUMRISK";
            return null;
        }
    }

    //public class PepCategory : ICategory
    //{
    //    public string Classify(ITrade trade, DateTime referenceDate)
    //    {
    //        if (trade is IPoliticallyExposed && ((IPoliticallyExposed)trade).IsPoliticallyExposed)
    //            return "PEP";
    //        return null;
    //    }
    //}

    // Para implementar a categoria PEP includa a propriedade IsPoliticallyExposed na Interface ITrade

}
