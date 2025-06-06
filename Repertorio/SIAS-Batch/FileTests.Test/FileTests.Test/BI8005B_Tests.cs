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
using static Code.BI8005B;

namespace FileTests.Test
{


    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("BI8005B_Tests")]
    public class BI8005B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , ""},
                { "V1SIST_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region BI8005B_CCBO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI8005B_CCBO", q2);

            #endregion

            #region BI8005B_V0BILHETE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V0BILH_NUMAPOL" , ""},
                { "V0BILH_FONTE" , ""},
                { "V0BILH_AGECOBR" , ""},
                { "V0BILH_NUM_MATR" , ""},
                { "V0BILH_AGENCIA" , ""},
                { "V0BILH_CODCLIEN" , ""},
                { "V0BILH_PROFISSAO" , ""},
                { "V0BILH_AGENCIA_DEB" , ""},
                { "V0BILH_OPERACAO_DEB" , ""},
                { "V0BILH_NUMCTA_DEB" , ""},
                { "V0BILH_DIGCTA_DEB" , ""},
                { "V0BILH_OPCAO_COBER" , ""},
                { "V0BILH_DTQITBCO" , ""},
                { "V0BILH_DTVENCTO" , ""},
                { "V0BILH_VLRCAP" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0BILH_CODUSU" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUM_APO_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI8005B_V0BILHETE", q3);

            #endregion

            #region BI8005B_V1COSSEGPROD

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CODPRODU" , ""},
                { "V1COSP_RAMO" , ""},
                { "V1COSP_CONGENER" , ""},
                { "V1COSP_PCPARTIC" , ""},
                { "V1COSP_PCCOMCOS" , ""},
                { "V1COSP_PCADMCOS" , ""},
                { "V1COSP_DTINIVIG" , ""},
                { "V1COSP_DTTERVIG" , ""},
                { "V1COSP_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI8005B_V1COSSEGPROD", q4);

            #endregion

            #region R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_COD_EMPRESA_CAP" , ""},
                { "PRODUTO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0250_00_LEITURA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_SIVPF" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_LEITURA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_SICOB" , ""},
                { "V0SIVPF_SIT_PROPOSTA" , ""},
                { "V0CONV_NUM_PROPOSTA_SIVPF" , ""},
                { "PRPFIDEL_COD_PROD_SIVPF" , ""},
                { "PRPFIDEL_ORIG_PROPOSTA" , ""},
                { "PRPFIDEL_QTD_MESES" , ""},
                { "PRPFIDEL_PERIPGTO" , ""},
                { "PRPFIDEL_OPCAO_COBER" , ""},
                { "PRPFIDEL_DIA_DEBITO" , ""},
                { "PRPFIDEL_NUM_IDENTIFICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PRPFIDCO_INFORM_COMPLEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_CGCCPF" , ""},
                { "V0CLIE_DTNASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "GELMR_QTD_SEGUROS" , ""},
                { "GELMR_VLR_SOMA_IS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1", q15);

            #endregion

            #region R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , ""},
                { "V1BILC_PRMTAR_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V2RCAP_VLRCAP" , ""},
                { "V0RCAP_SITUACAO" , ""},
                { "V0RCAP_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , ""},
                { "V0BILFX_VALADT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1", q20);

            #endregion

            #region R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1", q21);

            #endregion

            #region R0500_00_TRATA_APOLICE_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_SEQ_APOL" , ""},
                { "WWORK_RAMO_ANT" , ""},
                { "V0APOL_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_CODUNIMO" , ""},
                { "V1BILC_PCCOMCOR" , ""},
                { "V1BILC_PCIOCC" , ""},
                { "V1BILC_VALMAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1", q23);

            #endregion

            #region R0500_00_TRATA_APOLICE_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_CODCLIEN" , ""},
                { "V0APOL_NUM_APOL" , ""},
                { "V0APOL_NUM_ITEM" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_NUM_APO_ANT" , ""},
                { "V0APOL_NUMBIL" , ""},
                { "V0APOL_TIPSGU" , ""},
                { "V0APOL_TIPAPO" , ""},
                { "V0APOL_TIPCALC" , ""},
                { "V0APOL_PODPUBL" , ""},
                { "V0APOL_NUM_ATA" , ""},
                { "V0APOL_ANO_ATA" , ""},
                { "V0APOL_IDEMAN" , ""},
                { "V0APOL_PCDESCON" , ""},
                { "V0APOL_PCIOCC" , ""},
                { "V0APOL_TPCOSCED" , ""},
                { "V0APOL_QTCOSSEG" , ""},
                { "V0APOL_PCTCED" , ""},
                { "V0APOL_COD_EMPRESA" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_TPCORRET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_INSERT_1_Insert1", q24);

            #endregion

            #region R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1", q25);

            #endregion

            #region R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1", q26);

            #endregion

            #region R0530_00_INCLUI_ENDOSSO_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_CODSUBES" , ""},
                { "V0ENDO_FONTE" , ""},
                { "V0ENDO_NRPROPOS" , ""},
                { "V0ENDO_DATPRO" , ""},
                { "V0ENDO_DT_LIBER" , ""},
                { "V0ENDO_DTEMIS" , ""},
                { "V0ENDO_NRRCAP" , ""},
                { "V0ENDO_VLRCAP" , ""},
                { "V0ENDO_BCORCAP" , ""},
                { "V0ENDO_AGERCAP" , ""},
                { "V0ENDO_DACRCAP" , ""},
                { "V0ENDO_IDRCAP" , ""},
                { "V0ENDO_BCOCOBR" , ""},
                { "V0ENDO_AGECOBR" , ""},
                { "V0ENDO_DACCOBR" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
                { "V0ENDO_CDFRACIO" , ""},
                { "V0ENDO_PCENTRAD" , ""},
                { "V0ENDO_PCADICIO" , ""},
                { "V0ENDO_PRESTA1" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_QTPRESTA" , ""},
                { "V0ENDO_QTITENS" , ""},
                { "V0ENDO_CODTXT" , ""},
                { "V0ENDO_CDACEITA" , ""},
                { "V0ENDO_MOEDA_IMP" , ""},
                { "V0ENDO_MOEDA_PRM" , ""},
                { "V0ENDO_TIPO_ENDO" , ""},
                { "V0ENDO_COD_USUAR" , ""},
                { "V0ENDO_OCORR_END" , ""},
                { "V0ENDO_SITUACAO" , ""},
                { "V0ENDO_DATARCAP" , ""},
                { "V0ENDO_COD_EMPRESA" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_ISENTA_CST" , ""},
                { "V0ENDO_DTVENCTO" , ""},
                { "V0ENDO_CFPREFIX" , ""},
                { "V0ENDO_VLCUSEMI" , ""},
                { "V0ENDO_RAMO" , ""},
                { "V0ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_ENDOSSO_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R0540_00_INCLUI_PARCELAS_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , ""},
                { "V0PARC_NRENDOS" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_DACPARC" , ""},
                { "V0PARC_FONTE" , ""},
                { "V0PARC_NRTIT" , ""},
                { "V0PARC_PRM_TAR_IX" , ""},
                { "V0PARC_VAL_DES_IX" , ""},
                { "V0PARC_OTNPRLIQ" , ""},
                { "V0PARC_OTNADFRA" , ""},
                { "V0PARC_OTNCUSTO" , ""},
                { "V0PARC_OTNIOF" , ""},
                { "V0PARC_OTNTOTAL" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0PARC_QTDDOC" , ""},
                { "V0PARC_SITUACAO" , ""},
                { "V0PARC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0540_00_INCLUI_PARCELAS_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_DACPARC" , ""},
                { "V0HISP_DTMOVTO" , ""},
                { "V0HISP_OPERACAO" , ""},
                { "V0HISP_HORAOPER" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TARIFA" , ""},
                { "V0HISP_VAL_DESCON" , ""},
                { "V0HISP_VLPRMLIQ" , ""},
                { "V0HISP_VLADIFRA" , ""},
                { "V0HISP_VLCUSEMI" , ""},
                { "V0HISP_VLIOCC" , ""},
                { "V0HISP_VLPRMTOT" , ""},
                { "V0HISP_VLPREMIO" , ""},
                { "V0HISP_DTVENCTO" , ""},
                { "V0HISP_BCOCOBR" , ""},
                { "V0HISP_AGECOBR" , ""},
                { "V0HISP_NRAVISO" , ""},
                { "V0HISP_NRENDOCA" , ""},
                { "V0HISP_SITCONTB" , ""},
                { "V0HISP_COD_USUAR" , ""},
                { "V0HISP_RNUDOC" , ""},
                { "V0HISP_DTQITBCO" , ""},
                { "V0HISP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , ""},
                { "V0COBA_NRENDOS" , ""},
                { "V0COBA_NUM_ITEM" , ""},
                { "V0COBA_OCORHIST" , ""},
                { "V0COBA_RAMOFR" , ""},
                { "V0COBA_MODALIFR" , ""},
                { "V0COBA_COD_COBER" , ""},
                { "V0COBA_IMP_SEG_IX" , ""},
                { "V0COBA_PRM_TAR_IX" , ""},
                { "V0COBA_IMP_SEG_VR" , ""},
                { "V0COBA_PRM_TAR_VR" , ""},
                { "V0COBA_PCT_COBERT" , ""},
                { "V0COBA_FATOR_MULT" , ""},
                { "V0COBA_DATA_INIVI" , ""},
                { "V0COBA_DATA_TERVI" , ""},
                { "V0COBA_COD_EMPRESA" , ""},
                { "V0COBA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q30);

            #endregion

            #region R0600_00_MONTA_ENDOSSO01_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""},
                { "V0BILH_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_MONTA_ENDOSSO01_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1", q32);

            #endregion

            #region R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , ""},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1", q33);

            #endregion

            #region R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , ""},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1", q34);

            #endregion

            #region R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0APCR_NUM_APOL" , ""},
                { "V0APCR_RAMOFR" , ""},
                { "V0APCR_MODALIFR" , ""},
                { "V0APCR_CODCORR" , ""},
                { "V0APCR_CODSUBES" , ""},
                { "V0APCR_DTINIVIG" , ""},
                { "V0APCR_DTTERVIG" , ""},
                { "V0APCR_PCPARCOR" , ""},
                { "V0APCR_PCCOMCOR" , ""},
                { "V0APCR_TIPCOM" , ""},
                { "V0APCR_INDCRT" , ""},
                { "V0APCR_COD_EMPRESA" , ""},
                { "V0APCR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1", q35);

            #endregion

            #region R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , ""},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1", q36);

            #endregion

            #region BI8005B_V1RCAPCOMP

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_SITUACAO" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_DATARCAP" , ""},
                { "V1RCAC_DTCADAST" , ""},
                { "V1RCAC_SITCONTB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI8005B_V1RCAPCOMP", q37);

            #endregion

            #region R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0APCC_NUM_APOL" , ""},
                { "V0APCC_CODCOSS" , ""},
                { "V0APCC_RAMOFR" , ""},
                { "V0APCC_DTINIVIG" , ""},
                { "V0APCC_DTTERVIG" , ""},
                { "V0APCC_PCPARTIC" , ""},
                { "V0APCC_PCCOMCOS" , ""},
                { "V0APCC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1", q39);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , ""},
                { "V0ORDC_NRENDOS" , ""},
                { "V0ORDC_CODCOSS" , ""},
                { "V0ORDC_ORDEM_CED" , ""},
                { "V0ORDC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""},
                { "V1NCOS_CONGENER" , ""},
                { "V1NCOS_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1", q41);

            #endregion

            #region R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_QTCOSSEG" , ""},
                { "V0APOL_PCTCED" , ""},
                { "V0APOL_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1", q42);

            #endregion

            #region R1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
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
                { "MOVDEBCE_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1", q43);

            #endregion

            #region R1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "APOLCOBR_COD_EMPRESA" , ""},
                { "APOLCOBR_COD_FONTE" , ""},
                { "APOLCOBR_NUM_APOLICE" , ""},
                { "APOLCOBR_NUM_ENDOSSO" , ""},
                { "APOLCOBR_COD_PRODUTO" , ""},
                { "APOLCOBR_NUM_MATRICULA" , ""},
                { "APOLCOBR_TIPO_COBRANCA" , ""},
                { "APOLCOBR_AGE_COBRANCA" , ""},
                { "APOLCOBR_COD_AGENCIA" , ""},
                { "APOLCOBR_OPERACAO_CONTA" , ""},
                { "APOLCOBR_NUM_CONTA" , ""},
                { "APOLCOBR_DIG_CONTA" , ""},
                { "APOLCOBR_COD_AGENCIA_DEB" , ""},
                { "APOLCOBR_OPER_CONTA_DEB" , ""},
                { "APOLCOBR_NUM_CONTA_DEB" , ""},
                { "APOLCOBR_DIG_CONTA_DEB" , ""},
                { "APOLCOBR_NUM_CARTAO" , ""},
                { "APOLCOBR_DIA_DEBITO" , ""},
                { "APOLCOBR_NR_CERTIF_AUTO" , ""},
                { "APOLCOBR_MARGEM_COMERCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1", q44);

            #endregion

            #region R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "GELMR_QTD_SEGUROS" , ""},
                { "GELMR_VLR_SOMA_IS" , ""},
                { "V0CLIE_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1", q45);

            #endregion

            #region R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_CGCCPF" , ""},
                { "V0BILH_RAMO" , ""},
                { "GELMR_QTD_SEGUROS" , ""},
                { "GELMR_VLR_SOMA_IS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1", q46);

            #endregion

            #region R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1", q47);

            #endregion

            #region R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q48);

            #endregion

            #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q49);

            #endregion

            #region R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1", q50);

            #endregion

            #region R3170_00_UPDATE_BILHETE_DB_UPDATE_1_Update1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""},
                { "V0BILH_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3170_00_UPDATE_BILHETE_DB_UPDATE_1_Update1", q51);

            #endregion

            #region R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1", q52);

            #endregion

            #region R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q53);

            #endregion

            #region R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1SIST_DTMOVACB" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_SITUACAO" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_DATARCAP" , ""},
                { "V1RCAC_DTCADAST" , ""},
                { "V1RCAC_SITCONTB" , ""},
                { "V1RCAC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q54);

            #endregion

            #region R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q55);

            #endregion

            #region R3210_00_ALTERA_RCAPS_DB_UPDATE_1_Update1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_NRENDOS" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_00_ALTERA_RCAPS_DB_UPDATE_1_Update1", q56);

            #endregion

            #region R3210_20_CROT_DB_SELECT_1_Query1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_CGCCPF" , ""},
                { "V0BILH_NOME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_20_CROT_DB_SELECT_1_Query1", q57);

            #endregion

            #region R3210_20_CROT_DB_SELECT_2_Query1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "V1CROT_CGCCPF" , ""},
                { "V1CROT_BILH_AP" , ""},
                { "V1CROT_BILH_RES" , ""},
                { "V1CROT_BILH_VDAZUL" , ""},
                { "V1CROT_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_20_CROT_DB_SELECT_2_Query1", q58);

            #endregion

            #region R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "V0CROT_DTMOVABE" , ""},
                { "V0CROT_BILH_AP" , ""},
                { "V0BILH_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1", q59);

            #endregion

            #region R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "V0CROT_BILH_RES" , ""},
                { "V0CROT_DTMOVABE" , ""},
                { "V0BILH_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1", q60);

            #endregion

            #region R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "V0CROT_CGCCPF" , ""},
                { "V0CROT_BILH_AP" , ""},
                { "V0CROT_BILH_RES" , ""},
                { "V0CROT_BILH_VDAZUL" , ""},
                { "V0CROT_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1", q61);

            #endregion

            #region R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1", q62);

            #endregion

            #region R9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "VG078_NUM_CERTIFICADO" , ""},
                { "VG078_DES_ANDAMENTO" , ""},
                { "VG078_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1", q63);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI8005B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //*********** GEJVS002 ***************
                GEJVS002_Tests.Load_Parameters();
                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , "1989-01-01"},
                { "PARAMGER_DATA_TERVIGENCIA" , "9999-12-31"},
                { "PARAMGER_COD_MOEDA" , "1"},
                { "PARAMGER_COD_BANCO" , "104"},
                { "PARAMGER_COD_AGENCIA" , "630"},
                { "PARAMGER_OPCAO_BANCO" , "1"},
                { "PARAMGER_DIF_PREMIOS" , "10.00000"},
                { "PARAMGER_FAIXA_APOL_MANUAL" , "99999999"},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , "999999"},
                { "PARAMGER_DATA_FATURAVG_AUT" , "1999-12-31"},
                { "PARAMGER_CAPITAL_SOCIAL" , "500000000.00"},
                { "PARAMGER_CAPITAL_REALIZADO" , "500000000.00"},
                { "PARAMGER_CAPITAL_VINCULADO" , "250000000.00"},
                { "PARAMGER_ULT_AVISO_CREDITO" , "0"},
                { "PARAMGER_CODIGO_LIDER" , "5631"},
                { "PARAMGER_NUM_RELACAO" , "96"},
                { "PARAMGER_COD_EMPRESA" , "0"},
                { "PARAMGER_COD_CGCCPF" , "34020354000110"},
                { "PARAMGER_COD_EMPRESA_CAP" , "1"}
            });
                q70.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , "1989-01-01"},
                { "PARAMGER_DATA_TERVIGENCIA" , "9999-12-31"},
                { "PARAMGER_COD_MOEDA" , "1"},
                { "PARAMGER_COD_BANCO" , "104"},
                { "PARAMGER_COD_AGENCIA" , "630"},
                { "PARAMGER_OPCAO_BANCO" , "1"},
                { "PARAMGER_DIF_PREMIOS" , "10.00000"},
                { "PARAMGER_FAIXA_APOL_MANUAL" , "99999999"},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , "999999"},
                { "PARAMGER_DATA_FATURAVG_AUT" , "1999-12-31"},
                { "PARAMGER_CAPITAL_SOCIAL" , "500000000.00"},
                { "PARAMGER_CAPITAL_REALIZADO" , "500000000.00"},
                { "PARAMGER_CAPITAL_VINCULADO" , "250000000.00"},
                { "PARAMGER_ULT_AVISO_CREDITO" , "0"},
                { "PARAMGER_CODIGO_LIDER" , "8141"},
                { "PARAMGER_NUM_RELACAO" , "96"},
                { "PARAMGER_COD_EMPRESA" , "10"},
                { "PARAMGER_COD_CGCCPF" , "3730204000176"},
                { "PARAMGER_COD_EMPRESA_CAP" , "89"}
               });
                AppSettings.TestSet.DynamicData.Remove("GEJVS002_GE074_CURSOR");
                AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q70);
              //************************************************
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2026-01-01"},
                { "V1SIST_DTCURRENT" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2026-01-01"},
                { "V1SIST_TIMESTAMP" , "2000-01-01 09:00:00"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

                #endregion

                #region BI8005B_CCBO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "0"},
                { "CBO_DESCR_CBO" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI8005B_CCBO");
                AppSettings.TestSet.DynamicData.Add("BI8005B_CCBO", q2);

                #endregion

                #region BI8005B_V0BILHETE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "1"},
                { "V0BILH_NUMAPOL" , "0"},
                { "V0BILH_FONTE" , "3"},
                { "V0BILH_AGECOBR" , "4"},
                { "V0BILH_NUM_MATR" , "5"},
                { "V0BILH_AGENCIA" , "6"},
                { "V0BILH_CODCLIEN" , "7"},
                { "V0BILH_PROFISSAO" , "8"},
                { "V0BILH_AGENCIA_DEB" , "9"},
                { "V0BILH_OPERACAO_DEB" , "10"},
                { "V0BILH_NUMCTA_DEB" , "11"},
                { "V0BILH_DIGCTA_DEB" , "12"},
                { "V0BILH_OPCAO_COBER" , "13"},
                { "V0BILH_DTQITBCO" , "2020-01-01"},
                { "V0BILH_DTVENCTO" , "2020-01-01"},
                { "V0BILH_VLRCAP" , "0"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "1"},
                { "V0BILH_SITUACAO" , "100"},
                { "V0BILH_NUM_APO_ANT" , "100"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI8005B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI8005B_V0BILHETE", q3);

                #endregion

                #region BI8005B_V1COSSEGPROD

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CODPRODU" , "1"},
                { "V1COSP_RAMO" , "2"},
                { "V1COSP_CONGENER" , "3"},
                { "V1COSP_PCPARTIC" , "4"},
                { "V1COSP_PCCOMCOS" , "5"},
                { "V1COSP_PCADMCOS" , "6"},
                { "V1COSP_DTINIVIG" , "1"},
                { "V1COSP_DTTERVIG" , "20"},
                { "V1COSP_SITUACAO" , "9"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI8005B_V1COSSEGPROD");
                AppSettings.TestSet.DynamicData.Add("BI8005B_V1COSSEGPROD", q4);

                #endregion

                #region R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_COD_EMPRESA_CAP" , "1"},
                { "PRODUTO_COD_EMPRESA" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_SICOB" , "1"},
                { "V0SIVPF_SIT_PROPOSTA" , "2"},
                { "V0CONV_NUM_PROPOSTA_SIVPF" , "3"},
                { "PRPFIDEL_COD_PROD_SIVPF" , "4"},
                { "PRPFIDEL_ORIG_PROPOSTA" , "5"},
                { "PRPFIDEL_QTD_MESES" , "6"},
                { "PRPFIDEL_PERIPGTO" , "7"},
                { "PRPFIDEL_OPCAO_COBER" , "8"},
                { "PRPFIDEL_DIA_DEBITO" , "9"},
                { "PRPFIDEL_NUM_IDENTIFICA" , "10"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "PRPFIDCO_INFORM_COMPLEM" , "X"}
               });
                AppSettings.TestSet.DynamicData.Remove("R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_PROPOSTA_SIVPF" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_CGCCPF" , "123456"},
                { "V0CLIE_DTNASC" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "GELMR_QTD_SEGUROS" , "1"},
                { "GELMR_VLR_SOMA_IS" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1", q12);
                #endregion

                #region R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1", q13);

                #endregion

                #region R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , "2000-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , "2000-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1", q15);

                #endregion

                #region R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "12465"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1", q16);

                #endregion

                #region R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "1"},
                { "V1BILC_PRMTAR_IX" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1", q17);

                #endregion

                #region R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "1462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "4"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1", q19);

                #endregion

                #region R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , "0"},
                { "V0BILFX_VALADT" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1", q20);
                #endregion

                #region R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1", q21);

                #endregion

                #region R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_CODUNIMO" , "1"},
                { "V1BILC_PCCOMCOR" , "2"},
                { "V1BILC_PCIOCC" , "3"},
                { "V1BILC_VALMAX" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1", q23);

                #endregion

                #region R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1", q26);

                #endregion

                #region R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2000-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1", q32);

                #endregion

                #region R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , "100"},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1", q33);

                #endregion

                #region R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , "100"},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1", q34);

                #endregion

                #region R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , "100"},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1", q36);

                #endregion

                #region BI8005B_V1RCAPCOMP

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "1"},
                { "V1RCAC_NRRCAP" , "12"},
                { "V1RCAC_NRRCAPCO" , "123"},
                { "V1RCAC_OPERACAO" , "123"},
                { "V1RCAC_DTMOVTO" , "2000-01-01"},
                { "V1RCAC_HORAOPER" , "12"},
                { "V1RCAC_SITUACAO" , "0"},
                { "V1RCAC_BCOAVISO" , "1"},
                { "V1RCAC_AGEAVISO" , "2"},
                { "V1RCAC_NRAVISO" , "3"},
                { "V1RCAC_VLRCAP" , "100"},
                { "V1RCAC_DATARCAP" , "2000-01-01"},
                { "V1RCAC_DTCADAST" , "2020-01-01"},
                { "V1RCAC_SITCONTB" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI8005B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("BI8005B_V1RCAPCOMP", q37);

                #endregion

                #region R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1", q39);

                #endregion

                #region R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "1"},
                { "V1RCAC_AGEAVISO" , "2"},
                { "V1RCAC_NRAVISO" , "3"},
                { "V1RCAC_DATARCAP" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1", q47);

                #endregion

                #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q49);

                #endregion

                #region R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1", q50);

                #endregion

                #region R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1", q52);

                #endregion

                #region R3210_20_CROT_DB_SELECT_1_Query1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_CGCCPF" , "123456"},
                { "V0BILH_NOME" , "X"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3210_20_CROT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_20_CROT_DB_SELECT_1_Query1", q57);

                #endregion

                #region R3210_20_CROT_DB_SELECT_2_Query1

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "V1CROT_CGCCPF" , "123"},
                { "V1CROT_BILH_AP" , "1"},
                { "V1CROT_BILH_RES" , "1"},
                { "V1CROT_BILH_VDAZUL" , "1"},
                { "V1CROT_DTMOVABE" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3210_20_CROT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_20_CROT_DB_SELECT_2_Query1", q58);

                #endregion

                #endregion
                var program = new BI8005B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region R0250_00_LEITURA_DB_UPDATE_1_Update1

                var envList1 = AppSettings.TestSet.DynamicData["R0250_00_LEITURA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("WHOST_SIT_PROP_SIVPF", out var WHOST_SIT_PROP_SIVPF) && WHOST_SIT_PROP_SIVPF == "EMT");
                Assert.True(envList1[1].TryGetValue("V0BILH_NUMBIL", out var V0BILH_NUMBIL) && V0BILH_NUMBIL == "000000000000001");

                #endregion

                #region R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

                var envList18 = AppSettings.TestSet.DynamicData["R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList18?.Count > 0);

                Assert.True(envList18[0].TryGetValue("V0BILH_SITUACAO", out var V0BILH_SITUACAO) && V0BILH_SITUACAO == "");
                Assert.True(envList18[0].TryGetValue("V0BILH_NUMBIL", out var V0BILH_NUMBIL18) && V0BILH_NUMBIL18 == "");

                #endregion

                #region R0500_00_TRATA_APOLICE_DB_UPDATE_1_Update1

                var envList = AppSettings.TestSet.DynamicData["R0500_00_TRATA_APOLICE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("V0NAES_SEQ_APOL", out var V0NAES_SEQ_APOL) && V0NAES_SEQ_APOL == "000000002");
                Assert.True(envList[1].TryGetValue("WWORK_RAMO_ANT", out var WWORK_RAMO_ANT) && WWORK_RAMO_ANT == "0081");
                Assert.True(envList[1].TryGetValue("V0APOL_ORGAO", out var V0APOL_ORGAO) && V0APOL_ORGAO == "0000");

                #endregion

                #region R0500_00_TRATA_APOLICE_DB_INSERT_1_Insert1

                var envList2 = AppSettings.TestSet.DynamicData["R0500_00_TRATA_APOLICE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("V0APOL_CODCLIEN", out var V0APOL_CODCLIEN) && V0APOL_CODCLIEN == "000000007");
                Assert.True(envList2[1].TryGetValue("V0APOL_NUM_APOL", out var V0APOL_NUM_APOL) && V0APOL_NUM_APOL == "0108100000002");
                Assert.True(envList2[1].TryGetValue("V0APOL_NUM_ITEM", out var V0APOL_NUM_ITEM) && V0APOL_NUM_ITEM == "000000001");
                Assert.True(envList2[1].TryGetValue("V0APOL_MODALIDA", out var V0APOL_MODALIDA) && V0APOL_MODALIDA == "0000");
                Assert.True(envList2[1].TryGetValue("V0APOL_ORGAO", out var V0APOL_ORGAO1) && V0APOL_ORGAO1 == "0010");
                Assert.True(envList2[1].TryGetValue("V0APOL_RAMO", out var V0APOL_RAMO) && V0APOL_RAMO == "0081");
                Assert.True(envList2[1].TryGetValue("V0APOL_NUM_APO_ANT", out var V0APOL_NUM_APO_ANT) && V0APOL_NUM_APO_ANT == "0000000012465");
                Assert.True(envList2[1].TryGetValue("V0APOL_NUMBIL", out var V0APOL_NUMBIL) && V0APOL_NUMBIL == "000000000000001");
                Assert.True(envList2[1].TryGetValue("V0APOL_TIPSGU", out var V0APOL_TIPSGU) && V0APOL_TIPSGU == "1");
                Assert.True(envList2[1].TryGetValue("V0APOL_TIPAPO", out var V0APOL_TIPAPO) && V0APOL_TIPAPO == "2");
                Assert.True(envList2[1].TryGetValue("V0APOL_TIPCALC", out var V0APOL_TIPCALC) && V0APOL_TIPCALC == "3");
                Assert.True(envList2[1].TryGetValue("V0APOL_PODPUBL", out var V0APOL_PODPUBL) && V0APOL_PODPUBL == "N");
                Assert.True(envList2[1].TryGetValue("V0APOL_NUM_ATA", out var V0APOL_NUM_ATA) && V0APOL_NUM_ATA == "000000000");
                Assert.True(envList2[1].TryGetValue("V0APOL_ANO_ATA", out var V0APOL_ANO_ATA) && V0APOL_ANO_ATA == "0000");
                Assert.True(envList2[1].TryGetValue("V0APOL_IDEMAN", out var V0APOL_IDEMAN) && V0APOL_IDEMAN == " ");
                Assert.True(envList2[1].TryGetValue("V0APOL_PCDESCON", out var V0APOL_PCDESCON) && V0APOL_PCDESCON == "000.00");
                Assert.True(envList2[1].TryGetValue("V0APOL_PCIOCC", out var V0APOL_PCIOCC) && V0APOL_PCIOCC == "000.00");
                Assert.True(envList2[1].TryGetValue("V0APOL_TPCOSCED", out var V0APOL_TPCOSCED) && V0APOL_TPCOSCED == "4");
                Assert.True(envList2[1].TryGetValue("V0APOL_QTCOSSEG", out var V0APOL_QTCOSSEG) && V0APOL_QTCOSSEG == "0000");
                Assert.True(envList2[1].TryGetValue("V0APOL_PCTCED", out var V0APOL_PCTCED) && V0APOL_PCTCED == "0000.00000");
                Assert.True(envList2[1].TryGetValue("V0APOL_COD_EMPRESA", out var V0APOL_COD_EMPRESA) && V0APOL_COD_EMPRESA == "000000000");
                Assert.True(envList2[1].TryGetValue("V0APOL_CODPRODU", out var V0APOL_CODPRODU) && V0APOL_CODPRODU == "0001");
                Assert.True(envList2[1].TryGetValue("V0APOL_TPCORRET", out var V0APOL_TPCORRET) && V0APOL_TPCORRET == "2");

                #endregion

                #region R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1

                var envList3 = AppSettings.TestSet.DynamicData["R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("V0APOL_NUM_APOL", out var V0APOL_NUM_APOL1) && V0APOL_NUM_APOL1 == "0108100000002");
                Assert.True(envList3[1].TryGetValue("V0BILH_SITUACAO", out var V0BILH_SITUACAO1) && V0BILH_SITUACAO1 == "9");
                Assert.True(envList3[1].TryGetValue("V0BILH_NUMBIL", out var V0BILH_NUMBIL1) && V0BILH_NUMBIL1 == "000000000000001");

                #endregion

                #region R0530_00_INCLUI_ENDOSSO_DB_INSERT_1_Insert1

                var envList4 = AppSettings.TestSet.DynamicData["R0530_00_INCLUI_ENDOSSO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                Assert.True(envList4[1].TryGetValue("V0ENDO_NUM_APOL", out var V0ENDO_NUM_APOL) && V0ENDO_NUM_APOL == "0108100000002");
                Assert.True(envList4[1].TryGetValue("V0ENDO_NRENDOS", out var V0ENDO_NRENDOS) && V0ENDO_NRENDOS == "000000000");
                Assert.True(envList4[1].TryGetValue("V0ENDO_CODSUBES", out var V0ENDO_CODSUBES) && V0ENDO_CODSUBES == "0000");
                Assert.True(envList4[1].TryGetValue("V0ENDO_FONTE", out var V0ENDO_FONTE) && V0ENDO_FONTE == "0003");
                Assert.True(envList4[1].TryGetValue("V0ENDO_NRPROPOS", out var V0ENDO_NRPROPOS) && V0ENDO_NRPROPOS == "000000125");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DATPRO", out var V0ENDO_DATPRO) && V0ENDO_DATPRO == "9999-99-99");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DT_LIBER", out var V0ENDO_DT_LIBER) && V0ENDO_DT_LIBER == "2026-01-01");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DTEMIS", out var V0ENDO_DTEMIS) && V0ENDO_DTEMIS == "2026-01-01");
                Assert.True(envList4[1].TryGetValue("V0ENDO_NRRCAP", out var V0ENDO_NRRCAP) && V0ENDO_NRRCAP == "000001462");
                Assert.True(envList4[1].TryGetValue("V0ENDO_VLRCAP", out var V0ENDO_VLRCAP) && V0ENDO_VLRCAP == "0000000000000.00");
                Assert.True(envList4[1].TryGetValue("V0ENDO_BCORCAP", out var V0ENDO_BCORCAP) && V0ENDO_BCORCAP == "0104");
                Assert.True(envList4[1].TryGetValue("V0ENDO_AGERCAP", out var V0ENDO_AGERCAP) && V0ENDO_AGERCAP == "0004");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DACRCAP", out var V0ENDO_DACRCAP) && V0ENDO_DACRCAP == "0");
                Assert.True(envList4[1].TryGetValue("V0ENDO_IDRCAP", out var V0ENDO_IDRCAP) && V0ENDO_IDRCAP == "0");
                Assert.True(envList4[1].TryGetValue("V0ENDO_BCOCOBR", out var V0ENDO_BCOCOBR) && V0ENDO_BCOCOBR == "0104");
                Assert.True(envList4[1].TryGetValue("V0ENDO_AGECOBR", out var V0ENDO_AGECOBR) && V0ENDO_AGECOBR == "0002");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DACCOBR", out var V0ENDO_DACCOBR) && V0ENDO_DACCOBR == "0");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DTINIVIG", out var V0ENDO_DTINIVIG) && V0ENDO_DTINIVIG == "9999-99-99");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DTTERVIG", out var V0ENDO_DTTERVIG) && V0ENDO_DTTERVIG == "2000-01-01");
                Assert.True(envList4[1].TryGetValue("V0ENDO_CDFRACIO", out var V0ENDO_CDFRACIO) && V0ENDO_CDFRACIO == "0000");
                Assert.True(envList4[1].TryGetValue("V0ENDO_PCENTRAD", out var V0ENDO_PCENTRAD) && V0ENDO_PCENTRAD == "000.00");
                Assert.True(envList4[1].TryGetValue("V0ENDO_PCADICIO", out var V0ENDO_PCADICIO) && V0ENDO_PCADICIO == "000.00");
                Assert.True(envList4[1].TryGetValue("V0ENDO_PRESTA1", out var V0ENDO_PRESTA1) && V0ENDO_PRESTA1 == "0000");
                Assert.True(envList4[1].TryGetValue("V0ENDO_QTPARCEL", out var V0ENDO_QTPARCEL) && V0ENDO_QTPARCEL == "0000");
                Assert.True(envList4[1].TryGetValue("V0ENDO_QTPRESTA", out var V0ENDO_QTPRESTA) && V0ENDO_QTPRESTA == "0000");
                Assert.True(envList4[1].TryGetValue("V0ENDO_QTITENS", out var V0ENDO_QTITENS) && V0ENDO_QTITENS == "0001");
                Assert.True(envList4[1].TryGetValue("V0ENDO_CODTXT", out var V0ENDO_CODTXT) && V0ENDO_CODTXT == "   ");
                Assert.True(envList4[1].TryGetValue("V0ENDO_CDACEITA", out var V0ENDO_CDACEITA) && V0ENDO_CDACEITA == "0");
                Assert.True(envList4[1].TryGetValue("V0ENDO_MOEDA_IMP", out var V0ENDO_MOEDA_IMP) && V0ENDO_MOEDA_IMP == "0001");
                Assert.True(envList4[1].TryGetValue("V0ENDO_MOEDA_PRM", out var V0ENDO_MOEDA_PRM) && V0ENDO_MOEDA_PRM == "0001");
                Assert.True(envList4[1].TryGetValue("V0ENDO_TIPO_ENDO", out var V0ENDO_TIPO_ENDO) && V0ENDO_TIPO_ENDO == "0");
                Assert.True(envList4[1].TryGetValue("V0ENDO_COD_USUAR", out var V0ENDO_COD_USUAR) && V0ENDO_COD_USUAR == "BI8005B ");
                Assert.True(envList4[1].TryGetValue("V0ENDO_OCORR_END", out var V0ENDO_OCORR_END) && V0ENDO_OCORR_END == "0001");
                Assert.True(envList4[1].TryGetValue("V0ENDO_SITUACAO", out var V0ENDO_SITUACAO) && V0ENDO_SITUACAO == "1");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DATARCAP", out var V0ENDO_DATARCAP) && V0ENDO_DATARCAP == "2020-01-01");
                Assert.True(envList4[1].TryGetValue("V0ENDO_COD_EMPRESA", out var V0ENDO_COD_EMPRESA) && V0ENDO_COD_EMPRESA == "000000000");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DATARCAP", out var V0ENDO_DATARCAP4) && V0ENDO_DATARCAP4 == "2020-01-01");
                Assert.True(envList4[1].TryGetValue("V0ENDO_CORRECAO", out var V0ENDO_CORRECAO) && V0ENDO_CORRECAO == "1");
                Assert.True(envList4[1].TryGetValue("V0ENDO_ISENTA_CST", out var V0ENDO_ISENTA_CST) && V0ENDO_ISENTA_CST == "S");
                Assert.True(envList4[1].TryGetValue("V0ENDO_DTVENCTO", out var V0ENDO_DTVENCTO) && V0ENDO_DTVENCTO == "          ");
                Assert.True(envList4[1].TryGetValue("V0ENDO_CFPREFIX", out var V0ENDO_CFPREFIX) && V0ENDO_CFPREFIX == "0000.00000");
                Assert.True(envList4[1].TryGetValue("V0ENDO_VLCUSEMI", out var V0ENDO_VLCUSEMI) && V0ENDO_VLCUSEMI == "0000000000000.00");
                Assert.True(envList4[1].TryGetValue("V0ENDO_RAMO", out var V0ENDO_RAMO) && V0ENDO_RAMO == "0081");
                Assert.True(envList4[1].TryGetValue("V0ENDO_CODPRODU", out var V0ENDO_CODPRODU) && V0ENDO_CODPRODU == "0001");

                #endregion

                #region R0540_00_INCLUI_PARCELAS_DB_INSERT_1_Insert1

                var envList5 = AppSettings.TestSet.DynamicData["R0540_00_INCLUI_PARCELAS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5?.Count > 1);
                Assert.True(envList5[1].TryGetValue("V0PARC_NUM_APOL", out var V0PARC_NUM_APOL) && V0PARC_NUM_APOL == "0108100000002");
                Assert.True(envList5[1].TryGetValue("V0PARC_NRENDOS", out var V0PARC_NRENDOS) && V0PARC_NRENDOS == "000000000");
                Assert.True(envList5[1].TryGetValue("V0PARC_NRPARCEL", out var V0PARC_NRPARCEL) && V0PARC_NRPARCEL == "0000");
                Assert.True(envList5[1].TryGetValue("V0PARC_DACPARC", out var V0PARC_DACPARC) && V0PARC_DACPARC == "0");
                Assert.True(envList5[1].TryGetValue("V0PARC_FONTE", out var V0PARC_FONTE) && V0PARC_FONTE == "0003");
                Assert.True(envList5[1].TryGetValue("V0PARC_NRTIT", out var V0PARC_NRTIT) && V0PARC_NRTIT == "0000000000001");
                Assert.True(envList5[1].TryGetValue("V0PARC_PRM_TAR_IX", out var V0PARC_PRM_TAR_IX) && V0PARC_PRM_TAR_IX == "0000000000.00000");
                Assert.True(envList5[1].TryGetValue("V0PARC_VAL_DES_IX", out var V0PARC_VAL_DES_IX) && V0PARC_VAL_DES_IX == "0000000000.00000");
                Assert.True(envList5[1].TryGetValue("V0PARC_OTNPRLIQ", out var V0PARC_OTNPRLIQ) && V0PARC_OTNPRLIQ == "0000000000.00000");
                Assert.True(envList5[1].TryGetValue("V0PARC_OTNADFRA", out var V0PARC_OTNADFRA) && V0PARC_OTNADFRA == "0000000000.00000");
                Assert.True(envList5[1].TryGetValue("V0PARC_OTNCUSTO", out var V0PARC_OTNCUSTO) && V0PARC_OTNCUSTO == "0000000000.00000");
                Assert.True(envList5[1].TryGetValue("V0PARC_OTNIOF", out var V0PARC_OTNIOF) && V0PARC_OTNIOF == "0000000000.00000");
                Assert.True(envList5[1].TryGetValue("V0PARC_OTNTOTAL", out var V0PARC_OTNTOTAL) && V0PARC_OTNTOTAL == "0000000000.00000");
                Assert.True(envList5[1].TryGetValue("V0PARC_OCORHIST", out var V0PARC_OCORHIST) && V0PARC_OCORHIST == "0002");
                Assert.True(envList5[1].TryGetValue("V0PARC_QTDDOC", out var V0PARC_QTDDOC) && V0PARC_QTDDOC == "0000");
                Assert.True(envList5[1].TryGetValue("V0PARC_SITUACAO", out var V0PARC_SITUACAO) && V0PARC_SITUACAO == "1");
                Assert.True(envList5[1].TryGetValue("V0PARC_COD_EMPRESA", out var V0PARC_COD_EMPRESA) && V0PARC_COD_EMPRESA == "000000000");


                #endregion

                #region R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1
             
                var envList6 = AppSettings.TestSet.DynamicData["R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6?.Count > 1);
                Assert.True(envList6[1].TryGetValue("V0HISP_NUM_APOL", out var V0HISP_NUM_APOL) && V0HISP_NUM_APOL == "0108100000002");
                Assert.True(envList6[1].TryGetValue("V0HISP_NRENDOS", out var V0HISP_NRENDOS) && V0HISP_NRENDOS == "000000000");
                Assert.True(envList6[1].TryGetValue("V0HISP_NRPARCEL", out var V0HISP_NRPARCEL) && V0HISP_NRPARCEL == "0000");
                Assert.True(envList6[1].TryGetValue("V0HISP_DACPARC", out var V0HISP_DACPARC) && V0HISP_DACPARC == "0");
                Assert.True(envList6[1].TryGetValue("V0HISP_DTMOVTO", out var V0HISP_DTMOVTO) && V0HISP_DTMOVTO == "2026-01-01");
                Assert.True(envList6[1].TryGetValue("V0HISP_OPERACAO", out var V0HISP_OPERACAO) && V0HISP_OPERACAO == "0101");
                Assert.True(envList6[1].TryGetValue("V0HISP_OCORHIST", out var V0HISP_OCORHIST) && V0HISP_OCORHIST == "0001");
                Assert.True(envList6[1].TryGetValue("V0HISP_PRM_TARIFA", out var V0HISP_PRM_TARIFA) && V0HISP_PRM_TARIFA == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HISP_VAL_DESCON", out var V0HISP_VAL_DESCON) && V0HISP_VAL_DESCON == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HISP_VLPRMLIQ", out var V0HISP_VLPRMLIQ) && V0HISP_VLPRMLIQ == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HISP_VLADIFRA", out var V0HISP_VLADIFRA) && V0HISP_VLADIFRA == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HISP_VLCUSEMI", out var V0HISP_VLCUSEMI) && V0HISP_VLCUSEMI == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HISP_VLIOCC", out var V0HISP_VLIOCC) && V0HISP_VLIOCC == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HISP_VLPRMTOT", out var V0HISP_VLPRMTOT) && V0HISP_VLPRMTOT == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HISP_VLPREMIO", out var V0HISP_VLPREMIO) && V0HISP_VLPREMIO == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("V0HISP_DTVENCTO", out var V0HISP_DTVENCTO) && V0HISP_DTVENCTO == "2026-01-01");
                Assert.True(envList6[1].TryGetValue("V0HISP_BCOCOBR", out var V0HISP_BCOCOBR) && V0HISP_BCOCOBR == "0104");
                Assert.True(envList6[1].TryGetValue("V0HISP_AGECOBR", out var V0HISP_AGECOBR) && V0HISP_AGECOBR == "0002");
                Assert.True(envList6[1].TryGetValue("V0HISP_NRAVISO", out var V0HISP_NRAVISO) && V0HISP_NRAVISO == "000000000");
                Assert.True(envList6[1].TryGetValue("V0HISP_NRENDOCA", out var V0HISP_NRENDOCA) && V0HISP_NRENDOCA == "000000000");
                Assert.True(envList6[1].TryGetValue("V0HISP_SITCONTB", out var V0HISP_SITCONTB) && V0HISP_SITCONTB == "0");
                Assert.True(envList6[1].TryGetValue("V0HISP_COD_USUAR", out var V0HISP_COD_USUAR) && V0HISP_COD_USUAR == "BI8005B ");
                Assert.True(envList6[1].TryGetValue("V0HISP_RNUDOC", out var V0HISP_RNUDOC) && V0HISP_RNUDOC == "000000000");
                Assert.True(envList6[1].TryGetValue("V0HISP_DTQITBCO", out var V0HISP_DTQITBCO) && V0HISP_DTQITBCO == "          ");
                Assert.True(envList6[1].TryGetValue("V0HISP_COD_EMPRESA", out var V0HISP_COD_EMPRESA) && V0HISP_COD_EMPRESA == "000000000");

                #endregion

                #region R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

                var envList7 = AppSettings.TestSet.DynamicData["R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7?.Count > 0);

                Assert.True(envList7[1].TryGetValue("V0COBA_NUM_APOL", out var V0COBA_NUM_APOL) && V0COBA_NUM_APOL == "0108100000002");
                Assert.True(envList7[1].TryGetValue("V0COBA_NRENDOS", out var V0COBA_NRENDOS) && V0COBA_NRENDOS == "000000000");
                Assert.True(envList7[1].TryGetValue("V0COBA_NUM_ITEM", out var V0COBA_NUM_ITEM) && V0COBA_NUM_ITEM == "000000000");
                Assert.True(envList7[1].TryGetValue("V0COBA_OCORHIST", out var V0COBA_OCORHIST) && V0COBA_OCORHIST == "0001");
                Assert.True(envList7[1].TryGetValue("V0COBA_RAMOFR", out var V0COBA_RAMOFR) && V0COBA_RAMOFR == "0081");
                Assert.True(envList7[1].TryGetValue("V0COBA_MODALIFR", out var V0COBA_MODALIFR) && V0COBA_MODALIFR == "0000");
                Assert.True(envList7[1].TryGetValue("V0COBA_COD_COBER", out var V0COBA_COD_COBER) && V0COBA_COD_COBER == "0000");
                Assert.True(envList7[1].TryGetValue("V0COBA_IMP_SEG_IX", out var V0COBA_IMP_SEG_IX) && V0COBA_IMP_SEG_IX == "0000000000001.00");
                Assert.True(envList7[1].TryGetValue("V0COBA_PRM_TAR_IX", out var V0COBA_PRM_TAR_IX) && V0COBA_PRM_TAR_IX == "0000000000.00000");
                Assert.True(envList7[1].TryGetValue("V0COBA_IMP_SEG_VR", out var V0COBA_IMP_SEG_VR) && V0COBA_IMP_SEG_VR == "0000000000001.00");
                Assert.True(envList7[1].TryGetValue("V0COBA_PRM_TAR_VR", out var V0COBA_PRM_TAR_VR) && V0COBA_PRM_TAR_VR == "0000000000.00000");
                Assert.True(envList7[1].TryGetValue("V0COBA_PCT_COBERT", out var V0COBA_PCT_COBERT) && V0COBA_PCT_COBERT == "100.00");
                Assert.True(envList7[1].TryGetValue("V0COBA_FATOR_MULT", out var V0COBA_FATOR_MULT) && V0COBA_FATOR_MULT == "0001");
                Assert.True(envList7[1].TryGetValue("V0COBA_DATA_INIVI", out var V0COBA_DATA_INIVI) && V0COBA_DATA_INIVI == "9999-99-99");
                Assert.True(envList7[1].TryGetValue("V0COBA_DATA_TERVI", out var V0COBA_DATA_TERVI) && V0COBA_DATA_TERVI == "2000-01-01");
                Assert.True(envList7[1].TryGetValue("V0COBA_COD_EMPRESA", out var V0COBA_COD_EMPRESA) && V0COBA_COD_EMPRESA == "000000000");
                Assert.True(envList7[1].TryGetValue("V0COBA_SITUACAO", out var V0COBA_SITUACAO) && V0COBA_SITUACAO == "0");


                #endregion

                #region R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1

                var envList9 = AppSettings.TestSet.DynamicData["R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList9?.Count > 0);

                Assert.True(envList9[1].TryGetValue("V0APCR_NUM_APOL", out var V0APCR_NUM_APOL) && V0APCR_NUM_APOL == "0108100000002");
                Assert.True(envList9[1].TryGetValue("V0APCR_RAMOFR", out var V0APCR_RAMOFR) && V0APCR_RAMOFR == "0081");
                Assert.True(envList9[1].TryGetValue("V0APCR_MODALIFR", out var V0APCR_MODALIFR) && V0APCR_MODALIFR == "0000");
                Assert.True(envList9[1].TryGetValue("V0APCR_CODCORR", out var V0APCR_CODCORR) && V0APCR_CODCORR == "000100081");
                Assert.True(envList9[1].TryGetValue("V0APCR_CODSUBES", out var V0APCR_CODSUBES) && V0APCR_CODSUBES == "0000");
                Assert.True(envList9[1].TryGetValue("V0APCR_DTINIVIG", out var V0APCR_DTINIVIG) && V0APCR_DTINIVIG == "9999-99-99");
                Assert.True(envList9[1].TryGetValue("V0APCR_DTTERVIG", out var V0APCR_DTTERVIG) && V0APCR_DTTERVIG == "2000-01-01");
                Assert.True(envList9[1].TryGetValue("V0APCR_PCPARCOR", out var V0APCR_PCPARCOR) && V0APCR_PCPARCOR == "100.00");
                Assert.True(envList9[1].TryGetValue("V0APCR_PCCOMCOR", out var V0APCR_PCCOMCOR) && V0APCR_PCCOMCOR == "010.00");
                Assert.True(envList9[1].TryGetValue("V0APCR_TIPCOM", out var V0APCR_TIPCOM) && V0APCR_TIPCOM == "2");
                Assert.True(envList9[1].TryGetValue("V0APCR_INDCRT", out var V0APCR_INDCRT) && V0APCR_INDCRT == "1");
                Assert.True(envList9[1].TryGetValue("V0APCR_COD_EMPRESA", out var V0APCR_COD_EMPRESA) && V0APCR_COD_EMPRESA == "000000000");
                Assert.True(envList9[1].TryGetValue("V0APCR_COD_USUARIO", out var V0APCR_COD_USUARIO) && V0APCR_COD_USUARIO == "BI8005B ");



                #endregion

                #region R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1

                var envList10 = AppSettings.TestSet.DynamicData["R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList10?.Count > 0);

                Assert.True(envList10[1].TryGetValue("V0APCC_NUM_APOL", out var V0APCC_NUM_APOL) && V0APCC_NUM_APOL == "0108100000002");
                Assert.True(envList10[1].TryGetValue("V0APCC_CODCOSS", out var V0APCC_CODCOSS) && V0APCC_CODCOSS == "0003");
                Assert.True(envList10[1].TryGetValue("V0APCC_RAMOFR", out var V0APCC_RAMOFR) && V0APCC_RAMOFR == "0081");
                Assert.True(envList10[1].TryGetValue("V0APCC_DTINIVIG", out var V0APCC_DTINIVIG) && V0APCC_DTINIVIG == "9999-99-99");
                Assert.True(envList10[1].TryGetValue("V0APCC_DTTERVIG", out var V0APCC_DTTERVIG) && V0APCC_DTTERVIG == "2000-01-01");
                Assert.True(envList10[1].TryGetValue("V0APCC_PCPARTIC", out var V0APCC_PCPARTIC) && V0APCC_PCPARTIC == "0004.00000");
                Assert.True(envList10[1].TryGetValue("V0APCC_PCCOMCOS", out var V0APCC_PCCOMCOS) && V0APCC_PCCOMCOS == "005.00");
                Assert.True(envList10[1].TryGetValue("V0APCC_COD_EMPRESA", out var V0APCC_COD_EMPRESA) && V0APCC_COD_EMPRESA == "000000000");


                #endregion

                #region R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1

                var envList11 = AppSettings.TestSet.DynamicData["R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList11?.Count > 0);

                Assert.True(envList11[1].TryGetValue("V0ORDC_NUM_APOL", out var V0ORDC_NUM_APOL) && V0ORDC_NUM_APOL == "0108100000002");
                Assert.True(envList11[1].TryGetValue("V0ORDC_NRENDOS", out var V0ORDC_NRENDOS) && V0ORDC_NRENDOS == "000000000");
                Assert.True(envList11[1].TryGetValue("V0ORDC_CODCOSS", out var V0ORDC_CODCOSS) && V0ORDC_CODCOSS == "0003");
                Assert.True(envList11[1].TryGetValue("V0ORDC_ORDEM_CED", out var V0ORDC_ORDEM_CED) && V0ORDC_ORDEM_CED == "000030100000124");
                Assert.True(envList11[1].TryGetValue("V0ORDC_COD_EMPRESA", out var V0ORDC_COD_EMPRESA) && V0ORDC_COD_EMPRESA == "000000000");


                #endregion

                #region R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1

                var envList12 = AppSettings.TestSet.DynamicData["R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList12?.Count > 0);

                Assert.True(envList12[1].TryGetValue("V1NCOS_NRORDEM", out var V1NCOS_NRORDEM) && V1NCOS_NRORDEM == "000000124");
                Assert.True(envList12[1].TryGetValue("V1NCOS_CONGENER", out var V1NCOS_CONGENER) && V1NCOS_CONGENER == "0003");
                Assert.True(envList12[1].TryGetValue("V1NCOS_ORGAO", out var V1NCOS_ORGAO) && V1NCOS_ORGAO == "0010");


                #endregion

                #region R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

                var envList13 = AppSettings.TestSet.DynamicData["R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList13?.Count > 0);

                Assert.True(envList13[1].TryGetValue("V0APOL_QTCOSSEG", out var V0APOL_QTCOSSEG13) && V0APOL_QTCOSSEG13 == "0001");
                Assert.True(envList13[1].TryGetValue("V0APOL_PCTCED", out var V0APOL_PCTCED13) && V0APOL_PCTCED13 == "0004.00000");
                Assert.True(envList13[1].TryGetValue("V0APOL_NUM_APOL", out var V0APOL_NUM_APOL13) && V0APOL_NUM_APOL13 == "0108100000002");


                #endregion

                #region R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1

                var envList16 = AppSettings.TestSet.DynamicData["R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList16?.Count > 0);

                Assert.True(envList16[1].TryGetValue("GELMR_QTD_SEGUROS", out var GELMR_QTD_SEGUROS) && GELMR_QTD_SEGUROS == "0002");
                Assert.True(envList16[1].TryGetValue("GELMR_VLR_SOMA_IS", out var GELMR_VLR_SOMA_IS) && GELMR_VLR_SOMA_IS == "0000000000101.00");
                Assert.True(envList16[1].TryGetValue("V0CLIE_CGCCPF", out var V0CLIE_CGCCPF) && V0CLIE_CGCCPF == "000000000123456");

                #endregion

                #region R3170_00_UPDATE_BILHETE_DB_UPDATE_1_Update1

                var envList19 = AppSettings.TestSet.DynamicData["R3170_00_UPDATE_BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList19?.Count > 0);

                Assert.True(envList19[1].TryGetValue("V1FONT_PROPAUTOM", out var V1FONT_PROPAUTOM) && V1FONT_PROPAUTOM == "000000125");
                Assert.True(envList19[1].TryGetValue("V0BILH_FONTE", out var V0BILH_FONTE) && V0BILH_FONTE == "0003");



                #endregion

                #region R3210_00_ALTERA_RCAPS_DB_UPDATE_1_Update1

                var envList23 = AppSettings.TestSet.DynamicData["R3210_00_ALTERA_RCAPS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList23?.Count > 1);

                Assert.True(envList23[1].TryGetValue("V0PARC_NUM_APOL", out var V0PARC_NUM_APOL20) && V0PARC_NUM_APOL20 == "0108100000002");
                Assert.True(envList23[1].TryGetValue("V0PARC_NRPARCEL", out var V0PARC_NRPARCEL20) && V0PARC_NRPARCEL20 == "0000");
                Assert.True(envList23[1].TryGetValue("V0PARC_NRENDOS", out var V0PARC_NRENDOS20) && V0PARC_NRENDOS20 == "000000000");
                Assert.True(envList23[1].TryGetValue("V0RCAP_NRRCAP", out var V0RCAP_NRRCAP20) && V0RCAP_NRRCAP20 == "000001462");
                Assert.True(envList23[1].TryGetValue("V0RCAP_FONTE", out var V0RCAP_FONTE20) && V0RCAP_FONTE20 == "0020");


                #endregion

                #region R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1


                var envList24 = AppSettings.TestSet.DynamicData["R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList24?.Count > 1);

                Assert.True(envList24[1].TryGetValue("V0CROT_DTMOVABE", out var V0CROT_DTMOVABE) && V0CROT_DTMOVABE == "2026-01-01");
                Assert.True(envList24[1].TryGetValue("V0CROT_BILH_AP", out var V0CROT_BILH_AP) && V0CROT_BILH_AP == "S");
                Assert.True(envList24[1].TryGetValue("V0BILH_CGCCPF", out var V0BILH_CGCCPF) && V0BILH_CGCCPF == "000000000123456");


                #endregion

                #region R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1


                var envList27 = AppSettings.TestSet.DynamicData["R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList27?.Count > 0);

                Assert.True(envList27[0].TryGetValue("V0BILH_NUMBIL", out var V0BILH_NUMBIL27) && V0BILH_NUMBIL27 == "");
                Assert.True(envList27[0].TryGetValue("V1SIST_DTMOVABE", out var V1SIST_DTMOVABE) && V1SIST_DTMOVABE == "");

                #endregion

              
                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void BI8005B_Tests99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

             
                //************************************************
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2026-01-01"},
                { "V1SIST_DTCURRENT" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2026-01-01"},
                { "V1SIST_TIMESTAMP" , "2000-01-01 09:00:00"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

                #endregion

                #region BI8005B_CCBO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "0"},
                { "CBO_DESCR_CBO" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI8005B_CCBO");
                AppSettings.TestSet.DynamicData.Add("BI8005B_CCBO", q2);

                #endregion

                #region BI8005B_V0BILHETE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "1"},
                { "V0BILH_NUMAPOL" , "0"},
                { "V0BILH_FONTE" , "3"},
                { "V0BILH_AGECOBR" , "4"},
                { "V0BILH_NUM_MATR" , "5"},
                { "V0BILH_AGENCIA" , "6"},
                { "V0BILH_CODCLIEN" , "7"},
                { "V0BILH_PROFISSAO" , "8"},
                { "V0BILH_AGENCIA_DEB" , "9"},
                { "V0BILH_OPERACAO_DEB" , "10"},
                { "V0BILH_NUMCTA_DEB" , "11"},
                { "V0BILH_DIGCTA_DEB" , "12"},
                { "V0BILH_OPCAO_COBER" , "13"},
                { "V0BILH_DTQITBCO" , "2020-01-01"},
                { "V0BILH_DTVENCTO" , "2020-01-01"},
                { "V0BILH_VLRCAP" , "0"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "1"},
                { "V0BILH_SITUACAO" , "100"},
                { "V0BILH_NUM_APO_ANT" , "100"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI8005B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI8005B_V0BILHETE", q3);

                #endregion

                #region BI8005B_V1COSSEGPROD

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CODPRODU" , "1"},
                { "V1COSP_RAMO" , "2"},
                { "V1COSP_CONGENER" , "3"},
                { "V1COSP_PCPARTIC" , "4"},
                { "V1COSP_PCCOMCOS" , "5"},
                { "V1COSP_PCADMCOS" , "6"},
                { "V1COSP_DTINIVIG" , "1"},
                { "V1COSP_DTTERVIG" , "20"},
                { "V1COSP_SITUACAO" , "9"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI8005B_V1COSSEGPROD");
                AppSettings.TestSet.DynamicData.Add("BI8005B_V1COSSEGPROD", q4);

                #endregion

                #region R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_COD_EMPRESA_CAP" , "1"},
                { "PRODUTO_COD_EMPRESA" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_SICOB" , "1"},
                { "V0SIVPF_SIT_PROPOSTA" , "2"},
                { "V0CONV_NUM_PROPOSTA_SIVPF" , "3"},
                { "PRPFIDEL_COD_PROD_SIVPF" , "4"},
                { "PRPFIDEL_ORIG_PROPOSTA" , "5"},
                { "PRPFIDEL_QTD_MESES" , "6"},
                { "PRPFIDEL_PERIPGTO" , "7"},
                { "PRPFIDEL_OPCAO_COBER" , "8"},
                { "PRPFIDEL_DIA_DEBITO" , "9"},
                { "PRPFIDEL_NUM_IDENTIFICA" , "10"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "PRPFIDCO_INFORM_COMPLEM" , "X"}
               });
                AppSettings.TestSet.DynamicData.Remove("R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_PROPOSTA_SIVPF" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_CGCCPF" , "123456"},
                { "V0CLIE_DTNASC" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "GELMR_QTD_SEGUROS" , "1"},
                { "GELMR_VLR_SOMA_IS" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1", q12);
                #endregion

                #region R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1", q13);

                #endregion

                #region R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , "2000-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , "2000-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1", q15);

                #endregion

                #region R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "12465"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1", q16);

                #endregion

                #region R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "1"},
                { "V1BILC_PRMTAR_IX" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1", q17);

                #endregion

                #region R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "1462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "4"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1", q19);

                #endregion

                #region R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , "0"},
                { "V0BILFX_VALADT" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1", q20);
                #endregion

                #region R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1", q21);

                #endregion

                #region R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_CODUNIMO" , "1"},
                { "V1BILC_PCCOMCOR" , "2"},
                { "V1BILC_PCIOCC" , "3"},
                { "V1BILC_VALMAX" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1", q23);

                #endregion

                #region R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1", q26);

                #endregion

                #region R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2000-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1", q32);

                #endregion

                #region R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , "100"},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1", q33);

                #endregion

                #region R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , "100"},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1", q34);

                #endregion

                #region R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , "100"},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1", q36);

                #endregion

                #region BI8005B_V1RCAPCOMP

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "1"},
                { "V1RCAC_NRRCAP" , "12"},
                { "V1RCAC_NRRCAPCO" , "123"},
                { "V1RCAC_OPERACAO" , "123"},
                { "V1RCAC_DTMOVTO" , "2000-01-01"},
                { "V1RCAC_HORAOPER" , "12"},
                { "V1RCAC_SITUACAO" , "0"},
                { "V1RCAC_BCOAVISO" , "1"},
                { "V1RCAC_AGEAVISO" , "2"},
                { "V1RCAC_NRAVISO" , "3"},
                { "V1RCAC_VLRCAP" , "100"},
                { "V1RCAC_DATARCAP" , "2000-01-01"},
                { "V1RCAC_DTCADAST" , "2020-01-01"},
                { "V1RCAC_SITCONTB" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI8005B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("BI8005B_V1RCAPCOMP", q37);

                #endregion

                #region R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1", q39);

                #endregion

                #region R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "1"},
                { "V1RCAC_AGEAVISO" , "2"},
                { "V1RCAC_NRAVISO" , "3"},
                { "V1RCAC_DATARCAP" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1", q47);

                #endregion

                #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q49);

                #endregion

                #region R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1", q50);

                #endregion

                #region R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1", q52);

                #endregion

                #region R3210_20_CROT_DB_SELECT_1_Query1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_CGCCPF" , "123456"},
                { "V0BILH_NOME" , "X"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3210_20_CROT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_20_CROT_DB_SELECT_1_Query1", q57);

                #endregion

                #region R3210_20_CROT_DB_SELECT_2_Query1

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "V1CROT_CGCCPF" , "123"},
                { "V1CROT_BILH_AP" , "1"},
                { "V1CROT_BILH_RES" , "1"},
                { "V1CROT_BILH_VDAZUL" , "1"},
                { "V1CROT_DTMOVABE" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3210_20_CROT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_20_CROT_DB_SELECT_2_Query1", q58);

                #endregion

                #endregion
                var program = new BI8005B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}