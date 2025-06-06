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
using static Code.LT3117S;

namespace FileTests.Test
{
    [Collection("LT3117S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3117S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PRAZOSEG_PCT_PRM_ANUAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0200_00_LE_ENDOSSOS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LE_ENDOSSOS_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void LT3117S_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                LT3142S_Tests.Load_Parameters_to_LT3117S();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var paramentros = new LBLT3117();
                paramentros.LT3117_VL_IS_INCENDIO.Value = 1000;
                paramentros.LT3117_VL_IS_VALORES.Value = 1000;
                paramentros.LT3117_VL_IS_DANELET.Value = 1000;
                paramentros.LT3117_VL_IS_AP_EMPGDR.Value = 1000;
                paramentros.LT3117_VL_IS_AP_EMP.Value = 1000;
                paramentros.LT3117_VL_IS_RC.Value = 1000;
                paramentros.LT3117_TX_INCENDIO.Value = 1000;
                paramentros.LT3117_TX_VALORES.Value = 1000;
                paramentros.LT3117_TX_DANELET.Value = 1000;
                paramentros.LT3117_TX_AP_EMPGDR.Value = 1000;
                paramentros.LT3117_TX_AP_EMP.Value = 1000;
                paramentros.LT3117_TX_RC.Value = 1000;
                paramentros.LT3117_NUM_CLASSE_ADESAO.Value = 10;
                paramentros.LT3117_DTINIVIG_APOLICE.Value = "2025-03-14";
                paramentros.LT3117_DTTERVIG_APOLICE.Value = "2025-03-14";
                paramentros.LT3117_QTD_PARCELAS.Value = 2;
                paramentros.LT3117_PCT_IOF.Value = 2;
                paramentros.LT3117_TIPO_CALCULO.Value = " ";
                #endregion
                var program = new LT3117S();
                program.Execute(paramentros);

                Assert.Empty(AppSettings.TestSet.DynamicData["R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1"].DynamicList.ToList());

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}