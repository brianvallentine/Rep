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
using Code;
using static Code.SI5066B;

namespace FileTests.Test
{
    [Collection("SI5066B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI5066B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region Execute_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q1);

            #endregion

            #region R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-02-02"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-02-02"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-02-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region Execute_DB_SELECT_3_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_3_Query1", q3);

            #endregion

            #region R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_SI_DATA_MOV_ABERTO" , "2020-02-02"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_SI_DATA_MOV_ABERTO" , "2020-02-02"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_SI_DATA_MOV_ABERTO" , "2020-02-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1", q4);

            #endregion

            #region R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "W_DATA_PRIMEIRO_DIA_UTIL" , "2020-02-02"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "W_DATA_PRIMEIRO_DIA_UTIL" , "2020-02-02"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "W_DATA_PRIMEIRO_DIA_UTIL" , "2020-02-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1", q5);

            #endregion

            #region Execute_DB_SELECT_4_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q6);

            #endregion

            #region SI5066B_SINISTRO

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "123"},
                { "SINISHIS_OCORR_HISTORICO" , "10"},
                { "SINIHAB1_PONTO_VENDA" , "10"},
            });
            AppSettings.TestSet.DynamicData.Add("SI5066B_SINISTRO", q7);

            #endregion

            #region SI5066B_C01_RALCHEDO

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "456"},
                { "SINISHIS_NUM_APOLICE" , "123"},
                { "SINISHIS_OCORR_HISTORICO" , "10"},
                { "SINISHIS_COD_OPERACAO" , "10"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-10-10"},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , "2"},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_RAMO" , "10"},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINISMES_DAC_PROTOCOLO_SINI" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "RALCHEDO_AGE_CENTRAL_PROD01" , ""},
                { "RALCHEDO_NUMDOC_NUM01" , ""},
                { "RALCHEDO_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI5066B_C01_RALCHEDO", q8);

            #endregion

            #region R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_COD_EMPRESA" , ""},
                { "RALCHEDO_NUM_CHEQUE_INTERNO" , ""},
                { "RALCHEDO_DIG_CHEQUE_INTERNO" , ""},
                { "RALCHEDO_NUM_DOCUMENTO" , ""},
                { "RALCHEDO_OCORR_HISTORICO" , ""},
                { "RALCHEDO_TIPO_MOVIMENTO" , ""},
                { "RALCHEDO_TIMESTAMP" , ""},
                { "RALCHEDO_AGENCIA_CONTRATO" , ""},
                { "RALCHEDO_NUMERO_SIVAT" , ""},
                { "RALCHEDO_DV_SIVAT" , ""},
                { "RALCHEDO_AGE_CENTRAL_PROD01" , ""},
                { "RALCHEDO_NUMDOC_NUM01" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R0310_SELECT_MAX_CHEQUES_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0310_SELECT_MAX_CHEQUES_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_TIPO_MOVIMENTO" , ""},
                { "CHEQUEMI_COD_FONTE" , ""},
                { "CHEQUEMI_NUM_DOCUMENTO" , ""},
                { "CHEQUEMI_NOME_FAVORECIDO" , ""},
                { "CHEQUEMI_VAL_CHEQUE" , ""},
                { "CHEQUEMI_DATA_MOVIMENTO" , ""},
                { "CHEQUEMI_DATA_EMISSAO" , ""},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_DIG_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_SIT_REGISTRO" , ""},
                { "CHEQUEMI_TIPO_PAGAMENTO" , ""},
                { "CHEQUEMI_DATA_COMPETENCIA" , ""},
                { "CHEQUEMI_PRACA_PAGAMENTO" , ""},
                { "CHEQUEMI_NUM_RECIBO" , ""},
                { "CHEQUEMI_OCORR_HISTORICO" , ""},
                { "CHEQUEMI_COD_OPERACAO" , ""},
                { "CHEQUEMI_COD_DESPESA" , ""},
                { "CHEQUEMI_VAL_IRF" , ""},
                { "CHEQUEMI_VAL_ISS" , ""},
                { "CHEQUEMI_VAL_IAPAS" , ""},
                { "CHEQUEMI_COD_LANCAMENTO" , ""},
                { "CHEQUEMI_DATA_LANCAMENTO" , ""},
                { "CHEQUEMI_COD_EMPRESA" , ""},
                { "CHEQUEMI_COD_FAVORECIDO" , ""},
                { "CHEQUEMI_VAL_INSS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_COD_BANCO" , ""},
                { "PARAMCON_COD_AGENCIA_SASS" , ""},
                { "PARAMCON_OPER_CONTA_SASS" , ""},
                { "PARAMCON_NUM_CONTA_SASS" , ""},
                { "PARAMCON_DIG_CONTA_SASS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_VAL_CHEQUE" , ""},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISTOCHE_NUM_CHEQUE_INTERNO" , ""},
                { "HISTOCHE_DIG_CHEQUE_INTERNO" , ""},
                { "HISTOCHE_DATA_MOVIMENTO" , ""},
                { "HISTOCHE_HORA_OPERACAO" , ""},
                { "HISTOCHE_COD_OPERACAO" , ""},
                { "HISTOCHE_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_NUM_CHEQUE_INTERNO" , ""},
                { "RALCHEDO_DIG_CHEQUE_INTERNO" , ""},
                { "RALCHEDO_OCORR_HISTORICO" , ""},
                { "RALCHEDO_NUMDOC_NUM01" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_APOL_SINISTRO" , ""},
                { "SISINCHE_COD_OPERACAO" , ""},
                { "SISINCHE_OCORR_HISTORICO" , ""},
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""},
                { "SISINCHE_COD_DESPESA" , ""},
                { "SISINCHE_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_LOTE" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "GE369_NUM_APOLICE" , ""},
                { "GE369_NUM_ENDOSSO" , ""},
                { "GE369_NUM_PARCELA" , ""},
                { "GE369_COD_CONVENIO" , ""},
                { "GE369_NSAS" , ""},
                { "GE369_COD_AGENCIA" , ""},
                { "GE369_COD_BANCO" , ""},
                { "GE369_NUM_CONTA_CNB" , ""},
                { "GE369_NUM_DV_CONTA_CNB" , ""},
                { "GE369_IND_CONTA_BANCARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1", q20);

            #endregion

            #endregion

            //subprogramas
            SI0505B_Tests.Load_Parameters();
            SI1040S_Tests.Load_Parameters();
            SI4922B_Tests.Load_Parameters();
        }

        [Fact]
        public static void SI5066B_Tests_Fact()
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
                #endregion
                var program = new SI5066B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                //R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("RALCHEDO_OCORR_HISTORICO", out var valOr) && valOr == "0010");
                Assert.True(envList[1].TryGetValue("RALCHEDO_NUMDOC_NUM01", out var valSivpf) && valSivpf == "0000000000123");

                //R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("CHEQUEMI_TIPO_MOVIMENTO", out var valO2r) && valO2r == "1");
                Assert.True(envList1[1].TryGetValue("CHEQUEMI_COD_FONTE", out var valO3r) && valO3r == "0010");

                //R0340_INSERT_HIST_CHEQUE_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("HISTOCHE_NUM_CHEQUE_INTERNO", out var valO4r) && valO4r == "000000001");
                Assert.True(envList2[1].TryGetValue("HISTOCHE_COD_OPERACAO", out var valO5r) && valO5r == "0101");

                //R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("RALCHEDO_NUM_CHEQUE_INTERNO", out var valO6r) && valO6r == "000000001");
                Assert.True(envList3[1].TryGetValue("RALCHEDO_DIG_CHEQUE_INTERNO", out var valO7r) && valO7r == "0009");

                //R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("SINISHIS_OCORR_HISTORICO", out var valO8r) && valO8r == "0010");

                //R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1

                var envList5 = AppSettings.TestSet.DynamicData["R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5?.Count > 1);
                Assert.True(envList5[1].TryGetValue("SISINCHE_NUM_APOL_SINISTRO", out var valO9r) && valO9r == "0000000000456");
                Assert.True(envList5[1].TryGetValue("SISINCHE_COD_OPERACAO", out var val10r) && val10r == "0010");

                //R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6?.Count > 1);
                Assert.True(envList6[1].TryGetValue("MOVDEBCE_NUM_ENDOSSO", out var val12r) && val12r == "000007777");
                Assert.True(envList6[1].TryGetValue("MOVDEBCE_NUM_PARCELA", out var val13r) && val13r == "7777");

                //R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList7?.Count > 1);
                Assert.True(envList7[1].TryGetValue("GE369_NUM_ENDOSSO", out var val14r) && val14r == "000007777");
                Assert.True(envList7[1].TryGetValue("GE369_COD_CONVENIO", out var val15r) && val15r == "000043350");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void SI5066B_Tests_FactErro99()
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

                #region R0010_SELECT_SISTEMAS_Query1

                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q4);

                #endregion
                #endregion
                var program = new SI5066B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}