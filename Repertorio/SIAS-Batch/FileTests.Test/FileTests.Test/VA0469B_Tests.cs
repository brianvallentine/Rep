using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0469B;

namespace FileTests.Test
{
    [Collection("VA0469B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0469B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO", "2024/01/01" },
                { "V1SIST_DTHOJE", "2024/01/01 12:00:00" },
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0469B_TRELAT

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_APOLICE", "123456" },
                { "RELATORI_NUM_ENDOSSO", "78910" },
                { "RELATORI_COD_SUBGRUPO", "001" },
                { "RELATORI_COD_USUARIO", "user01" },
                { "RELATORI_COD_OPERACAO", "op001" },
                { "RELATORI_NUM_CERTIFICADO", "cert001" },
                { "RELATORI_NUM_PARCELA", "001" },
                { "RELATORI_SIT_REGISTRO", "active" },
                { "RELATORI_NUM_ORDEM", "order001" },
                { "RELATORI_QUANTIDADE", "10" },
                { "RELATORI_MES_REFERENCIA", "08" },
                { "RELATORI_ANO_REFERENCIA", "2024" },
                { "RELATORI_ORGAO_EMISSOR", "org001" },
                { "RELATORI_NUM_SINISTRO", "sin001" },
                { "RELATORI_NUM_COPIAS", "1" },
                { "RELATORI_DATA_SOLICITACAO", "2024/03/08" },
                { "RELATORI_NUM_APOL_LIDER", "leader001" },
            });
            AppSettings.TestSet.DynamicData.Add("VA0469B_TRELAT", q1);

            #endregion

            #region R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO", "cert002" }
            });
            AppSettings.TestSet.DynamicData.Add("R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1010_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_SIT_REGISTRO", "inactive" },
                { "RELATORI_NUM_CERTIFICADO", "cert003" },
                { "RELATORI_NUM_PARCELA", "002" },
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE", "source001" },
                { "PROPOVA_DATA_QUITACAO", "2024/02/15" },
                { "PROPOVA_SIT_REGISTRO", "completed" },
                { "PROPOVA_DTA_DECLINIO", "2024/01/20" },
                { "PROPOVA_COD_PRODUTO", "prod001" },
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_NUM_TITULO", "title001" },
                { "COBHISVI_DATA_VENCIMENTO", "2024/03/01" },
                { "COBHISVI_SIT_REGISTRO", "paid" },
                { "COBHISVI_OCORR_HISTORICO", "history001" },
                { "COBHISVI_COD_DEVOLUCAO", "return001" },
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WQTD_QTD", "100" }
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_OCORR_HISTORICOCTA", "history002" }
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1125_00_SELECT_HISLANCT_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_PRM_TOTAL_ANT", "5000" }
            });
            AppSettings.TestSet.DynamicData.Add("R1125_00_SELECT_HISLANCT_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_DATA_VENCIMENTO", "2024/03/10" },
                { "PARCEVID_PREMIO_VG", "1000" },
                { "PARCEVID_PREMIO_AP", "500" },
                { "PARCEVID_OCORR_HISTORICO", "history003" },
                { "COBHISVI_PRM_TOTAL", "1500" },
            });
            AppSettings.TestSet.DynamicData.Add("R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_OPCAOPAG", "paymentOption001" }
            });
            AppSettings.TestSet.DynamicData.Add("R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO", "option001" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO", "agency001" },
                { "OPCPAGVI_OPE_CONTA_DEBITO", "operation001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO", "123456789" },
                { "OPCPAGVI_DIG_CONTA_DEBITO", "0" },
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_CRED", "2024/02/01" },
                { "WHOST_NEW_PRM", "1200" },
                { "COBHISVI_SIT_REGISTRO", "updated" },
                { "COBHISVI_COD_OPERACAO", "op002" },
                { "COBHISVI_OCORR_HISTORICO", "history004" },
                { "RELATORI_COD_OPERACAO", "op003" },
                { "RELATORI_NUM_CERTIFICADO", "cert004" },
                { "RELATORI_NUM_PARCELA", "003" },
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R2010_00_SELECT_USUFILSE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "USUFILSE_COD_CO", "co001" }
            });
            AppSettings.TestSet.DynamicData.Add("R2010_00_SELECT_USUFILSE_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2020_00_VER_CANCELAMENTO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_CERTIFICADO" , "1231"},
                { "MOVIMVGA_COD_OPERACAO" , "1"},
                { "MOVIMVGA_DATA_OPERACAO" , "2024/08/21"},
            });
            AppSettings.TestSet.DynamicData.Add("R2020_00_VER_CANCELAMENTO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_CERTIFICADO" , "1231"},
                { "MOVIMVGA_COD_OPERACAO" , "1"},
                { "MOVIMVGA_DATA_OPERACAO" , "2024/08/21"},
            });
            AppSettings.TestSet.DynamicData.Add("R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2022_00_VER_CANCELAMENTO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_CERTIFICADO" , "1231"},
                { "MOVIMVGA_COD_OPERACAO" , "1"},
                { "MOVIMVGA_DATA_OPERACAO" , "2024/08/21"},
            });
            AppSettings.TestSet.DynamicData.Add("R2022_00_VER_CANCELAMENTO_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CONVEVG_COD_NAOACEITE" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1", q17);

            #endregion

            #region R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_CERTIFICADO" , "CERT123456789" },
                { "RELATORI_NUM_PARCELA" , "PARC987654321" },
                { "PARCEVID_OCORR_HISTORICO" , "Histórico de ocorrências registrado" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "AGENCIA01" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "OPERATION01" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "1234567890" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "1234" },
                { "WHOST_DATA_CRED" , "2024-08-30" },
                { "WHOST_NEW_PRM" , "NovoParametro123" },
                { "HISLANCT_SIT_REGISTRO" , "ATIVO" },
                { "HISLANCT_TIPLANC" , "TIPO_A" },
                { "CONVEVG_COD_NAOACEITE" , "NAOACEITE001" },
                { "HISLANCT_CODRET" , "RET001" },
                { "RELATORI_COD_USUARIO" , "USR123" },
                { "HISLANCT_COD_BANCO" , "BANCO01" }
            });
            AppSettings.TestSet.DynamicData.Add("R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_CERTIFICADO" , "CERT123456789"},
                { "RELATORI_NUM_PARCELA" , "PARC987654321"},
                { "WS_COD_CONVENIO" , "123"},
            });
            AppSettings.TestSet.DynamicData.Add("R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WHOST_JUROS" , "1"},
                { "PARCEVID_OCORR_HISTORICO" , "testee"},
                { "RELATORI_NUM_CERTIFICADO" , "CERT123456789"},
                { "RELATORI_NUM_PARCELA" , "PARC987654321"},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_SIT_REGISTRO" , "ATIVO" },
                { "PROPOVA_COD_PRODUTO" , "PROD001" },
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q21);

            #endregion

            #region R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_SIT_REGISTRO" , "INATIVO" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-08-30" },
                { "WDTA_DECLINIO" , "Declínio de proposta" },
                { "RELATORI_COD_USUARIO" , "USR456" },
                { "RELATORI_NUM_CERTIFICADO" , "CERT987654321" },
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_CERTIFICADO" , "CERT543210987" },
                { "RELATORI_NUM_PARCELA" , "PARC123456789" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança inserido" },
                { "RELATORI_NUM_APOLICE" , "APOL123456" },
                { "RELATORI_COD_SUBGRUPO" , "SUBGRP01" },
                { "PROPOVA_COD_FONTE" , "FONTE01" },
                { "WHOST_PRM_VG" , "ParametroVG123" },
                { "WHOST_PRM_AP" , "ParametroAP456" },
                { "WHOST_DATA_CRED" , "2024-08-30" },
                { "COBHISVI_COD_OPERACAO" , "OP001" },
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R2500_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-08-30" },
                { "RELATORI_NUM_APOLICE" , "APOL654321" },
                { "RELATORI_NUM_PARCELA" , "PARC987654" },
                { "RELATORI_NUM_CERTIFICADO" , "CERT098765432" },
                { "RELATORI_COD_SUBGRUPO" , "SUBGRP02" },
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q24);

            #endregion

            #region R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "WQTD_HIST_CONT" , "10" },
                { "WS_DTFATUR" , "2024-08-30" },
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1", q25);

            #endregion

            #region R3040_00_CONTA_DIAS_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "WQTDIAS" , "30" }
            });
            AppSettings.TestSet.DynamicData.Add("R3040_00_CONTA_DIAS_DB_SELECT_1_Query1", q26);

            #endregion

            #region R3040_00_CONTA_DIAS_DB_SELECT_2_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "WQTDIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3040_00_CONTA_DIAS_DB_SELECT_2_Query1", q27);

            #endregion

            #region R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "FONTE02" },
                { "RCAPS_NUM_RCAP" , "RCAP123" },
                { "RCAPS_VAL_RCAP" , "1000.00" },
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "900.00" },
                { "RCAPS_DATA_CADASTRAMENTO" , "2024-08-30" },
                { "RCAPS_DATA_MOVIMENTO" , "2024-08-30" },
                { "RCAPS_NUM_TITULO" , "TIT654321" },
                { "RCAPS_NUM_CERTIFICADO" , "CERT123456789" },
            });
            AppSettings.TestSet.DynamicData.Add("R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1", q28);

            #endregion

            #region R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , "FONTE03" },
                { "RCAPCOMP_NUM_RCAP" , "RCAP456" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , "RCAP456-C" },
                { "RCAPCOMP_COD_OPERACAO" , "OP002" },
                { "RCAPCOMP_BCO_AVISO" , "BCO123" },
                { "RCAPCOMP_AGE_AVISO" , "AGE123" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "AVISO123" },
                { "RCAPCOMP_VAL_RCAP" , "500.00" },
                { "RCAPCOMP_DATA_RCAP" , "2024-08-30" },
                { "RCAPCOMP_DATA_CADASTRAMENTO" , "2024-08-30" },
            });
            AppSettings.TestSet.DynamicData.Add("R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q29);

            #endregion

            #region R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP" , "RCAP789" },
                { "RCAPCOMP_COD_FONTE" , "FONTE04" },
            });
            AppSettings.TestSet.DynamicData.Add("R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R3320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , "FONTE05" },
                { "RCAPCOMP_NUM_RCAP" , "RCAP012" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , "RCAP012-C" },
                { "RCAPCOMP_COD_OPERACAO" , "OP003" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2024-08-30" },
                { "RCAPCOMP_SIT_REGISTRO" , "ATIVO" },
                { "RCAPCOMP_BCO_AVISO" , "BCO456" },
                { "RCAPCOMP_AGE_AVISO" , "AGE456" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "AVISO456" },
                { "RCAPCOMP_VAL_RCAP" , "200.00" },
                { "RCAPCOMP_DATA_RCAP" , "2024-08-30" },
                { "RCAPCOMP_DATA_CADASTRAMENTO" , "2024-08-30" },
                { "RCAPCOMP_SIT_CONTABIL" , "REGISTRADO" },
                { "RCAPCOMP_COD_EMPRESA" , "EMP01" },
            });
            AppSettings.TestSet.DynamicData.Add("R3320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1", q31);

            #endregion

            #region R3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_APOLICE" , "APOL987654" },
                { "RCAPS_NUM_ENDOSSO" , "END123" },
                { "RCAPS_NUM_PARCELA" , "PARC321" },
                { "RCAPCOMP_NUM_RCAP" , "RCAP345" },
                { "RCAPCOMP_COD_FONTE" , "FONTE06" },
            });
            AppSettings.TestSet.DynamicData.Add("R3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1", q32);

            #endregion

            #region R3405_00_SELECT_GE408_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_CERTIFICADO" , "CERT87654321" }
            });
            AppSettings.TestSet.DynamicData.Add("R3405_00_SELECT_GE408_DB_SELECT_1_Query1", q33);

            #endregion

            #region R3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , "EMP02" },
                { "MOVDEBCE_NUM_APOLICE" , "APOL123456" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END456" },
                { "MOVDEBCE_NUM_PARCELA" , "PARC789" },
                { "MOVDEBCE_SITUACAO_COBRANCA" , "EM ABERTO" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2024-09-15" },
                { "MOVDEBCE_VALOR_DEBITO" , "1500.00" },
                { "MOVDEBCE_DATA_MOVIMENTO" , "2024-08-30" },
                { "MOVDEBCE_DIA_DEBITO" , "15" },
                { "MOVDEBCE_COD_AGENCIA_DEB" , "AGENCIA02" },
                { "MOVDEBCE_OPER_CONTA_DEB" , "OP002" },
                { "MOVDEBCE_NUM_CONTA_DEB" , "9876543210" },
                { "MOVDEBCE_DIG_CONTA_DEB" , "5678" },
                { "MOVDEBCE_COD_CONVENIO" , "CONV002" },
                { "MOVDEBCE_DATA_ENVIO" , "2024-08-30" },
                { "MOVDEBCE_DATA_RETORNO" , "2024-09-01" },
                { "MOVDEBCE_COD_RETORNO_CEF" , "RET002" },
                { "MOVDEBCE_NSAS" , "NSAS456" },
                { "MOVDEBCE_COD_USUARIO" , "USR789" },
                { "MOVDEBCE_NUM_REQUISICAO" , "REQ789" },
                { "MOVDEBCE_NUM_CARTAO" , "CART123" },
                { "MOVDEBCE_SEQUENCIA" , "SEQ789" },
                { "MOVDEBCE_NUM_LOTE" , "LOTE456" },
                { "MOVDEBCE_DTCREDITO" , "2024-08-30" },
                { "MOVDEBCE_STATUS_CARTAO" , "ATIVO" },
                { "MOVDEBCE_VLR_CREDITO" , "1500.00" },
                { "MOVDEBCE_NUM_CERTIFICADO" , "CERT654321987" },
                { "MOVDEBCE_COD_MOEDA" , "BRL" },
                { "MOVDEBCE_PCT_INDICE" , "5" },
                { "MOVDEBCE_VLR_ORIGINAL" , "1500.00" },
                { "MOVDEBCE_VLR_PRORATA" , "1500.00" },
                { "MOVDEBCE_VLR_JUROS" , "0.00" },
                { "MOVDEBCE_VLR_MULTA" , "0.00" },
                { "MOVDEBCE_DTA_ORIGINAL" , "2024-08-30" },
                { "MOVDEBCE_COD_IDLG" , "IDLG789" },
            });
            AppSettings.TestSet.DynamicData.Add("R3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1", q34);

            #endregion

            #region R3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WS_NSAS_ERRO" , "ERRO001" },
                { "MOVDEBCE_NUM_APOLICE" , "APOL654321" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END789" },
                { "MOVDEBCE_NUM_PARCELA" , "PARC123" },
                { "MOVDEBCE_COD_CONVENIO" , "CONV003" },
                { "MOVDEBCE_NSAS" , "NSAS789" },
            });
            AppSettings.TestSet.DynamicData.Add("R3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1_Update1", q35);

            #endregion

            #region R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_CERTIFICADO" , "CERT321098765" },
                { "RELATORI_NUM_PARCELA" , "PARC456123" },
                { "PARCEVID_OCORR_HISTORICO" , "Atualização de histórico" },
            });
            AppSettings.TestSet.DynamicData.Add("R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q36);

            #endregion

            #region R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_CERTIFICADO" , "CERT87654321" },
                { "GE408_VLR_COBRANCA" , "2000.00" },
            });
            AppSettings.TestSet.DynamicData.Add("R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1", q37);

            #endregion

            #region R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_AGENCIA_DEB" , "AGENCIA03" },
                { "MOVDEBCE_OPER_CONTA_DEB" , "OP003" },
                { "MOVDEBCE_NUM_CONTA_DEB" , "1230984567" },
                { "MOVDEBCE_DIG_CONTA_DEB" , "6789" },
                { "MOVDEBCE_DIA_DEBITO" , "20" },
                { "MOVDEBCE_DATA_MOVIMENTO" , "2024-08-30" },
                { "MOVDEBCE_SITUACAO_COBRANCA" , "PAGO" },
                { "MOVDEBCE_NUM_CARTAO" , "CART456" },
                { "MOVDEBCE_NUM_APOLICE" , "APOL987654" },
                { "MOVDEBCE_NUM_PARCELA" , "PARC321" },
            });
            AppSettings.TestSet.DynamicData.Add("R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1", q38);

            #endregion

            #region R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_CORRECAO" , "5" }
            });
            AppSettings.TestSet.DynamicData.Add("R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1", q39);

            #endregion

            #region R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , "1500.00" },
                { "RCAPCOMP_BCO_AVISO" , "BCO789" },
                { "RCAPCOMP_AGE_AVISO" , "AGE789" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "AVISO789" },
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1", q40);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("TESTE_469BV2.TXT")]
        public static void VA0469B_Tests_Theory(string ARQCHEQ_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQCHEQ_FILE_NAME_P = $"{ARQCHEQ_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA0469B();
                program.Execute(ARQCHEQ_FILE_NAME_P);
                //
                var envList2 = AppSettings.TestSet.DynamicData["R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[0].TryGetValue("RCAPCOMP_COD_FONTE", out var valor) && valor == "FONTE04");
                Assert.True(ARQCHEQ_FILE_NAME_P.Length > 0);
                Assert.True(true);
            }
        }
    }
}