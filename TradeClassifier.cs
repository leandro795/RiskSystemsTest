using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystemsTest
{
    public class TradeClassifier
    {
        private readonly List<ICategory> _categories;

        public TradeClassifier()
        {
            _categories = new List<ICategory>
        {
            new ExpiredCategory(),
            new HighRiskCategory(),
            new MediumRiskCategory()
           // new PepCategory() Add Categoria PEP
        };
        }

        public string ClassifyTrade(ITrade trade, DateTime referenceDate)
        {
            foreach (var category in _categories)
            {
                var result = category.Classify(trade, referenceDate);
                if (result != null)
                    return result;
            }

            return "UNCATEGORIZED";
        }
    }

}
