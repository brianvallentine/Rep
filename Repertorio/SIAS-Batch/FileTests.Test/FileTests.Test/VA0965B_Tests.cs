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
using static Code.VA0965B;

namespace FileTests.Test
{
    [Collection("VA0965B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0965B_Tests
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

            #region VA0965B_C01_SINISHIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0965B_C01_SINISHIS", q1);

            #endregion

            #region VA0965B_SINISHIS1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0965B_SINISHIS1", q2);

            #endregion

            #region R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_NUM_APOLICE" , ""},
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

            #region R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MAX_OCORR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1600_00_SELECT_SI175_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SI175_NUM_APOL_SINISTRO" , ""},
                { "SI175_OCORR_HISTORICO" , ""},
                { "SI175_COD_OPERACAO" , ""},
                { "SI175_NUM_OCORR_MOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_SI175_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1700_00_SELECT_GE368_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "GE368_IND_ENTIDADE" , ""},
                { "GE368_NUM_PESSOA" , ""},
                { "GE368_SEQ_ENTIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_GE368_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1800_00_SELECT_OD009_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "OD009_COD_BANCO" , ""},
                { "OD009_COD_AGENCIA" , ""},
                { "OD009_NUM_OPERACAO_CONTA" , ""},
                { "OD009_NUM_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_OD009_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2200_00_SELECT_SI155_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SI155_VLR_CORRECAO" , ""},
                { "SI155_VLR_MULTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SI155_DB_SELECT_1_Query1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQSAIDA_FILE_NAME_P")]
        public static void VA0965B_Tests_Theory(string ARQSAIDA_FILE_NAME_P)
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

                #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "WHOST_CURRENT_DATE" , "2025-03-10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0965B_C01_SINISHIS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "107700000001"}
                });
                AppSettings.TestSet.DynamicData.Remove("VA0965B_C01_SINISHIS");
                AppSettings.TestSet.DynamicData.Add("VA0965B_C01_SINISHIS", q1);

                #endregion

                #region VA0965B_SINISHIS1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "100"},
                { "SINISHIS_NOME_FAVORECIDO" , "XXX"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0965B_SINISHIS1");
                AppSettings.TestSet.DynamicData.Add("VA0965B_SINISHIS1", q2);

                #endregion

                #region R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_CERTIFICADO" , "10020080465"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , "123456"},
                { "SEGURVGA_NUM_APOLICE" , "123456"},
                { "SEGURVGA_COD_CLIENTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A"},
                { "CLIENTES_CGCCPF" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "50000.00"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MAX_OCORR" , "32767"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1600_00_SELECT_SI175_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SI175_NUM_APOL_SINISTRO" , "109300077301"},
                { "SI175_OCORR_HISTORICO" , "7"},
                { "SI175_COD_OPERACAO" , "1184"},
                { "SI175_NUM_OCORR_MOVTO" , "112"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_SI175_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_SI175_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1700_00_SELECT_GE368_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "GE368_IND_ENTIDADE" , "1"},
                { "GE368_NUM_PESSOA" , "2"},
                { "GE368_SEQ_ENTIDADE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_GE368_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_GE368_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1800_00_SELECT_OD009_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "OD009_COD_BANCO" , "104"},
                { "OD009_COD_AGENCIA" , "630"},
                { "OD009_NUM_OPERACAO_CONTA" , "3"},
                { "OD009_NUM_CONTA" , "317"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_OD009_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_OD009_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "401086240105.46"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2200_00_SELECT_SI155_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SI155_VLR_CORRECAO" , "100"},
                { "SI155_VLR_MULTA" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_SI155_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SI155_DB_SELECT_1_Query1", q12);

                #endregion
               
                #endregion

                var program = new VA0965B();

                VA0965B_AREA_DE_WORK obj = new VA0965B_AREA_DE_WORK();
                obj.WPAR_PARAMETROS.Value = "M2021010120250101";

                program.Execute(obj, ARQSAIDA_FILE_NAME_P);
                //program.Execute(new VA0965B_AREA_DE_WORK(), ARQSAIDA_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["VA0965B_C01_SINISHIS"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["VA0965B_SINISHIS1"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList8);

                var envList9 = AppSettings.TestSet.DynamicData["R1600_00_SELECT_SI175_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);

                var envList10 = AppSettings.TestSet.DynamicData["R1700_00_SELECT_GE368_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList10);

                var envList11 = AppSettings.TestSet.DynamicData["R1800_00_SELECT_OD009_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList11);

                var envList12 = AppSettings.TestSet.DynamicData["R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList12);

                var envList13 = AppSettings.TestSet.DynamicData["R2200_00_SELECT_SI155_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList13);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("ARQSAIDA_FILE_NAME_P")]
        public static void VA0965B_Tests99_Theory(string ARQSAIDA_FILE_NAME_P)
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

                #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "WHOST_CURRENT_DATE" , "2025-03-10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0965B_C01_SINISHIS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "107700000001"}
                });
                AppSettings.TestSet.DynamicData.Remove("VA0965B_C01_SINISHIS");
                AppSettings.TestSet.DynamicData.Add("VA0965B_C01_SINISHIS", q1);

                #endregion

                #region VA0965B_SINISHIS1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "100"},
                { "SINISHIS_NOME_FAVORECIDO" , "XXX"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0965B_SINISHIS1");
                AppSettings.TestSet.DynamicData.Add("VA0965B_SINISHIS1", q2);

                #endregion

                #region R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_CERTIFICADO" , "10020080465"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , "123456"},
                { "SEGURVGA_NUM_APOLICE" , "123456"},
                { "SEGURVGA_COD_CLIENTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A"},
                { "CLIENTES_CGCCPF" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "50000.00"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MAX_OCORR" , "32767"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1600_00_SELECT_SI175_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SI175_NUM_APOL_SINISTRO" , "109300077301"},
                { "SI175_OCORR_HISTORICO" , "7"},
                { "SI175_COD_OPERACAO" , "1184"},
                { "SI175_NUM_OCORR_MOVTO" , "112"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_SI175_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_SI175_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1700_00_SELECT_GE368_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "GE368_IND_ENTIDADE" , "1"},
                { "GE368_NUM_PESSOA" , "2"},
                { "GE368_SEQ_ENTIDADE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_GE368_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_GE368_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1800_00_SELECT_OD009_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "OD009_COD_BANCO" , "104"},
                { "OD009_COD_AGENCIA" , "630"},
                { "OD009_NUM_OPERACAO_CONTA" , "3"},
                { "OD009_NUM_CONTA" , "317"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_OD009_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_OD009_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "401086240105.46"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2200_00_SELECT_SI155_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SI155_VLR_CORRECAO" , "100"},
                { "SI155_VLR_MULTA" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_SI155_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SI155_DB_SELECT_1_Query1", q12);

                #endregion

                #endregion

                var program = new VA0965B();

                VA0965B_AREA_DE_WORK obj = new VA0965B_AREA_DE_WORK();
                obj.WPAR_PARAMETROS.Value = "S2021010120250101";

                program.Execute(obj, ARQSAIDA_FILE_NAME_P);
                //program.Execute(new VA0965B_AREA_DE_WORK(), ARQSAIDA_FILE_NAME_P);

              

                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}