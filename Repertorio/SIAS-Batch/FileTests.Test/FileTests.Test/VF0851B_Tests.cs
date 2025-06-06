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
using static Code.VF0851B;

namespace FileTests.Test
{
    [Collection("VF0851B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class VF0851B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS

            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTCORRENTE" , ""},
                { "V1SIST_DTCORMAISQD" , ""},
                { "V1SIST_DTCORMENOQD" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VF0851B_CPROPVA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0851B_CPROPVA", q1);

            #endregion

            #region VF0851B_CPARCEL

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0PARC_VLPRMTOT" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0PARC_DTPROXVEN" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0851B_CPARCEL", q2);

            #endregion

            #region R0000_00_PRINCIPAL_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q4);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

            #endregion

            #region VF0851B_CDIFPAR

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0851B_CDIFPAR", q6);

            #endregion

            #region R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_VLPRMTOT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1", q8);

            #endregion

            #region R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1", q9);

            #endregion

            #region R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1", q10);

            #endregion

            #region R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0EVEN_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2_Update1", q12);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , ""},
                { "V0PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R1300_20_LOOP_PROPOSTA_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0FONT_PROPAUTOM" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0SEGU_TPINCLUS" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0SEGU_AGENCIADOR" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_IMPINVPERM" , ""},
                { "V0COBA_IMPDIT" , ""},
                { "V0COBA_PRMVG" , ""},
                { "V0COBA_PRMAP" , ""},
                { "V0FATC_DTREF" , ""},
                { "V0MOVI_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_20_LOOP_PROPOSTA_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DTMOVTO" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R1300_20_LOOP_PROPOSTA_DB_UPDATE_2_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_20_LOOP_PROPOSTA_DB_UPDATE_2_Update1", q18);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DTMOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1", q19);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0FATC_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1", q20);

            #endregion

            #region R1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0BANC_NRTIT" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0HCOB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1", q23);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0FATC_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1", q24);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0SEGU_TPINCLUS" , ""},
                { "V0SEGU_AGENCIADOR" , ""},
                { "V0SEGU_ITEM" , ""},
                { "V0SEGU_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1", q25);

            #endregion

            #region R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""},
                { "V0COMP_NRPARCEL" , ""},
                { "V0COMP_CODOPER" , ""},
                { "V0COMP_PRMDIFVG" , ""},
                { "V0COMP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1", q26);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_PRMVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1", q27);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1", q28);

            #endregion

            #region VF0851B_CPARDIF

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_NRPARCELDIF" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_DTVENCTO" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
                { "V0DIFP_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0851B_CPARDIF", q29);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1", q30);

            #endregion

            #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1", q31);

            #endregion

            #region R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""},
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R1600_00_GERA_DEBITO_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0PARC_VLPRMTOT" , ""},
                { "V0CONV_CODCONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_GERA_DEBITO_DB_INSERT_1_Insert1", q33);

            #endregion

            #region R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_OCORHIST" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R1700_00_QUITA_ATRASADA_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_QUITA_ATRASADA_DB_UPDATE_1_Update1", q35);

            #endregion

            #region VF0851B_CPLACOM

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0PLAC_CODPDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VF0851B_CPLACOM", q36);

            #endregion

            #region R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R1760_00_APROPRIA_DIFERENCA_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0DIFP_NRPARCELDIF" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_DTVENCTO" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1760_00_APROPRIA_DIFERENCA_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2_Update1", q39);

            #endregion

            #region R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1", q40);

            #endregion

            #region R1900_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_REPASSA_SAF_DB_SELECT_1_Query1", q41);

            #endregion

            #region R1900_00_REPASSA_SAF_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_REPASSA_SAF_DB_INSERT_1_Insert1", q42);

            #endregion

            #region R2100_00_GERA_EVENTO_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V0PDVF_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_GERA_EVENTO_DB_SELECT_1_Query1", q43);

            #endregion

            #region R2100_00_GERA_EVENTO_DB_UPDATE_1_Update1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0PDVF_OCORHIST" , ""},
                { "V0PLAC_CODPDT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_GERA_EVENTO_DB_UPDATE_1_Update1", q44);

            #endregion

            #region R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0PLAC_CODPDT" , ""},
                { "V0PDVF_OCORHIST" , ""},
                { "V0EVEN_NRCERTIF" , ""},
                { "V0EVEN_NRPARCEL" , ""},
                { "V0EVEN_CODEVEN" , ""},
                { "V0EVEN_CODOPER" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0EVEN_DTVENCTO" , ""},
                { "V0EVEN_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1", q45);

            #endregion

            #endregion
        }

        [Fact]
        public static void VF0851B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                PROTIT01_Tests.Load_Parameters();


                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTCORRENTE" , "2019-01-01"},
                { "V1SIST_DTCORMAISQD" , "2020-01-01"},
                { "V1SIST_DTCORMENOQD" , "2020-01-01"},
                { "V1SIST_DTMOVABE" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VF0851B_CPROPVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , "123456"},
                { "V0PROP_CODPRODU" , "1"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_FONTE" , "X"},
                { "V0PROP_NUM_APOLICE" , "123456"},
                { "V0PROP_CODSUBES" , "1"},
                { "V0PROP_CODCLIEN" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CPROPVA", q1);

                #endregion

                #region VF0851B_CPARCEL

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , "1"},
                { "V0PARC_PRMVG" , "2"},
                { "V0PARC_PRMAP" , "3"},
                { "V0PARC_VLPRMTOT" , "100"},
                { "V0PARC_OCORHIST" , "4"},
                { "V0PARC_DTPROXVEN" , "2020-01-01"},
                { "V0PARC_DTVENCTO" , "2020-01-01"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , "1"},
                { "V0PARC_PRMVG" , "2"},
                { "V0PARC_PRMAP" , "3"},
                { "V0PARC_VLPRMTOT" , "100"},
                { "V0PARC_OCORHIST" , "4"},
                { "V0PARC_DTPROXVEN" , "2020-01-01"},
                { "V0PARC_DTVENCTO" , "2020-01-01"},
                });
               /* q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , "1"},
                { "V0PARC_PRMVG" , "2"},
                { "V0PARC_PRMAP" , "3"},
                { "V0PARC_VLPRMTOT" , "100"},
                { "V0PARC_OCORHIST" , "4"},
                { "V0PARC_DTPROXVEN" , "2020-01-01"},
                { "V0PARC_DTVENCTO" , "2020-01-01"},
                });*/
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CPARCEL");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CPARCEL", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , "12456"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , "12"},
                { "V0OPCP_OPCAOPAG" , "2"},
                { "V0OPCP_AGECTADEB" , "206"},
                { "V0OPCP_OPRCTADEB" , "3"},
                { "V0OPCP_NUMCTADEB" , "817"},
                { "V0OPCP_DIGCTADEB" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region VF0851B_CDIFPAR

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , "1"},
                { "V0DIFP_CODOPER" , "0"},
                { "V0DIFP_PRMDIFVG" , "0"},
                { "V0DIFP_PRMDIFAP" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CDIFPAR");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CDIFPAR", q6);

                #endregion

                #region R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_VLPRMTOT" , "90"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , "123456"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2020-01-01"}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2020-01-01"}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1", q9);

                #endregion

                #region R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NSAS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1", q10);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , "14209"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DTMOVTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1", q19);


                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0FATC_DTREF" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1", q20);

                #endregion

                #region R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1", q23);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V0FATC_DTREF" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1", q24);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0SEGU_TPINCLUS" , "1"},
                { "V0SEGU_AGENCIADOR" , "0"},
                { "V0SEGU_ITEM" , "1"},
                { "V0SEGU_OCORHIST" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1", q25);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , "1092.00"},
                { "V0COBA_PRMVG" , "0.44772  "},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1", q27);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , "0"},
                { "V0COBA_PRMAP" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1", q28);

                #endregion

                #region VF0851B_CPARDIF

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , "1"},
                { "V0DIFP_NRPARCELDIF" , "2"},
                { "V0DIFP_CODOPER" , "3"},
                { "V0DIFP_DTVENCTO" , "2020-01-01"},
                { "V0DIFP_PRMDIFVG" , "4"},
                { "V0DIFP_PRMDIFAP" , "5"},
                { "V0DIFP_SITUACAO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CPARDIF");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CPARDIF", q29);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1", q30);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1", q31);

                #endregion

                #region VF0851B_CPLACOM

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "V0PLAC_CODPDT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CPLACOM");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CPLACOM", q36);

                #endregion

                #region R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , "100"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1", q40);

                #endregion

                #region R1900_00_REPASSA_SAF_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_REPASSA_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_REPASSA_SAF_DB_SELECT_1_Query1", q41);

                #endregion

                #region R2100_00_GERA_EVENTO_DB_SELECT_1_Query1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "V0PDVF_OCORHIST" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_GERA_EVENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_GERA_EVENTO_DB_SELECT_1_Query1", q43);

                #endregion

                #endregion

                var program = new VF0851B();
                
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                #region R0000_00_PRINCIPAL_DB_UPDATE_1_Update1              

                var envList1 = AppSettings.TestSet.DynamicData["R0000_00_PRINCIPAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("V0BANC_NRTIT", out var V0BANC_NRTIT) && V0BANC_NRTIT == "0000000012459");
                
                #endregion

                //V0DIFP_VLPRMTOT >= V0PARC_VLPRMTOT
                #region R1700_00_QUITA_ATRASADA_DB_UPDATE_1_Update1              
                /*
                var envList12 = AppSettings.TestSet.DynamicData["R1700_00_QUITA_ATRASADA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList12?.Count > 1);
                Assert.True(envList12[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF12) && V0PROP_NRCERTIF12 == "000000000123456");
                Assert.True(envList12[1].TryGetValue("V0PARC_NRPARCEL", out var V0PARC_NRPARCEL12) && V0PARC_NRPARCEL12 == "0001");
                */
                #endregion

                #region R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2_Update1              
                /*
                var envList15 = AppSettings.TestSet.DynamicData["R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList15?.Count > 1);
                Assert.True(envList15[1].TryGetValue("V0PARC_NRPARCEL", out var V0PARC_NRPARCEL15) && V0PARC_NRPARCEL15 == "0001");
                Assert.True(envList15[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF15) && V0PROP_NRCERTIF15 == "000000000123456");
                */
                #endregion

                //V0DIFP_VLPRMTOT < V0PARC_VLPRMTOT / V0PROP_SITUACAO = 3
                #region R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1              

              /*  var envList2 = AppSettings.TestSet.DynamicData["R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF) && V0PROP_NRCERTIF == "000000000123456");
              */
                #endregion

                #region R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2_Update1              
                /*
                var envList3 = AppSettings.TestSet.DynamicData["R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF1) && V0PROP_NRCERTIF1 == "000000000123456");
                Assert.True(envList3[1].TryGetValue("V0EVEN_NRPARCEL", out var V0EVEN_NRPARCEL) && V0EVEN_NRPARCEL == "0001");
                Assert.True(envList3[1].TryGetValue("V0HCOB_NRTIT", out var V0HCOB_NRTIT) && V0HCOB_NRTIT == "0000000123456");
                */
                #endregion


                #region R2100_00_GERA_EVENTO_DB_UPDATE_1_Update1              
                
                var envList17 = AppSettings.TestSet.DynamicData["R2100_00_GERA_EVENTO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList17?.Count > 1);
                Assert.True(envList17[1].TryGetValue("V0PDVF_OCORHIST", out var V0PDVF_OCORHIST) && V0PDVF_OCORHIST == "0001");
                Assert.True(envList17[1].TryGetValue("V0PLAC_CODPDT", out var V0PLAC_CODPDT) && V0PLAC_CODPDT == "000000001");
                
                #endregion

                #region R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1              
                
                var envList18 = AppSettings.TestSet.DynamicData["R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList18?.Count > 1);
                Assert.True(envList18[1].TryGetValue("V0PLAC_CODPDT", out var V0PLAC_CODPDT18) && V0PLAC_CODPDT18 == "000000001");
                Assert.True(envList18[1].TryGetValue("V0PDVF_OCORHIST", out var V0PDVF_OCORHIST18) && V0PDVF_OCORHIST18 == "0001");
                Assert.True(envList18[1].TryGetValue("V0EVEN_NRCERTIF", out var V0EVEN_NRCERTIF) && V0EVEN_NRCERTIF == "000000000123456");
                Assert.True(envList18[1].TryGetValue("V0EVEN_NRPARCEL", out var V0EVEN_NRPARCEL18) && V0EVEN_NRPARCEL18 == "0001");
                Assert.True(envList18[1].TryGetValue("V0EVEN_CODEVEN", out var V0EVEN_CODEVEN) && V0EVEN_CODEVEN == "0010");
                Assert.True(envList18[1].TryGetValue("V0EVEN_CODOPER", out var V0EVEN_CODOPER) && V0EVEN_CODOPER == "0000");
                Assert.True(envList18[1].TryGetValue("V1SIST_DTMOVABE", out var V1SIST_DTMOVABE) && V1SIST_DTMOVABE == "2020-01-01");
                Assert.True(envList18[1].TryGetValue("V0EVEN_DTVENCTO", out var V0EVEN_DTVENCTO) && V0EVEN_DTVENCTO == "2020-01-01");
                Assert.True(envList18[1].TryGetValue("V0EVEN_VLPRMTOT", out var V0EVEN_VLPRMTOT) && V0EVEN_VLPRMTOT == "0000000000100.00");
                
                #endregion



                //V0PROP_SITUACAO <> "3"
                #region R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1              
                /*
                var envList4 = AppSettings.TestSet.DynamicData["R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                Assert.True(envList4[1].TryGetValue("V0FONT_PROPAUTOM", out var V0FONT_PROPAUTOM) && V0FONT_PROPAUTOM == "0000");
                Assert.True(envList4[1].TryGetValue("V0PROP_FONTE", out var V0PROP_FONTE) && V0PROP_FONTE == "0000");
                */
                #endregion

                #region R1300_20_LOOP_PROPOSTA_DB_INSERT_1_Insert1              

               /* var envList5 = AppSettings.TestSet.DynamicData["R1300_20_LOOP_PROPOSTA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5?.Count > 1);
                Assert.True(envList5[1].TryGetValue("V0PROP_NUM_APOLICE", out var V0PROP_NUM_APOLICE) && V0PROP_NUM_APOLICE == "0000000123456");
                Assert.True(envList5[1].TryGetValue("V0PROP_CODSUBES", out var V0PROP_CODSUBES) && V0PROP_CODSUBES == "0001");
                Assert.True(envList5[1].TryGetValue("V0PROP_FONTE", out var V0PROP_FONTE1) && V0PROP_FONTE1 == "0000");
                Assert.True(envList5[1].TryGetValue("V0FONT_PROPAUTOM", out var V0FONT_PROPAUTOM1) && V0FONT_PROPAUTOM1 == "000014210");
                Assert.True(envList5[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF2) && V0PROP_NRCERTIF2 == "000000000123456");
                Assert.True(envList5[1].TryGetValue("V0SEGU_TPINCLUS", out var V0SEGU_TPINCLUS) && V0SEGU_TPINCLUS == "1");
                Assert.True(envList5[1].TryGetValue("V0SEGU_AGENCIADOR", out var V0SEGU_AGENCIADOR) && V0SEGU_AGENCIADOR == "000000000");
                Assert.True(envList5[1].TryGetValue("V0OPCP_PERIPGTO", out var V0OPCP_PERIPGTO) && V0OPCP_PERIPGTO == "0012");
                Assert.True(envList5[1].TryGetValue("V0COBA_IMPMORNATU", out var V0COBA_IMPMORNATU) && V0COBA_IMPMORNATU == "0000000109200.00");
                Assert.True(envList5[1].TryGetValue("V0COBA_IMPMORACID", out var V0COBA_IMPMORACID) && V0COBA_IMPMORACID == "0000000000000.00");
                Assert.True(envList5[1].TryGetValue("V0COBA_IMPINVPERM", out var V0COBA_IMPINVPERM) && V0COBA_IMPINVPERM == "0000000000000.00");
                Assert.True(envList5[1].TryGetValue("V0COBA_IMPDIT", out var V0COBA_IMPDIT) && V0COBA_IMPDIT == "0000000000000.00");
                Assert.True(envList5[1].TryGetValue("V0COBA_PRMVG", out var V0COBA_PRMVG) && V0COBA_PRMVG == "0000000000.00000");
                Assert.True(envList5[1].TryGetValue("V0FATC_DTREF", out var V0FATC_DTREF) && V0FATC_DTREF == "2020-01-01");
                Assert.True(envList5[1].TryGetValue("V0MOVI_DTMOVTO", out var V0MOVI_DTMOVTO) && V0MOVI_DTMOVTO == "2020-01-01");*/


                #endregion

               /* #region R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1_Update1              

                var envList6 = AppSettings.TestSet.DynamicData["R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList6?.Count > 1);
                Assert.True(envList6[1].TryGetValue("V0MOVI_DTMOVTO", out var V0MOVI_DTMOVTO2) && V0MOVI_DTMOVTO2 == "2020-01-01");
                Assert.True(envList6[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF3) && V0PROP_NRCERTIF3 == "000000000123456");

                #endregion*/

                //AREA_DE_WORK.WS_CONT_ATZ < 3 
                #region R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1              

                var envList7 = AppSettings.TestSet.DynamicData["R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7?.Count > 1);
                Assert.True(envList7[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF4) && V0PROP_NRCERTIF4 == "000000000123456");
                Assert.True(envList7[1].TryGetValue("V0HCOB_NRPARCEL", out var V0HCOB_NRPARCEL) && V0HCOB_NRPARCEL == "0001");
                Assert.True(envList7[1].TryGetValue("V0BANC_NRTIT", out var V0BANC_NRTIT1) && V0BANC_NRTIT1 == "0000000012459");
                Assert.True(envList7[1].TryGetValue("V0HCOB_DTVENCTO", out var V0HCOB_DTVENCTO) && V0HCOB_DTVENCTO == "2020-01-01");
                Assert.True(envList7[1].TryGetValue("WHOST_VLPREMIO", out var WHOST_VLPREMIO) && WHOST_VLPREMIO == "0000000000100.00");
                Assert.True(envList7[1].TryGetValue("V0OPCP_OPCAOPAG", out var V0OPCP_OPCAOPAG) && V0OPCP_OPCAOPAG == "2");
                Assert.True(envList7[1].TryGetValue("V0HCOB_CODOPER", out var V0HCOB_CODOPER) && V0HCOB_CODOPER == "0136");

                #endregion

                #region R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1              

                var envList8 = AppSettings.TestSet.DynamicData["R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList8?.Count > 1);
                Assert.True(envList8[1].TryGetValue("V0BANC_NRTIT", out var V0BANC_NRTIT8) && V0BANC_NRTIT8 == "0000000012459");
                Assert.True(envList8[1].TryGetValue("V0COMP_NRPARCEL", out var V0COMP_NRPARCEL) && V0COMP_NRPARCEL == "0001");
                Assert.True(envList8[1].TryGetValue("V0COMP_CODOPER", out var V0COMP_CODOPER) && V0COMP_CODOPER == "0121");
                Assert.True(envList8[1].TryGetValue("V0COMP_PRMDIFVG", out var V0COMP_PRMDIFVG) && V0COMP_PRMDIFVG == "0000000000002.00");
                Assert.True(envList8[1].TryGetValue("V0COMP_PRMDIFAP", out var V0COMP_PRMDIFAP) && V0COMP_PRMDIFAP == "0000000000003.00");

                #endregion

                #region R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1              

                /*var envList9 = AppSettings.TestSet.DynamicData["R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList9?.Count > 1);
                Assert.True(envList9[1].TryGetValue("V0BANC_NRTIT", out var V0BANC_NRTIT2) && V0BANC_NRTIT2 == "0000000012450");
                Assert.True(envList9[1].TryGetValue("V0DIFP_NRPARCEL", out var V0DIFP_NRPARCEL) && V0DIFP_NRPARCEL == "0001");
                Assert.True(envList9[1].TryGetValue("V0DIFP_CODOPER", out var V0DIFP_CODOPER) && V0DIFP_CODOPER == "0000");
                Assert.True(envList9[1].TryGetValue("V0DIFP_PRMDIFVG", out var V0DIFP_PRMDIFVG) && V0DIFP_PRMDIFVG == "0000000000000.00");
                Assert.True(envList9[1].TryGetValue("V0DIFP_PRMDIFAP", out var V0DIFP_PRMDIFAP) && V0DIFP_PRMDIFAP == "0000000000000.00");*/

                #endregion

                #region R1600_00_GERA_DEBITO_DB_INSERT_1_Insert1              

                var envList10 = AppSettings.TestSet.DynamicData["R1600_00_GERA_DEBITO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList10?.Count > 1);
                Assert.True(envList10[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF5) && V0PROP_NRCERTIF5 == "000000000123456");
                Assert.True(envList10[1].TryGetValue("V0PARC_NRPARCEL", out var V0PARC_NRPARCEL) && V0PARC_NRPARCEL == "0001");
                Assert.True(envList10[1].TryGetValue("V0PARC_OCORHIST", out var V0PARC_OCORHIST) && V0PARC_OCORHIST == "0005");
                Assert.True(envList10[1].TryGetValue("V0OPCP_AGECTADEB", out var V0OPCP_AGECTADEB) && V0OPCP_AGECTADEB == "0206");
                Assert.True(envList10[1].TryGetValue("V0OPCP_OPRCTADEB", out var V0OPCP_OPRCTADEB) && V0OPCP_OPRCTADEB == "0003");
                Assert.True(envList10[1].TryGetValue("V0OPCP_NUMCTADEB", out var V0OPCP_NUMCTADEB) && V0OPCP_NUMCTADEB == "0000000000817");
                Assert.True(envList10[1].TryGetValue("V0OPCP_DIGCTADEB", out var V0OPCP_DIGCTADEB) && V0OPCP_DIGCTADEB == "0000");
                Assert.True(envList10[1].TryGetValue("V0HCOB_DTVENCTO", out var V0HCOB_DTVENCTO1) && V0HCOB_DTVENCTO1 == "2020-01-01");
                Assert.True(envList10[1].TryGetValue("V0PARC_VLPRMTOT", out var V0PARC_VLPRMTOT) && V0PARC_VLPRMTOT == "0000000000100.00");
                Assert.True(envList10[1].TryGetValue("V0CONV_CODCONV", out var V0CONV_CODCONV) && V0CONV_CODCONV == "0001");

                #endregion

                #region R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1              

                var envList11 = AppSettings.TestSet.DynamicData["R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList11?.Count > 1);
                Assert.True(envList11[1].TryGetValue("V0PARC_OCORHIST", out var V0PARC_OCORHIST1) && V0PARC_OCORHIST1 == "0005");
                Assert.True(envList11[1].TryGetValue("V0PROP_NRCERTIF", out var V0PROP_NRCERTIF11) && V0PROP_NRCERTIF11 == "000000000123456");
                Assert.True(envList11[1].TryGetValue("V0PARC_NRPARCEL", out var V0PARC_NRPARCEL11) && V0PARC_NRPARCEL11 == "0001");


                #endregion



                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VF0851B_Tests99_Fact()
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

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTCORRENTE" , "2019-01-01"},
                { "V1SIST_DTCORMAISQD" , "2020-01-01"},
                { "V1SIST_DTCORMENOQD" , "2020-01-01"},
                { "V1SIST_DTMOVABE" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VF0851B_CPROPVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , "123456"},
                { "V0PROP_CODPRODU" , "1"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_FONTE" , "X"},
                { "V0PROP_NUM_APOLICE" , "123456"},
                { "V0PROP_CODSUBES" , "1"},
                { "V0PROP_CODCLIEN" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CPROPVA", q1);

                #endregion

                #region VF0851B_CPARCEL

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , "1"},
                { "V0PARC_PRMVG" , "2"},
                { "V0PARC_PRMAP" , "3"},
                { "V0PARC_VLPRMTOT" , "100"},
                { "V0PARC_OCORHIST" , "4"},
                { "V0PARC_DTPROXVEN" , "2020-01-01"},
                { "V0PARC_DTVENCTO" , "2020-01-01"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , "1"},
                { "V0PARC_PRMVG" , "2"},
                { "V0PARC_PRMAP" , "3"},
                { "V0PARC_VLPRMTOT" , "100"},
                { "V0PARC_OCORHIST" , "4"},
                { "V0PARC_DTPROXVEN" , "2020-01-01"},
                { "V0PARC_DTVENCTO" , "2020-01-01"},
                });
                /* q2.AddDynamic(new Dictionary<string, string>{
                 { "V0PARC_NRPARCEL" , "1"},
                 { "V0PARC_PRMVG" , "2"},
                 { "V0PARC_PRMAP" , "3"},
                 { "V0PARC_VLPRMTOT" , "100"},
                 { "V0PARC_OCORHIST" , "4"},
                 { "V0PARC_DTPROXVEN" , "2020-01-01"},
                 { "V0PARC_DTVENCTO" , "2020-01-01"},
                 });*/
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CPARCEL");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CPARCEL", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , "12"},
                { "V0OPCP_OPCAOPAG" , "2"},
                { "V0OPCP_AGECTADEB" , "206"},
                { "V0OPCP_OPRCTADEB" , "3"},
                { "V0OPCP_NUMCTADEB" , "817"},
                { "V0OPCP_DIGCTADEB" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region VF0851B_CDIFPAR

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , "1"},
                { "V0DIFP_CODOPER" , "0"},
                { "V0DIFP_PRMDIFVG" , "0"},
                { "V0DIFP_PRMDIFAP" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CDIFPAR");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CDIFPAR", q6);

                #endregion

                #region R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_VLPRMTOT" , "90"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , "123456"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2020-01-01"}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2020-01-01"}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1", q9);

                #endregion

                #region R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NSAS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1", q10);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , "14209"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DTMOVTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1", q19);


                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0FATC_DTREF" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1", q20);

                #endregion

                #region R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1", q23);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V0FATC_DTREF" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1", q24);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0SEGU_TPINCLUS" , "1"},
                { "V0SEGU_AGENCIADOR" , "0"},
                { "V0SEGU_ITEM" , "1"},
                { "V0SEGU_OCORHIST" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1", q25);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , "1092.00"},
                { "V0COBA_PRMVG" , "0.44772  "},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1", q27);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , "0"},
                { "V0COBA_PRMAP" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1", q28);

                #endregion

                #region VF0851B_CPARDIF

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , "1"},
                { "V0DIFP_NRPARCELDIF" , "2"},
                { "V0DIFP_CODOPER" , "3"},
                { "V0DIFP_DTVENCTO" , "2020-01-01"},
                { "V0DIFP_PRMDIFVG" , "4"},
                { "V0DIFP_PRMDIFAP" , "5"},
                { "V0DIFP_SITUACAO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CPARDIF");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CPARDIF", q29);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1", q30);

                #endregion

                #region R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1", q31);

                #endregion

                #region VF0851B_CPLACOM

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "V0PLAC_CODPDT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("VF0851B_CPLACOM");
                AppSettings.TestSet.DynamicData.Add("VF0851B_CPLACOM", q36);

                #endregion

                #region R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , "100"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1", q40);

                #endregion

                #region R1900_00_REPASSA_SAF_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_REPASSA_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_REPASSA_SAF_DB_SELECT_1_Query1", q41);

                #endregion

                #region R2100_00_GERA_EVENTO_DB_SELECT_1_Query1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "V0PDVF_OCORHIST" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_GERA_EVENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_GERA_EVENTO_DB_SELECT_1_Query1", q43);

                #endregion

                #endregion

                var program = new VF0851B();

                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                Assert.True(program.RETURN_CODE == 99);
            }
        }



    }
}