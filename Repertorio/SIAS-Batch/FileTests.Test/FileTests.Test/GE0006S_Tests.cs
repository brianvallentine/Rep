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
using static Code.GE0006S;

namespace FileTests.Test
{
    [Collection("GE0006S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0006S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region LOOP_CALEND_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("LOOP_CALEND_DB_SELECT_1_Query1", q0);

            #endregion

            #region LOOP_CALEND_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FERIADOS_DATA_FERIADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("LOOP_CALEND_DB_SELECT_2_Query1", q1);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0006S_Tests_Fact_QtdeDiasZerados_ReturnMessageError()
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
                var inputParam = new GE0006S_GE0006S_LINKAGE()
                {
                    GE0006S_DATA_DESTINO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(010)."),
                        Value = "2024-11-05"
                    },
                    GE0006S_QTDIAS = new IntBasis()
                    {
                        Pic = new PIC("9", "4", "9(004)."),
                        Value = 0
                    }
                };

                #endregion
                var program = new GE0006S();
                program.Execute(inputParam);

                Assert.True(!program.GE0006S_LINKAGE.GE0006S_MENSAGEM.IsEmpty());
                Assert.True(program.GE0006S_LINKAGE.GE0006S_MENSAGEM == "QUANTIDADE DE DIAS ZERADO");

            }
        }

        [Fact]
        public static void GE0006S_Tests_Fact_8Dias_2FinalSemana_1Feriado_ReturnSucess()
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
                var inputParam = new GE0006S_GE0006S_LINKAGE()
                {
                    GE0006S_DATA_DESTINO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(010)."),
                        Value = "2024-11-07"
                    },
                    GE0006S_QTDIAS = new IntBasis()
                    {
                        Pic = new PIC("9", "4", "9(004)."),
                        Value = 8
                    }
                };
                #region LOOP_CALEND_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("LOOP_CALEND_DB_SELECT_1_Query1");
                q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2024-11-09" }
                });
                q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2024-11-10" }
                });
                q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2024-11-16" }
                });
                q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2024-11-17" }
                });
                AppSettings.TestSet.DynamicData.Add("LOOP_CALEND_DB_SELECT_1_Query1", q0);

                #endregion
                #region LOOP_CALEND_Query2

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FERIADOS_DATA_FERIADO" , "2024-11-15"}
                });
                AppSettings.TestSet.DynamicData.Remove("LOOP_CALEND_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("LOOP_CALEND_DB_SELECT_2_Query1", q1);

                #endregion

                #endregion
                var program = new GE0006S();
                program.Execute(inputParam);

                Assert.True(program.GE0006S_LINKAGE.GE0006S_MENSAGEM.IsEmpty());
                Assert.True(program.GE0006S_LINKAGE.GE0006S_DATA_DESTINO == "2024-11-20");

            }
        }

    }
}