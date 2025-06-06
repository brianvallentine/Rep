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
using static Code.CB1127B;

namespace FileTests.Test
{
    [Collection("CB1127B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB1127B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "WSHOST_DATA015" , ""},
                { "WSHOST_DATA365" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region CB1127B_V0RCAP

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_VLRCAP" , ""},
                { "V0RCAP_VALPRI" , ""},
                { "V0RCAP_OPERACAO" , ""},
                { "V0RCAP_NRTIT" , ""},
                { "V0RCAP_CODPRODU" , ""},
                { "V0RCAP_AGECOBR" , ""},
                { "V0RCAP_NRCERTIF" , ""},
                { "V0RCOM_FONTE" , ""},
                { "V0RCOM_NRRCAP" , ""},
                { "V0RCOM_NRRCAPCO" , ""},
                { "V0RCOM_OPERACAO" , ""},
                { "V0RCOM_BCOAVISO" , ""},
                { "V0RCOM_AGEAVISO" , ""},
                { "V0RCOM_NRAVISO" , ""},
                { "V0RCOM_VLRCAP" , ""},
                { "V0RCOM_DATARCAP" , ""},
                { "V0RCOM_DTCADAST" , ""},
                { "V0RCOM_SITCONTB" , ""},
                { "V0AVIS_ORIGEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1127B_V0RCAP", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVTO_00")]
        public static void CB1127B_Tests_Theory(string MOVTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_FILE_NAME_P = $"{MOVTO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2025-01-27"},
                { "WSHOST_DATA015" , "2025-01-12"},
                { "WSHOST_DATA365" , "2024-01-28"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region CB1127B_V0RCAP

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_VLRCAP" , "1"},
                { "V0RCAP_VALPRI" , "2"},
                { "V0RCAP_OPERACAO" , "3"},
                { "V0RCAP_NRTIT" , "4"},
                { "V0RCAP_CODPRODU" , "5"},
                { "V0RCAP_AGECOBR" , "6"},
                { "V0RCAP_NRCERTIF" , "7"},
                { "V0RCOM_FONTE" , "8"},
                { "V0RCOM_NRRCAP" , "9"},
                { "V0RCOM_NRRCAPCO" , "10"},
                { "V0RCOM_OPERACAO" , "11"},
                { "V0RCOM_BCOAVISO" , "12"},
                { "V0RCOM_AGEAVISO" , "13"},
                { "V0RCOM_NRAVISO" , "14"},
                { "V0RCOM_VLRCAP" , "15"},
                { "V0RCOM_DATARCAP" , "16"},
                { "V0RCOM_DTCADAST" , "17"},
                { "V0RCOM_SITCONTB" , "18"},
                { "V0AVIS_ORIGEM" , "19"},
            });
                AppSettings.TestSet.DynamicData.Remove("CB1127B_V0RCAP");
                AppSettings.TestSet.DynamicData.Add("CB1127B_V0RCAP", q1);

                #endregion

                #endregion
                var program = new CB1127B();
                program.Execute(MOVTO_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["CB1127B_V0RCAP"].DynamicList;
                Assert.Empty(envList2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("MOVTO_01")]
        public static void CB1127B_Tests99_Theory(string MOVTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_FILE_NAME_P = $"{MOVTO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                /* q0.AddDynamic(new Dictionary<string, string>{
                 { "V0SIST_DTMOVABE" , ""},
                 { "WSHOST_DATA015" , ""},
                 { "WSHOST_DATA365" , ""},
             });**/
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region CB1127B_V0RCAP

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_VLRCAP" , "1"},
                { "V0RCAP_VALPRI" , "1"},
                { "V0RCAP_OPERACAO" , "1"},
                { "V0RCAP_NRTIT" , "1"},
                { "V0RCAP_CODPRODU" , "1"},
                { "V0RCAP_AGECOBR" , "1"},
                { "V0RCAP_NRCERTIF" , "1"},
                { "V0RCOM_FONTE" , "1"},
                { "V0RCOM_NRRCAP" , "1"},
                { "V0RCOM_NRRCAPCO" , "1"},
                { "V0RCOM_OPERACAO" , "1"},
                { "V0RCOM_BCOAVISO" , "1"},
                { "V0RCOM_AGEAVISO" , "1"},
                { "V0RCOM_NRAVISO" , "1"},
                { "V0RCOM_VLRCAP" , "1"},
                { "V0RCOM_DATARCAP" , "1"},
                { "V0RCOM_DTCADAST" , "1"},
                { "V0RCOM_SITCONTB" , "1"},
                { "V0AVIS_ORIGEM" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("CB1127B_V0RCAP");
                AppSettings.TestSet.DynamicData.Add("CB1127B_V0RCAP", q1);

                #endregion

                #endregion
                var program = new CB1127B();
                program.Execute(MOVTO_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                Assert.True(program.W.WABEND.WSQLCODE != 00);

               
            }
        }

    }
}