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
using static Code.AC0007B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("AC0007B_Tests")]
    public class AC0007B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region AC0007B_V0HISTOPARC

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TAR" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0007B_V0HISTOPARC", q1);

            #endregion

            #region R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_RAMO" , ""},
                { "V0ENDO_CODPRODU" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_MOEDA_PRM" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_TIPO_ENDO" , ""},
                { "V0ENDO_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MRAPCOB_PRM_TAR_VAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1AUTC_PRM_TAR_VAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1COBA_PRM_TAR_VAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVHBT_NUM_APOL" , ""},
                { "MOVHBT_NUM_ENDS" , ""},
                { "MOVHBT_PRM_CRED" , ""},
                { "MOVHBT_VAL_REMUN" , ""},
                { "MOVHBT_VAL_SUSEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTAR_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_CODUNIMO" , ""},
                { "V0COTA_VALVENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_PRM_TAR_TOT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0PCOM_NUM_APOL" , ""},
                { "V0PCOM_NRENDOS" , ""},
                { "V0PCOM_NRPARCEL" , ""},
                { "V0PCOM_VLR_COMPL_IX" , ""},
                { "V0PCOM_VLR_COMPL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1", q10);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0007B_Tests_Fact()
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

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0007B_V0HISTOPARC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TAR" , ""},
                { "V0APOL_RAMO" , "66"},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_COD_EMPR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("AC0007B_V0HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0007B_V0HISTOPARC", q1);

                #endregion

                #region R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_RAMO" , ""},
                { "V0ENDO_CODPRODU" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_MOEDA_PRM" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_TIPO_ENDO" , ""},
                { "V0ENDO_COD_EMPR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MRAPCOB_PRM_TAR_VAR" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1AUTC_PRM_TAR_VAR" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1COBA_PRM_TAR_VAR" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "MOVHBT_NUM_APOL" , ""},
                { "MOVHBT_NUM_ENDS" , ""},
                { "MOVHBT_PRM_CRED" , ""},
                { "MOVHBT_VAL_REMUN" , ""},
                { "MOVHBT_VAL_SUSEP" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTAR_IX" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_CODUNIMO" , ""},
                { "V0COTA_VALVENDA" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_PRM_TAR_TOT" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0PCOM_NUM_APOL" , ""},
                { "V0PCOM_NRENDOS" , ""},
                { "V0PCOM_NRPARCEL" , ""},
                { "V0PCOM_VLR_COMPL_IX" , ""},
                { "V0PCOM_VLR_COMPL" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1", q10);

                #endregion

                #endregion
                var program = new AC0007B();
                program.Execute();

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void AC0007B_Tests_FactReturn99()
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

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0007B_V0HISTOPARC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TAR" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_COD_EMPR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("AC0007B_V0HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0007B_V0HISTOPARC", q1);

                #endregion

                #region R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_RAMO" , ""},
                { "V0ENDO_CODPRODU" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_MOEDA_PRM" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_TIPO_ENDO" , ""},
                { "V0ENDO_COD_EMPR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MRAPCOB_PRM_TAR_VAR" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1AUTC_PRM_TAR_VAR" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1COBA_PRM_TAR_VAR" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "MOVHBT_NUM_APOL" , ""},
                { "MOVHBT_NUM_ENDS" , ""},
                { "MOVHBT_PRM_CRED" , ""},
                { "MOVHBT_VAL_REMUN" , ""},
                { "MOVHBT_VAL_SUSEP" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTAR_IX" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_CODUNIMO" , ""},
                { "V0COTA_VALVENDA" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_PRM_TAR_TOT" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0PCOM_NUM_APOL" , ""},
                { "V0PCOM_NRENDOS" , ""},
                { "V0PCOM_NRPARCEL" , ""},
                { "V0PCOM_VLR_COMPL_IX" , ""},
                { "V0PCOM_VLR_COMPL" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1", q10);

                #endregion

                #endregion
                var program = new AC0007B();
                program.Execute();

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}