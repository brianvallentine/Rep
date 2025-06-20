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
using static Code.VP5705B;

namespace FileTests.Test
{
    [Collection("VP5705B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VP5705B_Tests
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

            #region VP5705B_V0MOVIMENTO

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
                { "SQL_PRM_VG" , ""},
                { "SQL_PRM_AP" , ""},
                { "SQL_PRM_VG_ATU" , ""},
                { "SQL_PRM_AP_ATU" , ""},
                { "SQL_COD_OPERAC" , ""},
                { "SQL_FAIXA" , ""},
                { "SQL_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP5705B_V0MOVIMENTO", q1);

            #endregion

            #region VP5705B_PLANOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_NRPARCEL" , ""},
                { "SQL_PERC_COMIS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP5705B_PLANOS", q2);

            #endregion

            #region M_0000_INICIO_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_UPDATE_1_Update1", q3);

            #endregion

            #region M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_CODCLI" , ""},
                { "V1SEGV_DTNASCIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_DTNASCIM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_CERT" , ""},
                { "SQL_NRPARCEL" , ""},
                { "SQL_CODOPER_PLANOS" , ""},
                { "SQL_DTMOVABE" , ""},
                { "SQL_PRM_VG_CO" , ""},
                { "SQL_PRM_AP_CO" , ""},
                { "SQL_PERC_COMIS" , ""},
                { "SQL_COD_FONTE" , ""},
                { "SQL_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1", q6);

            #endregion

            #endregion
        }

        [Fact]
        public static void VP5705B_Tests_Fact()
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

                #region VP5705B_V0MOVIMENTO

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , "123456789" },
                { "SQL_COD_SUB" , "001" },
                { "SQL_COD_FONTE" , "002" },
                { "SQL_PROPOSTA" , "P123456789" },
                { "SQL_TIPO_SEG" , "Vida" },
                { "SQL_NUM_CERT" , "987654321" },
                { "SQL_DAC_CERT" , "5" },
                { "SQL_COD_CLIE" , "C123456" },
                { "SQL_COD_AGEN" , "A123" },
                { "SQL_PRM_VG" , "100000.00" },
                { "SQL_PRM_AP" , "50000.00" },
                { "SQL_PRM_VG_ATU" , "110000.00" },
                { "SQL_PRM_AP_ATU" , "55000.00" },
                { "SQL_COD_OPERAC" , "OP123" },
                { "SQL_FAIXA" , "30-40" },
                { "SQL_DTMOVTO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP5705B_V0MOVIMENTO");
AppSettings.TestSet.DynamicData.Add("VP5705B_V0MOVIMENTO", q1);

                #endregion

                #region VP5705B_PLANOS

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_NRPARCEL" , "12" },
                { "SQL_PERC_COMIS" , "10.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP5705B_PLANOS");
AppSettings.TestSet.DynamicData.Add("VP5705B_PLANOS", q2);

                #endregion

                #region M_0000_INICIO_DB_UPDATE_1_Update1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_0000_INICIO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_UPDATE_1_Update1", q3);

                #endregion

                #region M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_CODCLI" , "V123456" },
                { "V1SEGV_DTNASCIM" , "1990-01-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_DTNASCIM" , "1990-01-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_CERT" , "987654321" },
                { "SQL_NRPARCEL" , "12" },
                { "SQL_CODOPER_PLANOS" , "PL123" },
                { "SQL_DTMOVABE" , "2023-12-01" },
                { "SQL_PRM_VG_CO" , "120000.00" },
                { "SQL_PRM_AP_CO" , "60000.00" },
                { "SQL_PERC_COMIS" , "10.00" },
                { "SQL_COD_FONTE" , "002" },
                { "SQL_PROPOSTA" , "P123456789" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1", q6);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VP5705B();
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
        public static void VP5705B_Tests_Fact_Return99()
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
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_0000_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_1_Query1", q0);

                #endregion

                #region VP5705B_V0MOVIMENTO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , "123456789" },
                { "SQL_COD_SUB" , "001" },
                { "SQL_COD_FONTE" , "002" },
                { "SQL_PROPOSTA" , "P123456789" },
                { "SQL_TIPO_SEG" , "Vida" },
                { "SQL_NUM_CERT" , "987654321" },
                { "SQL_DAC_CERT" , "5" },
                { "SQL_COD_CLIE" , "C123456" },
                { "SQL_COD_AGEN" , "A123" },
                { "SQL_PRM_VG" , "100000.00" },
                { "SQL_PRM_AP" , "50000.00" },
                { "SQL_PRM_VG_ATU" , "110000.00" },
                { "SQL_PRM_AP_ATU" , "55000.00" },
                { "SQL_COD_OPERAC" , "OP123" },
                { "SQL_FAIXA" , "30-40" },
                { "SQL_DTMOVTO" , "2023-12-01" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VP5705B_V0MOVIMENTO");
                AppSettings.TestSet.DynamicData.Add("VP5705B_V0MOVIMENTO", q1);

                #endregion

                #region VP5705B_PLANOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_NRPARCEL" , "12" },
                { "SQL_PERC_COMIS" , "10.00" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VP5705B_PLANOS");
                AppSettings.TestSet.DynamicData.Add("VP5705B_PLANOS", q2);

                #endregion

                #region M_0000_INICIO_DB_UPDATE_1_Update1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_DTMOVABE" , "2023-12-01" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_0000_INICIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_UPDATE_1_Update1", q3);

                #endregion

                #region M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_CODCLI" , "V123456" },
                { "V1SEGV_DTNASCIM" , "1990-01-01" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_DTNASCIM" , "1990-01-01" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_CERT" , "987654321" },
                { "SQL_NRPARCEL" , "12" },
                { "SQL_CODOPER_PLANOS" , "PL123" },
                { "SQL_DTMOVABE" , "2023-12-01" },
                { "SQL_PRM_VG_CO" , "120000.00" },
                { "SQL_PRM_AP_CO" , "60000.00" },
                { "SQL_PERC_COMIS" , "10.00" },
                { "SQL_COD_FONTE" , "002" },
                { "SQL_PROPOSTA" , "P123456789" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1", q6);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VP5705B();
                program.Execute();

                Assert.True(program.RETURN_CODE != 00);
            }
        }
    }
}