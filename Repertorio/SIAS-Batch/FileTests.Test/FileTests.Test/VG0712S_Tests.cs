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
using static Code.VG0712S;

namespace FileTests.Test
{
    [Collection("VG0712S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VG0712S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , ""},
                { "TAXA_AP_INVPERM" , ""},
                { "TAXA_AP_AMDS" , ""},
                { "TAXA_AP_DH" , ""},
                { "TAXA_AP_DIT" , ""},
                { "GARAN_ADIC_IEA" , ""},
                { "GARAN_ADIC_IPA" , ""},
                { "GARAN_ADIC_IPD" , ""},
                { "GARAN_ADIC_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0712S_Tests_Fact()
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
                #region PARAMETERS
                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMA_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "TAXA_VG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "TAXA_VG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "TAXA_AP_MORACID" , ""},
                    { "TAXA_AP_INVPERM" , ""},
                    { "TAXA_AP_AMDS" , ""},
                    { "TAXA_AP_DH" , ""},
                    { "TAXA_AP_DIT" , ""},
                    { "GARAN_ADIC_IEA" , ""},
                    { "GARAN_ADIC_IPA" , ""},
                    { "GARAN_ADIC_IPD" , ""},
                    { "GARAN_ADIC_HD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion
                #endregion
                var param = new VG0712S_PARAMETROS();
                param.LK_APOLICE.Value = 1;
                param.LK_SUBGRUPO.Value = 1;
                param.LK_IDADE.Value = 1;
                param.LK_PURO_MORTE_NATURAL.Value = 100;
                param.LK_SALARIO.Value = 100;

                var program = new VG0712S();
                program.Execute(param);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.PARAMETROS.LK_RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void VG0712S_Tests_ReturnCode99_Fact()
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
                #region PARAMETERS
                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMA_DTMOVABE" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "TAXA_VG" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "TAXA_VG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "TAXA_AP_MORACID" , ""},
                    { "TAXA_AP_INVPERM" , ""},
                    { "TAXA_AP_AMDS" , ""},
                    { "TAXA_AP_DH" , ""},
                    { "TAXA_AP_DIT" , ""},
                    { "GARAN_ADIC_IEA" , ""},
                    { "GARAN_ADIC_IPA" , ""},
                    { "GARAN_ADIC_IPD" , ""},
                    { "GARAN_ADIC_HD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion
                #endregion
                var param = new VG0712S_PARAMETROS();
                param.LK_APOLICE.Value = 1;
                param.LK_SUBGRUPO.Value = 1;
                param.LK_IDADE.Value = 1;
                param.LK_PURO_MORTE_NATURAL.Value = 100;
                param.LK_SALARIO.Value = 100;

                var program = new VG0712S();
                program.Execute(param);

                Assert.True(program.PARAMETROS.LK_RETURN_CODE.Value == 99);
            }
        }
    }
}