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
using static Code.AC0816B;

namespace FileTests.Test
{
    [Collection("AC0816B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class AC0816B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region AC0816B_V0RELATORIOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_COD_USU" , ""},
                { "V0RELA_DATA_SOL" , ""},
                { "V0RELA_IDSISTEM" , ""},
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_PERI_INI" , ""},
                { "V0RELA_PERI_FIN" , ""},
                { "V0RELA_DATA_REF" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_CODUNIMO" , ""},
                { "V0RELA_CORRECAO" , ""},
                { "V0RELA_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0816B_V0RELATORIOS", q1);

            #endregion

            #region AC0816B_V1COSHISTSIN

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , ""},
                { "V1CHSI_CONGENER" , ""},
                { "V1CHSI_NUM_SINI" , ""},
                { "V1CHSI_OCORHIST" , ""},
                { "V1CHSI_DTMOVTO" , ""},
                { "V1CHSI_OPERACAO" , ""},
                { "V1CHSI_VAL_OPER" , ""},
                { "V1CHSI_TIPSGU" , ""},
                { "V1CHSI_SITUACAO" , ""},
                { "V1CHSI_SIT_LIBREC" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
                { "GESISFUO_IDE_SISTEMA" , ""},
                { "GESISFUO_COD_FUNCAO" , ""},
                { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                { "GESISFUO_NUM_FATOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0816B_V1COSHISTSIN", q2);

            #endregion

            #region R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_VAL_VENDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GESISORL_COD_FUNCAO" , ""},
                { "GESISORL_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GESISORL_COD_OPERACAO_ASS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0MSIN_NUM_SINISTRO" , ""},
                { "V0MSIN_MOEDA_SINI" , ""},
                { "V0MSIN_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , ""},
                { "V0APOL_TIPSGU" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1100_00_SELECT_SX010_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , ""},
                { "SX010_DTA_APOLICE" , ""},
                { "SX010_COD_FONTE" , ""},
                { "SX017_NUM_RAMO" , ""},
                { "SX017_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SX010_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VAL_COR_PEND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_CONGENER" , ""},
                { "V1CHSI_NUM_SINI" , ""},
                { "V1CHSI_OCORHIST" , ""},
                { "V1CHSI_OPERACAO" , ""},
                { "V1CHSI_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , ""},
                { "V1CHSI_CONGENER" , ""},
                { "V1CHSI_NUM_SINI" , ""},
                { "V1CHSI_OCORHIST" , ""},
                { "V0CHSI_OPERACAO" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "V0CHSI_VAL_OPER" , ""},
                { "V1CHSI_TIPSGU" , ""},
                { "V1CHSI_SIT_LIBREC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , ""},
                { "V1CHSI_CONGENER" , ""},
                { "V1CHSI_NUM_SINI" , ""},
                { "V1CHSI_OCORHIST" , ""},
                { "WHOST_OPER_COR" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "WHOST_VAL_CORR" , ""},
                { "V1CHSI_SITUACAO" , ""},
                { "V1CHSI_TIPSGU" , ""},
                { "V1CHSI_SIT_LIBREC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_VAL_OPER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OUTRDEBIT" , ""},
                { "WHOST_OUTRCREDT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_VLDESPESA" , ""},
                { "V0CCHQ_VLRESSARC" , ""},
                { "V0CCHQ_OUTRDEBIT" , ""},
                { "V0CCHQ_OUTRCREDT" , ""},
                { "V0CCHQ_VLRHONOR" , ""},
                { "V0CCHQ_VLRSALVD" , ""},
                { "V0CCHQ_VLRSINI" , ""},
                { "V0RELA_COD_EMPR" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_DATA_SOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_COD_USU" , ""},
                { "V0RELA_DATA_SOL" , ""},
                { "V0RELA_IDSISTEM" , ""},
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q17);

            #endregion

            #endregion
        }

        [Fact]
        public void AC0816B_Test_Success_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , "2023-12-01" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0816B_V0RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_COD_USU" , "user123" },
                { "V0RELA_DATA_SOL" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "system01" },
                { "V0RELA_CODRELAT" , "report001" },
                { "V0RELA_PERI_INI" , "2023-01-01" },
                { "V0RELA_PERI_FIN" , "2023-12-01" },
                { "V0RELA_DATA_REF" , "2023-12-01" },
                { "V0RELA_CONGENER" , "general" },
                { "V0RELA_CODUNIMO" , "1" },
                { "V0RELA_CORRECAO" , "correction" },
                { "V0RELA_COD_EMPR" , "company001" },
            });
                AppSettings.TestSet.DynamicData.Remove("AC0816B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0816B_V0RELATORIOS", q1);

                #endregion

                #region AC0816B_V1COSHISTSIN

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , "company002" },
                { "V1CHSI_CONGENER" , "general" },
                { "V1CHSI_NUM_SINI" , "incident123" },
                { "V1CHSI_OCORHIST" , "history" },
                { "V1CHSI_DTMOVTO" , "2023-12-01" },
                { "V1CHSI_OPERACAO" , "operation" },
                { "V1CHSI_VAL_OPER" , "1000" },
                { "V1CHSI_TIPSGU" , "type" },
                { "V1CHSI_SITUACAO" , "situation" },
                { "V1CHSI_SIT_LIBREC" , "librec" },
                { "GEOPERAC_FUNCAO_OPERACAO" , "SEVEN" },
                { "GEOPERAC_IND_TIPO_FUNCAO" , "SA" },
                { "GESISFUO_IDE_SISTEMA" , "system02" },
                { "GESISFUO_COD_FUNCAO" , "function002" },
                { "GESISFUO_IDE_SISTEMA_OPER" , "system03" },
                { "GESISFUO_NUM_FATOR" , "1.5" },
            });
                AppSettings.TestSet.DynamicData.Remove("AC0816B_V1COSHISTSIN");
                AppSettings.TestSet.DynamicData.Add("AC0816B_V1COSHISTSIN", q2);

                #endregion

                #region R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_VAL_VENDA" , "2000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GESISORL_COD_FUNCAO" , "function003" },
                { "GESISORL_COD_OPERACAO" , "operation003" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GESISORL_COD_OPERACAO_ASS" , "operation004" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0MSIN_NUM_SINISTRO" , "incident124" },
                { "V0MSIN_MOEDA_SINI" , "USD" },
                { "V0MSIN_NUM_APOL" , "policy124" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , "policy125" },
                { "V0APOL_TIPSGU" , "1" },
                { "V0APOL_ORGAO" , "0100" },
                { "V0APOL_RAMO" , "31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_SELECT_SX010_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , "policy126" },
                { "SX010_DTA_APOLICE" , "2023-12-01" },
                { "SX010_COD_FONTE" , "source" },
                { "SX017_NUM_RAMO" , "branch002" },
                { "SX017_COD_PRODUTO" , "product002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_SX010_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SX010_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VAL_COR_PEND" , "3000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_CONGENER" , "1015" },
                { "V1CHSI_NUM_SINI" , "incident123" },
                { "V1CHSI_OCORHIST" , "history" },
                { "V1CHSI_OPERACAO" , "operation" },
                { "V1CHSI_DTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , "company002" },
                { "V1CHSI_CONGENER" , "general" },
                { "V1CHSI_NUM_SINI" , "incident123" },
                { "V1CHSI_OCORHIST" , "history" },
                { "V0CHSI_OPERACAO" , "operation005" },
                { "V0SIST_DTMOVABE" , "2023-12-01" },
                { "V0CHSI_VAL_OPER" , "1500" },
                { "V1CHSI_TIPSGU" , "type" },
                { "V1CHSI_SIT_LIBREC" , "librec" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q12);

                #endregion

                #region R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , "company002" },
                { "V1CHSI_CONGENER" , "general" },
                { "V1CHSI_NUM_SINI" , "incident123" },
                { "V1CHSI_OCORHIST" , "history" },
                { "WHOST_OPER_COR" , "correction002" },
                { "V0SIST_DTMOVABE" , "2023-12-01" },
                { "WHOST_VAL_CORR" , "3500" },
                { "V1CHSI_SITUACAO" , "situation" },
                { "V1CHSI_TIPSGU" , "type" },
                { "V1CHSI_SIT_LIBREC" , "librec" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q13);

                #endregion

                #region R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_VAL_OPER" , "4000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OUTRDEBIT" , "5000" },
                { "WHOST_OUTRCREDT" , "6000" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_VLDESPESA" , "7000" },
                { "V0CCHQ_VLRESSARC" , "8000" },
                { "V0CCHQ_OUTRDEBIT" , "9000" },
                { "V0CCHQ_OUTRCREDT" , "10000" },
                { "V0CCHQ_VLRHONOR" , "11000" },
                { "V0CCHQ_VLRSALVD" , "12000" },
                { "V0CCHQ_VLRSINI" , "13000" },
                { "V0RELA_COD_EMPR" , "company001" },
                { "V0RELA_CONGENER" , "general" },
                { "V0RELA_DATA_SOL" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q16);

                #endregion

                #region R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_COD_USU" , "user123" },
                { "V0RELA_DATA_SOL" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "system01" },
                { "V0RELA_CODRELAT" , "report001" },
                { "V0RELA_CONGENER" , "general" },
                { "V0RELA_COD_EMPR" , "company001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q17);

                #endregion
                #endregion
                #endregion

                var program = new AC0816B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count == 4);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public void AC0816B_Test_ReturnCode99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0816B_V0RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_COD_USU" , "user123" },
                { "V0RELA_DATA_SOL" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "system01" },
                { "V0RELA_CODRELAT" , "report001" },
                { "V0RELA_PERI_INI" , "2023-01-01" },
                { "V0RELA_PERI_FIN" , "2023-12-01" },
                { "V0RELA_DATA_REF" , "2023-12-01" },
                { "V0RELA_CONGENER" , "general" },
                { "V0RELA_CODUNIMO" , "1" },
                { "V0RELA_CORRECAO" , "correction" },
                { "V0RELA_COD_EMPR" , "company001" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0816B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0816B_V0RELATORIOS", q1);

                #endregion

                #region AC0816B_V1COSHISTSIN

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , "company002" },
                { "V1CHSI_CONGENER" , "general" },
                { "V1CHSI_NUM_SINI" , "incident123" },
                { "V1CHSI_OCORHIST" , "history" },
                { "V1CHSI_DTMOVTO" , "2023-12-01" },
                { "V1CHSI_OPERACAO" , "operation" },
                { "V1CHSI_VAL_OPER" , "1000" },
                { "V1CHSI_TIPSGU" , "type" },
                { "V1CHSI_SITUACAO" , "situation" },
                { "V1CHSI_SIT_LIBREC" , "librec" },
                { "GEOPERAC_FUNCAO_OPERACAO" , "SEVEN" },
                { "GEOPERAC_IND_TIPO_FUNCAO" , "SA" },
                { "GESISFUO_IDE_SISTEMA" , "system02" },
                { "GESISFUO_COD_FUNCAO" , "function002" },
                { "GESISFUO_IDE_SISTEMA_OPER" , "system03" },
                { "GESISFUO_NUM_FATOR" , "1.5" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0816B_V1COSHISTSIN");
                AppSettings.TestSet.DynamicData.Add("AC0816B_V1COSHISTSIN", q2);

                #endregion

                #region R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_VAL_VENDA" , "2000" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GESISORL_COD_FUNCAO" , "function003" },
                { "GESISORL_COD_OPERACAO" , "operation003" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GESISORL_COD_OPERACAO_ASS" , "operation004" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0MSIN_NUM_SINISTRO" , "incident124" },
                { "V0MSIN_MOEDA_SINI" , "USD" },
                { "V0MSIN_NUM_APOL" , "policy124" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , "policy125" },
                { "V0APOL_TIPSGU" , "1" },
                { "V0APOL_ORGAO" , "0100" },
                { "V0APOL_RAMO" , "31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_SELECT_SX010_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , "policy126" },
                { "SX010_DTA_APOLICE" , "2023-12-01" },
                { "SX010_COD_FONTE" , "source" },
                { "SX017_NUM_RAMO" , "branch002" },
                { "SX017_COD_PRODUTO" , "product002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_SX010_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SX010_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VAL_COR_PEND" , "3000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_CONGENER" , "1015" },
                { "V1CHSI_NUM_SINI" , "incident123" },
                { "V1CHSI_OCORHIST" , "history" },
                { "V1CHSI_OPERACAO" , "operation" },
                { "V1CHSI_DTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , "company002" },
                { "V1CHSI_CONGENER" , "general" },
                { "V1CHSI_NUM_SINI" , "incident123" },
                { "V1CHSI_OCORHIST" , "history" },
                { "V0CHSI_OPERACAO" , "operation005" },
                { "V0SIST_DTMOVABE" , "2023-12-01" },
                { "V0CHSI_VAL_OPER" , "1500" },
                { "V1CHSI_TIPSGU" , "type" },
                { "V1CHSI_SIT_LIBREC" , "librec" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q12);

                #endregion

                #region R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , "company002" },
                { "V1CHSI_CONGENER" , "general" },
                { "V1CHSI_NUM_SINI" , "incident123" },
                { "V1CHSI_OCORHIST" , "history" },
                { "WHOST_OPER_COR" , "correction002" },
                { "V0SIST_DTMOVABE" , "2023-12-01" },
                { "WHOST_VAL_CORR" , "3500" },
                { "V1CHSI_SITUACAO" , "situation" },
                { "V1CHSI_TIPSGU" , "type" },
                { "V1CHSI_SIT_LIBREC" , "librec" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q13);

                #endregion

                #region R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_VAL_OPER" , "4000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OUTRDEBIT" , "5000" },
                { "WHOST_OUTRCREDT" , "6000" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_VLDESPESA" , "7000" },
                { "V0CCHQ_VLRESSARC" , "8000" },
                { "V0CCHQ_OUTRDEBIT" , "9000" },
                { "V0CCHQ_OUTRCREDT" , "10000" },
                { "V0CCHQ_VLRHONOR" , "11000" },
                { "V0CCHQ_VLRSALVD" , "12000" },
                { "V0CCHQ_VLRSINI" , "13000" },
                { "V0RELA_COD_EMPR" , "company001" },
                { "V0RELA_CONGENER" , "general" },
                { "V0RELA_DATA_SOL" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q16);

                #endregion

                #region R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_COD_USU" , "user123" },
                { "V0RELA_DATA_SOL" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "system01" },
                { "V0RELA_CODRELAT" , "report001" },
                { "V0RELA_CONGENER" , "general" },
                { "V0RELA_COD_EMPR" , "company001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q17);

                #endregion
                #endregion
                #endregion

                var program = new AC0816B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}