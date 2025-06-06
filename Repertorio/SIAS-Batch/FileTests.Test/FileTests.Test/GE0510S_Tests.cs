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
using static Code.GE0510S;

namespace FileTests.Test
{
    [Collection("GE0510S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0510S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LK_GE510_COD_MODALIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "LK_GE510_NUM_APOLICE" , ""},
                { "WS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0300_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_SELECT_PRODUTO_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0510S_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new GE0510S();
                program.Execute(new GE0510S_REGISTRO_LINKAGE_GE0510S());
                AppSettings.TestSet.DynamicData
                   .Where(x => (x.Key.Contains("Update")
                   || x.Key.Contains("Insert")
                   || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                   || x.Value.DynamicList.Count == 0);
                
            }
        }

        public static void Load_Parameters_To_VG0100B()
        {
            #region PARAMETERS
            #region R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LK_GE510_COD_MODALIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "LK_GE510_NUM_APOLICE" , "1"},
                { "WS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0300_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_SELECT_PRODUTO_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }
    }
}