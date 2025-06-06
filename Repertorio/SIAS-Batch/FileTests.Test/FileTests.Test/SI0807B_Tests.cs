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
using static Code.SI0807B;

namespace FileTests.Test
{
    [Collection("SI0807B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0807B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0MOED_SIGLUNIM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1", q2);

            #endregion

            #region M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1SEGU_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1", q6);

            #endregion

            #region SI0807B_V1RELATORIOS

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_RAMO" , ""},
                { "V1RELA_NUM_APOL" , ""},
                { "V1RELA_CODUNIMO" , ""},
                { "V1RELA_PERI_INI" , ""},
                { "V1RELA_PERI_FIM" , ""},
                { "V1RELA_CODUSU" , ""},
                { "V1RELA_DT_SOLICITA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0807B_V1RELATORIOS", q7);

            #endregion

            #region SI0807B_V0MESTSINI

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_NUM_APOL" , ""},
                { "V0MEST_RAMO" , ""},
                { "V0MEST_NUM_APOL_SINI" , ""},
                { "V0MEST_NRCERTIF" , ""},
                { "V0MEST_SITUACAO" , ""},
                { "V0MEST_DATCMD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0807B_V0MESTSINI", q8);

            #endregion

            #region M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "W_COUNT_V0HISTSINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0807B_1")]
        public static void SI0807B_Tests_Theory(string RSI0807B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RSI0807B_FILE_NAME_P = $"{RSI0807B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                SI1003S_Tests.Load_Parameters();
                SI1000S_Tests.Load_Parameters();
                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", q100);

                #endregion

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var q101 = new DynamicData();
                q101.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "101100000001"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q101);

                #endregion

                #region R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1

                var q103 = new DynamicData();
                q103.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1", q103);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var q104 = new DynamicData();
                q104.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", q104);

                #endregion

                #region R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1

                var q105 = new DynamicData();
                q105.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "110"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1", q105);

                #endregion

                #region R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1

                var q106 = new DynamicData();
                q106.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "120"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1", q106);

                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2020-01-01"},
                { "V1SIST_DTCURRENT" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0MOED_SIGLUNIM" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1", q2);

                #endregion

                #region M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_CODCLIEN" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1SEGU_CODCLIEN" , "97"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_NOME" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1", q6);

                #endregion

                #region SI0807B_V1RELATORIOS

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_RAMO" , "x"},
                { "V1RELA_NUM_APOL" , "x"},
                { "V1RELA_CODUNIMO" , "1"},
                { "V1RELA_PERI_INI" , "2020-01-01"},
                { "V1RELA_PERI_FIM" ,  "2020-01-01"},
                { "V1RELA_CODUSU" , "3"},
                { "V1RELA_DT_SOLICITA" ,  "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0807B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0807B_V1RELATORIOS", q7);

                #endregion

                #region SI0807B_V0MESTSINI

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_NUM_APOL" , "123456"},
                { "V0MEST_RAMO" , "97"},
                { "V0MEST_NUM_APOL_SINI" , "123456"},
                { "V0MEST_NRCERTIF" , "123456"},
                { "V0MEST_SITUACAO" , "x"},
                { "V0MEST_DATCMD" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0807B_V0MESTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0807B_V0MESTSINI", q8);

                #endregion

                #region M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "W_COUNT_V0HISTSINI" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q9);

                #endregion


                #endregion
                var program = new SI0807B();
                
               
                program.Execute(RSI0807B_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList3);

                //V0MEST_RAMO == 0
                // var envList4 = AppSettings.TestSet.DynamicData["M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList4);

                //V0MEST_RAMO == 97
                //var envList5 = AppSettings.TestSet.DynamicData["M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList5);

                //var envList6 = AppSettings.TestSet.DynamicData["M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1"].DynamicList;
               // Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["SI0807B_V1RELATORIOS"].DynamicList;
                Assert.Empty(envList8);

                var envList9 = AppSettings.TestSet.DynamicData["SI0807B_V0MESTSINI"].DynamicList;
                Assert.Empty(envList9);

                var envList10 = AppSettings.TestSet.DynamicData["M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList10);


                Assert.True(program.RETURN_CODE == 00);

            }
        }

        [Theory]
        [InlineData("SI0807B_2")]
        public static void SI0807B_Tests99_Theory(string RSI0807B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RSI0807B_FILE_NAME_P = $"{RSI0807B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1", q0);
                #endregion

                #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1", q2);

                #endregion

                #region M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1", q6);

                #endregion

                #region SI0807B_V1RELATORIOS

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                //{ "V1RELA_RAMO" , "x"},
                { "V1RELA_NUM_APOL" , null},
                { "V1RELA_CODUNIMO" , null},
                { "V1RELA_PERI_INI" , null},
                { "V1RELA_PERI_FIM" , null},
                //{ "V1RELA_CODUSU" ,null},
                { "V1RELA_DT_SOLICITA" ,  null},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0807B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0807B_V1RELATORIOS", q7);

                #endregion

                #region SI0807B_V0MESTSINI

                var q8 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("SI0807B_V0MESTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0807B_V0MESTSINI", q8);

                #endregion

                #region M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q9);

                #endregion


                #endregion
                var program = new SI0807B();
                program.Execute(RSI0807B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE != 00);

            }
        }


    }
}