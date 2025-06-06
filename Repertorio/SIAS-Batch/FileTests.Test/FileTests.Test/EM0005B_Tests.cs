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
using static Code.EM0005B;

namespace FileTests.Test
{
    [Collection("EM0005B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0005B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2025-01-27"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region EM0005B_V1PROPOSTA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_TPPROPOS" , "1"},
                { "V1PROP_FONTE" , ""},
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_RAMO" , "31"},
                { "V1PROP_MODALIDA" , ""},
                { "V1PROP_NUM_APO_ANT" , ""},
                { "V1PROP_TIPAPO" , ""},
                { "V1PROP_CODCLIEN" , ""},
                { "V1PROP_DTINIVIG" , ""},
                { "V1PROP_DTTERVIG" , ""},
                { "V1PROP_PODPUBL" , ""},
                { "V1PROP_CORRECAO" , ""},
                { "V1PROP_MOEDA_IMP" , ""},
                { "V1PROP_MOEDA_PRM" , ""},
                { "V1PROP_PRESTA1" , ""},
                { "V1PROP_BCORCAP" , ""},
                { "V1PROP_AGERCAP" , ""},
                { "V1PROP_NRRCAP" , ""},
                { "V1PROP_VLRCAP" , ""},
                { "V1PROP_CDFRACIO" , ""},
                { "V1PROP_QTPARCEL" , ""},
                { "V1PROP_PCENTRAD" , ""},
                { "V1PROP_PCADICIO" , ""},
                { "V1PROP_IDIOF" , ""},
                { "V1PROP_ISENTA_CST" , ""},
                { "V1PROP_QTPRESTA" , ""},
                { "V1PROP_BCOCOBR" , ""},
                { "V1PROP_AGECOBR" , ""},
                { "V1PROP_TPCORRET" , ""},
                { "V1PROP_NRAUTCOR" , ""},
                { "V1PROP_QTCORR" , ""},
                { "V1PROP_QTCORRC" , ""},
                { "V1PROP_NUM_APO_MAN" , ""},
                { "V1PROP_TPCOSCED" , ""},
                { "V1PROP_QTCOSSGC" , ""},
                { "V1PROP_QTCOSSEG" , ""},
                { "V1PROP_QTITENSI" , ""},
                { "V1PROP_QTITENS" , ""},
                { "V1PROP_TPMOVTO" , ""},
                { "V1PROP_DTENTRAD" , ""},
                { "V1PROP_DTCADAST" , ""},
                { "V1PROP_TIPCALC" , ""},
                { "V1PROP_LIMIND" , ""},
                { "V1PROP_CDACEITA" , ""},
                { "V1PROP_NRAUTACE" , ""},
                { "V1PROP_PCDESCON" , ""},
                { "V1PROP_IDRCAP" , ""},
                { "V1PROP_CODTXT" , ""},
                { "V1PROP_NUM_RENOV" , ""},
                { "V1PROP_CONV_COBR" , ""},
                { "V1PROP_OCORR_END" , ""},
                { "V1PROP_SITUACAO" , ""},
                { "V1PROP_COD_USUAR" , ""},
                { "V1PROP_NUM_ATA" , ""},
                { "V1PROP_ANO_ATA" , ""},
                { "V1PROP_DATA_SORT" , ""},
                { "V1PROP_DTLIBER" , ""},
                { "V1PROP_DTAPOLM" , ""},
                { "V1PROP_DATARCAP" , ""},
                { "V1PROP_COD_EMPRESA" , ""},
                { "V1PROP_CODPRODU" , "1803"},
                { "V1PROP_INSPETOR" , ""},
                { "V1PROP_CANALPROD" , ""},
                { "V1PROP_DTVENCTO" , ""},
                { "V1PROP_CFPREFIX" , ""},
                { "V1PROP_TIPO_ENDOS" , ""},
                { "V1PROP_NUM_APOLICE" , ""},
                { "V1PROP_VLCUSEMI" , ""},
                { "V1PROP_CODEMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0005B_V1PROPOSTA", q1);

            #endregion

            #region EM0005B_V1PROPCORRET

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1PCOR_FONTE" , ""},
                { "V1PCOR_NRPROPOS" , ""},
                { "V1PCOR_CODCORR" , ""},
                { "V1PCOR_RAMOFR" , ""},
                { "V1PCOR_MODALIFR" , ""},
                { "V1PCOR_PCPARCOR" , ""},
                { "V1PCOR_PCCOMCOR" , ""},
                { "V1PCOR_INDCRT" , ""},
                { "V1PCOR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0005B_V1PROPCORRET", q2);

            #endregion

            #region R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_ORGAOEMIS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1400_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_SEQ_APOLICE" , ""},
                { "V0NAES_ENDOSCOB" , ""},
                { "V0NAES_NRENDOCA" , ""},
                { "V0NAES_ENDOSRES" , ""},
                { "V0NAES_ENDOSSEM" , ""},
                { "V0NAES_ENDOSCCR" , ""},
                { "V0NAES_ENDOSMVC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_SEQ_APOLICE" , ""},
                { "V0NAES_ENDOSCOB" , ""},
                { "V0NAES_NRENDOCA" , ""},
                { "V0NAES_ENDOSRES" , ""},
                { "V0NAES_ENDOSSEM" , ""},
                { "V0NAES_ENDOSCCR" , ""},
                { "V0NAES_ENDOSMVC" , ""},
                { "V1FONT_ORGAOEMIS" , ""},
                { "V1PROP_RAMO" , "31"},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q6);

            #endregion

            #region EM0005B_V1PROPCOSCED

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1PCCD_FONTE" , ""},
                { "V1PCCD_NRPROPOS" , ""},
                { "V1PCCD_CODCOSS" , ""},
                { "V1PCCD_RAMOFR" , ""},
                { "V1PCCD_PCPARTIC" , ""},
                { "V1PCCD_PCCOMCOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0005B_V1PROPCOSCED", q7);

            #endregion

            #region EM0005B_V1COBERPROP

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1COBP_FONTE" , ""},
                { "V1COBP_NRPROPOS" , ""},
                { "V1COBP_NUM_ITEM" , ""},
                { "V1COBP_RAMOFR" , ""},
                { "V1COBP_MODALIFR" , ""},
                { "V1COBP_COD_COBER" , ""},
                { "V1COBP_IMP_SEG_IX" , ""},
                { "V1COBP_PRM_TAR_IX" , ""},
                { "V1COBP_DAT_INIVIG" , ""},
                { "V1COBP_DAT_TERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0005B_V1COBERPROP", q8);

            #endregion

            #region R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "W1COBP_NUM_ITEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "W1COBP_PRM_TAR_VR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1", q10);

            #endregion

            #region EM0005B_V1COSSEGSORT

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1COSS_RAMO" , ""},
                { "V1COSS_CONGENER" , ""},
                { "V1COSS_PCCOMCOS" , ""},
                { "V1COSS_PCPARTIC" , ""},
                { "V1COSS_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0005B_V1COSSEGSORT", q11);

            #endregion

            #region EM0005B_V1ACOMPROP

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1APRO_DATOPR" , ""},
                { "V1APRO_HORAOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0005B_V1ACOMPROP", q12);

            #endregion

            #region R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
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
                { "V0APOL_DATA_SORT" , ""},
                { "V0APOL_COD_EMPRESA" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_TPCORRET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R3200_10_INSERT_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
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
                { "V0ENDO_TIPEND" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R3200_10_INSERT_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , ""},
                { "V0ENDO_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_DATA_CADASTRAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1", q16);

            #endregion

            #region R3215_00_RECUPERA_AU085_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "AU085_IND_FORMA_PAGTO_AD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3215_00_RECUPERA_AU085_DB_SELECT_1_Query1", q17);

            #endregion

            #region R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0ACOR_NUM_APOL" , ""},
                { "V0ACOR_RAMOFR" , ""},
                { "V0ACOR_MODALIFR" , ""},
                { "V0ACOR_CODCORR" , ""},
                { "V0ACOR_CODSUBES" , ""},
                { "V0ACOR_DTINIVIG" , ""},
                { "V0ACOR_DTTERVIG" , ""},
                { "V0ACOR_PCPARCOR" , ""},
                { "V0ACOR_PCCOMCOR" , ""},
                { "V0ACOR_TIPCOM" , ""},
                { "V0ACOR_INDCRT" , ""},
                { "V0ACOR_COD_EMPRESA" , ""},
                { "V0ACOR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0ACCD_NUM_APOL" , ""},
                { "V0ACCD_CODCOSS" , ""},
                { "V0ACCD_RAMOFR" , ""},
                { "V0ACCD_DTINIVIG" , ""},
                { "V0ACCD_DTTERVIG" , ""},
                { "V0ACCD_PCPARTIC" , ""},
                { "V0ACCD_PCCOMCOS" , ""},
                { "V0ACCD_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R3530_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
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
                { "V0COBA_SITREG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3530_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R3600_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0APRO_FONTE" , ""},
                { "V0APRO_NRPROPOS" , ""},
                { "V0APRO_OPERACAO" , ""},
                { "V0APRO_DATOPR" , ""},
                { "V0APRO_HORAOPER" , ""},
                { "V0APRO_OCORHIST" , ""},
                { "V0APRO_CODUSU" , ""},
                { "V0APRO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "W1CPRO_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1", q22);

            #endregion

            #region R3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , ""},
                { "V0EDIA_NUM_APOL" , ""},
                { "V0EDIA_NRENDOS" , ""},
                { "V0EDIA_NRPARCEL" , ""},
                { "V0EDIA_DTMOVTO" , ""},
                { "V0EDIA_ORGAO" , ""},
                { "V0EDIA_RAMO" , ""},
                { "V0EDIA_FONTE" , ""},
                { "V0EDIA_CONGENER" , ""},
                { "V0EDIA_CODCORR" , ""},
                { "V0EDIA_SITUACAO" , ""},
                { "V0EDIA_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "W1CPRO_OCORHIST" , ""},
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1", q25);

            #endregion

            #region R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "W0APOL_QTCOSSEG" , ""},
                { "W0APOL_PCTCED" , ""},
                { "V0APOL_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1", q26);

            #endregion

            #region R4310_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_CODCLIEN" , ""},
                { "V0ENDO_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4310_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1", q27);

            #endregion

            #region R4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_PCT_COBERT" , ""},
                { "V0COBA_NUM_APOL" , ""},
                { "V0COBA_NUM_ITEM" , ""},
                { "V0COBA_OCORHIST" , ""},
                { "V0COBA_MODALIFR" , ""},
                { "V0COBA_NRENDOS" , ""},
                { "V0COBA_RAMOFR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1", q28);

            #endregion

            #region R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "LTMVPROP_PCT_JUROS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1", q29);

            #endregion

            #region R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R4550_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V1PROP_NRPROPOS" , ""},
                { "V0ENDO_NUM_APOL" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4550_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R5600_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0MPRD_NUM_APOL" , ""},
                { "V0MPRD_CODSUBES" , ""},
                { "V0MPRD_CODCORR" , ""},
                { "V0MPRD_CODPRP" , ""},
                { "V0MPRD_CODCLB" , ""},
                { "V0MPRD_INSPETOR" , ""},
                { "V0MPRD_ISPRGI" , ""},
                { "V0MPRD_CODGTE" , ""},
                { "V0MPRD_CODSTE" , ""},
                { "V0MPRD_DIRRGI" , ""},
                { "V0MPRD_DIRCMC" , ""},
                { "V0MPRD_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5600_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V2PROP_DTINIVIG" , ""},
                { "V2PROP_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1", q33);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0005B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                EM0910S_Tests.Load_Parameters_To_FactEM0005B();
                CS0701S_Tests.Load_Parameters_To_FactEM0005B();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #endregion
                var program = new EM0005B();
                program.Execute();

                var select1 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select1);

                var select2 = AppSettings.TestSet.DynamicData["R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select2);

                var select3 = AppSettings.TestSet.DynamicData["R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select3);

                var select4 = AppSettings.TestSet.DynamicData["R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select4);

                var select5 = AppSettings.TestSet.DynamicData["R1400_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select5);

                var update1 = AppSettings.TestSet.DynamicData["R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update1);
                Assert.True(update1[^1].TryGetValue("UpdateCheck", out string value) && value == "UpdateCheck");

                var insert1 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert1);
                Assert.True(insert1.Count() > 1);
                Assert.True(insert1[^1].TryGetValue("V0APOL_NUM_APOL", out string value1) && value1 == "0003100000001");

                var insert2 = AppSettings.TestSet.DynamicData["R3200_10_INSERT_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert2);
                Assert.True(insert2.Count() > 2);
                Assert.True(insert2[^1].TryGetValue("V0ENDO_NUM_APOL", out string value2) && value2 == "0003100000001");

                var insert3 = AppSettings.TestSet.DynamicData["R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert3);
                Assert.True(insert3.Count() > 1);
                Assert.True(insert3[^1].TryGetValue("V0ACOR_NUM_APOL", out string value3) && value3 == "0003100000001");

                var insert4 = AppSettings.TestSet.DynamicData["R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert4);
                Assert.True(insert4.Count() > 1);
                Assert.True(insert4[^1].TryGetValue("V0ACCD_NUM_APOL", out string value4) && value4 == "0003100000001");

                var insert5 = AppSettings.TestSet.DynamicData["R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(insert5);
                Assert.True(insert5.Count() > 1);
                Assert.True(insert5[^1].TryGetValue("V0APOL_NUM_APOL", out string value5) && value5 == "0003100000001");



                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void EM0005B_Tests_Fact_ReturnCode99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                EM0910S_Tests.Load_Parameters_To_FactEM0005B();
                CS0701S_Tests.Load_Parameters_To_FactEM0005B();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , "2025-01-27"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new EM0005B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}