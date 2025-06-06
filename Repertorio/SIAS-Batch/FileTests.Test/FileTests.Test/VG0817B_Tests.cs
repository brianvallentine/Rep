using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0817B;

namespace FileTests.Test
{
    [Collection("VG0817B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0817B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region VG0817B_CPARCEL

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , "10020079849"},
                { "V0PARC_NRPARCEL" , "1"},
                { "V0PARC_DTVENCTO" , "2004-04-30"},
                { "V0PARC_PRMTOT" , "182.39"},
                { "V0PARC_PRMVG" , "182.39"},
                { "V0PARC_PRMAP" , "0"},
                { "V0PARC_SITUACAO" , "1"},
                { "V0SUBG_TIPO_FATURAMENTO" , "1"},
                { "V0SUBG_PERI_FATURAMENTO" , "1"},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , "10020079849"},
                { "V0PARC_NRPARCEL" , "2"},
                { "V0PARC_DTVENCTO" , "2004-05-28"},
                { "V0PARC_PRMTOT" , "182.39"},
                { "V0PARC_PRMVG" , "182.39"},
                { "V0PARC_PRMAP" , "0"},
                { "V0PARC_SITUACAO" , "1"},
                { "V0SUBG_TIPO_FATURAMENTO" , "1"},
                { "V0SUBG_PERI_FATURAMENTO" , "1"},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , "10020079849"},
                { "V0PARC_NRPARCEL" , "3"},
                { "V0PARC_DTVENCTO" , "2004-06-28"},
                { "V0PARC_PRMTOT" , "3297.97"},
                { "V0PARC_PRMVG" , "3297.97"},
                { "V0PARC_PRMAP" , "0"},
                { "V0PARC_SITUACAO" , "1"},
                { "V0SUBG_TIPO_FATURAMENTO" , "1"},
                { "V0SUBG_PERI_FATURAMENTO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("VG0817B_CPARCEL", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2024-09-02"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0100_PROCESSA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "10020079849"},
                { "V0HCOB_NRPARCEL" , "1"},
                { "V0HCOB_VLPRMTOT" , "182.39"},
                { "V0HCOB_SITUACAO" , "1"},
                { "V0HCOB_OCORHIST" , "2"},
                { "V0HCOB_CODOPER" , "501"},
                { "V0HCOB_NRTIT" , "84216814180"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "10020079849"},
                { "V0HCOB_NRPARCEL" , "2"},
                { "V0HCOB_VLPRMTOT" , "3297.97"},
                { "V0HCOB_SITUACAO" , "1"},
                { "V0HCOB_OCORHIST" , "1"},
                { "V0HCOB_CODOPER" , "501"},
                { "V0HCOB_NRTIT" , "84218539003"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "10020079849"},
                { "V0HCOB_NRPARCEL" , "3"},
                { "V0HCOB_VLPRMTOT" , "8751.73"},
                { "V0HCOB_SITUACAO" , "1"},
                { "V0HCOB_OCORHIST" , "1"},
                { "V0HCOB_CODOPER" , "501"},
                { "V0HCOB_NRTIT" , "84220356948"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0100_PROCESSA_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , "8129237"},
                { "V0PROP_NUM_APOLICE" , "107700000003"},
                { "V0PROP_CODSUBES" , "0"},
                { "V0PROP_FONTE" , "21"},
                { "V0PROP_SITUACAO" , "4"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , "0"},
                { "V0PROP_CODPRODU" , "7703"},
                { "V0PROP_NRPARCE" , "32"},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , "N"},
                { "V0PROP_RISCO" , ""},
                { "V0PROP_ESTR_COBR" , "MULT"},
                { "V0PROP_CUSTOCAP_TOTAL" , "S"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , "8129237"},
                { "V0PROP_NUM_APOLICE" , "107700000003"},
                { "V0PROP_CODSUBES" , "0"},
                { "V0PROP_FONTE" , "21"},
                { "V0PROP_SITUACAO" , "4"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , "0"},
                { "V0PROP_CODPRODU" , "7703"},
                { "V0PROP_NRPARCE" , "32"},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , "N"},
                { "V0PROP_RISCO" , ""},
                { "V0PROP_ESTR_COBR" , "MULT"},
                { "V0PROP_CUSTOCAP_TOTAL" , "S"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , "8129237"},
                { "V0PROP_NUM_APOLICE" , "107700000003"},
                { "V0PROP_CODSUBES" , "0"},
                { "V0PROP_FONTE" , "21"},
                { "V0PROP_SITUACAO" , "4"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , "0"},
                { "V0PROP_CODPRODU" , "7703"},
                { "V0PROP_NRPARCE" , "32"},
                { "V0PROP_TEM_SAF" , ""},
                { "V0PROP_TEM_CDG" , "N"},
                { "V0PROP_RISCO" , ""},
                { "V0PROP_ESTR_COBR" , "MULT"},
                { "V0PROP_CUSTOCAP_TOTAL" , "S"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_2_Query1", q3);

            #endregion

            #region M_0100_PROCESSA_DB_SELECT_3_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTINIVIG" , "2004-04-01"},
                { "V0RELA_DTTERVIG_CALC" , "2004-04-30"},
                { "V0RELA_DTTERVIG" , "2004-04-01"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTINIVIG" , "2004-03-01"},
                { "V0RELA_DTTERVIG_CALC" , "2004-03-31"},
                { "V0RELA_DTTERVIG" , "2004-03-31"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTINIVIG" , "2004-03-01"},
                { "V0RELA_DTTERVIG_CALC" , "2004-03-31"},
                { "V0RELA_DTTERVIG" , "2004-03-31"},
            });

            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_3_Query1", q4);

            #endregion

            #region M_0100_PROCESSA_DB_SELECT_4_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOC_DTINIVIG" , "2004-03-01"},
                { "V0APOC_DTTERVIG" , "2004-08-31"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOC_DTINIVIG" , "2004-03-01"},
                { "V0APOC_DTTERVIG" , "2004-08-31"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOC_DTINIVIG" , "2004-03-01"},
                { "V0APOC_DTTERVIG" , "2004-08-31"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_4_Query1", q5);

            #endregion

            #region M_0100_PROCESSA_DB_SELECT_5_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_PERI_INICIAL" , "2004-04-01"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_PERI_INICIAL" , "2004-04-01"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_PERI_INICIAL" , "2004-04-01"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_5_Query1", q6);

            #endregion

            #region M_0100_PROCESSA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0SUBG_TIPO_FATURAMENTO" , ""},
                { "V0SUBG_PERI_FATURAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_INSERT_1_Insert1", q7);

            #endregion

            #endregion
        }
        [Fact]
        public static void VG0817B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0100_PROCESSA_DB_SELECT_5_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_5_Query1", q6);

                #endregion
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_4_Query1", q6);
                #endregion
                var program = new VG0817B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);


                var envlist = AppSettings.TestSet.DynamicData["M_0100_PROCESSA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envlist.Count > 1);
                Assert.True(envlist[1].TryGetValue("V0PROP_NUM_APOLICE", out var val2r) && val2r.Contains("107700000003"));
                Assert.True(envlist[1].TryGetValue("V0HCOB_NRCERTIF", out var val3r) && val3r.Contains("10020079849"));

            }
        }

        [Fact]
        public static void VG0817B_Tests_Fact0()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0100_PROCESSA_DB_SELECT_5_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_5_Query1", q6);

                #endregion
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_4_Query1", q6);
                #endregion
                var program = new VG0817B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WS_WORK_AREAS.AC_LIDOS >= 1);


            }
        }
        [Fact]
        public static void VG0817B_Tests_Fact1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region VG0817B_CPARCEL

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string> { });

                AppSettings.TestSet.DynamicData.Remove("VG0817B_CPARCEL");
                //AppSettings.TestSet.DynamicData.Add("VG0817B_CPARCEL", q0);

                #endregion
                #endregion
                var program = new VG0817B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 1);
            }
        }
    }
}