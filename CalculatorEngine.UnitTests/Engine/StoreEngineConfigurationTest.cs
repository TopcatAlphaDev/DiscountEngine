using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CalculatorEngine.UnitTests.Engine
{
    [TestClass]
    public class StoreEngineConfigurationTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void EngineConfigurationToJson()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5, 0);
            var condition = ConditionFactory.GetItemPropertiesCondition();
            discount.AddCondition(condition);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetAmountDiscount(1, 1);
            var condition2 = ConditionFactory.GetItemPropertiesCondition();
            discount2.AddCondition(condition2);
            discount2.Cumulating = true;
            _calculatorEngine.AddDiscount(discount2);

            var engineAsJson = JsonConvert.SerializeObject(_calculatorEngine, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All, 
                Formatting = Formatting.Indented
            });

            Assert.AreEqual(engineAsJson, $@"{{
  ""$type"": ""CalculatorEngine.Library.CalculatorEngine, CalculatorEngine.Library"",
  ""_discounts"": {{
    ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Discounts.BaseDiscount, CalculatorEngine.Models]], System.Private.CoreLib"",
    ""$values"": [
      {{
        ""$type"": ""CalculatorEngine.Models.Discounts.AmountDiscount, CalculatorEngine.Models"",
        ""Amount"": 5.0,
        ""Cumulating"": true,
        ""Id"": ""{discount.Id}"",
        ""SortOrder"": 0,
        ""Conditions"": {{
          ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Conditions.BaseCondition, CalculatorEngine.Models]], System.Private.CoreLib"",
          ""$values"": [
            {{
              ""$type"": ""CalculatorEngine.Models.Conditions.ItemPropertiesCondition, CalculatorEngine.Models"",
              ""Properties"": {{
                ""$type"": ""System.Collections.Generic.List`1[[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib]], System.Private.CoreLib"",
                ""$values"": [
                  {{
                    ""Key"": ""Group"",
                    ""Value"": ""Shoe""
                  }}
                ]
              }},
              ""MatchAllProperties"": false,
              ""Id"": ""{condition.Id}"",
              ""SortOrder"": 0,
              ""Conditions"": {{
                ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Conditions.BaseCondition, CalculatorEngine.Models]], System.Private.CoreLib"",
                ""$values"": []
              }}
            }}
          ]
        }}
      }},
      {{
        ""$type"": ""CalculatorEngine.Models.Discounts.AmountDiscount, CalculatorEngine.Models"",
        ""Amount"": 1.0,
        ""Cumulating"": true,
        ""Id"": ""{discount2.Id}"",
        ""SortOrder"": 1,
        ""Conditions"": {{
          ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Conditions.BaseCondition, CalculatorEngine.Models]], System.Private.CoreLib"",
          ""$values"": [
            {{
              ""$type"": ""CalculatorEngine.Models.Conditions.ItemPropertiesCondition, CalculatorEngine.Models"",
              ""Properties"": {{
                ""$type"": ""System.Collections.Generic.List`1[[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib]], System.Private.CoreLib"",
                ""$values"": [
                  {{
                    ""Key"": ""Group"",
                    ""Value"": ""Shoe""
                  }}
                ]
              }},
              ""MatchAllProperties"": false,
              ""Id"": ""{condition2.Id}"",
              ""SortOrder"": 0,
              ""Conditions"": {{
                ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Conditions.BaseCondition, CalculatorEngine.Models]], System.Private.CoreLib"",
                ""$values"": []
              }}
            }}
          ]
        }}
      }}
    ]
  }},
  ""_validators"": {{
    ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Validators.BaseValidator, CalculatorEngine.Models]], System.Private.CoreLib"",
    ""$values"": []
  }},
  ""_correctors"": {{
    ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Correctors.BaseCorrector, CalculatorEngine.Models]], System.Private.CoreLib"",
    ""$values"": []
  }}
}}");
        }

        [TestMethod]
        public void JsonToEngineConfiguration()
        {
            var engineAsJson = $@"{{
  ""$type"": ""CalculatorEngine.Library.CalculatorEngine, CalculatorEngine.Library"",
  ""_discounts"": {{
    ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Discounts.BaseDiscount, CalculatorEngine.Models]], System.Private.CoreLib"",
    ""$values"": [
      {{
        ""$type"": ""CalculatorEngine.Models.Discounts.AmountDiscount, CalculatorEngine.Models"",
        ""Amount"": 5.0,
        ""Cumulating"": true,
        ""Id"": ""1340622837"",
        ""SortOrder"": 0,
        ""Conditions"": {{
          ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Conditions.BaseCondition, CalculatorEngine.Models]], System.Private.CoreLib"",
          ""$values"": [
            {{
              ""$type"": ""CalculatorEngine.Models.Conditions.ItemPropertiesCondition, CalculatorEngine.Models"",
              ""Properties"": {{
                ""$type"": ""System.Collections.Generic.List`1[[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib]], System.Private.CoreLib"",
                ""$values"": [
                  {{
                    ""Key"": ""Group"",
                    ""Value"": ""Shoe""
                  }}
                ]
              }},
              ""MatchAllProperties"": false,
              ""Id"": ""409591111"",
              ""SortOrder"": 0,
              ""Conditions"": {{
                ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Conditions.BaseCondition, CalculatorEngine.Models]], System.Private.CoreLib"",
                ""$values"": []
              }}
            }}
          ]
        }}
      }},
      {{
        ""$type"": ""CalculatorEngine.Models.Discounts.AmountDiscount, CalculatorEngine.Models"",
        ""Amount"": 1.0,
        ""Cumulating"": true,
        ""Id"": ""1605538867"",
        ""SortOrder"": 1,
        ""Conditions"": {{
          ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Conditions.BaseCondition, CalculatorEngine.Models]], System.Private.CoreLib"",
          ""$values"": [
            {{
              ""$type"": ""CalculatorEngine.Models.Conditions.ItemPropertiesCondition, CalculatorEngine.Models"",
              ""Properties"": {{
                ""$type"": ""System.Collections.Generic.List`1[[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib]], System.Private.CoreLib"",
                ""$values"": [
                  {{
                    ""Key"": ""Group"",
                    ""Value"": ""Shoe""
                  }}
                ]
              }},
              ""MatchAllProperties"": false,
              ""Id"": ""435754320"",
              ""SortOrder"": 0,
              ""Conditions"": {{
                ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Conditions.BaseCondition, CalculatorEngine.Models]], System.Private.CoreLib"",
                ""$values"": []
              }}
            }}
          ]
        }}
      }}
    ]
  }},
  ""_validators"": {{
    ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Validators.BaseValidator, CalculatorEngine.Models]], System.Private.CoreLib"",
    ""$values"": []
  }},
  ""_correctors"": {{
    ""$type"": ""System.Collections.Generic.List`1[[CalculatorEngine.Models.Correctors.BaseCorrector, CalculatorEngine.Models]], System.Private.CoreLib"",
    ""$values"": []
  }}
}}";

            var engine = JsonConvert.DeserializeObject<Library.CalculatorEngine>(engineAsJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            engine.AddItem(item);

            engine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)15.50);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}