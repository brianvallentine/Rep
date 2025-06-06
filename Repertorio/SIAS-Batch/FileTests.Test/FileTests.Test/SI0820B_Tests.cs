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
using static Code.SI0820B;

namespace FileTests.Test
{
    [Collection("SI0820B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0820B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0820B_CURSOR_PRINC

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0AGEN_COD_ESCNEG" , ""},
                { "V0CRED_COD_SUREG" , ""},
                { "V0CRED_COD_AGENCIA" , ""},
                { "V0CRED_CODOPER" , ""},
                { "V0CRED_NUM_CONTRATO" , ""},
                { "V0CRED_CONTRATO_DIGITO" , ""},
                { "V0CRED_DTINIVIG" , ""},
                { "V0CRED_DTTERVIG" , ""},
                { "V0CRED_NUM_APOLICE" , ""},
                { "V0CRED_VAL_PREMIO" , ""},
                { "W_V0CRED_QTD_DIAS_VIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0820B_CURSOR_PRINC", q0);

            #endregion

            #region SI0820B_V0HISTSINI

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0HISTSINI_OPERACAO" , ""},
                { "V0HISTSINI_VAL_OPERACAO" , ""},
                { "V0HISTSINI_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0820B_V0HISTSINI", q1);

            #endregion

            #region M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0SINCRED_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1", q2);

            #endregion

            #region SI0820B_V0RELATORIOS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_RAMO" , ""},
                { "V0RELA_NUM_APOLICE" , ""},
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_CODUSU" , ""},
                { "V0RELA_APOLIDER" , ""},
                { "V0RELA_ENDOSLID" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0820B_V0RELATORIOS", q3);

            #endregion

            #region M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "W_QTD_DIAS_COMP_TERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_MES_REFERENCIA" , ""},
                { "V1SIST_ANO_REFERENCIA" , ""},
                { "V1SIST_DATA_REFERENCIA" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q7);

            #endregion

            #region M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0ESCNEG_REGIAO_ESCNEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "W_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0820B_OUTPUT_202504010000")]
        public static void SI0820B_Tests_Theory(string RSI0820B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RSI0820B_FILE_NAME_P = $"{RSI0820B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region SI0820B_CURSOR_PRINC

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0AGEN_COD_ESCNEG" , ""},
                    { "V0CRED_COD_SUREG" , ""},
                    { "V0CRED_COD_AGENCIA" , ""},
                    { "V0CRED_CODOPER" , ""},
                    { "V0CRED_NUM_CONTRATO" , ""},
                    { "V0CRED_CONTRATO_DIGITO" , ""},
                    { "V0CRED_DTINIVIG" , ""},
                    { "V0CRED_DTTERVIG" , ""},
                    { "V0CRED_NUM_APOLICE" , ""},
                    { "V0CRED_VAL_PREMIO" , ""},
                    { "W_V0CRED_QTD_DIAS_VIGENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0820B_CURSOR_PRINC");
                AppSettings.TestSet.DynamicData.Add("SI0820B_CURSOR_PRINC", q0);

                #endregion

                #region SI0820B_V0HISTSINI

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0HISTSINI_OPERACAO" , ""},
                    { "V0HISTSINI_VAL_OPERACAO" , ""},
                    { "V0HISTSINI_DTMOVTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0820B_V0HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0820B_V0HISTSINI", q1);

                #endregion

                #region M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0SINCRED_NUM_APOL_SINISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1", q2);

                #endregion

                #region SI0820B_V0RELATORIOS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0RELA_RAMO" , ""},
                    { "V0RELA_NUM_APOLICE" , ""},
                    { "V0RELA_PERI_INICIAL" , ""},
                    { "V0RELA_PERI_FINAL" , ""},
                    { "V0RELA_CODUSU" , ""},
                    { "V0RELA_APOLIDER" , ""},
                    { "V0RELA_ENDOSLID" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0820B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0820B_V0RELATORIOS", q3);

                #endregion

                #region M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "W_QTD_DIAS_COMP_TERVIG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPR_NOM_EMP" , "CAIXA VIDA E SEGURIDADE SA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_MES_REFERENCIA" , ""},
                    { "V1SIST_ANO_REFERENCIA" , ""},
                    { "V1SIST_DATA_REFERENCIA" , ""},
                    { "V1SIST_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q7);

                #endregion

                #region M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0ESCNEG_REGIAO_ESCNEG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "W_TIMESTAMP" , ""}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                    { "W_TIMESTAMP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1", q9);

                #endregion

                #endregion
                #endregion
                var program = new SI0820B();
                program.Execute(RSI0820B_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0820B_OUTPUT_202504010000")]
        public static void SI0820B_Tests_Theory_ReturnCode99(string RSI0820B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RSI0820B_FILE_NAME_P = $"{RSI0820B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region SI0820B_CURSOR_PRINC

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0AGEN_COD_ESCNEG" , ""},
                    { "V0CRED_COD_SUREG" , ""},
                    { "V0CRED_COD_AGENCIA" , ""},
                    { "V0CRED_CODOPER" , ""},
                    { "V0CRED_NUM_CONTRATO" , ""},
                    { "V0CRED_CONTRATO_DIGITO" , ""},
                    { "V0CRED_DTINIVIG" , ""},
                    { "V0CRED_DTTERVIG" , ""},
                    { "V0CRED_NUM_APOLICE" , ""},
                    { "V0CRED_VAL_PREMIO" , ""},
                    { "W_V0CRED_QTD_DIAS_VIGENCIA" , ""},
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("SI0820B_CURSOR_PRINC");
                AppSettings.TestSet.DynamicData.Add("SI0820B_CURSOR_PRINC", q0);

                #endregion

                #endregion
                #endregion
                var program = new SI0820B();
                program.Execute(RSI0820B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}