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
using static Code.VE0123B;

namespace FileTests.Test
{
    [Collection("VE0123B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE0123B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VE0123B_CURS01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_OCOREND" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_PROPOSTA" , ""},
                { "PROPOVA_STA_MUDANCA_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0123B_CURS01", q0);

            #endregion

            #region VE0123B_CURS02

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , ""},
                { "MOEDACOT_VAL_VENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0123B_CURS02", q1);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DTMOV_ABERTO" , ""},
                { "SISTEMAS_DTTER_COTACAO" , ""},
                { "SISTEMAS_DTINI_COTACAO" , ""},
                { "SISTEMAS_DTMOV_ABERTO_30" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DTANIVERS" , ""},
                { "WS_DTANIVERS_1" , ""},
                { "WS_DTANIVERS_2" , ""},
                { "WS_DTANIVERS_3" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "111"},
                { "PROPOVA_COD_OPERACAO" , ""},
                { "WS_DTANIVERS" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AUT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "WS_NUM_PROPOSTA_AUT" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "PROPOVA_OCOREND" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "W_DIG_CONTA" , ""},
                { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                { "MOVIMVGA_IMP_MORACID_ANT" , ""},
                { "MOVIMVGA_IMP_MORACID_ATU" , ""},
                { "MOVIMVGA_IMP_INVPERM_ANT" , ""},
                { "MOVIMVGA_IMP_INVPERM_ATU" , ""},
                { "MOVIMVGA_IMP_AMDS_ANT" , ""},
                { "MOVIMVGA_IMP_AMDS_ATU" , ""},
                { "MOVIMVGA_IMP_DH_ANT" , ""},
                { "MOVIMVGA_IMP_DH_ATU" , ""},
                { "MOVIMVGA_IMP_DIT_ANT" , ""},
                { "MOVIMVGA_IMP_DIT_ATU" , ""},
                { "MOVIMVGA_PRM_VG_ANT" , ""},
                { "MOVIMVGA_PRM_VG_ATU" , ""},
                { "MOVIMVGA_PRM_AP_ANT" , ""},
                { "MOVIMVGA_PRM_AP_ATU" , ""},
                { "SISTEMAS_DTMOV_ABERTO" , ""},
                { "WS_DTANIVERS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AUT" , ""},
                { "PROPOVA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_DATA_INIVIGENCIA" , ""},
                { "SUBGVGAP_DATA_TERVIGENCIA" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_DTANIVERS_3" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1", q12);

            #endregion

            #region R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPOVA_DATA_QUITACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1", q13);

            #endregion

            #region R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q14);

            #endregion

            #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1", q15);

            #endregion

            #region R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_COD_USUARIO" , ""},
                { "HISCOBPR_TIMESTAMP" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "HISCOBPR_PRMDIT" , ""},
                { "HISCOBPR_QTMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1", q16);

            #endregion

            #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "PROPOVA_COD_OPERACAO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1", q17);

            #endregion

            #region R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , ""},
                { "OPCPAGVI_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_USUARIO" , ""},
                { "OPCPAGVI_TIMESTAMP" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q18);

            #endregion

            #region R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , ""},
                { "OPCPAGVI_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_USUARIO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "HISCOBPR_PRMDIT" , ""},
                { "HISCOBPR_QTMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_MES_REFERENCIA" , ""},
                { "RELATORI_ANO_REFERENCIA" , ""},
                { "RELATORI_ORGAO_EMISSOR" , ""},
                { "RELATORI_COD_FONTE" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_COD_MODALIDADE" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_PLANO" , ""},
                { "RELATORI_OCORR_HISTORICO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
                { "RELATORI_ENDOS_LIDER" , ""},
                { "RELATORI_NUM_PARC_LIDER" , ""},
                { "RELATORI_NUM_SINISTRO" , ""},
                { "RELATORI_NUM_SINI_LIDER" , ""},
                { "RELATORI_NUM_ORDEM" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
                { "RELATORI_COD_EMPRESA" , ""},
                { "RELATORI_PERI_RENOVACAO" , ""},
                { "RELATORI_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1", q21);

            #endregion

            #endregion
        }

        [Fact]
        public static void VE0123B_Tests_Fact_ReturnCode00()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                GEJVS002_Tests.Load_Parameters();
                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region VE0123B_CURS01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
                { "PROPOVA_COD_CLIENTE" , "123456789" },
                { "PROPOVA_OCOREND" , "1001" },
                { "PROPOVA_COD_FONTE" , "2001" },
                { "PROPOVA_AGE_COBRANCA" , "3001" },
                { "PROPOVA_OCORR_HISTORICO" , "Incidente reportado" },
                { "PROPOVA_DATA_QUITACAO" , "2023-12-15" },
                { "PROPOVA_DATA_VENCIMENTO" , "2024-01-15" },
                { "PROPOVA_DTPROXVEN" , "2024-02-15" },
                { "PROPOVA_NUM_PARCELA" , "1" },
                { "PROPOVA_COD_PRODUTO" , "8209" },
                { "PROPOVA_NUM_PROPOSTA" , "123456" },
                { "PROPOVA_STA_MUDANCA_PLANO" , "S" },
            });
               
                AppSettings.TestSet.DynamicData.Remove("VE0123B_CURS01");
AppSettings.TestSet.DynamicData.Add("VE0123B_CURS01", q0);

                #endregion

                #region VE0123B_CURS02

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , "2023-01-01" },
                { "MOEDACOT_VAL_VENDA" , "3.75" },
            });

                q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , "2023-02-01" },
                { "MOEDACOT_VAL_VENDA" , "3.25" },
            });
                AppSettings.TestSet.DynamicData.Remove("VE0123B_CURS02");
AppSettings.TestSet.DynamicData.Add("VE0123B_CURS02", q1);

                #endregion

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DTMOV_ABERTO" , "2023-12-01" },
                { "SISTEMAS_DTTER_COTACAO" , "2023-12-10" },
                { "SISTEMAS_DTINI_COTACAO" , "2023-12-01" },
                { "SISTEMAS_DTMOV_ABERTO_30" , "2023-12-31" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "150" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DTANIVERS" , "1990-05-20" },
                { "WS_DTANIVERS_1" , "1991-06-21" },
                { "WS_DTANIVERS_2" , "1992-07-22" },
                { "WS_DTANIVERS_3" , "1993-08-23" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-12-31" },
                { "HISCOBPR_OCORR_HISTORICO" , "" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "" },
                { "PROPOVA_COD_OPERACAO" , "4001" },
                { "WS_DTANIVERS" , "1990-05-20" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AUT" , "654321" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_COD_FONTE" , "2001" },
                { "WS_NUM_PROPOSTA_AUT" , "654321" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
                { "PROPOVA_COD_CLIENTE" , "123456789" },
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" },
                { "PROPOVA_OCOREND" , "1001" },
                { "PROPOVA_AGE_COBRANCA" , "3001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "123456789012" },
                { "W_DIG_CONTA" , "5" },
                { "MOVIMVGA_IMP_MORNATU_ANT" , "10000" },
                { "MOVIMVGA_IMP_MORNATU_ATU" , "10500" },
                { "MOVIMVGA_IMP_MORACID_ANT" , "5000" },
                { "MOVIMVGA_IMP_MORACID_ATU" , "5500" },
                { "MOVIMVGA_IMP_INVPERM_ANT" , "2000" },
                { "MOVIMVGA_IMP_INVPERM_ATU" , "2100" },
                { "MOVIMVGA_IMP_AMDS_ANT" , "1500" },
                { "MOVIMVGA_IMP_AMDS_ATU" , "1600" },
                { "MOVIMVGA_IMP_DH_ANT" , "1200" },
                { "MOVIMVGA_IMP_DH_ATU" , "1300" },
                { "MOVIMVGA_IMP_DIT_ANT" , "1100" },
                { "MOVIMVGA_IMP_DIT_ATU" , "1150" },
                { "MOVIMVGA_PRM_VG_ANT" , "300" },
                { "MOVIMVGA_PRM_VG_ATU" , "315" },
                { "MOVIMVGA_PRM_AP_ANT" , "200" },
                { "MOVIMVGA_PRM_AP_ATU" , "210" },
                { "SISTEMAS_DTMOV_ABERTO" , "2023-12-01" },
                { "WS_DTANIVERS" , "1990-05-20" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AUT" , "654321" },
                { "PROPOVA_COD_FONTE" , "2001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1", q9);

                #endregion

                #region R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "8209" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_NUM_APOLICE" , "123456789" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1", q10);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , "Trimestral" },
                { "SUBGVGAP_DATA_INIVIGENCIA" , "2023-01-01" },
                { "SUBGVGAP_DATA_TERVIGENCIA" , "2023-12-31" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_NUM_APOLICE" , "123456789" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_DTANIVERS_3" , "1993-08-23" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1");
AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1", q12);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPOVA_DATA_QUITACAO" , "2023-12-15" }
            });
            AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1", q13);

                #endregion

                #region R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "111" }
            });
                q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "112" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q14);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "" }
            });
               
                AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1");
AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1", q15);

                #endregion

                #region R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "987654321" },
                { "HISCOBPR_OCORR_HISTORICO" , "111" },
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-12-31" },
                { "HISCOBPR_IMPSEGUR" , "0" },
                { "HISCOBPR_QUANT_VIDAS" , "0" },
                { "HISCOBPR_IMPSEGIND" , "0" },
                { "HISCOBPR_COD_OPERACAO" , "0" },
                { "HISCOBPR_OPCAO_COBERTURA" , "" },
                { "HISCOBPR_IMP_MORNATU" , "" },
                { "HISCOBPR_IMPMORACID" , "" },
                { "HISCOBPR_IMPINVPERM" , "" },
                { "HISCOBPR_IMPAMDS" , "" },
                { "HISCOBPR_IMPDH" , "" },
                { "HISCOBPR_IMPDIT" , "" },
                { "HISCOBPR_VLPREMIO" , "" },
                { "HISCOBPR_PRMVG" , "" },
                { "HISCOBPR_PRMAP" , "" },
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "" },
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "" },
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "" },
                { "HISCOBPR_IMPSEGCDG" , "" },
                { "HISCOBPR_VLCUSTCDG" , "" },
                { "HISCOBPR_COD_USUARIO" , "" },
                { "HISCOBPR_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "HISCOBPR_IMPSEGAUXF" , "" },
                { "HISCOBPR_VLCUSTAUXF" , "" },
                { "HISCOBPR_PRMDIT" , "" },
                { "HISCOBPR_QTMDIT" , "" },
            });
                q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "987654321" },
                { "HISCOBPR_OCORR_HISTORICO" , "112" },
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-12-31" },
                { "HISCOBPR_IMPSEGUR" , "0" },
                { "HISCOBPR_QUANT_VIDAS" , "0" },
                { "HISCOBPR_IMPSEGIND" , "0" },
                { "HISCOBPR_COD_OPERACAO" , "0" },
                { "HISCOBPR_OPCAO_COBERTURA" , "" },
                { "HISCOBPR_IMP_MORNATU" , "" },
                { "HISCOBPR_IMPMORACID" , "" },
                { "HISCOBPR_IMPINVPERM" , "" },
                { "HISCOBPR_IMPAMDS" , "" },
                { "HISCOBPR_IMPDH" , "" },
                { "HISCOBPR_IMPDIT" , "" },
                { "HISCOBPR_VLPREMIO" , "" },
                { "HISCOBPR_PRMVG" , "" },
                { "HISCOBPR_PRMAP" , "" },
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "" },
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "" },
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "" },
                { "HISCOBPR_IMPSEGCDG" , "" },
                { "HISCOBPR_VLCUSTCDG" , "" },
                { "HISCOBPR_COD_USUARIO" , "" },
                { "HISCOBPR_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "HISCOBPR_IMPSEGAUXF" , "" },
                { "HISCOBPR_VLCUSTAUXF" , "" },
                { "HISCOBPR_PRMDIT" , "" },
                { "HISCOBPR_QTMDIT" , "" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1", q16);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "111" },
                { "PROPOVA_COD_OPERACAO" , "4001" },
                { "PROPOVA_COD_PRODUTO" , "8209" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1");
AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1", q17);

                #endregion

                #region R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , "987654321" },
                { "OPCPAGVI_DATA_INIVIGENCIA" , "2023-01-01" },
                { "OPCPAGVI_DATA_TERVIGENCIA" , "2023-12-31" },
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "Débito Automático" },
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" },
                { "OPCPAGVI_DIA_DEBITO" , "15" },
                { "OPCPAGVI_COD_USUARIO" , "user123" },
                { "OPCPAGVI_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "001" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "Operação 001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "123456789012" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "5" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "1234567890123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q18);

                #endregion

                #region R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , "987654321" },
                { "OPCPAGVI_DATA_INIVIGENCIA" , "2023-01-01" },
                { "OPCPAGVI_DATA_TERVIGENCIA" , "2023-12-31" },
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "Débito Automático" },
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" },
                { "OPCPAGVI_DIA_DEBITO" , "15" },
                { "OPCPAGVI_COD_USUARIO" , "user123" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "001" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "Operação 001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "123456789012" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "5" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "1234567890123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1", q19);

                #endregion

                #region R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "987654321" },
                { "HISCOBPR_OCORR_HISTORICO" , "111" },
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-12-31" },
                { "HISCOBPR_IMPSEGUR" , "500000" },
                { "HISCOBPR_QUANT_VIDAS" , "100" },
                { "HISCOBPR_IMPSEGIND" , "5000" },
                { "HISCOBPR_COD_OPERACAO" , "4001" },
                { "HISCOBPR_OPCAO_COBERTURA" , "Básica" },
                { "HISCOBPR_IMP_MORNATU" , "10000" },
                { "HISCOBPR_IMPMORACID" , "5000" },
                { "HISCOBPR_IMPINVPERM" , "2000" },
                { "HISCOBPR_IMPAMDS" , "1500" },
                { "HISCOBPR_IMPDH" , "1200" },
                { "HISCOBPR_IMPDIT" , "1100" },
                { "HISCOBPR_VLPREMIO" , "450" },
                { "HISCOBPR_PRMVG" , "300" },
                { "HISCOBPR_PRMAP" , "150" },
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "50" },
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "100" },
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "5" },
                { "HISCOBPR_IMPSEGCDG" , "250000" },
                { "HISCOBPR_VLCUSTCDG" , "12500" },
                { "HISCOBPR_IMPSEGAUXF" , "75000" },
                { "HISCOBPR_VLCUSTAUXF" , "3750" },
                { "HISCOBPR_PRMDIT" , "50" },
                { "HISCOBPR_QTMDIT" , "10" },
            });
            AppSettings.TestSet.DynamicData.Remove("R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "user123" },
                { "RELATORI_DATA_SOLICITACAO" , "2023-12-01" },
                { "RELATORI_IDE_SISTEMA" , "Sistema XYZ" },
                { "RELATORI_COD_RELATORIO" , "RPT001" },
                { "RELATORI_NUM_COPIAS" , "2" },
                { "RELATORI_QUANTIDADE" , "100" },
                { "RELATORI_PERI_INICIAL" , "2023-01-01" },
                { "RELATORI_PERI_FINAL" , "2023-12-31" },
                { "RELATORI_DATA_REFERENCIA" , "2023-12-01" },
                { "RELATORI_MES_REFERENCIA" , "12" },
                { "RELATORI_ANO_REFERENCIA" , "2023" },
                { "RELATORI_ORGAO_EMISSOR" , "Orgão XYZ" },
                { "RELATORI_COD_FONTE" , "2001" },
                { "RELATORI_COD_PRODUTOR" , "Produtor XYZ" },
                { "RELATORI_RAMO_EMISSOR" , "Ramo XYZ" },
                { "RELATORI_COD_MODALIDADE" , "Modalidade XYZ" },
                { "RELATORI_COD_CONGENERE" , "Congênere XYZ" },
                { "RELATORI_NUM_APOLICE" , "123456789" },
                { "RELATORI_NUM_ENDOSSO" , "987654321" },
                { "RELATORI_NUM_PARCELA" , "1" },
                { "RELATORI_NUM_CERTIFICADO" , "987654321" },
                { "RELATORI_NUM_TITULO" , "Titulo XYZ" },
                { "RELATORI_COD_SUBGRUPO" , "001" },
                { "RELATORI_COD_OPERACAO" , "4001" },
                { "RELATORI_COD_PLANO" , "Plano XYZ" },
                { "RELATORI_OCORR_HISTORICO" , "Histórico XYZ" },
                { "RELATORI_NUM_APOL_LIDER" , "123456" },
                { "RELATORI_ENDOS_LIDER" , "987654" },
                { "RELATORI_NUM_PARC_LIDER" , "1" },
                { "RELATORI_NUM_SINISTRO" , "Sinistro XYZ" },
                { "RELATORI_NUM_SINI_LIDER" , "Sinistro Líder XYZ" },
                { "RELATORI_NUM_ORDEM" , "Ordem XYZ" },
                { "RELATORI_COD_MOEDA" , "BRL" },
                { "RELATORI_TIPO_CORRECAO" , "Correção XYZ" },
                { "RELATORI_SIT_REGISTRO" , "Situação XYZ" },
                { "RELATORI_IND_PREV_DEFINIT" , "Indicação XYZ" },
                { "RELATORI_IND_ANAL_RESUMO" , "Análise XYZ" },
                { "RELATORI_COD_EMPRESA" , "Empresa XYZ" },
                { "RELATORI_PERI_RENOVACAO" , "Renovação XYZ" },
                { "RELATORI_PCT_AUMENTO" , "10%" },
            });
            AppSettings.TestSet.DynamicData.Remove("R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1", q21);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VE0123B();
                 program.Execute();

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
        public static void VE0123B_Tests_Fact_ReturnCode99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                GEJVS002_Tests.Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region VE0123B_CURS01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
                { "PROPOVA_COD_CLIENTE" , "123456789" },
                { "PROPOVA_OCOREND" , "1001" },
                { "PROPOVA_COD_FONTE" , "2001" },
                { "PROPOVA_AGE_COBRANCA" , "3001" },
                { "PROPOVA_OCORR_HISTORICO" , "Incidente reportado" },
                { "PROPOVA_DATA_QUITACAO" , "2023-12-15" },
                { "PROPOVA_DATA_VENCIMENTO" , "2024-01-15" },
                { "PROPOVA_DTPROXVEN" , "2024-02-15" },
                { "PROPOVA_NUM_PARCELA" , "1" },
                { "PROPOVA_COD_PRODUTO" , "8209" },
                { "PROPOVA_NUM_PROPOSTA" , "123456" },
                { "PROPOVA_STA_MUDANCA_PLANO" , "S" },
            }, new SQLCA(99));

                AppSettings.TestSet.DynamicData.Remove("VE0123B_CURS01");
                AppSettings.TestSet.DynamicData.Add("VE0123B_CURS01", q0);

                #endregion

                #region VE0123B_CURS02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , "2023-01-01" },
                { "MOEDACOT_VAL_VENDA" , "3.75" },
            }, new SQLCA(99));

                q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , "2023-02-01" },
                { "MOEDACOT_VAL_VENDA" , "3.25" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VE0123B_CURS02");
                AppSettings.TestSet.DynamicData.Add("VE0123B_CURS02", q1);

                #endregion

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DTMOV_ABERTO" , "2023-12-01" },
                { "SISTEMAS_DTTER_COTACAO" , "2023-12-10" },
                { "SISTEMAS_DTINI_COTACAO" , "2023-12-01" },
                { "SISTEMAS_DTMOV_ABERTO_30" , "2023-12-31" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "150" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DTANIVERS" , "1990-05-20" },
                { "WS_DTANIVERS_1" , "1991-06-21" },
                { "WS_DTANIVERS_2" , "1992-07-22" },
                { "WS_DTANIVERS_3" , "1993-08-23" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-12-31" },
                { "HISCOBPR_OCORR_HISTORICO" , "" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "" },
                { "PROPOVA_COD_OPERACAO" , "4001" },
                { "WS_DTANIVERS" , "1990-05-20" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AUT" , "654321" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_COD_FONTE" , "2001" },
                { "WS_NUM_PROPOSTA_AUT" , "654321" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
                { "PROPOVA_COD_CLIENTE" , "123456789" },
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" },
                { "PROPOVA_OCOREND" , "1001" },
                { "PROPOVA_AGE_COBRANCA" , "3001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "123456789012" },
                { "W_DIG_CONTA" , "5" },
                { "MOVIMVGA_IMP_MORNATU_ANT" , "10000" },
                { "MOVIMVGA_IMP_MORNATU_ATU" , "10500" },
                { "MOVIMVGA_IMP_MORACID_ANT" , "5000" },
                { "MOVIMVGA_IMP_MORACID_ATU" , "5500" },
                { "MOVIMVGA_IMP_INVPERM_ANT" , "2000" },
                { "MOVIMVGA_IMP_INVPERM_ATU" , "2100" },
                { "MOVIMVGA_IMP_AMDS_ANT" , "1500" },
                { "MOVIMVGA_IMP_AMDS_ATU" , "1600" },
                { "MOVIMVGA_IMP_DH_ANT" , "1200" },
                { "MOVIMVGA_IMP_DH_ATU" , "1300" },
                { "MOVIMVGA_IMP_DIT_ANT" , "1100" },
                { "MOVIMVGA_IMP_DIT_ATU" , "1150" },
                { "MOVIMVGA_PRM_VG_ANT" , "300" },
                { "MOVIMVGA_PRM_VG_ATU" , "315" },
                { "MOVIMVGA_PRM_AP_ANT" , "200" },
                { "MOVIMVGA_PRM_AP_ATU" , "210" },
                { "SISTEMAS_DTMOV_ABERTO" , "2023-12-01" },
                { "WS_DTANIVERS" , "1990-05-20" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AUT" , "654321" },
                { "PROPOVA_COD_FONTE" , "2001" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1", q9);

                #endregion

                #region R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "8209" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_NUM_APOLICE" , "123456789" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1", q10);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , "Trimestral" },
                { "SUBGVGAP_DATA_INIVIGENCIA" , "2023-01-01" },
                { "SUBGVGAP_DATA_TERVIGENCIA" , "2023-12-31" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_NUM_APOLICE" , "123456789" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WS_DTANIVERS_3" , "1993-08-23" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1", q12);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPOVA_DATA_QUITACAO" , "2023-12-15" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1", q13);

                #endregion

                #region R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "111" }
            }, new SQLCA(99));
                q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "112" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q14);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "" }
            }, new SQLCA(99));

                AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1", q15);

                #endregion

                #region R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "987654321" },
                { "HISCOBPR_OCORR_HISTORICO" , "111" },
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-12-31" },
                { "HISCOBPR_IMPSEGUR" , "0" },
                { "HISCOBPR_QUANT_VIDAS" , "0" },
                { "HISCOBPR_IMPSEGIND" , "0" },
                { "HISCOBPR_COD_OPERACAO" , "0" },
                { "HISCOBPR_OPCAO_COBERTURA" , "" },
                { "HISCOBPR_IMP_MORNATU" , "" },
                { "HISCOBPR_IMPMORACID" , "" },
                { "HISCOBPR_IMPINVPERM" , "" },
                { "HISCOBPR_IMPAMDS" , "" },
                { "HISCOBPR_IMPDH" , "" },
                { "HISCOBPR_IMPDIT" , "" },
                { "HISCOBPR_VLPREMIO" , "" },
                { "HISCOBPR_PRMVG" , "" },
                { "HISCOBPR_PRMAP" , "" },
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "" },
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "" },
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "" },
                { "HISCOBPR_IMPSEGCDG" , "" },
                { "HISCOBPR_VLCUSTCDG" , "" },
                { "HISCOBPR_COD_USUARIO" , "" },
                { "HISCOBPR_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "HISCOBPR_IMPSEGAUXF" , "" },
                { "HISCOBPR_VLCUSTAUXF" , "" },
                { "HISCOBPR_PRMDIT" , "" },
                { "HISCOBPR_QTMDIT" , "" },
            }, new SQLCA(99));
                q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "987654321" },
                { "HISCOBPR_OCORR_HISTORICO" , "112" },
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-12-31" },
                { "HISCOBPR_IMPSEGUR" , "0" },
                { "HISCOBPR_QUANT_VIDAS" , "0" },
                { "HISCOBPR_IMPSEGIND" , "0" },
                { "HISCOBPR_COD_OPERACAO" , "0" },
                { "HISCOBPR_OPCAO_COBERTURA" , "" },
                { "HISCOBPR_IMP_MORNATU" , "" },
                { "HISCOBPR_IMPMORACID" , "" },
                { "HISCOBPR_IMPINVPERM" , "" },
                { "HISCOBPR_IMPAMDS" , "" },
                { "HISCOBPR_IMPDH" , "" },
                { "HISCOBPR_IMPDIT" , "" },
                { "HISCOBPR_VLPREMIO" , "" },
                { "HISCOBPR_PRMVG" , "" },
                { "HISCOBPR_PRMAP" , "" },
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "" },
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "" },
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "" },
                { "HISCOBPR_IMPSEGCDG" , "" },
                { "HISCOBPR_VLCUSTCDG" , "" },
                { "HISCOBPR_COD_USUARIO" , "" },
                { "HISCOBPR_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "HISCOBPR_IMPSEGAUXF" , "" },
                { "HISCOBPR_VLCUSTAUXF" , "" },
                { "HISCOBPR_PRMDIT" , "" },
                { "HISCOBPR_QTMDIT" , "" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1", q16);

                #endregion

                #region R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "111" },
                { "PROPOVA_COD_OPERACAO" , "4001" },
                { "PROPOVA_COD_PRODUTO" , "8209" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1", q17);

                #endregion

                #region R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , "987654321" },
                { "OPCPAGVI_DATA_INIVIGENCIA" , "2023-01-01" },
                { "OPCPAGVI_DATA_TERVIGENCIA" , "2023-12-31" },
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "Débito Automático" },
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" },
                { "OPCPAGVI_DIA_DEBITO" , "15" },
                { "OPCPAGVI_COD_USUARIO" , "user123" },
                { "OPCPAGVI_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "001" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "Operação 001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "123456789012" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "5" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "1234567890123456" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q18);

                #endregion

                #region R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , "987654321" },
                { "OPCPAGVI_DATA_INIVIGENCIA" , "2023-01-01" },
                { "OPCPAGVI_DATA_TERVIGENCIA" , "2023-12-31" },
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "Débito Automático" },
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" },
                { "OPCPAGVI_DIA_DEBITO" , "15" },
                { "OPCPAGVI_COD_USUARIO" , "user123" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "001" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "Operação 001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "123456789012" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "5" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "1234567890123456" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1", q19);

                #endregion

                #region R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "987654321" },
                { "HISCOBPR_OCORR_HISTORICO" , "111" },
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-12-31" },
                { "HISCOBPR_IMPSEGUR" , "500000" },
                { "HISCOBPR_QUANT_VIDAS" , "100" },
                { "HISCOBPR_IMPSEGIND" , "5000" },
                { "HISCOBPR_COD_OPERACAO" , "4001" },
                { "HISCOBPR_OPCAO_COBERTURA" , "Básica" },
                { "HISCOBPR_IMP_MORNATU" , "10000" },
                { "HISCOBPR_IMPMORACID" , "5000" },
                { "HISCOBPR_IMPINVPERM" , "2000" },
                { "HISCOBPR_IMPAMDS" , "1500" },
                { "HISCOBPR_IMPDH" , "1200" },
                { "HISCOBPR_IMPDIT" , "1100" },
                { "HISCOBPR_VLPREMIO" , "450" },
                { "HISCOBPR_PRMVG" , "300" },
                { "HISCOBPR_PRMAP" , "150" },
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "50" },
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "100" },
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "5" },
                { "HISCOBPR_IMPSEGCDG" , "250000" },
                { "HISCOBPR_VLCUSTCDG" , "12500" },
                { "HISCOBPR_IMPSEGAUXF" , "75000" },
                { "HISCOBPR_VLCUSTAUXF" , "3750" },
                { "HISCOBPR_PRMDIT" , "50" },
                { "HISCOBPR_QTMDIT" , "10" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "user123" },
                { "RELATORI_DATA_SOLICITACAO" , "2023-12-01" },
                { "RELATORI_IDE_SISTEMA" , "Sistema XYZ" },
                { "RELATORI_COD_RELATORIO" , "RPT001" },
                { "RELATORI_NUM_COPIAS" , "2" },
                { "RELATORI_QUANTIDADE" , "100" },
                { "RELATORI_PERI_INICIAL" , "2023-01-01" },
                { "RELATORI_PERI_FINAL" , "2023-12-31" },
                { "RELATORI_DATA_REFERENCIA" , "2023-12-01" },
                { "RELATORI_MES_REFERENCIA" , "12" },
                { "RELATORI_ANO_REFERENCIA" , "2023" },
                { "RELATORI_ORGAO_EMISSOR" , "Orgão XYZ" },
                { "RELATORI_COD_FONTE" , "2001" },
                { "RELATORI_COD_PRODUTOR" , "Produtor XYZ" },
                { "RELATORI_RAMO_EMISSOR" , "Ramo XYZ" },
                { "RELATORI_COD_MODALIDADE" , "Modalidade XYZ" },
                { "RELATORI_COD_CONGENERE" , "Congênere XYZ" },
                { "RELATORI_NUM_APOLICE" , "123456789" },
                { "RELATORI_NUM_ENDOSSO" , "987654321" },
                { "RELATORI_NUM_PARCELA" , "1" },
                { "RELATORI_NUM_CERTIFICADO" , "987654321" },
                { "RELATORI_NUM_TITULO" , "Titulo XYZ" },
                { "RELATORI_COD_SUBGRUPO" , "001" },
                { "RELATORI_COD_OPERACAO" , "4001" },
                { "RELATORI_COD_PLANO" , "Plano XYZ" },
                { "RELATORI_OCORR_HISTORICO" , "Histórico XYZ" },
                { "RELATORI_NUM_APOL_LIDER" , "123456" },
                { "RELATORI_ENDOS_LIDER" , "987654" },
                { "RELATORI_NUM_PARC_LIDER" , "1" },
                { "RELATORI_NUM_SINISTRO" , "Sinistro XYZ" },
                { "RELATORI_NUM_SINI_LIDER" , "Sinistro Líder XYZ" },
                { "RELATORI_NUM_ORDEM" , "Ordem XYZ" },
                { "RELATORI_COD_MOEDA" , "BRL" },
                { "RELATORI_TIPO_CORRECAO" , "Correção XYZ" },
                { "RELATORI_SIT_REGISTRO" , "Situação XYZ" },
                { "RELATORI_IND_PREV_DEFINIT" , "Indicação XYZ" },
                { "RELATORI_IND_ANAL_RESUMO" , "Análise XYZ" },
                { "RELATORI_COD_EMPRESA" , "Empresa XYZ" },
                { "RELATORI_PERI_RENOVACAO" , "Renovação XYZ" },
                { "RELATORI_PCT_AUMENTO" , "10%" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1", q21);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VE0123B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}