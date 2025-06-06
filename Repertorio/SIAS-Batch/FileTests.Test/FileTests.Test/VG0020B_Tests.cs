using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0020B;
using Sias.VidaEmGrupo.DB2.VG0020B;

namespace FileTests.Test
{
    [Collection("VG0020B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0020B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , "2024-08-21"}
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PAR_RAMO_VG" , "93"},
                { "V1PAR_RAMO_AP" , "82"},
                { "V1PAR_RAMO_PST" , "77"},
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EN_COD_MOEDA_IMP" , "1"},
                { "DVLCRUZAD_IMP" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VG0020B_TMOVIMENTO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                {"MNUM_APOLICE" , "109300000559"},
                {"MCOD_SUBGRUPO" , "1"},
                {"MCOD_FONTE" , "10"},
                {"MNUM_PROPOSTA" , "500017874"},
                {"MTIPO_SEGURADO" , "1"},
                {"MNUM_CERTIFICADO" , "10001787406"},
                {"MDAC_CERTIFICADO" , " "},
                {"MTIPO_INCLUSAO" , "1"},
                {"MCOD_CLIENTE" , "160451"},
                {"MCOD_AGENCIADOR" , "471208"},
                {"MCOD_CORRETOR" , "0"},
                {"MCOD_PLANOVGAP" , "0"},
                {"MCOD_PLANOAP" , "0"},
                {"MFAIXA" , "8"},
                {"MAUTOR_AUM_AUTOMAT" , "S"},
                {"MTIPO_BENEFICIARIO" , "N"},
                {"MPERI_PAGAMENTO" , "1"},
                {"MPERI_RENOVACAO" , "12"},
                {"MCOD_OCUPACAO" , "    "},
                {"MESTADO_CIVIL" , "C"},
                {"MIDE_SEXO" , "M"},
                {"MCOD_PROFISSAO" , "0"},
                {"MNATURALIDADE" , "                              "},
                {"MOCORR_ENDERECO" , "2"},
                {"MOCORR_END_COBRAN" , "1"},
                {"MBCO_COBRANCA" , "104"},
                {"MAGE_COBRANCA" , "45"},
                {"MDAC_COBRANCA" , " "},
                {"MNUM_MATRICULA" , "8339703"},
                {"MNUM_CTA_CORRENTE" , "1000000701054"},
                {"MDAC_CTA_CORRENTE" , "4"},
                {"MVAL_SALARIO" , "0.00"},
                {"MTIPO_SALARIO" , " "},
                {"MTIPO_PLANO" , "1"},
                {"MPCT_CONJUGE_VG" , "0.00"},
                {"MPCT_CONJUGE_AP" , "0.00"},
                {"MQTD_SAL_MORNATU" , "0"},
                {"MQTD_SAL_MORACID" , "0"},
                {"MQTD_SAL_INVPERM" , "0"},
                {"MTAXA_AP_MORACID" , "0.0000"},
                {"MTAXA_AP_INVPERM" , "0.0000"},
                {"MTAXA_AP_AMDS" , "0.0000"},
                {"MTAXA_AP_DH" , "0.0000"},
                {"MTAXA_AP_DIT" , "0.0000"},
                {"MTAXA_VG" , "4.4232"},
                {"MIMP_MORNATU_ANT" , "122705.98"},
                {"MIMP_MORNATU_ATU" , "50000.00"},
                {"MIMP_MORACID_ANT" , "0.00"},
                {"MIMP_MORACID_ATU" , "0.00"},
                {"MIMP_INVPERM_ANT" , "0.00"},
                {"MIMP_INVPERM_ATU" , "0.00"},
                {"MIMP_AMDS_ANT" , "0.00"},
                {"MIMP_AMDS_ATU" , "0.00"},
                {"MIMP_DH_ANT" , "0.00"},
                {"MIMP_DH_ATU" , "0.00"},
                {"MIMP_DIT_ANT" , "0.00"},
                {"MIMP_DIT_ATU" , "0.00"},
                {"MPRM_VG_ANT" , "445.11"},
                {"MPRM_VG_ATU" , "171.99"},
                {"MPRM_AP_ANT" , "0.00"},
                {"MPRM_AP_ATU" , "0.00"},
                {"MCOD_OPERACAO" , "701"},
                {"MDATA_OPERACAO" , "2018-02-23"},
                {"COD_SUBGRUPO_TRANS" , "0"},
                {"MSIT_REGISTRO" , "1"},
                {"MCOD_USUARIO" , "TER42247"},
                {"MDATA_AVERBACAO" , "2018-02-23"},
                {"MDATA_ADMISSAO" , "2003-02-19"},
                {"MDATA_INCLUSAO" , "null"},
                {"MDATA_NASCIMENTO" , "1950-05-10"},
                {"MDATA_FATURA" , "null"},
                {"MDATA_REFERENCIA" , "2018-02-01"},
                {"MDATA_MOVIMENTO" , "2018-02-23"},
                {"SDATA_MOVIMENTO" , "2018-02-22"},
                {"MCOD_EMPRESA" , "null"},
                {"V0APOL_RAMO" , "93"},
                {"V0APOL_MODALIDA" , "0"},
                {"WS_DT_MAIS30D" , "2018-03-25"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                {"MNUM_APOLICE" , "109300000559"},
                {"MCOD_SUBGRUPO" , "1"},
                {"MCOD_FONTE" , "10"},
                {"MNUM_PROPOSTA" , "500077874"},
                {"MTIPO_SEGURADO" , "1"},
                {"MNUM_CERTIFICADO" , "10701787406"},
                {"MDAC_CERTIFICADO" , " "},
                {"MTIPO_INCLUSAO" , "1"},
                {"MCOD_CLIENTE" , "160851"},
                {"MCOD_AGENCIADOR" , "471808"},
                {"MCOD_CORRETOR" , "0"},
                {"MCOD_PLANOVGAP" , "0"},
                {"MCOD_PLANOAP" , "0"},
                {"MFAIXA" , "8"},
                {"MAUTOR_AUM_AUTOMAT" , "S"},
                {"MTIPO_BENEFICIARIO" , "N"},
                {"MPERI_PAGAMENTO" , "1"},
                {"MPERI_RENOVACAO" , "12"},
                {"MCOD_OCUPACAO" , "    "},
                {"MESTADO_CIVIL" , "C"},
                {"MIDE_SEXO" , "M"},
                {"MCOD_PROFISSAO" , "0"},
                {"MNATURALIDADE" , "                              "},
                {"MOCORR_ENDERECO" , "2"},
                {"MOCORR_END_COBRAN" , "1"},
                {"MBCO_COBRANCA" , "104"},
                {"MAGE_COBRANCA" , "45"},
                {"MDAC_COBRANCA" , " "},
                {"MNUM_MATRICULA" , "8339707"},
                {"MNUM_CTA_CORRENTE" , "1000000701454"},
                {"MDAC_CTA_CORRENTE" , "4"},
                {"MVAL_SALARIO" , "0.00"},
                {"MTIPO_SALARIO" , " "},
                {"MTIPO_PLANO" , "1"},
                {"MPCT_CONJUGE_VG" , "0.00"},
                {"MPCT_CONJUGE_AP" , "0.00"},
                {"MQTD_SAL_MORNATU" , "0"},
                {"MQTD_SAL_MORACID" , "0"},
                {"MQTD_SAL_INVPERM" , "0"},
                {"MTAXA_AP_MORACID" , "0.0000"},
                {"MTAXA_AP_INVPERM" , "0.0000"},
                {"MTAXA_AP_AMDS" , "0.0000"},
                {"MTAXA_AP_DH" , "0.0000"},
                {"MTAXA_AP_DIT" , "0.0000"},
                {"MTAXA_VG" , "4.4232"},
                {"MIMP_MORNATU_ANT" , "122705.98"},
                {"MIMP_MORNATU_ATU" , "50000.00"},
                {"MIMP_MORACID_ANT" , "0.00"},
                {"MIMP_MORACID_ATU" , "0.00"},
                {"MIMP_INVPERM_ANT" , "0.00"},
                {"MIMP_INVPERM_ATU" , "0.00"},
                {"MIMP_AMDS_ANT" , "0.00"},
                {"MIMP_AMDS_ATU" , "0.00"},
                {"MIMP_DH_ANT" , "0.00"},
                {"MIMP_DH_ATU" , "0.00"},
                {"MIMP_DIT_ANT" , "0.00"},
                {"MIMP_DIT_ATU" , "0.00"},
                {"MPRM_VG_ANT" , "445.11"},
                {"MPRM_VG_ATU" , "171.99"},
                {"MPRM_AP_ANT" , "0.00"},
                {"MPRM_AP_ATU" , "0.00"},
                {"MCOD_OPERACAO" , "701"},
                {"MDATA_OPERACAO" , "2018-02-23"},
                {"COD_SUBGRUPO_TRANS" , "0"},
                {"MSIT_REGISTRO" , "1"},
                {"MCOD_USUARIO" , "TER42247"},
                {"MDATA_AVERBACAO" , "2018-02-23"},
                {"MDATA_ADMISSAO" , "2003-02-19"},
                {"MDATA_INCLUSAO" , "null"},
                {"MDATA_NASCIMENTO" , "1950-05-10"},
                {"MDATA_FATURA" , "null"},
                {"MDATA_REFERENCIA" , "2018-02-01"},
                {"MDATA_MOVIMENTO" , "2018-02-23"},
                {"SDATA_MOVIMENTO" , "2018-02-22"},
                {"MCOD_EMPRESA" , "null"},
                {"V0APOL_RAMO" , "93"},
                {"V0APOL_MODALIDA" , "0"},
                {"WS_DT_MAIS30D" , "2018-03-25"},
            });
            AppSettings.TestSet.DynamicData.Add("VG0020B_TMOVIMENTO", q3);

            #endregion

            #region M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , ""},
                { "SNUM_ITEM" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "SPERI_PAGAMENTO" , ""},
                { "SDATA_TERVIGENCIA" , ""},
                { "WDATA_TERVIGENCIA" , ""},
                { "SDATA_DTTERVIG" , ""},
                { "WDATA_DTTERVIG" , ""},
                { "SDATA_NASC" , ""},
                { "WDATA_NASC" , ""},
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
                { "MCOD_AGENCIADOR" , ""},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MFAIXA" , ""},
                { "MTAXA_VG" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "SDATA_DTTERVIG" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1", q6);

            #endregion

            #region M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SDATA_MOVIMENTO" , ""},
                { "MNUM_APOLICE" , ""},
                { "SNUM_ITEM" , ""},
                { "SOCORR_HISTORICO" , ""},
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
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
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

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_DTINIVIG" , ""},
                { "V0COBP_DTTERVIG" , ""},
                { "V0COBP_IMPSEGUR" , ""},
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
                { "V0COBP_IMPSEGAUXF_I" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_VLCUSTAUXF_I" , ""},
                { "V0COBP_PRMDIT" , ""},
                { "V0COBP_PRMDIT_I" , ""},
                { "V0COBP_QTDIT" , ""},
                { "V0COBP_QTDIT_I" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1", q13);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "MDATA_MOVIMENTO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1", q14);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_4_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_4_Update1", q15);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVADB_INSERT_5_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVADB_INSERT_5_Insert1", q16);

            #endregion

            #region M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_6_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MNUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_6_Update1", q17);

            #endregion

            #region M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0MLD_IDADE" , ""},
                { "V0MLD_CAP_MN_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1", q19);

            #endregion

            #region M_410_000_GERA_CARENCIAS_DB_SELECT_3_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_000_GERA_CARENCIAS_DB_SELECT_3_Query1", q20);

            #endregion

            #region M_410_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1", q21);

            #endregion

            #region M_410_010_INCLUI_CARENCIAS_DB_INSERT_2_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0MLD_IDADE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "V0CAR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_410_010_INCLUI_CARENCIAS_DB_INSERT_2_Insert1", q22);

            #endregion

            #region M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0CAR_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1", q23);

            #endregion

            #region M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_2_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_2_Query1", q24);

            #endregion

            #region M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_3_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0MLD_IDADE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "V0CAR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_3_Insert1", q25);

            #endregion

            #region M_420_000_GERA_CARENCIAS_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_000_GERA_CARENCIAS_DB_SELECT_1_Query1", q26);

            #endregion

            #region M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "CLIE_DTNASC" , ""},
                { "WDATA_NASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1", q27);

            #endregion

            #region M_420_000_GERA_CARENCIAS_DB_SELECT_3_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_000_GERA_CARENCIAS_DB_SELECT_3_Query1", q28);

            #endregion

            #region M_420_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1", q29);

            #endregion

            #region M_420_010_INCLUI_CARENCIAS_DB_INSERT_2_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0MLD_IDADE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "V0CAR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_420_010_INCLUI_CARENCIAS_DB_INSERT_2_Insert1", q30);

            #endregion

            #region M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0CAR_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1", q31);

            #endregion

            #region M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_2_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0CAR_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_2_Query1", q32);

            #endregion

            #region M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_3_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V0MLD_IDADE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "V0CAR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_3_Insert1", q33);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0020B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE



                #region M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "23"},
                { "SNUM_ITEM" , "18478"},
                { "MPERI_RENOVACAO" , "12"},
                { "SPERI_PAGAMENTO" , "1"},
                { "SDATA_TERVIGENCIA" , "2003-02-19"},
                { "SDATA_DTTERVIG" , "1950-05-10"},
                { "SDATA_NASC" , "1950-05-10"},
                { "SSIT_REGISTRO" , "2"}
            });
                q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "24"},
                { "SNUM_ITEM" , "18474"},
                { "MPERI_RENOVACAO" , "12"},
                { "SPERI_PAGAMENTO" , "1"},
                { "SDATA_TERVIGENCIA" , "2003-02-19"},
                { "SDATA_DTTERVIG" , "1950-05-10"},
                { "SDATA_NASC" , "1950-05-10"},
                { "SSIT_REGISTRO" , "2"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q4);



                #endregion

                #endregion
                var program = new VG0020B();
                program.Execute();

                Assert.True(program.MDATA_OPERACAO == "2018-02-23");
            }

        }

        [Fact]
        public static void VG0020B_Tests_Fact1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE



                #region M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "23"},
                { "SNUM_ITEM" , "18478"},
                { "MPERI_RENOVACAO" , "12"},
                { "SPERI_PAGAMENTO" , "1"},
                { "SDATA_TERVIGENCIA" , "2003-02-19"},
                { "SDATA_DTTERVIG" , "1950-05-10"},
                { "SDATA_NASC" , "1950-05-10"},
                { "SSIT_REGISTRO" , "1"}
            });                
                q4.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "23"},
                { "SNUM_ITEM" , "18478"},
                { "MPERI_RENOVACAO" , "12"},
                { "SPERI_PAGAMENTO" , "1"},
                { "SDATA_TERVIGENCIA" , "2003-02-19"},
                { "SDATA_DTTERVIG" , "1950-05-10"},
                { "SDATA_NASC" , "1950-05-10"},
                { "SSIT_REGISTRO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q4);

                #region M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "23"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q5);

                #endregion



                #endregion

                #endregion
                var program = new VG0020B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("HOCORR_HISTORICO", out var val5r) && val5r.Contains("0024"));
                Assert.True(envList[1].TryGetValue("MPERI_PAGAMENTO", out var val6r) && val6r.Contains("0001"));
                Assert.True(envList[1].TryGetValue("MNUM_CERTIFICADO", out var val7r) && val7r.Contains("10001787406"));
                
                var envList1 = AppSettings.TestSet.DynamicData["M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("SDATA_MOVIMENTO", out var val8r) && val8r.Contains("2018-02-22"));
                           
                var envList2 = AppSettings.TestSet.DynamicData["M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].Count > 1);
                Assert.True(envList2[1].TryGetValue("MNUM_APOLICE", out var val9r) && val9r.Contains("0109300000559"));


                Assert.True(program.RETURN_CODE == 0);
            }

        }
    }
}