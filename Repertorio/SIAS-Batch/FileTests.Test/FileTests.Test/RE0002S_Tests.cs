using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.RE0002S;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("RE0002S_Tests")]
    public class RE0002S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
           
            #region RE0002S_C01_MRAPOITE

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "MRAPOITE_NUM_ITEM" , ""},
                { "MRAPOITE_NUM_VERSAO" , ""},
                { "MRAPOITE_PCT_DESC_FIDEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("RE0002S_C01_MRAPOITE", q0);

            #endregion

            #region RE0002S_C01_MRAPOCOB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MRAPOCOB_COD_COBERTURA" , ""},
                { "MRAPOCOB_RAMO_COBERTURA" , ""},
                { "MRAPOCOB_MODALI_COBERTURA" , ""},
                { "MRAPOCOB_IMP_SEGURADA_IX" , ""},
                { "MRAPOCOB_PRM_TARIFARIO_VAR" , ""},
                { "MRAPOCOB_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("RE0002S_C01_MRAPOCOB", q1);

            #endregion

            #region RE0002S_CCORRET

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "APOLICOR_PCT_PART_CORRETOR" , ""},
                { "APOLICOR_PCT_COM_CORRETOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("RE0002S_CCORRET", q2);

            #endregion

            #region R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MRPROCOB_IND_RESSEGURO" , ""},
                { "MRPROCOB_IND_CESSAO" , ""},
                { "MRPROCOB_COD_TP_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1700_SELECT_MR022_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MR022_PCT_DESC_COBERTURA" , ""},
                { "MR022_PCT_BONUS_RENOVCAO" , ""},
                { "MR022_PCT_DESC_CORRETOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_SELECT_MR022_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MRAPOITE_PCT_DESC_FIDEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_PCT_PART_COSSEGURO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void RE0002S_Tests_Fact()
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

                #region RE0002S_C01_MRAPOITE

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "MRAPOITE_NUM_ITEM" , "1"},
                { "MRAPOITE_NUM_VERSAO" , "2"},
                { "MRAPOITE_PCT_DESC_FIDEL" , "X"},
                });
                AppSettings.TestSet.DynamicData.Remove("RE0002S_C01_MRAPOITE");
                AppSettings.TestSet.DynamicData.Add("RE0002S_C01_MRAPOITE", q0);

                #endregion

                #region RE0002S_C01_MRAPOCOB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MRAPOCOB_COD_COBERTURA" , "1"},
                { "MRAPOCOB_RAMO_COBERTURA" , "2"},
                { "MRAPOCOB_MODALI_COBERTURA" , "3"},
                { "MRAPOCOB_IMP_SEGURADA_IX" , "4"},
                { "MRAPOCOB_PRM_TARIFARIO_VAR" , "5"},
                { "MRAPOCOB_COD_EMPRESA" , "6"},
            });
                AppSettings.TestSet.DynamicData.Remove("RE0002S_C01_MRAPOCOB");
                AppSettings.TestSet.DynamicData.Add("RE0002S_C01_MRAPOCOB", q1);

                #endregion

                #region RE0002S_CCORRET

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "APOLICOR_PCT_PART_CORRETOR" , "1"},
                { "APOLICOR_PCT_COM_CORRETOR" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("RE0002S_CCORRET");
                AppSettings.TestSet.DynamicData.Add("RE0002S_CCORRET", q2);

                #endregion

                #region R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MRPROCOB_IND_RESSEGURO" , "1"},
                { "MRPROCOB_IND_CESSAO" , "2"},
                { "MRPROCOB_COD_TP_COBERTURA" , "3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1700_SELECT_MR022_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "MR022_PCT_DESC_COBERTURA" , "X"},
                { "MR022_PCT_BONUS_RENOVCAO" , "1"},
                { "MR022_PCT_DESC_CORRETOR" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_SELECT_MR022_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_SELECT_MR022_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "MRAPOITE_PCT_DESC_FIDEL" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_PCT_PART_COSSEGURO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_PRM_LIQUIDO" , "1"},
                { "PARCEHIS_ADICIONAL_FRACIO" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q7);

                #endregion
               
                #endregion

                var program = new RE0002S();
                RE0002S_LK_RE0002S obj = new RE0002S_LK_RE0002S();
                obj.LKRE02_ENTRADA.LKRE02_NUM_APOL.Value = 123;
                obj.LKRE02_ENTRADA.LKRE02_COD_PROD.Value = 1804;
                obj.LKRE02_ENTRADA.LKRE02_DTEMS_AP.Value = "2020-01-01";
                obj.LKRE02_ENTRADA.LKRE02_DTINIVIG.Value = "2020-01-01";
                obj.LKRE02_ENTRADA.LKRE02_DTTERVIG.Value = "2020-01-01";
                obj.LKRE02_ENTRADA.LKRE02_NUM_ITEM.Value = 11;
                obj.LKRE02_ENTRADA.LKRE02_NUM_VERS.Value = 12;
                obj.LKRE02_ENTRADA.LKRE02_TIP_ENDS.Value = "0";             
                obj.LKRE02_ENTRADA.LKRE02_RAMO_CBT.Value = 1;





                program.Execute(obj);
                // obj.LKRE02_ENTRADA.LKRE02_NUM_ITEM.Value e obj.LKRE02_ENTRADA.LKRE02_NUM_VERS.Value == 0              
                //var envList1 = AppSettings.TestSet.DynamicData["RE0002S_C01_MRAPOITE"].DynamicList;
                // Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["RE0002S_C01_MRAPOCOB"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["RE0002S_CCORRET"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["R1700_SELECT_MR022_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList8);


                Assert.True(program.AREAS_AUXILIARES.WS_RETORNO == 00);

            }
        }

        [Fact]
        public static void RE0002S_Tests99_Fact()
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

                #region RE0002S_C01_MRAPOITE

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "MRAPOITE_NUM_ITEM" , "1"},
                { "MRAPOITE_NUM_VERSAO" , "2"},
                { "MRAPOITE_PCT_DESC_FIDEL" , "X"},
                });
                AppSettings.TestSet.DynamicData.Remove("RE0002S_C01_MRAPOITE");
                AppSettings.TestSet.DynamicData.Add("RE0002S_C01_MRAPOITE", q0);

                #endregion

                #region RE0002S_C01_MRAPOCOB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MRAPOCOB_COD_COBERTURA" , "1"},
                { "MRAPOCOB_RAMO_COBERTURA" , "2"},
                { "MRAPOCOB_MODALI_COBERTURA" , "3"},
                { "MRAPOCOB_IMP_SEGURADA_IX" , "4"},
                { "MRAPOCOB_PRM_TARIFARIO_VAR" , "5"},
                { "MRAPOCOB_COD_EMPRESA" , "6"},
            });
                AppSettings.TestSet.DynamicData.Remove("RE0002S_C01_MRAPOCOB");
                AppSettings.TestSet.DynamicData.Add("RE0002S_C01_MRAPOCOB", q1);

                #endregion

                #region RE0002S_CCORRET

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "APOLICOR_PCT_PART_CORRETOR" , "1"},
                { "APOLICOR_PCT_COM_CORRETOR" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("RE0002S_CCORRET");
                AppSettings.TestSet.DynamicData.Add("RE0002S_CCORRET", q2);

                #endregion

                #region R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MRPROCOB_IND_RESSEGURO" , "1"},
                { "MRPROCOB_IND_CESSAO" , "2"},
                { "MRPROCOB_COD_TP_COBERTURA" , "3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1700_SELECT_MR022_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "MR022_PCT_DESC_COBERTURA" , "X"},
                { "MR022_PCT_BONUS_RENOVCAO" , "1"},
                { "MR022_PCT_DESC_CORRETOR" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_SELECT_MR022_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_SELECT_MR022_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "MRAPOITE_PCT_DESC_FIDEL" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_PCT_PART_COSSEGURO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_PRM_LIQUIDO" , "1"},
                { "PARCEHIS_ADICIONAL_FRACIO" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion

                var program = new RE0002S();
                RE0002S_LK_RE0002S obj = new RE0002S_LK_RE0002S();
                obj.LKRE02_ENTRADA.LKRE02_NUM_APOL.Value = 0;
                obj.LKRE02_ENTRADA.LKRE02_COD_PROD.Value = 0;
                obj.LKRE02_ENTRADA.LKRE02_DTEMS_AP.Value = "2020-01-01";
                obj.LKRE02_ENTRADA.LKRE02_DTINIVIG.Value = "2020-01-01";
                obj.LKRE02_ENTRADA.LKRE02_DTTERVIG.Value = "2020-01-01";
                obj.LKRE02_ENTRADA.LKRE02_NUM_ITEM.Value = 0;
                obj.LKRE02_ENTRADA.LKRE02_NUM_VERS.Value = 0;
                obj.LKRE02_ENTRADA.LKRE02_TIP_ENDS.Value = "0";
                obj.LKRE02_ENTRADA.LKRE02_RAMO_CBT.Value = 0;

                program.Execute(obj);             

                Assert.True(program.AREAS_AUXILIARES.WS_RETORNO == 999);

            }
        }

    }
}