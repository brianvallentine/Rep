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
using static Code.EF0101S;

namespace FileTests.Test
{
    [Collection("EF0101S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class EF0101S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LS_V0CONT_DATA_CONTRATO" , ""},
                { "LS_V0CONT_PRZ_VIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData(123456789, "123456789", "123456789", 123456789, 123456789)]
        public static void EF0101S_Tests_Theory(int LS_V0HAB01_NUM_CONTRATO_P, string LS_SINI_DATORR_P, string LS_V0CONT_DATA_CONTRATO_P, int LS_V0CONT_PRZ_VIGENCIA_P, int LS_SQLCODE_P)
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
                #region D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "LS_V0CONT_DATA_CONTRATO" , ""},
                    { "LS_V0CONT_PRZ_VIGENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new EF0101S();
                program.Execute(new IntBasis(null, LS_V0HAB01_NUM_CONTRATO_P), new StringBasis(null, LS_SINI_DATORR_P), new StringBasis(null, LS_V0CONT_DATA_CONTRATO_P), new IntBasis(null, LS_V0CONT_PRZ_VIGENCIA_P), new IntBasis(null, LS_SQLCODE_P));

                Assert.Empty(AppSettings.TestSet.DynamicData["D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.LS_SQLCODE == 00);
            }
        }

        [Theory]
        [InlineData(123456789, "123456789", "123456789", 123456789, 123456789)]
        public static void EF0101S_Tests_Theory_ReturnCode99(int LS_V0HAB01_NUM_CONTRATO_P, string LS_SINI_DATORR_P, string LS_V0CONT_DATA_CONTRATO_P, int LS_V0CONT_PRZ_VIGENCIA_P, int LS_SQLCODE_P)
        {
            // Comentário para ver mudanças na main

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "LS_V0CONT_DATA_CONTRATO" , ""},
                    { "LS_V0CONT_PRZ_VIGENCIA" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new EF0101S();
                program.Execute(new IntBasis(null, LS_V0HAB01_NUM_CONTRATO_P), new StringBasis(null, LS_SINI_DATORR_P), new StringBasis(null, LS_V0CONT_DATA_CONTRATO_P), new IntBasis(null, LS_V0CONT_PRZ_VIGENCIA_P), new IntBasis(null, LS_SQLCODE_P));

                Assert.Empty(AppSettings.TestSet.DynamicData["D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.LS_SQLCODE == 99);
            }
        }
    }
}