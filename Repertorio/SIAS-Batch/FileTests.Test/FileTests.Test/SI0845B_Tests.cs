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
using static Code.SI0845B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0845B_Tests")]
    public class SI0845B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_CODRELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q3);

            #endregion

            #region SI0845B_SINISTRO

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_NUM_APOL" , ""},
                { "V1HSIN_DTMOVTO" , ""},
                { "V1HSIN_NUM_SINI" , ""},
                { "V1MSIN_RAMO" , ""},
                { "V1MSIN_FONTE" , ""},
                { "V1MSIN_CODCAU" , ""},
                { "V1HSIN_VAL_OPERACAO" , ""},
                { "V1HSIN_CODUSU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0845B_SINISTRO", q4);

            #endregion

            #region R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1SCAU_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0845B_t1")]
        public static void SI0845B_Tests_Theory(string RSI0845B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RSI0845B_FILE_NAME_P = $"{RSI0845B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , "2025-01-01"},
                    { "V1SIST_DTCURRENT" , "2025-04-03"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1RELA_CODRELAT" , "1"},
                    { "V1RELA_MES_REFER" , "1"},
                    { "V1RELA_ANO_REFER" , "2025"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPR_NOM_EMP" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1RELA_CODRELAT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q3);

                #endregion

                #region SI0845B_SINISTRO

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V1MSIN_NUM_APOL" , "1"},
                    { "V1HSIN_DTMOVTO" , "2025-04-01"},
                    { "V1HSIN_NUM_SINI" , "1"},
                    { "V1MSIN_RAMO" , "1"},
                    { "V1MSIN_FONTE" , "1"},
                    { "V1MSIN_CODCAU" , "1"},
                    { "V1HSIN_VAL_OPERACAO" , "1"},
                    { "V1HSIN_CODUSU" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0845B_SINISTRO");
                AppSettings.TestSet.DynamicData.Add("SI0845B_SINISTRO", q4);

                #endregion

                #region R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1RAMO_NOMERAMO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1SCAU_DESCAU" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1APOL_NOME" , "Teste"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new SI0845B();
                program.Execute(RSI0845B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0845B_t2")]
        public static void SI0845B_Tests_Theory_Return99(string RSI0845B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RSI0845B_FILE_NAME_P = $"{RSI0845B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1RELA_CODRELAT" , ""},
                    { "V1RELA_MES_REFER" , ""},
                    { "V1RELA_ANO_REFER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPR_NOM_EMP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1RELA_CODRELAT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q3);

                #endregion

                #region SI0845B_SINISTRO

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V1MSIN_NUM_APOL" , ""},
                    { "V1HSIN_DTMOVTO" , ""},
                    { "V1HSIN_NUM_SINI" , ""},
                    { "V1MSIN_RAMO" , ""},
                    { "V1MSIN_FONTE" , ""},
                    { "V1MSIN_CODCAU" , ""},
                    { "V1HSIN_VAL_OPERACAO" , ""},
                    { "V1HSIN_CODUSU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0845B_SINISTRO");
                AppSettings.TestSet.DynamicData.Add("SI0845B_SINISTRO", q4);

                #endregion

                #region R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1RAMO_NOMERAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1SCAU_DESCAU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1APOL_NOME" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new SI0845B();
                program.Execute(RSI0845B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}