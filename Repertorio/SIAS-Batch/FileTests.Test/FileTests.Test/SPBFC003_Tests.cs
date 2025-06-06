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
using static Code.SPBFC003;

namespace FileTests.Test
{
    [Collection("SPBFC003_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SPBFC003_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SPBFC003_CSS_SEQUENCE

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "FCSEQUEN_NUM_SEQ" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SPBFC003_CSS_SEQUENCE", q0);

            #endregion

            #region P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FCSEQUEN_NUM_SEQ" , ""},
                { "FCSEQUEN_COD_SEQ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1", q1);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1_Query1", q2);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1_Query1", q3);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1_Query1", q4);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1_Query1", q5);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1", q6);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1_Query1", q7);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1_Query1", q8);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1_Query1", q9);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1_Query1", q10);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1_Query1", q11);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1_Query1", q12);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1_Query1", q13);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1_Query1", q14);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1_Query1", q15);

            #endregion

            #region P100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "LK_OUT_NUM_SEQ_INI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1_Query1", q16);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("LK_IN_COD_SEQ_P", 56789, 1234, 4567, 2378, 1379, "LK_OUT_MENSAGEM_P", "LK_OUT_SQLERRMC_P", "LK_OUT_SQLSTATE_P")]
        public static void SPBFC003_Tests_Theory(string LK_IN_COD_SEQ_P, int LK_IN_QTD_SEQ_P, int LK_OUT_NUM_SEQ_INI_P, int LK_OUT_NUM_SEQ_FIM_P, int LK_OUT_COD_RETORNO_P, int LK_OUT_SQLCODE_P, string LK_OUT_MENSAGEM_P, string LK_OUT_SQLERRMC_P, string LK_OUT_SQLSTATE_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            LK_IN_COD_SEQ_P = $"{LK_IN_COD_SEQ_P}_{timestamp}.txt";
            LK_OUT_MENSAGEM_P = $"{LK_OUT_MENSAGEM_P}_{timestamp}.txt";
            LK_OUT_SQLERRMC_P = $"{LK_OUT_SQLERRMC_P}_{timestamp}.txt";
            LK_OUT_SQLSTATE_P = $"{LK_OUT_SQLSTATE_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new SPBFC003();
                program.Execute(new StringBasis(null, LK_IN_COD_SEQ_P), new IntBasis(null, LK_IN_QTD_SEQ_P), new IntBasis(null, LK_OUT_NUM_SEQ_INI_P), new IntBasis(null, LK_OUT_NUM_SEQ_FIM_P), new IntBasis(null, LK_OUT_COD_RETORNO_P), new IntBasis(null, LK_OUT_SQLCODE_P), new StringBasis(null, LK_OUT_MENSAGEM_P), new StringBasis(null, LK_OUT_SQLERRMC_P), new StringBasis(null, LK_OUT_SQLSTATE_P));

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("FCSEQUEN_NUM_SEQ", out var valor) && valor == "000056789");

                Assert.True(program.LK_OUT_COD_RETORNO == 0);
            }
        }
        
        [Theory]
        [InlineData("LK_IN_COD_SEQ_P", 56789, 1234, 4567, 2378, 1379, "LK_OUT_MENSAGEM_P", "LK_OUT_SQLERRMC_P", "LK_OUT_SQLSTATE_P")]
        public static void SPBFC003_Tests_Erro(string LK_IN_COD_SEQ_P, int LK_IN_QTD_SEQ_P, int LK_OUT_NUM_SEQ_INI_P, int LK_OUT_NUM_SEQ_FIM_P, int LK_OUT_COD_RETORNO_P, int LK_OUT_SQLCODE_P, string LK_OUT_MENSAGEM_P, string LK_OUT_SQLERRMC_P, string LK_OUT_SQLSTATE_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            LK_IN_COD_SEQ_P = $"{LK_IN_COD_SEQ_P}_{timestamp}.txt";
            LK_OUT_MENSAGEM_P = $"{LK_OUT_MENSAGEM_P}_{timestamp}.txt";
            LK_OUT_SQLERRMC_P = $"{LK_OUT_SQLERRMC_P}_{timestamp}.txt";
            LK_OUT_SQLSTATE_P = $"{LK_OUT_SQLSTATE_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                AppSettings.TestSet.DynamicData.Remove("SPBFC003_CSS_SEQUENCE");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "FCSEQUEN_NUM_SEQ" , ""}
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Add("SPBFC003_CSS_SEQUENCE", q0);
                #endregion
                var program = new SPBFC003();
                program.Execute(new StringBasis(null, LK_IN_COD_SEQ_P), new IntBasis(null, LK_IN_QTD_SEQ_P), new IntBasis(null, LK_OUT_NUM_SEQ_INI_P), new IntBasis(null, LK_OUT_NUM_SEQ_FIM_P), new IntBasis(null, LK_OUT_COD_RETORNO_P), new IntBasis(null, LK_OUT_SQLCODE_P), new StringBasis(null, LK_OUT_MENSAGEM_P), new StringBasis(null, LK_OUT_SQLERRMC_P), new StringBasis(null, LK_OUT_SQLSTATE_P));
               

                Assert.True(program.LK_OUT_COD_RETORNO == 1);
            }
        }
    }
}