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
using static Code.VG0710S;

namespace FileTests.Test
{
    [Collection("VG0710S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VG0710S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-10-11"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-10-12"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-10-13"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-10-14"}
            });
            AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , "2"}
            });
            AppSettings.TestSet.DynamicData.Remove("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , "1"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , "1"}
            });
            AppSettings.TestSet.DynamicData.Remove("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "1"},
                { "TAXA_AP_INVPERM" , "3"},
                { "TAXA_AP_AMDS" , "2"},
                { "TAXA_AP_DH" , "1"},
                { "TAXA_AP_DIT" , "1"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "0"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "1"},
                { "TAXA_AP_INVPERM" , "3"},
                { "TAXA_AP_AMDS" , "2"},
                { "TAXA_AP_DH" , "1"},
                { "TAXA_AP_DIT" , "1"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "0"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},
            });
            AppSettings.TestSet.DynamicData.Remove("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "11"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1", q4);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0710S_Tests_Fact()
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
                var program = new VG0710S();
                program.Execute(new VG0710S_PARAMETROS());
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.PARAMETROS.LK_RETURN_CODE == 20);
            }
        }
    }
}