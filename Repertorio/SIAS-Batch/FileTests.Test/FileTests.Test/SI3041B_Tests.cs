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
using static Code.SI3041B;

namespace FileTests.Test
{
    [Collection("SI3041B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI3041B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1", q2);

            #endregion

            #region SI3041B_MOTIVOS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIMOTIVO_COD_TIPO_MOTIVO" , ""},
                { "SIMOTIVO_NUM_MOTIVO" , ""},
                { "SIMOTIVO_DES_MOTIVO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI3041B_MOTIVOS", q3);

            #endregion

            #region R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SITIPMOT_DES_TIPO_MOTIVO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "GEARDETA_DTH_GERACAO" , ""},
                { "GEARDETA_IND_MEIO_ENVIO" , ""},
                { "GEARDETA_STA_ENVIO_RECEPCAO" , ""},
                { "GEARDETA_COD_TIPO_ARQUIVO" , ""},
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
                { "GEARDETA_QTD_REG_REJEITADOS" , ""},
                { "GEARDETA_QTD_REG_ACEITOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R8000_00_LE_DATA_CALENDARIO_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DTH_ULT_DIA_MES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_LE_DATA_CALENDARIO_DB_SELECT_2_Query1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI3041B_OUTPUT_202504220000")]
        public static void SI3041B_Tests_Theory(string ARQ_SEGAB02_FILE_NAME_P)
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
                var program = new SI3041B();
                program.Execute(ARQ_SEGAB02_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.Empty(AppSettings.TestSet.DynamicData["SI3041B_MOTIVOS"].DynamicList.ToList());

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}