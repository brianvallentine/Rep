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
using static Code.SI9247B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI9247B_Tests")]
    public class SI9247B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

            #endregion

            #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "SIARVRCZ_TIPO_REGISTRO" , ""},
                { "SIARVRCZ_SEQ_REGISTRO" , ""},
                { "SIARVRCZ_STA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region SI9247B_C01_SIARDEVC

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "SIARDEVC_DATA_COMUNICADO" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
                { "SIARDEVC_HORA_OCORRENCIA" , ""},
                { "SIARDEVC_DATA_MOVIMENTO" , ""},
                { "SIARDEVC_IND_FAVORECIDO" , ""},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , ""},
                { "SIARDEVC_VAL_PECAS" , ""},
                { "SIARDEVC_VAL_MAO_OBRA" , ""},
                { "SIARDEVC_VAL_PARCELA_PEND" , ""},
                { "SIARDEVC_QTD_PARCELA_PEND" , ""},
                { "SIARDEVC_VAL_DESC_PARC_PEND" , ""},
                { "SIARDEVC_DATA_NEGOCIADA" , ""},
                { "SIARDEVC_VAL_IRF" , ""},
                { "SIARDEVC_VAL_ISS" , ""},
                { "SIARDEVC_VAL_INSS" , ""},
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , ""},
                { "SIARDEVC_CGCCPF" , ""},
                { "SIARDEVC_TIPO_PESSOA" , ""},
                { "SIARDEVC_NOM_FAVORECIDO" , ""},
                { "SIARDEVC_IND_DOC_FISCAL" , ""},
                { "SIARDEVC_NUM_DOC_FISCAL" , ""},
                { "SIARDEVC_SERIE_DOC_FISCAL" , ""},
                { "SIARDEVC_DATA_EMISSAO" , ""},
                { "SIARDEVC_DES_ENDERECO" , ""},
                { "SIARDEVC_NOM_BAIRRO" , ""},
                { "SIARDEVC_NOM_CIDADE" , ""},
                { "SIARDEVC_COD_UF" , ""},
                { "SIARDEVC_NUM_CEP" , ""},
                { "SIARDEVC_NUM_DDD" , ""},
                { "SIARDEVC_NUM_TELEFONE" , ""},
                { "SIARDEVC_IND_FORMA_PAGTO" , ""},
                { "SIARDEVC_NUM_IDENTIFICADOR" , ""},
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , ""},
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , ""},
                { "SIARDEVC_ORDEM_PAGAMENTO" , ""},
                { "SIARDEVC_COD_BANCO" , ""},
                { "SIARDEVC_COD_AGENCIA" , ""},
                { "SIARDEVC_OPERACAO_CONTA" , ""},
                { "SIARDEVC_COD_CONTA" , ""},
                { "SIARDEVC_DV_CONTA" , ""},
                { "SIARDEVC_COD_FAVORECIDO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_COD_ERRO" , ""},
                { "SIARDEVC_VAL_PISPASEP" , ""},
                { "SIARDEVC_VAL_COFINS" , ""},
                { "SIARDEVC_VAL_CSLL" , ""},
                { "SIARDEVC_COD_FONTE" , ""},
                { "SIARDEVC_NUM_RESSARC" , ""},
                { "SIARDEVC_IND_PESSOA_ACORDO" , ""},
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , ""},
                { "SIARDEVC_NOM_RESP_ACORDO" , ""},
                { "SIARDEVC_STA_ACORDO" , ""},
                { "SIARDEVC_DTH_INDENIZACAO" , ""},
                { "SIARDEVC_VLR_INDENIZACAO" , ""},
                { "SIARDEVC_VLR_PART_TERCEIROS" , ""},
                { "SIARDEVC_VLR_DIVIDA" , ""},
                { "SIARDEVC_PCT_DESCONTO" , ""},
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , ""},
                { "SIARDEVC_VLR_TOTAL_ACORDO" , ""},
                { "SIARDEVC_COD_MOEDA_ACORDO" , ""},
                { "SIARDEVC_DTH_ACORDO" , ""},
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , ""},
                { "SIARDEVC_NUM_PARCELA_ACORDO" , ""},
                { "SIARDEVC_COD_AGENCIA_CEDENT" , ""},
                { "SIARDEVC_NUM_CEDENTE" , ""},
                { "SIARDEVC_NUM_CEDENTE_DV" , ""},
                { "SIARDEVC_DTH_VENCIMENTO" , ""},
                { "SIARDEVC_NUM_NOSSO_TITULO" , ""},
                { "SIARDEVC_VLR_TITULO" , ""},
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , ""},
                { "SIARDEVC_NOM_RECLAMANTE" , ""},
                { "SIARDEVC_VLR_RECLAMADO" , ""},
                { "SIARDEVC_VLR_PROVISIONADO" , ""},
                { "SIARDEVC_NUM_SINISTRO_CONV" , ""},
                { "SIARDEVC_NUM_IDENT_CONV" , ""},
                { "SIARDEVC_NUM_IDE_COBR_CONV" , ""},
                { "SIARDEVC_COD_CFOP" , ""},
                { "SIARDEVC_COD_CEST" , ""},
                { "SIARDEVC_NUM_INSCR_ESTADUAL" , ""},
                { "SIARDEVC_NUM_NCM" , ""},
                { "SIARDEVC_NUM_CPF_CNPJ_TOMADOR" , ""},
                { "SIARDEVC_IND_ISENCAO_TRIBUTO" , ""},
                { "SIARDEVC_COD_IMPOSTO_LIMINAR" , ""},
                { "SIARDEVC_COD_PROCESSO_ISENCAO" , ""},
                { "SIARDEVC_VLR_RET_N_EFETUADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9247B_C01_SIARDEVC", q5);

            #endregion

            #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "SIARREVC_TIPO_REGISTRO_VC" , ""},
                { "SIARREVC_SEQ_REGISTRO_VC" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , ""},
                { "SIARDEVC_NUM_IDENTIFICADOR" , ""},
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_TIPO_PAGAMENTO" , ""},
                { "CHEQUEMI_DATA_EMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1", q10);

            #endregion

            #region R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "LOTECHEQ_NUM_CHEQUE" , ""},
                { "LOTECHEQ_SERIE_CHEQUE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI9247B_t1")]
        public static void SI9247B_Tests_Theory_Erro99(string CSPAGSIN_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CSPAGSIN_FILE_NAME_P = $"{CSPAGSIN_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI9247B();
                program.Execute(CSPAGSIN_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI9247B_t2")]
        public static void SI9247B_Tests_Theory(string CSPAGSIN_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CSPAGSIN_FILE_NAME_P = $"{CSPAGSIN_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new SI9247B();
                program.Execute(CSPAGSIN_FILE_NAME_P);

                //R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1"].DynamicList);

                //R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1"].DynamicList);

                //R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1
                var envList = (AppSettings.TestSet.DynamicData["R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1"].DynamicList);
                Assert.True(envList[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var valor) && valor.Contains("1"));
                Assert.True(envList.Count > 1);

                //R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1
                var envList1 = (AppSettings.TestSet.DynamicData["R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1"].DynamicList);
                Assert.True(envList[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var valor1) && valor.Contains("1"));
                Assert.True(envList.Count > 1);

                //R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1
                var envList4 = (AppSettings.TestSet.DynamicData["R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1"].DynamicList);
                Assert.True(envList[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var valor4) && valor.Contains("1"));
                Assert.True(envList.Count > 1);

                //R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1
                var envList2 = (AppSettings.TestSet.DynamicData["R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1"].DynamicList);
                Assert.True(envList[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var valor2) && valor.Contains("1"));
                Assert.True(envList.Count > 1);

                //R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1
                var envList3 = (AppSettings.TestSet.DynamicData["R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1"].DynamicList);
                Assert.True(envList[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var valor3) && valor.Contains("1"));
                Assert.True(envList.Count > 1);

                //R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}