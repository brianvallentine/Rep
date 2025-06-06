using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;

namespace FileTests.Test
{
    [Collection("VA0127B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0127B_Tests
    {
        [Fact]
        public static void VA0127B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                AppSettings.TestSet.IsTest = true;
                #region PARAMETERS
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRENT" , ""},
                { "SISTEMA_DTTERCOT" , ""},
                { "SISTEMA_DTINICOT" , ""},
                { "SISTEMA_DTMOV01M" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , ""},
                { "PARAMRAM_RAMO_VG" , ""},
                { "PARAMRAM_RAMO_AP" , ""},
                { "PARAMRAM_RAMO_SAUDE" , ""},
                { "PARAMRAM_RAMO_SA_INDV" , ""},
                { "PARAMRAM_RAMO_EDUCACAO" , ""},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_DATA_INIVIGENCIA" , "1"},
                { "V0RIND_DTMOVTO_1DAY" , ""},
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q2);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "4"}
            });
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q3);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_5_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_FIM" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_5_Query1", q4);

                #endregion

                #region VA0127B_CPROPVA

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , ""},
                { "CODSUBES" , ""},
                { "NRCERTIF" , ""},
                { "CODCLIEN" , ""},
                { "OCOREND" , ""},
                { "FONTE" , ""},
                { "AGECOBR" , ""},
                { "OPCAO_COBER" , ""},
                { "DTPROXVEN" , ""},
                { "CODOPER" , ""},
                { "DTMOVTO" , ""},
                { "NUM_APOLICE0" , ""},
                { "CODSUBES1" , ""},
                { "OCORHIST" , ""},
                { "SIT_INTERFACE" , ""},
                { "TIMESTAMP" , ""},
                { "IDE_SEXO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "YEAR" , ""},
                { "DTQITBCO" , ""},
                { "IDADE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VA0127B_CPROPVA", q5);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SEGURA_NUM_ITEM" , ""},
                { "SEGURA_FAIXA" , ""},
                { "SEGURA_TXVG" , ""},
                { "SEGURA_TXAPMA" , ""},
                { "SEGURA_TXAPIP" , ""},
                { "SEGURA_TXAPAMDS" , ""},
                { "SEGURA_TXAPDH" , ""},
                { "SEGURA_TXAPDIT" , ""},
                { "SEGURA_SIT_REGISTRO" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
                { "WLOT_EMP_SEGURADO" , ""},
                { "SEGURA_OCORHIST" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q7);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "HISTSG_OCORHIST" , "3"}
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q8);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "HISTSG_DTMOVTO_ANT" , "1"},
                { "HISTSG_CODOPER" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q9);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q10);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_PREMIO200VG" , "10"},
                { "V0HCTB_PREMIO200AP" , "100"},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q11);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_PREMIO400VG" , ""},
                { "V0HCTB_PREMIO400AP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q12);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_PREMIO500VG" , "1"},
                { "V0HCTB_PREMIO500AP" , "1"},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1", q13);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT_CRED" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1", q14);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "HISCOBPR_OCORR_HISTORICO" , "1"}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                    { "HISCOBPR_OCORR_HISTORICO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1", q15);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , "1"},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , "1"},
                { "HISCOBPR_PRMVG" , "1"},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_COD_USUARIO" , ""},
                { "HISCOBPR_TIMESTAMP" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "HISCOBPR_PRMDIT" , ""},
                { "HISCOBPR_QTMDIT" , ""},
                { "HISCOBPR_DTINIVIG_1DAY" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1", q16);

                #endregion

                #region M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "DIFERPAR_NUM_CERTIFICADO" , ""},
                { "DIFERPAR_NUM_PARCELA" , ""},
                { "DIFERPAR_NUM_PARCELA_DIF" , ""},
                { "DIFERPAR_COD_OPERACAO" , ""},
                { "DIFERPAR_DATA_VENCIMENTO" , ""},
                { "DIFERPAR_PRMDEVVG" , ""},
                { "DIFERPAR_PRMDEVAP" , ""},
                { "DIFERPAR_PRMPAGVG" , ""},
                { "DIFERPAR_PRMPAGAP" , ""},
                { "DIFERPAR_PRMDIFVG" , ""},
                { "DIFERPAR_PRMDIFAP" , ""},
                { "DIFERPAR_VAL_MULTA" , ""},
                { "DIFERPAR_SITUACAO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1", q17);

                #endregion

                #endregion
                var program = new VA0127B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("DIFERPAR_COD_OPERACAO", out var valOr) && valOr == "0696");
            }
        }
    }
}