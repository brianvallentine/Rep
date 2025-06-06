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
using static Code.VF0403B;

namespace FileTests.Test
{
    [Collection("VF0403B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class VF0403B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTHOJE" , ""},
                { "DTFIMSEM" , ""},
                { "DTINISEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q2);

            #endregion

            #region VF0403B_CEVENT

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0EVEN_NRCERTIF" , ""},
                { "V0EVEN_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0403B_CEVENT", q3);

            #endregion

            #region R1100_00_MONTA_SORT_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PRVA_FONTE" , ""},
                { "V0PRVA_CODCLIEN" , ""},
                { "V0PRVA_CODPRODU" , ""},
                { "V0PRVA_NUM_APOLICE" , ""},
                { "V0PRVA_CODSUBES" , ""},
                { "V0PRVA_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1100_00_MONTA_SORT_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_2_Query1", q5);

            #endregion

            #region R1100_00_MONTA_SORT_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0ASST_CODAST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_3_Query1", q6);

            #endregion

            #region R1100_00_MONTA_SORT_DB_SELECT_4_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0GERE_CODGER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_4_Query1", q7);

            #endregion

            #region R1100_00_MONTA_SORT_DB_SELECT_5_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODCOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_5_Query1", q8);

            #endregion

            #region R1100_00_MONTA_SORT_DB_SELECT_6_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODCOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_6_Query1", q9);

            #endregion

            #region R1100_00_MONTA_SORT_DB_SELECT_7_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_IMPMORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_7_Query1", q10);

            #endregion

            #region R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0GERE_NOMGER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ASST_NOMAST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NOMSUB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1", q15);

            #endregion

            #region R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_NOMPDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0PDVG_NOMPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1", q17);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RVF0403B_Saida", " SVF0403B_Saida")]
        public static void VF0403B_Tests_Theory(string RVF0403B_FILE_NAME_P, string SVF0403B_FILE_NAME_P)
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

                #region R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_SITUACAO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTHOJE" , "2020-01-01"},
                { "DTFIMSEM" , "2020-01-01"},
                { "DTINISEM" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion
               
                #region VF0403B_CEVENT

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0EVEN_NRCERTIF" , "123"},
                { "V0EVEN_VLPREMIO" , "130"},
            });
                AppSettings.TestSet.DynamicData.Remove("VF0403B_CEVENT");
                AppSettings.TestSet.DynamicData.Add("VF0403B_CEVENT", q3);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PRVA_FONTE" , "1"},
                { "V0PRVA_CODCLIEN" , "2"},
                { "V0PRVA_CODPRODU" , "3"},
                { "V0PRVA_NUM_APOLICE" , "4"},
                { "V0PRVA_CODSUBES" , "5"},
                { "V0PRVA_DTQITBCO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_NOME_RAZAO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_2_Query1", q5);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0ASST_CODAST" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_3_Query1", q6);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_4_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0GERE_CODGER" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_4_Query1", q7);


                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_5_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODCOR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_5_Query1", q8);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_6_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODCOR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_6_Query1", q9);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_7_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_IMPMORNATU" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_7_Query1", q10);

                #endregion

                #region R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0GERE_NOMGER" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_NOMEFTE" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1", q12);

                #endregion

                #region R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0ASST_NOMAST" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_CODCLIEN" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NOMSUB" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1", q15);

                #endregion

                #region R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_NOMPDT" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0PDVG_NOMPRODU" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1", q17);

                #endregion

                #endregion
                var program = new VF0403B();
                program.Execute(RVF0403B_FILE_NAME_P, SVF0403B_FILE_NAME_P);

                #region R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1           

                var envList35 = AppSettings.TestSet.DynamicData["R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList35?.Count > 1);

                #endregion

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("RVF0403B_Saida1", " SVF0403B_Saida1")]
        public static void VF0403B_Tests99_Theory(string RVF0403B_FILE_NAME_P, string SVF0403B_FILE_NAME_P)
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

                #region R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region VF0403B_CEVENT

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0EVEN_NRCERTIF" , "123"},
                { "V0EVEN_VLPREMIO" , "130"},
            });
                AppSettings.TestSet.DynamicData.Remove("VF0403B_CEVENT");
                AppSettings.TestSet.DynamicData.Add("VF0403B_CEVENT", q3);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PRVA_FONTE" , "1"},
                { "V0PRVA_CODCLIEN" , "2"},
                { "V0PRVA_CODPRODU" , "3"},
                { "V0PRVA_NUM_APOLICE" , "4"},
                { "V0PRVA_CODSUBES" , "5"},
                { "V0PRVA_DTQITBCO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_NOME_RAZAO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_2_Query1", q5);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0ASST_CODAST" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_3_Query1", q6);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_4_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0GERE_CODGER" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_4_Query1", q7);


                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_5_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODCOR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_5_Query1", q8);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_6_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODCOR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_6_Query1", q9);

                #endregion

                #region R1100_00_MONTA_SORT_DB_SELECT_7_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_IMPMORNATU" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MONTA_SORT_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MONTA_SORT_DB_SELECT_7_Query1", q10);

                #endregion

                #region R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0GERE_NOMGER" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_NOMEFTE" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1", q12);

                #endregion

                #region R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0ASST_NOMAST" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_CODCLIEN" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NOMSUB" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1", q15);

                #endregion

                #region R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_NOMPDT" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0PDVG_NOMPRODU" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1", q17);

                #endregion

                #endregion
                var program = new VF0403B();
                program.Execute(RVF0403B_FILE_NAME_P, SVF0403B_FILE_NAME_P);               

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}