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
using static Code.AC0004B;

namespace FileTests.Test
{
    [Collection("AC0004B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0004B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE_AC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE_FI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1", q1);

            #endregion

            #region AC0004B_V0RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0004B_V0RELATORIOS", q2);

            #endregion

            #region AC0004B_V1COSHISTPRE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1CHSP_COD_EMPR" , ""},
                { "V1CHSP_CONGENER" , ""},
                { "V1CHSP_NUM_APOL" , ""},
                { "V1CHSP_NRENDOS" , ""},
                { "V1CHSP_NRPARCEL" , ""},
                { "V1CHSP_OCORHIST" , ""},
                { "V1CHSP_OPERACAO" , ""},
                { "V1CHSP_DTMOVTO" , ""},
                { "V1CHSP_TIPSGU" , ""},
                { "V1CHSP_PRM_TAR" , ""},
                { "V1CHSP_VAL_DESC" , ""},
                { "V1CHSP_VLPRMLIQ" , ""},
                { "V1CHSP_VLADIFRA" , ""},
                { "V1CHSP_VLCOMIS" , ""},
                { "V1CHSP_VLPRMTOT" , ""},
                { "V1CHSP_DTQITBCO" , ""},
                { "V1CHSP_SIT_FINANC" , ""},
                { "V1CHSP_SIT_LIBREC" , ""},
                { "V1CHSP_NUMOCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0004B_V1COSHISTPRE", q3);

            #endregion

            #region R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , ""},
                { "V0CCHQ_CONGENER" , ""},
                { "V0CCHQ_DTMOVTO_AC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q4);

            #endregion

            #region AC0004B_V1COSHISTSIN

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , ""},
                { "V1CHSI_CONGENER" , ""},
                { "V1CHSI_NUM_SINI" , ""},
                { "V1CHSI_OCORHIST" , ""},
                { "V1CHSI_OPERACAO" , ""},
                { "V1CHSI_DTMOVTO" , ""},
                { "V1CHSI_VAL_OPER" , ""},
                { "V1CHSI_SITUACAO" , ""},
                { "V1CHSI_TIPSGU" , ""},
                { "V1CHSI_SIT_LIBREC" , ""},
                { "GESISFUO_IDE_SISTEMA" , ""},
                { "GESISFUO_COD_FUNCAO" , ""},
                { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                { "GESISFUO_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0004B_V1COSHISTSIN", q5);

            #endregion

            #region R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CHSP_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1CHSP_COD_EMPR" , ""},
                { "V1CHSP_CONGENER" , ""},
                { "V1CHSP_NUM_APOL" , ""},
                { "V1CHSP_NRENDOS" , ""},
                { "V1CHSP_NRPARCEL" , ""},
                { "V0CHSP_OCORHIST" , ""},
                { "V0CHSP_OPERACAO" , ""},
                { "V0CHSP_DTMOVTO" , ""},
                { "V1CHSP_TIPSGU" , ""},
                { "V1CHSP_PRM_TAR" , ""},
                { "V1CHSP_VAL_DESC" , ""},
                { "V1CHSP_VLPRMLIQ" , ""},
                { "V1CHSP_VLADIFRA" , ""},
                { "V1CHSP_VLCOMIS" , ""},
                { "V1CHSP_VLPRMTOT" , ""},
                { "V1CHSP_DTQITBCO" , ""},
                { "V0CHSP_SIT_FINANC" , ""},
                { "V0CHSP_SIT_LIBREC" , ""},
                { "V1CHSP_NUMOCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHSP_CONGENER" , ""},
                { "V1CHSP_NUM_APOL" , ""},
                { "V1CHSP_NRPARCEL" , ""},
                { "V1CHSP_OCORHIST" , ""},
                { "V1CHSP_OPERACAO" , ""},
                { "V1CHSP_NRENDOS" , ""},
                { "V1CHSP_TIPSGU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0CHSP_OCORHIST" , ""},
                { "V1CHSP_CONGENER" , ""},
                { "V1CHSP_NUM_APOL" , ""},
                { "V1CHSP_NRPARCEL" , ""},
                { "V1CHSP_NRENDOS" , ""},
                { "V1CHSP_TIPSGU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GESISORL_COD_OPERACAO_ASS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_CONGENER" , ""},
                { "V1CHSI_NUM_SINI" , ""},
                { "V1CHSI_OCORHIST" , ""},
                { "V1CHSI_OPERACAO" , ""},
                { "V1CHSI_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CHSI_COD_EMPR" , ""},
                { "V1CHSI_CONGENER" , ""},
                { "V1CHSI_NUM_SINI" , ""},
                { "V1CHSI_OCORHIST" , ""},
                { "V0CHSI_OPERACAO" , ""},
                { "V0CHSI_DTMOVTO" , ""},
                { "V1CHSI_VAL_OPER" , ""},
                { "V0CHSI_SITUACAO" , ""},
                { "V1CHSI_TIPSGU" , ""},
                { "V0CHSI_SIT_LIBREC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE_AC" , ""},
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q13);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0004B_Tests_Fact()
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
                #region R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE_AC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE_FI" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0004B_V0RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0RELA_PERI_INICIAL" , ""},
                    { "V0RELA_PERI_FINAL" , ""},
                    { "V0RELA_CONGENER" , ""},
                    { "V0RELA_COD_EMPR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0004B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0004B_V0RELATORIOS", q2);

                #endregion

                #region AC0004B_V1COSHISTPRE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSP_COD_EMPR" , ""},
                    { "V1CHSP_CONGENER" , ""},
                    { "V1CHSP_NUM_APOL" , ""},
                    { "V1CHSP_NRENDOS" , ""},
                    { "V1CHSP_NRPARCEL" , ""},
                    { "V1CHSP_OCORHIST" , ""},
                    { "V1CHSP_OPERACAO" , ""},
                    { "V1CHSP_DTMOVTO" , ""},
                    { "V1CHSP_TIPSGU" , ""},
                    { "V1CHSP_PRM_TAR" , ""},
                    { "V1CHSP_VAL_DESC" , ""},
                    { "V1CHSP_VLPRMLIQ" , ""},
                    { "V1CHSP_VLADIFRA" , ""},
                    { "V1CHSP_VLCOMIS" , ""},
                    { "V1CHSP_VLPRMTOT" , ""},
                    { "V1CHSP_DTQITBCO" , ""},
                    { "V1CHSP_SIT_FINANC" , ""},
                    { "V1CHSP_SIT_LIBREC" , ""},
                    { "V1CHSP_NUMOCOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0004B_V1COSHISTPRE");
                AppSettings.TestSet.DynamicData.Add("AC0004B_V1COSHISTPRE", q3);

                #endregion

                #region R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0CCHQ_COD_EMPR" , ""},
                    { "V0CCHQ_CONGENER" , ""},
                    { "V0CCHQ_DTMOVTO_AC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q4);

                #endregion

                #region AC0004B_V1COSHISTSIN

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSI_COD_EMPR" , ""},
                    { "V1CHSI_CONGENER" , ""},
                    { "V1CHSI_NUM_SINI" , ""},
                    { "V1CHSI_OCORHIST" , ""},
                    { "V1CHSI_OPERACAO" , ""},
                    { "V1CHSI_DTMOVTO" , ""},
                    { "V1CHSI_VAL_OPER" , ""},
                    { "V1CHSI_SITUACAO" , ""},
                    { "V1CHSI_TIPSGU" , ""},
                    { "V1CHSI_SIT_LIBREC" , ""},
                    { "GESISFUO_IDE_SISTEMA" , ""},
                    { "GESISFUO_COD_FUNCAO" , ""},
                    { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                    { "GESISFUO_COD_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0004B_V1COSHISTSIN");
                AppSettings.TestSet.DynamicData.Add("AC0004B_V1COSHISTSIN", q5);

                #endregion

                #region R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0CHSP_OCORHIST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSP_COD_EMPR" , ""},
                    { "V1CHSP_CONGENER" , ""},
                    { "V1CHSP_NUM_APOL" , ""},
                    { "V1CHSP_NRENDOS" , ""},
                    { "V1CHSP_NRPARCEL" , ""},
                    { "V0CHSP_OCORHIST" , ""},
                    { "V0CHSP_OPERACAO" , ""},
                    { "V0CHSP_DTMOVTO" , ""},
                    { "V1CHSP_TIPSGU" , ""},
                    { "V1CHSP_PRM_TAR" , ""},
                    { "V1CHSP_VAL_DESC" , ""},
                    { "V1CHSP_VLPRMLIQ" , ""},
                    { "V1CHSP_VLADIFRA" , ""},
                    { "V1CHSP_VLCOMIS" , ""},
                    { "V1CHSP_VLPRMTOT" , ""},
                    { "V1CHSP_DTQITBCO" , ""},
                    { "V0CHSP_SIT_FINANC" , ""},
                    { "V0CHSP_SIT_LIBREC" , ""},
                    { "V1CHSP_NUMOCOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1", q7);

                #endregion

                #region R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSP_CONGENER" , ""},
                    { "V1CHSP_NUM_APOL" , ""},
                    { "V1CHSP_NRPARCEL" , ""},
                    { "V1CHSP_OCORHIST" , ""},
                    { "V1CHSP_OPERACAO" , ""},
                    { "V1CHSP_NRENDOS" , ""},
                    { "V1CHSP_TIPSGU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1", q8);

                #endregion

                #region R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0CHSP_OCORHIST" , ""},
                    { "V1CHSP_CONGENER" , ""},
                    { "V1CHSP_NUM_APOL" , ""},
                    { "V1CHSP_NRPARCEL" , ""},
                    { "V1CHSP_NRENDOS" , ""},
                    { "V1CHSP_TIPSGU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1", q9);

                #endregion

                #region R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "GESISORL_COD_OPERACAO_ASS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSI_CONGENER" , ""},
                    { "V1CHSI_NUM_SINI" , ""},
                    { "V1CHSI_OCORHIST" , ""},
                    { "V1CHSI_OPERACAO" , ""},
                    { "V1CHSI_DTMOVTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSI_COD_EMPR" , ""},
                    { "V1CHSI_CONGENER" , ""},
                    { "V1CHSI_NUM_SINI" , ""},
                    { "V1CHSI_OCORHIST" , ""},
                    { "V0CHSI_OPERACAO" , ""},
                    { "V0CHSI_DTMOVTO" , ""},
                    { "V1CHSI_VAL_OPER" , ""},
                    { "V0CHSI_SITUACAO" , ""},
                    { "V1CHSI_TIPSGU" , ""},
                    { "V0CHSI_SIT_LIBREC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q12);

                #endregion

                #region R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE_AC" , ""},
                    { "V0RELA_PERI_INICIAL" , ""},
                    { "V0RELA_PERI_FINAL" , ""},
                    { "V0RELA_CONGENER" , ""},
                    { "V0RELA_COD_EMPR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q13);

                #endregion

                #endregion
                #endregion
                var program = new AC0004B();
                program.Execute();

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                var update1 = AppSettings.TestSet.DynamicData["R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update1[1].TryGetValue("V1CHSP_NUM_APOL", out string value1) && value1.Equals("0000000000000"));
                Assert.True(update1[1].TryGetValue("UpdateCheck", out string value2) && value2.Equals("UpdateCheck"));
                
                var update2 = AppSettings.TestSet.DynamicData["R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update1[1].TryGetValue("V1CHSP_NUM_APOL", out string value3) && value3.Equals("0000000000000"));
                Assert.True(update1[1].TryGetValue("UpdateCheck", out string value4) && value4.Equals("UpdateCheck"));
                
                var update3 = AppSettings.TestSet.DynamicData["R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update3[1].TryGetValue("V1CHSI_NUM_SINI", out string value5) && value5.Equals("0000000000000"));
                Assert.True(update3[1].TryGetValue("UpdateCheck", out string value6) && value6.Equals("UpdateCheck"));

                var insert1 = AppSettings.TestSet.DynamicData["R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert1[1].TryGetValue("V1CHSP_NUM_APOL", out string value7) && value7.Equals("0000000000000"));
                
                var insert2 = AppSettings.TestSet.DynamicData["R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert2[1].TryGetValue("V1CHSI_NUM_SINI", out string value8) && value8.Equals("0000000000000"));

                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void AC0004B_Tests_ReturnCode99_Fact()
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
                #region R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE_AC" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE_FI" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0004B_V0RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0RELA_PERI_INICIAL" , ""},
                    { "V0RELA_PERI_FINAL" , ""},
                    { "V0RELA_CONGENER" , ""},
                    { "V0RELA_COD_EMPR" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0004B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0004B_V0RELATORIOS", q2);

                #endregion

                #region AC0004B_V1COSHISTPRE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSP_COD_EMPR" , ""},
                    { "V1CHSP_CONGENER" , ""},
                    { "V1CHSP_NUM_APOL" , ""},
                    { "V1CHSP_NRENDOS" , ""},
                    { "V1CHSP_NRPARCEL" , ""},
                    { "V1CHSP_OCORHIST" , ""},
                    { "V1CHSP_OPERACAO" , ""},
                    { "V1CHSP_DTMOVTO" , ""},
                    { "V1CHSP_TIPSGU" , ""},
                    { "V1CHSP_PRM_TAR" , ""},
                    { "V1CHSP_VAL_DESC" , ""},
                    { "V1CHSP_VLPRMLIQ" , ""},
                    { "V1CHSP_VLADIFRA" , ""},
                    { "V1CHSP_VLCOMIS" , ""},
                    { "V1CHSP_VLPRMTOT" , ""},
                    { "V1CHSP_DTQITBCO" , ""},
                    { "V1CHSP_SIT_FINANC" , ""},
                    { "V1CHSP_SIT_LIBREC" , ""},
                    { "V1CHSP_NUMOCOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0004B_V1COSHISTPRE");
                AppSettings.TestSet.DynamicData.Add("AC0004B_V1COSHISTPRE", q3);

                #endregion

                #region R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0CCHQ_COD_EMPR" , ""},
                    { "V0CCHQ_CONGENER" , ""},
                    { "V0CCHQ_DTMOVTO_AC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q4);

                #endregion

                #region AC0004B_V1COSHISTSIN

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSI_COD_EMPR" , ""},
                    { "V1CHSI_CONGENER" , ""},
                    { "V1CHSI_NUM_SINI" , ""},
                    { "V1CHSI_OCORHIST" , ""},
                    { "V1CHSI_OPERACAO" , ""},
                    { "V1CHSI_DTMOVTO" , ""},
                    { "V1CHSI_VAL_OPER" , ""},
                    { "V1CHSI_SITUACAO" , ""},
                    { "V1CHSI_TIPSGU" , ""},
                    { "V1CHSI_SIT_LIBREC" , ""},
                    { "GESISFUO_IDE_SISTEMA" , ""},
                    { "GESISFUO_COD_FUNCAO" , ""},
                    { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                    { "GESISFUO_COD_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0004B_V1COSHISTSIN");
                AppSettings.TestSet.DynamicData.Add("AC0004B_V1COSHISTSIN", q5);

                #endregion

                #region R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0CHSP_OCORHIST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSP_COD_EMPR" , ""},
                    { "V1CHSP_CONGENER" , ""},
                    { "V1CHSP_NUM_APOL" , ""},
                    { "V1CHSP_NRENDOS" , ""},
                    { "V1CHSP_NRPARCEL" , ""},
                    { "V0CHSP_OCORHIST" , ""},
                    { "V0CHSP_OPERACAO" , ""},
                    { "V0CHSP_DTMOVTO" , ""},
                    { "V1CHSP_TIPSGU" , ""},
                    { "V1CHSP_PRM_TAR" , ""},
                    { "V1CHSP_VAL_DESC" , ""},
                    { "V1CHSP_VLPRMLIQ" , ""},
                    { "V1CHSP_VLADIFRA" , ""},
                    { "V1CHSP_VLCOMIS" , ""},
                    { "V1CHSP_VLPRMTOT" , ""},
                    { "V1CHSP_DTQITBCO" , ""},
                    { "V0CHSP_SIT_FINANC" , ""},
                    { "V0CHSP_SIT_LIBREC" , ""},
                    { "V1CHSP_NUMOCOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1", q7);

                #endregion

                #region R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSP_CONGENER" , ""},
                    { "V1CHSP_NUM_APOL" , ""},
                    { "V1CHSP_NRPARCEL" , ""},
                    { "V1CHSP_OCORHIST" , ""},
                    { "V1CHSP_OPERACAO" , ""},
                    { "V1CHSP_NRENDOS" , ""},
                    { "V1CHSP_TIPSGU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1", q8);

                #endregion

                #region R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0CHSP_OCORHIST" , ""},
                    { "V1CHSP_CONGENER" , ""},
                    { "V1CHSP_NUM_APOL" , ""},
                    { "V1CHSP_NRPARCEL" , ""},
                    { "V1CHSP_NRENDOS" , ""},
                    { "V1CHSP_TIPSGU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1", q9);

                #endregion

                #region R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "GESISORL_COD_OPERACAO_ASS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSI_CONGENER" , ""},
                    { "V1CHSI_NUM_SINI" , ""},
                    { "V1CHSI_OCORHIST" , ""},
                    { "V1CHSI_OPERACAO" , ""},
                    { "V1CHSI_DTMOVTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V1CHSI_COD_EMPR" , ""},
                    { "V1CHSI_CONGENER" , ""},
                    { "V1CHSI_NUM_SINI" , ""},
                    { "V1CHSI_OCORHIST" , ""},
                    { "V0CHSI_OPERACAO" , ""},
                    { "V0CHSI_DTMOVTO" , ""},
                    { "V1CHSI_VAL_OPER" , ""},
                    { "V0CHSI_SITUACAO" , ""},
                    { "V1CHSI_TIPSGU" , ""},
                    { "V0CHSI_SIT_LIBREC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1", q12);

                #endregion

                #region R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE_AC" , ""},
                    { "V0RELA_PERI_INICIAL" , ""},
                    { "V0RELA_PERI_FINAL" , ""},
                    { "V0RELA_CONGENER" , ""},
                    { "V0RELA_COD_EMPR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q13);

                #endregion

                #endregion
                #endregion
                var program = new AC0004B();
                program.Execute();

                Assert.True(program.RETURN_CODE.Value == 99);
            }
        }
    }
}