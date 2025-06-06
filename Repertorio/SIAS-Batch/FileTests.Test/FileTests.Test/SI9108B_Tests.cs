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
using Dclgens;
using Code;
using static Code.SI9108B;

namespace FileTests.Test
{
    [Collection("SI9108B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9108B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI9108B_C01_SIARDEVC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9108B_C01_SIARDEVC", q2);

            #endregion

            #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_SALDO_PAGAR_IX" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , ""},
                { "HOST_NUM_EXPEDIENTE_VC" , ""},
                { "HOST_COD_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISMES_SALDO_PAGAR_IX" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , ""},
                { "IND_COD_ERRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI9108B_Tests_Fact()
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
                #endregion
                var program = new SI9108B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);
                Assert.Empty(AppSettings.TestSet.DynamicData["SI9108B_C01_SIARDEVC"].DynamicList.ToList());

                var insert = AppSettings.TestSet.DynamicData["R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert?.Count > 1);
                Assert.True(insert[1].TryGetValue("SINISMES_OCORR_HISTORICO", out var valOr1) && valOr1 == "0001");

                var update = AppSettings.TestSet.DynamicData["R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update?.Count > 1);
                Assert.True(update[1].TryGetValue("SINISMES_OCORR_HISTORICO", out var valOr2) && valOr2 == "0001");

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}