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
using static Code.VF0853B;

namespace FileTests.Test
{
    [Collection("VF0853B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VF0853B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTCORMAISQD" , ""},
                { "V1SIST_DTCORMAIS1D" , ""},
                { "V1SIST_DTCORMAIS1M" , ""},
                { "V1SIST_DTCORMAIS3M" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VF0853B_CPROPVA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0853B_CPROPVA", q1);

            #endregion

            #region VF0853B_CDIFPAR

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_DTVENCTO" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_VLPRMTOT" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
                { "V0DIFP_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0853B_CDIFPAR", q2);

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
                { "V0SEGU_DTINISAF" , ""},
                { "V0SEGU_DTINIRTO" , ""},
                { "V0SEGU_DTINIDIT" , ""},
                { "V0SEGU_DTINIDFT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIA_DEBITO" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q6);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTOTANT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0PARC_SITUACAO" , ""},
                { "V0PARC_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1", q11);

            #endregion

            #region R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "W_TITULO" , ""},
                { "V0COMP_NRPARCEL" , ""},
                { "V0COMP_CODOPER" , ""},
                { "V0COMP_PRMDIFVG" , ""},
                { "V0COMP_PRMDIFAP" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0HICB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO" , ""},
                { "V0CONV_CODCONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "W_TITULO" , ""},
                { "V0HICB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0HICB_SITUACAO" , ""},
                { "V0HICB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1", q16);

            #endregion

            #region VF0853B_CCMPTIT

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0COMP_NRPARCEL" , ""},
                { "V0COMP_CODOPER" , ""},
                { "V0COMP_PRMDIFVG" , ""},
                { "V0COMP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0853B_CCMPTIT", q17);

            #endregion

            #region R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PRMVG" , ""},
                { "WHOST_PRMAP" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R1530_00_LOOP_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0DIFP_NRPARCEL" , ""},
                { "V3DIFP_CODOPER" , ""},
                { "V0DIFP_DTVENCTO" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1530_00_LOOP_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0COMP_NRPARCEL" , ""},
                { "V0COMP_PRMDIFVG" , ""},
                { "V0COMP_PRMDIFAP" , ""},
                { "V0COMP_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q23);

            #endregion

            #region R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0RSAF_CODOPER" , ""},
                { "V0PROP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1", q24);

            #endregion

            #endregion
        }

        [Fact]
        public static void VF0853B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE#region PARAMETERS
                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTCORMAISQD" , ""},
                    { "V1SIST_DTCORMAIS1D" , ""},
                    { "V1SIST_DTCORMAIS1M" , ""},
                    { "V1SIST_DTCORMAIS3M" , "2025-12-01"},
                    { "V1SIST_DTMOVABE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VF0853B_CPROPVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_SITUACAO" , "6"},
                    { "V0PROP_DTVENCTO" , "2025-12-01"},
                    { "V0PROP_DTPROXVEN" , "2025-12-01"},
                    { "V0PROP_QTDPARATZ" , "0"},
                    { "V0PROP_TIMESTAMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0853B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VF0853B_CPROPVA", q1);

                #endregion

                #region VF0853B_CDIFPAR

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0DIFP_NRPARCEL" , ""},
                    { "V0DIFP_DTVENCTO" , ""},
                    { "V0DIFP_CODOPER" , ""},
                    { "V0DIFP_VLPRMTOT" , ""},
                    { "V0DIFP_PRMDIFVG" , ""},
                    { "V0DIFP_PRMDIFAP" , ""},
                    { "V0DIFP_NUM_PARCELA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0853B_CDIFPAR");
                AppSettings.TestSet.DynamicData.Add("VF0853B_CDIFPAR", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_UPDATE_1_Update1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0BANC_NRTIT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_UPDATE_1_Update1", q3);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0BANC_NRTIT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0SEGU_DTINISAF" , ""},
                    { "V0SEGU_DTINIRTO" , ""},
                    { "V0SEGU_DTINIDIT" , ""},
                    { "V0SEGU_DTINIDFT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0OPCP_OPCAOPAG" , "0"},
                    { "V0OPCP_PERIPGTO" , "5"},
                    { "V0OPCP_DIA_DEBITO" , ""},
                    { "V0OPCP_AGECTADEB" , ""},
                    { "V0OPCP_OPRCTADEB" , ""},
                    { "V0OPCP_NUMCTADEB" , ""},
                    { "V0OPCP_DIGCTADEB" , ""},
                    { "V0OPCP_INDAGE" , "1"},
                    { "V0OPCP_INDOPR" , "1"},
                    { "V0OPCP_INDNUM" , "1"},
                    { "V0OPCP_INDDIG" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q6);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_DTPROXVEN" , ""},
                    { "V0PROP_QTDPARATZ" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_SITUACAO" , ""},
                    { "V0PROP_DTVENCTO" , "2025-12-01"},
                    { "V0PROP_NRCERTIF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CONV_CODCONV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

                #endregion

                #region R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_PRMTOTANT" , ""}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_PRMTOTANT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_DTVENCTO" , "2025-12-01"},
                    { "V0COBP_PRMVG" , ""},
                    { "V0COBP_PRMAP" , ""},
                    { "V0OPCP_OPCAOPAG" , "1"},
                    { "V0PARC_SITUACAO" , ""},
                    { "V0PARC_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0COBP_VLPREMIO" , ""},
                    { "V0COBP_PRMVG" , ""},
                    { "V0COBP_PRMAP" , ""},
                    { "V0COBP_VLCUSTAUXF" , ""},
                    { "V0COBP_CODOPER" , ""},
                });
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0COBP_VLPREMIO" , ""},
                    { "V0COBP_PRMVG" , ""},
                    { "V0COBP_PRMAP" , ""},
                    { "V0COBP_VLCUSTAUXF" , ""},
                    { "V0COBP_CODOPER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1", q11);

                #endregion

                #region R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "CEDENTE_NUM_TITULO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "W_TITULO" , ""},
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_CODOPER" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                    { "V1SIST_DTMOVABE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1", q14);

                #endregion

                #region R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0OPCP_AGECTADEB" , ""},
                    { "V0OPCP_OPRCTADEB" , ""},
                    { "V0OPCP_NUMCTADEB" , ""},
                    { "V0OPCP_DIGCTADEB" , ""},
                    { "V0HICB_DTVENCTO" , ""},
                    { "WHOST_VLPREMIO" , ""},
                    { "V0CONV_CODCONV" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1", q15);

                #endregion

                #region R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "W_TITULO" , ""},
                    { "V0HICB_DTVENCTO" , ""},
                    { "WHOST_VLPREMIO" , ""},
                    { "V0OPCP_OPCAOPAG" , "1"},
                    { "V0HICB_SITUACAO" , ""},
                    { "V0HICB_CODOPER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1", q16);

                #endregion

                #region VF0853B_CCMPTIT

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_CODOPER" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                });
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_CODOPER" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                });
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_CODOPER" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0853B_CCMPTIT");
                AppSettings.TestSet.DynamicData.Add("VF0853B_CCMPTIT", q17);

                #endregion

                #region R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1", q18);

                #endregion

                #region R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_PRMVG" , ""},
                    { "WHOST_PRMAP" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R1530_00_LOOP_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0DIFP_NRPARCEL" , ""},
                    { "V3DIFP_CODOPER" , ""},
                    { "V0DIFP_DTVENCTO" , ""},
                    { "V0DIFP_PRMDIFVG" , ""},
                    { "V0DIFP_PRMDIFAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1530_00_LOOP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1530_00_LOOP_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                    { "V0COMP_CODOPER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "V0SAFC_VLCUSTSAF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1", q22);

                #endregion

                #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                //q23.AddDynamic(new Dictionary<string, string>{
                //    { "V0RSAF_SITUACAO" , ""}
                //});
                AppSettings.TestSet.DynamicData.Remove("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q23);

                #endregion

                #region R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODCLIEN" , ""},
                    { "V0RSAF_DTREFER" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0SAFC_VLCUSTSAF" , ""},
                    { "V0RSAF_CODOPER" , ""},
                    { "V0PROP_DTVENCTO" , "2025-12-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1", q24);

                #endregion
                #endregion
                var program = new VF0853B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);
                Assert.True(inserts.Count >= allInserts.Count / 2);
                Assert.True(updates.Count >= allUpdates.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VF0853B_Tests_Fact_ReturnCode99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE#region PARAMETERS
                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTCORMAISQD" , ""},
                    { "V1SIST_DTCORMAIS1D" , ""},
                    { "V1SIST_DTCORMAIS1M" , ""},
                    { "V1SIST_DTCORMAIS3M" , "2025-12-01"},
                    { "V1SIST_DTMOVABE" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VF0853B_CPROPVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_SITUACAO" , "6"},
                    { "V0PROP_DTVENCTO" , "2025-12-01"},
                    { "V0PROP_DTPROXVEN" , "2025-12-01"},
                    { "V0PROP_QTDPARATZ" , "0"},
                    { "V0PROP_TIMESTAMP" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VF0853B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VF0853B_CPROPVA", q1);

                #endregion

                #region VF0853B_CDIFPAR

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0DIFP_NRPARCEL" , ""},
                    { "V0DIFP_DTVENCTO" , ""},
                    { "V0DIFP_CODOPER" , ""},
                    { "V0DIFP_VLPRMTOT" , ""},
                    { "V0DIFP_PRMDIFVG" , ""},
                    { "V0DIFP_PRMDIFAP" , ""},
                    { "V0DIFP_NUM_PARCELA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0853B_CDIFPAR");
                AppSettings.TestSet.DynamicData.Add("VF0853B_CDIFPAR", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_UPDATE_1_Update1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0BANC_NRTIT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_UPDATE_1_Update1", q3);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0BANC_NRTIT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0SEGU_DTINISAF" , ""},
                    { "V0SEGU_DTINIRTO" , ""},
                    { "V0SEGU_DTINIDIT" , ""},
                    { "V0SEGU_DTINIDFT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0OPCP_OPCAOPAG" , "0"},
                    { "V0OPCP_PERIPGTO" , "5"},
                    { "V0OPCP_DIA_DEBITO" , ""},
                    { "V0OPCP_AGECTADEB" , ""},
                    { "V0OPCP_OPRCTADEB" , ""},
                    { "V0OPCP_NUMCTADEB" , ""},
                    { "V0OPCP_DIGCTADEB" , ""},
                    { "V0OPCP_INDAGE" , "1"},
                    { "V0OPCP_INDOPR" , "1"},
                    { "V0OPCP_INDNUM" , "1"},
                    { "V0OPCP_INDDIG" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q6);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_DTPROXVEN" , ""},
                    { "V0PROP_QTDPARATZ" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_SITUACAO" , ""},
                    { "V0PROP_DTVENCTO" , "2025-12-01"},
                    { "V0PROP_NRCERTIF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CONV_CODCONV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

                #endregion

                #region R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_PRMTOTANT" , ""}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_PRMTOTANT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_DTVENCTO" , "2025-12-01"},
                    { "V0COBP_PRMVG" , ""},
                    { "V0COBP_PRMAP" , ""},
                    { "V0OPCP_OPCAOPAG" , "1"},
                    { "V0PARC_SITUACAO" , ""},
                    { "V0PARC_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0COBP_VLPREMIO" , ""},
                    { "V0COBP_PRMVG" , ""},
                    { "V0COBP_PRMAP" , ""},
                    { "V0COBP_VLCUSTAUXF" , ""},
                    { "V0COBP_CODOPER" , ""},
                });
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0COBP_VLPREMIO" , ""},
                    { "V0COBP_PRMVG" , ""},
                    { "V0COBP_PRMAP" , ""},
                    { "V0COBP_VLCUSTAUXF" , ""},
                    { "V0COBP_CODOPER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1", q11);

                #endregion

                #region R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "CEDENTE_NUM_TITULO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "W_TITULO" , ""},
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_CODOPER" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                    { "V1SIST_DTMOVABE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1", q14);

                #endregion

                #region R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0OPCP_AGECTADEB" , ""},
                    { "V0OPCP_OPRCTADEB" , ""},
                    { "V0OPCP_NUMCTADEB" , ""},
                    { "V0OPCP_DIGCTADEB" , ""},
                    { "V0HICB_DTVENCTO" , ""},
                    { "WHOST_VLPREMIO" , ""},
                    { "V0CONV_CODCONV" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1", q15);

                #endregion

                #region R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "W_TITULO" , ""},
                    { "V0HICB_DTVENCTO" , ""},
                    { "WHOST_VLPREMIO" , ""},
                    { "V0OPCP_OPCAOPAG" , "1"},
                    { "V0HICB_SITUACAO" , ""},
                    { "V0HICB_CODOPER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1", q16);

                #endregion

                #region VF0853B_CCMPTIT

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_CODOPER" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                });
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_CODOPER" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                });
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_CODOPER" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0853B_CCMPTIT");
                AppSettings.TestSet.DynamicData.Add("VF0853B_CCMPTIT", q17);

                #endregion

                #region R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1", q18);

                #endregion

                #region R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_PRMVG" , ""},
                    { "WHOST_PRMAP" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R1530_00_LOOP_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0DIFP_NRPARCEL" , ""},
                    { "V3DIFP_CODOPER" , ""},
                    { "V0DIFP_DTVENCTO" , ""},
                    { "V0DIFP_PRMDIFVG" , ""},
                    { "V0DIFP_PRMDIFAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1530_00_LOOP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1530_00_LOOP_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0COMP_NRPARCEL" , ""},
                    { "V0COMP_PRMDIFVG" , ""},
                    { "V0COMP_PRMDIFAP" , ""},
                    { "V0COMP_CODOPER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "V0SAFC_VLCUSTSAF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1", q22);

                #endregion

                #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                //q23.AddDynamic(new Dictionary<string, string>{
                //    { "V0RSAF_SITUACAO" , ""}
                //});
                AppSettings.TestSet.DynamicData.Remove("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q23);

                #endregion

                #region R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODCLIEN" , ""},
                    { "V0RSAF_DTREFER" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_NRPARCEL" , ""},
                    { "V0SAFC_VLCUSTSAF" , ""},
                    { "V0RSAF_CODOPER" , ""},
                    { "V0PROP_DTVENCTO" , "2025-12-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1", q24);

                #endregion
                #endregion
                var program = new VF0853B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}