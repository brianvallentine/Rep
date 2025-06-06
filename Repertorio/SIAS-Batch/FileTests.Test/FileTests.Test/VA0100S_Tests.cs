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
using static Code.VA0100S;

namespace FileTests.Test
{
    [Collection("VA0100S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0100S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1
            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , "998877665544"},
                { "COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region Execute_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q1);

            #endregion

            #region M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DTMOVTO" , ""},
                { "CODPRODAZ" , ""},
                { "CODOPER" , ""},
                { "VLOPER" , ""},
                { "NUMFAT" , ""},
                { "VLIOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1", q2);

            #endregion

            #region Execute_DB_SELECT_3_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_3_Query1", q3);

            #endregion

            #region Execute_DB_SELECT_4_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_W" , "2050"},
                { "VLIOCC_W" , ""},
            }, new SQLCA(100));
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q4);

            #endregion

            #region M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_W" , ""},
                { "VLIOCC_W" , ""},
                { "CODPRODAZ" , ""},
                { "DTMOVTO" , ""},
                { "CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_FIL" , ""},
                { "VLIOCC_FIL" , ""},
            }, new SQLCA(100));
            AppSettings.TestSet.DynamicData.Add("M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , ""},
                { "FONTE" , ""},
                { "COD_SUBGRUPO" , ""},
                { "CODOPER" , ""},
                { "VLOPER" , ""},
                { "DTMOVTO" , ""},
                { "NUMFAT" , ""},
                { "VLIOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1", q7);

            #endregion

            #region M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_FIL" , ""},
                { "VLIOCC_FIL" , ""},
                { "COD_SUBGRUPO" , ""},
                { "NUM_APOLICE" , ""},
                { "DTMOVTO" , ""},
                { "CODOPER" , ""},
                { "FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0100S_Tests_Fact()
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


                VA0100S_PARAMETROS vA0100S_PARAMETROS = new VA0100S_PARAMETROS();
                vA0100S_PARAMETROS.PARM_CODOPER.SetValue(0101);

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1");

                AppSettings.TestSet.DynamicData.Add("M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1", q6);

                #region Execute_DB_SELECT_4_Query1
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_4_Query1");

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_W" , "2050"},
                { "VLIOCC_W" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q4);

                #endregion
                #endregion
                var program = new VA0100S();
                program.Execute(vA0100S_PARAMETROS);

                var envList = AppSettings.TestSet.DynamicData["M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("VLOPER_W", out var val1r) && val1r.Equals("0000000002050.00"));

                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("NUM_APOLICE", out val1r) && val1r.Equals("0998877665544"));

            }
        }

        [Fact]
        public static void VA0100S_Tests_Fact_M_0500_ALTERA_LANCAMENTO()
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

                VA0100S_PARAMETROS vA0100S_PARAMETROS = new VA0100S_PARAMETROS();
                vA0100S_PARAMETROS.PARM_CODOPER.SetValue(0101);

                #region Execute_DB_SELECT_4_Query1
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_4_Query1");

                var q4 = new DynamicData();
             /*   q4.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_W" , "2050"},
                { "VLIOCC_W" , ""},
            });*/
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q4);

                #endregion
                #region M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1");

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_FIL" , ""},
                { "VLIOCC_FIL" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new VA0100S();
                program.Execute(vA0100S_PARAMETROS);

                var envList = AppSettings.TestSet.DynamicData["M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("NUM_APOLICE", out var val1r) && val1r.Equals("0998877665544"));
                Assert.True(envList1[1].TryGetValue("CODOPER", out val1r) && val1r.Equals("0101"));

            }
        }
    }
}