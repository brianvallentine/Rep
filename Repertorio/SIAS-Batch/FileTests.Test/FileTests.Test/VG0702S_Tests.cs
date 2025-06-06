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
using static Code.VG0702S;

namespace FileTests.Test
{
    [Collection("VG0702S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VG0702S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "1"},
                { "TAXA_AP_INVPERM" , "2"},
                { "TAXA_AP_AMDS" , "1"},
                { "TAXA_AP_DH" , "2"},
                { "TAXA_AP_DIT" , "3"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "0"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0702S_Tests_Fact()
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
                var program = new VG0702S();
                program.Execute(new VG0702S_PARAMETROS());

                Assert.True(program.PARAMETROS.LK_RETURN_CODE == 20);
            }
        }

        [Fact]
        public static void VG0702S_Tests_SemDados()
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

                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                var program = new VG0702S();
                program.Execute(new VG0702S_PARAMETROS());

                Assert.True(program.PARAMETROS.LK_RETURN_CODE == 100);
            }
        }
    }
}