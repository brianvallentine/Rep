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
using static Code.BI7401B;
using System.IO;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("BI7401B_Tests")]
    public class BI7401B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTMOVABE_1Y" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI7401B_V0RELATORI

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI7401B_V0RELATORI", q1);

            #endregion

            #region BI7401B_V0RCAPCOMP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "HOST_COUNT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI7401B_V0RCAPCOMP", q2);

            #endregion

            #region R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "CONVERSI_NUM_SICOB" , ""},
                { "CONVERSI_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
                { "RCAPCOMP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
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
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
                { "RCAPCOMP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "VIND_NULL01" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_SIT_REGISTRO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
                { "RCAPCOMP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ORGAO_EMISSOR" , ""},
                { "NUMERAES_RAMO_EMISSOR" , ""},
                { "NUMERAES_ENDOS_CANCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANCELA" , ""},
                { "NUMERAES_ORGAO_EMISSOR" , ""},
                { "NUMERAES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_AVISO_CREDITO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1", q26);

            #endregion

            #region R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1", q27);

            #endregion

            #region BI7401B_V1RELATORI

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI7401B_V1RELATORI", q28);

            #endregion

            #region R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1", q29);

            #endregion

            #region R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1", q31);

            #endregion

            #region BI7401B_V2RELATORI

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI7401B_V2RELATORI", q32);

            #endregion

            #region R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ORGAO_EMISSOR" , ""},
                { "NUMERAES_RAMO_EMISSOR" , ""},
                { "NUMERAES_ENDOS_CANC_RESTI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q33);

            #endregion

            #region R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANC_RESTI" , ""},
                { "NUMERAES_ORGAO_EMISSOR" , ""},
                { "NUMERAES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R3050_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1", q35);

            #endregion

            #region R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q36);

            #endregion

            #region R3070_00_UPDATE_FONTES_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "BILHETE_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3070_00_UPDATE_FONTES_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_LIBERACAO" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "ENDOSSOS_BCO_RCAP" , ""},
                { "ENDOSSOS_AGE_RCAP" , ""},
                { "ENDOSSOS_DAC_RCAP" , ""},
                { "ENDOSSOS_TIPO_RCAP" , ""},
                { "ENDOSSOS_BCO_COBRANCA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_DAC_COBRANCA" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_PLANO_SEGURO" , ""},
                { "ENDOSSOS_PCT_ENTRADA" , ""},
                { "ENDOSSOS_PCT_ADIC_FRACIO" , ""},
                { "ENDOSSOS_QTD_DIAS_PRIMEIRA" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "ENDOSSOS_QTD_PRESTACOES" , ""},
                { "ENDOSSOS_QTD_ITENS" , ""},
                { "ENDOSSOS_COD_TEXTO_PADRAO" , ""},
                { "ENDOSSOS_COD_ACEITACAO" , ""},
                { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "ENDOSSOS_DATA_RCAP" , ""},
                { "ENDOSSOS_COD_EMPRESA" , ""},
                { "ENDOSSOS_TIPO_CORRECAO" , ""},
                { "ENDOSSOS_ISENTA_CUSTO" , ""},
                { "ENDOSSOS_DATA_VENCIMENTO" , ""},
                { "ENDOSSOS_COEF_PREFIX" , ""},
                { "ENDOSSOS_VAL_CUSTO_EMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q38);

            #endregion

            #region R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1", q39);

            #endregion

            #region R3120_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_LIBERACAO" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "ENDOSSOS_BCO_RCAP" , ""},
                { "ENDOSSOS_AGE_RCAP" , ""},
                { "ENDOSSOS_DAC_RCAP" , ""},
                { "ENDOSSOS_TIPO_RCAP" , ""},
                { "ENDOSSOS_BCO_COBRANCA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_DAC_COBRANCA" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_PLANO_SEGURO" , ""},
                { "ENDOSSOS_PCT_ENTRADA" , ""},
                { "ENDOSSOS_PCT_ADIC_FRACIO" , ""},
                { "ENDOSSOS_QTD_DIAS_PRIMEIRA" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "ENDOSSOS_QTD_PRESTACOES" , ""},
                { "ENDOSSOS_QTD_ITENS" , ""},
                { "ENDOSSOS_COD_TEXTO_PADRAO" , ""},
                { "ENDOSSOS_COD_ACEITACAO" , ""},
                { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "ENDOSSOS_DATA_RCAP" , ""},
                { "ENDOSSOS_COD_EMPRESA" , ""},
                { "ENDOSSOS_TIPO_CORRECAO" , ""},
                { "ENDOSSOS_ISENTA_CUSTO" , ""},
                { "ENDOSSOS_DATA_VENCIMENTO" , ""},
                { "ENDOSSOS_COEF_PREFIX" , ""},
                { "ENDOSSOS_VAL_CUSTO_EMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3120_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R3130_00_INSERT_PARCELAS_DB_INSERT_1_Insert1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
                { "PARCELAS_DAC_PARCELA" , ""},
                { "PARCELAS_COD_FONTE" , ""},
                { "PARCELAS_NUM_TITULO" , ""},
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_PRM_LIQUIDO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , ""},
                { "PARCELAS_VAL_IOCC_IX" , ""},
                { "PARCELAS_PRM_TOTAL_IX" , ""},
                { "PARCELAS_OCORR_HISTORICO" , ""},
                { "PARCELAS_QTD_DOCUMENTOS" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "PARCELAS_COD_EMPRESA" , ""},
                { "PARCELAS_SITUACAO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3130_00_INSERT_PARCELAS_DB_INSERT_1_Insert1", q41);

            #endregion

            #region R3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q42);

            #endregion

            #region R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
                { "APOLICOB_COD_EMPRESA" , ""},
                { "APOLICOB_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q43);

            #endregion

            #region R3210_00_INSERT_APOLICOB_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
                { "APOLICOB_COD_EMPRESA" , ""},
                { "APOLICOB_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_00_INSERT_APOLICOB_DB_INSERT_1_Insert1", q44);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SBI7401B", "PRD.BI.D240919.BI7401B.SAIDA01_t1", "PRD.BI.D240919.BI7401B.SAIDA02_t1")]
        public static void BI7401B_Tests_Theory(string SBI7401B_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P)
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

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO", "2020-01-01" },
                { "V1SIST_DTMOVABE_1Y", "2020-01-01" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region BI7401B_V0RELATORI

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO", "2020-01-01" },
                { "RELATORI_IDE_SISTEMA", "1" },
                { "RELATORI_COD_RELATORIO", "1" },
                { "RELATORI_QUANTIDADE", "1" },
                { "RELATORI_RAMO_EMISSOR", "1" },
                { "RELATORI_NUM_APOLICE", "1" },
                { "RELATORI_NUM_TITULO", "1" },
                { "RELATORI_SIT_REGISTRO", "1" },
                { "RELATORI_IND_PREV_DEFINIT", "1" },
                { "RELATORI_IND_ANAL_RESUMO", "2" }
            });
                AppSettings.TestSet.DynamicData.Remove("BI7401B_V0RELATORI");
                AppSettings.TestSet.DynamicData.Add("BI7401B_V0RELATORI", q1);

                #endregion

                #region BI7401B_V0RCAPCOMP

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE", "1" },
                { "RCAPCOMP_NUM_RCAP", "2" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN", "3" },
                { "HOST_COUNT", "5" }
                });
                AppSettings.TestSet.DynamicData.Remove("BI7401B_V0RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("BI7401B_V0RCAPCOMP", q2);

                #region R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE", "1" },
                { "APOLICES_COD_PRODUTO", "2" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1", q3);

                #endregion


                #endregion

                #region R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO", "5" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                /*q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT", "5" }
                 });
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT", "3" }
                 });
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT", "5" }
                 });*/
                AppSettings.TestSet.DynamicData.Remove("R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT", "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE", "1" },
                { "BILHETE_NUM_APOLICE", "2" },
                { "BILHETE_FONTE", "3" },
                { "BILHETE_AGE_COBRANCA", "4" },
                { "BILHETE_VAL_RCAP", "120" },
                { "BILHETE_RAMO", "5" },
                { "BILHETE_DATA_VENDA", "2020-01-01" },
                { "BILHETE_SITUACAO", "6" },
                { "BILHETE_TIP_CANCELAMENTO", "7" },
                { "BILHETE_DATA_CANCELAMENTO", "2020-01-01" },
                { "CLIENTES_NOME_RAZAO", "XXXXXXX" },
                { "CLIENTES_CGCCPF", "1234567899" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF", "1" },
                { "CONVERSI_NUM_SICOB", "2" },
                { "CONVERSI_COD_PRODUTO_SIVPF", "3" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE", "1" },
                { "MOVDEBCE_NUM_ENDOSSO", "5" },
                { "MOVDEBCE_NUM_PARCELA", "3" },
                { "MOVDEBCE_SITUACAO_COBRANCA", "4" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE", "1" },
                { "MOVDEBCE_NUM_ENDOSSO", "5" },
                { "MOVDEBCE_NUM_PARCELA", "3" },
                { "MOVDEBCE_SITUACAO_COBRANCA", "4" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO", "1" },
                { "RCAPS_COD_OPERACAO", "200" },
                { "RCAPCOMP_COD_FONTE", "3" },
                { "RCAPCOMP_NUM_RCAP", "4" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN", "5" },
                { "RCAPCOMP_COD_OPERACAO", "6" },
                { "RCAPCOMP_BCO_AVISO", "7" },
                { "RCAPCOMP_AGE_AVISO", "8" },
                { "RCAPCOMP_NUM_AVISO_CREDITO", "9" },
                { "RCAPCOMP_VAL_RCAP", "10" },
                { "RCAPCOMP_DATA_RCAP", "2020-01-01" },
                { "RCAPCOMP_DATA_CADASTRAMENTO", "2020-01-01" },
                { "RCAPCOMP_SIT_CONTABIL", "11" },
                { "RCAPCOMP_COD_EMPRESA", "12" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE", "79545" },
                { "PARCEHIS_NUM_ENDOSSO", "5" },
                { "PARCEHIS_NUM_PARCELA", "0" },
                { "PARCEHIS_DAC_PARCELA", "2020-01-01" },
                { "PARCEHIS_COD_OPERACAO", "1" },
                { "PARCEHIS_OCORR_HISTORICO", "5" },
                { "PARCEHIS_PRM_TARIFARIO", "45" },
                { "PARCEHIS_VAL_DESCONTO", "135" },
                { "PARCEHIS_PRM_LIQUIDO", "485" },
                { "PARCEHIS_ADICIONAL_FRACIO", "12" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO", "123" },
                { "PARCEHIS_VAL_IOCC", "2" },
                { "PARCEHIS_PRM_TOTAL", "13" },
                { "PARCEHIS_VAL_OPERACAO", "985" },
                { "PARCEHIS_DATA_VENCIMENTO", "2020-01-01" },
                { "PARCEHIS_BCO_COBRANCA", "1" },
                { "PARCEHIS_AGE_COBRANCA", "2" },
                { "PARCEHIS_NUM_AVISO_CREDITO", "897" },
                { "PARCEHIS_SIT_CONTABIL", "1" },
                { "PARCEHIS_DATA_QUITACAO", "2020-01-01" },
                { "PARCEHIS_COD_EMPRESA", "198" },
                { "APOLICES_ORGAO_EMISSOR", "SSP" },
                { "APOLICES_RAMO_EMISSOR", "8" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP", "1" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN", "2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q13);

                #endregion

                #region R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP", "8" },
                { "RCAPS_COD_OPERACAO", "200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO", "874" },
                { "RCAPS_COD_OPERACAO", "200" },
                { "RCAPCOMP_COD_FONTE", "5" },
                { "RCAPCOMP_NUM_RCAP", "7845" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN", "3657" },
                { "RCAPCOMP_COD_OPERACAO", "1" },
                { "RCAPCOMP_BCO_AVISO", "1" },
                { "RCAPCOMP_AGE_AVISO", "2" },
                { "RCAPCOMP_NUM_AVISO_CREDITO", "12468" },
                { "RCAPCOMP_VAL_RCAP", "87" },
                { "RCAPCOMP_DATA_RCAP", "87" },
                { "RCAPCOMP_DATA_CADASTRAMENTO", "2020-01-01" },
                { "RCAPCOMP_SIT_CONTABIL", "1" },
                { "RCAPCOMP_COD_EMPRESA", "10" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ORGAO_EMISSOR", "SSP" },
                { "NUMERAES_RAMO_EMISSOR", "1" },
                { "NUMERAES_ENDOS_CANCELA", "0" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q22);

                #endregion

                #region BI7401B_V1RELATORI

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string> {
                { "RELATORI_RAMO_EMISSOR", "1" },
                { "RELATORI_NUM_APOLICE", "95874" },
                { "RELATORI_NUM_TITULO", "1235" },
                { "RELATORI_IND_PREV_DEFINIT", "1" },
                { "RELATORI_IND_ANAL_RESUMO", "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("BI7401B_V1RELATORI");
                AppSettings.TestSet.DynamicData.Add("BI7401B_V1RELATORI", q28);

                #endregion

                #region R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string> {
                { "RCAPS_SIT_REGISTRO", "1" },
                { "RCAPS_COD_OPERACAO", "200" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1", q29);

                #endregion

                #region BI7401B_V2RELATORI

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string> {
                { "RELATORI_RAMO_EMISSOR", "1" },
                { "RELATORI_NUM_APOLICE", "9874" },
                { "RELATORI_NUM_TITULO", "9658" },
                { "RELATORI_IND_PREV_DEFINIT", "1" },
                { "RELATORI_IND_ANAL_RESUMO", "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("BI7401B_V2RELATORI");
                AppSettings.TestSet.DynamicData.Add("BI7401B_V2RELATORI", q32);

                #endregion

                #region R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string> {
                { "NUMERAES_ORGAO_EMISSOR", "SSP" },
                { "NUMERAES_RAMO_EMISSOR", "1" },
                { "NUMERAES_ENDOS_CANC_RESTI", "2" },
                });
                AppSettings.TestSet.DynamicData.Remove("R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q33);

                #endregion

                #region R3050_00_SELECT_FONTES_DB_SELECT_1_Query1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT", "78454" }
                });
                AppSettings.TestSet.DynamicData.Remove("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1", q35);

                #endregion

                #region R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_PROPOSTA", "7541" }
                });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q36);

                #endregion

                #region R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE", "65984" },
                { "APOLICOB_NUM_ENDOSSO", "5647" },
                { "APOLICOB_NUM_ITEM", "125" },
                { "APOLICOB_OCORR_HISTORICO", "1" },
                { "APOLICOB_RAMO_COBERTURA", "2" },
                { "APOLICOB_MODALI_COBERTURA", "3" },
                { "APOLICOB_COD_COBERTURA", "95" },
                { "APOLICOB_IMP_SEGURADA_IX", "6" },
                { "APOLICOB_PRM_TARIFARIO_IX", "4" },
                { "APOLICOB_IMP_SEGURADA_VAR", "7" },
                { "APOLICOB_PRM_TARIFARIO_VAR", "8" },
                { "APOLICOB_PCT_COBERTURA", "9" },
                { "APOLICOB_FATOR_MULTIPLICA", "10" },
                { "APOLICOB_DATA_INIVIGENCIA", "110" },
                { "APOLICOB_DATA_TERVIGENCIA", "650" },
                { "APOLICOB_COD_EMPRESA", "30" },
                { "APOLICOB_SIT_REGISTRO", "20" }
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q43);

                #endregion

                #endregion
                var program = new BI7401B();
                program.Execute(SBI7401B_FILE_NAME_P, SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P);

                /*
                 SBI7401B.SetFile(SBI7401B_FILE_NAME_P);
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);
                SAIDA02.SetFile(SAIDA02_FILE_NAME_P);*/
                //4 - Validação de arquivos
                Assert.True(File.Exists(program.SAIDA01.FilePath));              
                Assert.True(new FileInfo(program.SAIDA01.FilePath).Length > 0);

                Assert.True(File.Exists(program.SAIDA02.FilePath));
                Assert.True(new FileInfo(program.SAIDA02.FilePath).Length > 0);



                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                #region R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

                var q18 = AppSettings.TestSet.DynamicData["R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(q18?.Count > 1);
                Assert.True(q18[1].TryGetValue("BILHETE_DATA_CANCELAMENTO", out var BILHETE_DATA_CANCELAMENTO) && BILHETE_DATA_CANCELAMENTO == "2020-01-01");
                Assert.True(q18[1].TryGetValue("VIND_NULL01", out var VIND_NULL01) && VIND_NULL01 == "0000");
                Assert.True(q18[1].TryGetValue("BILHETE_NUM_BILHETE", out var BILHETE_NUM_BILHETE) && BILHETE_NUM_BILHETE == "000000000000001");

                #endregion

                #region R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1

                var q30 = AppSettings.TestSet.DynamicData["R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(q30?.Count > 1);
                Assert.True(q30[1].TryGetValue("RCAPS_SIT_REGISTRO", out var RCAPS_SIT_REGISTRO3) && RCAPS_SIT_REGISTRO3 == "1");
                Assert.True(q30[1].TryGetValue("RCAPS_COD_FONTE", out var RCAPS_COD_FONTE) && RCAPS_COD_FONTE == "0001");
                Assert.True(q30[1].TryGetValue("RCAPS_NUM_RCAP", out var RCAPS_NUM_RCAP) && RCAPS_NUM_RCAP == "000000002");

                #endregion

                #region R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1

                var q31 = AppSettings.TestSet.DynamicData["R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(q31?.Count > 1);
                Assert.True(q31[1].TryGetValue("RCAPS_COD_OPERACAO", out var RCAPS_COD_OPERACAO4) && RCAPS_COD_OPERACAO4 == "0200");
                Assert.True(q31[1].TryGetValue("RCAPS_COD_FONTE", out var RCAPS_COD_FONTE4) && RCAPS_COD_FONTE4 == "0001");
                Assert.True(q31[1].TryGetValue("RCAPS_NUM_RCAP", out var RCAPS_NUM_RCAP4) && RCAPS_NUM_RCAP4 == "000000002");

                #endregion

                #region R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

                var q34 = AppSettings.TestSet.DynamicData["R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(q34?.Count > 1);
                Assert.True(q34[1].TryGetValue("NUMERAES_ENDOS_CANC_RESTI", out var NUMERAES_ENDOS_CANC_RESTI) && NUMERAES_ENDOS_CANC_RESTI == "000000003");
                Assert.True(q34[1].TryGetValue("NUMERAES_ORGAO_EMISSOR", out var NUMERAES_ORGAO_EMISSOR3) && NUMERAES_ORGAO_EMISSOR3 == "0000");
                Assert.True(q34[1].TryGetValue("NUMERAES_RAMO_EMISSOR", out var NUMERAES_RAMO_EMISSOR3) && NUMERAES_RAMO_EMISSOR3 == "0001");

                #endregion

                #region R3070_00_UPDATE_FONTES_DB_UPDATE_1_Update1

                var q37 = AppSettings.TestSet.DynamicData["R3070_00_UPDATE_FONTES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(q37?.Count > 1);
                Assert.True(q37[1].TryGetValue("FONTES_ULT_PROP_AUTOMAT", out var FONTES_ULT_PROP_AUTOMAT) && FONTES_ULT_PROP_AUTOMAT == "000078456");
                Assert.True(q37[1].TryGetValue("BILHETE_FONTE", out var BILHETE_FONTE) && BILHETE_FONTE == "0003");

                #endregion

                #region R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

                var q39 = AppSettings.TestSet.DynamicData["R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(q39?.Count > 1);
                Assert.True(q39[1].TryGetValue("ENDOSSOS_NUM_APOLICE", out var ENDOSSOS_NUM_APOLICE6) && ENDOSSOS_NUM_APOLICE6 == "0000000000000");

                #endregion

                #region R3120_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1

                var q40 = AppSettings.TestSet.DynamicData["R3120_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(q40?.Count > 1);
                Assert.True(q40[1].TryGetValue("ENDOSSOS_NUM_APOLICE", out var ENDOSSOS_NUM_APOLICE40) && ENDOSSOS_NUM_APOLICE40 == "0000000000000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_NUM_ENDOSSO", out var ENDOSSOS_NUM_ENDOSSO40) && ENDOSSOS_NUM_ENDOSSO40 == "000000003");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_RAMO_EMISSOR", out var ENDOSSOS_RAMO_EMISSOR40) && ENDOSSOS_RAMO_EMISSOR40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_PRODUTO", out var ENDOSSOS_COD_PRODUTO40) && ENDOSSOS_COD_PRODUTO40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_SUBGRUPO", out var ENDOSSOS_COD_SUBGRUPO40) && ENDOSSOS_COD_SUBGRUPO40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_FONTE", out var ENDOSSOS_COD_FONTE40) && ENDOSSOS_COD_FONTE40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_NUM_PROPOSTA", out var ENDOSSOS_NUM_PROPOSTA40) && ENDOSSOS_NUM_PROPOSTA40 == "000078456");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DATA_PROPOSTA", out var ENDOSSOS_DATA_PROPOSTA40) && ENDOSSOS_DATA_PROPOSTA40 == "          ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DATA_LIBERACAO", out var ENDOSSOS_DATA_LIBERACAO40) && ENDOSSOS_DATA_LIBERACAO40 == "          ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DATA_EMISSAO", out var ENDOSSOS_DATA_EMISSAO40) && ENDOSSOS_DATA_EMISSAO40 == "2020-01-01");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_NUM_RCAP", out var ENDOSSOS_NUM_RCAP40) && ENDOSSOS_NUM_RCAP40 == "000000000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_VAL_RCAP", out var ENDOSSOS_VAL_RCAP40) && ENDOSSOS_VAL_RCAP40 == "0000000000000.00");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_BCO_RCAP", out var ENDOSSOS_BCO_RCAP40) && ENDOSSOS_BCO_RCAP40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_AGE_RCAP", out var ENDOSSOS_AGE_RCAP40) && ENDOSSOS_AGE_RCAP40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DAC_RCAP", out var ENDOSSOS_DAC_RCAP40) && ENDOSSOS_DAC_RCAP40 == "0");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_TIPO_RCAP", out var ENDOSSOS_TIPO_RCAP40) && ENDOSSOS_TIPO_RCAP40 == "0");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_BCO_COBRANCA", out var ENDOSSOS_BCO_COBRANCA40) && ENDOSSOS_BCO_COBRANCA40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_AGE_COBRANCA", out var ENDOSSOS_AGE_COBRANCA40) && ENDOSSOS_AGE_COBRANCA40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DAC_COBRANCA", out var ENDOSSOS_DAC_COBRANCA40) && ENDOSSOS_DAC_COBRANCA40 == " ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DATA_INIVIGENCIA", out var ENDOSSOS_DATA_INIVIGENCIA40) && ENDOSSOS_DATA_INIVIGENCIA40 == "          ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DATA_TERVIGENCIA", out var ENDOSSOS_DATA_TERVIGENCIA40) && ENDOSSOS_DATA_TERVIGENCIA40 == "          ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_PLANO_SEGURO", out var ENDOSSOS_PLANO_SEGURO40) && ENDOSSOS_PLANO_SEGURO40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_PCT_ENTRADA", out var ENDOSSOS_PCT_ENTRADA40) && ENDOSSOS_PCT_ENTRADA40 == "000.00");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_PCT_ADIC_FRACIO", out var ENDOSSOS_PCT_ADIC_FRACIO40) && ENDOSSOS_PCT_ADIC_FRACIO40 == "000.00");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_QTD_DIAS_PRIMEIRA", out var ENDOSSOS_QTD_DIAS_PRIMEIRA40) && ENDOSSOS_QTD_DIAS_PRIMEIRA40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_QTD_PARCELAS", out var ENDOSSOS_QTD_PARCELAS40) && ENDOSSOS_QTD_PARCELAS40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_QTD_PRESTACOES", out var ENDOSSOS_QTD_PRESTACOES40) && ENDOSSOS_QTD_PRESTACOES40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_QTD_ITENS", out var ENDOSSOS_QTD_ITENS40) && ENDOSSOS_QTD_ITENS40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_TEXTO_PADRAO", out var ENDOSSOS_COD_TEXTO_PADRAO40) && ENDOSSOS_COD_TEXTO_PADRAO40 == "   ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_ACEITACAO", out var ENDOSSOS_COD_ACEITACAO40) && ENDOSSOS_COD_ACEITACAO40 == " ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_MOEDA_IMP", out var ENDOSSOS_COD_MOEDA_IMP40) && ENDOSSOS_COD_MOEDA_IMP40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_MOEDA_PRM", out var ENDOSSOS_COD_MOEDA_PRM40) && ENDOSSOS_COD_MOEDA_PRM40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_TIPO_ENDOSSO", out var ENDOSSOS_TIPO_ENDOSSO40) && ENDOSSOS_TIPO_ENDOSSO40 == "5");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_USUARIO", out var ENDOSSOS_COD_USUARIO40) && ENDOSSOS_COD_USUARIO40 == "BI7401B ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_OCORR_ENDERECO", out var ENDOSSOS_OCORR_ENDERECO40) && ENDOSSOS_OCORR_ENDERECO40 == "0000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_SIT_REGISTRO", out var ENDOSSOS_SIT_REGISTRO40) && ENDOSSOS_SIT_REGISTRO40 == "1");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DATA_RCAP", out var ENDOSSOS_DATA_RCAP40) && ENDOSSOS_DATA_RCAP40 == "          ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COD_EMPRESA", out var ENDOSSOS_COD_EMPRESA40) && ENDOSSOS_COD_EMPRESA40 == "000000000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_TIPO_CORRECAO", out var ENDOSSOS_TIPO_CORRECAO40) && ENDOSSOS_TIPO_CORRECAO40 == " ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_ISENTA_CUSTO", out var ENDOSSOS_ISENTA_CUSTO40) && ENDOSSOS_ISENTA_CUSTO40 == " ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_DATA_VENCIMENTO", out var ENDOSSOS_DATA_VENCIMENTO40) && ENDOSSOS_DATA_VENCIMENTO40 == "          ");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_COEF_PREFIX", out var ENDOSSOS_COEF_PREFIX40) && ENDOSSOS_COEF_PREFIX40 == "0000.00000");
                Assert.True(q40[1].TryGetValue("ENDOSSOS_VAL_CUSTO_EMISSAO", out var ENDOSSOS_VAL_CUSTO_EMISSAO40) && ENDOSSOS_VAL_CUSTO_EMISSAO40 == "0000000000000.00");

                #endregion

                #region R3130_00_INSERT_PARCELAS_DB_INSERT_1_Insert1

                var q41 = AppSettings.TestSet.DynamicData["R3130_00_INSERT_PARCELAS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(q41?.Count > 1);
                Assert.True(q41[1].TryGetValue("PARCELAS_NUM_APOLICE", out var PARCELAS_NUM_APOLICE) && PARCELAS_NUM_APOLICE == "0000000000000");
                Assert.True(q41[1].TryGetValue("PARCELAS_NUM_ENDOSSO", out var PARCELAS_NUM_ENDOSSO) && PARCELAS_NUM_ENDOSSO == "000000003");
                Assert.True(q41[1].TryGetValue("PARCELAS_NUM_PARCELA", out var PARCELAS_NUM_PARCELA) && PARCELAS_NUM_PARCELA == "0000");
                Assert.True(q41[1].TryGetValue("PARCELAS_DAC_PARCELA", out var PARCELAS_DAC_PARCELA) && PARCELAS_DAC_PARCELA == "0");
                Assert.True(q41[1].TryGetValue("PARCELAS_COD_FONTE", out var PARCELAS_COD_FONTE) && PARCELAS_COD_FONTE == "0000");
                Assert.True(q41[1].TryGetValue("PARCELAS_NUM_TITULO", out var PARCELAS_NUM_TITULO) && PARCELAS_NUM_TITULO == "0000000000000");
                Assert.True(q41[1].TryGetValue("PARCELAS_PRM_TARIFARIO_IX", out var PARCELAS_PRM_TARIFARIO_IX) && PARCELAS_PRM_TARIFARIO_IX == "0000000000.00000");
                Assert.True(q41[1].TryGetValue("PARCELAS_VAL_DESCONTO_IX", out var PARCELAS_VAL_DESCONTO_IX) && PARCELAS_VAL_DESCONTO_IX == "0000000000.00000");
                Assert.True(q41[1].TryGetValue("PARCELAS_PRM_LIQUIDO_IX", out var PARCELAS_PRM_LIQUIDO_IX) && PARCELAS_PRM_LIQUIDO_IX == "0000000000.00000");
                Assert.True(q41[1].TryGetValue("PARCELAS_ADICIONAL_FRAC_IX", out var PARCELAS_ADICIONAL_FRAC_IX) && PARCELAS_ADICIONAL_FRAC_IX == "0000000000.00000");
                Assert.True(q41[1].TryGetValue("PARCELAS_VAL_CUSTO_EMIS_IX", out var PARCELAS_VAL_CUSTO_EMIS_IX) && PARCELAS_VAL_CUSTO_EMIS_IX == "0000000000.00000");
                Assert.True(q41[1].TryGetValue("PARCELAS_VAL_IOCC_IX", out var PARCELAS_VAL_IOCC_IX) && PARCELAS_VAL_IOCC_IX == "0000000000.00000");
                Assert.True(q41[1].TryGetValue("PARCELAS_PRM_TOTAL_IX", out var PARCELAS_PRM_TOTAL_IX) && PARCELAS_PRM_TOTAL_IX == "0000000000.00000");
                Assert.True(q41[1].TryGetValue("PARCELAS_OCORR_HISTORICO", out var PARCELAS_OCORR_HISTORICO) && PARCELAS_OCORR_HISTORICO == "0002");
                Assert.True(q41[1].TryGetValue("PARCELAS_QTD_DOCUMENTOS", out var PARCELAS_QTD_DOCUMENTOS) && PARCELAS_QTD_DOCUMENTOS == "0000");
                Assert.True(q41[1].TryGetValue("PARCELAS_SIT_REGISTRO", out var PARCELAS_SIT_REGISTRO) && PARCELAS_SIT_REGISTRO == "1");
                Assert.True(q41[1].TryGetValue("PARCELAS_COD_EMPRESA", out var PARCELAS_COD_EMPRESA) && PARCELAS_COD_EMPRESA == "000000000");
                Assert.True(q41[1].TryGetValue("PARCELAS_SITUACAO_COBRANCA", out var PARCELAS_SITUACAO_COBRANCA) && PARCELAS_SITUACAO_COBRANCA == " ");

                #endregion


                Assert.True(program.RETURN_CODE == 000);
            }
        }


        [Theory]
        [InlineData("SBI7401B", "PRD.BI.D240919.BI7401B.SAIDA01_t2", "PRD.BI.D240919.BI7401B.SAIDA02_t2")]
        public static void BI7401B_Tests99_Theory(string SBI7401B_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P)
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

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region BI7401B_V0RELATORI
                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("BI7401B_V0RELATORI");
                AppSettings.TestSet.DynamicData.Add("BI7401B_V0RELATORI", q1);

                #endregion

                #region BI7401B_V0RCAPCOMP

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE", "1" },
                { "RCAPCOMP_NUM_RCAP", "2" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN", "3" },
                { "HOST_COUNT", "5" }
                });
                AppSettings.TestSet.DynamicData.Remove("BI7401B_V0RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("BI7401B_V0RCAPCOMP", q2);

                #region R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE", "1" },
                { "APOLICES_COD_PRODUTO", "2" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1", q3);

                #endregion


                #endregion

                #region R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO", "5" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT", "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF", "1" },
                { "CONVERSI_NUM_SICOB", "2" },
                { "CONVERSI_COD_PRODUTO_SIVPF", "3" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE", "1" },
                { "MOVDEBCE_NUM_ENDOSSO", "5" },
                { "MOVDEBCE_NUM_PARCELA", "3" },
                { "MOVDEBCE_SITUACAO_COBRANCA", "4" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE", "1" },
                { "MOVDEBCE_NUM_ENDOSSO", "5" },
                { "MOVDEBCE_NUM_PARCELA", "3" },
                { "MOVDEBCE_SITUACAO_COBRANCA", "4" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q11 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

                var q12 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP", "1" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN", "2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q13);

                #endregion

                #region R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP", "8" },
                { "RCAPS_COD_OPERACAO", "200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO", "874" },
                { "RCAPS_COD_OPERACAO", "200" },
                { "RCAPCOMP_COD_FONTE", "5" },
                { "RCAPCOMP_NUM_RCAP", "7845" },
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN", "3657" },
                { "RCAPCOMP_COD_OPERACAO", "1" },
                { "RCAPCOMP_BCO_AVISO", "1" },
                { "RCAPCOMP_AGE_AVISO", "2" },
                { "RCAPCOMP_NUM_AVISO_CREDITO", "12468" },
                { "RCAPCOMP_VAL_RCAP", "87" },
                { "RCAPCOMP_DATA_RCAP", "87" },
                { "RCAPCOMP_DATA_CADASTRAMENTO", "2020-01-01" },
                { "RCAPCOMP_SIT_CONTABIL", "1" },
                { "RCAPCOMP_COD_EMPRESA", "10" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ORGAO_EMISSOR", "SSP" },
                { "NUMERAES_RAMO_EMISSOR", "1" },
                { "NUMERAES_ENDOS_CANCELA", "0" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q22);

                #endregion

                #region BI7401B_V1RELATORI

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string> {
                { "RELATORI_RAMO_EMISSOR", "1" },
                { "RELATORI_NUM_APOLICE", "95874" },
                { "RELATORI_NUM_TITULO", "1235" },
                { "RELATORI_IND_PREV_DEFINIT", "1" },
                { "RELATORI_IND_ANAL_RESUMO", "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("BI7401B_V1RELATORI");
                AppSettings.TestSet.DynamicData.Add("BI7401B_V1RELATORI", q28);

                #endregion

                #region R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string> {
                { "RCAPS_SIT_REGISTRO", "1" },
                { "RCAPS_COD_OPERACAO", "200" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1", q29);

                #endregion

                #region BI7401B_V2RELATORI

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string> {
                { "RELATORI_RAMO_EMISSOR", "1" },
                { "RELATORI_NUM_APOLICE", "9874" },
                { "RELATORI_NUM_TITULO", "9658" },
                { "RELATORI_IND_PREV_DEFINIT", "1" },
                { "RELATORI_IND_ANAL_RESUMO", "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("BI7401B_V2RELATORI");
                AppSettings.TestSet.DynamicData.Add("BI7401B_V2RELATORI", q32);

                #endregion

                #region R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string> {
                { "NUMERAES_ORGAO_EMISSOR", "SSP" },
                { "NUMERAES_RAMO_EMISSOR", "1" },
                { "NUMERAES_ENDOS_CANC_RESTI", "2" },
                });
                AppSettings.TestSet.DynamicData.Remove("R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q33);

                #endregion

                #region R3050_00_SELECT_FONTES_DB_SELECT_1_Query1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT", "78454" }
                });
                AppSettings.TestSet.DynamicData.Remove("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1", q35);

                #endregion

                #region R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_PROPOSTA", "7541" }
                });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q36);

                #endregion

                #region R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE", "65984" },
                { "APOLICOB_NUM_ENDOSSO", "5647" },
                { "APOLICOB_NUM_ITEM", "125" },
                { "APOLICOB_OCORR_HISTORICO", "1" },
                { "APOLICOB_RAMO_COBERTURA", "2" },
                { "APOLICOB_MODALI_COBERTURA", "3" },
                { "APOLICOB_COD_COBERTURA", "95" },
                { "APOLICOB_IMP_SEGURADA_IX", "6" },
                { "APOLICOB_PRM_TARIFARIO_IX", "4" },
                { "APOLICOB_IMP_SEGURADA_VAR", "7" },
                { "APOLICOB_PRM_TARIFARIO_VAR", "8" },
                { "APOLICOB_PCT_COBERTURA", "9" },
                { "APOLICOB_FATOR_MULTIPLICA", "10" },
                { "APOLICOB_DATA_INIVIGENCIA", "110" },
                { "APOLICOB_DATA_TERVIGENCIA", "650" },
                { "APOLICOB_COD_EMPRESA", "30" },
                { "APOLICOB_SIT_REGISTRO", "20" }
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q43);

                #endregion

                #endregion
                var program = new BI7401B();
                program.Execute(SBI7401B_FILE_NAME_P, SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 099);
            }
        }


    }
}