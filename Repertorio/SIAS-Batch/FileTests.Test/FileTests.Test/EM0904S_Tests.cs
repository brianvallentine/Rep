using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.EM0904S;

namespace FileTests.Test
{
    [Collection("EM0904S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0904S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region EM0904S_V1MOEDA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , ""},
                { "MOED_TIPO_MOEDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0904S_V1MOEDA", q0);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0904S_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new EM0904S();
                program.Execute(new EM0904S_CALCULOS());

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

            }
        }
        [Fact]
        public static void EM0904S_Tests_SemDados()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new EM0904S();

                AppSettings.TestSet.DynamicData.Remove("EM0904S_V1MOEDA");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , ""},
                { "MOED_TIPO_MOEDA" , ""},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Add("EM0904S_V1MOEDA", q0);

                program.Execute(new EM0904S_CALCULOS());

                Assert.True(program.CALCULOS.W01A0077.W01A0077_COD == 100);
            }
        }
    }
}