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
using static Code.GE0503B;

namespace FileTests.Test
{
    [Collection("GE0503B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0503B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , ""},
                { "HOST_CURRENT_TIMESTAMP" , ""},
            });
            
            //AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "AGENCIAS_COD_BANCO" , ""},
                { "AGENCIAS_COD_AGENCIA" , ""},
            });
            //AppSettings.TestSet.DynamicData.Add("R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R200_CONSULTA_BANCO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , ""},
                { "OD001_DTH_CADASTRAMENTO" , ""},
                { "OD001_NUM_DV_PESSOA" , ""},
                { "OD001_IND_PESSOA" , ""},
                { "OD001_STA_INF_INTEGRA" , ""},
                { "OD009_SEQ_CONTA_BANCARIA" , ""},
                { "OD009_DTH_CADASTRAMENTO" , ""},
                { "OD009_STA_CONTA" , ""},
                { "OD009_COD_BANCO" , ""},
                { "OD009_COD_AGENCIA" , ""},
                { "OD009_IND_CONTA_BANCARIA" , ""},
                { "OD009_NUM_CONTA" , ""},
                { "OD009_NUM_DV_CONTA" , ""},
                { "OD009_NUM_OPERACAO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R200_CONSULTA_BANCO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R100_INSERT_BANCO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "OD009_SEQ_CONTA_BANCARIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R100_INSERT_BANCO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R100_INSERT_BANCO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "OD009_NUM_PESSOA" , ""},
                { "OD009_SEQ_CONTA_BANCARIA" , ""},
                { "OD009_DTH_CADASTRAMENTO" , ""},
                { "OD009_STA_CONTA" , ""},
                { "OD009_COD_BANCO" , ""},
                { "OD009_COD_AGENCIA" , ""},
                { "OD009_IND_CONTA_BANCARIA" , ""},
                { "OD009_NUM_CONTA" , ""},
                { "OD009_NUM_DV_CONTA" , ""},
                { "OD009_NUM_OPERACAO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_INSERT_BANCO_DB_INSERT_1_Insert1", q4);

            #endregion

            #region GE0503B_V0BANCO

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , ""},
                { "OD001_DTH_CADASTRAMENTO" , ""},
                { "OD001_NUM_DV_PESSOA" , ""},
                { "OD001_IND_PESSOA" , ""},
                { "OD001_STA_INF_INTEGRA" , ""},
                { "OD009_SEQ_CONTA_BANCARIA" , ""},
                { "OD009_DTH_CADASTRAMENTO" , ""},
                { "OD009_STA_CONTA" , ""},
                { "OD009_COD_BANCO" , ""},
                { "OD009_COD_AGENCIA" , ""},
                { "OD009_IND_CONTA_BANCARIA" , ""},
                { "OD009_NUM_CONTA" , ""},
                { "OD009_NUM_DV_CONTA" , ""},
                { "OD009_NUM_OPERACAO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GE0503B_V0BANCO", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0503B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new GE0503B();
                program.Execute(new GE0503B_LINK_PARAMETRO());

                Assert.True(true);
            }
        }
    }
}