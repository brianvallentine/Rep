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
using Code;
using static Code.VA6005B;

namespace FileTests.Test
{
    [Collection("VA6005B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA6005B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA6005B_V0BILHETE

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
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
                { "V0BILH_DTA_VENDA" , ""},
                { "V0BILH_DTQITBCO" , ""},
                { "V0BILH_VLRCAP" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0BILH_CODUSU" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUM_APO_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA6005B_V0BILHETE", q2);

            #endregion

            #region VA6005B_V1COSSEGPROD

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VA6005B_V1COSSEGPROD", q3);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1000_00_LEITURA_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_SIVPF" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_LEITURA_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_SICOB" , ""},
                { "V0SIVPF_SIT_PROPOSTA" , ""},
                { "V0CONV_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q6);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_SEQ_APOL" , ""},
                { "WH_JV1_COD_ORGAO" , ""},
                { "WWORK_RAMO_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , ""},
                { "V1BILC_PRMTAR_IX" , ""},
                { "V1BILC_VALMAX" , ""},
                { "V1BILC_PRMTOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q9);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1", q11);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_CODUNIMO" , ""},
                { "V1BILC_PCCOMCOR" , ""},
                { "V1BILC_PCIOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q12);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1", q13);

            #endregion

            #region R1050_00_TRATA_FUNDAO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_TRATA_FUNDAO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_4_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_4_Insert1", q16);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1NOUT_NUMOPG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1", q17);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q18);

            #endregion

            #region R1050_20_TRATA_FENAE_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_20_TRATA_FENAE_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1050_20_TRATA_FENAE_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1050_20_TRATA_FENAE_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0PROE_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1", q21);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_5_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0ADIA_CODPDT" , ""},
                { "V0ADIA_FONTE" , ""},
                { "V0ADIA_NUMOPG" , ""},
                { "V0ADIA_VALADT" , ""},
                { "V0ADIA_QTPRESTA" , ""},
                { "V0ADIA_NRPROPOS" , ""},
                { "V0ADIA_NUM_APOL" , ""},
                { "V0ADIA_NRENDOS" , ""},
                { "V0ADIA_NRPARCEL" , ""},
                { "V0ADIA_DTMOVTO" , ""},
                { "V0ADIA_SITUACAO" , ""},
                { "V0ADIA_COD_EMP" , ""},
                { "V0ADIA_TIPO_ADT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_5_Insert1", q22);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0FORM_CODPDT" , ""},
                { "V0FORM_FONTE" , ""},
                { "V0FORM_NUMOPG" , ""},
                { "V0FORM_NRPROPOS" , ""},
                { "V0FORM_NUM_APOL" , ""},
                { "V0FORM_NRENDOS" , ""},
                { "V0FORM_NRPARCEL" , ""},
                { "V0FORM_NUMPTC" , ""},
                { "V0FORM_VALRCP" , ""},
                { "V0FORM_PCGACM" , ""},
                { "V0FORM_SITUACAO" , ""},
                { "V0FORM_VALSDO" , ""},
                { "V0FORM_DTMOVTO" , ""},
                { "V0FORM_DTVENCTO" , ""},
                { "V0FORM_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1", q23);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NUMOPG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1", q24);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_7_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0HISR_CODPDT" , ""},
                { "V0HISR_FONTE" , ""},
                { "V0HISR_NUMOPG" , ""},
                { "V0HISR_NRPROPOS" , ""},
                { "V0HISR_NUM_APOL" , ""},
                { "V0HISR_NRENDOS" , ""},
                { "V0HISR_NRPARCEL" , ""},
                { "V0HISR_NUMPTC" , ""},
                { "V0HISR_VALRCP" , ""},
                { "V0HISR_NUMREC" , ""},
                { "V0HISR_DTMOVTO" , ""},
                { "V0HISR_OPERACAO" , ""},
                { "V0HISR_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_7_Insert1", q25);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V1NOUT_NUMOPG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1", q26);

            #endregion

            #region R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , ""},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1", q27);

            #endregion

            #region R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_VALOR_COMISSAO_PRD" , ""},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1", q28);

            #endregion

            #region R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1", q29);

            #endregion

            #region VA6005B_V1RCAPCOMP

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VA6005B_V1RCAPCOMP", q30);

            #endregion

            #region R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0APCC_NUM_APOL" , ""},
                { "V0APCC_CODCOSS" , ""},
                { "V0APCC_RAMOFR" , ""},
                { "V0APCC_DTINIVIG" , ""},
                { "V0APCC_DTTERVIG" , ""},
                { "V0APCC_PCPARTIC" , ""},
                { "V0APCC_PCCOMCOS" , ""},
                { "V0APCC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1", q31);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1", q32);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , ""},
                { "V0ORDC_NRENDOS" , ""},
                { "V0ORDC_CODCOSS" , ""},
                { "V0ORDC_ORDEM_CED" , ""},
                { "V0ORDC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1", q33);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""},
                { "V1NCOS_CONGENER" , ""},
                { "V1NCOS_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_QTCOSSEG" , ""},
                { "V0APOL_PCTCED" , ""},
                { "V0APOL_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1", q35);

            #endregion

            #region R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "PRPFIDEL_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1", q37);

            #endregion

            #region R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_FISICA_COD_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1", q38);

            #endregion

            #region R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V2RCAP_VLRCAP" , ""},
                { "V0RCAP_SITUACAO" , ""},
                { "V0RCAP_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1", q39);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V1COFE_AGECOBR" , ""},
                { "V1COFE_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_1_Query1", q40);

            #endregion

            #region R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1", q41);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_2_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V1ACEF_CODESCNEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_2_Query1", q42);

            #endregion

            #region R3000_90_CONTINUA_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_90_CONTINUA_DB_SELECT_1_Query1", q43);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_3_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V1MCEF_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_3_Query1", q44);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_1_Query1", q45);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""},
                { "V0BILH_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1", q46);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_4_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , ""},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_4_Query1", q47);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1", q48);

            #endregion

            #region R3000_10_CONTINUA_DB_UPDATE_1_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_COD_ANGAR" , ""},
                { "V1FUNC_NUM_MATRIC" , ""},
                { "V1FUNC_NUM_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_UPDATE_1_Update1", q49);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V0COFE_OPERACAO_DEB" , ""},
                { "V0COFE_AGENCIA_DEB" , ""},
                { "V0COFE_NUMCTA_DEB" , ""},
                { "V0COFE_DIGCTA_DEB" , ""},
                { "V0COFE_NOME_SIND" , ""},
                { "V0COFE_NUM_MATR" , ""},
                { "V0COFE_SITUACAO" , ""},
                { "V0COFE_AGECOBR" , ""},
                { "V0COFE_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1", q50);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_CGCCPF" , ""},
                { "V0BILH_NOME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1", q51);

            #endregion

            #region R3000_10_CONTINUA_DB_INSERT_1_Insert1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V1MCEF_COD_FONTE" , ""},
                { "V1FUNC_COD_ANGAR" , ""},
                { "V1FUNC_NOME_FUN" , ""},
                { "V1FUNC_NUM_MATRIC" , ""},
                { "V1PROD_ENDERECO" , ""},
                { "V1PROD_CIDADE" , ""},
                { "V1FUNC_SIGLA_UF" , ""},
                { "V1FUNC_CEP" , ""},
                { "V1FUNC_NUM_CPF" , ""},
                { "V1SURG_PCDESISS" , ""},
                { "V0BILH_AGENCIA" , ""},
                { "V1SIST_DTMOVACB" , ""},
                { "WHOST_NUMREC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_INSERT_1_Insert1", q52);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "V1CROT_CGCCPF" , ""},
                { "V1CROT_BILH_AP" , ""},
                { "V1CROT_BILH_RES" , ""},
                { "V1CROT_BILH_VDAZUL" , ""},
                { "V1CROT_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1", q53);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1", q54);

            #endregion

            #region R3000_10_CONTINUA_DB_UPDATE_2_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "V1NOUT_CODANGAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_UPDATE_2_Update1", q55);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_5_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_NUM_MATRIC" , ""},
                { "V1FUNC_NOME_FUN" , ""},
                { "V1FUNC_ENDERECO" , ""},
                { "V1FUNC_CIDADE" , ""},
                { "V1FUNC_SIGLA_UF" , ""},
                { "V1FUNC_CEP" , ""},
                { "V1FUNC_NUM_CPF" , ""},
                { "V1FUNC_COD_ANGAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_5_Query1", q56);

            #endregion

            #region R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q57);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_6_Query1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "V1NOUT_CODANGAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_6_Query1", q58);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_7_Query1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "V1SURG_PCDESISS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_7_Query1", q59);

            #endregion

            #region R3045_00_INSERE_ERRO_DB_INSERT_1_Insert1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V0BILER_COD_ERRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3045_00_INSERE_ERRO_DB_INSERT_1_Insert1", q60);

            #endregion

            #region R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q61);

            #endregion

            #region R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "V1MCEF_COD_FONTE" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q62);

            #endregion

            #region R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "V1COFE_AGECOBR" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q63);

            #endregion

            #region R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "V0C396_NUMBIL" , ""},
                { "V0C396_DTMOVTO" , ""},
                { "V0C396_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1", q64);

            #endregion

            #region VA6005B_CCBO

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA6005B_CCBO", q65);

            #endregion

            #region R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q66);

            #endregion

            #region R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q67);

            #endregion

            #region R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q68);

            #endregion

            #region R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "V0CROT_DTMOVABE" , ""},
                { "V0CROT_BILH_AP" , ""},
                { "V0BILH_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1", q69);

            #endregion

            #region R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "V0CROT_BILH_RES" , ""},
                { "V0CROT_DTMOVABE" , ""},
                { "V0BILH_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1", q70);

            #endregion

            #region R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "V0CROT_CGCCPF" , ""},
                { "V0CROT_BILH_AP" , ""},
                { "V0CROT_BILH_RES" , ""},
                { "V0CROT_BILH_VDAZUL" , ""},
                { "V0CROT_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1", q71);

            #endregion

            #region R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1", q72);

            #endregion

            #region R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                { "V0ENDO_COD_PRODU_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1", q73);

            #endregion

            #region R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q74);

            #endregion

            #region R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1", q75);

            #endregion

            #region R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1", q76);

            #endregion

            #region R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

            var q77 = new DynamicData();
            q77.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , ""},
                { "PARM_COD_EMPR_CAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q77);

            #endregion

            #region R8000_JV1_BUSCA_EMPRESA_DB_SELECT_1_Query1

            var q78 = new DynamicData();
            q78.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "PRODUTO_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_JV1_BUSCA_EMPRESA_DB_SELECT_1_Query1", q78);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA6005B_Tests_Fact()
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
                #endregion
                var program = new VA6005B();
                program.Execute();

                Assert.True(true);
            }
        }
    }
}