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
using Dclgens;
using Code;
using static Code.SI9107B;

namespace FileTests.Test
{
    [Collection("SI9107B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9107B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI9107B_C01_SIARDEVC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9107B_C01_SIARDEVC", q2);

            #endregion

            #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1400_00_LE_SINISCAU_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_LE_SINISCAU_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , ""},
                { "HOST_NUM_EXPEDIENTE_VC" , ""},
                { "HOST_COD_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_OCORR_HISTORICO" , ""},
                { "SINIMPSE_VAL_IS_DATA_OCORR" , ""},
                { "SINIMPSE_DATA_OCORRENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SINIMPSE_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SINIMPSE_OCORR_HISTORICO" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "SINIMPSE_VAL_IS_DATA_OCORR" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SINIMPSE_DATA_OCORRENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , ""},
                { "IND_COD_ERRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q13);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI9107B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                SI1032S_Tests.Load_Parameters();
                SI1000S_Tests.Load_Parameters();
                #region PARAMETERS

                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                q100.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                q100.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", q100);

                #endregion

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                q110.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                q110.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q110);

                #endregion

                #region R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1

                var q210 = new DynamicData();
                q210.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                q210.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                q210.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1", q210);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var q310 = new DynamicData();
                q310.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                q310.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                q310.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", q310);

                #endregion

                #region R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1

                var q410 = new DynamicData();
                q410.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                q410.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                q410.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1", q410);

                #endregion

                #region R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1

                var q510 = new DynamicData();
                q510.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                q510.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                q510.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1", q510);

                #endregion

                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region PARAMETERS

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2020-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI9107B_C01_SIARDEVC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "file1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
                { "SIARDEVC_TIPO_REGISTRO" , "A" },
                { "SIARDEVC_SEQ_REGISTRO" , "100" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "1234" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "0" },
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "EXP123456" },
                { "SIARDEVC_COD_OPERACAO" , "805" },
                { "SIARDEVC_NUM_APOLICE" , "AP654321" },
                { "SIARDEVC_NUM_ENDOSSO" , "END123456" },
                { "SIARDEVC_NUM_ITEM" , "10" },
                { "SIARDEVC_COD_RAMO" , "15" },
                { "SIARDEVC_COD_COBERTURA" , "10" },
                { "SIARDEVC_COD_CAUSA" , "3" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-11-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9107B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9107B_C01_SIARDEVC", q2);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , "Active" },
                { "SINISMES_RAMO" , "General" },
                { "SINISMES_COD_CAUSA" , "C123" },
                { "SINISMES_COD_FONTE" , "F123" },
                { "SINISMES_COD_PRODUTO" , "P123" },
                { "SINISMES_OCORR_HISTORICO" , "Incident occurred" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "5" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "5" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1400_00_LE_SINISCAU_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , "Group1" }
            });
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , "Group1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_LE_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_LE_SINISCAU_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , "0" },
                { "HOST_NUM_EXPEDIENTE_VC" , "EXP654321" },
                { "HOST_COD_COBERTURA" , "10" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "1234" },
                { "SINISMES_OCORR_HISTORICO" , "Incident occurred" },
                { "SINISHIS_COD_OPERACAO" , "150" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SINISHIS_NOME_FAVORECIDO" , "John Doe" },
                { "SINISHIS_VAL_OPERACAO" , "1000.0" },
                { "SINISHIS_TIPO_FAVORECIDO" , "Individual" },
                { "SINISMES_COD_FONTE" , "F123" },
                { "SINISHIS_SIT_CONTABIL" , "Balanced" },
                { "SINISHIS_SIT_REGISTRO" , "Registered" },
                { "SIARDEVC_NUM_APOLICE" , "AP654321" },
                { "SINISMES_COD_PRODUTO" , "P123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_OCORR_HISTORICO" , "Incident detailed" },
                { "SINIMPSE_VAL_IS_DATA_OCORR" , "True" },
                { "SINIMPSE_DATA_OCORRENCIA" , "2023-11-02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123" },
                { "SINIMPSE_OCORR_HISTORICO" , "Incident detailed" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1", q10);

                #endregion

                #region R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123" },
                { "SINIMPSE_OCORR_HISTORICO" , "Incident detailed" },
                { "SIARDEVC_COD_CAUSA" , "3" },
                { "SINIMPSE_VAL_IS_DATA_OCORR" , "True" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SINIMPSE_DATA_OCORRENCIA" , "2023-11-02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , "Incident occurred" },
                { "SINISMES_COD_CAUSA" , "C123" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , "0" },
                { "IND_COD_ERRO" , "0" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "Processed" },
                { "SIARDEVC_OCORR_HISTORICO" , "Processing completed" },
                { "SIARDEVC_TIPO_REGISTRO" , "A" },
                { "SIARDEVC_SEQ_REGISTRO" , "100" },
                { "SIARDEVC_NOM_ARQUIVO" , "file1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q13);

                #endregion
            
                #endregion

                var program = new SI9107B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);


            }
        }

        [Fact]
        public static void SI9107B_Tests99_Fact()
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



                #region PARAMETERS

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

                var q1 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI9107B_C01_SIARDEVC

                var q2 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("SI9107B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9107B_C01_SIARDEVC", q2);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1400_00_LE_SINISCAU_DB_SELECT_1_Query1

                var q6 = new DynamicData();              
                
                AppSettings.TestSet.DynamicData.Remove("R1400_00_LE_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_LE_SINISCAU_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , "0" },
                { "HOST_NUM_EXPEDIENTE_VC" , "EXP654321" },
                { "HOST_COD_COBERTURA" , "10" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123" },
                { "SINISMES_OCORR_HISTORICO" , "Incident occurred" },
                { "SINISHIS_COD_OPERACAO" , "150" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SINISHIS_NOME_FAVORECIDO" , "John Doe" },
                { "SINISHIS_VAL_OPERACAO" , "1000.0" },
                { "SINISHIS_TIPO_FAVORECIDO" , "Individual" },
                { "SINISMES_COD_FONTE" , "F123" },
                { "SINISHIS_SIT_CONTABIL" , "Balanced" },
                { "SINISHIS_SIT_REGISTRO" , "Registered" },
                { "SIARDEVC_NUM_APOLICE" , "AP654321" },
                { "SINISMES_COD_PRODUTO" , "P123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_OCORR_HISTORICO" , "Incident detailed" },
                { "SINIMPSE_VAL_IS_DATA_OCORR" , "True" },
                { "SINIMPSE_DATA_OCORRENCIA" , "2023-11-02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123" },
                { "SINIMPSE_OCORR_HISTORICO" , "Incident detailed" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1", q10);

                #endregion

                #region R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123" },
                { "SINIMPSE_OCORR_HISTORICO" , "Incident detailed" },
                { "SIARDEVC_COD_CAUSA" , "3" },
                { "SINIMPSE_VAL_IS_DATA_OCORR" , "True" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SINIMPSE_DATA_OCORRENCIA" , "2023-11-02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , "Incident occurred" },
                { "SINISMES_COD_CAUSA" , "C123" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "233" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , "0" },
                { "IND_COD_ERRO" , "0" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "Processed" },
                { "SIARDEVC_OCORR_HISTORICO" , "Processing completed" },
                { "SIARDEVC_TIPO_REGISTRO" , "A" },
                { "SIARDEVC_SEQ_REGISTRO" , "100" },
                { "SIARDEVC_NOM_ARQUIVO" , "file1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q13);

                #endregion

                #endregion


                #endregion
                var program = new SI9107B();
                program.Execute();

              
                Assert.True(program.RETURN_CODE ==99);


            }
        }


    }
}