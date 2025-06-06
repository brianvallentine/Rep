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
using static Code.BI6005B;

namespace FileTests.Test
{
    [Collection("BI6005B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI6005B_Tests
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

            #region BI6005B_V0BILHETE

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
                { "V0BILH_DTQITBCO" , ""},
                { "V0BILH_VLRCAP" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0BILH_CODUSU" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUM_APO_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6005B_V0BILHETE", q2);

            #endregion

            #region BI6005B_V1COSSEGPROD

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
            AppSettings.TestSet.DynamicData.Add("BI6005B_V1COSSEGPROD", q3);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1000_10_ANTIGA_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_10_ANTIGA_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q6);

            #endregion

            #region R1000_15_NOVA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_15_NOVA_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_SICOB" , ""},
                { "V0SIVPF_SIT_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

            #endregion

            #region R1000_15_NOVA_DB_INSERT_2_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_15_NOVA_DB_INSERT_2_Insert1", q9);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_SEQ_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R1000_15_FIM_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_15_FIM_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q12);

            #endregion

            #region R1000_15_FIM_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NUMOPG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_15_FIM_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1000_15_FIM_DB_INSERT_2_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_15_FIM_DB_INSERT_2_Insert1", q14);

            #endregion

            #region R1000_15_FIM_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1NOUT_NUMOPG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_15_FIM_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R1000_15_FIM_DB_SELECT_2_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1NOUT_NUMOPG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_15_FIM_DB_SELECT_2_Query1", q16);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R1000_15_FIM_DB_INSERT_3_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_15_FIM_DB_INSERT_3_Insert1", q18);

            #endregion

            #region R1000_00_LEITURA_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_SIVPF" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_LEITURA_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R1000_15_FIM_DB_INSERT_4_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_15_FIM_DB_INSERT_4_Insert1", q20);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1", q21);

            #endregion

            #region R1000_15_FIM_DB_INSERT_5_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_15_FIM_DB_INSERT_5_Insert1", q22);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , ""},
                { "V1BILC_PRMTAR_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q23);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_CODUNIMO" , ""},
                { "V1BILC_PCCOMCOR" , ""},
                { "V1BILC_PCIOCC" , ""},
                { "V1BILC_VALMAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q24);

            #endregion

            #region R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0PROE_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1", q26);

            #endregion

            #region R1050_00_TRATA_FUNDAO_DB_INSERT_2_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1050_00_TRATA_FUNDAO_DB_INSERT_2_Insert1", q27);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0COFE_VALADT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1", q28);

            #endregion

            #region BI6005B_V1RCAPCOMP

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("BI6005B_V1RCAPCOMP", q29);

            #endregion

            #region R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0APCC_NUM_APOL" , ""},
                { "V0APCC_CODCOSS" , ""},
                { "V0APCC_RAMOFR" , ""},
                { "V0APCC_DTINIVIG" , ""},
                { "V0APCC_DTTERVIG" , ""},
                { "V0APCC_PCPARTIC" , ""},
                { "V0APCC_PCCOMCOS" , ""},
                { "V0APCC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1", q30);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1", q31);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , ""},
                { "V0ORDC_NRENDOS" , ""},
                { "V0ORDC_CODCOSS" , ""},
                { "V0ORDC_ORDEM_CED" , ""},
                { "V0ORDC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""},
                { "V1NCOS_CONGENER" , ""},
                { "V1NCOS_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1", q33);

            #endregion

            #region R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_QTCOSSEG" , ""},
                { "V0APOL_PCTCED" , ""},
                { "V0APOL_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q35);

            #endregion

            #region R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "PRPFIDEL_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1", q36);

            #endregion

            #region R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_FISICA_COD_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1", q37);

            #endregion

            #region R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V2RCAP_VLRCAP" , ""},
                { "V0RCAP_SITUACAO" , ""},
                { "V0RCAP_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1", q38);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V1COFE_AGECOBR" , ""},
                { "V1COFE_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_1_Query1", q39);

            #endregion

            #region R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1", q40);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_2_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V1ACEF_CODESCNEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_2_Query1", q41);

            #endregion

            #region R3000_90_CONTINUA_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_90_CONTINUA_DB_SELECT_1_Query1", q42);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_3_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V1MCEF_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_3_Query1", q43);

            #endregion

            #region R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , ""},
                { "V0BILFX_VALADT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1", q44);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_4_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , ""},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_4_Query1", q45);

            #endregion

            #region R3000_10_CONTINUA_DB_UPDATE_1_Update1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_COD_ANGAR" , ""},
                { "V1FUNC_NUM_MATRIC" , ""},
                { "V1FUNC_NUM_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_UPDATE_1_Update1", q46);

            #endregion

            #region R3000_10_CONTINUA_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_INSERT_1_Insert1", q47);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_1_Query1", q48);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""},
                { "V0BILH_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1", q49);

            #endregion

            #region R3000_10_CONTINUA_DB_UPDATE_2_Update1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V1NOUT_CODANGAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_UPDATE_2_Update1", q50);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1", q51);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_5_Query1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_NUM_MATRIC" , ""},
                { "V1FUNC_NOME_FUN" , ""},
                { "V1FUNC_ENDERECO" , ""},
                { "V1FUNC_CIDADE" , ""},
                { "V1FUNC_SIGLA_UF" , ""},
                { "V1FUNC_CEP" , ""},
                { "V1FUNC_NUM_CPF" , ""},
                { "V1FUNC_COD_ANGAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_5_Query1", q52);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1", q53);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_CGCCPF" , ""},
                { "V0BILH_NOME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1", q54);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "V1CROT_CGCCPF" , ""},
                { "V1CROT_BILH_AP" , ""},
                { "V1CROT_BILH_RES" , ""},
                { "V1CROT_BILH_VDAZUL" , ""},
                { "V1CROT_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1", q55);

            #endregion

            #region R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1", q56);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_6_Query1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "V1NOUT_CODANGAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_6_Query1", q57);

            #endregion

            #region R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q58);

            #endregion

            #region R3000_10_CONTINUA_DB_SELECT_7_Query1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "V1SURG_PCDESISS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_7_Query1", q59);

            #endregion

            #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q60);

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

            #region BI6005B_CCBO

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6005B_CCBO", q65);

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
            });
            AppSettings.TestSet.DynamicData.Add("R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1", q73);

            #endregion

            #region R3290_10_INSERT_DB_INSERT_1_Insert1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V0BILH_FONTE" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V1BILC_VALMAX" , ""},
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "V1BILP_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3290_10_INSERT_DB_INSERT_1_Insert1", q74);

            #endregion

            #region R3300_00_INSERT_DB_INSERT_1_Insert1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "V0BILH_NUMBIL" , ""},
                { "TITFEDCA_DATA_INIVIGENCIA" , ""},
                { "TITFEDCA_DATA_TERVIGENCIA" , ""},
                { "TITFEDCA_NRSORTEIO" , ""},
                { "V1BILC_VALMAX" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_INSERT_DB_INSERT_1_Insert1", q75);

            #endregion

            #region R3400_10_INSERT_DB_INSERT_1_Insert1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_10_INSERT_DB_INSERT_1_Insert1", q76);

            #endregion

            #region R3500_10_INSERT_DB_INSERT_1_Insert1

            var q77 = new DynamicData();
            q77.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "V1BILC_VALMAX" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_10_INSERT_DB_INSERT_1_Insert1", q77);

            #endregion

            #region R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1

            var q78 = new DynamicData();
            q78.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1", q78);

            #endregion

            #region R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

            var q79 = new DynamicData();
            q79.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , ""},
                { "PARM_COD_EMPR_CAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q79);

            #endregion

            #region BI6005B_FCAP

            var q80 = new DynamicData();
            q80.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V1BILC_VALMAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6005B_FCAP", q80);

            #endregion

            #region R9130_00_SELECT_TITULO_DB_SELECT_1_Query1

            var q81 = new DynamicData();
            q81.AddDynamic(new Dictionary<string, string>{
                { "FCTITULO_NUM_PLANO" , ""},
                { "FCTITULO_NUM_SERIE" , ""},
                { "FCTITULO_NUM_TITULO" , ""},
                { "FCTITULO_IND_DV" , ""},
                { "FCTITULO_DTH_INI_VIGENCIA" , ""},
                { "FCTITULO_DTH_FIM_VIGENCIA" , ""},
                { "FCCOMTIT_DES_COMBINACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9130_00_SELECT_TITULO_DB_SELECT_1_Query1", q81);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI6005B_Tests_Fact_1_ReturnCode_0()
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

                #region BI6005B_CCBO

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "3"},
                { "CBO_DESCR_CBO" , "COMERCIANTE"},
                });
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "8"},
                { "CBO_DESCR_CBO" , "NUTRICIONISTA"},
                }); AppSettings.TestSet.DynamicData.Remove("BI6005B_CCBO");
                AppSettings.TestSet.DynamicData.Add("BI6005B_CCBO", q65);

                #endregion
                #region BI6005B_V0BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458482"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "21"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "60.00"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "0"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458483"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "21"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "60.00"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V0BILHETE", q2);

                #endregion
                #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q60);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q23 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q23);

                #endregion
                #endregion
                var program = new BI6005B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R1000_00_LEITURA_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R1000_00_LEITURA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("WHOST_SIT_PROP_SIVPF", out var valor0) && valor0.Contains("PEN"));

                //R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0BILH_NUMBIL", out var valor1) && valor1.Contains("000084682458482"));
            }
        }
        [Fact]
        public static void BI6005B_Tests_Fact_Error_ReturnCode_99()
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

                #region BI6005B_CCBO

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_CCBO");
                AppSettings.TestSet.DynamicData.Add("BI6005B_CCBO", q65);

                #endregion

                #endregion
                var program = new BI6005B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Fact]
        public static void BI6005B_Tests_Fact_2_CritPropError_ReturnCode_0()
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

                #region BI6005B_CCBO

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "3"},
                { "CBO_DESCR_CBO" , "COMERCIANTE"},
                });
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "8"},
                { "CBO_DESCR_CBO" , "NUTRICIONISTA"},
                }); AppSettings.TestSet.DynamicData.Remove("BI6005B_CCBO");
                AppSettings.TestSet.DynamicData.Add("BI6005B_CCBO", q65);

                #endregion
                #region BI6005B_V0BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458482"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "21"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "60.00"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "0"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458483"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "21"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "60.00"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V0BILHETE", q2);

                #endregion
                #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q60);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q23 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q23);

                #endregion
                #endregion
                var program = new BI6005B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("V0BILH_NUMBIL", out var valor) && valor.Contains("000084682458482"));
            }
        }
        [Fact]
        public static void BI6005B_Tests_Fact_3_ReturnCode_0()
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

                #region BI6005B_CCBO

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "3"},
                { "CBO_DESCR_CBO" , "COMERCIANTE"},
                });
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "8"},
                { "CBO_DESCR_CBO" , "NUTRICIONISTA"},
                }); AppSettings.TestSet.DynamicData.Remove("BI6005B_CCBO");
                AppSettings.TestSet.DynamicData.Add("BI6005B_CCBO", q65);

                #endregion
                #region BI6005B_V0BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458482"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "1"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "1"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "12"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458483"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "21"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "6"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V0BILHETE", q2);

                #endregion
                #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q60);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "72850900.00"},
                { "V1BILC_PRMTAR_IX" , "130703.08000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q23);

                #endregion

                #region R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "-378631462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1", q38);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q8 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q12 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q12);

                #endregion
                #region R3000_10_CONTINUA_DB_SELECT_4_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , "B"},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_10_CONTINUA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_4_Query1", q45);

                #endregion
                #region R3000_10_CONTINUA_DB_SELECT_5_Query1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_NUM_MATRIC" , "109429"},
                { "V1FUNC_NOME_FUN" , "ABEL MAURICIO RODRIGUES                 "},
                { "V1FUNC_ENDERECO" , "RUA OLAVO BILAC,784                              "},
                { "V1FUNC_CIDADE" , "ASSIS                 "},
                { "V1FUNC_SIGLA_UF" , "SP"},
                { "V1FUNC_CEP" , "19802020"},
                { "V1FUNC_NUM_CPF" , "77906608887"},
                { "V1FUNC_COD_ANGAR" , "318108"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_10_CONTINUA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_5_Query1", q52);

                #endregion
                #region R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1

                //REMOVER QUERY PARA SUBSTIUIR UPDATES PELO INSERT
                //var q55 = new DynamicData();
                //AppSettings.TestSet.DynamicData.Remove("R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1");
                //AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1", q55);

                #endregion

                #region R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1

                var q72 = new DynamicData();
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1", q72);

                #endregion

                #region R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1", q73);

                #endregion
                #region BI6005B_V1RCAPCOMP

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , "20"},
                { "V1RCAC_NRRCAPCO" , "-378631462"},
                { "V1RCAC_OPERACAO" , "0"},
                { "V1RCAC_DTMOVTO" , "110"},
                { "V1RCAC_HORAOPER" , "22:33:33"},
                { "V1RCAC_SITUACAO" , "0"},
                { "V1RCAC_BCOAVISO" , "104"},
                { "V1RCAC_AGEAVISO" , "7996"},
                { "V1RCAC_NRAVISO" , "899604577"},
                { "V1RCAC_VLRCAP" , "1171.89"},
                { "V1RCAC_DATARCAP" , "2018-12-14"},
                { "V1RCAC_DTCADAST" , "2018-12-17"},
                { "V1RCAC_SITCONTB" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V1RCAPCOMP", q29);

                #endregion
                #region R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "104"},
                { "V1RCAC_AGEAVISO" , "7996"},
                { "V1RCAC_NRAVISO" , "899604641"},
                { "V1RCAC_DATARCAP" , "2019-03-25"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1", q40);

                #endregion
                #region BI6005B_V1COSSEGPROD

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CODPRODU" , "1001"},
                { "V1COSP_RAMO" , "31"},
                { "V1COSP_CONGENER" , "5495"},
                { "V1COSP_PCPARTIC" , "91.00000"},
                { "V1COSP_PCCOMCOS" , "18.69"},
                { "V1COSP_PCADMCOS" , "0.00"},
                { "V1COSP_DTINIVIG" , "1993-12-10"},
                { "V1COSP_DTTERVIG" , "9999-12-31"},
                { "V1COSP_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V1COSSEGPROD");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V1COSSEGPROD", q3);

                #endregion


                #endregion
                var program = new BI6005B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1
                var envList00 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList00[1].TryGetValue("V0NAES_SEQ_APOL", out var valor00) && valor00.Contains("1"));

                //R1000_15_FIM_DB_INSERT_1_Insert1
                var envList01 = AppSettings.TestSet.DynamicData["R1000_15_FIM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList01[1].TryGetValue("V0PARC_NUM_APOL", out var valor01) && valor01.Contains("0101400000001"));
                Assert.True(envList01.Count > 1);

                //R1000_15_FIM_DB_INSERT_2_Insert1
                var envList02 = AppSettings.TestSet.DynamicData["R1000_15_FIM_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList02[1].TryGetValue("V0COBA_PCT_COBERT", out var valor02) && valor02.Contains("100.00"));
                Assert.True(envList02.Count > 1);

                //R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1
                var envList03 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList03[1].TryGetValue("V0APOL_CODCLIEN", out var valor03) && valor03.Contains("020856799"));
                Assert.True(envList03.Count > 1);

                //R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1
                var envList04 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList04[1].TryGetValue("V0ENDO_BCORCAP", out var valor04) && valor04.Contains("0104"));
                Assert.True(envList04.Count > 1);

                //R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1
                var envList05 = AppSettings.TestSet.DynamicData["R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList05[1].TryGetValue("V0APCR_RAMOFR", out var valor05) && valor05.Contains("0014"));
                Assert.True(envList05.Count > 1);

                //R1050_00_TRATA_FUNDAO_DB_INSERT_2_Insert1
                var envList06 = AppSettings.TestSet.DynamicData["R1050_00_TRATA_FUNDAO_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList06[1].TryGetValue("V0APCR_CODCORR", out var valor06) && valor06.Contains("000017256"));
                Assert.True(envList06.Count > 1);

                //R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1
                var envList07 = AppSettings.TestSet.DynamicData["R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList07[1].TryGetValue("V0APCC_CODCOSS", out var valor07) && valor07.Contains("5495"));
                Assert.True(envList07.Count > 1);

                //R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1
                var envList08 = AppSettings.TestSet.DynamicData["R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList08[1].TryGetValue("V0ORDC_ORDEM_CED", out var valor08) && valor08.Contains("054950100000001"));
                Assert.True(envList08.Count > 1);

                //R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1
                var envList09 = AppSettings.TestSet.DynamicData["R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList09[1].TryGetValue("V1NCOS_ORGAO", out var valor09) && valor09.Contains("0010"));

                //R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1
                var envList10 = AppSettings.TestSet.DynamicData["R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("V0APOL_NUM_APOL", out var valor10) && valor10.Contains("0101400000001"));

                //R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1
                var envList11 = AppSettings.TestSet.DynamicData["R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList11[1].TryGetValue("V0HISP_AGECOBR", out var valor11) && valor11.Contains("7996"));
                Assert.True(envList11.Count > 1);

                //R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1
                var envList12 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList12[1].TryGetValue("V1FONT_PROPAUTOM", out var valor12) && valor12.Contains("2"));

                //R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1
                var envList13 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList13[1].TryGetValue("V0BILH_NUMBIL", out var valor13) && valor13.Contains("000084682458482"));

                //R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1
                var envList14 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1"].DynamicList;
                Assert.True(envList14[1].TryGetValue("V0COFE_SITUACAO", out var valor14) && valor14.Contains("9"));

                //R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1
                var envList15 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1"].DynamicList;
                Assert.True(envList15[1].TryGetValue("V0RCAP_FONTE", out var valor15) && valor15.Contains("0020"));

                //R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList16 = AppSettings.TestSet.DynamicData["R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList16[1].TryGetValue("V0BILH_NUMBIL", out var valor16) && valor16.Contains("000084682458482"));

                //R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList17 = AppSettings.TestSet.DynamicData["R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList17[1].TryGetValue("V0BILH_NUMBIL", out var valor17) && valor17.Contains("000084682458482"));

                //R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1
                var envList18 = AppSettings.TestSet.DynamicData["R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList18[1].TryGetValue("V0C396_NUMBIL", out var valor18) && valor18.Contains("000084682458482"));
                Assert.True(envList18.Count > 1);

                //R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1
                var envList19 = AppSettings.TestSet.DynamicData["R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList19[1].TryGetValue("V0CROT_BILH_RES", out var valor19) && valor19.Contains("S"));

            }
        }
        [Fact]
        public static void BI6005B_Tests_Fact_4_ReturnCode_0()
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

                #region BI6005B_CCBO

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "3"},
                { "CBO_DESCR_CBO" , "COMERCIANTE"},
                });
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "8"},
                { "CBO_DESCR_CBO" , "NUTRICIONISTA"},
                }); AppSettings.TestSet.DynamicData.Remove("BI6005B_CCBO");
                AppSettings.TestSet.DynamicData.Add("BI6005B_CCBO", q65);

                #endregion
                #region BI6005B_V0BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458482"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "1"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "1"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "12"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458483"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "21"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "6"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V0BILHETE", q2);

                #endregion
                #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
                });
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
                });
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q60);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "72850900.00"},
                { "V1BILC_PRMTAR_IX" , "130703.08000"},
                });
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "72850900.00"},
                { "V1BILC_PRMTAR_IX" , "130703.08000"},
                });
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "72850900.00"},
                { "V1BILC_PRMTAR_IX" , "130703.08000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q23);

                #endregion

                #region R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "-378631462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "-378631462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "-378631462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1", q38);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q8 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q12 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q12);

                #endregion
                #region R3000_10_CONTINUA_DB_SELECT_4_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , "B"},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , "B"},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , "B"},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_10_CONTINUA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_4_Query1", q45);

                #endregion
                #region R3000_10_CONTINUA_DB_SELECT_5_Query1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_NUM_MATRIC" , "109429"},
                { "V1FUNC_NOME_FUN" , "ABEL MAURICIO RODRIGUES                 "},
                { "V1FUNC_ENDERECO" , "RUA OLAVO BILAC,784                              "},
                { "V1FUNC_CIDADE" , "ASSIS                 "},
                { "V1FUNC_SIGLA_UF" , "SP"},
                { "V1FUNC_CEP" , "19802020"},
                { "V1FUNC_NUM_CPF" , "77906608887"},
                { "V1FUNC_COD_ANGAR" , "318108"},
                });
                q52.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_NUM_MATRIC" , "109429"},
                { "V1FUNC_NOME_FUN" , "ABEL MAURICIO RODRIGUES                 "},
                { "V1FUNC_ENDERECO" , "RUA OLAVO BILAC,784                              "},
                { "V1FUNC_CIDADE" , "ASSIS                 "},
                { "V1FUNC_SIGLA_UF" , "SP"},
                { "V1FUNC_CEP" , "19802020"},
                { "V1FUNC_NUM_CPF" , "77906608887"},
                { "V1FUNC_COD_ANGAR" , "318108"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_10_CONTINUA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_5_Query1", q52);

                #endregion
                #region R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1

                //REMOVER QUERY PARA SUBSTIUIR UPDATES PELO INSERT
                //var q55 = new DynamicData();
                //AppSettings.TestSet.DynamicData.Remove("R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1");
                //AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1", q55);

                #endregion

                #region R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1

                var q72 = new DynamicData();
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1", q72);

                #endregion

                #region R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1", q73);

                #endregion
                #region BI6005B_V1RCAPCOMP

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , "20"},
                { "V1RCAC_NRRCAPCO" , "-378631462"},
                { "V1RCAC_OPERACAO" , "0"},
                { "V1RCAC_DTMOVTO" , "110"},
                { "V1RCAC_HORAOPER" , "22:33:33"},
                { "V1RCAC_SITUACAO" , "0"},
                { "V1RCAC_BCOAVISO" , "104"},
                { "V1RCAC_AGEAVISO" , "7996"},
                { "V1RCAC_NRAVISO" , "899604577"},
                { "V1RCAC_VLRCAP" , "1171.89"},
                { "V1RCAC_DATARCAP" , "2018-12-14"},
                { "V1RCAC_DTCADAST" , "2018-12-17"},
                { "V1RCAC_SITCONTB" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V1RCAPCOMP", q29);

                #endregion
                #region R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "104"},
                { "V1RCAC_AGEAVISO" , "7996"},
                { "V1RCAC_NRAVISO" , "899604641"},
                { "V1RCAC_DATARCAP" , ""},
                });
                q40.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "104"},
                { "V1RCAC_AGEAVISO" , "7996"},
                { "V1RCAC_NRAVISO" , "899604641"},
                { "V1RCAC_DATARCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1", q40);

                #endregion
                #region BI6005B_V1COSSEGPROD

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CODPRODU" , "1001"},
                { "V1COSP_RAMO" , "31"},
                { "V1COSP_CONGENER" , "5495"},
                { "V1COSP_PCPARTIC" , "91.00000"},
                { "V1COSP_PCCOMCOS" , "18.69"},
                { "V1COSP_PCADMCOS" , "0.00"},
                { "V1COSP_DTINIVIG" , "1993-12-10"},
                { "V1COSP_DTTERVIG" , "9999-12-31"},
                { "V1COSP_SITUACAO" , "0"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CODPRODU" , "1001"},
                { "V1COSP_RAMO" , "31"},
                { "V1COSP_CONGENER" , "5495"},
                { "V1COSP_PCPARTIC" , "91.00000"},
                { "V1COSP_PCCOMCOS" , "18.69"},
                { "V1COSP_PCADMCOS" , "0.00"},
                { "V1COSP_DTINIVIG" , "1993-12-10"},
                { "V1COSP_DTTERVIG" , "9999-12-31"},
                { "V1COSP_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V1COSSEGPROD");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V1COSSEGPROD", q3);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "2541684"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "2541684"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "2541684"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "2541684"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1402"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1402"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1402"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1402"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q6);

                #endregion
                #region R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , "0"},
                { "V0BILFX_VALADT" , "6"},
                });
                q44.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , "0"},
                { "V0BILFX_VALADT" , "6"},
                });
                q44.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , "0"},
                { "V0BILFX_VALADT" , "6"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1", q44);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0COFE_VALADT" , "0"}
                });
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0COFE_VALADT" , "5"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1", q28);

                #endregion
                #endregion
                var program = new BI6005B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1
                var envList00 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList00[1].TryGetValue("V0NAES_SEQ_APOL", out var valor00) && valor00.Contains("1"));

                //R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1
                var envList01 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList01[1].TryGetValue("V0APOL_NUM_APOL", out var valor01) && valor01.Contains("0101402541685"));
                Assert.True(envList01.Count > 1);

                //R1000_15_NOVA_DB_INSERT_1_Insert1
                var envList02 = AppSettings.TestSet.DynamicData["R1000_15_NOVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList02[1].TryGetValue("V0APCR_CODCORR", out var valor02) && valor02.Contains("000018040"));
                Assert.True(envList02.Count > 1);

                //R1000_15_NOVA_DB_INSERT_2_Insert1
                var envList03 = AppSettings.TestSet.DynamicData["R1000_15_NOVA_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList03[1].TryGetValue("V0APCR_NUM_APOL", out var valor03) && valor03.Contains("0101402541685"));
                Assert.True(envList03.Count > 1);

                //R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1
                var envList04 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList04[1].TryGetValue("V0ENDO_NUM_APOL", out var valor04) && valor04.Contains("0101402541685"));
                Assert.True(envList04.Count > 1);

                //R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1
                var envList05 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList05[1].TryGetValue("V1FONT_PROPAUTOM", out var valor05) && valor05.Contains("000000002"));

                //R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1
                var envList06 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList06[1].TryGetValue("V0BILH_SITUACAO", out var valor06) && valor06.Contains("9"));

                //R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1
                var envList07 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1"].DynamicList;
                Assert.True(envList07[1].TryGetValue("V0COFE_SITUACAO", out var valor07) && valor07.Contains("9"));

                //R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1
                var envList08 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1"].DynamicList;
                Assert.True(envList08[1].TryGetValue("V0APOL_NUM_APOL", out var valor08) && valor08.Contains("0101402541685"));

                //R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList09 = AppSettings.TestSet.DynamicData["R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList09[1].TryGetValue("V0BILH_NUMBIL", out var valor09) && valor09.Contains("000084682458482"));

                //R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList10 = AppSettings.TestSet.DynamicData["R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("V0BILH_NUMBIL", out var valor10) && valor10.Contains("000084682458482"));

                //R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList11 = AppSettings.TestSet.DynamicData["R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList11[1].TryGetValue("V0BILH_NUMBIL", out var valor11) && valor11.Contains("000084682458482"));

                //R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1
                var envList12 = AppSettings.TestSet.DynamicData["R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList12[1].TryGetValue("V0C396_NUMBIL", out var valor12) && valor12.Contains("000084682458482"));
                Assert.True(envList12.Count > 1);

                //R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1
                var envList13 = AppSettings.TestSet.DynamicData["R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList13[1].TryGetValue("V0CROT_BILH_RES", out var valor13) && valor13.Contains("S"));


            }
        }
        [Fact]
        public static void BI6005B_Tests_Fact_5_ReturnCode_0()
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

                #region BI6005B_CCBO

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "3"},
                { "CBO_DESCR_CBO" , "COMERCIANTE"},
                });
                q65.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "8"},
                { "CBO_DESCR_CBO" , "NUTRICIONISTA"},
                }); AppSettings.TestSet.DynamicData.Remove("BI6005B_CCBO");
                AppSettings.TestSet.DynamicData.Add("BI6005B_CCBO", q65);

                #endregion
                #region BI6005B_V0BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458482"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "1"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "1"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "12"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84682458483"},
                { "V0BILH_FONTE" , "20"},
                { "V0BILH_AGECOBR" , "3082"},
                { "V0BILH_NUM_MATR" , "7777777"},
                { "V0BILH_AGENCIA" , "0"},
                { "V0BILH_CODCLIEN" , "20856799"},
                { "V0BILH_PROFISSAO" , "NAO INFORMADO       "},
                { "V0BILH_AGENCIA_DEB" , "0"},
                { "V0BILH_OPERACAO_DEB" , "0"},
                { "V0BILH_NUMCTA_DEB" , "0"},
                { "V0BILH_DIGCTA_DEB" , "0"},
                { "V0BILH_OPCAO_COBER" , "21"},
                { "V0BILH_DTQITBCO" , "2013-09-04"},
                { "V0BILH_VLRCAP" , "6"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_NUM_APO_ANT" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V0BILHETE", q2);

                #endregion
                #region R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
                });
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
                });
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q60);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "72850900.00"},
                { "V1BILC_PRMTAR_IX" , "130703.08000"},
                });
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "72850900.00"},
                { "V1BILC_PRMTAR_IX" , "130703.08000"},
                });
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_IMPSEG_IX" , "72850900.00"},
                { "V1BILC_PRMTAR_IX" , "130703.08000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q23);

                #endregion

                #region R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "-378631462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "-378631462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "20"},
                { "V0RCAP_NRRCAP" , "-378631462"},
                { "V2RCAP_VLRCAP" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_OPERACAO" , "110"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1", q38);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q8 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q12 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q12);

                #endregion
                #region R3000_10_CONTINUA_DB_SELECT_4_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , "B"},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , "B"},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_COBERTURA1" , "B"},
                { "V1COBI_COBERTURA2" , ""},
                { "V1COBI_COBERTURA3" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_10_CONTINUA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_4_Query1", q45);

                #endregion
                #region R3000_10_CONTINUA_DB_SELECT_5_Query1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_NUM_MATRIC" , "109429"},
                { "V1FUNC_NOME_FUN" , "ABEL MAURICIO RODRIGUES                 "},
                { "V1FUNC_ENDERECO" , "RUA OLAVO BILAC,784                              "},
                { "V1FUNC_CIDADE" , "ASSIS                 "},
                { "V1FUNC_SIGLA_UF" , "SP"},
                { "V1FUNC_CEP" , "19802020"},
                { "V1FUNC_NUM_CPF" , "77906608887"},
                { "V1FUNC_COD_ANGAR" , "318108"},
                });
                q52.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_NUM_MATRIC" , "109429"},
                { "V1FUNC_NOME_FUN" , "ABEL MAURICIO RODRIGUES                 "},
                { "V1FUNC_ENDERECO" , "RUA OLAVO BILAC,784                              "},
                { "V1FUNC_CIDADE" , "ASSIS                 "},
                { "V1FUNC_SIGLA_UF" , "SP"},
                { "V1FUNC_CEP" , "19802020"},
                { "V1FUNC_NUM_CPF" , "77906608887"},
                { "V1FUNC_COD_ANGAR" , "318108"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_10_CONTINUA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_SELECT_5_Query1", q52);

                #endregion
                #region R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1

                //REMOVER QUERY PARA SUBSTIUIR UPDATES PELO INSERT
                //var q55 = new DynamicData();
                //AppSettings.TestSet.DynamicData.Remove("R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1");
                //AppSettings.TestSet.DynamicData.Add("R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1", q55);

                #endregion

                #region R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1

                var q72 = new DynamicData();
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                q72.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NUM_APOL" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1", q72);

                #endregion

                #region R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                q73.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_INIVIG_ANT" , ""},
                { "V0ENDO_TERVIG_ANT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1", q73);

                #endregion
                #region BI6005B_V1RCAPCOMP

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , "20"},
                { "V1RCAC_NRRCAPCO" , "-378631462"},
                { "V1RCAC_OPERACAO" , "0"},
                { "V1RCAC_DTMOVTO" , "110"},
                { "V1RCAC_HORAOPER" , "22:33:33"},
                { "V1RCAC_SITUACAO" , "0"},
                { "V1RCAC_BCOAVISO" , "104"},
                { "V1RCAC_AGEAVISO" , "7996"},
                { "V1RCAC_NRAVISO" , "899604577"},
                { "V1RCAC_VLRCAP" , "1171.89"},
                { "V1RCAC_DATARCAP" , "2018-12-14"},
                { "V1RCAC_DTCADAST" , "2018-12-17"},
                { "V1RCAC_SITCONTB" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V1RCAPCOMP", q29);

                #endregion
                #region R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "104"},
                { "V1RCAC_AGEAVISO" , "7996"},
                { "V1RCAC_NRAVISO" , "899604641"},
                { "V1RCAC_DATARCAP" , ""},
                });
                q40.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "104"},
                { "V1RCAC_AGEAVISO" , "7996"},
                { "V1RCAC_NRAVISO" , "899604641"},
                { "V1RCAC_DATARCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1", q40);

                #endregion
                #region BI6005B_V1COSSEGPROD

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CODPRODU" , "1001"},
                { "V1COSP_RAMO" , "31"},
                { "V1COSP_CONGENER" , "5495"},
                { "V1COSP_PCPARTIC" , "91.00000"},
                { "V1COSP_PCCOMCOS" , "18.69"},
                { "V1COSP_PCADMCOS" , "0.00"},
                { "V1COSP_DTINIVIG" , "1993-12-10"},
                { "V1COSP_DTTERVIG" , "9999-12-31"},
                { "V1COSP_SITUACAO" , "0"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CODPRODU" , "1001"},
                { "V1COSP_RAMO" , "31"},
                { "V1COSP_CONGENER" , "5495"},
                { "V1COSP_PCPARTIC" , "91.00000"},
                { "V1COSP_PCCOMCOS" , "18.69"},
                { "V1COSP_PCADMCOS" , "0.00"},
                { "V1COSP_DTINIVIG" , "1993-12-10"},
                { "V1COSP_DTTERVIG" , "9999-12-31"},
                { "V1COSP_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6005B_V1COSSEGPROD");
                AppSettings.TestSet.DynamicData.Add("BI6005B_V1COSSEGPROD", q3);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "2541684"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "2541684"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "2541684"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1NAES_SEQ_APOL" , "2541684"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1402"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1402"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1402"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILP_CODPRODU" , "1402"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q6);

                #endregion
                #region R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , "0"},
                { "V0BILFX_VALADT" , "6"},
                });
                q44.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , "0"},
                { "V0BILFX_VALADT" , "6"},
                });
                q44.AddDynamic(new Dictionary<string, string>{
                { "V0BILFX_VERSAO" , "0"},
                { "V0BILFX_VALADT" , "6"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1", q44);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0COFE_VALADT" , "5"}
                });
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0COFE_VALADT" , "5"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1", q28);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1BILC_CODUNIMO" , "1"},
                { "V1BILC_PCCOMCOR" , "23.65"},
                { "V1BILC_PCIOCC" , "4.00"},
                { "V1BILC_VALMAX" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q24);

                #endregion
                #region R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "2621"}
                });
                q31.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "2622"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1", q31);

                #endregion
                #endregion
                var program = new BI6005B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R1000_10_ANTIGA_DB_INSERT_1_Insert1
                var envList00 = AppSettings.TestSet.DynamicData["R1000_10_ANTIGA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList00[1].TryGetValue("V0APCR_NUM_APOL", out var valor00) && valor00.Contains("0101402541685"));
                Assert.True(envList00.Count > 1);

                //R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1
                var envList01 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList01[1].TryGetValue("V0NAES_SEQ_APOL", out var valor01) && valor01.Contains("002541685"));
                
                //R1000_15_FIM_DB_INSERT_1_Insert1
                var envList02 = AppSettings.TestSet.DynamicData["R1000_15_FIM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList02[1].TryGetValue("V0PARC_NRTIT", out var valor02) && valor02.Contains("0084682458482"));
                Assert.True(envList02.Count > 1);

                //R1000_15_FIM_DB_INSERT_2_Insert1
                var envList03 = AppSettings.TestSet.DynamicData["R1000_15_FIM_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList03[1].TryGetValue("V0COBA_RAMOFR", out var valor03) && valor03.Contains("0014"));
                Assert.True(envList03.Count > 1);

                //R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1
                var envList04 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList04[1].TryGetValue("V0APOL_CODCLIEN", out var valor04) && valor04.Contains("020856799"));
                Assert.True(envList04.Count > 1);

                //R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1
                var envList05 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList05[1].TryGetValue("V0ENDO_BCORCAP", out var valor05) && valor05.Contains("0104"));
                Assert.True(envList05.Count > 1);

                //R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1
                var envList06 = AppSettings.TestSet.DynamicData["R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList06[1].TryGetValue("V0APCC_CODCOSS", out var valor06) && valor06.Contains("5495"));
                Assert.True(envList06.Count > 1);

                //R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1
                var envList07 = AppSettings.TestSet.DynamicData["R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList07[1].TryGetValue("V0ORDC_ORDEM_CED", out var valor07) && valor07.Contains("054950100002622"));
                Assert.True(envList07.Count > 1);

                //R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1
                var envList08 = AppSettings.TestSet.DynamicData["R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList08[1].TryGetValue("V1NCOS_CONGENER", out var valor08) && valor08.Contains("5495"));

                //R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1
                var envList09 = AppSettings.TestSet.DynamicData["R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList09[1].TryGetValue("V0APOL_PCTCED", out var valor09) && valor09.Contains("0182.00000"));

                //R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1
                var envList10 = AppSettings.TestSet.DynamicData["R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("V0HISP_OPERACAO", out var valor10) && valor10.Contains("0101"));
                Assert.True(envList10.Count > 1);

                //R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1
                var envList11 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList11[1].TryGetValue("V1FONT_PROPAUTOM", out var valor11) && valor11.Contains("000000002"));

                //R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1
                var envList12 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList12[1].TryGetValue("V0BILH_SITUACAO", out var valor12) && valor12.Contains("9"));
               
                //R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1
                var envList13 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1"].DynamicList;
                Assert.True(envList13[1].TryGetValue("V0COFE_NUMBIL", out var valor13) && valor13.Contains("000084682458482"));

                //R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1
                var envList14 = AppSettings.TestSet.DynamicData["R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1"].DynamicList;
                Assert.True(envList14[1].TryGetValue("V0RCAP_FONTE", out var valor14) && valor14.Contains("0020"));

                //R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList15 = AppSettings.TestSet.DynamicData["R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList15[1].TryGetValue("V0BILH_NUMBIL", out var valor15) && valor15.Contains("000084682458482"));

                //R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList16 = AppSettings.TestSet.DynamicData["R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList15[1].TryGetValue("V0BILH_NUMBIL", out var valor16) && valor16.Contains("000084682458482"));

                //R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1
                var envList17 = AppSettings.TestSet.DynamicData["R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList17[1].TryGetValue("V0C396_SITUACAO", out var valor17) && valor17.Contains("0"));
                Assert.True(envList17.Count > 1);

                //R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1
                var envList18 = AppSettings.TestSet.DynamicData["R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList18[1].TryGetValue("V0CROT_BILH_RES", out var valor18) && valor18.Contains("S"));

                //R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1
                var envList19 = AppSettings.TestSet.DynamicData["R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList19[1].TryGetValue("V0BILH_NUMBIL", out var valor19) && valor19.Contains("000084682458482"));
                Assert.True(envList19.Count > 1);
            }
        }
    }
}