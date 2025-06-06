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
using static Code.SI0101B;

namespace FileTests.Test
{
    [Collection("SI0101B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class SI0101B_Tests
    {
        
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0101B_V1RELATSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_APOLICE" , ""},
                { "RELSIN_DTINIVIG" , ""},
                { "RELSIN_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0101B_V1RELATSINI", q2);

            #endregion

            #region SI0101B_TMESTSIN1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MEST_APOL_SINI" , ""},
                { "MEST_DATCMD" , ""},
                { "MEST_DATORR" , ""},
                { "MEST_FONTE" , ""},
                { "MEST_CODSUBES" , ""},
                { "THIST_DTMOVTO1" , ""},
                { "THIST_VALPRI1" , ""},
                { "MEST_MOEDA_SIN" , ""},
                { "MEST_RAMO" , ""},
                { "MEST_CODCAU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0101B_TMESTSIN1", q3);

            #endregion

            #region SI0101B_V1HISTSINI

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "THIST_DTMOVTO" , ""},
                { "THIST_VALPRI" , ""},
                { "THIST_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0101B_V1HISTSINI", q4);

            #endregion

            #region M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIE_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1", q6);

            #endregion

            #region M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "APOL_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SCAU_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1", q9);

            #endregion

            #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , ""},
                { "GEUNIMO_SIGLUNIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0101M1_1")]
        public static void SI0101B_Tests_Theory(string SI0101M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0101M1_FILE_NAME_P = $"{SI0101M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , "CAIXA SEGURADORA S.A."}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , "2025-01-27"},
                { "SIST_DTCURRENT" , "2025-03-28"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0101B_V1RELATSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_APOLICE" , "12123"},
                { "RELSIN_DTINIVIG" , "1999-01-01"},
                { "RELSIN_DTTERVIG" , "2025-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0101B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0101B_V1RELATSINI", q2);

                #endregion

                #region SI0101B_TMESTSIN1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MEST_APOL_SINI" , "12345"},
                { "MEST_DATCMD" , "1999-01-01"},
                { "MEST_DATORR" , "1999-01-01"},
                { "MEST_FONTE" , "GERAL"},
                { "MEST_CODSUBES" , "1"},
                { "THIST_DTMOVTO1" , "1999-01-01"},
                { "THIST_VALPRI1" , "100"},
                { "MEST_MOEDA_SIN" , "1"},
                { "MEST_RAMO" , "X"},
                { "MEST_CODCAU" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0101B_TMESTSIN1");
                AppSettings.TestSet.DynamicData.Add("SI0101B_TMESTSIN1", q3);

                #endregion

                #region SI0101B_V1HISTSINI

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "THIST_DTMOVTO" , "1999-01-01"},
                { "THIST_VALPRI" , "100"},
                { "THIST_OPERACAO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0101B_V1HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0101B_V1HISTSINI", q4);

                #endregion

                #region M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIE_COD_CLIENTE" , "1096"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "CLIE_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1", q6);

                #endregion

                #region M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "APOL_NOME" , "JOAO FORTES ENGENHARIA S/A"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SCAU_DESCAU" , "DANOS ELETRICOS"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1", q8);

                #endregion

                 #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , "1"},
                { "GEUNIMO_SIGLUNIM" , "R$"},
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , "1"},
                { "GEUNIMO_SIGLUNIM" , "R$"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q10);

                #endregion

                #endregion
             
                var program = new SI0101B();
               
                program.Execute(SI0101M1_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["M_015_000_CABECALHOS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);
             
                var envList3 = AppSettings.TestSet.DynamicData["SI0101B_V1RELATSINI"].DynamicList;
                Assert.Empty(envList3);
             
                var envList4 = AppSettings.TestSet.DynamicData["SI0101B_TMESTSIN1"].DynamicList;
                Assert.Empty(envList4);
              
                var envList5 = AppSettings.TestSet.DynamicData["SI0101B_V1HISTSINI"].DynamicList;
               Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList8);

                var envList9 = AppSettings.TestSet.DynamicData["M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);

                Assert.True(program.W.WABEND.WSQLCODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0101M1_2")]
        public static void SI0101B_Tests99_Theory(string SI0101M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0101M1_FILE_NAME_P = $"{SI0101M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
            
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                            AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0101B_V1RELATSINI

                var q2 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("SI0101B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0101B_V1RELATSINI", q2);

                #endregion

                #region SI0101B_TMESTSIN1

                var q3 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("SI0101B_TMESTSIN1");
                AppSettings.TestSet.DynamicData.Add("SI0101B_TMESTSIN1", q3);

                #endregion

                #region SI0101B_V1HISTSINI

                var q4 = new DynamicData();            
                AppSettings.TestSet.DynamicData.Remove("SI0101B_V1HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0101B_V1HISTSINI", q4);

                #endregion

                #region M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();                
                AppSettings.TestSet.DynamicData.Remove("M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1

                var q6 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1", q6);

                #endregion

                #region M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1

                var q8 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q10);

                #endregion

                #endregion

                var program = new SI0101B();

                program.Execute(SI0101M1_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["M_015_000_CABECALHOS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["SI0101B_V1RELATSINI"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["SI0101B_TMESTSIN1"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["SI0101B_V1HISTSINI"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList8);

                var envList9 = AppSettings.TestSet.DynamicData["M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);

                Assert.True(program.W.WABEND.WSQLCODE != 00);
            }
        }

    }
}