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
using static Code.SI1003S;

namespace FileTests.Test
{
    [Collection("SI1003S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class SI1003S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void SI1003S_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();
                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "101100000001"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "110"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "120"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1", q5);

                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new SI1003S();
              
                LBSI1001_SI1001S_PARAMETROS obj = new LBSI1001_SI1001S_PARAMETROS();

                obj.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO.Value = 101100000001;
                obj.SI1001S_ENTRADA.SI1001S_COD_PRODUTO.Value = 123;
                obj.SI1001S_ENTRADA.SI1001S_RAMO.Value = 123;

                program.Execute(obj);

                Assert.True(program.LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_SQLCODE == 0);
             
            }
        }



        [Fact]
        public static void SI1003S_Tests99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();
                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var q1 = new DynamicData();             
                AppSettings.TestSet.DynamicData.Remove("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var q3 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1

                var q4 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1

                var q5 = new DynamicData();             
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1", q5);

                #endregion

        

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new SI1003S();

                LBSI1001_SI1001S_PARAMETROS obj = new LBSI1001_SI1001S_PARAMETROS();

                obj.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO.Value = 101100000001;
                obj.SI1001S_ENTRADA.SI1001S_COD_PRODUTO.Value = 123;
                obj.SI1001S_ENTRADA.SI1001S_RAMO.Value = 123;
                obj.SI1001S_ENTRADA.SI1001S_COD_FUNCAO.Value = 0;
                program.Execute(obj);

                Assert.True(program.LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_SQLCODE != 0);
            }
        }


    }
}