using System;
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
using static Code.VA0123B;

namespace FileTests.Test
{
    [Collection("VA0123B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0123B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA0123B_CURS01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "1234"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_CERTIFICADO" , "654"},
                { "PROPOVA_COD_CLIENTE" , "33"},
                { "PROPOVA_OCORR_HISTORICO" , "2"},
                { "PROPOVA_DATA_QUITACAO" , "2024-09-09"},
                { "PROPOVA_DTPROXVEN" , "2024-11-11"},
                { "PROPOVA_NUM_PARCELA" , "1"},
                { "PROPOVA_OPCAO_COBERTURA" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0123B_CURS01", q0);

            #endregion

            #region VA0123B_CURS02

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0123B_CURS02", q1);

            #endregion

            #region R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R0005_00_UPDATE_ESTOQUE_DB_UPDATE_2_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_UPDATE_ESTOQUE_DB_UPDATE_2_Update1", q3);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_MOV_ABERTO" , "2024-10-10"},
                { "WS_DATA_MOV_ABERTO_1" , "2024-10-11"},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , "2024-10-12"},
                { "SISTEMAS_DATA_MOV_ABERTO_40" , "2024-10-13"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0110_00_SELECT_RELATORI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_RELATORI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_OCORR_HISTORICO" , "45"},
                { "SEGURVGA_NUM_ITEM" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SEGURHIS_DATA_MOVIMENTO" , "2023-12-31"}
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_OPCAO_CONJUGE" , "S"}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "VG130_IND_OPCAO_CONJUGE" , "S"},
                { "VG130_COD_TIPO_ASSISTENCIA" , "2"},
                { "VG130_STA_REGISTRO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , "11"}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1", q10);

            #endregion

            #region R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1120_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OPCAO_COBERTURA" , "2"},
                { "HISCOBPR_VLPREMIO" , "10000"},
                { "HISCOBPR_PRMVG" , "11000"},
                { "HISCOBPR_PRMAP" , "12000"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "2024-01-01"},
                { "HISCOBPR_DATA_INIVIG_1" , "2024-02-01"},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "12345678900"},
                { "CLIENTES_DATA_NASCIMENTO" , "1980-11-11"},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_IMPMORNATU" , ""},
                { "PLAVAVGA_IMPMORACID" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
                { "PLAVAVGA_PRMVG" , ""},
                { "PLAVAVGA_PRMAP" , ""},
                { "PLAVAVGA_FAIXA" , ""},
                { "PLAVAVGA_QTTITCAP" , ""},
                { "PLAVAVGA_VLTITCAP" , ""},
                { "PLAVAVGA_VLCUSTCAP" , ""},
                { "PLAVAVGA_PCT_FAIXA_ETARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_IMPMORNATU" , ""},
                { "PLAVAVGA_IMPMORACID" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
                { "PLAVAVGA_PRMVG" , ""},
                { "PLAVAVGA_PRMAP" , ""},
                { "PLAVAVGA_FAIXA" , ""},
                { "PLAVAVGA_QTTITCAP" , ""},
                { "PLAVAVGA_VLTITCAP" , ""},
                { "PLAVAVGA_VLCUSTCAP" , ""},
                { "PLAVAVGA_PCT_FAIXA_ETARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "GE406_IND_SERV_CONSULTA" , ""},
                { "GE406_IND_RET_SUBSCRICAO" , ""},
                { "GE406_PCT_AGRAVO" , ""},
                { "GE406_VLR_PRM_SEM_AGR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO_01" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2_Update1", q22);

            #endregion

            #region R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_OCORR_HISTORICO1" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
                { "PLAVAVGA_PRMVG" , ""},
                { "PLAVAVGA_PRMAP" , ""},
                { "PLAVAVGA_QTTITCAP" , ""},
                { "PLAVAVGA_VLTITCAP" , ""},
                { "PLAVAVGA_VLCUSTCAP" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO_01" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2_Update1", q25);

            #endregion

            #region R1615_00_MAX_PARCEVID_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_PARCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1615_00_MAX_PARCEVID_DB_SELECT_1_Query1", q26);

            #endregion

            #region R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_PARCELA1" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PLAVAVGA_PRMVG" , ""},
                { "PLAVAVGA_PRMAP" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PARCEVID_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R1630_00_INSERT_COBHISVI_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_UPDATE_1_Update1", q28);

            #endregion

            #region R1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1", q29);

            #endregion

            #region R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1", q30);

            #endregion

            #region R1630_00_INSERT_COBHISVI_DB_UPDATE_2_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_UPDATE_2_Update1", q31);

            #endregion

            #region R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_PARCELA1" , ""},
                { "WHOST_NRTITULO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PARCEVID_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "CONVEVG_COD_SEGURO" , ""},
                { "CONVEVG_COD_CONV_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1", q33);

            #endregion

            #region R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PARCEVID_NUM_PARCELA1" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
                { "WHOST_COD_CONVENIO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1", q34);

            #endregion

            #region R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_CERTIFICADO" , ""},
                { "WS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1", q35);

            #endregion

            #region R1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
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
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_LOTE" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R1700_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_OCORR_HISTORICO1" , ""},
                { "SUBGVGAP_COD_SUBGRUPO" , ""},
                { "PARCEVID_NUM_PARCELA1" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R1750_00_INSERT_RELATO_PF10_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1750_00_INSERT_RELATO_PF10_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_OCORR_HISTORICO1" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "SUBGVGAP_COD_SUBGRUPO" , ""},
                { "PLAVAVGA_FAIXA" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1", q39);

            #endregion

            #region R1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_HORA_OPERACAO" , ""},
                { "SEGURVGA_OCORR_HISTORICO1" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT_COBER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q41);

            #endregion

            #region R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q42);

            #endregion

            #region R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO1" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1", q43);

            #endregion

            #region R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO1" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1", q44);

            #endregion

            #region R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO_01" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1", q45);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0123B_Tests_Fact_AtualizaRelatorio_ReturnCode_00()
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

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_MOV_ABERTO" , "2024-10-10"},
                { "WS_DATA_MOV_ABERTO_1" , "2024-10-11"},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , "2024-10-30"},
                { "SISTEMAS_DATA_MOV_ABERTO_40" , "2024-10-31"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q4);
                #endregion

                #endregion

                #region R0110_00_SELECT_RELATORI_DB_SELECT_1_Query1
                #endregion
                var program = new VA0123B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 00);
                var envList0 = AppSettings.TestSet.DynamicData["R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("RELATORI_DATA_REFERENCIA", out var val0r) && val0r.Contains("2024-10-30"));
            }
        }

        [Fact]
        public static void VA0123B_Tests_Fact_ErroCursor_ReturnCode_99()
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
                #region VA0123B_CURS01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "1234"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_CERTIFICADO" , "19790324"},
                { "PROPOVA_COD_CLIENTE" , "33"},
                { "PROPOVA_OCORR_HISTORICO" , "2"},
                { "PROPOVA_DATA_QUITACAO" , "2024-09-09"},
                { "PROPOVA_DTPROXVEN" , "2024-11-11"},
                { "PROPOVA_NUM_PARCELA" , "1"},
                { "PROPOVA_OPCAO_COBERTURA" , "3"},
                }, new SQLCA(100));
       
                AppSettings.TestSet.DynamicData.Remove("VA0123B_CURS01");
                AppSettings.TestSet.DynamicData.Add("VA0123B_CURS01", q0);

                #endregion
                #endregion

                #region R0110_00_SELECT_RELATORI_Query1
                #endregion
                var program = new VA0123B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Fact]
        public static void VA0123B_Tests_Fact_Fluxo_ReturnCode_00()
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
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_MOV_ABERTO" , "2024-10-10"},
                { "WS_DATA_MOV_ABERTO_1" , "2024-03-24"},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , "2024-10-12"},
                { "SISTEMAS_DATA_MOV_ABERTO_40" , "2024-10-13"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q4);
                #endregion
                #region VA0123B_CURS01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "1234"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_CERTIFICADO" , "19790324"},
                { "PROPOVA_COD_CLIENTE" , "33"},
                { "PROPOVA_OCORR_HISTORICO" , "2"},
                { "PROPOVA_DATA_QUITACAO" , "2024-09-09"},
                { "PROPOVA_DTPROXVEN" , "2024-11-11"},
                { "PROPOVA_NUM_PARCELA" , "1"},
                { "PROPOVA_OPCAO_COBERTURA" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0123B_CURS01");
                AppSettings.TestSet.DynamicData.Add("VA0123B_CURS01", q0);

                #endregion

                #region R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1
                var q7 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1", q7);
                #endregion
                #region R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "1"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "0001"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "1"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "1454496"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "2"},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "5200654789650044"},
                { "OPCPAGVI_PERI_PAGAMENTO" , "12"},
                });

                AppSettings.TestSet.DynamicData.Remove("R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "VG130_IND_OPCAO_CONJUGE" , "S"},
                { "VG130_COD_TIPO_ASSISTENCIA" , "2"},
                { "VG130_STA_REGISTRO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1", q9);

                #endregion
                #region R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OPCAO_COBERTURA" , "2"},
                { "HISCOBPR_VLPREMIO" , "10000"},
                { "HISCOBPR_PRMVG" , "11000"},
                { "HISCOBPR_PRMAP" , "12000"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "2024-01-01"},
                { "HISCOBPR_DATA_INIVIG_1" , "2024-02-01"},
                });
                q13.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OPCAO_COBERTURA" , "1"},
                { "HISCOBPR_VLPREMIO" , "10000"},
                { "HISCOBPR_PRMVG" , "11000"},
                { "HISCOBPR_PRMAP" , "12000"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "2024-01-01"},
                { "HISCOBPR_DATA_INIVIG_1" , "2024-02-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q13);

                #endregion
                #region R1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "GE406_IND_SERV_CONSULTA" , "1"},
                { "GE406_IND_RET_SUBSCRICAO" , "1"},
                { "GE406_PCT_AGRAVO" , "10"},
                { "GE406_VLR_PRM_SEM_AGR" , "5000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1", q17);

                #endregion
                #region R1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_IMPMORNATU" , "1"},
                { "PLAVAVGA_IMPMORACID" , "2"},
                { "PLAVAVGA_VLPREMIOTOT" , "2222"},
                { "PLAVAVGA_PRMVG" , "3333"},
                { "PLAVAVGA_PRMAP" , "3334"},
                { "PLAVAVGA_FAIXA" , "43"},
                { "PLAVAVGA_QTTITCAP" , "1"},
                { "PLAVAVGA_VLTITCAP" , "2000"},
                { "PLAVAVGA_VLCUSTCAP" , "3000"},
                { "PLAVAVGA_PCT_FAIXA_ETARIA" , "13"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1", q15);

                #endregion
                #region R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q19);

                #endregion
                #region R1615_00_MAX_PARCEVID_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_PARCELA" , "5"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1615_00_MAX_PARCEVID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1615_00_MAX_PARCEVID_DB_SELECT_1_Query1", q26);

                #endregion
                #region R1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , "554499"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1", q29);

                #endregion
                #region R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1", q30);

                #endregion
                #region R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "CONVEVG_COD_SEGURO" , "1979"},
                { "CONVEVG_COD_CONV_CARTAO" , "260"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1", q33);

                #endregion
                #region R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , "20"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1", q10);

                #endregion
                #region R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1

                var q35 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1", q35);

                #endregion
                #region VA0123B_CURS02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , "20100826"},
                { "APOLICOB_NUM_ENDOSSO" , "2010"},
                { "APOLICOB_NUM_ITEM" , "1"},
                { "APOLICOB_RAMO_COBERTURA" , "2"},
                { "APOLICOB_COD_COBERTURA" , "77"},
                { "APOLICOB_MODALI_COBERTURA" , "4"},
                { "APOLICOB_OCORR_HISTORICO" , "65"},
                { "APOLICOB_IMP_SEGURADA_IX" , "20"},
                { "APOLICOB_PRM_TARIFARIO_IX" , "275"},
                { "APOLICOB_IMP_SEGURADA_VAR" , "122"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "321"},
                { "APOLICOB_PCT_COBERTURA" , "12"},
                { "APOLICOB_FATOR_MULTIPLICA" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0123B_CURS02");
                AppSettings.TestSet.DynamicData.Add("VA0123B_CURS02", q1);


                #endregion
                #endregion
                var program = new VA0123B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 00);

                var envList0 = AppSettings.TestSet.DynamicData["R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0.Count > 1);
                Assert.True(envList0[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val0r) && val0r.Contains("19790324"));
                Assert.True(envList0[1].TryGetValue("OPCPAGVI_OPCAO_PAGAMENTO", out var val1r) && val1r.Contains("1"));
                Assert.True(envList0[1].TryGetValue("PRODUVG_PERI_PAGAMENTO", out var val2r) && val2r.Contains("1"));

                var envList1 = AppSettings.TestSet.DynamicData["R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val3r) && val3r.Contains("19790324"));
                Assert.True(envList1[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO_01", out var val4r) && val4r.Contains("2024-03-24"));

                var envList2 = AppSettings.TestSet.DynamicData["R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val5r) && val5r.Contains("19790324"));

                var envList3 = AppSettings.TestSet.DynamicData["R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val6r) && val6r.Contains("19790324"));
                Assert.True(envList3[1].TryGetValue("PLAVAVGA_VLPREMIOTOT", out var val7r) && val7r.Contains("6667"));
                Assert.True(envList3[1].TryGetValue("PLAVAVGA_VLTITCAP", out var val8r) && val8r.Contains("2000"));

                var envList4 = AppSettings.TestSet.DynamicData["R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO_01", out var val9r) && val9r.Contains("2024-03-24"));
                Assert.True(envList4[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val10r) && val10r.Contains("19790324"));

                var envList5 = AppSettings.TestSet.DynamicData["R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val11r) && val11r.Contains("19790324"));

                var envList6 = AppSettings.TestSet.DynamicData["R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6.Count > 1);
                Assert.True(envList6[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val12r) && val12r.Contains("19790324"));
                Assert.True(envList6[1].TryGetValue("PARCEVID_NUM_PARCELA", out var val13r) && val13r.Contains("5"));
                Assert.True(envList6[1].TryGetValue("PLAVAVGA_PRMVG", out var val14r) && val14r.Contains("3333"));

                Assert.True(program.WHOST_NRTITULO == "554499");

                var envList7 = AppSettings.TestSet.DynamicData["R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7.Count > 1);
                Assert.True(envList7[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val15r) && val15r.Contains("19790324"));
                Assert.True(envList7[1].TryGetValue("PARCEVID_NUM_PARCELA", out var val16r) && val16r.Contains("5"));
                Assert.True(envList7[1].TryGetValue("WHOST_NRTITULO", out var val17r) && val17r.Contains("554499"));

                var envList8 = AppSettings.TestSet.DynamicData["R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList8.Count > 1);
                Assert.True(envList8[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val18r) && val18r.Contains("19790324"));
                Assert.True(envList8[1].TryGetValue("WHOST_COD_CONVENIO", out var val19r) && val19r.Contains("1979"));

                var envList9 = AppSettings.TestSet.DynamicData["R1700_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val20r) && val20r.Contains("19790324"));
                Assert.True(envList9[1].TryGetValue("SUBGVGAP_COD_SUBGRUPO", out var val21r) && val21r.Contains("20"));

                var envList10 = AppSettings.TestSet.DynamicData["R1750_00_INSERT_RELATO_PF10_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList10.Count > 1);
                Assert.True(envList10[1].TryGetValue("RELATORI_NUM_CERTIFICADO", out var val22r) && val22r.Contains("19790324"));
                Assert.True(envList10[1].TryGetValue("RELATORI_COD_SUBGRUPO", out var val23r) && val23r.Contains("20"));
                Assert.True(envList10[1].TryGetValue("RELATORI_COD_USUARIO", out var val24r) && val24r.Contains("VA0123B"));

                var envList11 = AppSettings.TestSet.DynamicData["R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList11[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val25r) && val25r.Contains("19790324"));
                Assert.True(envList11[1].TryGetValue("SUBGVGAP_COD_SUBGRUPO", out var val26r) && val26r.Contains("20"));
                Assert.True(envList11[1].TryGetValue("PLAVAVGA_FAIXA", out var val27r) && val27r.Contains("43"));

                var envList12 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList12.Count > 1);
                Assert.True(envList12[1].TryGetValue("APOLICOB_NUM_APOLICE", out var val28r) && val28r.Contains("20100826"));
                Assert.True(envList12[1].TryGetValue("APOLICOB_NUM_ENDOSSO", out var val29r) && val29r.Contains("2010"));

                var envList13 = AppSettings.TestSet.DynamicData["R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList13[1].TryGetValue("APOLICOB_NUM_APOLICE", out var val30r) && val30r.Contains("20100826"));
                Assert.True(envList13[1].TryGetValue("APOLICOB_NUM_ENDOSSO", out var val31r) && val31r.Contains("2010"));
                Assert.True(envList13[1].TryGetValue("APOLICOB_COD_COBERTURA", out var val32r) && val32r.Contains("77"));


                var envList14 = AppSettings.TestSet.DynamicData["R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList14[1].TryGetValue("RELATORI_DATA_REFERENCIA", out var val33r) && val33r.Contains("2024-10-12"));

            }
        }

    }
}