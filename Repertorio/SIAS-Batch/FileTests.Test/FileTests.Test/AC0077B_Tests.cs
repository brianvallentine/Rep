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
using static Code.AC0077B;

namespace FileTests.Test
{
    [Collection("AC0077B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0077B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region AC0077B_V1MESTSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_NUM_SINI" , ""},
                { "V1MSIN_NUM_APOL" , ""},
                { "V1MSIN_NRENDOS" , ""},
                { "V1MSIN_COD_MOEDA" , ""},
                { "V1MSIN_TIPREG" , ""},
                { "V1MSIN_RAMO" , ""},
                { "V1MSIN_CODCAU" , ""},
                { "V1MSIN_DATORR" , ""},
                { "V1MSIN_PCTRES" , ""},
                { "V1HSIN_OCORHIST" , ""},
                { "V1HSIN_OPERACAO" , ""},
                { "V1HSIN_DTMOVTO" , ""},
                { "V1HSIN_VAL_OPER" , ""},
                { "V1HSIN_TIPREG" , ""},
                { "V1HSIN_SITUACAO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0077B_V1MESTSINI", q2);

            #endregion

            #region AC0077B_SX_APOLCOSG

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , ""},
                { "SX118_COD_CONGENERE" , ""},
                { "SX118_PCT_PARTICIPACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0077B_SX_APOLCOSG", q3);

            #endregion

            #region R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_AVS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GESISFUO_IDE_SISTEMA" , ""},
                { "GESISFUO_COD_FUNCAO" , ""},
                { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                { "GESISFUO_NUM_FATOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , ""},
                { "V0APOL_TIPSGU" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1000_00_SELECT_SX010_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , ""},
                { "SX010_DTA_APOLICE" , ""},
                { "SX010_COD_FONTE" , ""},
                { "SX017_NUM_RAMO" , ""},
                { "SX017_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_SX010_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_VL_VENDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0CSIN_COD_EMP" , ""},
                { "V0CSIN_TIPSGU" , ""},
                { "V0CSIN_CONGENER" , ""},
                { "V0CSIN_NUM_SINI" , ""},
                { "V0CSIN_VAL_OPER" , ""},
                { "V0CSIN_SITUACAO" , ""},
                { "V0CSIN_SIT_CONG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0CHSI_COD_EMP" , ""},
                { "V0CHSI_CONGENER" , ""},
                { "V0CHSI_NUM_SINI" , ""},
                { "V0CHSI_OCORHIST" , ""},
                { "V0CHSI_OPERACAO" , ""},
                { "V0CHSI_DTMOVTO" , ""},
                { "V0CHSI_VAL_OPER" , ""},
                { "V0CHSI_SITUACAO" , ""},
                { "V0CHSI_TIPSGU" , ""},
                { "V0CHSI_SIT_LIBRC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1CSIN_CONGENER" , ""},
                { "V1CSIN_NUM_SINI" , ""},
                { "V1CSIN_TIPSGU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "V1CSIN_CONGENER" , ""},
                { "V1CSIN_NUM_SINI" , ""},
                { "V1CSIN_TIPSGU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1", q12);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0077B_Tests_Fact()
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

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0077B_V1MESTSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_NUM_SINI" , "1400000000000" },
                { "V1MSIN_NUM_APOL" , "6501000001" },
                { "V1MSIN_NRENDOS" , "5" },
                { "V1MSIN_COD_MOEDA" , "1" },
                { "V1MSIN_TIPREG" , "2" },
                { "V1MSIN_RAMO" , "68" },
                { "V1MSIN_CODCAU" , "101" },
                { "V1MSIN_DATORR" , "2023-11-15" },
                { "V1MSIN_PCTRES" , "50.0" },
                { "V1HSIN_OCORHIST" , "300" },
                { "V1HSIN_OPERACAO" , "0101" },
                { "V1HSIN_DTMOVTO" , "2023-12-01" },
                { "V1HSIN_VAL_OPER" , "1000.0" },
                { "V1HSIN_TIPREG" , "1" },
                { "V1HSIN_SITUACAO" , "A" },
                { "GEOPERAC_FUNCAO_OPERACAO" , "FUNC123" },
                { "GEOPERAC_IND_TIPO_FUNCAO" , "T" },
            });

                q2.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_NUM_SINI" , "1400000000000" },
                { "V1MSIN_NUM_APOL" , "6501000001" },
                { "V1MSIN_NRENDOS" , "5" },
                { "V1MSIN_COD_MOEDA" , "1" },
                { "V1MSIN_TIPREG" , "2" },
                { "V1MSIN_RAMO" , "68" },
                { "V1MSIN_CODCAU" , "101" },
                { "V1MSIN_DATORR" , "2023-11-15" },
                { "V1MSIN_PCTRES" , "50.0" },
                { "V1HSIN_OCORHIST" , "300" },
                { "V1HSIN_OPERACAO" , "0101" },
                { "V1HSIN_DTMOVTO" , "2023-12-01" },
                { "V1HSIN_VAL_OPER" , "1000.0" },
                { "V1HSIN_TIPREG" , "1" },
                { "V1HSIN_SITUACAO" , "A" },
                { "GEOPERAC_FUNCAO_OPERACAO" , "FUNC123" },
                { "GEOPERAC_IND_TIPO_FUNCAO" , "DS" },
            });
                AppSettings.TestSet.DynamicData.Remove("AC0077B_V1MESTSINI");
                AppSettings.TestSet.DynamicData.Add("AC0077B_V1MESTSINI", q2);

                #endregion

                #region AC0077B_SX_APOLCOSG

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , "6501000003" },
                { "SX118_COD_CONGENERE" , "500" },
                { "SX118_PCT_PARTICIPACAO" , "25.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("AC0077B_SX_APOLCOSG");
                AppSettings.TestSet.DynamicData.Add("AC0077B_SX_APOLCOSG", q3);

                #endregion

                #region R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_AVS" , "2023-12-02" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GESISFUO_IDE_SISTEMA" , "SYS1" },
                { "GESISFUO_COD_FUNCAO" , "F100" },
                { "GESISFUO_IDE_SISTEMA_OPER" , "SYSOP1" },
                { "GESISFUO_NUM_FATOR" , "1.5" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , "6501000004" },
                { "V0APOL_TIPSGU" , "1" },
                { "V0APOL_ORGAO" , "10" },
                { "V0APOL_RAMO" , "48" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1000_00_SELECT_SX010_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , "6501000003" },
                { "SX010_DTA_APOLICE" , "2023-11-20" },
                { "SX010_COD_FONTE" , "FNT1" },
                { "SX017_NUM_RAMO" , "69" },
                { "SX017_COD_PRODUTO" , "P100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_SX010_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_SX010_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_VL_VENDA" , "150000.0" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0CSIN_COD_EMP" , "EMP1" },
                { "V0CSIN_TIPSGU" , "T2" },
                { "V0CSIN_CONGENER" , "CONG1" },
                { "V0CSIN_NUM_SINI" , "654321" },
                { "V0CSIN_VAL_OPER" , "2000.0" },
                { "V0CSIN_SITUACAO" , "B" },
                { "V0CSIN_SIT_CONG" , "C1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0CHSI_COD_EMP" , "EMP2" },
                { "V0CHSI_CONGENER" , "CONG2" },
                { "V0CHSI_NUM_SINI" , "654322" },
                { "V0CHSI_OCORHIST" , "301" },
                { "V0CHSI_OPERACAO" , "201" },
                { "V0CHSI_DTMOVTO" , "2023-12-03" },
                { "V0CHSI_VAL_OPER" , "3000.0" },
                { "V0CHSI_SITUACAO" , "C" },
                { "V0CHSI_TIPSGU" , "T3" },
                { "V0CHSI_SIT_LIBRC" , "L1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1CSIN_CONGENER" , "CONG3" },
                { "V1CSIN_NUM_SINI" , "654323" },
                { "V1CSIN_TIPSGU" , "T4" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , "D" },
                { "V1CSIN_CONGENER" , "CONG3" },
                { "V1CSIN_NUM_SINI" , "654323" },
                { "V1CSIN_TIPSGU" , "T4" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1", q12);

                #endregion

                #endregion
                #endregion
                var program = new AC0077B();
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

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void AC0077B_Tests_Fact_ReturnCode99()
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

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , "0" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0077B_V1MESTSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_NUM_SINI" , "1400000000000" },
                { "V1MSIN_NUM_APOL" , "6501000001" },
                { "V1MSIN_NRENDOS" , "5" },
                { "V1MSIN_COD_MOEDA" , "1" },
                { "V1MSIN_TIPREG" , "2" },
                { "V1MSIN_RAMO" , "68" },
                { "V1MSIN_CODCAU" , "101" },
                { "V1MSIN_DATORR" , "2023-11-15" },
                { "V1MSIN_PCTRES" , "50.0" },
                { "V1HSIN_OCORHIST" , "300" },
                { "V1HSIN_OPERACAO" , "0101" },
                { "V1HSIN_DTMOVTO" , "2023-12-01" },
                { "V1HSIN_VAL_OPER" , "1000.0" },
                { "V1HSIN_TIPREG" , "1" },
                { "V1HSIN_SITUACAO" , "A" },
                { "GEOPERAC_FUNCAO_OPERACAO" , "FUNC123" },
                { "GEOPERAC_IND_TIPO_FUNCAO" , "T" },
            }, new SQLCA(99));

                q2.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_NUM_SINI" , "1400000000000" },
                { "V1MSIN_NUM_APOL" , "6501000001" },
                { "V1MSIN_NRENDOS" , "5" },
                { "V1MSIN_COD_MOEDA" , "1" },
                { "V1MSIN_TIPREG" , "2" },
                { "V1MSIN_RAMO" , "68" },
                { "V1MSIN_CODCAU" , "101" },
                { "V1MSIN_DATORR" , "2023-11-15" },
                { "V1MSIN_PCTRES" , "50.0" },
                { "V1HSIN_OCORHIST" , "300" },
                { "V1HSIN_OPERACAO" , "0101" },
                { "V1HSIN_DTMOVTO" , "2023-12-01" },
                { "V1HSIN_VAL_OPER" , "1000.0" },
                { "V1HSIN_TIPREG" , "1" },
                { "V1HSIN_SITUACAO" , "A" },
                { "GEOPERAC_FUNCAO_OPERACAO" , "FUNC123" },
                { "GEOPERAC_IND_TIPO_FUNCAO" , "DS" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0077B_V1MESTSINI");
                AppSettings.TestSet.DynamicData.Add("AC0077B_V1MESTSINI", q2);

                #endregion

                #region AC0077B_SX_APOLCOSG

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , "6501000003" },
                { "SX118_COD_CONGENERE" , "500" },
                { "SX118_PCT_PARTICIPACAO" , "25.0" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0077B_SX_APOLCOSG");
                AppSettings.TestSet.DynamicData.Add("AC0077B_SX_APOLCOSG", q3);

                #endregion

                #region R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_AVS" , "2023-12-02" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GESISFUO_IDE_SISTEMA" , "SYS1" },
                { "GESISFUO_COD_FUNCAO" , "F100" },
                { "GESISFUO_IDE_SISTEMA_OPER" , "SYSOP1" },
                { "GESISFUO_NUM_FATOR" , "1.5" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , "6501000004" },
                { "V0APOL_TIPSGU" , "1" },
                { "V0APOL_ORGAO" , "10" },
                { "V0APOL_RAMO" , "48" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1000_00_SELECT_SX010_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , "6501000003" },
                { "SX010_DTA_APOLICE" , "2023-11-20" },
                { "SX010_COD_FONTE" , "FNT1" },
                { "SX017_NUM_RAMO" , "69" },
                { "SX017_COD_PRODUTO" , "P100" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_SX010_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_SX010_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_VL_VENDA" , "150000.0" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0CSIN_COD_EMP" , "EMP1" },
                { "V0CSIN_TIPSGU" , "T2" },
                { "V0CSIN_CONGENER" , "CONG1" },
                { "V0CSIN_NUM_SINI" , "654321" },
                { "V0CSIN_VAL_OPER" , "2000.0" },
                { "V0CSIN_SITUACAO" , "B" },
                { "V0CSIN_SIT_CONG" , "C1" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0CHSI_COD_EMP" , "EMP2" },
                { "V0CHSI_CONGENER" , "CONG2" },
                { "V0CHSI_NUM_SINI" , "654322" },
                { "V0CHSI_OCORHIST" , "301" },
                { "V0CHSI_OPERACAO" , "201" },
                { "V0CHSI_DTMOVTO" , "2023-12-03" },
                { "V0CHSI_VAL_OPER" , "3000.0" },
                { "V0CHSI_SITUACAO" , "C" },
                { "V0CHSI_TIPSGU" , "T3" },
                { "V0CHSI_SIT_LIBRC" , "L1" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1CSIN_CONGENER" , "CONG3" },
                { "V1CSIN_NUM_SINI" , "654323" },
                { "V1CSIN_TIPSGU" , "T4" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , "D" },
                { "V1CSIN_CONGENER" , "CONG3" },
                { "V1CSIN_NUM_SINI" , "654323" },
                { "V1CSIN_TIPSGU" , "T4" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1", q12);

                #endregion

                #endregion
                #endregion
                var program = new AC0077B();
                program.Execute();

               
                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}