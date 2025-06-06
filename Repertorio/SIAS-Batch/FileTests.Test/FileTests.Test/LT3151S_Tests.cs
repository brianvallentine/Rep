using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.LT3151S;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test
{

    [Collection("LT3151S_Tests")]

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class LT3151S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_EXISTE_DESC_SEM_SINI" , ""},
                { "WS_EXISTE_DESC_SEM_SINI_INF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PRAZOSEG_PCT_PRM_ANUAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        [Fact]
        public static void LT3151S_Tests_Fact_Erro99()
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

                LT3150S_Tests.Load_Parameters();
                //LT3159S_Tests.Load_Parameters();
                LT3171S_Tests.Load_Parameters();

                #endregion
                var program = new LT3151S();
                program.Execute(new LBLT3151_LT3151_AREA_PARAMETROS());

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Fact]
        public static void LT3151S_Tests_Fact()
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

                LT3150S_Tests.Load_Parameters();
                LT3150S_Tests.Load_Parameters();
                LT3171S_Tests.Load_Parameters();

                #region R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "WS_QT_REG" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_EXISTE_DESC_SEM_SINI" , "0"},
                    { "WS_EXISTE_DESC_SEM_SINI_INF" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PRAZOSEG_PCT_PRM_ANUAL" , "13"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1", q3);

                #endregion

                var parametros = new LBLT3151_LT3151_AREA_PARAMETROS();
                parametros.LT3151_COD_LOTERICO.SetValue(2);
                parametros.LT3151_DTINIVIG_APOLICE.SetValue("2025-01-01");
                parametros.LT3151_COD_REGIAO.SetValue(1);
                parametros.LT3151_NUM_CLASSE_ADESAO.SetValue(1);

                #endregion
                var program = new LT3151S();
                program.Execute(parametros);

                var envList1 = AppSettings.TestSet.DynamicData["R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}
