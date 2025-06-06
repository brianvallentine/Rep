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
using static Code.VA0142B;

namespace FileTests.Test
{
    [Collection("VA0142B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0142B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0142B_V0HISCONPA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0142B_V0HISCONPA", q1);

            #endregion

            #region R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAP_NUM_ITEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_PRM_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT1" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT2" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q6);

            #endregion

            #region VA0142B_V0APOLICOB

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0142B_V0APOLICOB", q7);

            #endregion

            #region R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_SIT_REGISTRO" , ""},
                { "VIND_NULL02" , ""},
                { "APOLICOB_COD_EMPRESA" , ""},
                { "VIND_NULL01" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
                { "APOLICOB_COD_EMPRESA" , ""},
                { "APOLICOB_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SVA0142B_FILE_NAME_P")]
        public static void VA0142B_Tests_Theory(string SVA0142B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0142B_FILE_NAME_P = $"{SVA0142B_FILE_NAME_P}_{timestamp}.txt";
            
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAP_NUM_ITEM" , "123"}
                });
                AppSettings.TestSet.DynamicData.Add("R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1", q2);

                AppSettings.TestSet.DynamicData.Remove("R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_PRM_TOTAL" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q3);

                AppSettings.TestSet.DynamicData.Remove("R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT1" , "1"},
                { "APOLICOB_OCORR_HISTORICO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q4);

                AppSettings.TestSet.DynamicData.Remove("R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_DATA_INIVIGENCIA" , "2024-11-20"},
                { "APOLICOB_DATA_TERVIGENCIA" , "2024-11-27"},
                });
                AppSettings.TestSet.DynamicData.Add("R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q6);

                #endregion
                var program = new VA0142B();
                program.Execute(SVA0142B_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("APOLICOB_NUM_ITEM", out string valor) && valor == "000000123");

            }
        }
    }
}