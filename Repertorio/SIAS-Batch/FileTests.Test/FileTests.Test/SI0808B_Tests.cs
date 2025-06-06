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
using static Code.SI0808B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0808B_Tests")]
    public class SI0808B_Tests
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

            #region SI0808B_V1RELATORIOS

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_RAMO" , ""},
                { "V1RELA_NUM_APOLICE" , ""},
                { "V1RELA_CODUNIMO" , ""},
                { "V1RELA_PERI_INI" , ""},
                { "V1RELA_PERI_FIM" , ""},
                { "V1RELA_CODUSU" , ""},
                { "V1RELA_DT_SOLICITA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0808B_V1RELATORIOS", q7);

            #endregion

            #region SI0808B_JOIN_HIST_MEST

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_NUM_APOLICE" , ""},
                { "V0MEST_NUM_APOL_SINI" , ""},
                { "V0MEST_RAMO" , ""},
                { "V0MEST_NRCERTIF" , ""},
                { "V0MEST_SITUACAO" , ""},
                { "V0MEST_DATCMD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0808B_JOIN_HIST_MEST", q8);

            #endregion

            #region SI0808B_ANT

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""},
                { "V0HIST_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0808B_ANT", q9);

            #endregion

            #region SI0808B_PERI

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""},
                { "V0HIST_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0808B_PERI", q10);

            #endregion

            #region M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0808B_t1")]
        public static void SI0808B_Tests_Theory_Erro99(string RSI0808B_FILE_NAME_P)
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
                #region SI0808B_V1RELATORIOS

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_RAMO" , ""},
                { "V1RELA_NUM_APOLICE" , ""},
                { "V1RELA_CODUNIMO" , ""},
                { "V1RELA_PERI_INI" , ""},
                { "V1RELA_PERI_FIM" , ""},
                { "V1RELA_CODUSU" , ""},
                { "V1RELA_DT_SOLICITA" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("SI0808B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0808B_V1RELATORIOS", q7);

                #endregion
                #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1");

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA"}
            });
                AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new SI0808B();
                program.Execute(RSI0808B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0808B_t2")]
        public static void SI0808B_Tests_Theory(string RSI0808B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                SI1003S_Tests.Load_Parameters();
                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1", q6);

                #endregion
                #region SI0808B_JOIN_HIST_MEST

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_NUM_APOLICE" , "100"},
                { "V0MEST_NUM_APOL_SINI" , "200"},
                { "V0MEST_RAMO" , ""},
                { "V0MEST_NRCERTIF" , ""},
                { "V0MEST_SITUACAO" , ""},
                { "V0MEST_DATCMD" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0808B_JOIN_HIST_MEST");
                AppSettings.TestSet.DynamicData.Add("SI0808B_JOIN_HIST_MEST", q8);

                #endregion
                #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1");

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA"}
            });
                AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new SI0808B();
                program.Execute(RSI0808B_FILE_NAME_P);

                //M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1"].DynamicList);

                //M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1"].DynamicList);

                //M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1"].DynamicList);

                //M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1"].DynamicList);

                //M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}