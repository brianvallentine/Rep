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
using static Code.RE0001S;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("RE0001S_Tests")]
    public class RE0001S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_PRM_TAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMP_IX_T" , ""},
                { "V0COBA_PRM_VAR_T" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMP_IX_R" , ""},
                { "V0COBA_PRM_VAR_R" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0HISR_PRERSP" , ""},
                { "V0HISR_COMRSP" , ""},
                { "WHOST_IMPSEG_ER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0DRES_PCTCOT" , ""},
                { "V0DRES_PCTCTF" , ""},
                { "V0DRES_PCTDNO" , ""},
                { "V0DRES_PCTCOMCO" , ""},
                { "V0DRES_DTCUTOFF" , ""},
                { "V0DRES_RECUP_PSL" , ""},
                { "V0DRES_CONTR_RESG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0PCMP_VLR_COMPL" , ""},
                { "V0PCMP_VLR_COMPL_I" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_CODPRODU" , ""},
                { "V0ENDO_CODSUBES" , ""},
                { "V0ENDO_DTEMIS" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
                { "V0ENDO_TIP_ENDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0ENDS_NUM_APOL" , ""},
                { "V0ENDS_NRENDOS" , ""},
                { "V0ENDS_CODPRODU" , ""},
                { "V0ENDS_CODSUBES" , ""},
                { "V0ENDS_DTEMIS" , ""},
                { "V0ENDS_DTINIVIG" , ""},
                { "V0ENDS_DTTERVIG" , ""},
                { "V0ENDS_TIP_ENDS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void RE0001S_Tests_Fact()
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
                var program = new RE0001S();
                program.Execute(new RE0001S_LK_RE0001S());

                Assert.True(true);
            }
        }
    }
}