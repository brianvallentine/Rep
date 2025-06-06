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
using static Code.VP0050B;

namespace FileTests.Test
{
    [Collection("VP0050B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VP0050B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_DATA_REFER" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
                { "V1RELA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1", q2);

            #endregion

            #region R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q3);

            #endregion

            #region VP0050B_V0FUNCIOCEF

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0FUNC_COD_SUREG" , ""},
                { "V0FUNC_NRMATRIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0050B_V0FUNCIOCEF", q4);

            #endregion

            #region VP0050B_V0SEGURAVG

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_NRCERTIF" , ""},
                { "V0SEGV_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0050B_V0SEGURAVG", q5);

            #endregion

            #region R1300_SELECT_SUREG_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0SURE_NOME_SUREG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_SELECT_SUREG_DB_SELECT_1_Query1", q6);

            #endregion

            #region VP0050B_V0HISTCOBVA

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_NRPARCEL" , ""},
                { "V0HIST_DTVENCTO" , ""},
                { "V0HIST_SITUACAO" , ""},
                { "V0HIST_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0050B_V0HISTCOBVA", q7);

            #endregion

            #region VP0050B_V0AVERBCEF

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0AVER_NRMATRIC" , ""},
                { "V0AVER_VAL_AVERB" , ""},
                { "V0AVER_TPMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0050B_V0AVERBCEF", q8);

            #endregion

            #region R5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLTITCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_NRCERTIF" , ""},
                { "V0SEGV_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1", q10);

            #endregion

            #region R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLTITCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1", q11);

            #endregion

            #region R9100_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R9100_00_INSERT_V0RELATORIO_DB_INSERT_2_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_INSERT_V0RELATORIO_DB_INSERT_2_Insert1", q13);

            #endregion

            #region R9100_00_INSERT_V0RELATORIO_DB_INSERT_3_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_INSERT_V0RELATORIO_DB_INSERT_3_Insert1", q14);

            #endregion

            #region R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1", q15);

            #endregion

            #region R9100_00_INSERT_V0RELATORIO_DB_INSERT_5_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_INSERT_V0RELATORIO_DB_INSERT_5_Insert1", q16);

            #endregion

            #region R9100_00_INSERT_V0RELATORIO_DB_INSERT_6_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_INSERT_V0RELATORIO_DB_INSERT_6_Insert1", q17);

            #endregion

            #region R9100_00_INSERT_V0RELATORIO_DB_INSERT_7_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_INSERT_V0RELATORIO_DB_INSERT_7_Insert1", q18);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RVP0050B_FILE_NAME_P")]
        public static void VP0050B_Tests_Theory_Erro(string RVP0050B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVP0050B_FILE_NAME_P = $"{RVP0050B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                PROALN01_Tests.Load_Parameters();

                #region R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "Foursys"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q3);

                #endregion

                #region VP0050B_V0FUNCIOCEF

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0FUNC_COD_SUREG" , ""},
                { "V0FUNC_NRMATRIC" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VP0050B_V0FUNCIOCEF");
                AppSettings.TestSet.DynamicData.Add("VP0050B_V0FUNCIOCEF", q4);

                #endregion

                #endregion
                var program = new VP0050B();
                program.Execute(RVP0050B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }

        [Theory]
        [InlineData("RVP0050B_FILE_NAME_P")]
        public static void VP0050B_Tests_Theory(string RVP0050B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVP0050B_FILE_NAME_P = $"{RVP0050B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                PROALN01_Tests.Load_Parameters();


                #region R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_DATA_REFER" , "2020-06-01"},
                { "V1RELA_MES_REFER" , "06"},
                { "V1RELA_ANO_REFER" , "2020"},
                { "V1RELA_SITUACAO" , "A"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "Foursys"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1300_SELECT_SUREG_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0SURE_NOME_SUREG" , "Teste1"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0SURE_NOME_SUREG" , "Teste2"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0SURE_NOME_SUREG" , "Teste3"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_SELECT_SUREG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_SELECT_SUREG_DB_SELECT_1_Query1", q6);

                #endregion

                #endregion
                var program = new VP0050B();
                program.Execute(RVP0050B_FILE_NAME_P);

                //R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1
                var envList = AppSettings.TestSet.DynamicData["R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1"].DynamicList;
                Assert.True(envList.Count == 0);

                //R9100_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R9100_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V1RELA_MES_REFER", out var valor1) && valor1.Contains("06"));
                Assert.True(envList1.Count > 1);

                //R9100_00_INSERT_V0RELATORIO_DB_INSERT_2_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R9100_00_INSERT_V0RELATORIO_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V1RELA_ANO_REFER", out var valor2) && valor2.Contains("2020"));
                Assert.True(envList2.Count > 1);

                //R9100_00_INSERT_V0RELATORIO_DB_INSERT_3_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R9100_00_INSERT_V0RELATORIO_DB_INSERT_3_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V1RELA_MES_REFER", out var valor3) && valor3.Contains("06"));
                Assert.True(envList3.Count > 1);

                //R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("V1RELA_ANO_REFER", out var valor4) && valor4.Contains("2020"));
                Assert.True(envList4.Count > 1);

                //R9100_00_INSERT_V0RELATORIO_DB_INSERT_5_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R9100_00_INSERT_V0RELATORIO_DB_INSERT_5_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("V1RELA_MES_REFER", out var valor5) && valor5.Contains("06"));
                Assert.True(envList5.Count > 1);

                //R9100_00_INSERT_V0RELATORIO_DB_INSERT_6_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R9100_00_INSERT_V0RELATORIO_DB_INSERT_6_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("V1RELA_ANO_REFER", out var valor6) && valor6.Contains("2020"));
                Assert.True(envList6.Count > 1);

                //R9100_00_INSERT_V0RELATORIO_DB_INSERT_7_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["R9100_00_INSERT_V0RELATORIO_DB_INSERT_7_Insert1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("V1RELA_MES_REFER", out var valor7) && valor7.Contains("06"));
                Assert.True(envList7.Count > 1);


                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}