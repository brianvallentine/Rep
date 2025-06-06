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
using static Code.SI0102B;

namespace FileTests.Test
{
    [Collection("SI0102B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0102B_Tests
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
                { "TSISTEMA_DTMOVABE" , ""},
                { "TSISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RAMO_VGAPC" , ""},
                { "RAMO_VG" , ""},
                { "RAMO_AP" , ""},
                { "RAMO_SAUDE" , ""},
                { "RAMO_EDUCACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SEGV_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_072_000_LER_SINIITEM_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGV_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_072_000_LER_SINIITEM_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_073_000_LER_APOLICE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SEGV_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_073_000_LER_APOLICE_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_074_000_LER_CLIENTES_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_074_000_LER_CLIENTES_DB_SELECT_1_Query1", q6);

            #endregion

            #region SI0102B_V1RELATSINI

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "TRELSIN_DTINIVIG" , ""},
                { "TRELSIN_DTTERVIG" , ""},
                { "TRELSIN_CODCORR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0102B_V1RELATSINI", q7);

            #endregion

            #region SI0102B_V1APOLCORRET

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "TAPDCORR_NUM_APOL" , ""},
                { "TMESTSIN_DATCMD" , ""},
                { "TMESTSIN_APOL_SINI" , ""},
                { "TAPDCORR_CODCORR" , ""},
                { "TMESTSIN_MOEDA_SIN" , ""},
                { "TMESTSIN_CODSUBES" , ""},
                { "TMESTSIN_NRCERTIF" , ""},
                { "TMESTSIN_IDTPSEGU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0102B_V1APOLCORRET", q8);

            #endregion

            #region SI0102B_V1HISTSINI

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "THISTSIN_DTMOVTO" , ""},
                { "THISTSIN_VAL_OPER" , ""},
                { "THISTSIN_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0102B_V1HISTSINI", q9);

            #endregion

            #region M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "TAPOLICE_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_NOMPDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "TSISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1", q12);

            #endregion

            #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q13);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0102M1_FILE_NAME_P_1")]
        public static void SI0102B_Tests_Theory(string SI0102M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0102M1_FILE_NAME_P = $"{SI0102M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE


                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "TSISTEMA_DTMOVABE" , "1999-01-01"},
                { "TSISTEMA_DTCURRENT" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RAMO_VGAPC" , "1"},
                { "RAMO_VG" , "2"},
                { "RAMO_AP" , "3"},
                { "RAMO_SAUDE" , "4"},
                { "RAMO_EDUCACAO" , "5"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SEGV_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_072_000_LER_SINIITEM_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SEGV_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_072_000_LER_SINIITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_072_000_LER_SINIITEM_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_073_000_LER_APOLICE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SEGV_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_073_000_LER_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_073_000_LER_APOLICE_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_074_000_LER_CLIENTES_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "CLIE_NOME_RAZAO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_074_000_LER_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_074_000_LER_CLIENTES_DB_SELECT_1_Query1", q6);

                #endregion

                #region SI0102B_V1RELATSINI

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "TRELSIN_DTINIVIG" , "1999-01-01"},
                { "TRELSIN_DTTERVIG" , "1999-01-01"},
                { "TRELSIN_CODCORR" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0102B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0102B_V1RELATSINI", q7);

                #endregion

                #region SI0102B_V1APOLCORRET

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "TAPDCORR_NUM_APOL" , "123456789"},
                { "TMESTSIN_DATCMD" , "2020-01-01"},
                { "TMESTSIN_APOL_SINI" , "12345678"},
                { "TAPDCORR_CODCORR" , "2"},
                { "TMESTSIN_MOEDA_SIN" , "1"},
                { "TMESTSIN_CODSUBES" , "2"},
                { "TMESTSIN_NRCERTIF" , "0"},
                { "TMESTSIN_IDTPSEGU" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0102B_V1APOLCORRET");
                AppSettings.TestSet.DynamicData.Add("SI0102B_V1APOLCORRET", q8);

                #endregion

                #region SI0102B_V1HISTSINI

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "THISTSIN_DTMOVTO" , "1999-01-01"},
                { "THISTSIN_VAL_OPER" , "100"},
                { "THISTSIN_OPERACAO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0102B_V1HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0102B_V1HISTSINI", q9);

                #endregion

                #region M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "TAPOLICE_NOME" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1", q10);

                #endregion

                #region M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_NOMPDT" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1", q11);

                #endregion    

                #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , "100"}
                });
                q13.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , "100"}
                 });
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q13);

                #endregion

                #endregion
                var program = new SI0102B();
                program.Execute(SI0102M1_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["M_015_000_CABECALHOS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);
                //*** TMESTSIN_IDTPSEGU tem que ser diferente de  " " e RAMO_VGAPC = 0, RAMO_VG= 0, RAMO_AP= 0, RAMO_SAUDE= 0, RAMO_EDUCACAO= 0
                //var envList4 = AppSettings.TestSet.DynamicData["M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1"].DynamicList;
                // Assert.Empty(envList4);

                //*** TMESTSIN_IDTPSEGU tem que ser = " " e RAMO_VGAPC <> 0, RAMO_VG <> 0, RAMO_AP <> 0, RAMO_SAUDE <> 0, RAMO_EDUCACAO <> 0
                 var envList5 = AppSettings.TestSet.DynamicData["M_072_000_LER_SINIITEM_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                //var envList6 = AppSettings.TestSet.DynamicData["M_073_000_LER_APOLICE_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["M_074_000_LER_CLIENTES_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList7);   

                var envList9 = AppSettings.TestSet.DynamicData["SI0102B_V1RELATSINI"].DynamicList;
                Assert.Empty(envList9);

                var envList10 = AppSettings.TestSet.DynamicData["SI0102B_V1APOLCORRET"].DynamicList;
                Assert.Empty(envList10);

                var envList11 = AppSettings.TestSet.DynamicData["SI0102B_V1HISTSINI"].DynamicList;
                Assert.Empty(envList11);

                var envList12 = AppSettings.TestSet.DynamicData["M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList12);

                var envList13 = AppSettings.TestSet.DynamicData["M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList13);

                var envList15 = AppSettings.TestSet.DynamicData["M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList15);

                Assert.True(program.W.WABEND.WSQLCODE == 00);
            }
        }


        [Theory]
        [InlineData("SI0102M1_FILE_NAME_P_2")]
        public static void SI0102B_Tests99_Theory(string SI0102M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0102M1_FILE_NAME_P = $"{SI0102M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_072_000_LER_SINIITEM_DB_SELECT_1_Query1

                var q4 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_072_000_LER_SINIITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_072_000_LER_SINIITEM_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_073_000_LER_APOLICE_DB_SELECT_1_Query1

                var q5 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_073_000_LER_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_073_000_LER_APOLICE_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_074_000_LER_CLIENTES_DB_SELECT_1_Query1

                var q6 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_074_000_LER_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_074_000_LER_CLIENTES_DB_SELECT_1_Query1", q6);

                #endregion

                #region SI0102B_V1RELATSINI

                var q7 = new DynamicData();             
                AppSettings.TestSet.DynamicData.Remove("SI0102B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0102B_V1RELATSINI", q7);

                #endregion

                #region SI0102B_V1APOLCORRET

                var q8 = new DynamicData();            
                AppSettings.TestSet.DynamicData.Remove("SI0102B_V1APOLCORRET");
                AppSettings.TestSet.DynamicData.Add("SI0102B_V1APOLCORRET", q8);

                #endregion

                #region SI0102B_V1HISTSINI

                var q9 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("SI0102B_V1HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0102B_V1HISTSINI", q9);

                #endregion

                #region M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1

                var q10 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1", q10);

                #endregion

                #region M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1

                var q11 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1", q11);

                #endregion    

                #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q13 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q13);

                #endregion

                #endregion

                var program = new SI0102B();
                program.Execute(SI0102M1_FILE_NAME_P);

                Assert.True(program.W.WABEND.WSQLCODE != 00);
            }
        }

    }
}