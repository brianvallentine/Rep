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
using static Code.FN0401B;

namespace FileTests.Test
{
    [Collection("FN0401B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class FN0401B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
                { "V1SIST_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region FN0401B_V1HISTOPARC

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUMAPOL" , ""},
                { "V1HIST_NRENDOS" , ""},
                { "V1HIST_NRPARCEL" , ""},
                { "V1HIST_DTMOVTO" , ""},
                { "V1HIST_OPERACAO" , ""},
                { "V1HIST_OCORHIST" , ""},
                { "V1HIST_VLPRMLIQ" , ""},
                { "V1HIST_VLPRMTOT" , ""},
                { "V1HIST_DTQITBCO" , ""},
                { "V1HIST_DTVENCTO" , ""},
                { "V0ENDO_CODSUBES" , ""},
                { "V0ENDO_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0401B_V1HISTOPARC", q1);

            #endregion

            #region R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODCORR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("FN0401B_o1")]
        public void FN0401B_Test_Cenario_1(string FENHIST_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_DTCURRENT" , "2023-12-01" },
                { "V1SIST_TIMESTAMP" , "2023-12-01T12:00:00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region FN0401B_V1HISTOPARC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUMAPOL" , "123456" },
                { "V1HIST_NRENDOS" , "654321" },
                { "V1HIST_NRPARCEL" , "10" },
                { "V1HIST_DTMOVTO" , "2023-12-01" },
                { "V1HIST_OPERACAO" , "220" },
                { "V1HIST_OCORHIST" , "805" },
                { "V1HIST_VLPRMLIQ" , "1000.5" },
                { "V1HIST_VLPRMTOT" , "2000.75" },
                { "V1HIST_DTQITBCO" , "2023-12-01" },
                { "V1HIST_DTVENCTO" , "2024-01-01" },
                { "V0ENDO_CODSUBES" , "300" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            });
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUMAPOL" , "123456" },
                { "V1HIST_NRENDOS" , "654321" },
                { "V1HIST_NRPARCEL" , "10" },
                { "V1HIST_DTMOVTO" , "2023-12-01" },
                { "V1HIST_OPERACAO" , "150" },
                { "V1HIST_OCORHIST" , "805" },
                { "V1HIST_VLPRMLIQ" , "1000.5" },
                { "V1HIST_VLPRMTOT" , "2000.75" },
                { "V1HIST_DTQITBCO" , "2023-12-01" },
                { "V1HIST_DTVENCTO" , "2024-01-01" },
                { "V0ENDO_CODSUBES" , "300" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            });

                AppSettings.TestSet.DynamicData.Remove("FN0401B_V1HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("FN0401B_V1HISTOPARC", q1);

                #endregion

                #region R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODCORR" , "400" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion
                #endregion


                var program = new FN0401B();
                program.Execute(FENHIST_FILE_NAME_P);

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
        

        [Theory]
        [InlineData("FN0401B_o99")]
        public void FN0401B_Test_Cenario_99(string FENHIST_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_DTCURRENT" , "2023-12-01" },
                { "V1SIST_TIMESTAMP" , "2023-12-01T12:00:00" },
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region FN0401B_V1HISTOPARC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUMAPOL" , "123456" },
                { "V1HIST_NRENDOS" , "654321" },
                { "V1HIST_NRPARCEL" , "1" },
                { "V1HIST_DTMOVTO" , "2023-12-01" },
                { "V1HIST_OPERACAO" , "234" },
                { "V1HIST_OCORHIST" , "222" },
                { "V1HIST_VLPRMLIQ" , "1000.5" },
                { "V1HIST_VLPRMTOT" , "1500.75" },
                { "V1HIST_DTQITBCO" , "2023-12-01" },
                { "V1HIST_DTVENCTO" , "2024-01-01" },
                { "V0ENDO_CODSUBES" , "Subespecie Z" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("FN0401B_V1HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("FN0401B_V1HISTOPARC", q1);

                #endregion

                #region R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODCORR" , "Corretor A" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion
                #endregion


                var program = new FN0401B();
                program.Execute(FENHIST_FILE_NAME_P);

                Assert.True(program.AREA_DE_WORK.WABEND.WNR_EXEC_SQL.Value == "0100");

            }
        }



    }
}