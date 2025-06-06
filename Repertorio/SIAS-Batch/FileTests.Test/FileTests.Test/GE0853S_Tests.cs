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
using static Code.GE0853S;
using Sias.Geral.DB2.GE0853S;

namespace FileTests.Test
{
    [Collection("GE0853S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0853S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0HISC_NRTIT" , ""},
                { "V0HISC_CODOPER" , ""},
                { "V0HISC_DTVENCTO" , ""},
                { "V0HISC_DTVENCTO_30" , ""},
                { "V0HISC_OPCAOPAG" , ""},
                { "V0HISC_VLPRMTOT" , ""},
                { "V0HISC_SITUACAO" , ""},
                { "V0HISC_OCORHIST" , ""},
                { "V0HISC_NRTITCOMP" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_DTADMISSAO" , ""},
                { "V0PROP_TIMESTAMP" , ""},
                { "V0PROP_PERIPGTO" , ""},
                { "V0PROP_OPCAOCAP" , ""},
                { "V0PROP_ESTR_COBR" , ""},
                { "V0PROP_ORIG_PRODU" , ""},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , ""},
                { "V0PROP_COBERADIC" , ""},
                { "V0PROP_CUSTOCAP" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0PARC_VLPRMTOT" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0PARC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion
            
            #region R0000_00_PRINCIPAL_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_UPDATE_1_Update1", q1);

            #endregion
            
            #region R0000_00_PRINCIPAL_DB_UPDATE_2_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_UPDATE_2_Update1", q2);

            #endregion

            #region R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1", q3);

            #endregion
            
            #region R1000_90_LEITURA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_90_LEITURA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2_Query1", q5);

            #endregion
            
            #region R1000_90_LEITURA_DB_UPDATE_2_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_90_LEITURA_DB_UPDATE_2_Update1", q6);

            #endregion

            #region R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1", q7);

            #endregion
            
            #region R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0HISC_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1", q8);

            #endregion
            
            #region R1051_00_CANCELA_PARCELA_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1051_00_CANCELA_PARCELA_DB_UPDATE_1_Update1", q9);

            #endregion
            
            #region R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1", q10);

            #endregion

            #region GE0853S_CDIFPAR

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_NRPARCELDIF" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_VLPRMTOT" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GE0853S_CDIFPAR", q11);

            #endregion

            #region GE0853S_CDIFANT

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V2DIFP_NRPARCDIF" , ""},
                { "V2DIFP_PRMVG" , ""},
                { "V2DIFP_PRMAP" , ""},
                { "V2DIFP_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GE0853S_CDIFANT", q12);

            #endregion
            
            #region R1051_00_CANCELA_PARCELA_DB_UPDATE_3_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1051_00_CANCELA_PARCELA_DB_UPDATE_3_Update1", q13);

            #endregion

            #region R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRPARCEL" , ""},
                { "V3DIFP_CODOPER" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0DIFP_NRPARCELDIF" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1", q14);

            #endregion
            
            #region R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCELDIF" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1_Update1", q15);

            #endregion
            
            #region R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRPARCEL" , ""},
                { "V0HISC_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1", q17);

            #endregion
            
            #region R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "WHOST_NRPARCEL_1" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "WHOST_CODOPER" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1_Insert1", q18);

            #endregion
            
            #region R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "WHOST_CODOPER" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2_Insert1", q19);

            #endregion
            
            #region R4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "WHOST_CODOPER1" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1", q20);

            #endregion

            #region GE0853S_CPARCAT

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PARC_AT" , ""},
                { "WS_NUM_TITULO_AT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GE0853S_CPARCAT", q21);

            #endregion

            #region R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1", q22);

            #endregion
            
            #region R4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V2DIFP_NRPARCDIF" , ""},
                { "V2DIFP_CODOPER" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V2DIFP_PRMVG" , ""},
                { "V2DIFP_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1", q23);

            #endregion
            
            #region R4000_20_LE_CDIFANT_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "WHOST_CODOPER1" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_20_LE_CDIFANT_DB_INSERT_1_Insert1", q24);

            #endregion
            
            #region R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_QTDPARATZ" , ""},
                { "V0HISC_DTVENCTO" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R5000_00_GERA_PROXIMA_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_SELECT_1_Query1", q26);

            #endregion

            #region R5000_00_GERA_PROXIMA_DB_SELECT_2_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_SELECT_2_Query1", q27);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "DESCON_NRPARCEL" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "DESCON_PRMVG" , ""},
                { "DESCON_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R5010_00_OCORHIST_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5010_00_OCORHIST_DB_SELECT_1_Query1", q29);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_INSERT_2_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_INSERT_2_Insert1", q30);

            #endregion

            #region R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1", q31);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1", q32);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_UPDATE_1_Update1", q33);

            #endregion
            
            #region R5010_10_OCORHIST_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_OCORHIST" , ""},
                { "WHOST_PRMVG" , ""},
                { "WHOST_PRMAP" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5010_10_OCORHIST_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R5010_10_OCORHIST_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5010_10_OCORHIST_DB_SELECT_1_Query1", q35);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_UPDATE_2_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRTIT" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_UPDATE_2_Update1", q36);

            #endregion

            #region R5000_00_GERA_PROXIMA_DB_SELECT_4_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_SELECT_4_Query1", q37);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_UPDATE_3_Update1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_UPDATE_3_Update1", q38);

            #endregion

            #region R5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0CONV_CODCONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1", q39);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_INSERT_5_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "WHOST_NRTIT" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0PARC_VLPRMTOT" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0HISC_SITUACAO" , ""},
                { "WHOST_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_INSERT_5_Insert1", q40);

            #endregion
            
            #region R5500_00_GERA_ATRASADAS_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRPARCEL" , ""},
                { "V0HISC_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5500_00_GERA_ATRASADAS_DB_UPDATE_1_Update1", q41);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0PARC_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1", q42);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_INSERT_6_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "WHOST_NRTIT" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0HISC_SITUACAO" , ""},
                { "WHOST_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_INSERT_6_Insert1", q43);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0HISC_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1", q44);

            #endregion

            #region R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0MOVF_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1", q45);

            #endregion
            
            #region R5540_10_OCORHIST_DB_UPDATE_1_Update1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_OCORHIST" , ""},
                { "WHOST_PRMVG" , ""},
                { "WHOST_PRMAP" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5540_10_OCORHIST_DB_UPDATE_1_Update1", q46);

            #endregion

            #region R5540_10_OCORHIST_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5540_10_OCORHIST_DB_SELECT_1_Query1", q47);

            #endregion
            
            #region R5000_00_GERA_PROXIMA_DB_INSERT_7_Insert1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO_ATR" , ""},
                { "V0CONV_CODCONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_INSERT_7_Insert1", q48);

            #endregion
            
            #region R5540_10_OCORHIST_DB_UPDATE_2_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5540_10_OCORHIST_DB_UPDATE_2_Update1", q49);

            #endregion
            
            #region R5540_10_OCORHIST_DB_INSERT_1_Insert1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO" , ""},
                { "V0CONV_CODCONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5540_10_OCORHIST_DB_INSERT_1_Insert1", q50);

            #endregion

            #region R5540_10_OCORHIST_DB_SELECT_2_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5540_10_OCORHIST_DB_SELECT_2_Query1", q51);

            #endregion
            
            #region R5540_10_OCORHIST_DB_UPDATE_3_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0PARC_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5540_10_OCORHIST_DB_UPDATE_3_Update1", q52);

            #endregion

            #region R5000_00_GERA_PROXIMA_DB_INSERT_8_Insert1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "WHOST_PARCELCAP" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_INSERT_8_Insert1", q53);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V0SEGU_TPINCLUS" , ""},
                { "V0SEGU_AGENCIADOR" , ""},
                { "V0SEGU_ITEM" , ""},
                { "V0SEGU_OCORHIST" , ""},
                { "V0SEGU_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1", q54);

            #endregion

            #region R6000_10_CANCEL_DB_UPDATE_1_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_UPDATE_1_Update1", q55);

            #endregion

            #region R6000_20_PROPAUTOM_DB_INSERT_1_Insert1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0FONT_PROPAUTOM" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0SEGU_TPINCLUS" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0SEGU_AGENCIADOR" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_IMPINVPERM" , ""},
                { "V0COBA_IMPDIT" , ""},
                { "V0COBA_PRMVG" , ""},
                { "V0COBA_PRMAP" , ""},
                { "V0FATC_DTREF" , ""},
                { "V0MOVI_DTMOVTO" , ""},
                { "V0SEGU_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_20_PROPAUTOM_DB_INSERT_1_Insert1", q56);

            #endregion

            #region R6000_20_PROPAUTOM_DB_UPDATE_1_Update1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , ""},
                { "V0PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_20_PROPAUTOM_DB_UPDATE_1_Update1", q57);

            #endregion

            #region R6000_10_CANCEL_DB_UPDATE_2_Update1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_OCORHIST" , ""},
                { "V0HISC_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_UPDATE_2_Update1", q58);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_1_Query1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_1_Query1", q59);

            #endregion

            #region R6000_10_CANCEL_DB_UPDATE_3_Update1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_UPDATE_3_Update1", q60);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_2_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_2_Query1", q61);

            #endregion

            #region R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1", q62);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_3_Query1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DTMOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_3_Query1", q63);

            #endregion

            #region R6000_10_CANCEL_DB_UPDATE_4_Update1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_UPDATE_4_Update1", q64);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_4_Query1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DTMOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_4_Query1", q65);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_5_Query1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_5_Query1", q66);

            #endregion
            
            #region R7000_00_QUITA_ATRASADA_DB_UPDATE_1_Update1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7000_00_QUITA_ATRASADA_DB_UPDATE_1_Update1", q67);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_6_Query1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_6_Query1", q68);

            #endregion
            
            #region R7000_00_QUITA_ATRASADA_DB_UPDATE_2_Update1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V2DIFP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7000_00_QUITA_ATRASADA_DB_UPDATE_2_Update1", q69);

            #endregion

            #region R7000_00_QUITA_ATRASADA_DB_INSERT_1_Insert1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "WHOST_PRMVG" , ""},
                { "WHOST_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7000_00_QUITA_ATRASADA_DB_INSERT_1_Insert1", q70);

            #endregion
            
            #region R7000_00_QUITA_ATRASADA_DB_UPDATE_3_Update1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "V2DIFP_NRPARCEL" , ""},
                { "V0HISC_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7000_00_QUITA_ATRASADA_DB_UPDATE_3_Update1", q71);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_7_Query1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "V0FATC_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_7_Query1", q72);

            #endregion
            
            #region R7000_00_QUITA_ATRASADA_DB_UPDATE_4_Update1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7000_00_QUITA_ATRASADA_DB_UPDATE_4_Update1", q73);

            #endregion

            #region R7500_00_QUITA_PROXIMA_DB_INSERT_1_Insert1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7500_00_QUITA_PROXIMA_DB_INSERT_1_Insert1", q74);

            #endregion

            #region R7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1", q75);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_8_Query1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "V0FATC_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_8_Query1", q76);

            #endregion

            #region R7500_00_QUITA_PROXIMA_DB_UPDATE_2_Update1

            var q77 = new DynamicData();
            q77.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRTIT" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7500_00_QUITA_PROXIMA_DB_UPDATE_2_Update1", q77);

            #endregion

            #region R7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1

            var q78 = new DynamicData();
            q78.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "WHOST_NRTIT" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1", q78);

            #endregion

            #region R7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1

            var q79 = new DynamicData();
            q79.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "WHOST_PRMVG" , ""},
                { "WHOST_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1", q79);

            #endregion

            #region R7500_00_QUITA_PROXIMA_DB_UPDATE_3_Update1

            var q80 = new DynamicData();
            q80.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0HISC_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7500_00_QUITA_PROXIMA_DB_UPDATE_3_Update1", q80);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_9_Query1

            var q81 = new DynamicData();
            q81.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_PRMVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_9_Query1", q81);

            #endregion

            #region R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1

            var q82 = new DynamicData();
            q82.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1", q82);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_10_Query1

            var q83 = new DynamicData();
            q83.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_10_Query1", q83);

            #endregion

            #region R7700_00_VERIFICA_REPASSES_DB_SELECT_2_Query1

            var q84 = new DynamicData();
            q84.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7700_00_VERIFICA_REPASSES_DB_SELECT_2_Query1", q84);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_11_Query1

            var q85 = new DynamicData();
            q85.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_11_Query1", q85);

            #endregion

            #region R8000_00_REPASSA_CDG_DB_SELECT_1_Query1

            var q86 = new DynamicData();
            q86.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_REPASSA_CDG_DB_SELECT_1_Query1", q86);

            #endregion

            #region R8000_00_REPASSA_CDG_DB_INSERT_1_Insert1

            var q87 = new DynamicData();
            q87.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V2DIFP_NRPARCEL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_REPASSA_CDG_DB_INSERT_1_Insert1", q87);

            #endregion

            #region R6000_10_CANCEL_DB_SELECT_12_Query1

            var q88 = new DynamicData();
            q88.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_CANCEL_DB_SELECT_12_Query1", q88);

            #endregion

            #region R8100_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q89 = new DynamicData();
            q89.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8100_00_REPASSA_SAF_DB_SELECT_1_Query1", q89);

            #endregion

            #region R8100_00_REPASSA_SAF_DB_INSERT_1_Insert1

            var q90 = new DynamicData();
            q90.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HISC_NRCERTIF" , ""},
                { "V2DIFP_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8100_00_REPASSA_SAF_DB_INSERT_1_Insert1", q90);

            #endregion

            #region R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1

            var q91 = new DynamicData();
            q91.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT_DEB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1", q91);

            #endregion

            #region R8105_00_ACERTA_PARCELA_DB_UPDATE_1_Update1

            var q92 = new DynamicData();
            q92.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8105_00_ACERTA_PARCELA_DB_UPDATE_1_Update1", q92);

            #endregion

            #region R8105_00_ACERTA_PARCELA_DB_UPDATE_2_Update1

            var q93 = new DynamicData();
            q93.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8105_00_ACERTA_PARCELA_DB_UPDATE_2_Update1", q93);

            #endregion

            #region R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1

            var q94 = new DynamicData();
            q94.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V4DIFP_CODOPER" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "DEVIDO_PRMVG" , ""},
                { "DEVIDO_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1", q94);

            #endregion

            #region R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1

            var q95 = new DynamicData();
            q95.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_PARCELAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1", q95);

            #endregion

            #region R8160_00_MAX_PARCELA_DB_SELECT_1_Query1

            var q96 = new DynamicData();
            q96.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PARCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8160_00_MAX_PARCELA_DB_SELECT_1_Query1", q96);

            #endregion

            #region R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1

            var q97 = new DynamicData();
            q97.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DT_VENC_PARC" , ""},
                { "WHOST_VL_PRM_TOTAL" , ""},
                { "WHOST_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1", q97);

            #endregion

            #region R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1

            var q98 = new DynamicData();
            q98.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VL_PRM_1PARC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1", q98);

            #endregion

            #region R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1

            var q99 = new DynamicData();
            q99.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DT_VENC_PARC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1", q99);

            #endregion

            #region R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1

            var q100 = new DynamicData();
            q100.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "WS_NUM_PARCELA_ATRD" , ""},
                { "WHOST_NUM_PARCELA_F" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "DESCON_PRMVG" , ""},
                { "DESCON_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1", q100);

            #endregion

            #region R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1

            var q101 = new DynamicData();
            q101.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PARCELA_PEND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1", q101);

            #endregion

            #region R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1

            var q102 = new DynamicData();
            q102.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_NSL" , ""},
                { "V0HCTA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1", q102);

            #endregion

            #region R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1

            var q103 = new DynamicData();
            q103.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_DTCREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1", q103);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0853S_Tests_Fact()
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

                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0HISC_NRTIT" , ""},
                { "V0HISC_CODOPER" , ""},
                { "V0HISC_DTVENCTO" , ""},
                { "V0HISC_DTVENCTO_30" , ""},
                { "V0HISC_OPCAOPAG" , ""},
                { "V0HISC_VLPRMTOT" , ""},
                { "V0HISC_SITUACAO" , ""},
                { "V0HISC_OCORHIST" , ""},
                { "V0HISC_NRTITCOMP" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_DTADMISSAO" , ""},
                { "V0PROP_TIMESTAMP" , ""},
                { "V0PROP_PERIPGTO" , ""},
                { "V0PROP_OPCAOCAP" , ""},
                { "V0PROP_ESTR_COBR" , ""},
                { "V0PROP_ORIG_PRODU" , ""},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , ""},
                { "V0PROP_COBERADIC" , ""},
                { "V0PROP_CUSTOCAP" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0PARC_VLPRMTOT" , ""},
                { "V0PARC_PRMVG" , "1"},
                { "V0PARC_PRMAP" , "1"},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0PARC_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);
               
                #endregion

                var program = new GE0853S();
                program.Execute(new GE0853S_REGISTRO_LINKAGE_GE0853S());

                var envList = AppSettings.TestSet.DynamicData["R0000_00_PRINCIPAL_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0000_00_PRINCIPAL_DB_UPDATE_2_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1000_90_LEITURA_DB_UPDATE_1_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1000_90_LEITURA_DB_UPDATE_2_Update1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1_Update1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R7000_00_QUITA_ATRASADA_DB_UPDATE_1_Update1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R7000_00_QUITA_ATRASADA_DB_UPDATE_2_Update1"].DynamicList;
                var envList8 = AppSettings.TestSet.DynamicData["R7000_00_QUITA_ATRASADA_DB_UPDATE_3_Update1"].DynamicList;
                var envList9 = AppSettings.TestSet.DynamicData["R7000_00_QUITA_ATRASADA_DB_UPDATE_4_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);
                Assert.True(envList8?.Count > 1);
                Assert.True(envList9?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0BANC_NRTIT", out var val1r) && val1r.Equals("0000000000000"));
                Assert.True(envList1[1].TryGetValue("CEDENTE_NUM_TITULO", out val1r) && val1r.Equals("0000000000000"));
                Assert.True(envList2[1].TryGetValue("V0BANC_NRTIT", out val1r) && val1r.Equals("0000000000000"));
                Assert.True(envList3[1].TryGetValue("CEDENTE_NUM_TITULO", out val1r) && val1r.Equals("0000000000000"));
                Assert.True(envList4[1].TryGetValue("V0DIFP_NRPARCELDIF", out val1r) && val1r.Equals("0000"));
                Assert.True(envList5[1].TryGetValue("V0HISC_NRPARCEL", out val1r) && val1r.Equals("0000"));
                Assert.True(envList6[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList7[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList8[1].TryGetValue("V2DIFP_NRPARCEL", out val1r) && val1r.Equals("0000"));
                Assert.True(envList9[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
            }
        }

        [Fact]
        public static void GE0853S_Tests_V0PROP_SITUACAO_8()
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

                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0HISC_NRTIT" , ""},
                { "V0HISC_CODOPER" , ""},
                { "V0HISC_DTVENCTO" , ""},
                { "V0HISC_DTVENCTO_30" , ""},
                { "V0HISC_OPCAOPAG" , ""},
                { "V0HISC_VLPRMTOT" , ""},
                { "V0HISC_SITUACAO" , ""},
                { "V0HISC_OCORHIST" , ""},
                { "V0HISC_NRTITCOMP" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , "8"},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_DTADMISSAO" , ""},
                { "V0PROP_TIMESTAMP" , ""},
                { "V0PROP_PERIPGTO" , ""},
                { "V0PROP_OPCAOCAP" , ""},
                { "V0PROP_ESTR_COBR" , ""},
                { "V0PROP_ORIG_PRODU" , ""},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , ""},
                { "V0PROP_COBERADIC" , ""},
                { "V0PROP_CUSTOCAP" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0PARC_VLPRMTOT" , ""},
                { "V0PARC_PRMVG" , "1"},
                { "V0PARC_PRMAP" , "1"},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0PARC_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                var program = new GE0853S();
                program.Execute(new GE0853S_REGISTRO_LINKAGE_GE0853S());

                var envList = AppSettings.TestSet.DynamicData["R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1051_00_CANCELA_PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1051_00_CANCELA_PARCELA_DB_UPDATE_3_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0HISC_NRCERTIF", out var val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList1[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList2[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList3[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                
            }
        }

        [Fact]
        public static void GE0853S_Tests_V0PROP_OPCAOPAG_3()
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

                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0HISC_NRTIT" , ""},
                { "V0HISC_CODOPER" , ""},
                { "V0HISC_DTVENCTO" , ""},
                { "V0HISC_DTVENCTO_30" , ""},
                { "V0HISC_OPCAOPAG" , ""},
                { "V0HISC_VLPRMTOT" , ""},
                { "V0HISC_SITUACAO" , ""},
                { "V0HISC_OCORHIST" , ""},
                { "V0HISC_NRTITCOMP" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_QTDPARATZ" , "2"},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_DTADMISSAO" , ""},
                { "V0PROP_TIMESTAMP" , ""},
                { "V0PROP_PERIPGTO" , ""},
                { "V0PROP_OPCAOCAP" , ""},
                { "V0PROP_ESTR_COBR" , ""},
                { "V0PROP_ORIG_PRODU" , ""},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , ""},
                { "V0PROP_COBERADIC" , ""},
                { "V0PROP_CUSTOCAP" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_OPCAOPAG" , "3"},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0PARC_VLPRMTOT" , "1"},
                { "V0PARC_PRMVG" , "1"},
                { "V0PARC_PRMAP" , "1"},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0PARC_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                AppSettings.TestSet.DynamicData.Remove("R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1");
                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1", q31);

                AppSettings.TestSet.DynamicData.Remove("R5000_00_GERA_PROXIMA_DB_SELECT_1_Query1");
                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMVG" , "20"},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R5000_00_GERA_PROXIMA_DB_SELECT_1_Query1", q26);

                #endregion

                var program = new GE0853S();
                program.Execute(new GE0853S_REGISTRO_LINKAGE_GE0853S());

                var envList = AppSettings.TestSet.DynamicData["R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R5000_00_GERA_PROXIMA_DB_UPDATE_1_Update1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R5000_00_GERA_PROXIMA_DB_UPDATE_2_Update1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R5000_00_GERA_PROXIMA_DB_INSERT_5_Insert1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1"].DynamicList;
                var envList8 = AppSettings.TestSet.DynamicData["R5000_00_GERA_PROXIMA_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);
                Assert.True(envList8?.Count > 1);

                Assert.True(envList[1].TryGetValue("WHOST_NRPARCEL_1", out var val1r) && val1r.Equals("0001"));
                Assert.True(envList1[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList2[1].TryGetValue("V0RELA_CODRELAT", out val1r) && val1r.Equals("VA0431B "));
                Assert.True(envList3[1].TryGetValue("V0PROP_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList4[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList5[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList6[1].TryGetValue("V0PROP_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList7[1].TryGetValue("V0PROP_QTDPARATZ", out val1r) && val1r.Equals("0002"));
                Assert.True(envList8[1].TryGetValue("DESCON_NRPARCEL", out val1r) && val1r.Equals("0001"));

            }
        }

        [Fact]
        public static void GE0853S_Tests_Fact_VLPRMTOT()
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

                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0HISC_NRCERTIF" , ""},
                { "V0HISC_NRPARCEL" , ""},
                { "V0HISC_NRTIT" , ""},
                { "V0HISC_CODOPER" , ""},
                { "V0HISC_DTVENCTO" , ""},
                { "V0HISC_DTVENCTO_30" , ""},
                { "V0HISC_OPCAOPAG" , ""},
                { "V0HISC_VLPRMTOT" , ""},
                { "V0HISC_SITUACAO" , ""},
                { "V0HISC_OCORHIST" , ""},
                { "V0HISC_NRTITCOMP" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_DTADMISSAO" , ""},
                { "V0PROP_TIMESTAMP" , ""},
                { "V0PROP_PERIPGTO" , ""},
                { "V0PROP_OPCAOCAP" , ""},
                { "V0PROP_ESTR_COBR" , ""},
                { "V0PROP_ORIG_PRODU" , ""},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , ""},
                { "V0PROP_COBERADIC" , ""},
                { "V0PROP_CUSTOCAP" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0PARC_VLPRMTOT" , "10"},
                { "V0PARC_PRMVG" , "1"},
                { "V0PARC_PRMAP" , "1"},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0PARC_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                var program = new GE0853S();
                program.Execute(new GE0853S_REGISTRO_LINKAGE_GE0853S());

                var envList = AppSettings.TestSet.DynamicData["R5540_10_OCORHIST_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R5540_10_OCORHIST_DB_UPDATE_2_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R5540_10_OCORHIST_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R5540_10_OCORHIST_DB_UPDATE_3_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0PARC_OCORHIST", out var val1r) && val1r.Equals("0001"));
                Assert.True(envList1[1].TryGetValue("WHOST_VLPREMIO", out val1r) && val1r.Equals("0000000000010.00"));
                Assert.True(envList2[1].TryGetValue("V0HISC_NRCERTIF", out val1r) && val1r.Equals("000000000000000"));
                Assert.True(envList3[1].TryGetValue("V0PARC_OCORHIST", out val1r) && val1r.Equals("0002"));
                
            }
        }
    }
}