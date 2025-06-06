using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.SI9101B;

namespace FileTests.Test
{
    [Collection("SI9101B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9101B_Tests
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

            #region SI9101B_C01_SIARDEVC

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_DATA_COMUNICADO" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
                { "SIARDEVC_NUM_ITEM1" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9101B_C01_SIARDEVC", q1);

            #endregion

            #region SI9101B_C01_APOLIAUT

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_NUM_ITEM" , ""},
                { "APOLIAUT_NUM_ENDOSSO" , ""},
                { "APOLIAUT_DATA_INIVIGENCIA" , ""},
                { "APOLIAUT_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9101B_C01_APOLIAUT", q2);

            #endregion

            #region R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "AUTOCOBE_IMP_SEGURADA_IX" , ""},
                { "AUTOCOBE_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "AUTOCOBE_IMP_SEGURADA_IX" , ""},
                { "AUTOCOBE_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1500_LE_SINISCAU_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_LE_SINISCAU_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2100_00_MAX_SINISCON_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SINISCON_NUM_PROTOCOLO_SINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MAX_SINISCON_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , ""},
                { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , ""},
                { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_PCT_PART_COSSEGURO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_SINISTRO" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , ""},
                { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "APOLIAUT_NUM_ENDOSSO" , ""},
                { "SIARDEVC_DATA_COMUNICADO" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "SINISMES_COD_MOEDA_SINI" , ""},
                { "AUTOCOBE_IMP_SEGURADA_IX" , ""},
                { "APOLCOSS_PCT_PART_COSSEGURO" , ""},
                { "SINISMES_PCT_PART_RESSEGURO" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "APOLICES_COD_CLIENTE" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "APOLIAUT_NUM_ITEM" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "AUTOCOBE_IMP_SEGURADA_IX" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , ""},
                { "IND_COD_ERRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q21);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI9101B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

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

                #region SI9101B_C01_SIARDEVC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "arquivo1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
                { "SIARDEVC_TIPO_REGISTRO" , "A" },
                { "SIARDEVC_SEQ_REGISTRO" , "100" },
                { "SIARDEVC_COD_OPERACAO" , "200" },
                { "SIARDEVC_NUM_APOLICE" , "AP123456" },
                { "SIARDEVC_NUM_ENDOSSO" , "EN654321" },
                { "SIARDEVC_NUM_ITEM" , "10" },
                { "SIARDEVC_COD_RAMO" , "R123" },
                { "SIARDEVC_COD_COBERTURA" , "114" },
                { "SIARDEVC_DATA_COMUNICADO" , "2023-12-02" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-12-03" },
                { "SIARDEVC_NUM_ITEM1" , "11" },
                { "SIARDEVC_COD_CAUSA" , "CA789" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "5000.0" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "SV123" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9101B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9101B_C01_SIARDEVC", q1);

                #endregion

                #region SI9101B_C01_APOLIAUT

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_NUM_ITEM" , "12" },
                { "APOLIAUT_NUM_ENDOSSO" , "AE123" },
                { "APOLIAUT_DATA_INIVIGENCIA" , "2023-11-01" },
                { "APOLIAUT_SIT_REGISTRO" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9101B_C01_APOLIAUT");
                AppSettings.TestSet.DynamicData.Add("SI9101B_C01_APOLIAUT", q2);

                #endregion

                #region R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_SIT_REGISTRO" , "5" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO" , "P789" },
                { "ENDOSSOS_COD_FONTE" , "F123" },
                { "APOLICES_ORGAO_EMISSOR" , "OE456" },
                { "APOLICES_COD_CLIENTE" , "CL789" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "AUTOCOBE_IMP_SEGURADA_IX" , "100000.0" },
                { "AUTOCOBE_SIT_REGISTRO" , "3" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "AUTOCOBE_IMP_SEGURADA_IX" , "100000.0" },
                { "AUTOCOBE_SIT_REGISTRO" , "3" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1500_LE_SINISCAU_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , "Causa1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_LE_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_LE_SINISCAU_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-11-02" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_MOVIMENTO" , "2023-12-04" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2100_00_MAX_SINISCON_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SINISCON_NUM_PROTOCOLO_SINI" , "SP123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_MAX_SINISCON_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_MAX_SINISCON_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_PCT_PART_COSSEGURO" , "15.0" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_SINISTRO" , "123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_SINISTRO" , "123" },
                { "APOLICES_ORGAO_EMISSOR" , "OE456" },
                { "SIARDEVC_COD_RAMO" , "R123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "F123" },
                { "SINISCON_NUM_PROTOCOLO_SINI" , "SP123" },
                { "SINISCON_DAC_PROTOCOLO_SINI" , "DP456" },
                { "SIARDEVC_NUM_APOLICE" , "AP123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "F123" },
                { "SINISCON_NUM_PROTOCOLO_SINI" , "SP123" },
                { "SINISCON_DAC_PROTOCOLO_SINI" , "DP456" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1", q12);

                #endregion

                #region R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "F123" },
                { "SINISCON_NUM_PROTOCOLO_SINI" , "SP123" },
                { "SINISCON_DAC_PROTOCOLO_SINI" , "DP456" },
                { "SINISMES_NUM_APOL_SINISTRO" , "AS789" },
                { "SIARDEVC_NUM_APOLICE" , "AP123456" },
                { "APOLIAUT_NUM_ENDOSSO" , "AE123" },
                { "SIARDEVC_DATA_COMUNICADO" , "2023-12-02" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-12-03" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SIARDEVC_COD_CAUSA" , "CA789" },
                { "SINISMES_COD_MOEDA_SINI" , "USD" },
                { "AUTOCOBE_IMP_SEGURADA_IX" , "100000.0" },
                { "APOLCOSS_PCT_PART_COSSEGURO" , "15.0" },
                { "SINISMES_PCT_PART_RESSEGURO" , "20.0" },
                { "SIARDEVC_COD_RAMO" , "R123" },
                { "ENDOSSOS_COD_PRODUTO" , "P789" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1", q16);

                #endregion

                #region R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "AS789" },
                { "APOLICES_COD_CLIENTE" , "CL789" },
                { "ENDOSSOS_COD_FONTE" , "F123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1", q17);

                #endregion

                #region R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "AS789" },
                { "SIARDEVC_COD_OPERACAO" , "200" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "5000.0" },
                { "SIARDEVC_NUM_APOLICE" , "AP123456" },
                { "ENDOSSOS_COD_PRODUTO" , "P789" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOLICE" , "AP123456" },
                { "SINISMES_NUM_APOL_SINISTRO" , "AS789" },
                { "APOLIAUT_NUM_ITEM" , "12" },
                { "SIARDEVC_COD_RAMO" , "R123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1", q19);

                #endregion

                #region R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "AS789" },
                { "SIARDEVC_COD_CAUSA" , "CA789" },
                { "AUTOCOBE_IMP_SEGURADA_IX" , "100000.0" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-12-03" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , "" },
                { "IND_COD_ERRO" , "" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "NAS123" },
                { "SIARDEVC_OCORR_HISTORICO" , "" },
                { "SIARDEVC_TIPO_REGISTRO" , "A" },
                { "SIARDEVC_SEQ_REGISTRO" , "100" },
                { "SIARDEVC_NOM_ARQUIVO" , "arquivo1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q21);

                #endregion
              
                #endregion


                var program = new SI9101B();
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
        public static void SI9101B_Tests99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region PARAMETERS

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI9101B_C01_SIARDEVC

                var q1 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("SI9101B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9101B_C01_SIARDEVC", q1);

                #endregion

                #region SI9101B_C01_APOLIAUT

                var q2 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("SI9101B_C01_APOLIAUT");
                AppSettings.TestSet.DynamicData.Add("SI9101B_C01_APOLIAUT", q2);

                #endregion

                #region R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1500_LE_SINISCAU_DB_SELECT_1_Query1

                var q7 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R1500_LE_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_LE_SINISCAU_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2100_00_MAX_SINISCON_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SINISCON_NUM_PROTOCOLO_SINI" , "SP123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_MAX_SINISCON_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_MAX_SINISCON_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_PCT_PART_COSSEGURO" , "15.0" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_SINISTRO" , "123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_SINISTRO" , "123" },
                { "APOLICES_ORGAO_EMISSOR" , "OE456" },
                { "SIARDEVC_COD_RAMO" , "R123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "F123" },
                { "SINISCON_NUM_PROTOCOLO_SINI" , "SP123" },
                { "SINISCON_DAC_PROTOCOLO_SINI" , "DP456" },
                { "SIARDEVC_NUM_APOLICE" , "AP123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1

                var q12 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1", q12);

                #endregion

                #region R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1

                var q16 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1", q16);

                #endregion

                #region R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "AS789" },
                { "APOLICES_COD_CLIENTE" , "CL789" },
                { "ENDOSSOS_COD_FONTE" , "F123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1", q17);

                #endregion

                #region R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q18 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1

                var q19 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1", q19);

                #endregion

                #region R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q21);

                #endregion

                #endregion


                var program = new SI9101B();
                program.Execute();
             

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}