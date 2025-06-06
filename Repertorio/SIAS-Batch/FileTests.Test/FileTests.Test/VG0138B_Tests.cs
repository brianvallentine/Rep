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
using static Code.VG0138B;

namespace FileTests.Test
{
    [Collection("VG0138B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class VG0138B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0138B_CHISTCTBL

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_SITUACAO" , ""},
                { "V0HCTB_NUM_APOLICE" , ""},
                { "V0HCTB_CODSUBES" , ""},
                { "V0HCTB_FONTE" , ""},
                { "V0HCTB_PRMVG" , ""},
                { "V0HCTB_PRMAP" , ""},
                { "V0HCTB_CODOPER" , ""},
                { "V0HCTB_NRCERTIF" , ""},
                { "V0HCTB_NRPARCEL" , ""},
                { "V0HCTB_NRTIT" , ""},
                { "V0HCTB_OCORHIST" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PRVG_ESTR_COBR" , ""},
                { "V0PRVG_ORIG_PRODU" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0138B_CHISTCTBL", q1);

            #endregion

            #region VG0138B_V1APOLCOSCED

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VG0138B_V1APOLCOSCED", q2);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q3);

            #endregion

            #region R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""},
                { "V0ENDO_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_IND_IOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q8);

            #endregion

            #region R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1", q9);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q10);

            #endregion

            #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , ""},
                { "V0ENDO_CODSUBES" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "WHOST_NRPARCEL" , ""},
                { "V0ENDO_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1", q13);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q14);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , ""},
                { "WHOST_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q15);

            #endregion

            #region R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0HCTB_NRCERTIF" , ""},
                { "V0HCTB_NRPARCEL" , ""},
                { "V0HCTB_OCORHIST" , ""},
                { "V0HCTB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q18);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1", q19);

            #endregion

            #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1210_00_ACUMULA_IS_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , ""},
                { "V0CBPR_IMPMORACID" , ""},
                { "V0CBPR_IMPINVPERM" , ""},
                { "V0CBPR_IMPAMDS" , ""},
                { "V0CBPR_IMPDH" , ""},
                { "V0CBPR_IMPDIT" , ""},
                { "V0CBPR_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1", q21);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , ""},
                { "V0ORDC_NRENDOS" , ""},
                { "V0ORDC_CODCOSS" , ""},
                { "V0ORDC_ORDEM_CED" , ""},
                { "V0ORDC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""},
                { "V1NCOS_CONGENER" , ""},
                { "V1NCOS_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q26);

            #endregion

            #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q27);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0138B_Tests_Fact()
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

                #region PARAMETERS

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_DTCURRENT" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VG0138B_CHISTCTBL

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_SITUACAO" , "Active" },
                { "V0HCTB_NUM_APOLICE" , "123456" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_FONTE" , "Internal" },
                { "V0HCTB_PRMVG" , "1000" },
                { "V0HCTB_PRMAP" , "500" },
                { "V0HCTB_CODOPER" , "150" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "12" },
                { "V0HCTB_NRTIT" , "TIT100" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0PROP_DTQITBCO" , "2023-12-01" },
                { "V0PROP_CODCLIEN" , "CL100" },
                { "V0PRVG_ESTR_COBR" , "MULT" },
                { "V0PRVG_ORIG_PRODU" , "EMPRE" },
                { "V0PROP_OCORHIST" , "None" },
            });
                AppSettings.TestSet.DynamicData.Remove("VG0138B_CHISTCTBL");
                AppSettings.TestSet.DynamicData.Add("VG0138B_CHISTCTBL", q1);

                #endregion

                #region VG0138B_V1APOLCOSCED

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , "General" }
            });
                AppSettings.TestSet.DynamicData.Remove("VG0138B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("VG0138B_V1APOLCOSCED", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NUM_APOLICE" , "123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , "Life" },
                { "V0APOL_MODALIDA" , "Full" },
                { "V0APOL_CODPRODU" , "PRD001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "123456" },
                { "V0ENDO_NRENDOS" , "1" },
                { "V0ENDO_CODSUBES" , "001" },
                { "V0ENDO_FONTE" , "Internal" },
                { "V0ENDO_NRPROPOS" , "PROP123" },
                { "V0ENDO_DATPRO" , "2023-12-01" },
                { "V0ENDO_DT_LIBER" , "2023-12-01" },
                { "V0ENDO_DTEMIS" , "2023-12-01" },
                { "V0ENDO_NRRCAP" , "RCAP100" },
                { "V0ENDO_VLRCAP" , "10000" },
                { "V0ENDO_BCORCAP" , "Bank1" },
                { "V0ENDO_AGERCAP" , "Agency1" },
                { "V0ENDO_DACRCAP" , "2023-12-01" },
                { "V0ENDO_IDRCAP" , "ID100" },
                { "V0ENDO_BCOCOBR" , "Bank2" },
                { "V0ENDO_AGECOBR" , "Agency2" },
                { "V0ENDO_DACCOBR" , "2023-12-01" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2024-12-01" },
                { "V0ENDO_CDFRACIO" , "FRC100" },
                { "V0ENDO_PCENTRAD" , "10" },
                { "V0ENDO_PCADICIO" , "5" },
                { "V0ENDO_PRESTA1" , "100" },
                { "V0ENDO_QTPARCEL" , "12" },
                { "V0ENDO_QTPRESTA" , "12" },
                { "V0ENDO_QTITENS" , "1" },
                { "V0ENDO_CODTXT" , "TXT100" },
                { "V0ENDO_CDACEITA" , "Yes" },
                { "V0ENDO_MOEDA_IMP" , "USD" },
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "Type1" },
                { "V0ENDO_COD_USUAR" , "USR100" },
                { "V0ENDO_OCORR_END" , "Event1" },
                { "V0ENDO_SITUACAO" , "Active" },
                { "V0ENDO_DATARCAP" , "2023-12-01" },
                { "V0ENDO_COD_EMPRESA" , "CMP100" },
                { "V0ENDO_CORRECAO" , "None" },
                { "V0ENDO_ISENTA_CST" , "No" },
                { "V0ENDO_DTVENCTO" , "2024-12-01" },
                { "V0ENDO_CFPREFIX" , "CF100" },
                { "V0ENDO_VLCUSEMI" , "500" },
                { "V0ENDO_RAMO" , "Life" },
                { "V0ENDO_CODPRODU" , "PRD001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q6);

                #endregion

                #region R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto" },
                { "V0ENDO_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_IND_IOF" , "No" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , "123456" },
                { "V0PARC_NRENDOS" , "1" },
                { "V0PARC_NRPARCEL" , "12" },
                { "V0PARC_DACPARC" , "2023-12-01" },
                { "V0PARC_FONTE" , "Internal" },
                { "V0PARC_NRTIT" , "TIT200" },
                { "V0PARC_PRM_TAR_IX" , "100" },
                { "V0PARC_VAL_DES_IX" , "10" },
                { "V0PARC_OTNPRLIQ" , "90" },
                { "V0PARC_OTNADFRA" , "5" },
                { "V0PARC_OTNCUSTO" , "5" },
                { "V0PARC_OTNIOF" , "2" },
                { "V0PARC_OTNTOTAL" , "102" },
                { "V0PARC_OCORHIST" , "None" },
                { "V0PARC_QTDDOC" , "1" },
                { "V0PARC_SITUACAO" , "Active" },
                { "V0PARC_COD_EMPRESA" , "CMP200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1", q9);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , "2024-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q10);

                #endregion

                #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "123456" },
                { "V0ENDO_CODSUBES" , "001" },
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "1" },
                { "WHOST_NRPARCEL" , "12" },
                { "V0ENDO_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "1" },
                { "V0APOL_RAMO" , "Life" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "1" },
                { "V0APOL_RAMO" , "Life" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1", q13);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q14);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , "001" },
                { "WHOST_DTTERVIG" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q15);

                #endregion

                #region R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "SIC100" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "1" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "12" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0HCTB_NRTIT" , "TIT100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q18);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1", q19);

                #endregion

                #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1210_00_ACUMULA_IS_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "0" },
                { "V0CBPR_IMPMORACID" , "0" },
                { "V0CBPR_IMPINVPERM" , "0" },
                { "V0CBPR_IMPAMDS" , "0" },
                { "V0CBPR_IMPDH" , "0" },
                { "V0CBPR_IMPDIT" , "0" },
                { "V0CBPR_PRMDIT" , "0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q22);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , "123456" },
                { "V0ORDC_NRENDOS" , "1" },
                { "V0ORDC_CODCOSS" , "COS100" },
                { "V0ORDC_ORDEM_CED" , "Order1" },
                { "V0ORDC_COD_EMPRESA" , "CMP300" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q23);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "1" },
                { "V1NCOS_CONGENER" , "General" },
                { "V1NCOS_ORGAO" , "Org1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q24);

                #endregion

                #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "123456" },
                { "V0HISP_NRENDOS" , "1" },
                { "V0HISP_NRPARCEL" , "12" },
                { "V0HISP_DACPARC" , "2023-12-01" },
                { "V0HISP_DTMOVTO" , "2023-12-01" },
                { "V0HISP_OPERACAO" , "Operation1" },
                { "V0HISP_OCORHIST" , "None" },
                { "V0HISP_PRM_TARIFA" , "100" },
                { "V0HISP_VAL_DESCON" , "10" },
                { "V0HISP_VLPRMLIQ" , "90" },
                { "V0HISP_VLADIFRA" , "5" },
                { "V0HISP_VLCUSEMI" , "5" },
                { "V0HISP_VLIOCC" , "2" },
                { "V0HISP_VLPRMTOT" , "102" },
                { "V0HISP_VLPREMIO" , "100" },
                { "V0HISP_DTVENCTO" , "2024-12-01" },
                { "V0HISP_BCOCOBR" , "Bank3" },
                { "V0HISP_AGECOBR" , "Agency3" },
                { "V0HISP_NRAVISO" , "Notice1" },
                { "V0HISP_NRENDOCA" , "Endo1" },
                { "V0HISP_SITCONTB" , "Active" },
                { "V0HISP_COD_USUAR" , "USR200" },
                { "V0HISP_RNUDOC" , "DOC100" },
                { "V0HISP_DTQITBCO" , "2023-12-01" },
                { "V0HISP_COD_EMPRESA" , "CMP400" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q25);

                #endregion

                #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , "123456" },
                { "V0COBA_NRENDOS" , "1" },
                { "V0COBA_NUM_ITEM" , "1" },
                { "V0COBA_OCORHIST" , "None" },
                { "V0COBA_RAMOFR" , "Life" },
                { "V0COBA_MODALIFR" , "Full" },
                { "V0COBA_COD_COBER" , "COV100" },
                { "V0COBA_IMP_SEG_IX" , "1000" },
                { "V0COBA_PRM_TAR_IX" , "100" },
                { "V0COBA_IMP_SEG_VR" , "10000" },
                { "V0COBA_PRM_TAR_VR" , "1000" },
                { "V0COBA_PCT_COBERT" , "100" },
                { "V0COBA_FATOR_MULT" , "1" },
                { "V0COBA_DATA_INIVI" , "2023-12-01" },
                { "V0COBA_DATA_TERVI" , "2024-12-01" },
                { "V0COBA_COD_EMPRESA" , "CMP500" },
                { "V0COBA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q26);

                #endregion

                #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , "RPT100" },
                { "V0EDIA_NUM_APOL" , "123456" },
                { "V0EDIA_NRENDOS" , "1" },
                { "V0EDIA_NRPARCEL" , "12" },
                { "V0EDIA_DTMOVTO" , "2023-12-01" },
                { "V0EDIA_ORGAO" , "Org2" },
                { "V0EDIA_RAMO" , "Life" },
                { "V0EDIA_FONTE" , "Internal" },
                { "V0EDIA_CONGENER" , "General" },
                { "V0EDIA_CODCORR" , "CORR100" },
                { "V0EDIA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q27);

                #endregion
                #endregion
                #endregion

                var program = new VG0138B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void VG0138B_Tests_ReturnCode99_Fact()
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

                #region PARAMETERS

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , "2023-12-01" },
                    { "V1SIST_DTCURRENT" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VG0138B_CHISTCTBL

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_SITUACAO" , "Active" },
                { "V0HCTB_NUM_APOLICE" , "123456" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_FONTE" , "Internal" },
                { "V0HCTB_PRMVG" , "1000" },
                { "V0HCTB_PRMAP" , "500" },
                { "V0HCTB_CODOPER" , "150" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "12" },
                { "V0HCTB_NRTIT" , "TIT100" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0PROP_DTQITBCO" , "2023-12-01" },
                { "V0PROP_CODCLIEN" , "CL100" },
                { "V0PRVG_ESTR_COBR" , "MULT" },
                { "V0PRVG_ORIG_PRODU" , "EMPRE" },
                { "V0PROP_OCORHIST" , "None" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VG0138B_CHISTCTBL");
                AppSettings.TestSet.DynamicData.Add("VG0138B_CHISTCTBL", q1);

                #endregion

                #region VG0138B_V1APOLCOSCED

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , "General" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VG0138B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("VG0138B_V1APOLCOSCED", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NUM_APOLICE" , "123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , "Life" },
                { "V0APOL_MODALIDA" , "Full" },
                { "V0APOL_CODPRODU" , "PRD001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "123456" },
                { "V0ENDO_NRENDOS" , "1" },
                { "V0ENDO_CODSUBES" , "001" },
                { "V0ENDO_FONTE" , "Internal" },
                { "V0ENDO_NRPROPOS" , "PROP123" },
                { "V0ENDO_DATPRO" , "2023-12-01" },
                { "V0ENDO_DT_LIBER" , "2023-12-01" },
                { "V0ENDO_DTEMIS" , "2023-12-01" },
                { "V0ENDO_NRRCAP" , "RCAP100" },
                { "V0ENDO_VLRCAP" , "10000" },
                { "V0ENDO_BCORCAP" , "Bank1" },
                { "V0ENDO_AGERCAP" , "Agency1" },
                { "V0ENDO_DACRCAP" , "2023-12-01" },
                { "V0ENDO_IDRCAP" , "ID100" },
                { "V0ENDO_BCOCOBR" , "Bank2" },
                { "V0ENDO_AGECOBR" , "Agency2" },
                { "V0ENDO_DACCOBR" , "2023-12-01" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2024-12-01" },
                { "V0ENDO_CDFRACIO" , "FRC100" },
                { "V0ENDO_PCENTRAD" , "10" },
                { "V0ENDO_PCADICIO" , "5" },
                { "V0ENDO_PRESTA1" , "100" },
                { "V0ENDO_QTPARCEL" , "12" },
                { "V0ENDO_QTPRESTA" , "12" },
                { "V0ENDO_QTITENS" , "1" },
                { "V0ENDO_CODTXT" , "TXT100" },
                { "V0ENDO_CDACEITA" , "Yes" },
                { "V0ENDO_MOEDA_IMP" , "USD" },
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "Type1" },
                { "V0ENDO_COD_USUAR" , "USR100" },
                { "V0ENDO_OCORR_END" , "Event1" },
                { "V0ENDO_SITUACAO" , "Active" },
                { "V0ENDO_DATARCAP" , "2023-12-01" },
                { "V0ENDO_COD_EMPRESA" , "CMP100" },
                { "V0ENDO_CORRECAO" , "None" },
                { "V0ENDO_ISENTA_CST" , "No" },
                { "V0ENDO_DTVENCTO" , "2024-12-01" },
                { "V0ENDO_CFPREFIX" , "CF100" },
                { "V0ENDO_VLCUSEMI" , "500" },
                { "V0ENDO_RAMO" , "Life" },
                { "V0ENDO_CODPRODU" , "PRD001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q6);

                #endregion

                #region R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto" },
                { "V0ENDO_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_IND_IOF" , "No" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , "123456" },
                { "V0PARC_NRENDOS" , "1" },
                { "V0PARC_NRPARCEL" , "12" },
                { "V0PARC_DACPARC" , "2023-12-01" },
                { "V0PARC_FONTE" , "Internal" },
                { "V0PARC_NRTIT" , "TIT200" },
                { "V0PARC_PRM_TAR_IX" , "100" },
                { "V0PARC_VAL_DES_IX" , "10" },
                { "V0PARC_OTNPRLIQ" , "90" },
                { "V0PARC_OTNADFRA" , "5" },
                { "V0PARC_OTNCUSTO" , "5" },
                { "V0PARC_OTNIOF" , "2" },
                { "V0PARC_OTNTOTAL" , "102" },
                { "V0PARC_OCORHIST" , "None" },
                { "V0PARC_QTDDOC" , "1" },
                { "V0PARC_SITUACAO" , "Active" },
                { "V0PARC_COD_EMPRESA" , "CMP200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1", q9);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , "2024-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q10);

                #endregion

                #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "123456" },
                { "V0ENDO_CODSUBES" , "001" },
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "1" },
                { "WHOST_NRPARCEL" , "12" },
                { "V0ENDO_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "1" },
                { "V0APOL_RAMO" , "Life" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "1" },
                { "V0APOL_RAMO" , "Life" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1", q13);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q14);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , "001" },
                { "WHOST_DTTERVIG" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q15);

                #endregion

                #region R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "SIC100" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "1" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "12" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0HCTB_NRTIT" , "TIT100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q18);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1", q19);

                #endregion

                #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1210_00_ACUMULA_IS_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "0" },
                { "V0CBPR_IMPMORACID" , "0" },
                { "V0CBPR_IMPINVPERM" , "0" },
                { "V0CBPR_IMPAMDS" , "0" },
                { "V0CBPR_IMPDH" , "0" },
                { "V0CBPR_IMPDIT" , "0" },
                { "V0CBPR_PRMDIT" , "0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q22);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , "123456" },
                { "V0ORDC_NRENDOS" , "1" },
                { "V0ORDC_CODCOSS" , "COS100" },
                { "V0ORDC_ORDEM_CED" , "Order1" },
                { "V0ORDC_COD_EMPRESA" , "CMP300" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q23);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "1" },
                { "V1NCOS_CONGENER" , "General" },
                { "V1NCOS_ORGAO" , "Org1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q24);

                #endregion

                #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "123456" },
                { "V0HISP_NRENDOS" , "1" },
                { "V0HISP_NRPARCEL" , "12" },
                { "V0HISP_DACPARC" , "2023-12-01" },
                { "V0HISP_DTMOVTO" , "2023-12-01" },
                { "V0HISP_OPERACAO" , "Operation1" },
                { "V0HISP_OCORHIST" , "None" },
                { "V0HISP_PRM_TARIFA" , "100" },
                { "V0HISP_VAL_DESCON" , "10" },
                { "V0HISP_VLPRMLIQ" , "90" },
                { "V0HISP_VLADIFRA" , "5" },
                { "V0HISP_VLCUSEMI" , "5" },
                { "V0HISP_VLIOCC" , "2" },
                { "V0HISP_VLPRMTOT" , "102" },
                { "V0HISP_VLPREMIO" , "100" },
                { "V0HISP_DTVENCTO" , "2024-12-01" },
                { "V0HISP_BCOCOBR" , "Bank3" },
                { "V0HISP_AGECOBR" , "Agency3" },
                { "V0HISP_NRAVISO" , "Notice1" },
                { "V0HISP_NRENDOCA" , "Endo1" },
                { "V0HISP_SITCONTB" , "Active" },
                { "V0HISP_COD_USUAR" , "USR200" },
                { "V0HISP_RNUDOC" , "DOC100" },
                { "V0HISP_DTQITBCO" , "2023-12-01" },
                { "V0HISP_COD_EMPRESA" , "CMP400" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q25);

                #endregion

                #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , "123456" },
                { "V0COBA_NRENDOS" , "1" },
                { "V0COBA_NUM_ITEM" , "1" },
                { "V0COBA_OCORHIST" , "None" },
                { "V0COBA_RAMOFR" , "Life" },
                { "V0COBA_MODALIFR" , "Full" },
                { "V0COBA_COD_COBER" , "COV100" },
                { "V0COBA_IMP_SEG_IX" , "1000" },
                { "V0COBA_PRM_TAR_IX" , "100" },
                { "V0COBA_IMP_SEG_VR" , "10000" },
                { "V0COBA_PRM_TAR_VR" , "1000" },
                { "V0COBA_PCT_COBERT" , "100" },
                { "V0COBA_FATOR_MULT" , "1" },
                { "V0COBA_DATA_INIVI" , "2023-12-01" },
                { "V0COBA_DATA_TERVI" , "2024-12-01" },
                { "V0COBA_COD_EMPRESA" , "CMP500" },
                { "V0COBA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q26);

                #endregion

                #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , "RPT100" },
                { "V0EDIA_NUM_APOL" , "123456" },
                { "V0EDIA_NRENDOS" , "1" },
                { "V0EDIA_NRPARCEL" , "12" },
                { "V0EDIA_DTMOVTO" , "2023-12-01" },
                { "V0EDIA_ORGAO" , "Org2" },
                { "V0EDIA_RAMO" , "Life" },
                { "V0EDIA_FONTE" , "Internal" },
                { "V0EDIA_CONGENER" , "General" },
                { "V0EDIA_CODCORR" , "CORR100" },
                { "V0EDIA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q27);

                #endregion
                #endregion
                #endregion

                var program = new VG0138B();
                program.Execute();

                Assert.True(program.RETURN_CODE.Value == 9);
            }
        }
    }
}