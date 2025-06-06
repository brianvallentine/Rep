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
using static Code.VA0101S;

namespace FileTests.Test
{
    [Collection("VA0101S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0101S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "CODSUBES" , "8"},
                { "RAMO" , "97"},
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DTREF" , ""},
                { "CODPRODAZ" , ""},
                { "QTD_VIDAS_VG" , ""},
                { "QTD_VIDAS_AP" , ""},
                { "PRM_VG" , ""},
                { "PRM_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1", q1);

            #endregion

            #region Execute_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DTREF" , "2023-10-10"},
                { "DTREF2" , "2023-11-10"},
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q2);

            #endregion

            #region Execute_DB_SELECT_3_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "NUM_FATURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_3_Query1", q3);

            #endregion

            #region M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "QTD_VIDAS_VG_W" , ""},
                { "QTD_VIDAS_AP_W" , ""},
                { "PRM_VG_W" , ""},
                { "PRM_AP_W" , ""},
                { "CODPRODAZ" , ""},
                { "DTREF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region Execute_DB_SELECT_4_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "QTD_VIDAS_VG_W" , ""},
                { "QTD_VIDAS_AP_W" , ""},
                { "PRM_VG_W" , ""},
                { "PRM_AP_W" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0101S_Tests_Fact_Error_ReturnCode9()
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
                var inputParam = new VA0101S_PARAMETROS()
                {
                    PARM_CODPRODAZ = new StringBasis()
                    {
                        Pic = new PIC("X", "3", "X(03)."),
                        Value = "EMP"
                    },
                    PARM_QTD_VIDAS = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 200
                    }
                };
                #region Execute_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new VA0101S();
                program.Execute(inputParam);

                Assert.True(program.PARAMETROS.PARM_RETCODE == 100);
            }
        }

        [Fact]
        public static void VA0101S_Tests_Fact_AlteraReferencia_ReturnCode00()
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
                var inputParam = new VA0101S_PARAMETROS()
                {
                    PARM_CODPRODAZ = new StringBasis()
                    {
                        Pic = new PIC("X", "3", "X(03)."),
                        Value = "EMP"
                    },
                    PARM_QTD_VIDAS = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 200
                    }
                };
                #region Execute_Query4

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "QTD_VIDAS_VG_W" , "300"},
                { "QTD_VIDAS_AP_W" , "300"},
                { "PRM_VG_W" , "17063.00"},
                { "PRM_AP_W" , "17063.00"},
                { "TIMESTAMP" , "2023-10-23 15:19:53.851"},
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q3);

                #endregion


                #endregion
                var program = new VA0101S();
                program.Execute(inputParam);

                Assert.True(program.PARAMETROS.PARM_RETCODE == 0);

                //M_0200_ALTERA_REFERENCIA_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("PRM_AP_W", out var val0r) && val0r.Contains("0000000017063.00"));
                Assert.True(envList0[1].TryGetValue("CODPRODAZ", out var val1r) && val1r.Contains("EMP"));
                Assert.True(envList0[1].TryGetValue("QTD_VIDAS_VG_W", out var val2r) && val2r.Contains("500"));
                Assert.True(envList0[1].TryGetValue("QTD_VIDAS_AP_W", out var val3r) && val3r.Contains("500"));

            }
        }
        [Fact]
        public static void VA0101S_Tests_Fact_IncluiReferencia_ReturnCode00()
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
                var inputParam = new VA0101S_PARAMETROS()
                {
                    PARM_CODPRODAZ = new StringBasis()
                    {
                        Pic = new PIC("X", "3", "X(03)."),
                        Value = "PRM"
                    },
                    PARM_QTD_VIDAS = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 1200
                    }
                };

                #region Execute_Query4

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q3);

                #endregion
                #endregion
                var program = new VA0101S();
                program.Execute(inputParam);

                Assert.True(program.PARAMETROS.PARM_RETCODE == 0);

                //M_0100_INCLUI_REFERENCIA_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("QTD_VIDAS_VG", out var val0r) && val0r.Contains("1200"));
                Assert.True(envList0[1].TryGetValue("CODPRODAZ", out var val1r) && val1r.Contains("PRM"));

            }
        }
    }
}