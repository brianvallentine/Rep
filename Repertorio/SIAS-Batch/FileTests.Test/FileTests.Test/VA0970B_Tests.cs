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
using static Code.VA0970B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0970B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0970B_Tests
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
                { "WHOST_CURRENT_DATE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0970B_C01_SINISHIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "456987"}
            });
            AppSettings.TestSet.DynamicData.Add("VA0970B_C01_SINISHIS", q1);

            #endregion

            #region VA0970B_SINISHIS1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "2"},
                { "SINISHIS_VAL_OPERACAO" , "100"},
                { "SINISHIS_NOME_FAVORECIDO" , "ANTONIO OLIVEIRA"},
                { "SINISHIS_OCORR_HISTORICO" , "HISTORICO DA OPERACAO"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0970B_SINISHIS1", q2);

            #endregion

            #region R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_CERTIFICADO" , "998877"},
                { "SINISMES_NUM_APOLICE" , "1122"},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , "753"},
                { "SEGURVGA_NUM_APOLICE" , "321"},
                { "SEGURVGA_COD_CLIENTE" , "12"},
                { "SEGURVGA_COD_SUBGRUPO" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "FOURSYS SA"},
                { "CLIENTES_CGCCPF" , "1234567890001"},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "400"}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MAX_OCORR" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1600_00_SELECT_SI175_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SI175_NUM_APOL_SINISTRO" , "9658"},
                { "SI175_OCORR_HISTORICO" , "1"},
                { "SI175_COD_OPERACAO" , "3"},
                { "SI175_NUM_OCORR_MOVTO" , "44"},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_SI175_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1700_00_SELECT_GE368_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GE368_IND_ENTIDADE" , "2"},
                { "GE368_NUM_PESSOA" , "76"},
                { "GE368_SEQ_ENTIDADE" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_GE368_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1800_00_SELECT_OD009_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OD009_COD_BANCO" , "237"},
                { "OD009_COD_AGENCIA" , "0001"},
                { "OD009_NUM_OPERACAO_CONTA" , "2"},
                { "OD009_NUM_CONTA" , "1454100"},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_OD009_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1850_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO" , "7"},
                { "PRODUVG_NOME_PRODUTO" , "PRODUTO ABC"},
            });
            AppSettings.TestSet.DynamicData.Add("R1850_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PRODUVG_NOME_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1", q13);

            #endregion

            #region R2050_00_SELECT_OD002_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "OD002_NUM_CPF" , "123456789"}
            });
            AppSettings.TestSet.DynamicData.Add("R2050_00_SELECT_OD002_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "200"}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "300"}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "400"}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q17);

            #endregion

            #region R2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R2600_00_SELECT_GE369_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "OD009_COD_BANCO" , "246"},
                { "OD009_COD_AGENCIA" , "1"},
                { "OD009_NUM_OPERACAO_CONTA" , "4"},
                { "OD009_NUM_CONTA" , "1659658"},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_SELECT_GE369_DB_SELECT_1_Query1", q19);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("WPAR_PARAMETROS_P", "Saida_VA0970B.txt")]
        public static void VA0970B_Tests_Theory_FluxoSemSolicitacao(string WPAR_PARAMETROS_P, string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WPAR_PARAMETROS_P = $"{WPAR_PARAMETROS_P}_{timestamp}.txt";
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
                #region WPAR_PARAMETROS
                var param = new VA0970B_AREA_DE_WORK();
                param.FILLER_7.WPAR_ROTINA.Value = "M";
                param.FILLER_7.WPAR_INICIO.Value = "00000000";
                param.FILLER_7.WPAR_FIM.Value = "00000000";
                //param= "M0000000000000000";
                #endregion
                #endregion
                var program = new VA0970B();
                program.Execute(param, ARQSAIDA_FILE_NAME_P);

                //Assert.True(File.Exists(program.ARQSAIDA.FilePath));
                //Assert.True(new FileInfo(program.ARQSAIDA.FilePath)?.Length >= 0);
                Assert.True(program.AREA_DE_WORK.FILLER_7.WPAR_ROTINA == "M" &&
                            program.AREA_DE_WORK.FILLER_7.WPAR_INICIO == "00000000" &&
                            program.AREA_DE_WORK.FILLER_7.WPAR_FIM == "00000000" &&
                            program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("WPAR_PARAMETROS_P", "Saida_VA0970B.txt")]
        public static void VA0970B_Tests_Theory_FluxoProblemaData_ReturnCode_99(string WPAR_PARAMETROS_P, string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WPAR_PARAMETROS_P = $"{WPAR_PARAMETROS_P}_{timestamp}.txt";
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
                #region WPAR_PARAMETROS
                var param = new VA0970B_AREA_DE_WORK();
                param.FILLER_7.WPAR_ROTINA.Value = "M";
                param.FILLER_7.WPAR_INICIO.Value = "20240931";
                param.FILLER_7.WPAR_FIM.Value = "20241131";
                //param.Value = "M2024093120241131";
                #endregion
                #endregion
                var program = new VA0970B();
                program.Execute(param, ARQSAIDA_FILE_NAME_P);

                Assert.True(program.AREA_DE_WORK.WS_ERRO_DATA == "SIM" &&
                            program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("WPAR_PARAMETROS_P", "Saida_VA0970B.txt")]
        public static void VA0970B_Tests_Theory_Fluxo_CodOper_1184_Valor_3000_ReturnCode_00(string WPAR_PARAMETROS_P, string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WPAR_PARAMETROS_P = $"{WPAR_PARAMETROS_P}_{timestamp}.txt";
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
                #region WPAR_PARAMETROS
                var param = new VA0970B_AREA_DE_WORK();
                param.FILLER_7.WPAR_ROTINA.Value = "M";
                param.FILLER_7.WPAR_INICIO.Value = "20240931";
                param.FILLER_7.WPAR_FIM.Value = "20241025";
                //param.Value = "M2024093120241025";
                #endregion

                #region VA0970B_SINISHIS1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1184"},
                { "SINISHIS_VAL_OPERACAO" , "152"},
                { "SINISHIS_NOME_FAVORECIDO" , "ANTONIO OLIVEIRA"},
                { "SINISHIS_OCORR_HISTORICO" , "HISTORICO DA OPERACAO"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0970B_SINISHIS1");
                AppSettings.TestSet.DynamicData.Add("VA0970B_SINISHIS1", q2);

                #endregion

                #region R2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1
                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "3000"}
                }); ;
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q18);

                #endregion

                #endregion
                var program = new VA0970B();
                program.Execute(param, ARQSAIDA_FILE_NAME_P);

                Assert.True(File.Exists(program.ARQSAIDA.FilePath));
                Assert.True(new FileInfo(program.ARQSAIDA.FilePath)?.Length >= 0);
                Assert.True(program.WHOST_VAL_PAG_COMP_TOT == 3000 &&
                            program.RETURN_CODE == 00);
            }
        }
    }
}