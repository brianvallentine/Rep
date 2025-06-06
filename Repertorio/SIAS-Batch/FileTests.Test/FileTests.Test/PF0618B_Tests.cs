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
using static Code.PF0618B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0618B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0618B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-03"}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2024-09-05"}
            });
            AppSettings.TestSet.DynamicData.Add("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "12458"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region PF0618B_MOVIMENTO_VGAP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_WS_SELECT" , "3"},
                { "MOVIMVGA_NUM_APOLICE" , "81010000001"},
                { "MOVIMVGA_COD_SUBGRUPO" , "1"},
                { "MOVIMVGA_COD_FONTE" , "10"},
                { "MOVIMVGA_NUM_PROPOSTA" , "721650"},
                { "MOVIMVGA_TIPO_SEGURADO" , "1"},
                { "MOVIMVGA_NUM_CERTIFICADO" , "10000649295"},
                { "MOVIMVGA_DAC_CERTIFICADO" , "7"},
                { "MOVIMVGA_IDE_SEXO" , " "},
                { "MOVIMVGA_PCT_CONJUGE_VG" , "0.00"},
                { "MOVIMVGA_PCT_CONJUGE_AP" , "0.00"},
                { "MOVIMVGA_QTD_SAL_MORNATU" , "0"},
                { "MOVIMVGA_QTD_SAL_MORACID" , "0"},
                { "MOVIMVGA_QTD_SAL_INVPERM" , "0"},
                { "MOVIMVGA_TAXA_AP_MORACID" , "0.0310"},
                { "MOVIMVGA_TAXA_AP_INVPERM" , "0.0620"},
                { "MOVIMVGA_TAXA_AP_AMDS" , "0.0000"},
                { "MOVIMVGA_TAXA_AP_DH" , "0.0000"},
                { "MOVIMVGA_TAXA_AP_DIT" , "0.0000"},
                { "MOVIMVGA_TAXA_VG" , "0.0000"},
                { "MOVIMVGA_IMP_MORNATU_ANT" , "0.00"},
                { "MOVIMVGA_IMP_MORNATU_ATU" , "0.00"},
                { "MOVIMVGA_IMP_MORACID_ANT" , "94.79"},
                { "MOVIMVGA_IMP_MORACID_ATU" , "94.79"},
                { "MOVIMVGA_IMP_INVPERM_ANT" , "94.79"},
                { "MOVIMVGA_IMP_INVPERM_ATU" , "94.79"},
                { "MOVIMVGA_IMP_AMDS_ANT" , "0.00"},
                { "MOVIMVGA_IMP_AMDS_ATU" , "0.00"},
                { "MOVIMVGA_IMP_DH_ANT" , "0.00"},
                { "MOVIMVGA_IMP_DH_ATU" , "0.00"},
                { "MOVIMVGA_IMP_DIT_ANT" , "0.00"},
                { "MOVIMVGA_IMP_DIT_ATU" , "0.00"},
                { "MOVIMVGA_PRM_VG_ANT" , "0.00"},
                { "MOVIMVGA_PRM_VG_ATU" , "0.00"},
                { "MOVIMVGA_PRM_AP_ANT" , "0.79"},
                { "MOVIMVGA_PRM_AP_ATU" , "0.79"},
                { "MOVIMVGA_COD_OPERACAO" , "402"},
                { "MOVIMVGA_DATA_OPERACAO" , "1996-01-23"},
                { "MOVIMVGA_DATA_REFERENCIA" , "1990-07-09"},
                { "MOVIMVGA_DATA_MOVIMENTO" , "1995-09-13"},
                { "MOVIMVGA_DATA_INCLUSAO" , "1996-01-23"},
                { "MOVIMVGA_COD_SUBGRUPO_TRANS" , "0"},
                { "MOVIMVGA_SIT_REGISTRO" , "1"},
                { "MOVIMVGA_COD_USUARIO" , "AGDAROSA"},
                { "PRODUVG_COD_PRODUTO" , "9304"},
                { "PRODUVG_PERI_PAGAMENTO" , "1"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_WS_SELECT" , "3"},
                { "MOVIMVGA_NUM_APOLICE" , "81010000001"},
                { "MOVIMVGA_COD_SUBGRUPO" , "1"},
                { "MOVIMVGA_COD_FONTE" , "10"},
                { "MOVIMVGA_NUM_PROPOSTA" , "721650"},
                { "MOVIMVGA_TIPO_SEGURADO" , "1"},
                { "MOVIMVGA_NUM_CERTIFICADO" , "10000649295"},
                { "MOVIMVGA_DAC_CERTIFICADO" , "7"},
                { "MOVIMVGA_IDE_SEXO" , " "},
                { "MOVIMVGA_PCT_CONJUGE_VG" , "0.00"},
                { "MOVIMVGA_PCT_CONJUGE_AP" , "0.00"},
                { "MOVIMVGA_QTD_SAL_MORNATU" , "0"},
                { "MOVIMVGA_QTD_SAL_MORACID" , "0"},
                { "MOVIMVGA_QTD_SAL_INVPERM" , "0"},
                { "MOVIMVGA_TAXA_AP_MORACID" , "0.0310"},
                { "MOVIMVGA_TAXA_AP_INVPERM" , "0.0620"},
                { "MOVIMVGA_TAXA_AP_AMDS" , "0.0000"},
                { "MOVIMVGA_TAXA_AP_DH" , "0.0000"},
                { "MOVIMVGA_TAXA_AP_DIT" , "0.0000"},
                { "MOVIMVGA_TAXA_VG" , "0.0000"},
                { "MOVIMVGA_IMP_MORNATU_ANT" , "0.00"},
                { "MOVIMVGA_IMP_MORNATU_ATU" , "0.00"},
                { "MOVIMVGA_IMP_MORACID_ANT" , "94.79"},
                { "MOVIMVGA_IMP_MORACID_ATU" , "94.79"},
                { "MOVIMVGA_IMP_INVPERM_ANT" , "94.79"},
                { "MOVIMVGA_IMP_INVPERM_ATU" , "94.79"},
                { "MOVIMVGA_IMP_AMDS_ANT" , "0.00"},
                { "MOVIMVGA_IMP_AMDS_ATU" , "0.00"},
                { "MOVIMVGA_IMP_DH_ANT" , "0.00"},
                { "MOVIMVGA_IMP_DH_ATU" , "0.00"},
                { "MOVIMVGA_IMP_DIT_ANT" , "0.00"},
                { "MOVIMVGA_IMP_DIT_ATU" , "0.00"},
                { "MOVIMVGA_PRM_VG_ANT" , "0.00"},
                { "MOVIMVGA_PRM_VG_ATU" , "0.00"},
                { "MOVIMVGA_PRM_AP_ANT" , "0.79"},
                { "MOVIMVGA_PRM_AP_ATU" , "0.79"},
                { "MOVIMVGA_COD_OPERACAO" , "402"},
                { "MOVIMVGA_DATA_OPERACAO" , "1996-01-23"},
                { "MOVIMVGA_DATA_REFERENCIA" , "1990-07-09"},
                { "MOVIMVGA_DATA_MOVIMENTO" , "1995-09-13"},
                { "MOVIMVGA_DATA_INCLUSAO" , "1996-01-23"},
                { "MOVIMVGA_COD_SUBGRUPO_TRANS" , "0"},
                { "MOVIMVGA_SIT_REGISTRO" , "1"},
                { "MOVIMVGA_COD_USUARIO" , "AGDAROSA"},
                { "PRODUVG_COD_PRODUTO" , "9304"},
                { "PRODUVG_PERI_PAGAMENTO" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("PF0618B_MOVIMENTO_VGAP", q3);

            #endregion

            #region R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , "1"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "3"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , "1"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "331"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "331"}
            });
            AppSettings.TestSet.DynamicData.Add("R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0157_00_OBTER_PERIPGTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "332"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "332"}
            });
            AppSettings.TestSet.DynamicData.Add("R0157_00_OBTER_PERIPGTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , "555"},
                { "PROPFIDH_NSAS_SIVPF" , "1"},
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1"},
                { "PROPFIDH_DATA_SITUACAO" , "1900-01-01"},
                { "PROPFIDH_SIT_PROPOSTA" , "EMT"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , "555"},
                { "PROPFIDH_NSAS_SIVPF" , "1"},
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1"},
                { "PROPFIDH_DATA_SITUACAO" , "1900-01-01"},
                { "PROPFIDH_SIT_PROPOSTA" , "EMT"},
            });
            AppSettings.TestSet.DynamicData.Add("R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""},
                { "PROPFIDH_DATA_SITUACAO" , ""},
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPFIDH_SIT_COBRANCA_SIVPF" , ""},
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , ""},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , ""},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "81010000001"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "1"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "81010000001"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "1"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "81010000001"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "1"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "81010000001"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "1"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
            });
            AppSettings.TestSet.DynamicData.Add("R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0515_00_OBTER_VIGENCIA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0515_00_OBTER_VIGENCIA_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1", q12);

            #endregion

            #region R0517_00_ACESSAR_COBERAPOL_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0517_00_ACESSAR_COBERAPOL_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_DATA_OCORRENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0520_00_ACESSA_APOLICE_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "11"}
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "11"}
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "11"}
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_ACESSA_APOLICE_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0525_00_OBTER_PCT_IOF_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "1"}
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "1"}
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "1"}
            });

            AppSettings.TestSet.DynamicData.Add("R0525_00_OBTER_PCT_IOF_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "9321"},
                { "PROPOVA_DATA_MOVIMENTO" , "2008-07-31"},
                { "PROPOVA_IDE_SEXO" , "M"},
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "9322"},
                { "PROPOVA_DATA_MOVIMENTO" , "2008-07-31"},
                { "PROPOVA_IDE_SEXO" , "M"},
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "9323"},
                { "PROPOVA_DATA_MOVIMENTO" , "2008-07-30"},
                { "PROPOVA_IDE_SEXO" , "M"},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , "1990-07-10"}
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , "1990-07-10"}
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , "1990-07-10"}
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , "1990-07-10"}
            });
            AppSettings.TestSet.DynamicData.Add("R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_APOLICE" , ""},
                { "MOVIMVGA_COD_SUBGRUPO" , ""},
                { "MOVIMVGA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q23);

            #endregion

            #region PARAMETERS_SubVG0710S

            #region Execute_DB_SELECT_1_Query1
            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-09-02"},

            });
            q31.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-09-02"},

            });
            q31.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-09-02"},

            });
            q31.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-09-02"},

            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q31);

            #endregion

            #region M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1
            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "0.0001"},
                { "TAXA_AP_INVPERM" , "0"},
                { "TAXA_AP_AMDS" , "0"},
                { "TAXA_AP_DH" , "0"},
                { "TAXA_AP_DIT" , "0"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "100"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},


            });
            q32.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "0.0001"},
                { "TAXA_AP_INVPERM" , "0"},
                { "TAXA_AP_AMDS" , "0"},
                { "TAXA_AP_DH" , "0"},
                { "TAXA_AP_DIT" , "0"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "100"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},


            });
            q32.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "0.0001"},
                { "TAXA_AP_INVPERM" , "0"},
                { "TAXA_AP_AMDS" , "0"},
                { "TAXA_AP_DH" , "0"},
                { "TAXA_AP_DIT" , "0"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "100"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},


            });
            q32.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "0.0001"},
                { "TAXA_AP_INVPERM" , "0"},
                { "TAXA_AP_AMDS" , "0"},
                { "TAXA_AP_DH" , "0"},
                { "TAXA_AP_DIT" , "0"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "100"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},


            });
            q32.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "0.0001"},
                { "TAXA_AP_INVPERM" , "0"},
                { "TAXA_AP_AMDS" , "0"},
                { "TAXA_AP_DH" , "0"},
                { "TAXA_AP_DIT" , "0"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "100"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},


            });
            AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1", q32);

            #endregion

            #region M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1
            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1", q33);

            #endregion
            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0618B_00.txt")]
        public static void PF0618B_Tests_Theory(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0618B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //arquivo
                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);


                //R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val8r) && val8r.Contains("STASASSE"));
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val9r) && val9r.Contains("4"));

                //R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("RELATORI_DATA_REFERENCIA", out var valor) && valor.Contains("2024-09-05"));
                                
            }
        }
        [Theory]
        [InlineData("Saida_PF0618B_01.txt")]
        public static void PF0618B_Tests_TheorySemHistorico(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new PF0618B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //arquivo
                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                //teste especifico para o call do Subprograma VG0710S
                //Verifica se o parametro do subprograma foi alterado
                Assert.True(program.PARAMETROS.LK_COBT_MORTE_ACIDENTAL != 0);

                //R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1

                var envList1 = AppSettings.TestSet.DynamicData["R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("PROPFIDH_DATA_SITUACAO", out var val8r) && val8r.Contains("1996-01-23"));
                Assert.True(envList1[1].TryGetValue("PROPFIDH_NUM_IDENTIFICACAO", out var val9r) && val9r.Contains("1"));

                //R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PROPFIDH_SIT_PROPOSTA", out var valor) && valor.Contains("OBT"));
                Assert.True(envList[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var val2r) && val2r.Contains("12459"));

                //R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("MOVIMVGA_NUM_APOLICE", out var val3r) && val3r.Contains("81010000001"));
                Assert.True(envList2[1].TryGetValue("MOVIMVGA_COD_SUBGRUPO", out var val4r) && val4r.Contains("1"));

            }
        }

        [Theory]
        [InlineData("Saida_PF0618B_03.txt")]
        public static void PF0618B_Tests_TheoryERRO99(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion
                var program = new PF0618B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}