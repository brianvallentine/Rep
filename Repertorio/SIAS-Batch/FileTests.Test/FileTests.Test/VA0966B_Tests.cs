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
using static Code.VA0966B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0966B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0966B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"},
                { "WHOST_DT_HOJE" , "2024-02-02"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0966B_C01_SINISHIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1234567"}
            });
            AppSettings.TestSet.DynamicData.Add("VA0966B_C01_SINISHIS", q1);

            #endregion

            #region VA0966B_SINISHIS1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "12"},
                { "SINISHIS_COD_USUARIO" , "7"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0966B_SINISHIS1", q2);

            #endregion

            #region R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_CERTIFICADO" , "1234"},
                { "SINISMES_IMP_SEGURADA_IX" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "1234567"},
                { "SEGURVGA_COD_SUBGRUPO" , "6"},
                { "SEGURVGA_COD_CLIENTE" , "558"},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "JOSE DA SILVA"},
                { "CLIENTES_CGCCPF" , "12345678988"},
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
                { "FONTES_NOME_FONTE" , "NOME FONTE"}
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_SELECT_FONTES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , "345"},
                { "PRODUTO_DESCR_PRODUTO" , "DESC PRODUTO"},
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

            #region R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1500_00_SELECT_PRODUTO_DB_SELECT_3_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PRODUTO_DB_SELECT_3_Query1", q11);

            #endregion

            #region R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_OPC_COBERTURA" , "12"}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "15.6"}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q13);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_VA0966B.txt")]
        public static void VA0966B_Tests_TheoryFluxoSemSolicitacao(string SAI0966B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0966B_FILE_NAME_P = $"{SAI0966B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0966B_AREA_DE_WORK

                var parameters = new VA0966B_AREA_DE_WORK();
                parameters.SIST_DT_MOV_ABERTO.Value = "2024-10-10";
                parameters.WPAR_PARAMETROS.Value = "M0000000000000000";
                #endregion
                #endregion
                var program = new VA0966B();

                program.Execute(parameters, SAI0966B_FILE_NAME_P);

                //Assert.True(File.Exists(program._SAI0966B.FilePath));
                //Assert.True(new FileInfo(program._SAI0966B.FilePath)?.Length > 0);

                Assert.True((program.AREA_DE_WORK.FILLER_0.WPAR_ROTINA == "M") &&
                            (program.AREA_DE_WORK.FILLER_0.WPAR_INICIO == "00000000") &&
                            (program.AREA_DE_WORK.FILLER_0.WPAR_FIM == "00000000"));

            }
        }
        [Theory]
        [InlineData("Saida_VA0966B.txt")]
        public static void VA0966B_Tests_TheoryErroData(string SAI0966B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0966B_FILE_NAME_P = $"{SAI0966B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0966B_AREA_DE_WORK
                var parameters = new VA0966B_AREA_DE_WORK();
                parameters.SIST_DT_MOV_ABERTO.Value = "2024-10-10";
                parameters.WS_ERRO_DATA.Value = "N";
                parameters.WPAR_PARAMETROS.Value = "M2024101120241032";
                #endregion
                #endregion
                var program = new VA0966B();

                program.Execute(parameters, SAI0966B_FILE_NAME_P);

                //Assert.True(File.Exists(program._SAI0966B.FilePath));
                //Assert.True(new FileInfo(program._SAI0966B.FilePath)?.Length > 0);

                Assert.True((program.RETURN_CODE == "99") &&
                            (program.AREA_DE_WORK.WS_ERRO_DATA == "SIM"));


            }
        }
        [Theory]
        [InlineData("Saida_VA0966B.txt")]
        public static void VA0966B_Tests_Theory_FluxoCoberturaVG_Code00(string SAI0966B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0966B_FILE_NAME_P = $"{SAI0966B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0966B_AREA_DE_WORK
               
                var parameters = new VA0966B_AREA_DE_WORK();
                parameters.SIST_DT_MOV_ABERTO.Value = "2024-10-10";
                parameters.WS_ERRO_DATA.Value = "N";
                parameters.WPAR_PARAMETROS.Value = "M2024101120241020";
                #endregion
                #region R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1
                var q10 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q10);
                q10.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_RAMO" , "93"}
                 });
                #endregion
                #endregion
                var program = new VA0966B();

                program.Execute(parameters, SAI0966B_FILE_NAME_P);

                Assert.True(File.Exists(program._SAI0966B.FilePath));
                Assert.True(new FileInfo(program._SAI0966B.FilePath)?.Length > 0);

                Assert.True((program.RETURN_CODE == "00") &&
                            (program.AREA_DE_WORK.WS_ERRO_DATA == "NAO") &&
                            (program.AREA_DE_WORK.SAI.SAI_COBERTURA == "VG"));


            }
        }
    }
}