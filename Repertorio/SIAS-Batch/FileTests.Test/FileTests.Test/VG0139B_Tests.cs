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
using static Code.VG0139B;

namespace FileTests.Test
{
    [Collection("VG0139B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class VG0139B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0050_00_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0050_00_INICIO_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_2_Query1", q1);

            #endregion

            #region VG0139B_CHISTCTBL

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRCERTIF" , ""},
                { "V0HCTB_NRPARCEL" , ""},
                { "V0HCTB_NRTIT" , ""},
                { "V0HCTB_OCORHIST" , ""},
                { "V0HCTB_NUM_APOLICE" , ""},
                { "V0HCTB_CODSUBES" , ""},
                { "V0HCTB_FONTE" , ""},
                { "V0HCTB_PRMVG" , ""},
                { "V0HCTB_PRMAP" , ""},
                { "V0HCTB_DTMOVTO" , ""},
                { "V0HCTB_SITUACAO" , ""},
                { "V0HCTB_CODOPER" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PRVG_CODPRODU" , ""},
                { "V0PRVG_ESTR_COBR" , ""},
                { "V0PRVG_ORIG_PRODU" , ""},
                { "V0SUBG_IND_IOF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0139B_CHISTCTBL", q2);

            #endregion

            #region VG0139B_V1RCAPCOMP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VG0139B_V1RCAPCOMP", q3);

            #endregion

            #region R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NUM_APOLICE" , ""},
                { "V0HCTB_NRCERTIF" , ""},
                { "V0HCTB_NRPARCEL" , ""},
                { "V0HCTB_OCORHIST" , ""},
                { "V0HCTB_CODSUBES" , ""},
                { "V0HCTB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0700_10_10C1_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0700_10_10C1_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""},
                { "V0HCTB_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q8);

            #endregion

            #region R0700_10_10C1_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_2_Query1", q9);

            #endregion

            #region R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""},
                { "V0ENDO_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R0700_10_10C1_DB_SELECT_3_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_3_Query1", q13);

            #endregion

            #region R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1", q14);

            #endregion

            #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q15);

            #endregion

            #region R0700_10_10C1_DB_SELECT_4_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_4_Query1", q16);

            #endregion

            #region R0700_10_10C1_DB_UPDATE_2_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_UPDATE_2_Update1", q17);

            #endregion

            #region R0700_10_10C1_DB_SELECT_5_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_5_Query1", q18);

            #endregion

            #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q19);

            #endregion

            #region R0700_10_10C1_DB_SELECT_6_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , ""},
                { "WHOST_DTENDFIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_6_Query1", q20);

            #endregion

            #region R0700_10_10C1_DB_SELECT_7_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_7_Query1", q21);

            #endregion

            #region R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q22);

            #endregion

            #region R0700_10_10C1_DB_SELECT_8_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "VG080_COD_GRUPO_SUSEP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_8_Query1", q23);

            #endregion

            #region R0700_10_10C1_DB_SELECT_9_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_9_Query1", q24);

            #endregion

            #region R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q25);

            #endregion

            #region R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_NRCERTIF" , ""},
                { "V0COBP_OCORHIST" , ""},
                { "V0COBP_DTINIVIG_ENDO" , ""},
                { "V0COBP_DTTERVIG_ENDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q26);

            #endregion

            #region R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_NRCERTIF" , ""},
                { "V0COBP_OCORHIST" , ""},
                { "V0COBP_DTINIVIG_ENDO" , ""},
                { "V0COBP_DTTERVIG_ENDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q27);

            #endregion

            #region R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , ""},
                { "WHOST_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q28);

            #endregion

            #region R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q29);

            #endregion

            #region R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , ""},
                { "V0HCTB_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG1" , ""},
                { "WHOST_DTTERVIG1" , ""},
                { "WHOST_DTINIVIG2" , ""},
                { "WHOST_DTTERVIG2" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1", q31);

            #endregion

            #region R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1", q32);

            #endregion

            #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , ""},
                { "V0ENDO_CODSUBES" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "WHOST_NRPARCEL" , ""},
                { "V0ENDO_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1", q33);

            #endregion

            #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1", q34);

            #endregion

            #region R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0HCTB_NRCERTIF" , ""},
                { "V0HCTB_NRPARCEL" , ""},
                { "V0HCTB_OCORHIST" , ""},
                { "V0HCTB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1", q35);

            #endregion

            #region R1102_00_SELECT_RCAP_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1", q36);

            #endregion

            #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q37);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1", q38);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1", q39);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1", q40);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1", q41);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1", q42);

            #endregion

            #region VG0139B_CVGHISTCONT

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "VG082_NUM_CERTIFICADO" , ""},
                { "VG082_NUM_PARCELA" , ""},
                { "VG082_NUM_TITULO" , ""},
                { "VG082_OCORR_HISTORICO" , ""},
                { "VG082_COD_GRUPO_SUSEP" , ""},
                { "VG082_RAMO_EMISSOR" , ""},
                { "VG082_COD_MODALIDADE" , ""},
                { "VG082_COD_COBERTURA" , ""},
                { "VG082_VLR_PREMIO_RAMO" , ""},
                { "VG082_COD_USUARIO" , ""},
                { "VG082_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0139B_CVGHISTCONT", q43);

            #endregion

            #region R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q44);

            #endregion

            #region R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1SIST_DTMOVACB" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q46);

            #endregion

            #region VG0139B_V1APOLCOSCED

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VG0139B_V1APOLCOSCED", q47);

            #endregion

            #region R1210_00_ACUMULA_IS_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , ""},
                { "V0CBPR_IMPMORACID" , ""},
                { "V0CBPR_IMPINVPERM" , ""},
                { "V0CBPR_IMPAMDS" , ""},
                { "V0CBPR_IMPDH" , ""},
                { "V0CBPR_IMPDIT" , ""},
                { "V0CBPR_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1", q48);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q49);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , ""},
                { "V0ORDC_NRENDOS" , ""},
                { "V0ORDC_CODCOSS" , ""},
                { "V0ORDC_ORDEM_CED" , ""},
                { "V0ORDC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q50);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""},
                { "V1NCOS_CONGENER" , ""},
                { "V1NCOS_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q51);

            #endregion

            #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_DACPARC" , ""},
                { "V0HISP_DTMOVTO" , ""},
                { "V0HISP_OPERACAO" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q52);

            #endregion

            #region R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0HCTB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1", q53);

            #endregion

            #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q54);

            #endregion

            #region R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_PRM_TAR_IX" , ""},
                { "V0COBA_PRM_TAR_VR" , ""},
                { "V0COBA_PCT_COBERT" , ""},
                { "V0COBA_COD_COBER" , ""},
                { "V0COBA_NUM_APOL" , ""},
                { "V0COBA_NUM_ITEM" , ""},
                { "V0COBA_OCORHIST" , ""},
                { "V0COBA_MODALIFR" , ""},
                { "V0COBA_NRENDOS" , ""},
                { "V0COBA_RAMOFR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1", q55);

            #endregion

            #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
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
            });
            AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q56);

            #endregion

            #region R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , ""},
                { "V0RELA_DATA_SOLICITACAO" , ""},
                { "V0RELA_IDSISTEM" , ""},
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_NRCOPIAS" , ""},
                { "V0RELA_QUANTIDADE" , ""},
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_DATA_REFERENCIA" , ""},
                { "V0RELA_MES_REFERENCIA" , ""},
                { "V0RELA_ANO_REFERENCIA" , ""},
                { "V0RELA_ORGAO" , ""},
                { "V0RELA_FONTE" , ""},
                { "V0RELA_CODPDT" , ""},
                { "V0RELA_RAMO" , ""},
                { "V0RELA_MODALIDA" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_NUM_APOLICE" , ""},
                { "V0RELA_NRENDOS" , ""},
                { "V0RELA_NRPARCEL" , ""},
                { "V0RELA_NRCERTIF" , ""},
                { "V0RELA_NRTIT" , ""},
                { "V0RELA_CODSUBES" , ""},
                { "V0RELA_OPERACAO" , ""},
                { "V0RELA_COD_PLANO" , ""},
                { "V0RELA_OCORHIST" , ""},
                { "V0RELA_APOLIDER" , ""},
                { "V0RELA_ENDOSLID" , ""},
                { "V0RELA_NUM_PARC_LIDER" , ""},
                { "V0RELA_NUM_SINISTRO" , ""},
                { "V0RELA_NUM_SINI_LIDER" , ""},
                { "V0RELA_NUM_ORDEM" , ""},
                { "V0RELA_CODUNIMO" , ""},
                { "V0RELA_CORRECAO" , ""},
                { "V0RELA_SITUACAO" , ""},
                { "V0RELA_PREVIA_DEFINITIVA" , ""},
                { "V0RELA_ANAL_RESUMO" , ""},
                { "V0RELA_COD_EMPRESA" , ""},
                { "V0RELA_PERI_RENOVACAO" , ""},
                { "V0RELA_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1", q57);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VG0139B_o1", "VG0139B_o2")]
        public static void VG0139B_Tests_Theory(string SVG0139B_FILE_NAME_P, string VG0139B1_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssffftt");

                SVG0139B_FILE_NAME_P = $"{SVG0139B_FILE_NAME_P}_{timestamp}.txt";
                VG0139B1_FILE_NAME_P = $"{VG0139B1_FILE_NAME_P}_{timestamp}.txt";

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0050_00_INICIO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_DTCURRENT" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0050_00_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0050_00_INICIO_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0050_00_INICIO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_2_Query1", q1);

                #endregion

                #region VG0139B_CHISTCTBL

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRCERTIF" , "123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_NRTIT" , "456" },
                { "V0HCTB_OCORHIST" , "A" },
                { "V0HCTB_NUM_APOLICE" , "789" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_FONTE" , "0" },
                { "V0HCTB_PRMVG" , "0" },
                { "V0HCTB_PRMAP" , "0" },
                { "V0HCTB_DTMOVTO" , "2023-12-01" },
                { "V0HCTB_SITUACAO" , "0" },
                { "V0HCTB_CODOPER" , "200" },
                { "V0PROP_CODPRODU" , "Prod001" },
                { "V0PROP_CODCLIEN" , "Client001" },
                { "V0PROP_DTQITBCO" , "2023-12-01" },
                { "V0PROP_SITUACAO" , "4" },
                { "V0PROP_OCORHIST" , "Hist001" },
                { "V0PROP_DTPROXVEN" , "2023-12-10" },
                { "V0PRVG_CODPRODU" , "Prod002" },
                { "V0PRVG_ESTR_COBR" , "MULT" },
                { "V0PRVG_ORIG_PRODU" , "EMPRE" },
                { "V0SUBG_IND_IOF" , "Y" },
            });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRCERTIF" , "123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_NRTIT" , "456" },
                { "V0HCTB_OCORHIST" , "A" },
                { "V0HCTB_NUM_APOLICE" , "789" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_FONTE" , "50" },
                { "V0HCTB_PRMVG" , "150" },
                { "V0HCTB_PRMAP" , "0" },
                { "V0HCTB_DTMOVTO" , "2023-12-01" },
                { "V0HCTB_SITUACAO" , "0" },
                { "V0HCTB_CODOPER" , "200" },
                { "V0PROP_CODPRODU" , "Prod001" },
                { "V0PROP_CODCLIEN" , "Client001" },
                { "V0PROP_DTQITBCO" , "2023-12-01" },
                { "V0PROP_SITUACAO" , "3" },
                { "V0PROP_OCORHIST" , "Hist001" },
                { "V0PROP_DTPROXVEN" , "2023-12-10" },
                { "V0PRVG_CODPRODU" , "Prod002" },
                { "V0PRVG_ESTR_COBR" , "MULT" },
                { "V0PRVG_ORIG_PRODU" , "EMPRE" },
                { "V0SUBG_IND_IOF" , "Y" },
            });
                AppSettings.TestSet.DynamicData.Remove("VG0139B_CHISTCTBL");
                AppSettings.TestSet.DynamicData.Add("VG0139B_CHISTCTBL", q2);

                #endregion

                #region VG0139B_V1RCAPCOMP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Source001" },
                { "V1RCAC_NRRCAP" , "Rcap001" },
                { "V1RCAC_NRRCAPCO" , "RcapCo001" },
                { "V1RCAC_OPERACAO" , "Oper002" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Pending" },
                { "V1RCAC_BCOAVISO" , "Bank001" },
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
                { "V1RCAC_VLRCAP" , "200.0" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Sit001" },
            });
                AppSettings.TestSet.DynamicData.Remove("VG0139B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VG0139B_V1RCAPCOMP", q3);

                #endregion

                #region R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NUM_APOLICE" , "789" },
                { "V0HCTB_NRCERTIF" , "123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_OCORHIST" , "A" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_NRTIT" , "456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1", q4);

                #endregion

                #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , "97" },
                { "V0APOL_CODPRODU" , "Prod003" },
                { "V0APOL_MODALIDA" , "Mod001" },
                { "V0APOL_ORGAO" , "Org001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0700_10_10C1_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , "Monthly" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0700_10_10C1_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , "2023-12-15" },
                { "V0HCTB_NRCERTIF" , "123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , "2023-12-15" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R0700_10_10C1_DB_SELECT_2_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , "Monthly" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_2_Query1", q9);

                #endregion

                #region R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_CODPRODU" , "Prod004" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "Apol002" },
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0ENDO_CODSUBES" , "Subes002" },
                { "V0ENDO_FONTE" , "Source002" },
                { "V0ENDO_NRPROPOS" , "Prop002" },
                { "V0ENDO_DATPRO" , "2023-12-01" },
                { "V0ENDO_DT_LIBER" , "2023-12-01" },
                { "V0ENDO_DTEMIS" , "2023-12-01" },
                { "V0ENDO_NRRCAP" , "Rcap002" },
                { "V0ENDO_VLRCAP" , "250.0" },
                { "V0ENDO_BCORCAP" , "Bank002" },
                { "V0ENDO_AGERCAP" , "Agency002" },
                { "V0ENDO_DACRCAP" , "Dac002" },
                { "V0ENDO_IDRCAP" , "Id002" },
                { "V0ENDO_BCOCOBR" , "BankCobr001" },
                { "V0ENDO_AGECOBR" , "AgencyCobr001" },
                { "V0ENDO_DACCOBR" , "DacCobr001" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2023-12-31" },
                { "V0ENDO_CDFRACIO" , "Frac001" },
                { "V0ENDO_PCENTRAD" , "10.0" },
                { "V0ENDO_PCADICIO" , "5.0" },
                { "V0ENDO_PRESTA1" , "100.0" },
                { "V0ENDO_QTPARCEL" , "3" },
                { "V0ENDO_QTPRESTA" , "10" },
                { "V0ENDO_QTITENS" , "5" },
                { "V0ENDO_CODTXT" , "Txt001" },
                { "V0ENDO_CDACEITA" , "Yes" },
                { "V0ENDO_MOEDA_IMP" , "USD" },
                { "V0ENDO_MOEDA_PRM" , "EUR" },
                { "V0ENDO_TIPO_ENDO" , "Type001" },
                { "V0ENDO_COD_USUAR" , "User001" },
                { "V0ENDO_OCORR_END" , "Occur001" },
                { "V0ENDO_SITUACAO" , "Active" },
                { "V0ENDO_DATARCAP" , "2023-12-01" },
                { "V0ENDO_COD_EMPRESA" , "Comp001" },
                { "V0ENDO_CORRECAO" , "Corr001" },
                { "V0ENDO_ISENTA_CST" , "No" },
                { "V0ENDO_DTVENCTO" , "2023-12-20" },
                { "V0ENDO_CFPREFIX" , "Prefix001" },
                { "V0ENDO_VLCUSEMI" , "300.0" },
                { "V0ENDO_RAMO" , "Ramo002" },
                { "V0ENDO_CODPRODU" , "Prod004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto001" },
                { "V0ENDO_FONTE" , "Source002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R0700_10_10C1_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_3_Query1", q13);

                #endregion

                #region R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , "Apol003" },
                { "V0PARC_NRENDOS" , "Endos002" },
                { "V0PARC_NRPARCEL" , "2" },
                { "V0PARC_DACPARC" , "Dac003" },
                { "V0PARC_FONTE" , "Source003" },
                { "V0PARC_NRTIT" , "Tit002" },
                { "V0PARC_PRM_TAR_IX" , "350.0" },
                { "V0PARC_VAL_DES_IX" , "50.0" },
                { "V0PARC_OTNPRLIQ" , "400.0" },
                { "V0PARC_OTNADFRA" , "45.0" },
                { "V0PARC_OTNCUSTO" , "25.0" },
                { "V0PARC_OTNIOF" , "5.0" },
                { "V0PARC_OTNTOTAL" , "500.0" },
                { "V0PARC_OCORHIST" , "Hist002" },
                { "V0PARC_QTDDOC" , "10" },
                { "V0PARC_SITUACAO" , "Valid" },
                { "V0PARC_COD_EMPRESA" , "Comp002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1", q14);

                #endregion

                #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2023-12-25" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q15);

                #endregion

                #region R0700_10_10C1_DB_SELECT_4_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_4_Query1", q16);

                #endregion

                #region R0700_10_10C1_DB_UPDATE_2_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0APOL_ORGAO" , "Org001" },
                { "V0APOL_RAMO" , "97" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_UPDATE_2_Update1", q17);

                #endregion

                #region R0700_10_10C1_DB_SELECT_5_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , "2023-12-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_5_Query1", q18);

                #endregion

                #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2023-12-25" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q19);

                #endregion

                #region R0700_10_10C1_DB_SELECT_6_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2023-12-02" },
                { "WHOST_DTENDFIM" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_6_Query1", q20);

                #endregion

                #region R0700_10_10C1_DB_SELECT_7_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_7_Query1", q21);

                #endregion

                #region R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "Endos003" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q22);

                #endregion

                #region R0700_10_10C1_DB_SELECT_8_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "VG080_COD_GRUPO_SUSEP" , "Susep001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_8_Query1", q23);

                #endregion

                #region R0700_10_10C1_DB_SELECT_9_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_9_Query1", q24);

                #endregion

                #region R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "Endos003" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q25);

                #endregion

                #region R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_NRCERTIF" , "Cert002" },
                { "V0COBP_OCORHIST" , "Hist003" },
                { "V0COBP_DTINIVIG_ENDO" , "2023-12-15" },
                { "V0COBP_DTTERVIG_ENDO" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q26);

                #endregion

                #region R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_NRCERTIF" , "Cert002" },
                { "V0COBP_OCORHIST" , "Hist003" },
                { "V0COBP_DTINIVIG_ENDO" , "2023-12-15" },
                { "V0COBP_DTTERVIG_ENDO" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q27);

                #endregion

                #region R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , "Subes003" },
                { "WHOST_DTTERVIG" , "2023-12-14" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q28);

                #endregion

                #region R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , "2023-12-14" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q29);

                #endregion

                #region R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , "2023-12-14" },
                { "V0HCTB_NUM_APOLICE" , "789" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q30);

                #endregion

                #region R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG1" , "2023-12-02" },
                { "WHOST_DTTERVIG1" , "2023-12-14" },
                { "WHOST_DTINIVIG2" , "2023-12-02" },
                { "WHOST_DTTERVIG2" , "2023-12-14" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1", q31);

                #endregion

                #region R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , "2023-12-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1", q32);

                #endregion

                #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "Apol002" },
                { "V0ENDO_CODSUBES" , "Subes002" },
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "WHOST_NRPARCEL" , "4" },
                { "V0ENDO_FONTE" , "Source002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1", q33);

                #endregion

                #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0APOL_ORGAO" , "Org001" },
                { "V0APOL_RAMO" , "97" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1", q34);

                #endregion

                #region R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0HCTB_NRCERTIF" , "123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_OCORHIST" , "A" },
                { "V0HCTB_NRTIT" , "456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1", q35);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_1_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1", q36);

                #endregion

                #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.1" }
            });
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q37);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "Sicob001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1", q38);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0RCAP_NRRCAP" , "Rcap003" },
                { "V0RCAP_FONTE" , "Source004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1", q39);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Source004" },
                { "V0RCAP_NRRCAP" , "Rcap003" },
                { "V0RCAP_SITUACAO" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1", q40);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "Apol002" },
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0RCAP_NRRCAP" , "Rcap003" },
                { "V0RCAP_FONTE" , "Source004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1", q41);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "Bank001" },
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1", q42);

                #endregion

                #region VG0139B_CVGHISTCONT

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "VG082_NUM_CERTIFICADO" , "Cert003" },
                { "VG082_NUM_PARCELA" , "5" },
                { "VG082_NUM_TITULO" , "Title001" },
                { "VG082_OCORR_HISTORICO" , "Hist004" },
                { "VG082_COD_GRUPO_SUSEP" , "Susep002" },
                { "VG082_RAMO_EMISSOR" , "Ramo003" },
                { "VG082_COD_MODALIDADE" , "Mod002" },
                { "VG082_COD_COBERTURA" , "Cob001" },
                { "VG082_VLR_PREMIO_RAMO" , "450.0" },
                { "VG082_COD_USUARIO" , "User002" },
                { "VG082_DTH_ATUALIZACAO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("VG0139B_CVGHISTCONT");
                AppSettings.TestSet.DynamicData.Add("VG0139B_CVGHISTCONT", q43);

                #endregion

                #region R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "RcapCo001" },
                { "V1RCAC_OPERACAO" , "Oper002" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "Rcap001" },
                { "V1RCAC_FONTE" , "Source001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q44);

                #endregion

                #region R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Source001" },
                { "V1RCAC_NRRCAP" , "Rcap001" },
                { "V1RCAC_NRRCAPCO" , "RcapCo001" },
                { "V1RCAC_OPERACAO" , "Oper002" },
                { "V1SIST_DTMOVACB" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Pending" },
                { "V1RCAC_BCOAVISO" , "Bank001" },
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
                { "V1RCAC_VLRCAP" , "200.0" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Sit001" },
                { "V1RCAC_COD_EMPRESA" , "Comp003" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q45);

                #endregion

                #region R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "200.0" },
                { "V1RCAC_BCOAVISO" , "Bank001" },
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q46);

                #endregion

                #region VG0139B_V1APOLCOSCED

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , "Cong001" }
            });
                AppSettings.TestSet.DynamicData.Remove("VG0139B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("VG0139B_V1APOLCOSCED", q47);

                #endregion

                #region R1210_00_ACUMULA_IS_DB_SELECT_1_Query1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "0.2" },
                { "V0CBPR_IMPMORACID" , "0.3" },
                { "V0CBPR_IMPINVPERM" , "0.4" },
                { "V0CBPR_IMPAMDS" , "0.5" },
                { "V0CBPR_IMPDH" , "0.6" },
                { "V0CBPR_IMPDIT" , "5.0" },
                { "V0CBPR_PRMDIT" , "0.8" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1", q48);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "Order001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q49);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , "Apol004" },
                { "V0ORDC_NRENDOS" , "Endos004" },
                { "V0ORDC_CODCOSS" , "Coss001" },
                { "V0ORDC_ORDEM_CED" , "Ced001" },
                { "V0ORDC_COD_EMPRESA" , "Comp004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q50);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "Order001" },
                { "V1NCOS_CONGENER" , "Cong002" },
                { "V1NCOS_ORGAO" , "Org002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q51);

                #endregion

                #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "Apol005" },
                { "V0HISP_NRENDOS" , "Endos005" },
                { "V0HISP_NRPARCEL" , "6" },
                { "V0HISP_DACPARC" , "Dac004" },
                { "V0HISP_DTMOVTO" , "2023-12-01" },
                { "V0HISP_OPERACAO" , "Oper003" },
                { "V0HISP_OCORHIST" , "Hist005" },
                { "V0HISP_PRM_TARIFA" , "550.0" },
                { "V0HISP_VAL_DESCON" , "75.0" },
                { "V0HISP_VLPRMLIQ" , "600.0" },
                { "V0HISP_VLADIFRA" , "65.0" },
                { "V0HISP_VLCUSEMI" , "350.0" },
                { "V0HISP_VLIOCC" , "15.0" },
                { "V0HISP_VLPRMTOT" , "700.0" },
                { "V0HISP_VLPREMIO" , "750.0" },
                { "V0HISP_DTVENCTO" , "2023-12-30" },
                { "V0HISP_BCOCOBR" , "BankCobr002" },
                { "V0HISP_AGECOBR" , "AgencyCobr002" },
                { "V0HISP_NRAVISO" , "Notice002" },
                { "V0HISP_NRENDOCA" , "Endoca001" },
                { "V0HISP_SITCONTB" , "Sit002" },
                { "V0HISP_COD_USUAR" , "User003" },
                { "V0HISP_RNUDOC" , "Doc001" },
                { "V0HISP_DTQITBCO" , "2023-12-01" },
                { "V0HISP_COD_EMPRESA" , "Comp005" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q52);

                #endregion

                #region R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1

                var q53 = new DynamicData();
                q53.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0HCTB_NRTIT" , "456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1", q53);

                #endregion

                #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

                var q54 = new DynamicData();
                q54.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , "Apol006" },
                { "V0COBA_NRENDOS" , "Endos006" },
                { "V0COBA_NUM_ITEM" , "Item001" },
                { "V0COBA_OCORHIST" , "Hist006" },
                { "V0COBA_RAMOFR" , "Ramo004" },
                { "V0COBA_MODALIFR" , "Mod003" },
                { "V0COBA_COD_COBER" , "Cob002" },
                { "V0COBA_IMP_SEG_IX" , "800.0" },
                { "V0COBA_PRM_TAR_IX" , "850.0" },
                { "V0COBA_IMP_SEG_VR" , "900.0" },
                { "V0COBA_PRM_TAR_VR" , "950.0" },
                { "V0COBA_PCT_COBERT" , "0.9" },
                { "V0COBA_FATOR_MULT" , "1.1" },
                { "V0COBA_DATA_INIVI" , "2023-12-01" },
                { "V0COBA_DATA_TERVI" , "2023-12-31" },
                { "V0COBA_COD_EMPRESA" , "Comp006" },
                { "V0COBA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q54);

                #endregion

                #region R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_PRM_TAR_IX" , "850.0" },
                { "V0COBA_PRM_TAR_VR" , "950.0" },
                { "V0COBA_PCT_COBERT" , "0.9" },
                { "V0COBA_COD_COBER" , "Cob002" },
                { "V0COBA_NUM_APOL" , "Apol006" },
                { "V0COBA_NUM_ITEM" , "Item001" },
                { "V0COBA_OCORHIST" , "Hist006" },
                { "V0COBA_MODALIFR" , "Mod003" },
                { "V0COBA_NRENDOS" , "Endos006" },
                { "V0COBA_RAMOFR" , "Ramo004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1", q55);

                #endregion

                #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , "Relat001" },
                { "V0EDIA_NUM_APOL" , "Apol007" },
                { "V0EDIA_NRENDOS" , "Endos007" },
                { "V0EDIA_NRPARCEL" , "7" },
                { "V0EDIA_DTMOVTO" , "2023-12-01" },
                { "V0EDIA_ORGAO" , "Org003" },
                { "V0EDIA_RAMO" , "Ramo005" },
                { "V0EDIA_FONTE" , "Source005" },
                { "V0EDIA_CONGENER" , "Cong003" },
                { "V0EDIA_CODCORR" , "Corr002" },
                { "V0EDIA_SITUACAO" , "Valid" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q56);

                #endregion

                #region R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , "User004" },
                { "V0RELA_DATA_SOLICITACAO" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "Sys001" },
                { "V0RELA_CODRELAT" , "Relat002" },
                { "V0RELA_NRCOPIAS" , "1" },
                { "V0RELA_QUANTIDADE" , "1" },
                { "V0RELA_PERI_INICIAL" , "2023-12-01" },
                { "V0RELA_PERI_FINAL" , "2023-12-31" },
                { "V0RELA_DATA_REFERENCIA" , "2023-12-01" },
                { "V0RELA_MES_REFERENCIA" , "12" },
                { "V0RELA_ANO_REFERENCIA" , "2023" },
                { "V0RELA_ORGAO" , "Org004" },
                { "V0RELA_FONTE" , "Source006" },
                { "V0RELA_CODPDT" , "Pdt001" },
                { "V0RELA_RAMO" , "Ramo006" },
                { "V0RELA_MODALIDA" , "Mod004" },
                { "V0RELA_CONGENER" , "Cong004" },
                { "V0RELA_NUM_APOLICE" , "Apol008" },
                { "V0RELA_NRENDOS" , "Endos008" },
                { "V0RELA_NRPARCEL" , "8" },
                { "V0RELA_NRCERTIF" , "Cert004" },
                { "V0RELA_NRTIT" , "Tit003" },
                { "V0RELA_CODSUBES" , "Subes004" },
                { "V0RELA_OPERACAO" , "Oper004" },
                { "V0RELA_COD_PLANO" , "Plan001" },
                { "V0RELA_OCORHIST" , "Hist007" },
                { "V0RELA_APOLIDER" , "Lider001" },
                { "V0RELA_ENDOSLID" , "EndosLid001" },
                { "V0RELA_NUM_PARC_LIDER" , "9" },
                { "V0RELA_NUM_SINISTRO" , "Sin001" },
                { "V0RELA_NUM_SINI_LIDER" , "SiniLid001" },
                { "V0RELA_NUM_ORDEM" , "Order002" },
                { "V0RELA_CODUNIMO" , "Unimo001" },
                { "V0RELA_CORRECAO" , "Corr003" },
                { "V0RELA_SITUACAO" , "Pending" },
                { "V0RELA_PREVIA_DEFINITIVA" , "Definitive" },
                { "V0RELA_ANAL_RESUMO" , "Summary" },
                { "V0RELA_COD_EMPRESA" , "Comp007" },
                { "V0RELA_PERI_RENOVACAO" , "2023-12-01" },
                { "V0RELA_PCT_AUMENTO" , "1.2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1", q57);

                #endregion
                #endregion
                #endregion

                var program = new VG0139B();
                program.Execute(SVG0139B_FILE_NAME_P, VG0139B1_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= 6);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= 1);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VG0139B_o3", "VG0139B_o4")]
        public static void VG0139B_Tests_ReturnCode99_Theory(string SVG0139B_FILE_NAME_P, string VG0139B1_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssffftt");

                SVG0139B_FILE_NAME_P = $"{SVG0139B_FILE_NAME_P}_{timestamp}.txt";
                VG0139B1_FILE_NAME_P = $"{VG0139B1_FILE_NAME_P}_{timestamp}.txt";

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0050_00_INICIO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_DTCURRENT" , "2023-12-01" },
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0050_00_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0050_00_INICIO_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2023-12-01" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0050_00_INICIO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_2_Query1", q1);

                #endregion

                #region VG0139B_CHISTCTBL

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRCERTIF" , "123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_NRTIT" , "456" },
                { "V0HCTB_OCORHIST" , "A" },
                { "V0HCTB_NUM_APOLICE" , "789" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_FONTE" , "0" },
                { "V0HCTB_PRMVG" , "100.0" },
                { "V0HCTB_PRMAP" , "150.0" },
                { "V0HCTB_DTMOVTO" , "2023-12-01" },
                { "V0HCTB_SITUACAO" , "0" },
                { "V0HCTB_CODOPER" , "200" },
                { "V0PROP_CODPRODU" , "Prod001" },
                { "V0PROP_CODCLIEN" , "Client001" },
                { "V0PROP_DTQITBCO" , "2023-12-01" },
                { "V0PROP_SITUACAO" , "4" },
                { "V0PROP_OCORHIST" , "Hist001" },
                { "V0PROP_DTPROXVEN" , "2023-12-10" },
                { "V0PRVG_CODPRODU" , "Prod002" },
                { "V0PRVG_ESTR_COBR" , "MULT" },
                { "V0PRVG_ORIG_PRODU" , "EMPRE" },
                { "V0SUBG_IND_IOF" , "Y" },
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VG0139B_CHISTCTBL");
                AppSettings.TestSet.DynamicData.Add("VG0139B_CHISTCTBL", q2);

                #endregion

                #region VG0139B_V1RCAPCOMP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Source001" },
                { "V1RCAC_NRRCAP" , "Rcap001" },
                { "V1RCAC_NRRCAPCO" , "RcapCo001" },
                { "V1RCAC_OPERACAO" , "Oper002" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Pending" },
                { "V1RCAC_BCOAVISO" , "Bank001" },
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
                { "V1RCAC_VLRCAP" , "200.0" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Sit001" },
            });
                AppSettings.TestSet.DynamicData.Remove("VG0139B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VG0139B_V1RCAPCOMP", q3);

                #endregion

                #region R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NUM_APOLICE" , "789" },
                { "V0HCTB_NRCERTIF" , "123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_OCORHIST" , "A" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_NRTIT" , "456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1", q4);

                #endregion

                #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , "97" },
                { "V0APOL_CODPRODU" , "Prod003" },
                { "V0APOL_MODALIDA" , "Mod001" },
                { "V0APOL_ORGAO" , "Org001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0700_10_10C1_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , "Monthly" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0700_10_10C1_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , "2023-12-15" },
                { "V0HCTB_NRCERTIF" , "123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , "2023-12-15" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R0700_10_10C1_DB_SELECT_2_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , "Monthly" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_2_Query1", q9);

                #endregion

                #region R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_CODPRODU" , "Prod004" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "Apol002" },
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0ENDO_CODSUBES" , "Subes002" },
                { "V0ENDO_FONTE" , "Source002" },
                { "V0ENDO_NRPROPOS" , "Prop002" },
                { "V0ENDO_DATPRO" , "2023-12-01" },
                { "V0ENDO_DT_LIBER" , "2023-12-01" },
                { "V0ENDO_DTEMIS" , "2023-12-01" },
                { "V0ENDO_NRRCAP" , "Rcap002" },
                { "V0ENDO_VLRCAP" , "250.0" },
                { "V0ENDO_BCORCAP" , "Bank002" },
                { "V0ENDO_AGERCAP" , "Agency002" },
                { "V0ENDO_DACRCAP" , "Dac002" },
                { "V0ENDO_IDRCAP" , "Id002" },
                { "V0ENDO_BCOCOBR" , "BankCobr001" },
                { "V0ENDO_AGECOBR" , "AgencyCobr001" },
                { "V0ENDO_DACCOBR" , "DacCobr001" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2023-12-31" },
                { "V0ENDO_CDFRACIO" , "Frac001" },
                { "V0ENDO_PCENTRAD" , "10.0" },
                { "V0ENDO_PCADICIO" , "5.0" },
                { "V0ENDO_PRESTA1" , "100.0" },
                { "V0ENDO_QTPARCEL" , "3" },
                { "V0ENDO_QTPRESTA" , "10" },
                { "V0ENDO_QTITENS" , "5" },
                { "V0ENDO_CODTXT" , "Txt001" },
                { "V0ENDO_CDACEITA" , "Yes" },
                { "V0ENDO_MOEDA_IMP" , "USD" },
                { "V0ENDO_MOEDA_PRM" , "EUR" },
                { "V0ENDO_TIPO_ENDO" , "Type001" },
                { "V0ENDO_COD_USUAR" , "User001" },
                { "V0ENDO_OCORR_END" , "Occur001" },
                { "V0ENDO_SITUACAO" , "Active" },
                { "V0ENDO_DATARCAP" , "2023-12-01" },
                { "V0ENDO_COD_EMPRESA" , "Comp001" },
                { "V0ENDO_CORRECAO" , "Corr001" },
                { "V0ENDO_ISENTA_CST" , "No" },
                { "V0ENDO_DTVENCTO" , "2023-12-20" },
                { "V0ENDO_CFPREFIX" , "Prefix001" },
                { "V0ENDO_VLCUSEMI" , "300.0" },
                { "V0ENDO_RAMO" , "Ramo002" },
                { "V0ENDO_CODPRODU" , "Prod004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto001" },
                { "V0ENDO_FONTE" , "Source002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R0700_10_10C1_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_3_Query1", q13);

                #endregion

                #region R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , "Apol003" },
                { "V0PARC_NRENDOS" , "Endos002" },
                { "V0PARC_NRPARCEL" , "2" },
                { "V0PARC_DACPARC" , "Dac003" },
                { "V0PARC_FONTE" , "Source003" },
                { "V0PARC_NRTIT" , "Tit002" },
                { "V0PARC_PRM_TAR_IX" , "350.0" },
                { "V0PARC_VAL_DES_IX" , "50.0" },
                { "V0PARC_OTNPRLIQ" , "400.0" },
                { "V0PARC_OTNADFRA" , "45.0" },
                { "V0PARC_OTNCUSTO" , "25.0" },
                { "V0PARC_OTNIOF" , "5.0" },
                { "V0PARC_OTNTOTAL" , "500.0" },
                { "V0PARC_OCORHIST" , "Hist002" },
                { "V0PARC_QTDDOC" , "10" },
                { "V0PARC_SITUACAO" , "Valid" },
                { "V0PARC_COD_EMPRESA" , "Comp002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1", q14);

                #endregion

                #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2023-12-25" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q15);

                #endregion

                #region R0700_10_10C1_DB_SELECT_4_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_4_Query1", q16);

                #endregion

                #region R0700_10_10C1_DB_UPDATE_2_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0APOL_ORGAO" , "Org001" },
                { "V0APOL_RAMO" , "97" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_UPDATE_2_Update1", q17);

                #endregion

                #region R0700_10_10C1_DB_SELECT_5_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , "2023-12-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_5_Query1", q18);

                #endregion

                #region R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2023-12-25" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q19);

                #endregion

                #region R0700_10_10C1_DB_SELECT_6_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2023-12-02" },
                { "WHOST_DTENDFIM" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_6_Query1", q20);

                #endregion

                #region R0700_10_10C1_DB_SELECT_7_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_7_Query1", q21);

                #endregion

                #region R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "Endos003" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q22);

                #endregion

                #region R0700_10_10C1_DB_SELECT_8_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "VG080_COD_GRUPO_SUSEP" , "Susep001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_8_Query1", q23);

                #endregion

                #region R0700_10_10C1_DB_SELECT_9_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_10_10C1_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_10_10C1_DB_SELECT_9_Query1", q24);

                #endregion

                #region R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "Endos003" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q25);

                #endregion

                #region R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_NRCERTIF" , "Cert002" },
                { "V0COBP_OCORHIST" , "Hist003" },
                { "V0COBP_DTINIVIG_ENDO" , "2023-12-16" },
                { "V0COBP_DTTERVIG_ENDO" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q26);

                #endregion

                #region R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_NRCERTIF" , "Cert002" },
                { "V0COBP_OCORHIST" , "Hist003" },
                { "V0COBP_DTINIVIG_ENDO" , "2023-12-15" },
                { "V0COBP_DTTERVIG_ENDO" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q27);

                #endregion

                #region R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , "Subes003" },
                { "WHOST_DTTERVIG" , "2023-12-14" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q28);

                #endregion

                #region R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , "2023-12-14" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q29);

                #endregion

                #region R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , "2023-12-14" },
                { "V0HCTB_NUM_APOLICE" , "789" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q30);

                #endregion

                #region R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG1" , "2023-12-02" },
                { "WHOST_DTTERVIG1" , "2023-12-14" },
                { "WHOST_DTINIVIG2" , "2023-12-02" },
                { "WHOST_DTTERVIG2" , "2023-12-14" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1", q31);

                #endregion

                #region R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , "2023-12-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1", q32);

                #endregion

                #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "Apol002" },
                { "V0ENDO_CODSUBES" , "Subes002" },
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "WHOST_NRPARCEL" , "4" },
                { "V0ENDO_FONTE" , "Source002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1", q33);

                #endregion

                #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0APOL_ORGAO" , "Org001" },
                { "V0APOL_RAMO" , "97" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1", q34);

                #endregion

                #region R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0HCTB_NRCERTIF" , "123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_OCORHIST" , "A" },
                { "V0HCTB_NRTIT" , "456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1", q35);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_1_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1", q36);

                #endregion

                #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.1" }
            });
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q37);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "Sicob001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1", q38);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0RCAP_NRRCAP" , "Rcap003" },
                { "V0RCAP_FONTE" , "Source004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1", q39);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Source004" },
                { "V0RCAP_NRRCAP" , "Rcap003" },
                { "V0RCAP_SITUACAO" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1", q40);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "Apol002" },
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0RCAP_NRRCAP" , "Rcap003" },
                { "V0RCAP_FONTE" , "Source004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1", q41);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "Bank001" },
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1", q42);

                #endregion

                #region VG0139B_CVGHISTCONT

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "VG082_NUM_CERTIFICADO" , "Cert003" },
                { "VG082_NUM_PARCELA" , "5" },
                { "VG082_NUM_TITULO" , "Title001" },
                { "VG082_OCORR_HISTORICO" , "Hist004" },
                { "VG082_COD_GRUPO_SUSEP" , "Susep002" },
                { "VG082_RAMO_EMISSOR" , "Ramo003" },
                { "VG082_COD_MODALIDADE" , "Mod002" },
                { "VG082_COD_COBERTURA" , "Cob001" },
                { "VG082_VLR_PREMIO_RAMO" , "450.0" },
                { "VG082_COD_USUARIO" , "User002" },
                { "VG082_DTH_ATUALIZACAO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("VG0139B_CVGHISTCONT");
                AppSettings.TestSet.DynamicData.Add("VG0139B_CVGHISTCONT", q43);

                #endregion

                #region R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "RcapCo001" },
                { "V1RCAC_OPERACAO" , "Oper002" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "Rcap001" },
                { "V1RCAC_FONTE" , "Source001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q44);

                #endregion

                #region R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Source001" },
                { "V1RCAC_NRRCAP" , "Rcap001" },
                { "V1RCAC_NRRCAPCO" , "RcapCo001" },
                { "V1RCAC_OPERACAO" , "Oper002" },
                { "V1SIST_DTMOVACB" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Pending" },
                { "V1RCAC_BCOAVISO" , "Bank001" },
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
                { "V1RCAC_VLRCAP" , "200.0" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Sit001" },
                { "V1RCAC_COD_EMPRESA" , "Comp003" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q45);

                #endregion

                #region R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "200.0" },
                { "V1RCAC_BCOAVISO" , "Bank001" },
                { "V1RCAC_AGEAVISO" , "Agency001" },
                { "V1RCAC_NRAVISO" , "Notice001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q46);

                #endregion

                #region VG0139B_V1APOLCOSCED

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , "Cong001" }
            });
                AppSettings.TestSet.DynamicData.Remove("VG0139B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("VG0139B_V1APOLCOSCED", q47);

                #endregion

                #region R1210_00_ACUMULA_IS_DB_SELECT_1_Query1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "0.2" },
                { "V0CBPR_IMPMORACID" , "0.3" },
                { "V0CBPR_IMPINVPERM" , "0.4" },
                { "V0CBPR_IMPAMDS" , "0.5" },
                { "V0CBPR_IMPDH" , "0.6" },
                { "V0CBPR_IMPDIT" , "5.0" },
                { "V0CBPR_PRMDIT" , "0.8" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1", q48);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "Order001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q49);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , "Apol004" },
                { "V0ORDC_NRENDOS" , "Endos004" },
                { "V0ORDC_CODCOSS" , "Coss001" },
                { "V0ORDC_ORDEM_CED" , "Ced001" },
                { "V0ORDC_COD_EMPRESA" , "Comp004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q50);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "Order001" },
                { "V1NCOS_CONGENER" , "Cong002" },
                { "V1NCOS_ORGAO" , "Org002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q51);

                #endregion

                #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "Apol005" },
                { "V0HISP_NRENDOS" , "Endos005" },
                { "V0HISP_NRPARCEL" , "6" },
                { "V0HISP_DACPARC" , "Dac004" },
                { "V0HISP_DTMOVTO" , "2023-12-01" },
                { "V0HISP_OPERACAO" , "Oper003" },
                { "V0HISP_OCORHIST" , "Hist005" },
                { "V0HISP_PRM_TARIFA" , "550.0" },
                { "V0HISP_VAL_DESCON" , "75.0" },
                { "V0HISP_VLPRMLIQ" , "600.0" },
                { "V0HISP_VLADIFRA" , "65.0" },
                { "V0HISP_VLCUSEMI" , "350.0" },
                { "V0HISP_VLIOCC" , "15.0" },
                { "V0HISP_VLPRMTOT" , "700.0" },
                { "V0HISP_VLPREMIO" , "750.0" },
                { "V0HISP_DTVENCTO" , "2023-12-30" },
                { "V0HISP_BCOCOBR" , "BankCobr002" },
                { "V0HISP_AGECOBR" , "AgencyCobr002" },
                { "V0HISP_NRAVISO" , "Notice002" },
                { "V0HISP_NRENDOCA" , "Endoca001" },
                { "V0HISP_SITCONTB" , "Sit002" },
                { "V0HISP_COD_USUAR" , "User003" },
                { "V0HISP_RNUDOC" , "Doc001" },
                { "V0HISP_DTQITBCO" , "2023-12-01" },
                { "V0HISP_COD_EMPRESA" , "Comp005" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q52);

                #endregion

                #region R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1

                var q53 = new DynamicData();
                q53.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "Endos001" },
                { "V0HCTB_NRTIT" , "456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1", q53);

                #endregion

                #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

                var q54 = new DynamicData();
                q54.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , "Apol006" },
                { "V0COBA_NRENDOS" , "Endos006" },
                { "V0COBA_NUM_ITEM" , "Item001" },
                { "V0COBA_OCORHIST" , "Hist006" },
                { "V0COBA_RAMOFR" , "Ramo004" },
                { "V0COBA_MODALIFR" , "Mod003" },
                { "V0COBA_COD_COBER" , "Cob002" },
                { "V0COBA_IMP_SEG_IX" , "800.0" },
                { "V0COBA_PRM_TAR_IX" , "850.0" },
                { "V0COBA_IMP_SEG_VR" , "900.0" },
                { "V0COBA_PRM_TAR_VR" , "950.0" },
                { "V0COBA_PCT_COBERT" , "0.9" },
                { "V0COBA_FATOR_MULT" , "1.1" },
                { "V0COBA_DATA_INIVI" , "2023-12-01" },
                { "V0COBA_DATA_TERVI" , "2023-12-31" },
                { "V0COBA_COD_EMPRESA" , "Comp006" },
                { "V0COBA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q54);

                #endregion

                #region R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_PRM_TAR_IX" , "850.0" },
                { "V0COBA_PRM_TAR_VR" , "950.0" },
                { "V0COBA_PCT_COBERT" , "0.9" },
                { "V0COBA_COD_COBER" , "Cob002" },
                { "V0COBA_NUM_APOL" , "Apol006" },
                { "V0COBA_NUM_ITEM" , "Item001" },
                { "V0COBA_OCORHIST" , "Hist006" },
                { "V0COBA_MODALIFR" , "Mod003" },
                { "V0COBA_NRENDOS" , "Endos006" },
                { "V0COBA_RAMOFR" , "Ramo004" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1", q55);

                #endregion

                #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , "Relat001" },
                { "V0EDIA_NUM_APOL" , "Apol007" },
                { "V0EDIA_NRENDOS" , "Endos007" },
                { "V0EDIA_NRPARCEL" , "7" },
                { "V0EDIA_DTMOVTO" , "2023-12-01" },
                { "V0EDIA_ORGAO" , "Org003" },
                { "V0EDIA_RAMO" , "Ramo005" },
                { "V0EDIA_FONTE" , "Source005" },
                { "V0EDIA_CONGENER" , "Cong003" },
                { "V0EDIA_CODCORR" , "Corr002" },
                { "V0EDIA_SITUACAO" , "Valid" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q56);

                #endregion

                #region R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , "User004" },
                { "V0RELA_DATA_SOLICITACAO" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "Sys001" },
                { "V0RELA_CODRELAT" , "Relat002" },
                { "V0RELA_NRCOPIAS" , "1" },
                { "V0RELA_QUANTIDADE" , "1" },
                { "V0RELA_PERI_INICIAL" , "2023-12-01" },
                { "V0RELA_PERI_FINAL" , "2023-12-31" },
                { "V0RELA_DATA_REFERENCIA" , "2023-12-01" },
                { "V0RELA_MES_REFERENCIA" , "12" },
                { "V0RELA_ANO_REFERENCIA" , "2023" },
                { "V0RELA_ORGAO" , "Org004" },
                { "V0RELA_FONTE" , "Source006" },
                { "V0RELA_CODPDT" , "Pdt001" },
                { "V0RELA_RAMO" , "Ramo006" },
                { "V0RELA_MODALIDA" , "Mod004" },
                { "V0RELA_CONGENER" , "Cong004" },
                { "V0RELA_NUM_APOLICE" , "Apol008" },
                { "V0RELA_NRENDOS" , "Endos008" },
                { "V0RELA_NRPARCEL" , "8" },
                { "V0RELA_NRCERTIF" , "Cert004" },
                { "V0RELA_NRTIT" , "Tit003" },
                { "V0RELA_CODSUBES" , "Subes004" },
                { "V0RELA_OPERACAO" , "Oper004" },
                { "V0RELA_COD_PLANO" , "Plan001" },
                { "V0RELA_OCORHIST" , "Hist007" },
                { "V0RELA_APOLIDER" , "Lider001" },
                { "V0RELA_ENDOSLID" , "EndosLid001" },
                { "V0RELA_NUM_PARC_LIDER" , "9" },
                { "V0RELA_NUM_SINISTRO" , "Sin001" },
                { "V0RELA_NUM_SINI_LIDER" , "SiniLid001" },
                { "V0RELA_NUM_ORDEM" , "Order002" },
                { "V0RELA_CODUNIMO" , "Unimo001" },
                { "V0RELA_CORRECAO" , "Corr003" },
                { "V0RELA_SITUACAO" , "Pending" },
                { "V0RELA_PREVIA_DEFINITIVA" , "Definitive" },
                { "V0RELA_ANAL_RESUMO" , "Summary" },
                { "V0RELA_COD_EMPRESA" , "Comp007" },
                { "V0RELA_PERI_RENOVACAO" , "2023-12-01" },
                { "V0RELA_PCT_AUMENTO" , "1.2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1", q57);

                #endregion
                #endregion
                #endregion


                var program = new VG0139B();
                program.Execute(SVG0139B_FILE_NAME_P, VG0139B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE.Value == 9);
            }
        }
    }
}