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
using static Code.SI5000B;

namespace FileTests.Test
{
    [Collection("SI5000B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI5000B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_DATA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R010_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R010_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region SI5000B_CALENDARIO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI5000B_CALENDARIO", q2);

            #endregion

            #region SI5000B_SINISTROS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINILT01_COD_LOT_FENAL" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
                { "SINILT01_COD_CLIENTE" , ""},
                { "SINILT01_DTINIVIG" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "HOST_VALOR_AVISADO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
                { "PARAMCON_SIT_REGISTRO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI5000B_SINISTROS", q3);

            #endregion

            #region R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1", q4);

            #endregion

            #region R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1", q5);

            #endregion

            #region R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_BANCO" , ""},
                { "LOTERI01_AGENCIA" , ""},
                { "LOTERI01_OPERACAO_CONTA" , ""},
                { "LOTERI01_NUMERO_CONTA" , ""},
                { "LOTERI01_DV_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R200_PROCESSA_SINISTRO_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
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
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R200_PROCESSA_SINISTRO_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R210_UPDATE_SINISTROS_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R210_UPDATE_SINISTROS_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R220_GRAVA_RESSARC_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SI112_NUM_APOL_SINISTRO" , ""},
                { "SI112_NUM_RESSARC" , ""},
                { "SI112_SEQ_RESSARC" , ""},
                { "SI112_COD_SISTEMA_ORIGEM" , ""},
                { "SI112_IND_PESSOA_ACORDO" , ""},
                { "SI112_NUM_CPFCGC_ACORDO" , ""},
                { "SI112_NOM_RESP_ACORDO" , ""},
                { "SI112_STA_ACORDO" , ""},
                { "SI112_DTH_ACORDO" , ""},
                { "SI112_QTD_PARCELAS" , ""},
                { "SI112_COD_CONDICAO" , ""},
                { "SI112_VLR_INDENIZACAO" , ""},
                { "SI112_DTH_INDENIZACAO" , ""},
                { "SI112_VLR_PART_TERCEIROS" , ""},
                { "SI112_COD_MOEDA_ACORDO" , ""},
                { "SI112_VLR_DIVIDA" , ""},
                { "SI112_PCT_DESCONTO" , ""},
                { "SI112_VLR_TOTAL_ACORDO" , ""},
                { "SI112_COD_FORNECEDOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R220_GRAVA_RESSARC_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SI112_NUM_RESSARC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1", q10);

            #endregion

            #region R230_GRAVA_RESSARC_PCLA_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , ""},
                { "SI111_OCORR_HISTORICO" , ""},
                { "SI111_COD_OPERACAO" , ""},
                { "SI111_NUM_RESSARC" , ""},
                { "SI111_SEQ_RESSARC" , ""},
                { "SI111_NUM_PARCELA" , ""},
                { "SI111_COD_AGENCIA_CEDENT" , ""},
                { "SI111_COD_SISTEMA_ORIGEM" , ""},
                { "SI111_NUM_CEDENTE" , ""},
                { "SI111_NUM_CEDENTE_DV" , ""},
                { "SI111_DTH_VENCIMENTO" , ""},
                { "SI111_NUM_NOSSO_TITULO" , ""},
                { "SI111_PCT_OPERACAO" , ""},
                { "SI111_IND_FORMA_BAIXA" , ""},
                { "SI111_DTH_PAGAMENTO" , ""},
                { "SI111_IND_INTEGRACAO" , ""},
                { "SI111_NUM_TITULO_SIGCB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R230_GRAVA_RESSARC_PCLA_DB_INSERT_1_Insert1", q11);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI5000B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE
                #endregion
                var program = new SI5000B();

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("SI5000B_CALENDARIO");
                q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "10-10-2001"},
                { "CALENDAR_DIA_SEMANA" , "11"},
                { "CALENDAR_FERIADO" , "22"},
            });
                AppSettings.TestSet.DynamicData.Add("SI5000B_CALENDARIO", q2);

                program.Execute(new SI5000B_LINK_PARM_CONV_PROCESSADO());

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["R200_PROCESSA_SINISTRO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("MOVDEBCE_COD_EMPRESA", out var valor) && valor == "000000000");
                Assert.True(envList[1].TryGetValue("MOVDEBCE_NUM_APOLICE", out valor) && valor == "0000000000000");

                var envList1 = AppSettings.TestSet.DynamicData["R210_UPDATE_SINISTROS_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("SINISHIS_NUM_APOL_SINISTRO", out var valor1) && valor == "0000000000000");
                Assert.True(envList1[1].TryGetValue("SINISHIS_OCORR_HISTORICO", out valor) && valor == "0000");

                Assert.True(true);
            }
        }

        [Fact]
        public static void SI5000B_Tests_Sem_Dados()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE
                #endregion
                var program = new SI5000B();

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R010_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SISTEMAS_DB_SELECT_1_Query1", q0);

                program.Execute(new SI5000B_LINK_PARM_CONV_PROCESSADO());

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}