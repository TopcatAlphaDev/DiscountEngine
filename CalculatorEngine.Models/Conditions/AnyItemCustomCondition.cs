using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace CalculatorEngine.Models.Conditions
{
    public class AnyItemCustomCondition : BaseCondition
    {
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                CustomExpression = DynamicExpressionParser.ParseLambda<Item, bool>(new ParsingConfig(), false, value);
            }
        }
        private string query;
        private Expression<Func<Item,bool>> CustomExpression;

        public AnyItemCustomCondition(string id) : base(id)
        {
        }

        public override bool IsFulFilled(Item item, Context context)
        {
            if (base.IsFulFilled(item, context) == false) return false;

            if (context.Items.AsQueryable().Any(CustomExpression) == false) return false;

            return Result(item, true);
        }

        public void SetQuery(string query) 
        {
            
        }
    }
}