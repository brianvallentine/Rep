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
using static Code.AC0008B;

namespace FileTests.Test
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("AC0008B_Tests")]
    public class AC0008B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region AC0008B_V0HISTOPARC

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_OPERACAO" , ""},
                { "V0HISP_DTMOVTO" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_NUMBIL" , ""},
                { "V0APOL_PCTCED" , ""},
                { "V0APOL_QTCOSSEG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0008B_V0HISTOPARC", q1);

            #endregion

            #region R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1", q2);

            #endregion

            #region R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0CPRE_COD_EMPR" , ""},
                { "V0CPRE_TIPSGU" , ""},
                { "V0CPRE_CONGENER" , ""},
                { "V0CPRE_NUM_ORDEM" , ""},
                { "V0CPRE_NUM_APOL" , ""},
                { "V0CPRE_NRENDOS" , ""},
                { "V0CPRE_NRPARCEL" , ""},
                { "V0CPRE_PRM_TAR_IX" , ""},
                { "V0CPRE_VAL_DES_IX" , ""},
                { "V0CPRE_OTNPRLIQ" , ""},
                { "V0CPRE_OTNADFRA" , ""},
                { "V0CPRE_VLCOMISIX" , ""},
                { "V0CPRE_OTNTOTAL" , ""},
                { "V0CPRE_SITUACAO" , ""},
                { "V0CPRE_SIT_CONG" , ""},
                { "V0CPRE_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , ""},
                { "V0CHIS_CONGENER" , ""},
                { "V0CHIS_NUM_APOL" , ""},
                { "V0CHIS_NRENDOS" , ""},
                { "V0CHIS_NRPARCEL" , ""},
                { "V0CHIS_OCORHIST" , ""},
                { "V0CHIS_OPERACAO" , ""},
                { "V0CHIS_DTMOVTO" , ""},
                { "V0CHIS_TIPSGU" , ""},
                { "V0CHIS_PRM_TAR" , ""},
                { "V0CHIS_VAL_DES" , ""},
                { "V0CHIS_VLPRMLIQ" , ""},
                { "V0CHIS_VLADIFRA" , ""},
                { "V0CHIS_VLCOMIS" , ""},
                { "V0CHIS_VLPRMTOT" , ""},
                { "V0CHIS_DTQITBCO" , ""},
                { "V0CHIS_SIT_FINANC" , ""},
                { "V0CHIS_SIT_LIBRECUP" , ""},
                { "V0CHIS_NUMOCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1_Insert1", q4);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.DEL.AC.COSSHIS2teste.FITA", "PRD.DEL.AC.COSSPRE2teste.FITA")]
        public static void AC0008B_Tests_Theory(string COSSHIST_FILE_NAME_P, string COSSPREM_FILE_NAME_P)
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

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0008B_V0HISTOPARC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "0"},
                { "V0HISP_NRENDOS" , "2"},
                { "V0HISP_NRPARCEL" , "1"},
                { "V0HISP_OCORHIST" , "1"},
                { "V0HISP_OPERACAO" , "0"},
                { "V0HISP_DTMOVTO" , "200-01-01"},
                { "V0APOL_RAMO" , "0"},
                { "V0APOL_NUMBIL" , "123"},
                { "V0APOL_PCTCED" , "1"},
                { "V0APOL_QTCOSSEG" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0008B_V0HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0008B_V0HISTOPARC", q1);

                #endregion

                #region R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1", q2);


                #endregion

                #endregion
                var program = new AC0008B();
                program.Execute(COSSHIST_FILE_NAME_P, COSSPREM_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1

                var envList = AppSettings.TestSet.DynamicData["R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("V0CPRE_COD_EMPR", out var V0CPRE_COD_EMPR) && V0CPRE_COD_EMPR == "000000000");
                Assert.True(envList[1].TryGetValue("V0CPRE_TIPSGU", out var V0CPRE_TIPSGU) && V0CPRE_TIPSGU == "1");
                Assert.True(envList[1].TryGetValue("V0CPRE_CONGENER", out var V0CPRE_CONGENER) && V0CPRE_CONGENER == "0000");
                Assert.True(envList[1].TryGetValue("V0CPRE_NUM_ORDEM", out var V0CPRE_NUM_ORDEM) && V0CPRE_NUM_ORDEM == "000000000000000");
                Assert.True(envList[1].TryGetValue("V0CPRE_NUM_APOL", out var V0CPRE_NUM_APOL) && V0CPRE_NUM_APOL == "0000000000000");
                Assert.True(envList[1].TryGetValue("V0CPRE_NRENDOS", out var V0CPRE_NRENDOS) && V0CPRE_NRENDOS == "000000000");
                Assert.True(envList[1].TryGetValue("V0CPRE_NRPARCEL", out var V0CPRE_NRPARCEL) && V0CPRE_NRPARCEL == "0000");
                Assert.True(envList[1].TryGetValue("V0CPRE_PRM_TAR_IX", out var V0CPRE_PRM_TAR_IX) && V0CPRE_PRM_TAR_IX == "0000000000.00000");
                Assert.True(envList[1].TryGetValue("V0CPRE_VAL_DES_IX", out var V0CPRE_VAL_DES_IX) && V0CPRE_VAL_DES_IX == "0000000000.00000");
                Assert.True(envList[1].TryGetValue("V0CPRE_OTNPRLIQ", out var V0CPRE_OTNPRLIQ) && V0CPRE_OTNPRLIQ == "0000000000.00000");
                Assert.True(envList[1].TryGetValue("V0CPRE_OTNADFRA", out var V0CPRE_OTNADFRA) && V0CPRE_OTNADFRA == "0000000000.00000");
                Assert.True(envList[1].TryGetValue("V0CPRE_VLCOMISIX", out var V0CPRE_VLCOMISIX) && V0CPRE_VLCOMISIX == "0000000000.00000");
                Assert.True(envList[1].TryGetValue("V0CPRE_OTNTOTAL", out var V0CPRE_OTNTOTAL) && V0CPRE_OTNTOTAL == "0000000000.00000");
                Assert.True(envList[1].TryGetValue("V0CPRE_SITUACAO", out var V0CPRE_SITUACAO) && V0CPRE_SITUACAO == " ");
                Assert.True(envList[1].TryGetValue("V0CPRE_SIT_CONG", out var V0CPRE_SIT_CONG) && V0CPRE_SIT_CONG == " ");
                Assert.True(envList[1].TryGetValue("V0CPRE_OCORHIST", out var V0CPRE_OCORHIST) && V0CPRE_OCORHIST == "0000");

                #endregion

                #region R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1_Insert1

                var envList1 = AppSettings.TestSet.DynamicData["R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("V0CHIS_COD_EMPR", out var V0CHIS_COD_EMPR) && V0CHIS_COD_EMPR == "000000000");
                Assert.True(envList1[1].TryGetValue("V0CHIS_CONGENER", out var V0CHIS_CONGENER) && V0CHIS_CONGENER == "0000");
                Assert.True(envList1[1].TryGetValue("V0CHIS_NUM_APOL", out var V0CHIS_NUM_APOL) && V0CHIS_NUM_APOL == "0000000000000");
                Assert.True(envList1[1].TryGetValue("V0CHIS_NRENDOS", out var V0CHIS_NRENDOS) && V0CHIS_NRENDOS == "000000000");
                Assert.True(envList1[1].TryGetValue("V0CHIS_NRPARCEL", out var V0CHIS_NRPARCEL) && V0CHIS_NRPARCEL == "0000");
                Assert.True(envList1[1].TryGetValue("V0CHIS_OCORHIST", out var V0CHIS_OCORHIST) && V0CHIS_OCORHIST == "0000");
                Assert.True(envList1[1].TryGetValue("V0CHIS_OPERACAO", out var V0CHIS_OPERACAO) && V0CHIS_OPERACAO == "0000");
                Assert.True(envList1[1].TryGetValue("V0CHIS_DTMOVTO", out var V0CHIS_DTMOVTO) && V0CHIS_DTMOVTO == "0000-00-00");
                Assert.True(envList1[1].TryGetValue("V0CHIS_TIPSGU", out var V0CHIS_TIPSGU) && V0CHIS_TIPSGU == "1");
                Assert.True(envList1[1].TryGetValue("V0CHIS_PRM_TAR", out var V0CHIS_PRM_TAR) && V0CHIS_PRM_TAR == "0000000000000.00");
                Assert.True(envList1[1].TryGetValue("V0CHIS_VAL_DES", out var V0CHIS_VAL_DES) && V0CHIS_VAL_DES == "0000000000000.00");
                Assert.True(envList1[1].TryGetValue("V0CHIS_VLPRMLIQ", out var V0CHIS_VLPRMLIQ) && V0CHIS_VLPRMLIQ == "0000000000000.00");
                Assert.True(envList1[1].TryGetValue("V0CHIS_VLADIFRA", out var V0CHIS_VLADIFRA) && V0CHIS_VLADIFRA == "0000000000000.00");
                Assert.True(envList1[1].TryGetValue("V0CHIS_VLCOMIS", out var V0CHIS_VLCOMIS) && V0CHIS_VLCOMIS == "0000000000000.00");
                Assert.True(envList1[1].TryGetValue("V0CHIS_VLPRMTOT", out var V0CHIS_VLPRMTOT) && V0CHIS_VLPRMTOT == "0000000000000.00");
                Assert.True(envList1[1].TryGetValue("V0CHIS_DTQITBCO", out var V0CHIS_DTQITBCO) && V0CHIS_DTQITBCO == "          ");
                Assert.True(envList1[1].TryGetValue("V0CHIS_SIT_FINANC", out var V0CHIS_SIT_FINANC) && V0CHIS_SIT_FINANC == " ");
                Assert.True(envList1[1].TryGetValue("V0CHIS_SIT_LIBRECUP", out var V0CHIS_SIT_LIBRECUP) && V0CHIS_SIT_LIBRECUP == " ");
                Assert.True(envList1[1].TryGetValue("V0CHIS_NUMOCOR", out var V0CHIS_NUMOCOR) && V0CHIS_NUMOCOR == "0000");


                #endregion

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("123", "12")]
        public static void AC0008B_Tests99_Theory(string COSSHIST_FILE_NAME_P, string COSSPREM_FILE_NAME_P)
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

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0008B_V0HISTOPARC

                var q1 = new DynamicData();            
                AppSettings.TestSet.DynamicData.Remove("AC0008B_V0HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0008B_V0HISTOPARC", q1);

                #endregion

                #region R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1

                var q2 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1", q2);


                #endregion

                #endregion
                var program = new AC0008B();
                program.Execute(COSSHIST_FILE_NAME_P, COSSPREM_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                Assert.True(program.RETURN_CODE == 99);
            }
        }



    }
}