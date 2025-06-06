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
using static Code.VP6706B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VP6706B_Tests")]
    public class VP6706B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SQL_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region VP6706B_V0MOVIMENTO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , ""},
                { "SQL_COD_SUB" , ""},
                { "SQL_COD_FONTE" , ""},
                { "SQL_PROPOSTA" , ""},
                { "SQL_TIPO_SEG" , ""},
                { "SQL_NUM_CERT" , ""},
                { "SQL_DAC_CERT" , ""},
                { "SQL_COD_CLIE" , ""},
                { "SQL_COD_AGEN" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_PRM_VG" , ""},
                { "SQL_PRM_AP" , ""},
                { "SQL_COD_OPERAC" , ""},
                { "SQL_FAIXA" , ""},
                { "SQL_PERC_COMIS" , ""},
                { "SQL_NRPARCEL" , ""},
                { "SQL_DTMOVTO" , ""},
                { "SQL_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP6706B_V0MOVIMENTO", q1);

            #endregion

            #region M_0000_INICIO_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_2_Query1", q2);

            #endregion

            #region M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_DTADMIS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_1300_UPDATE_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SQL_SITUACAO" , ""},
                { "SQL_DTMOVABE" , ""},
                { "SQL_COD_OPERAC" , ""},
                { "SQL_NUM_CERT" , ""},
                { "SQL_NRPARCEL" , ""},
                { "SQL_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1300_UPDATE_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , ""},
                { "SQL_NUM_CERT" , ""},
                { "SQL_DAC_CERT" , ""},
                { "SQL_TIPO_SEG" , ""},
                { "SQL_COD_AGEN" , ""},
                { "SQL_RAMOFR" , ""},
                { "SQL_COD_FONTE" , ""},
                { "SQL_COD_CLIE" , ""},
                { "SQL_VLCOMIS" , ""},
                { "SQL_DTMOVABE" , ""},
                { "SQL_VALBAS" , ""},
                { "SQL_PCT_AGENC" , ""},
                { "SQL_COD_SUB" , ""},
                { "SQL_HORAOPER" , ""},
                { "SQL_DATSEL" , ""},
                { "SQL_PROPOSTA" , ""},
                { "SQL_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void VP6706B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region M_0000_INICIO_DB_SELECT_1_Query1

                        var q0 = new DynamicData();
                        q0.AddDynamic(new Dictionary<string, string>{
                            { "SQL_DTMOVABE" , "2023-12-01" }
                        });
                        AppSettings.TestSet.DynamicData.Remove("M_0000_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_1_Query1", q0);

                            #endregion

                #region VP6706B_V0MOVIMENTO

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , "123456789" },
                { "SQL_COD_SUB" , "001" },
                { "SQL_COD_FONTE" , "002" },
                { "SQL_PROPOSTA" , "PRO123456" },
                { "SQL_TIPO_SEG" , "Vida" },
                { "SQL_NUM_CERT" , "987654321" },
                { "SQL_DAC_CERT" , "10" },
                { "SQL_COD_CLIE" , "CL12345" },
                { "SQL_COD_AGEN" , "AG987" },
                { "SQL_MATRICULA" , "MT123456" },
                { "SQL_PRM_VG" , "10000.00" },
                { "SQL_PRM_AP" , "5000.00" },
                { "SQL_COD_OPERAC" , "OP1234" },
                { "SQL_FAIXA" , "30-40" },
                { "SQL_PERC_COMIS" , "5%" },
                { "SQL_NRPARCEL" , "12" },
                { "SQL_DTMOVTO" , "2023-12-01" },
                { "SQL_SITUACAO" , "Ativo" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP6706B_V0MOVIMENTO");
AppSettings.TestSet.DynamicData.Add("VP6706B_V0MOVIMENTO", q1);

                #endregion

                #region M_0000_INICIO_DB_SELECT_2_Query1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_PCIOF" , "0.38%" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_0000_INICIO_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_2_Query1", q2);

                #endregion

                #region M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_DTADMIS" , "2020-01-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_1300_UPDATE_DB_UPDATE_1_Update1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SQL_SITUACAO" , "Ativo" },
                { "SQL_DTMOVABE" , "2023-12-01" },
                { "SQL_COD_OPERAC" , "OP1234" },
                { "SQL_NUM_CERT" , "987654321" },
                { "SQL_NRPARCEL" , "12" },
                { "SQL_DTMOVTO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_1300_UPDATE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("M_1300_UPDATE_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , "123456789" },
                { "SQL_NUM_CERT" , "987654321" },
                { "SQL_DAC_CERT" , "10" },
                { "SQL_TIPO_SEG" , "Vida" },
                { "SQL_COD_AGEN" , "AG987" },
                { "SQL_RAMOFR" , "FR001" },
                { "SQL_COD_FONTE" , "002" },
                { "SQL_COD_CLIE" , "CL12345" },
                { "SQL_VLCOMIS" , "500.00" },
                { "SQL_DTMOVABE" , "2023-12-01" },
                { "SQL_VALBAS" , "100000.00" },
                { "SQL_PCT_AGENC" , "10%" },
                { "SQL_COD_SUB" , "001" },
                { "SQL_HORAOPER" , "14:00:00" },
                { "SQL_DATSEL" , "2023-12-01" },
                { "SQL_PROPOSTA" , "PRO123456" },
                { "SQL_NUMBIL" , "BIL123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1", q5);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VP6706B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VP6706B_Tests_Fact_Erro9()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region M_0000_INICIO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                            { "SQL_DTMOVABE" , "2023-12-01" }
                        }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0000_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_1_Query1", q0);

                #endregion


                var program = new VP6706B();
                program.Execute();
                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}