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
using static Code.VG9020S;

namespace FileTests.Test
{
    [Collection("VG9020S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG9020S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PAR_RAMO_VG" , ""},
                { "V1PAR_RAMO_AP" , ""},
                { "V1PAR_RAMO_PST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EN_COD_MOEDA_IMP" , ""},
                { "DVLCRUZAD_IMP" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VG9020S_TMOVIMENTO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MDAC_CERTIFICADO" , ""},
                { "MTIPO_INCLUSAO" , ""},
                { "MCOD_CLIENTE" , ""},
                { "MCOD_AGENCIADOR" , ""},
                { "MCOD_CORRETOR" , ""},
                { "MCOD_PLANOVGAP" , ""},
                { "MCOD_PLANOAP" , ""},
                { "MFAIXA" , ""},
                { "MAUTOR_AUM_AUTOMAT" , ""},
                { "MTIPO_BENEFICIARIO" , ""},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MCOD_OCUPACAO" , ""},
                { "MESTADO_CIVIL" , ""},
                { "MIDE_SEXO" , ""},
                { "MCOD_PROFISSAO" , ""},
                { "MNATURALIDADE" , ""},
                { "MOCORR_ENDERECO" , ""},
                { "MOCORR_END_COBRAN" , ""},
                { "MBCO_COBRANCA" , ""},
                { "MAGE_COBRANCA" , ""},
                { "MDAC_COBRANCA" , ""},
                { "MNUM_MATRICULA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MVAL_SALARIO" , ""},
                { "MTIPO_SALARIO" , ""},
                { "MTIPO_PLANO" , ""},
                { "MPCT_CONJUGE_VG" , ""},
                { "MPCT_CONJUGE_AP" , ""},
                { "MQTD_SAL_MORNATU" , ""},
                { "MQTD_SAL_MORACID" , ""},
                { "MQTD_SAL_INVPERM" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "MTAXA_VG" , ""},
                { "MIMP_MORNATU_ANT" , ""},
                { "MIMP_MORNATU_ATU" , ""},
                { "MIMP_MORACID_ANT" , ""},
                { "MIMP_MORACID_ATU" , ""},
                { "MIMP_INVPERM_ANT" , ""},
                { "MIMP_INVPERM_ATU" , ""},
                { "MIMP_AMDS_ANT" , ""},
                { "MIMP_AMDS_ATU" , ""},
                { "MIMP_DH_ANT" , ""},
                { "MIMP_DH_ATU" , ""},
                { "MIMP_DIT_ANT" , ""},
                { "MIMP_DIT_ATU" , ""},
                { "MPRM_VG_ANT" , ""},
                { "MPRM_VG_ATU" , ""},
                { "MPRM_AP_ANT" , ""},
                { "MPRM_AP_ATU" , ""},
                { "MCOD_OPERACAO" , ""},
                { "MDATA_OPERACAO" , ""},
                { "COD_SUBGRUPO_TRANS" , ""},
                { "MSIT_REGISTRO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MDATA_AVERBACAO" , ""},
                { "MDATA_ADMISSAO" , ""},
                { "MDATA_INCLUSAO" , ""},
                { "MDATA_NASCIMENTO" , ""},
                { "MDATA_FATURA" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "SDATA_MOVIMENTO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "WS_DT_MAIS30D" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG9020S_TMOVIMENTO", q3);

            #endregion

            #region M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , ""},
                { "SNUM_ITEM" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "SPERI_PAGAMENTO" , ""},
                { "SDATA_TERVIGENCIA" , ""},
                { "SDATA_DTTERVIG" , ""},
                { "SDATA_NASC" , ""},
                { "SSIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOCORR_HISTORICO" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MCOD_AGENCIADOR" , ""},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "SDATA_DTTERVIG" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_VG" , ""},
                { "MFAIXA" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1", q6);

            #endregion

            #region M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SDATA_MOVIMENTO" , ""},
                { "SOCORR_HISTORICO" , ""},
                { "MNUM_APOLICE" , ""},
                { "SNUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1", q7);

            #endregion

            #region M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VGNUM_APOLICE" , ""},
                { "VGNRENDOS" , ""},
                { "VGNUM_ITEM" , ""},
                { "HOCORR_HISTORICO" , ""},
                { "VGRAMOFR" , ""},
                { "VGMODALIFR" , ""},
                { "VGCOD_COBERTURA" , ""},
                { "VGIMP_SEGURADA_IX" , ""},
                { "VGPRM_TARIFARIO_IX" , ""},
                { "VGIMP_SEGURADA_VAR" , ""},
                { "PRM_TARIFARIO_VAR" , ""},
                { "VGPCT_COBERTURA" , ""},
                { "VGFATOR_MULTIPLICA" , ""},
                { "VGDATA_INIVIGENCIA" , ""},
                { "VGDATA_TERVIGENCIA" , ""},
                { "MCOD_EMPRESA" , ""},
                { "VGCOD_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1", q8);

            #endregion

            #region M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HHOCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "SNUM_ITEM" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V1SISTEMA_DTMOVABE" , ""},
                { "HHORA_OPERACAO" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "HOCORR_HISTORICO" , ""},
                { "HCOD_SUBGRUP_TRANS" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MCOD_USUARIO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "V1EN_COD_MOEDA_IMP" , ""},
                { "V1EN_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1", q10);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MCOD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1", q11);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "MDATA_MOVIMENTO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1_Update1", q13);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_DTINIVIG" , ""},
                { "V0COBP_DTTERVIG" , ""},
                { "V0COBP_IMPSEGUR" , "3"},
                { "V0COBP_QUANT_VIDAS" , ""},
                { "V0COBP_IMPSEGIND" , ""},
                { "V0COBP_CODOPER" , ""},
                { "V0COBP_OPCAO_COBER" , ""},
                { "V0COBP_IMPMORNATU" , ""},
                { "V0COBP_IMPMORACID" , ""},
                { "V0COBP_IMPINVPERM" , ""},
                { "V0COBP_IMPAMDS" , ""},
                { "V0COBP_IMPDH" , ""},
                { "V0COBP_IMPDIT" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_VLTITCAP" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_IMPSEGCDC" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_PRMDIT" , ""},
                { "V0COBP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1", q14);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "V0COBP_IMPSEGUR" , ""},
                { "V0COBP_QUANT_VIDAS" , ""},
                { "V0COBP_IMPSEGIND" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0COBP_OPCAO_COBER" , ""},
                { "V0COBP_IMPMORNATU" , ""},
                { "V0COBP_IMPMORACID" , ""},
                { "V0COBP_IMPINVPERM" , ""},
                { "V0COBP_IMPAMDS" , ""},
                { "V0COBP_IMPDH" , ""},
                { "V0COBP_IMPDIT" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_VLTITCAP" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_IMPSEGCDC" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "MCOD_USUARIO" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_PRMDIT" , ""},
                { "V0COBP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1", q15);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2_Update1", q16);

            #endregion

            #region M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_OCORHIST" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "MCOD_OPERACAO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MNUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1", q18);

            #endregion

            #region M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0MLD_IDADE" , ""},
                { "V0MLD_CAP_MN_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1", q19);

            #endregion

            #region M_410_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1", q20);

            #endregion

            #region M_410_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0MLD_IDADE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "V0CAR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_410_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1", q21);

            #endregion

            #region M_410_000_GERA_CARENCIAS_DB_SELECT_3_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_000_GERA_CARENCIAS_DB_SELECT_3_Query1", q22);

            #endregion

            #region M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0CAR_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1", q23);

            #endregion

            #region M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0MLD_IDADE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "V0CAR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1", q25);

            #endregion

            #region M_420_000_GERA_CARENCIAS_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_000_GERA_CARENCIAS_DB_SELECT_1_Query1", q26);

            #endregion

            #region M_420_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1", q27);

            #endregion

            #region M_420_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0MLD_IDADE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "V0CAR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_420_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1", q28);

            #endregion

            #region M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "CLIE_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1", q29);

            #endregion

            #region M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0CAR_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1", q30);

            #endregion

            #region M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1", q31);

            #endregion

            #region M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0MLD_IDADE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "V0CAR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1", q32);

            #endregion

            #region M_420_000_GERA_CARENCIAS_DB_SELECT_3_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_000_GERA_CARENCIAS_DB_SELECT_3_Query1", q33);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData(1, 2, 3, "MENSAGEM.txt", "SQLERRMC.txt", "SQLSTATE.txt")]
        public static void VG9020S_Tests_Theory(int CSP_NRCERTIF_P, int H_OUT_COD_RETORNO_P, int H_OUT_COD_RETORNO_SQL_P, string H_OUT_MENSAGEM_P, string H_OUT_SQLERRMC_P, string H_OUT_SQLSTATE_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            H_OUT_MENSAGEM_P = $"{H_OUT_MENSAGEM_P}_{timestamp}.txt";
            H_OUT_SQLERRMC_P = $"{H_OUT_SQLERRMC_P}_{timestamp}.txt";
            H_OUT_SQLSTATE_P = $"{H_OUT_SQLSTATE_P}_{timestamp}.txt";
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
                var program = new VG9020S();

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1");
                q5.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q5);


                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG9020S_TMOVIMENTO");
                q3.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , "97010000889"},
                { "MCOD_SUBGRUPO" , "1"},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MDAC_CERTIFICADO" , ""},
                { "MTIPO_INCLUSAO" , ""},
                { "MCOD_CLIENTE" , ""},
                { "MCOD_AGENCIADOR" , ""},
                { "MCOD_CORRETOR" , ""},
                { "MCOD_PLANOVGAP" , ""},
                { "MCOD_PLANOAP" , ""},
                { "MFAIXA" , ""},
                { "MAUTOR_AUM_AUTOMAT" , ""},
                { "MTIPO_BENEFICIARIO" , ""},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MCOD_OCUPACAO" , ""},
                { "MESTADO_CIVIL" , ""},
                { "MIDE_SEXO" , ""},
                { "MCOD_PROFISSAO" , ""},
                { "MNATURALIDADE" , ""},
                { "MOCORR_ENDERECO" , ""},
                { "MOCORR_END_COBRAN" , ""},
                { "MBCO_COBRANCA" , ""},
                { "MAGE_COBRANCA" , ""},
                { "MDAC_COBRANCA" , ""},
                { "MNUM_MATRICULA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MVAL_SALARIO" , ""},
                { "MTIPO_SALARIO" , ""},
                { "MTIPO_PLANO" , ""},
                { "MPCT_CONJUGE_VG" , ""},
                { "MPCT_CONJUGE_AP" , ""},
                { "MQTD_SAL_MORNATU" , ""},
                { "MQTD_SAL_MORACID" , ""},
                { "MQTD_SAL_INVPERM" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "MTAXA_VG" , ""},
                { "MIMP_MORNATU_ANT" , ""},
                { "MIMP_MORNATU_ATU" , "1"},
                { "MIMP_MORACID_ANT" , ""},
                { "MIMP_MORACID_ATU" , "1"},
                { "MIMP_INVPERM_ANT" , ""},
                { "MIMP_INVPERM_ATU" , ""},
                { "MIMP_AMDS_ANT" , ""},
                { "MIMP_AMDS_ATU" , ""},
                { "MIMP_DH_ANT" , ""},
                { "MIMP_DH_ATU" , ""},
                { "MIMP_DIT_ANT" , ""},
                { "MIMP_DIT_ATU" , ""},
                { "MPRM_VG_ANT" , ""},
                { "MPRM_VG_ATU" , "1"},
                { "MPRM_AP_ANT" , ""},
                { "MPRM_AP_ATU" , "1"},
                { "MCOD_OPERACAO" , ""},
                { "MDATA_OPERACAO" , ""},
                { "COD_SUBGRUPO_TRANS" , ""},
                { "MSIT_REGISTRO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MDATA_AVERBACAO" , ""},
                { "MDATA_ADMISSAO" , ""},
                { "MDATA_INCLUSAO" , ""},
                { "MDATA_NASCIMENTO" , ""},
                { "MDATA_FATURA" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MDATA_MOVIMENTO" , "10-10-2000"},
                { "SDATA_MOVIMENTO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "WS_DT_MAIS30D" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VG9020S_TMOVIMENTO", q3);

                program.Execute(new IntBasis(null, CSP_NRCERTIF_P), new IntBasis(null, H_OUT_COD_RETORNO_P), new IntBasis(null, H_OUT_COD_RETORNO_SQL_P), new StringBasis(null, H_OUT_MENSAGEM_P), new StringBasis(null, H_OUT_SQLERRMC_P), new StringBasis(null, H_OUT_SQLSTATE_P));

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);
                Assert.True(true);


                //Assert.True(File.Exists(program.SIAVISAD.FilePath));
                //Assert.True(new FileInfo(program.SIAVISAD.FilePath)?.Length > 0);
                var envList = AppSettings.TestSet.DynamicData["M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("HOCORR_HISTORICO", out var valor) && valor == "0002");

                var envList1 = AppSettings.TestSet.DynamicData["M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("SOCORR_HISTORICO", out valor) && valor == "0001");

                var envList2 = AppSettings.TestSet.DynamicData["M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("VGNUM_APOLICE", out valor) && valor == "0097010000889");

                var envList3 = AppSettings.TestSet.DynamicData["M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("MNUM_APOLICE", out valor) && valor == "0097010000889");

                var envList4 = AppSettings.TestSet.DynamicData["M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("MPERI_RENOVACAO", out valor) && valor == "-002");

                var envList5 = AppSettings.TestSet.DynamicData["M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5.Count > 1);
                Assert.True(envList5[1].TryGetValue("MDATA_MOVIMENTO", out valor) && valor == "10-10-2000");

                var envList6 = AppSettings.TestSet.DynamicData["M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList6.Count > 1);
                Assert.True(envList6[1].TryGetValue("MNUM_CERTIFICADO", out valor) && valor == "000000000000000");

                var envList7 = AppSettings.TestSet.DynamicData["M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7.Count > 1);
                Assert.True(envList7[1].TryGetValue("V0PROP_OCORHIST", out valor) && valor == "0001");

                var envList8 = AppSettings.TestSet.DynamicData["M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1"].DynamicList;
                Assert.True(envList8.Count > 1);
                Assert.True(envList8[1].TryGetValue("MCOD_OPERACAO", out valor) && valor == "0000");

                //Verifica se bateu no Update, Sem parametro
                // var envList = AppSettings.TestSet.DynamicData["M_000_700_UPDATE_V1RELATORIOS_Update1"].DynamicList;
                // Assert.True(envList[1].TryGetValue("UpdateCheck", out var valOr) && valOr == "UpdateCheck");


            }
        }
        [Theory]
        [InlineData(1, 2, 3, "MENSAGEM.txt", "SQLERRMC.txt", "SQLSTATE.txt")]
        public static void VG9020S_Tests_SemDados(int CSP_NRCERTIF_P, int H_OUT_COD_RETORNO_P, int H_OUT_COD_RETORNO_SQL_P, string H_OUT_MENSAGEM_P, string H_OUT_SQLERRMC_P, string H_OUT_SQLSTATE_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            H_OUT_MENSAGEM_P = $"{H_OUT_MENSAGEM_P}_{timestamp}.txt";
            H_OUT_SQLERRMC_P = $"{H_OUT_SQLERRMC_P}_{timestamp}.txt";
            H_OUT_SQLSTATE_P = $"{H_OUT_SQLSTATE_P}_{timestamp}.txt";
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
                var program = new VG9020S();
                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG9020S_TMOVIMENTO");
                q3.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , "97010000889"},
                { "MCOD_SUBGRUPO" , "1"},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MDAC_CERTIFICADO" , ""},
                { "MTIPO_INCLUSAO" , ""},
                { "MCOD_CLIENTE" , ""},
                { "MCOD_AGENCIADOR" , ""},
                { "MCOD_CORRETOR" , ""},
                { "MCOD_PLANOVGAP" , ""},
                { "MCOD_PLANOAP" , ""},
                { "MFAIXA" , ""},
                { "MAUTOR_AUM_AUTOMAT" , ""},
                { "MTIPO_BENEFICIARIO" , ""},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MCOD_OCUPACAO" , ""},
                { "MESTADO_CIVIL" , ""},
                { "MIDE_SEXO" , ""},
                { "MCOD_PROFISSAO" , ""},
                { "MNATURALIDADE" , ""},
                { "MOCORR_ENDERECO" , ""},
                { "MOCORR_END_COBRAN" , ""},
                { "MBCO_COBRANCA" , ""},
                { "MAGE_COBRANCA" , ""},
                { "MDAC_COBRANCA" , ""},
                { "MNUM_MATRICULA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MVAL_SALARIO" , ""},
                { "MTIPO_SALARIO" , ""},
                { "MTIPO_PLANO" , ""},
                { "MPCT_CONJUGE_VG" , ""},
                { "MPCT_CONJUGE_AP" , ""},
                { "MQTD_SAL_MORNATU" , ""},
                { "MQTD_SAL_MORACID" , ""},
                { "MQTD_SAL_INVPERM" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "MTAXA_VG" , ""},
                { "MIMP_MORNATU_ANT" , ""},
                { "MIMP_MORNATU_ATU" , "1"},
                { "MIMP_MORACID_ANT" , ""},
                { "MIMP_MORACID_ATU" , "1"},
                { "MIMP_INVPERM_ANT" , ""},
                { "MIMP_INVPERM_ATU" , ""},
                { "MIMP_AMDS_ANT" , ""},
                { "MIMP_AMDS_ATU" , ""},
                { "MIMP_DH_ANT" , ""},
                { "MIMP_DH_ATU" , ""},
                { "MIMP_DIT_ANT" , ""},
                { "MIMP_DIT_ATU" , ""},
                { "MPRM_VG_ANT" , ""},
                { "MPRM_VG_ATU" , "1"},
                { "MPRM_AP_ANT" , ""},
                { "MPRM_AP_ATU" , "1"},
                { "MCOD_OPERACAO" , ""},
                { "MDATA_OPERACAO" , ""},
                { "COD_SUBGRUPO_TRANS" , ""},
                { "MSIT_REGISTRO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MDATA_AVERBACAO" , ""},
                { "MDATA_ADMISSAO" , ""},
                { "MDATA_INCLUSAO" , ""},
                { "MDATA_NASCIMENTO" , ""},
                { "MDATA_FATURA" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MDATA_MOVIMENTO" , "10-10-2000"},
                { "SDATA_MOVIMENTO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "WS_DT_MAIS30D" , ""},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Add("VG9020S_TMOVIMENTO", q3);

                program.Execute(new IntBasis(null, CSP_NRCERTIF_P), new IntBasis(null, H_OUT_COD_RETORNO_P), new IntBasis(null, H_OUT_COD_RETORNO_SQL_P), new StringBasis(null, H_OUT_MENSAGEM_P), new StringBasis(null, H_OUT_SQLERRMC_P), new StringBasis(null, H_OUT_SQLSTATE_P));
                Assert.True(program.H_OUT_COD_RETORNO == 1);

            }
        }
    }
}