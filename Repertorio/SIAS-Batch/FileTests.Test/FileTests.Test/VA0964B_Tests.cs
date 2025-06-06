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
using static Code.VA0964B;

namespace FileTests.Test
{
    [Collection("VA0964B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0964B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DT_HOJE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0964B_C01_SINISHIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0964B_C01_SINISHIS", q1);

            #endregion

            #region VA0964B_SINISHIS1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0964B_SINISHIS1", q2);

            #endregion

            #region R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_IMP_SEGURADA_IX" , ""},
                { "SINISMES_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1450_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_SELECT_FONTES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1500_00_SELECT_PRODUTO_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PRODUTO_DB_SELECT_2_Query1", q9);

            #endregion

            #region R1500_00_SELECT_PRODUTO_DB_SELECT_3_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PRODUTO_DB_SELECT_3_Query1", q10);

            #endregion

            #region R2100_00_SELECT_USUARIOS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q13);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA0964B_SAI0964B.txt")]
        public static void VA0964B_Tests_Theory_ReturnCode_99(string SAI0964B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0964B_FILE_NAME_P = $"{SAI0964B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA0964B();
                program.Execute(SAI0964B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("VA0964B_SAI0964B.txt")]
        public static void VA0964B_Tests_Theory_SemMovimento_ReturnCode_0(string SAI0964B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0964B_FILE_NAME_P = $"{SAI0964B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0964B_C01_SINISHIS

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VA0964B_C01_SINISHIS");
                AppSettings.TestSet.DynamicData.Add("VA0964B_C01_SINISHIS", q1);

                #endregion
                #endregion
                var program = new VA0964B();
                program.Execute(SAI0964B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("VA0964B_SAI0964B.txt")]
        public static void VA0964B_Tests_Theory_ReturnCode_0(string SAI0964B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0964B_FILE_NAME_P = $"{SAI0964B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0964B_C01_SINISHIS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "10019790324"}
                });
                AppSettings.TestSet.DynamicData.Remove("VA0964B_C01_SINISHIS");
                AppSettings.TestSet.DynamicData.Add("VA0964B_C01_SINISHIS", q1);

                #endregion
                #region VA0964B_SINISHIS1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_DATA_MOVIMENTO" , "2004-11-10"},
                { "SINISHIS_VAL_OPERACAO" , "5709.11"},
                { "SINISHIS_COD_USUARIO" , "MENDONCA"},
                { "SINISHIS_NOME_FAVORECIDO" , "CEF-SUSAD/ARQUIVO/RJ                    "},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0964B_SINISHIS1");
                AppSettings.TestSet.DynamicData.Add("VA0964B_SINISHIS1", q2);

                #endregion
                #region R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "1000"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q13);

                #endregion
                #endregion
                var program = new VA0964B();
                program.Execute(SAI0964B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.W77_VAL_IN_TOTAL == 1000);
            }
        }
    }
}