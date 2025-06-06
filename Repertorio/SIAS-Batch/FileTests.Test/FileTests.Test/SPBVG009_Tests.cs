using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.SPBVG009;

namespace FileTests.Test
{
    [Collection("SPBVG009_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class SPBVG009_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region P0301_05_INICIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "VG113_COD_PESSOA" , ""},
                { "VG113_SEQ_PESSOA_HIST" , ""},
                { "VG113_COD_CLASSIF_RISCO" , ""},
                { "VG113_NUM_SCORE_RISCO" , ""},
                { "VG113_DTA_CLASSIF_RISCO" , ""},
                { "VG113_IND_PEND_APROVACAO" , ""},
                { "VG113_IND_DECL_AUTOMATICO" , ""},
                { "VG113_IND_ATLZ_FAIXA_RISCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0301_05_INICIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region P3021_05_INICIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "VG110_COD_PESSOA" , ""},
                { "VG110_SEQ_PESSOA_HIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P3021_05_INICIO_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void SPBVG009_Tests_Fact()
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
                #region P0050_05_INICIO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q0);

                #endregion

                #region P0301_05_INICIO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "VG113_COD_PESSOA" , ""},
                { "VG113_SEQ_PESSOA_HIST" , ""},
                { "VG113_COD_CLASSIF_RISCO" , ""},
                { "VG113_NUM_SCORE_RISCO" , ""},
                { "VG113_DTA_CLASSIF_RISCO" , ""},
                { "VG113_IND_PEND_APROVACAO" , ""},
                { "VG113_IND_DECL_AUTOMATICO" , ""},
                { "VG113_IND_ATLZ_FAIXA_RISCO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("P0301_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0301_05_INICIO_DB_SELECT_1_Query1", q1);

                #endregion

                #region P3021_05_INICIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "VG110_COD_PESSOA" , ""},
                { "VG110_SEQ_PESSOA_HIST" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("P3021_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P3021_05_INICIO_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                var program = new SPBVG009();

                SPVG009W obj = new SPVG009W();
                obj.LK_VG009_E_TIPO_ACAO.Value = 01;
                obj.LK_VG009_E_TRACE.Value = "S";
                obj.LK_VG009_E_COD_USUARIO.Value = "X";
                obj.LK_VG009_E_NOM_PROGRAMA.Value = "X";
                obj.LK_VG009_E_NUM_PROPOSTA.Value = 1;

                //program.Execute(new SPVG009W());
                program.Execute(obj);

                var envList1 = AppSettings.TestSet.DynamicData["P0050_05_INICIO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["P0301_05_INICIO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["P3021_05_INICIO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                Assert.True(program.WORK.WS_ERRO.WS_IND_ERRO == 0);

            }
        }


        [Fact]
        public static void SPBVG009_Tests99_Fact()
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
                #region P0050_05_INICIO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q0);

                #endregion

                #region P0301_05_INICIO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "VG113_COD_PESSOA" , ""},
                { "VG113_SEQ_PESSOA_HIST" , ""},
                { "VG113_COD_CLASSIF_RISCO" , ""},
                { "VG113_NUM_SCORE_RISCO" , ""},
                { "VG113_DTA_CLASSIF_RISCO" , ""},
                { "VG113_IND_PEND_APROVACAO" , ""},
                { "VG113_IND_DECL_AUTOMATICO" , ""},
                { "VG113_IND_ATLZ_FAIXA_RISCO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("P0301_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0301_05_INICIO_DB_SELECT_1_Query1", q1);

                #endregion

                #region P3021_05_INICIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "VG110_COD_PESSOA" , ""},
                { "VG110_SEQ_PESSOA_HIST" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("P3021_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P3021_05_INICIO_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                var program = new SPBVG009();
                program.Execute(new SPVG009W());
               
                

                Assert.True(program.WORK.WS_ERRO.WS_IND_ERRO != 0);

            }
        }


    }
}