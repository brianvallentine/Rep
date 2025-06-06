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
using static Code.VG0816B;

namespace FileTests.Test
{
    [Collection("VG0816B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0816B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0816B_V0MOVIMCOB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_COD_EMPRESA" , ""},
                { "V0MOVC_CODMOV" , ""},
                { "V0MOVC_BCOAVISO" , ""},
                { "V0MOVC_AGEAVISO" , ""},
                { "V0MOVC_NRAVISO" , ""},
                { "V0MOVC_NUMFITA" , ""},
                { "V0MOVC_DTMOVTO" , ""},
                { "V0MOVC_DTQITBCO" , ""},
                { "V0MOVC_NRTIT" , ""},
                { "V0MOVC_NUM_APOLICE" , ""},
                { "V0MOVC_NRENDOS" , ""},
                { "V0MOVC_NRPARCEL" , ""},
                { "V0MOVC_VALTIT" , ""},
                { "V0MOVC_VLIOCC" , ""},
                { "V0MOVC_VALCDT" , ""},
                { "V0MOVC_SITUACAO" , ""},
                { "V0MOVC_NOME" , ""},
                { "V0MOVC_TIPO_MOVIMENTO" , ""},
                { "V0MOVC_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0816B_V0MOVIMCOB", q1);

            #endregion

            #region VG0816B_CVGRAMOCOMP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "VG081_NUM_APOLICE" , ""},
                { "VG081_COD_SUBGRUPO" , ""},
                { "VG081_COD_GRUPO_SUSEP" , ""},
                { "VG081_RAMO_EMISSOR" , ""},
                { "VG081_COD_MODALIDADE" , ""},
                { "VG081_DTH_INI_VIGENCIA" , ""},
                { "VG081_COD_OPCAO_COBERTURA" , ""},
                { "VG081_NUM_IDADE_INICIAL" , ""},
                { "VG081_NUM_IDADE_FINAL" , ""},
                { "VG081_VLR_PERC_PREMIO" , ""},
                { "VG081_COD_USUARIO" , ""},
                { "VG081_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0816B_CVGRAMOCOMP", q2);

            #endregion

            #region R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_CODOPER" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0210_00_SELECT_GE403_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_IDLG" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_SELECT_GE403_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0220_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_CODOPER" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_NUM_APOLICE" , ""},
                { "V0MOVC_NRENDOS" , ""},
                { "V0MOVC_NRPARCEL" , ""},
                { "V0FOLL_DACPARC" , ""},
                { "V0MOVC_DTMOVTO" , ""},
                { "V0FOLL_HORAOPER" , ""},
                { "V0MOVC_VALTIT" , ""},
                { "V0MOVC_BCOAVISO" , ""},
                { "V0MOVC_AGEAVISO" , ""},
                { "V0MOVC_NRAVISO" , ""},
                { "V0FOLL_CODBAIXA" , ""},
                { "V0FOLL_CDERRO01" , ""},
                { "V0FOLL_CDERRO02" , ""},
                { "V0FOLL_CDERRO03" , ""},
                { "V0FOLL_CDERRO04" , ""},
                { "V0FOLL_CDERRO05" , ""},
                { "V0FOLL_CDERRO06" , ""},
                { "V0FOLL_SITUACAO" , ""},
                { "V0FOLL_SITCONTB" , ""},
                { "V0FOLL_OPERACAO" , ""},
                { "V0FOLL_DTLIBER" , ""},
                { "V0MOVC_DTQITBCO" , ""},
                { "V0FOLL_CODEMP" , ""},
                { "V0FOLL_ORDLIDER" , ""},
                { "V0FOLL_TIPSGU" , ""},
                { "V0FOLL_APOLIDER" , ""},
                { "V0FOLL_ENDOSLID" , ""},
                { "V0FOLL_CODLIDER" , ""},
                { "V0FOLL_FONTE" , ""},
                { "V0FOLL_NRRCAP" , ""},
                { "V0MOVC_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_NRPARCEL" , ""},
                { "V0MOVC_SITUACAO" , ""},
                { "V0MOVC_NRTIT" , ""},
                { "V0MOVC_NOME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_OPCAO_COBER" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , ""},
                { "V0PROP_RISCO" , ""},
                { "V0PROP_ESTR_COBR" , ""},
                { "V0PROP_ORIG_PRODU" , ""},
                { "V0PROP_CUSTOCAP_TOTAL" , ""},
                { "V0PROP_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_PRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMTOT" , ""},
                { "V0COBP_IMPMORNATU" , ""},
                { "V0COBP_IMPMORACID" , ""},
                { "V0COBP_IMPDIT" , ""},
                { "V0COBP_QUANT_VIDAS" , ""},
                { "V0COBP_IMPINVPERM" , ""},
                { "V0COBP_IMPDH" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMTOT" , ""},
                { "V0COBP_IMPMORNATU" , ""},
                { "V0COBP_IMPMORACID" , ""},
                { "V0COBP_IMPDIT" , ""},
                { "V0COBP_QUANT_VIDAS" , ""},
                { "V0COBP_IMPINVPERM" , ""},
                { "V0COBP_IMPDH" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0MOVC_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0HCTVA_PRMVG" , ""},
                { "V0HCTVA_PRMAP" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "V0HCTB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R0560_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0560_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1", q15);

            #endregion

            #region VG0816B_CDIFP

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0DIFPA_NRPARCELDIF" , ""},
                { "V0DIFPA_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0816B_CDIFP", q16);

            #endregion

            #region R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_IMP_SEGURADA_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_TAXA_AP_MORACID" , ""},
                { "CONDITEC_TAXA_AP_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_AMDS" , ""},
                { "CONDITEC_TAXA_AP_DH" , ""},
                { "CONDITEC_TAXA_AP_DIT" , ""},
                { "CONDITEC_TAXA_AP" , ""},
                { "CONDITEC_CARREGA_PRINCIPAL" , ""},
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_CARREGA_FILHOS" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0800_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "WHOST_GRUPO_SUSEP" , ""},
                { "WHOST_COD_RAMO" , ""},
                { "VG082_COD_MODALIDADE" , ""},
                { "VG082_COD_COBERTURA" , ""},
                { "WHOST_PREMIO_CONJ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R1000_00_PROCESSA_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1000_00_PROCESSA_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R1000_00_PROCESSA_DB_SELECT_2_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTAUXF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_DB_SELECT_2_Query1", q22);

            #endregion

            #region R1000_00_PROCESSA_DB_UPDATE_2_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , ""},
                { "V0MOVC_BCOAVISO" , ""},
                { "V0MOVC_AGEAVISO" , ""},
                { "WHOST_SITUACAO" , ""},
                { "V0MOVC_NRAVISO" , ""},
                { "V0MOVC_NRTIT" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_DB_UPDATE_2_Update1", q23);

            #endregion

            #region R1020_00_INCLUI_CDG_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0HCOB_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_INCLUI_CDG_DB_INSERT_1_Insert1", q24);

            #endregion

            #region R1000_00_PROCESSA_DB_UPDATE_3_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_DB_UPDATE_3_Update1", q25);

            #endregion

            #region R1000_00_PROCESSA_DB_UPDATE_4_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_VALTIT" , ""},
                { "V0MOVC_BCOAVISO" , ""},
                { "V0MOVC_AGEAVISO" , ""},
                { "V0MOVC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_DB_UPDATE_4_Update1", q26);

            #endregion

            #region R1040_00_REPASSA_CDG_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1040_00_REPASSA_CDG_DB_SELECT_1_Query1", q27);

            #endregion

            #region R1040_00_REPASSA_CDG_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1040_00_REPASSA_CDG_DB_INSERT_1_Insert1", q28);

            #endregion

            #region VG0816B_CDIFPA

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0DIFPA_NRPARCELDIF" , ""},
                { "V0DIFPA_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0816B_CDIFPA", q29);

            #endregion

            #region R1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1", q30);

            #endregion

            #region R1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0DIFPA_NRPARCELDIF" , ""},
                { "V0SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1", q31);

            #endregion

            #region R1120_00_INCLUI_SAF_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0SAFC_VLCUSTAUXF" , ""},
                { "V0HCOB_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_INCLUI_SAF_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R1120_00_INCLUI_SAF_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_INCLUI_SAF_DB_SELECT_1_Query1", q33);

            #endregion

            #region R1120_00_INCLUI_SAF_DB_INSERT_2_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTAUXF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_INCLUI_SAF_DB_INSERT_2_Insert1", q34);

            #endregion

            #region R1140_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1140_00_REPASSA_SAF_DB_SELECT_1_Query1", q35);

            #endregion

            #region R1140_00_REPASSA_SAF_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTAUXF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1140_00_REPASSA_SAF_DB_INSERT_1_Insert1", q36);

            #endregion

            #region VG0816B_CCMPTIT

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0CMPT_NRPARCEL" , ""},
                { "V0CMPT_CODOPER" , ""},
                { "V0CMPT_VLPRMDIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0816B_CCMPTIT", q37);

            #endregion

            #region R1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1", q38);

            #endregion

            #region R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTAUXF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1", q39);

            #endregion

            #region R1210_50_LOOP_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0DIFP_PRMDEVVG" , ""},
                { "V0DIFP_PRMDEVAP" , ""},
                { "V0DIFP_PRMPAGVG" , ""},
                { "V0DIFP_PRMPAGAP" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_50_LOOP_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1_Update1", q41);

            #endregion

            #region R1230_00_BAIXA_DO_MULTI_DB_UPDATE_2_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_QTDPARATZ" , ""},
                { "V0HCOB_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_BAIXA_DO_MULTI_DB_UPDATE_2_Update1", q42);

            #endregion

            #region VG0816B_CPLCOM

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODPDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VG0816B_CPLCOM", q43);

            #endregion

            #region R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_DTQITBCO" , ""},
                { "V0HCOB_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1", q44);

            #endregion

            #region R1230_00_BAIXA_DO_MULTI_DB_UPDATE_4_Update1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_BAIXA_DO_MULTI_DB_UPDATE_4_Update1", q45);

            #endregion

            #region R1280_00_PROC_COMPOSICAO_DB_UPDATE_1_Update1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0CMPT_NRPARCEL" , ""},
                { "V0CMPT_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1280_00_PROC_COMPOSICAO_DB_UPDATE_1_Update1", q46);

            #endregion

            #region R1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0CMPT_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1", q47);

            #endregion

            #region R1300_00_GERA_EVENTO_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0PDTV_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_GERA_EVENTO_DB_SELECT_1_Query1", q48);

            #endregion

            #region R1300_50_LOOP_DB_UPDATE_1_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V0PDTV_OCORHIST" , ""},
                { "V0PLCO_CODPDT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_50_LOOP_DB_UPDATE_1_Update1", q49);

            #endregion

            #region R1300_50_LOOP_DB_INSERT_1_Insert1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODPDT" , ""},
                { "V0PDTV_OCORHIST" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0CMPT_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "V0MOVC_DTQITBCO" , ""},
                { "V0CMPT_VLPRMDIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_50_LOOP_DB_INSERT_1_Insert1", q50);

            #endregion

            #region R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V0SEGU_NUM_ITEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1", q51);

            #endregion

            #region R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_DTQITBCO" , ""},
                { "V0HCOB_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1_Update1", q52);

            #endregion

            #region R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_DTQITBCO" , ""},
                { "V0SEGU_NUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1", q53);

            #endregion

            #region R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3_Update1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_DTQITBCO" , ""},
                { "V0SEGU_NUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3_Update1", q54);

            #endregion

            #region R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "V0MOVC_DTQITBCO" , ""},
                { "V0HCOB_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4_Update1", q55);

            #endregion

            #endregion
        }
        [Fact]
        public static void VG0816B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region PARAMETERS

                #region R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1");

                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "1"},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_CODOPER" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTVENCTO" , ""},
            });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "1"},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_CODOPER" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTVENCTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1");
                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "1"},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_CODOPER" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTVENCTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1
                
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1");
                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NUM_APOLICE" , "1"},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_SITUACAO" , "3"},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_OPCAO_COBER" , ""},
                { "V0PROP_DTQITBCO" , "2024-10-08"},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , ""},
                { "V0PROP_RISCO" , ""},
                { "V0PROP_ESTR_COBR" , "MULT"},
                { "V0PROP_ORIG_PRODU" , "1"},
                { "V0PROP_CUSTOCAP_TOTAL" , ""},
                { "V0PROP_RAMO" , ""},
            });
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NUM_APOLICE" , "1"},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_SITUACAO" , "3"},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_OPCAO_COBER" , ""},
                { "V0PROP_DTQITBCO" , "2024-10-08"},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , ""},
                { "V0PROP_RISCO" , ""},
                { "V0PROP_ESTR_COBR" , "MULT"},
                { "V0PROP_ORIG_PRODU" , "1"},
                { "V0PROP_CUSTOCAP_TOTAL" , ""},
                { "V0PROP_RAMO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1", q8);

                #endregion
                #endregion




                var program = new VG0816B();
                program.Execute();
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList1 = AppSettings.TestSet.DynamicData["R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_DB_UPDATE_1_Update1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_DB_UPDATE_2_Update1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_DB_UPDATE_4_Update1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);

                Assert.True(envList1[1].TryGetValue("V0HCTB_CODOPER", out var V0HCTB_CODOPER) && V0HCTB_CODOPER == "0201");
                Assert.True(envList2[1].TryGetValue("V0MOVC_SITUACAO", out var V0MOVC_SITUACAO) && V0MOVC_SITUACAO == "1");
                Assert.True(envList3[1].TryGetValue("V0HCOB_NRCERTIF", out var V0HCOB_NRCERTIF) && V0HCOB_NRCERTIF == "000000000000001");
                Assert.True(envList4[1].TryGetValue("V0HCOB_OCORHIST", out var V0HCOB_OCORHIST) && V0HCOB_OCORHIST == "0001");
                Assert.True(envList5[1].TryGetValue("V0MOVC_VALTIT", out var V0MOVC_VALTIT) && V0MOVC_VALTIT == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HCOB_NRCERTIF", out V0HCOB_NRCERTIF) && V0HCOB_NRCERTIF == "000000000000001");
            }
        }

        [Fact]
        public static void VG0816B_Tests_SemDados()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region PARAMETERS

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion

                var program = new VG0816B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}