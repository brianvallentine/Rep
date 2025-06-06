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
using static Code.SI1000B;

namespace FileTests.Test
{
    [Collection("SI1000B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI1000B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2024-11-30"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "0.00005"}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI1000B_V1MESTSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_TIPREG" , ""},
                { "V1MSIN_NUM_SINI" , ""},
                { "V1MSIN_NUM_APOL" , ""},
                { "V1MSIN_CODPRODU" , ""},
                { "V1MSIN_IDTPSEGU" , ""},
                { "V1MSIN_OCORHIST" , ""},
                { "V1MSIN_DATCMD" , ""},
                { "V1MSIN_COD_MOEDA" , ""},
                { "V1MSIN_SDOPAGBT" , ""},
                { "V1HSIN_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI1000B_V1MESTSINI", q2);

            #endregion

            #region R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_COD_EMP" , ""},
                { "V0HSIN_TIPREG" , ""},
                { "V0HSIN_NUM_SINI" , ""},
                { "V0HSIN_OCORHIST" , ""},
                { "V0HSIN_OPERACAO" , ""},
                { "V0HSIN_DTMOVTO" , ""},
                { "V0HSIN_HORAOPER" , ""},
                { "V0HSIN_NOMFAV" , ""},
                { "V0HSIN_VAL_OPER" , ""},
                { "V0HSIN_LIMCRR" , ""},
                { "V0HSIN_TIPFAV" , ""},
                { "V0HSIN_DATNEG" , ""},
                { "V0HSIN_FONPAG" , ""},
                { "V0HSIN_CODPSVI" , ""},
                { "V0HSIN_CODSVI" , ""},
                { "V0HSIN_NUMOPG" , ""},
                { "V0HSIN_NUMREC" , ""},
                { "V0HSIN_MOVPCS" , ""},
                { "V0HSIN_CODUSU" , ""},
                { "V0HSIN_SITCONTB" , ""},
                { "V0HSIN_SITUACAO" , ""},
                { "V0HSIN_NUM_APOL" , ""},
                { "V0HSIN_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_OCORHIST" , ""},
                { "V0HSIN_NUM_SINI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_DTMOVTO_MAX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI1000B_Tests_Fact()
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
                #region SI1000B_V1MESTSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_TIPREG" , "1"},
                { "V1MSIN_NUM_APOL_SINISTRO" , "19790324"},
                { "V1MSIN_NUM_APOLICE" , "66020100826"},
                { "V1MSIN_CODPRODU" , "6600"},
                { "V1MSIN_IDTPSEGU" , " "},
                { "V1MSIN_OCORHIST" , "2"},
                { "V1MSIN_DATCMD" , "2024-04-08"},
                { "V1MSIN_COD_MOEDA_SINI" , "1"},
                { "V1MSIN_SDOPAGBT" , "50000.00000"},
                { "V1MSIN_DTMOVTO" , "2024-08-16"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI1000B_V1MESTSINI");
                AppSettings.TestSet.DynamicData.Add("SI1000B_V1MESTSINI", q2);

                #endregion
                #region R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "2"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new SI1000B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);
                //R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0.Count > 1);
                Assert.True(envList0[1].TryGetValue("V0HSIN_NUM_SINI", out var val0r) && val0r.Contains("0000019790324"));
                Assert.True(envList0[1].TryGetValue("V0HSIN_NUM_APOL", out var val1r) && val1r.Contains("0066020100826"));

                //R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0HSIN_NUM_SINI", out var val2r) && val2r.Contains("0000019790324"));
            }
        }
        [Fact]
        public static void SI1000B_Tests_Fact_SemMoeda_ReturnCode_99()
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
                #region R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new SI1000B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}