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
using static Code.AU9303B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("AU9303B_Tests")]
    public class AU9303B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region AU9303B_V1AUTOAPOL

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1AUTA_NUM_APOLICE" , ""},
                { "V1AUTA_NRENDOS" , ""},
                { "V1AUTA_FONTE" , ""},
                { "V1AUTA_NRPROPOS" , ""},
                { "V1AUTA_NRITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AU9303B_V1AUTOAPOL", q0);

            #endregion

            #region R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0080_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0080_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0083_00_SELECT_V0PARCELA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0083_00_SELECT_V0PARCELA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0AUTP_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0AUTP_SITUACAO" , ""},
                { "V1AUTA_NUM_APOLICE" , ""},
                { "V1AUTA_NRPROPOS" , ""},
                { "V1AUTA_NRENDOS" , ""},
                { "V1AUTA_NRITEM" , ""},
                { "V1AUTA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void AU9303B_Tests_Fact()
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
                var program = new AU9303B();
                program.Execute();

                Assert.True(true);
            }
        }
    }
}