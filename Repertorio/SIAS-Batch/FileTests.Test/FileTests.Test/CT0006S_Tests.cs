using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.CT0006S;

namespace FileTests.Test
{
    [Collection("CT0006S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class CT0006S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GE353_COD_INI_FAIXA_CEP" , ""},
                { "GE353_COD_FIM_FAIXA_CEP" , ""},
                { "GE353_NOM_UNIDADE_OPER" , ""},
                { "GE353_NOM_CENTRALIZADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GE332_COD_INI_CEP" , ""},
                { "GE332_COD_FIM_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1", q1);

            #endregion

            #region R1110_10_SELECT_GE318_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE318_COD_UF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_10_SELECT_GE318_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1110_10_SELECT_GE318_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE318_IND_TP_LOGRADOURO" , ""},
                { "GE318_NOM_LOGRADOURO" , ""},
                { "GE329_NOM_BAIRRO" , ""},
                { "GE324_NOM_LOCALIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_10_SELECT_GE318_DB_SELECT_2_Query1", q3);

            #endregion

            #region R1110_20_SELECT_GE321_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE321_COD_UF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_20_SELECT_GE321_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1110_20_SELECT_GE321_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GE321_NOM_TP_LOGRADOURO" , ""},
                { "GE321_NOM_LOGRADOURO" , ""},
                { "GE329_NOM_BAIRRO" , ""},
                { "GE324_NOM_LOCALIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_20_SELECT_GE321_DB_SELECT_2_Query1", q5);

            #endregion

            #region R1110_30_SELECT_GE322_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE322_COD_UF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_30_SELECT_GE322_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1110_30_SELECT_GE322_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GE322_NOM_TP_LOGRADOURO" , ""},
                { "GE322_NOM_LOGRADOURO" , ""},
                { "GE329_NOM_BAIRRO" , ""},
                { "GE324_NOM_LOCALIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_30_SELECT_GE322_DB_SELECT_2_Query1", q7);

            #endregion

            #region R1110_40_SELECT_GE326_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE326_COD_UF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_40_SELECT_GE326_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1110_50_SELECT_GE324_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "GE324_COD_UF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_50_SELECT_GE324_DB_SELECT_1_Query1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void CT0006S_Tests_Fact()
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
                #region R1110_50_SELECT_GE324_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R1110_50_SELECT_GE324_DB_SELECT_1_Query1");
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "GE324_COD_UF" , "ZO"}
            });
                AppSettings.TestSet.DynamicData.Add("R1110_50_SELECT_GE324_DB_SELECT_1_Query1", q9);

                #endregion
                #endregion

                var program = new CT0006S();

                var param = new CT0006S_CT0006S_LINKAGE();
                param.CT0006S_CEP_DESTINO.Value = 123456789;
                param.CT0006S_CIDADE.Value = "São Paulo";
                param.CT0006S_BAIRRO.Value = "Limão";
                param.CT0006S_MENSAGEM.Value = "Sem Mensagem";
                param.CT0006S_SIGLA_UF.Value = "ZO";
                param.CT0006S_TP_LOGRAD.Value = "X";
                param.CT0006S_UNIDADE_OPER.Value = "Unidade II";

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                   .Where(x => (x.Key.Contains("Update")
                   || x.Key.Contains("Insert")
                   || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                   || x.Value.DynamicList.Count == 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.False(program.AREA_DE_WORK.WRETORNO.Value == "*");
                Assert.Equal(selects.Count(), (allSelects.Count()/2));
            }
        }
        [Fact]
        public static void CT0006S_Tests_FactError()
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
                #region R1110_50_SELECT_GE324_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R1110_50_SELECT_GE324_DB_SELECT_1_Query1");
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "GE324_COD_UF" , "ZO"}
            });
                AppSettings.TestSet.DynamicData.Add("R1110_50_SELECT_GE324_DB_SELECT_1_Query1", q9);

                #endregion
                #endregion

                var program = new CT0006S();

                var param = new CT0006S_CT0006S_LINKAGE();

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                   .Where(x => (x.Key.Contains("Update")
                   || x.Key.Contains("Insert")
                   || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                   || x.Value.DynamicList.Count == 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(program.AREA_DE_WORK.WRETORNO.Value == "*");
                //Assert.Equal(selects.Count(), (allSelects.Count() / 2));
            }
        }
    }
}