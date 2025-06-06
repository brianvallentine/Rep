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
using static Code.SI0848B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0848B_Tests")]
    public class SI0848B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region Execute_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELAT_MES_REFERENCIA" , ""},
                { "V0RELAT_ANO_REFERENCIA" , ""},
                { "V0RELAT_PERI_INICIAL" , ""},
                { "V0RELAT_PERI_FINAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q1);

            #endregion

            #region R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1", q2);

            #endregion

            #region SI0848B_V0SINISTROS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0SINI_HABIT01_NOME_SEGURADO" , ""},
                { "V0MEST_NUM_APOL_SINISTRO" , ""},
                { "V0MEST_NUM_APOLICE" , ""},
                { "V0HIST_VAL_OPERACAO" , ""},
                { "V0HIST_DTMOVTO" , ""},
                { "V0MEST_CODPRODU" , ""},
                { "V0SINI_HABIT01_OPERACAO" , ""},
                { "V0SINI_HABIT01_PONTO_VENDA" , ""},
                { "V0SINI_HABIT01_NUM_CONTRATO" , ""},
                { "V0SINI_HABIT01_COD_COBERTURA" , ""},
                { "V0SINI_HABIT01_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0848B_V0SINISTROS", q3);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0848B_t1")]
        public static void SI0848B_Tests_Theory(string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region Execute_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0RELAT_MES_REFERENCIA" , ""},
                    { "V0RELAT_ANO_REFERENCIA" , ""},
                    { "V0RELAT_PERI_INICIAL" , ""},
                    { "V0RELAT_PERI_FINAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q1);

                #endregion

                #region R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1", q2);

                #endregion

                #region SI0848B_V0SINISTROS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0SINI_HABIT01_NOME_SEGURADO" , ""},
                    { "V0MEST_NUM_APOL_SINISTRO" , ""},
                    { "V0MEST_NUM_APOLICE" , ""},
                    { "V0HIST_VAL_OPERACAO" , ""},
                    { "V0HIST_DTMOVTO" , ""},
                    { "V0MEST_CODPRODU" , ""},
                    { "V0SINI_HABIT01_OPERACAO" , ""},
                    { "V0SINI_HABIT01_PONTO_VENDA" , ""},
                    { "V0SINI_HABIT01_NUM_CONTRATO" , ""},
                    { "V0SINI_HABIT01_COD_COBERTURA" , ""},
                    { "V0SINI_HABIT01_CGCCPF" , ""},
                });

                AppSettings.TestSet.DynamicData.Remove("SI0848B_V0SINISTROS");
                AppSettings.TestSet.DynamicData.Add("SI0848B_V0SINISTROS", q3);

                #endregion

                #endregion
                var program = new SI0848B();
                program.Execute(ARQSAIDA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0848B_t2")]
        public static void SI0848B_Tests_Theory_Return99(string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region Execute_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{

                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q1);

                #endregion

                #region R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1", q2);

                #endregion

                #region SI0848B_V0SINISTROS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0SINI_HABIT01_NOME_SEGURADO" , ""},
                    { "V0MEST_NUM_APOL_SINISTRO" , ""},
                    { "V0MEST_NUM_APOLICE" , ""},
                    { "V0HIST_VAL_OPERACAO" , ""},
                    { "V0HIST_DTMOVTO" , ""},
                    { "V0MEST_CODPRODU" , ""},
                    { "V0SINI_HABIT01_OPERACAO" , ""},
                    { "V0SINI_HABIT01_PONTO_VENDA" , ""},
                    { "V0SINI_HABIT01_NUM_CONTRATO" , ""},
                    { "V0SINI_HABIT01_COD_COBERTURA" , ""},
                    { "V0SINI_HABIT01_CGCCPF" , ""},
                });

                AppSettings.TestSet.DynamicData.Remove("SI0848B_V0SINISTROS");
                AppSettings.TestSet.DynamicData.Add("SI0848B_V0SINISTROS", q3);

                #endregion

                #endregion
                var program = new SI0848B();
                program.Execute(ARQSAIDA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}