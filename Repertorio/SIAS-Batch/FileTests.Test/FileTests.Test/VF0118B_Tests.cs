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
using static Code.VF0118B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VF0118B_Tests")]
    public class VF0118B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRDATE" , ""},
                { "SISTEMA_DTACEITE" , ""},
                { "SISTEMA_DTMOVA15D" , ""},
                { "SISTEMA_DTMOVA01M" , ""},
                { "SISTEMA_DTMOVA02M" , ""},
                { "SISTEMA_DTINISAF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VF0118B_CPROPVA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "PROPVA_DTINIVIG" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTMINVEN" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_CODUSU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0118B_CPROPVA", q1);

            #endregion

            #region VF0118B_CBENEFP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "BENEF_NOMBENEF" , ""},
                { "BENEF_GRAUPAR" , ""},
                { "BENEF_PCTBENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0118B_CBENEFP", q2);

            #endregion

            #region M_0000_PRINCIPAL_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CEDENT_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_UPDATE_1_Update1", q3);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CEDENT_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q4);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_DIA_DEB" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q6);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "COBERP_IMPMORNATU" , ""},
                { "COBERP_IMPMORACID" , ""},
                { "COBERP_IMPINVPERM" , ""},
                { "COBERP_IMPDIT" , ""},
                { "COBERP_VLPREMIO" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q7);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1", q8);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , ""},
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q9);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPVF_NRTIT" , ""},
                { "PROPVF_PRMTOTPGO" , ""},
                { "PROPVF_PRMVGPGO" , ""},
                { "PROPVF_PRMAPPGO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q10);

            #endregion

            #region M_1000_INTEGRA_PROPOSTA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "RCAP_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_INTEGRA_PROPOSTA_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , ""},
                { "RELATO_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_1000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "RELATO_NRPARCEL" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "RELATO_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1", q13);

            #endregion

            #region M_1100_GERA_1A_PARCELA_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
                { "PARCEL_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_GERA_1A_PARCELA_DB_INSERT_1_Insert1", q14);

            #endregion

            #region M_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "CEDENT_NRTIT" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "COBERP_VLPREMIO" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
                { "HISTCB_SITUACAO" , ""},
                { "HISTCB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1", q15);

            #endregion

            #region M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTVENCTO" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1_Update1", q16);

            #endregion

            #region M_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CEDENT_NRTIT" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1", q17);

            #endregion

            #region M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTVENCTO" , ""},
                { "COBERP_VLPREMIO" , ""},
                { "CEDENT_NRTIT" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1", q18);

            #endregion

            #region M_1300_GERA_AJUSTE_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVF_PRMVGPGO" , ""},
                { "PROPVF_PRMAPPGO" , ""},
                { "DIFPAR_PRMVGDIF" , ""},
                { "DIFPAR_PRMAPDIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1300_GERA_AJUSTE_DB_INSERT_1_Insert1", q19);

            #endregion

            #region M_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1_Update1", q20);

            #endregion

            #region M_2000_INTEGRA_VG_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "CONDTE_IEA" , ""},
                { "CONDTE_IPA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_INTEGRA_VG_DB_SELECT_1_Query1", q21);

            #endregion

            #region M_2000_INTEGRA_VG_DB_SELECT_2_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "FATURC_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_INTEGRA_VG_DB_SELECT_2_Query1", q22);

            #endregion

            #region M_2100_CALC_PROP_AUTOM_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2100_CALC_PROP_AUTOM_DB_SELECT_1_Query1", q23);

            #endregion

            #region M_2100_CALC_PROP_AUTOM_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2100_CALC_PROP_AUTOM_DB_UPDATE_1_Update1", q24);

            #endregion

            #region M_2000_INTEGRA_VG_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "MTPINCLUS" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "MFAIXA" , ""},
                { "MTPBENEF" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "PROPVA_SEXO" , ""},
                { "MAGECOBR" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MTXAPMA" , ""},
                { "MTXAPIP" , ""},
                { "MTXVG" , ""},
                { "COBERP_IMPMORNATU" , ""},
                { "COBERP_IMPMORACID" , ""},
                { "COBERP_IMPINVPERM" , ""},
                { "COBERP_IMPDIT" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "PROPVA_CODUSU" , ""},
                { "CLIENT_DTNASC" , ""},
                { "MDTREF" , ""},
                { "MDTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_INTEGRA_VG_DB_INSERT_1_Insert1", q25);

            #endregion

            #region M_2000_INTEGRA_VG_DB_SELECT_3_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "FATURC_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_INTEGRA_VG_DB_SELECT_3_Query1", q26);

            #endregion

            #region M_2000_INTEGRA_VG_DB_SELECT_4_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_INTEGRA_VG_DB_SELECT_4_Query1", q27);

            #endregion

            #region VF0118B_CPLCOM

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "PLCOM_CODPDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VF0118B_CPLCOM", q28);

            #endregion

            #region M_2200_LOOP_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "BENEF_NRBENEF" , ""},
                { "BENEF_NOMBENEF" , ""},
                { "BENEF_GRAUPAR" , ""},
                { "BENEF_PCTBENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2200_LOOP_DB_INSERT_1_Insert1", q29);

            #endregion

            #region M_2300_CONCEDE_SAF_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "SAFCOB_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2300_CONCEDE_SAF_DB_SELECT_1_Query1", q30);

            #endregion

            #region M_2300_CONCEDE_SAF_DB_SELECT_2_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "REPSAF_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2300_CONCEDE_SAF_DB_SELECT_2_Query1", q31);

            #endregion

            #region M_2310_ELIMINA_SAF_DB_DELETE_1_Delete1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2310_ELIMINA_SAF_DB_DELETE_1_Delete1", q32);

            #endregion

            #region M_2320_INCLUI_SAF_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "SISTEMA_DTINISAF" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2320_INCLUI_SAF_DB_INSERT_1_Insert1", q33);

            #endregion

            #region M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "REPSAF_DTREF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "SISTEMA_DTINISAF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1", q34);

            #endregion

            #region M_2330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "REPSAF_DTREF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "SISTEMA_DTINISAF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1", q35);

            #endregion

            #region M_2420_GERA_EVENTO_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "PDTVF_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2420_GERA_EVENTO_DB_SELECT_1_Query1", q36);

            #endregion

            #region M_2420_GERA_EVENTO_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "PDTVF_OCORHIST" , ""},
                { "PLCOM_CODPDT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2420_GERA_EVENTO_DB_UPDATE_1_Update1", q37);

            #endregion

            #region M_2420_GERA_EVENTO_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "PLCOM_CODPDT" , ""},
                { "PDTVF_OCORHIST" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "COBERP_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2420_GERA_EVENTO_DB_INSERT_1_Insert1", q38);

            #endregion

            #region M_8700_GERA_DEBITO_DB_INSERT_1_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "COBERP_VLPREMIO" , ""},
                { "V0CONV_CODCONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1", q39);

            #endregion

            #endregion
        }

        [Fact]
        public static void VF0118B_Tests_Fact()
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
                var program = new VF0118B();
                program.Execute();

                Assert.True(true);
            }
        }
    }
}