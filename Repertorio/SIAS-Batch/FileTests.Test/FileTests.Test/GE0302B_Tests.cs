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
using static Code.GE0302B;

namespace FileTests.Test
{
    [Collection("GE0302B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0302B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GE100_NUM_OCORR_MOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GE094_COD_CONVENIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1", q1);

            #endregion

            #region Execute_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE113_CHR_USO_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q2);

            #endregion

            #region Execute_DB_SELECT_3_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_3_Query1", q3);

            #endregion

            #region R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                { "HOST_CURRENT_DATE" , ""},
                { "HOST_TIMESTAMP" , ""},
                { "HOST_CURRENT_TIME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region Execute_DB_SELECT_4_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q5);

            #endregion

            #endregion
        }
        [Fact]
        public static void GE0302B_Tests_Fact()
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
                AppSettings.TestSet.DynamicData.Remove("RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1");

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GE094_COD_CONVENIO" , "921286"}
            });
                AppSettings.TestSet.DynamicData.Add("RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1", q1);
                #endregion
                var program = new GE0302B();

                var passingBy = new GE0302B_REGISTRO_LINKAGE_GE0302B();
                passingBy.LK_GE0302B_IDLG.Value = "S1234567890123|12345|1234|P|2|R23|1234567890";
                program.Execute(passingBy);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void GE0302B_Tests_SemDados()
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
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q4);
                #endregion
                var program = new GE0302B();

                var passingBy = new GE0302B_REGISTRO_LINKAGE_GE0302B();
                passingBy.LK_GE0302B_IDLG.Value = "S1234567890123|12345|1234|P|2|R23|1234567890";
                program.Execute(passingBy);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}