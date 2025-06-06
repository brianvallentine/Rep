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
using static Code.EM0901S;

namespace FileTests.Test
{
    [Collection("EM0901S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0901S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region EM0901S_V1MOEDA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "10"},
                { "MOED_TIPO_MOEDA" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0901S_V1MOEDA", q0);

            #endregion

            #region A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1", q1);

            #endregion

            #region A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        public static void Load_Parameters_To_EM0030B()
        {
            #region PARAMETERS
            #region EM0901S_V1MOEDA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "10"},
                { "MOED_TIPO_MOEDA" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0901S_V1MOEDA", q0);

            #endregion

            #region A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1", q1);

            #endregion

            #region A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0901S_Tests_Fact()
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

                var parametros = new EM0901S_CALCULOS();

                parametros.COD_MOEDA.Value = 12;
                parametros.DTINIVIG_LK.Value = "2024-01-01";
                parametros.IND_FRAC.Value = "1";
                parametros.ISENTA_CUSTO.Value = "1";
                parametros.NRPARCEL.Value = 0;
                parametros.PCDESCON.Value = 20.00;
                parametros.PCDESCON_ADIC.Value = 10;
                parametros.PCDESCON_BONUS.Value = 20;
                parametros.PCENTRAD.Value = 10;
                parametros.PCIOF.Value = 10;
                parametros.QTPARCEL.Value = 10;
                parametros.PCJUROS.Value = 10;

                var program = new EM0901S();
                program.Execute(parametros);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                Assert.True(program.FRAC_RAMO == 1);
            }
        }

    }
}