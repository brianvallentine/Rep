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
using static Code.CB1260B;
using System.IO;
using Dclgens;
using Sias.Cobranca.DB2.CB1260B;

namespace FileTests.Test
{
    [Collection("CB1260B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB1260B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_MOV_ABERTO_CO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1", q1);

            #endregion

            #region CB1260B_C1CALENDARIO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1260B_C1CALENDARIO", q2);

            #endregion

            #region CB1260B_C0PARCELAS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
                { "PARCELAS_NUM_TITULO" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "ENDOSSOS_TIPO_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCELAS", q3);

            #endregion

            #region CB1260B_C1AU071

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "AU071_NUM_APOLICE" , ""},
                { "AU071_NUM_ENDOSSO" , ""},
                { "AU071_NUM_PARCELA" , ""},
                { "AU071_DTA_VENCTO" , ""},
                { "AU071_NUM_VENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1260B_C1AU071", q4);

            #endregion

            #region CB1260B_C0MOVDEBCE

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1260B_C0MOVDEBCE", q5);

            #endregion

            #region R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , ""},
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "CBAPOVIG_NUM_PARCELA" , ""},
                { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                { "CBAPOVIG_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CBMALPAR_NUM_APOLICE" , ""},
                { "CBMALPAR_NUM_ENDOSSO" , ""},
                { "CBMALPAR_NUM_PARCELA" , ""},
                { "CBMALPAR_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1", q7);

            #endregion

            #region R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "AU084_IND_FORMA_PAGTO_AD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_TIPO_SEGURO" , ""},
                { "APOLICES_TIPO_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_TIPO_ENDOSSO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_DTINIVIG_APOL" , ""},
                { "WS_HOST_DTTERVIG_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_QTD_MESES_VIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PARCEDEV_DATA_CANCEL_PREV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_QTD_DOCUMENTOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1", q15);

            #endregion

            #region CB1260B_C0PARCEHIS

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCEHIS", q16);

            #endregion

            #region R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "APOLCOBR_TIPO_COBRANCA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_QTD_SINISTROS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_QTD_SINISTROS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_QTD_PARCELAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q20);

            #endregion

            #region CB1260B_C2CALENDARIO

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1260B_C2CALENDARIO", q21);

            #endregion

            #region R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PRAZOSEG_FIM_PRAZO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_DATA_FIM_VIG_PROP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1", q23);

            #endregion

            #region R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_DATA_CANCELAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1", q24);

            #endregion

            #region R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_DATA_NOVOCANCEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1", q25);

            #endregion

            #region CB1260B_C0CALENDARIO

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1260B_C0CALENDARIO", q26);

            #endregion

            #region R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , ""},
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "CBAPOVIG_NUM_PARCELA" , ""},
                { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                { "CBAPOVIG_DATA_VENCIMENTO" , ""},
                { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                { "CBAPOVIG_SITUACAO" , ""},
                { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                { "VIND_DATA_MALA_CANCEL" , ""},
                { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                { "VIND_DATA_MALA_VIG" , ""},
                { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                { "CBAPOVIG_DATA_VENCIMENTO" , ""},
                { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "CBAPOVIG_NUM_PARCELA" , ""},
                { "CBAPOVIG_SITUACAO" , ""},
                { "CBAPOVIG_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1", q28);

            #endregion

            #region R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "CBMALPAR_NUM_APOLICE" , ""},
                { "CBMALPAR_NUM_ENDOSSO" , ""},
                { "CBMALPAR_NUM_PARCELA" , ""},
                { "CBMALPAR_DATA_MOVIMENTO" , ""},
                { "CBMALPAR_DATA_VENC_CONTR" , ""},
                { "CBMALPAR_IDTAB_SITUACAO" , ""},
                { "CBMALPAR_SITUACAO" , ""},
                { "CBMALPAR_NUM_TITULO" , ""},
                { "CBMALPAR_DATA_VENCIMENTO" , ""},
                { "CBMALPAR_PREMIO_TOTAL" , ""},
                { "CBMALPAR_VALOR_ACRESCIMO" , ""},
                { "CBMALPAR_VALOR_TARIFA" , ""},
                { "CBMALPAR_VALOR_VISTORIA" , ""},
                { "CBMALPAR_DATA_ENVIO" , ""},
                { "CBMALPAR_DTA_VENCIMENTO_AR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1", q29);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB1260B_t1")]
        public static void CB1260B_Tests_Theory_Grava_CB1260B1(string CB1260B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB1260B1_FILE_NAME_P = $"{CB1260B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2021-08-29"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_DATA_MOV_ABERTO_CO" , "2021-08-29"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1", q1);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PARCELAS_NUM_APOLICE" , ""},
                    { "PARCELAS_NUM_ENDOSSO" , ""},
                    { "PARCELAS_NUM_TITULO" , ""},
                    { "PARCELAS_NUM_PARCELA" , ""},
                    { "PARCEHIS_DATA_VENCIMENTO" , ""},
                    { "PARCEHIS_PRM_TOTAL" , ""},
                    { "ENDOSSOS_COD_PRODUTO" , "5302"},
                    { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                    { "ENDOSSOS_QTD_PARCELAS" , ""},
                    { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCELAS", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "AU071_NUM_APOLICE" , ""},
                    { "AU071_NUM_ENDOSSO" , ""},
                    { "AU071_NUM_PARCELA" , ""},
                    { "AU071_DTA_VENCTO" , ""},
                    { "AU071_NUM_VENCTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C1AU071");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C1AU071", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_NUM_CARTAO" , ""},
                    { "MOVDEBCE_VALOR_DEBITO" , ""},
                    { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                    { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                    { "MOVDEBCE_NSAS" , ""},
                    { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0MOVDEBCE", q5);

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_NUM_APOLICE" , ""},
                    { "CBAPOVIG_NUM_ENDOSSO" , ""},
                    { "CBAPOVIG_NUM_PARCELA" , ""},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1", q6);

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "CBMALPAR_NUM_APOLICE" , ""},
                    { "CBMALPAR_NUM_ENDOSSO" , ""},
                    { "CBMALPAR_NUM_PARCELA" , ""},
                    { "CBMALPAR_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1", q7);

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "AU084_IND_FORMA_PAGTO_AD" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1", q8);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "MOVIMCOB_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_ORGAO_EMISSOR" , "100"},
                    { "APOLICES_TIPO_SEGURO" , "1"},
                    { "APOLICES_TIPO_APOLICE" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1", q10);

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_TIPO_ENDOSSO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q11);

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_DTINIVIG_APOL" , ""},
                    { "WS_HOST_DTTERVIG_APOL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q12);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_MESES_VIG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1", q13);

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "PARCEDEV_DATA_CANCEL_PREV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1", q14);

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_DOCUMENTOS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1", q15);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_NUM_APOLICE" , ""},
                    { "PARCEHIS_NUM_ENDOSSO" , ""},
                    { "PARCEHIS_NUM_PARCELA" , ""},
                    { "PARCEHIS_OCORR_HISTORICO" , ""},
                    { "PARCEHIS_COD_OPERACAO" , ""},
                    { "PARCEHIS_DATA_MOVIMENTO" , ""},
                    { "PARCEHIS_PRM_TOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCEHIS", q16);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "APOLCOBR_TIPO_COBRANCA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1", q17);

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_SINISTROS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1", q18);

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_SINISTROS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1", q19);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_PARCELAS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q20);

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , ""},
                    { "CALENDAR_DIA_SEMANA" , ""},
                    { "CALENDAR_FERIADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C2CALENDARIO");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C2CALENDARIO", q21);

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "PRAZOSEG_FIM_PRAZO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1", q22);

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_DATA_FIM_VIG_PROP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1", q23);

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_DATA_CANCELAMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1", q24);

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_DATA_NOVOCANCEL" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1", q25);

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_NUM_APOLICE" , ""},
                    { "CBAPOVIG_NUM_ENDOSSO" , ""},
                    { "CBAPOVIG_NUM_PARCELA" , ""},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_DATA_VENCIMENTO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                    { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                    { "CBAPOVIG_SITUACAO" , ""},
                    { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1", q27);

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                    { "VIND_DATA_MALA_CANCEL" , ""},
                    { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                    { "VIND_DATA_MALA_VIG" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                    { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                    { "CBAPOVIG_DATA_VENCIMENTO" , ""},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                    { "CBAPOVIG_NUM_ENDOSSO" , ""},
                    { "CBAPOVIG_NUM_PARCELA" , ""},
                    { "CBAPOVIG_SITUACAO" , ""},
                    { "CBAPOVIG_NUM_APOLICE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1", q28);

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "CBMALPAR_NUM_APOLICE" , ""},
                    { "CBMALPAR_NUM_ENDOSSO" , ""},
                    { "CBMALPAR_NUM_PARCELA" , ""},
                    { "CBMALPAR_DATA_MOVIMENTO" , ""},
                    { "CBMALPAR_DATA_VENC_CONTR" , ""},
                    { "CBMALPAR_IDTAB_SITUACAO" , ""},
                    { "CBMALPAR_SITUACAO" , ""},
                    { "CBMALPAR_NUM_TITULO" , ""},
                    { "CBMALPAR_DATA_VENCIMENTO" , ""},
                    { "CBMALPAR_PREMIO_TOTAL" , ""},
                    { "CBMALPAR_VALOR_ACRESCIMO" , ""},
                    { "CBMALPAR_VALOR_TARIFA" , ""},
                    { "CBMALPAR_VALOR_VISTORIA" , ""},
                    { "CBMALPAR_DATA_ENVIO" , ""},
                    { "CBMALPAR_DTA_VENCIMENTO_AR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1", q29);

                MountCalendars();

                #endregion

                var program = new CB1260B();
                program.Execute(CB1260B1_FILE_NAME_P);

                Assert.True(File.Exists(program.CB1260B1.FilePath));
                Assert.True(new FileInfo(program.CB1260B1.FilePath).Length > 1);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("CB1260B_t2")]
        public static void CB1260B_Tests_Theory_Selects(string CB1260B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB1260B1_FILE_NAME_P = $"{CB1260B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "1996-08-29"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion

                #region R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_DATA_MOV_ABERTO_CO" , "1996-08-29"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1", q1);
                #endregion

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PARCELAS_NUM_APOLICE" , ""},
                    { "PARCELAS_NUM_ENDOSSO" , ""},
                    { "PARCELAS_NUM_TITULO" , ""},
                    { "PARCELAS_NUM_PARCELA" , ""},
                    { "PARCEHIS_DATA_VENCIMENTO" , ""},
                    { "PARCEHIS_PRM_TOTAL" , ""},
                    { "ENDOSSOS_COD_PRODUTO" , "5302"},
                    { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                    { "ENDOSSOS_QTD_PARCELAS" , ""},
                    { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCELAS", q3);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_ORGAO_EMISSOR" , "110"},
                    { "APOLICES_TIPO_SEGURO" , "1"},
                    { "APOLICES_TIPO_APOLICE" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1", q10);

                MountCalendars();

                #endregion

                var program = new CB1260B();
                program.Execute(CB1260B1_FILE_NAME_P);

                var select1 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select1);

                var select2 = AppSettings.TestSet.DynamicData["R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select2);

                var select3 = AppSettings.TestSet.DynamicData["R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select3);

                var select4 = AppSettings.TestSet.DynamicData["R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1"].DynamicList.ToList();
                Assert.Empty(select4);

                //var select5 = AppSettings.TestSet.DynamicData["R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select5);

                //var select6 = AppSettings.TestSet.DynamicData["R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select6);

                var select7 = AppSettings.TestSet.DynamicData["R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select7);

                //var select8 = AppSettings.TestSet.DynamicData["R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select8);

                //var select9 = AppSettings.TestSet.DynamicData["R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select9);

                //var select10 = AppSettings.TestSet.DynamicData["R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select10);

                //var select11 = AppSettings.TestSet.DynamicData["R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select11);

                //var select12 = AppSettings.TestSet.DynamicData["R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select12);

                var select13 = AppSettings.TestSet.DynamicData["R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select13);

                //var select14 = AppSettings.TestSet.DynamicData["R1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select14);

                //var select15 = AppSettings.TestSet.DynamicData["R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select15);

                //var select16 = AppSettings.TestSet.DynamicData["R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select16);

                //var select17 = AppSettings.TestSet.DynamicData["R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select17);

                //var select18 = AppSettings.TestSet.DynamicData["R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1"].DynamicList.ToList();
                //Assert.Empty(select18);

                //var select19 = AppSettings.TestSet.DynamicData["R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1"].DynamicList.ToList();
                //Assert.Empty(select19);

                var select20 = AppSettings.TestSet.DynamicData["R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select20);

                var select21 = AppSettings.TestSet.DynamicData["R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select21);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("CB1260B_t3")]
        public static void CB1260B_Tests_Theory_Update(string CB1260B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB1260B1_FILE_NAME_P = $"{CB1260B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "1999-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_DATA_MOV_ABERTO_CO" , "1999-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1", q1);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PARCELAS_NUM_APOLICE" , "1"},
                    { "PARCELAS_NUM_ENDOSSO" , "0"},
                    { "PARCELAS_NUM_TITULO" , "0"},
                    { "PARCELAS_NUM_PARCELA" , "1"},
                    { "PARCEHIS_DATA_VENCIMENTO" , "1996-08-01"},
                    { "PARCEHIS_PRM_TOTAL" , "4"},
                    { "ENDOSSOS_COD_PRODUTO" , "5302"},
                    { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                    { "ENDOSSOS_QTD_PARCELAS" , ""},
                    { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCELAS", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "AU071_NUM_APOLICE" , "0"},
                    { "AU071_NUM_ENDOSSO" , "0"},
                    { "AU071_NUM_PARCELA" , "1"},
                    { "AU071_DTA_VENCTO" , "1997-12-01"},
                    { "AU071_NUM_VENCTO" , ""},
                });
                //q4.AddDynamic(new Dictionary<string, string>{
                //    { "AU071_NUM_APOLICE" , "1"},
                //    { "AU071_NUM_ENDOSSO" , "0"},
                //    { "AU071_NUM_PARCELA" , "1"},
                //    { "AU071_DTA_VENCTO" , "1997-12-01"},
                //    { "AU071_NUM_VENCTO" , ""},
                //});
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C1AU071");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C1AU071", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_NUM_CARTAO" , "0"},
                    { "MOVDEBCE_VALOR_DEBITO" , "0"},
                    { "MOVDEBCE_DATA_VENCIMENTO" , "2000-01-01"},
                    { "MOVDEBCE_SITUACAO_COBRANCA" , "6"},
                    { "MOVDEBCE_NSAS" , ""},
                    { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0MOVDEBCE", q5);

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_NUM_APOLICE" , "0"},
                    { "CBAPOVIG_NUM_ENDOSSO" , "0"},
                    { "CBAPOVIG_NUM_PARCELA" , "1"},
                    { "CBAPOVIG_DATA_MOVIMENTO" , "1997-01-01"},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , "2000-01-01"},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , "2000-01-01"},
                    { "CBAPOVIG_SITUACAO" , "1"},
                });
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_NUM_APOLICE" , "1"},
                    { "CBAPOVIG_NUM_ENDOSSO" , "0"},
                    { "CBAPOVIG_NUM_PARCELA" , "1"},
                    { "CBAPOVIG_DATA_MOVIMENTO" , "1997-01-01"},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , "2000-01-01"},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , "2000-01-01"},
                    { "CBAPOVIG_SITUACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1", q6);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_MESES_VIG" , "12"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1", q13);

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_DOCUMENTOS" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1", q15);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_NUM_APOLICE" , "0"},
                    { "PARCEHIS_NUM_ENDOSSO" , "0"},
                    { "PARCEHIS_NUM_PARCELA" , "0"},
                    { "PARCEHIS_OCORR_HISTORICO" , ""},
                    { "PARCEHIS_COD_OPERACAO" , ""},
                    { "PARCEHIS_DATA_MOVIMENTO" , ""},
                    { "PARCEHIS_PRM_TOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCEHIS", q16);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_PARCELAS" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q20);

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_NUM_APOLICE" , "0"},
                    { "CBAPOVIG_NUM_ENDOSSO" , "0"},
                    { "CBAPOVIG_NUM_PARCELA" , "0"},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_DATA_VENCIMENTO" , "2021-08-10"},
                    { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                    { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                    { "CBAPOVIG_SITUACAO" , "1"},
                    { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1", q27);

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                    { "VIND_DATA_MALA_CANCEL" , ""},
                    { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                    { "VIND_DATA_MALA_VIG" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                    { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                    { "CBAPOVIG_DATA_VENCIMENTO" , "2021-08-10"},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                    { "CBAPOVIG_NUM_ENDOSSO" , "0"},
                    { "CBAPOVIG_NUM_PARCELA" , "1"},
                    { "CBAPOVIG_SITUACAO" , "1"},
                    { "CBAPOVIG_NUM_APOLICE" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1", q28);

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "CBMALPAR_NUM_APOLICE" , "0"},
                    { "CBMALPAR_NUM_ENDOSSO" , "0"},
                    { "CBMALPAR_NUM_PARCELA" , "0"},
                    { "CBMALPAR_DATA_MOVIMENTO" , ""},
                    { "CBMALPAR_DATA_VENC_CONTR" , ""},
                    { "CBMALPAR_IDTAB_SITUACAO" , ""},
                    { "CBMALPAR_SITUACAO" , ""},
                    { "CBMALPAR_NUM_TITULO" , "0"},
                    { "CBMALPAR_DATA_VENCIMENTO" , ""},
                    { "CBMALPAR_PREMIO_TOTAL" , ""},
                    { "CBMALPAR_VALOR_ACRESCIMO" , ""},
                    { "CBMALPAR_VALOR_TARIFA" , ""},
                    { "CBMALPAR_VALOR_VISTORIA" , ""},
                    { "CBMALPAR_DATA_ENVIO" , ""},
                    { "CBMALPAR_DTA_VENCIMENTO_AR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1", q29);

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "CBMALPAR_NUM_APOLICE" , "0"},
                    { "CBMALPAR_NUM_ENDOSSO" , "0"},
                    { "CBMALPAR_NUM_PARCELA" , "1"},
                    { "CBMALPAR_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1", q7);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "MOVIMCOB_SIT_REGISTRO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_ORGAO_EMISSOR" , "100"},
                    { "APOLICES_TIPO_SEGURO" , "1"},
                    { "APOLICES_TIPO_APOLICE" , "0"},
                });
                q10.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_ORGAO_EMISSOR" , "100"},
                    { "APOLICES_TIPO_SEGURO" , "1"},
                    { "APOLICES_TIPO_APOLICE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1", q10);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "APOLCOBR_TIPO_COBRANCA" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1", q17);

                MountCalendars();

                #endregion

                var program = new CB1260B();
                program.Execute(CB1260B1_FILE_NAME_P);

                var update = AppSettings.TestSet.DynamicData["R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.True(update.Count > 1);
                Assert.True(update[^1].TryGetValue("CBAPOVIG_NUM_APOLICE", out string value2) && value2 == "0000000000001");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("CB1260B_t4")]
        public static void CB1260B_Tests_Theory_Insert1(string CB1260B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB1260B1_FILE_NAME_P = $"{CB1260B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "1999-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_DATA_MOV_ABERTO_CO" , "1999-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1", q1);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PARCELAS_NUM_APOLICE" , "1"},
                    { "PARCELAS_NUM_ENDOSSO" , "0"},
                    { "PARCELAS_NUM_TITULO" , "0"},
                    { "PARCELAS_NUM_PARCELA" , "1"},
                    { "PARCEHIS_DATA_VENCIMENTO" , "1996-08-01"},
                    { "PARCEHIS_PRM_TOTAL" , "4"},
                    { "ENDOSSOS_COD_PRODUTO" , "5302"},
                    { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                    { "ENDOSSOS_QTD_PARCELAS" , ""},
                    { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCELAS", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "AU071_NUM_APOLICE" , "0"},
                    { "AU071_NUM_ENDOSSO" , "0"},
                    { "AU071_NUM_PARCELA" , "1"},
                    { "AU071_DTA_VENCTO" , "1997-12-01"},
                    { "AU071_NUM_VENCTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C1AU071");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C1AU071", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_NUM_CARTAO" , "0"},
                    { "MOVDEBCE_VALOR_DEBITO" , "0"},
                    { "MOVDEBCE_DATA_VENCIMENTO" , "2000-01-01"},
                    { "MOVDEBCE_SITUACAO_COBRANCA" , "6"},
                    { "MOVDEBCE_NSAS" , ""},
                    { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0MOVDEBCE", q5);

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1", q6);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_MESES_VIG" , "12"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1", q13);

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_DOCUMENTOS" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1", q15);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_NUM_APOLICE" , "0"},
                    { "PARCEHIS_NUM_ENDOSSO" , "0"},
                    { "PARCEHIS_NUM_PARCELA" , "0"},
                    { "PARCEHIS_OCORR_HISTORICO" , ""},
                    { "PARCEHIS_COD_OPERACAO" , ""},
                    { "PARCEHIS_DATA_MOVIMENTO" , ""},
                    { "PARCEHIS_PRM_TOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCEHIS", q16);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_PARCELAS" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q20);

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_NUM_APOLICE" , "0"},
                    { "CBAPOVIG_NUM_ENDOSSO" , "0"},
                    { "CBAPOVIG_NUM_PARCELA" , "0"},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_DATA_VENCIMENTO" , "2021-08-10"},
                    { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                    { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                    { "CBAPOVIG_SITUACAO" , "1"},
                    { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1", q27);

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                    { "VIND_DATA_MALA_CANCEL" , ""},
                    { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                    { "VIND_DATA_MALA_VIG" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                    { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                    { "CBAPOVIG_DATA_VENCIMENTO" , "2021-08-10"},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                    { "CBAPOVIG_NUM_ENDOSSO" , "0"},
                    { "CBAPOVIG_NUM_PARCELA" , "1"},
                    { "CBAPOVIG_SITUACAO" , "1"},
                    { "CBAPOVIG_NUM_APOLICE" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1", q28);

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "CBMALPAR_NUM_APOLICE" , "0"},
                    { "CBMALPAR_NUM_ENDOSSO" , "0"},
                    { "CBMALPAR_NUM_PARCELA" , "0"},
                    { "CBMALPAR_DATA_MOVIMENTO" , ""},
                    { "CBMALPAR_DATA_VENC_CONTR" , ""},
                    { "CBMALPAR_IDTAB_SITUACAO" , ""},
                    { "CBMALPAR_SITUACAO" , ""},
                    { "CBMALPAR_NUM_TITULO" , "0"},
                    { "CBMALPAR_DATA_VENCIMENTO" , ""},
                    { "CBMALPAR_PREMIO_TOTAL" , ""},
                    { "CBMALPAR_VALOR_ACRESCIMO" , ""},
                    { "CBMALPAR_VALOR_TARIFA" , ""},
                    { "CBMALPAR_VALOR_VISTORIA" , ""},
                    { "CBMALPAR_DATA_ENVIO" , ""},
                    { "CBMALPAR_DTA_VENCIMENTO_AR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1", q29);

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "CBMALPAR_NUM_APOLICE" , "0"},
                    { "CBMALPAR_NUM_ENDOSSO" , "0"},
                    { "CBMALPAR_NUM_PARCELA" , "1"},
                    { "CBMALPAR_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1", q7);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "MOVIMCOB_SIT_REGISTRO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_ORGAO_EMISSOR" , "100"},
                    { "APOLICES_TIPO_SEGURO" , "1"},
                    { "APOLICES_TIPO_APOLICE" , "0"},
                });
                q10.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_ORGAO_EMISSOR" , "100"},
                    { "APOLICES_TIPO_SEGURO" , "1"},
                    { "APOLICES_TIPO_APOLICE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1", q10);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "APOLCOBR_TIPO_COBRANCA" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1", q17);

                MountCalendars();

                #endregion

                var program = new CB1260B();
                program.Execute(CB1260B1_FILE_NAME_P);

                var insert1 = AppSettings.TestSet.DynamicData["R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert1.Count > 1);
                Assert.True(insert1[^1].TryGetValue("CBAPOVIG_NUM_APOLICE", out string value) && value == "0000000000001");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("CB1260B_t5")]
        public static void CB1260B_Tests_Theory_Insert2(string CB1260B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB1260B1_FILE_NAME_P = $"{CB1260B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "1999-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_DATA_MOV_ABERTO_CO" , "1999-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1", q1);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PARCELAS_NUM_APOLICE" , "1"},
                    { "PARCELAS_NUM_ENDOSSO" , "0"},
                    { "PARCELAS_NUM_TITULO" , "0"},
                    { "PARCELAS_NUM_PARCELA" , "1"},
                    { "PARCEHIS_DATA_VENCIMENTO" , "1996-08-01"},
                    { "PARCEHIS_PRM_TOTAL" , "4"},
                    { "ENDOSSOS_COD_PRODUTO" , "5302"},
                    { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                    { "ENDOSSOS_QTD_PARCELAS" , ""},
                    { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCELAS", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "AU071_NUM_APOLICE" , "0"},
                    { "AU071_NUM_ENDOSSO" , "0"},
                    { "AU071_NUM_PARCELA" , "1"},
                    { "AU071_DTA_VENCTO" , "1997-12-01"},
                    { "AU071_NUM_VENCTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C1AU071");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C1AU071", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_NUM_CARTAO" , "0"},
                    { "MOVDEBCE_VALOR_DEBITO" , "0"},
                    { "MOVDEBCE_DATA_VENCIMENTO" , "2000-01-01"},
                    { "MOVDEBCE_SITUACAO_COBRANCA" , "6"},
                    { "MOVDEBCE_NSAS" , ""},
                    { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0MOVDEBCE", q5);

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1", q6);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_MESES_VIG" , "12"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1", q13);

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_DOCUMENTOS" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1", q15);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_NUM_APOLICE" , "0"},
                    { "PARCEHIS_NUM_ENDOSSO" , "0"},
                    { "PARCEHIS_NUM_PARCELA" , "0"},
                    { "PARCEHIS_OCORR_HISTORICO" , ""},
                    { "PARCEHIS_COD_OPERACAO" , ""},
                    { "PARCEHIS_DATA_MOVIMENTO" , ""},
                    { "PARCEHIS_PRM_TOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1260B_C0PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("CB1260B_C0PARCEHIS", q16);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_QTD_PARCELAS" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q20);

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_NUM_APOLICE" , "0"},
                    { "CBAPOVIG_NUM_ENDOSSO" , "0"},
                    { "CBAPOVIG_NUM_PARCELA" , "0"},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_DATA_VENCIMENTO" , "2021-08-10"},
                    { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                    { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                    { "CBAPOVIG_SITUACAO" , "1"},
                    { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1", q27);

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "CBAPOVIG_DATA_MALA_CANCEL" , ""},
                    { "VIND_DATA_MALA_CANCEL" , ""},
                    { "CBAPOVIG_DATA_MALA_VIG_PROP" , ""},
                    { "VIND_DATA_MALA_VIG" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                    { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                    { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                    { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                    { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                    { "CBAPOVIG_DATA_VENCIMENTO" , "2021-08-10"},
                    { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                    { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                    { "CBAPOVIG_NUM_ENDOSSO" , "0"},
                    { "CBAPOVIG_NUM_PARCELA" , "1"},
                    { "CBAPOVIG_SITUACAO" , "1"},
                    { "CBAPOVIG_NUM_APOLICE" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1", q28);

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "CBMALPAR_NUM_APOLICE" , "0"},
                    { "CBMALPAR_NUM_ENDOSSO" , "0"},
                    { "CBMALPAR_NUM_PARCELA" , "0"},
                    { "CBMALPAR_DATA_MOVIMENTO" , ""},
                    { "CBMALPAR_DATA_VENC_CONTR" , ""},
                    { "CBMALPAR_IDTAB_SITUACAO" , ""},
                    { "CBMALPAR_SITUACAO" , ""},
                    { "CBMALPAR_NUM_TITULO" , "0"},
                    { "CBMALPAR_DATA_VENCIMENTO" , ""},
                    { "CBMALPAR_PREMIO_TOTAL" , ""},
                    { "CBMALPAR_VALOR_ACRESCIMO" , ""},
                    { "CBMALPAR_VALOR_TARIFA" , ""},
                    { "CBMALPAR_VALOR_VISTORIA" , ""},
                    { "CBMALPAR_DATA_ENVIO" , ""},
                    { "CBMALPAR_DTA_VENCIMENTO_AR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1", q29);

                var q7 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1", q7);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "MOVIMCOB_SIT_REGISTRO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_ORGAO_EMISSOR" , "100"},
                    { "APOLICES_TIPO_SEGURO" , "1"},
                    { "APOLICES_TIPO_APOLICE" , "0"},
                });
                q10.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_ORGAO_EMISSOR" , "100"},
                    { "APOLICES_TIPO_SEGURO" , "1"},
                    { "APOLICES_TIPO_APOLICE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1", q10);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "APOLCOBR_TIPO_COBRANCA" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1", q17);

                MountCalendars();

                #endregion

                var program = new CB1260B();
                program.Execute(CB1260B1_FILE_NAME_P);

                var insert2 = AppSettings.TestSet.DynamicData["R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert2.Count > 1);
                Assert.True(insert2[^1].TryGetValue("CBMALPAR_NUM_APOLICE", out string value1) && value1 == "0000000000001");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("CB1260B_t6")]
        public static void CB1260B_Tests_Theory_ReturnCode99(string CB1260B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB1260B1_FILE_NAME_P = $"{CB1260B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                AppSettings.TestSet.QueryLimit = 20;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "1996-08-29"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion

                #endregion

                var program = new CB1260B();
                program.Execute(CB1260B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        private static void MountCalendars()
        {
            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-31"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-30"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-29"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-28"},
                    { "CALENDAR_DIA_SEMANA" , "S"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-27"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-26"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-25"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-24"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-23"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-22"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-21"},
                    { "CALENDAR_DIA_SEMANA" , "S"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-20"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-19"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-18"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-17"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-16"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-15"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-14"},
                    { "CALENDAR_DIA_SEMANA" , "S"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q2.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-13"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            AppSettings.TestSet.DynamicData.Remove("CB1260B_C1CALENDARIO");
            AppSettings.TestSet.DynamicData.Add("CB1260B_C1CALENDARIO", q2);

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-11"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-10"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-11"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-10"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-11"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-10"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-09"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-08"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-07"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-06"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-05"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-04"},
                    { "CALENDAR_DIA_SEMANA" , "S"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-03"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-02"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-01"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-04"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-03"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-02"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1995-01-01"},
                    { "CALENDAR_DIA_SEMANA" , "S"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-31"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-30"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-29"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-28"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-27"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-26"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                        { "CALENDAR_DATA_CALENDARIO" , "1996-12-25"},
                        { "CALENDAR_DIA_SEMANA" , "S"},
                        { "CALENDAR_FERIADO" , ""},
                    });
            q26.AddDynamic(new Dictionary<string, string>{
                        { "CALENDAR_DATA_CALENDARIO" , "1996-12-24"},
                        { "CALENDAR_DIA_SEMANA" , "6"},
                        { "CALENDAR_FERIADO" , ""},
                    });
            q26.AddDynamic(new Dictionary<string, string>{
                        { "CALENDAR_DATA_CALENDARIO" , "1996-12-23"},
                        { "CALENDAR_DIA_SEMANA" , "5"},
                        { "CALENDAR_FERIADO" , ""},
                    });
            q26.AddDynamic(new Dictionary<string, string>{
                        { "CALENDAR_DATA_CALENDARIO" , "1996-12-22"},
                        { "CALENDAR_DIA_SEMANA" , "4"},
                        { "CALENDAR_FERIADO" , ""},
                    });
            q26.AddDynamic(new Dictionary<string, string>{
                        { "CALENDAR_DATA_CALENDARIO" , "1996-12-21"},
                        { "CALENDAR_DIA_SEMANA" , "3"},
                        { "CALENDAR_FERIADO" , ""},
                    });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-20"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-19"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-18"},
                    { "CALENDAR_DIA_SEMANA" , "S"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-17"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-16"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-15"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-14"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-13"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-12"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-11"},
                    { "CALENDAR_DIA_SEMANA" , "S"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-10"},
                    { "CALENDAR_DIA_SEMANA" , "6"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-9"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-8"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-7"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-6"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-5"},
                    { "CALENDAR_DIA_SEMANA" , "5"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-4"},
                    { "CALENDAR_DIA_SEMANA" , "4"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-3"},
                    { "CALENDAR_DIA_SEMANA" , "3"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-2"},
                    { "CALENDAR_DIA_SEMANA" , "2"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-12-1"},
                    { "CALENDAR_DIA_SEMANA" , "D"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "1996-11-30"},
                    { "CALENDAR_DIA_SEMANA" , "S"},
                    { "CALENDAR_FERIADO" , ""},
                });
            q26.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1996-11-29"},
                { "CALENDAR_DIA_SEMANA" , "6"},
                { "CALENDAR_FERIADO" , ""},
            });
            q26.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1996-11-28"},
                { "CALENDAR_DIA_SEMANA" , "5"},
                { "CALENDAR_FERIADO" , ""},
            });
            q26.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1996-11-27"},
                { "CALENDAR_DIA_SEMANA" , "4"},
                { "CALENDAR_FERIADO" , ""},
            });
            q26.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1996-11-26"},
                { "CALENDAR_DIA_SEMANA" , "3"},
                { "CALENDAR_FERIADO" , ""},
            });
            q26.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1996-11-25"},
                { "CALENDAR_DIA_SEMANA" , "2"},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Remove("CB1260B_C0CALENDARIO");
            AppSettings.TestSet.DynamicData.Add("CB1260B_C0CALENDARIO", q26);
        }
    }
}