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
using static Code.CB0123B;
using System.IO;

namespace FileTests.Test
{
    [Collection("CB0123B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class CB0123B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region CB0123B_C0_PRODUTOS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("CB0123B_C0_PRODUTOS", q0);

            #endregion

            #region R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "WS_DATA_GERACAO_PARCELA" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "PARCELAS_DAC_PARCELA" , ""},
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_PRM_LIQUIDO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , ""},
                { "PARCELAS_VAL_IOCC_IX" , ""},
                { "PARCELAS_PRM_TOTAL_IX" , ""},
                { "PARCELAS_QTD_DOCUMENTOS" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "ENDOSSOS_TIPO_CORRECAO" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_CARTAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                { "OPCPAGVI_NUM_CERTIFICADO" , ""},
                { "MCIELO_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_COD_OPERACAO" , ""},
                { "AVISOCRE_TIPO_AVISO" , ""},
                { "AVISOCRE_DATA_AVISO" , ""},
                { "AVISOCRE_VAL_IOCC" , ""},
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_COSSEGURO_CED" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , ""},
                { "AVISOCRE_SIT_CONTABIL" , ""},
                { "AVISOCRE_COD_EMPRESA" , ""},
                { "AVISOCRE_ORIGEM_AVISO" , ""},
                { "AVISOCRE_VAL_ADIANTAMENTO" , ""},
                { "AVISOCRE_STA_DEPOSITO_TER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , ""},
                { "AVISOSAL_BCO_AVISO" , ""},
                { "AVISOSAL_AGE_AVISO" , ""},
                { "AVISOSAL_TIPO_SEGURO" , ""},
                { "AVISOSAL_NUM_AVISO_CREDITO" , ""},
                { "AVISOSAL_DATA_AVISO" , ""},
                { "AVISOSAL_DATA_MOVIMENTO" , ""},
                { "AVISOSAL_SALDO_ATUAL" , ""},
                { "AVISOSAL_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_CERTIFICADO" , ""},
                { "PARCEVID_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_CODRET" , ""},
                { "HISLANCT_NSAC" , ""},
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_COD_EMPRESA" , ""},
                { "CONDESCE_ANO_REFERENCIA" , ""},
                { "CONDESCE_MES_REFERENCIA" , ""},
                { "CONDESCE_BCO_AVISO" , ""},
                { "CONDESCE_AGE_AVISO" , ""},
                { "CONDESCE_NUM_AVISO_CREDITO" , ""},
                { "CONDESCE_COD_PRODUTO" , ""},
                { "CONDESCE_TIPO_REGISTRO" , ""},
                { "CONDESCE_SITUACAO" , ""},
                { "CONDESCE_TIPO_COBRANCA" , ""},
                { "CONDESCE_DATA_MOVIMENTO" , ""},
                { "CONDESCE_DATA_AVISO" , ""},
                { "CONDESCE_QTD_REGISTROS" , ""},
                { "CONDESCE_PRM_TOTAL" , ""},
                { "CONDESCE_PRM_LIQUIDO" , ""},
                { "CONDESCE_VAL_TARIFA" , ""},
                { "CONDESCE_VAL_BALCAO" , ""},
                { "CONDESCE_VAL_IOCC" , ""},
                { "CONDESCE_VAL_DESCONTO" , ""},
                { "CONDESCE_VAL_JUROS" , ""},
                { "CONDESCE_VAL_MULTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_HORA_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCEHIS_NUM_AVISO_CREDITO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_COD_USUARIO" , ""},
                { "PARCEHIS_RENUM_DOCUMENTO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1", q19);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB0123B_i1.txt")]
        public static void CB0123B_Tests_Theory(string CCADESAO_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region CB0123B_C0_PRODUTOS

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_COD_PRODUTO" , "123456" }
                });
                AppSettings.TestSet.DynamicData.Remove("CB0123B_C0_PRODUTOS");
                AppSettings.TestSet.DynamicData.Add("CB0123B_C0_PRODUTOS", q0);

                #endregion

                #region R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , "AC202312001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , "CERT202312001" },
                { "HISLANCT_NUM_PARCELA" , "1" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Pagamento recebido" },
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "PROPOVA_SIT_REGISTRO" , "2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT202312002" },
                { "HISCONPA_NUM_PARCELA" , "1" },
                { "HISCONPA_NUM_ENDOSSO" , "END202312001" },
                { "HISCONPA_NUM_APOLICE" , "AP202312001" },
                { "HISCONPA_SIT_REGISTRO" , "Ativo" },
                { "PARCELAS_DAC_PARCELA" , "DAC202312001" },
                { "PARCELAS_PRM_TARIFARIO_IX" , "100.00" },
                { "PARCELAS_VAL_DESCONTO_IX" , "5.00" },
                { "PARCELAS_PRM_LIQUIDO_IX" , "95.00" },
                { "PARCELAS_ADICIONAL_FRAC_IX" , "2.00" },
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , "1.50" },
                { "PARCELAS_VAL_IOCC_IX" , "0.50" },
                { "PARCELAS_PRM_TOTAL_IX" , "98.50" },
                { "PARCELAS_QTD_DOCUMENTOS" , "3" },
                { "PROPOVA_COD_PRODUTO" , "0" },
                { "ENDOSSOS_TIPO_CORRECAO" , "Monetária" },
                { "ENDOSSOS_COD_MOEDA_PRM" , "BRL" },
                { "ENDOSSOS_COD_USUARIO" , "USR123" },
                { "COBHISVI_NUM_TITULO" , "TIT202312001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , "CERT202312003" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "5555444433332222" },
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "5" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_CARTAO" , "5555444433331111" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "" },
                { "OPCPAGVI_NUM_CERTIFICADO" , "CERT202312003" },
                { "MCIELO_DATA_VENCIMENTO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "EMP123" },
                { "MOVIMCOB_COD_MOVIMENTO" , "MOV202312001" },
                { "MOVIMCOB_COD_BANCO" , "001" },
                { "MOVIMCOB_COD_AGENCIA" , "0001" },
                { "MOVIMCOB_NUM_AVISO" , "AV202312001" },
                { "MOVIMCOB_NUM_FITA" , "FITA001" },
                { "MOVIMCOB_DATA_MOVIMENTO" , "2023-12-01" },
                { "MOVIMCOB_DATA_QUITACAO" , "2023-12-10" },
                { "MOVIMCOB_NUM_TITULO" , "TIT202312002" },
                { "MOVIMCOB_NUM_APOLICE" , "AP202312002" },
                { "MOVIMCOB_NUM_ENDOSSO" , "END202312002" },
                { "MOVIMCOB_NUM_PARCELA" , "3" },
                { "MOVIMCOB_VAL_TITULO" , "150.00" },
                { "MOVIMCOB_VAL_IOCC" , "0.75" },
                { "MOVIMCOB_VAL_CREDITO" , "149.25" },
                { "MOVIMCOB_SIT_REGISTRO" , "Quitado" },
                { "MOVIMCOB_NOME_SEGURADO" , "João Silva" },
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Pagamento" },
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "NT202312001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , "237" },
                { "AVISOCRE_AGE_AVISO" , "1234" },
                { "AVISOCRE_NUM_AVISO_CREDITO" , "AC202312001" },
                { "AVISOCRE_NUM_SEQUENCIA" , "SEQ001" },
                { "AVISOCRE_DATA_MOVIMENTO" , "2023-12-01" },
                { "AVISOCRE_COD_OPERACAO" , "OP123" },
                { "AVISOCRE_TIPO_AVISO" , "Crédito" },
                { "AVISOCRE_DATA_AVISO" , "2023-12-01" },
                { "AVISOCRE_VAL_IOCC" , "0.75" },
                { "AVISOCRE_VAL_DESPESA" , "10.00" },
                { "AVISOCRE_PRM_COSSEGURO_CED" , "20.00" },
                { "AVISOCRE_PRM_LIQUIDO" , "130.00" },
                { "AVISOCRE_PRM_TOTAL" , "150.00" },
                { "AVISOCRE_SIT_CONTABIL" , "Confirmado" },
                { "AVISOCRE_COD_EMPRESA" , "EMP123" },
                { "AVISOCRE_ORIGEM_AVISO" , "Interna" },
                { "AVISOCRE_VAL_ADIANTAMENTO" , "50.00" },
                { "AVISOCRE_STA_DEPOSITO_TER" , "Pendente" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , "EMP123" },
                { "AVISOSAL_BCO_AVISO" , "001" },
                { "AVISOSAL_AGE_AVISO" , "0001" },
                { "AVISOSAL_TIPO_SEGURO" , "Vida" },
                { "AVISOSAL_NUM_AVISO_CREDITO" , "AC202312002" },
                { "AVISOSAL_DATA_AVISO" , "2023-12-01" },
                { "AVISOSAL_DATA_MOVIMENTO" , "2023-12-01" },
                { "AVISOSAL_SALDO_ATUAL" , "1000.00" },
                { "AVISOSAL_SIT_REGISTRO" , "Ativo" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_AGENCIA" , "0001" },
                { "MOVIMCOB_NUM_AVISO" , "AV202312001" },
                { "MOVIMCOB_COD_BANCO" , "001" },
                { "HISCONPA_NUM_CERTIFICADO" , "CERT202312002" },
                { "HISCONPA_NUM_PARCELA" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_CERTIFICADO" , "CERT202312004" },
                { "PARCEVID_NUM_PARCELA" , "4" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT202312002" },
                { "HISCONPA_NUM_PARCELA" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_CODRET" , "+100" },
                { "HISLANCT_NSAC" , "NSAC202312001" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Pagamento recebido" },
                { "HISLANCT_NUM_CERTIFICADO" , "CERT202312001" },
                { "HISLANCT_NUM_PARCELA" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_COD_EMPRESA" , "EMP123" },
                { "CONDESCE_ANO_REFERENCIA" , "2023" },
                { "CONDESCE_MES_REFERENCIA" , "12" },
                { "CONDESCE_BCO_AVISO" , "001" },
                { "CONDESCE_AGE_AVISO" , "0001" },
                { "CONDESCE_NUM_AVISO_CREDITO" , "AC202312003" },
                { "CONDESCE_COD_PRODUTO" , "789012" },
                { "CONDESCE_TIPO_REGISTRO" , "Normal" },
                { "CONDESCE_SITUACAO" , "Ativo" },
                { "CONDESCE_TIPO_COBRANCA" , "Direta" },
                { "CONDESCE_DATA_MOVIMENTO" , "2023-12-01" },
                { "CONDESCE_DATA_AVISO" , "2023-12-01" },
                { "CONDESCE_QTD_REGISTROS" , "5" },
                { "CONDESCE_PRM_TOTAL" , "500.00" },
                { "CONDESCE_PRM_LIQUIDO" , "485.00" },
                { "CONDESCE_VAL_TARIFA" , "15.00" },
                { "CONDESCE_VAL_BALCAO" , "0.00" },
                { "CONDESCE_VAL_IOCC" , "0.50" },
                { "CONDESCE_VAL_DESCONTO" , "5.00" },
                { "CONDESCE_VAL_JUROS" , "2.50" },
                { "CONDESCE_VAL_MULTA" , "1.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q15);

                #endregion

                #region R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_VENCIMENTO" , "2024-01-01" },
                { "PARCEHIS_OCORR_HISTORICO" , "Pagamento efetuado" },
                { "PARCEHIS_PRM_TARIFARIO" , "200.00" },
                { "PARCEHIS_VAL_DESCONTO" , "10.00" },
                { "PARCEHIS_PRM_LIQUIDO" , "190.00" },
                { "PARCEHIS_ADICIONAL_FRACIO" , "3.00" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , "2.00" },
                { "PARCEHIS_VAL_IOCC" , "0.60" },
                { "PARCEHIS_PRM_TOTAL" , "195.60" },
                { "PARCEHIS_NUM_PARCELA" , "5" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "AP202312003" },
                { "PARCEHIS_NUM_ENDOSSO" , "END202312003" },
                { "PARCEHIS_NUM_PARCELA" , "5" },
                { "PARCEHIS_DAC_PARCELA" , "DAC202312002" },
                { "PARCEHIS_DATA_MOVIMENTO" , "2023-12-01" },
                { "PARCEHIS_COD_OPERACAO" , "OP124" },
                { "PARCEHIS_HORA_OPERACAO" , "14:00" },
                { "PARCEHIS_OCORR_HISTORICO" , "Pagamento efetuado" },
                { "PARCEHIS_PRM_TARIFARIO" , "200.00" },
                { "PARCEHIS_VAL_DESCONTO" , "10.00" },
                { "PARCEHIS_PRM_LIQUIDO" , "190.00" },
                { "PARCEHIS_ADICIONAL_FRACIO" , "3.00" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , "2.00" },
                { "PARCEHIS_VAL_IOCC" , "0.60" },
                { "PARCEHIS_PRM_TOTAL" , "195.60" },
                { "PARCEHIS_VAL_OPERACAO" , "195.60" },
                { "PARCEHIS_DATA_VENCIMENTO" , "2024-01-01" },
                { "PARCEHIS_BCO_COBRANCA" , "237" },
                { "PARCEHIS_AGE_COBRANCA" , "1234" },
                { "PARCEHIS_NUM_AVISO_CREDITO" , "AC202312004" },
                { "PARCEHIS_ENDOS_CANCELA" , "Não" },
                { "PARCEHIS_SIT_CONTABIL" , "Confirmado" },
                { "PARCEHIS_COD_USUARIO" , "USR124" },
                { "PARCEHIS_RENUM_DOCUMENTO" , "DOC202312001" },
                { "PARCEHIS_DATA_QUITACAO" , "2023-12-10" },
                { "PARCEHIS_COD_EMPRESA" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1", q17);

                #endregion

                #region R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , "Pagamento efetuado" },
                { "HISCONPA_NUM_APOLICE" , "AP202312001" },
                { "HISCONPA_NUM_ENDOSSO" , "END202312001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1", q18);

                #endregion

                #region R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "AP202312001" },
                { "HISCONPA_NUM_ENDOSSO" , "END202312001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1", q19);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new CB0123B();
                program.Execute(CCADESAO_FILE_NAME_P);

                Assert.True(File.Exists(program.CCADESAO.FilePath));
                Assert.True(new FileInfo(program.CCADESAO.FilePath).Length > 0);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= 1);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("CB0123_i1.txt")]
        public static void CB0123B_Tests_ReturnCode99_Theory(string CCADESAO_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region CB0123B_C0_PRODUTOS

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_COD_PRODUTO" , "123456" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("CB0123B_C0_PRODUTOS");
                AppSettings.TestSet.DynamicData.Add("CB0123B_C0_PRODUTOS", q0);

                #endregion

                #region R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , "AC202312001" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , "CERT202312001" },
                { "HISLANCT_NUM_PARCELA" , "1" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Pagamento recebido" },
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "PROPOVA_SIT_REGISTRO" , "2" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT202312002" },
                { "HISCONPA_NUM_PARCELA" , "1" },
                { "HISCONPA_NUM_ENDOSSO" , "END202312001" },
                { "HISCONPA_NUM_APOLICE" , "AP202312001" },
                { "HISCONPA_SIT_REGISTRO" , "Ativo" },
                { "PARCELAS_DAC_PARCELA" , "DAC202312001" },
                { "PARCELAS_PRM_TARIFARIO_IX" , "100.00" },
                { "PARCELAS_VAL_DESCONTO_IX" , "5.00" },
                { "PARCELAS_PRM_LIQUIDO_IX" , "95.00" },
                { "PARCELAS_ADICIONAL_FRAC_IX" , "2.00" },
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , "1.50" },
                { "PARCELAS_VAL_IOCC_IX" , "0.50" },
                { "PARCELAS_PRM_TOTAL_IX" , "98.50" },
                { "PARCELAS_QTD_DOCUMENTOS" , "3" },
                { "PROPOVA_COD_PRODUTO" , "0" },
                { "ENDOSSOS_TIPO_CORRECAO" , "Monetária" },
                { "ENDOSSOS_COD_MOEDA_PRM" , "BRL" },
                { "ENDOSSOS_COD_USUARIO" , "USR123" },
                { "COBHISVI_NUM_TITULO" , "TIT202312001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , "CERT202312003" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "5555444433332222" },
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "5" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_CARTAO" , "5555444433331111" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "" },
                { "OPCPAGVI_NUM_CERTIFICADO" , "CERT202312003" },
                { "MCIELO_DATA_VENCIMENTO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "EMP123" },
                { "MOVIMCOB_COD_MOVIMENTO" , "MOV202312001" },
                { "MOVIMCOB_COD_BANCO" , "001" },
                { "MOVIMCOB_COD_AGENCIA" , "0001" },
                { "MOVIMCOB_NUM_AVISO" , "AV202312001" },
                { "MOVIMCOB_NUM_FITA" , "FITA001" },
                { "MOVIMCOB_DATA_MOVIMENTO" , "2023-12-01" },
                { "MOVIMCOB_DATA_QUITACAO" , "2023-12-10" },
                { "MOVIMCOB_NUM_TITULO" , "TIT202312002" },
                { "MOVIMCOB_NUM_APOLICE" , "AP202312002" },
                { "MOVIMCOB_NUM_ENDOSSO" , "END202312002" },
                { "MOVIMCOB_NUM_PARCELA" , "3" },
                { "MOVIMCOB_VAL_TITULO" , "150.00" },
                { "MOVIMCOB_VAL_IOCC" , "0.75" },
                { "MOVIMCOB_VAL_CREDITO" , "149.25" },
                { "MOVIMCOB_SIT_REGISTRO" , "Quitado" },
                { "MOVIMCOB_NOME_SEGURADO" , "João Silva" },
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Pagamento" },
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "NT202312001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , "237" },
                { "AVISOCRE_AGE_AVISO" , "1234" },
                { "AVISOCRE_NUM_AVISO_CREDITO" , "AC202312001" },
                { "AVISOCRE_NUM_SEQUENCIA" , "SEQ001" },
                { "AVISOCRE_DATA_MOVIMENTO" , "2023-12-01" },
                { "AVISOCRE_COD_OPERACAO" , "OP123" },
                { "AVISOCRE_TIPO_AVISO" , "Crédito" },
                { "AVISOCRE_DATA_AVISO" , "2023-12-01" },
                { "AVISOCRE_VAL_IOCC" , "0.75" },
                { "AVISOCRE_VAL_DESPESA" , "10.00" },
                { "AVISOCRE_PRM_COSSEGURO_CED" , "20.00" },
                { "AVISOCRE_PRM_LIQUIDO" , "130.00" },
                { "AVISOCRE_PRM_TOTAL" , "150.00" },
                { "AVISOCRE_SIT_CONTABIL" , "Confirmado" },
                { "AVISOCRE_COD_EMPRESA" , "EMP123" },
                { "AVISOCRE_ORIGEM_AVISO" , "Interna" },
                { "AVISOCRE_VAL_ADIANTAMENTO" , "50.00" },
                { "AVISOCRE_STA_DEPOSITO_TER" , "Pendente" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , "EMP123" },
                { "AVISOSAL_BCO_AVISO" , "001" },
                { "AVISOSAL_AGE_AVISO" , "0001" },
                { "AVISOSAL_TIPO_SEGURO" , "Vida" },
                { "AVISOSAL_NUM_AVISO_CREDITO" , "AC202312002" },
                { "AVISOSAL_DATA_AVISO" , "2023-12-01" },
                { "AVISOSAL_DATA_MOVIMENTO" , "2023-12-01" },
                { "AVISOSAL_SALDO_ATUAL" , "1000.00" },
                { "AVISOSAL_SIT_REGISTRO" , "Ativo" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_AGENCIA" , "0001" },
                { "MOVIMCOB_NUM_AVISO" , "AV202312001" },
                { "MOVIMCOB_COD_BANCO" , "001" },
                { "HISCONPA_NUM_CERTIFICADO" , "CERT202312002" },
                { "HISCONPA_NUM_PARCELA" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_CERTIFICADO" , "CERT202312004" },
                { "PARCEVID_NUM_PARCELA" , "4" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT202312002" },
                { "HISCONPA_NUM_PARCELA" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_CODRET" , "+100" },
                { "HISLANCT_NSAC" , "NSAC202312001" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Pagamento recebido" },
                { "HISLANCT_NUM_CERTIFICADO" , "CERT202312001" },
                { "HISLANCT_NUM_PARCELA" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_COD_EMPRESA" , "EMP123" },
                { "CONDESCE_ANO_REFERENCIA" , "2023" },
                { "CONDESCE_MES_REFERENCIA" , "12" },
                { "CONDESCE_BCO_AVISO" , "001" },
                { "CONDESCE_AGE_AVISO" , "0001" },
                { "CONDESCE_NUM_AVISO_CREDITO" , "AC202312003" },
                { "CONDESCE_COD_PRODUTO" , "789012" },
                { "CONDESCE_TIPO_REGISTRO" , "Normal" },
                { "CONDESCE_SITUACAO" , "Ativo" },
                { "CONDESCE_TIPO_COBRANCA" , "Direta" },
                { "CONDESCE_DATA_MOVIMENTO" , "2023-12-01" },
                { "CONDESCE_DATA_AVISO" , "2023-12-01" },
                { "CONDESCE_QTD_REGISTROS" , "5" },
                { "CONDESCE_PRM_TOTAL" , "500.00" },
                { "CONDESCE_PRM_LIQUIDO" , "485.00" },
                { "CONDESCE_VAL_TARIFA" , "15.00" },
                { "CONDESCE_VAL_BALCAO" , "0.00" },
                { "CONDESCE_VAL_IOCC" , "0.50" },
                { "CONDESCE_VAL_DESCONTO" , "5.00" },
                { "CONDESCE_VAL_JUROS" , "2.50" },
                { "CONDESCE_VAL_MULTA" , "1.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q15);

                #endregion

                #region R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_VENCIMENTO" , "2024-01-01" },
                { "PARCEHIS_OCORR_HISTORICO" , "Pagamento efetuado" },
                { "PARCEHIS_PRM_TARIFARIO" , "200.00" },
                { "PARCEHIS_VAL_DESCONTO" , "10.00" },
                { "PARCEHIS_PRM_LIQUIDO" , "190.00" },
                { "PARCEHIS_ADICIONAL_FRACIO" , "3.00" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , "2.00" },
                { "PARCEHIS_VAL_IOCC" , "0.60" },
                { "PARCEHIS_PRM_TOTAL" , "195.60" },
                { "PARCEHIS_NUM_PARCELA" , "5" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "AP202312003" },
                { "PARCEHIS_NUM_ENDOSSO" , "END202312003" },
                { "PARCEHIS_NUM_PARCELA" , "5" },
                { "PARCEHIS_DAC_PARCELA" , "DAC202312002" },
                { "PARCEHIS_DATA_MOVIMENTO" , "2023-12-01" },
                { "PARCEHIS_COD_OPERACAO" , "OP124" },
                { "PARCEHIS_HORA_OPERACAO" , "14:00" },
                { "PARCEHIS_OCORR_HISTORICO" , "Pagamento efetuado" },
                { "PARCEHIS_PRM_TARIFARIO" , "200.00" },
                { "PARCEHIS_VAL_DESCONTO" , "10.00" },
                { "PARCEHIS_PRM_LIQUIDO" , "190.00" },
                { "PARCEHIS_ADICIONAL_FRACIO" , "3.00" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , "2.00" },
                { "PARCEHIS_VAL_IOCC" , "0.60" },
                { "PARCEHIS_PRM_TOTAL" , "195.60" },
                { "PARCEHIS_VAL_OPERACAO" , "195.60" },
                { "PARCEHIS_DATA_VENCIMENTO" , "2024-01-01" },
                { "PARCEHIS_BCO_COBRANCA" , "237" },
                { "PARCEHIS_AGE_COBRANCA" , "1234" },
                { "PARCEHIS_NUM_AVISO_CREDITO" , "AC202312004" },
                { "PARCEHIS_ENDOS_CANCELA" , "Não" },
                { "PARCEHIS_SIT_CONTABIL" , "Confirmado" },
                { "PARCEHIS_COD_USUARIO" , "USR124" },
                { "PARCEHIS_RENUM_DOCUMENTO" , "DOC202312001" },
                { "PARCEHIS_DATA_QUITACAO" , "2023-12-10" },
                { "PARCEHIS_COD_EMPRESA" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1", q17);

                #endregion

                #region R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , "Pagamento efetuado" },
                { "HISCONPA_NUM_APOLICE" , "AP202312001" },
                { "HISCONPA_NUM_ENDOSSO" , "END202312001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1", q18);

                #endregion

                #region R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "AP202312001" },
                { "HISCONPA_NUM_ENDOSSO" , "END202312001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1", q19);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new CB0123B();
                program.Execute(CCADESAO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}