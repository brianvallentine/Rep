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
using static Code.VA0143B;

namespace FileTests.Test
{
    [Collection("VA0143B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0143B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0143B_V0HISCONPA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "109319790324"},
                { "HISCONPA_COD_SUBGRUPO" , "1"},
                { "HISCONPA_NUM_CERTIFICADO" , "7420100826"},
                { "HISCONPA_NUM_PARCELA" , "1"},
                { "ENDOSSOS_NUM_APOLICE" , "109319790324"},
                { "ENDOSSOS_NUM_ENDOSSO" , "4574395"},
                { "ENDOSSOS_DATA_EMISSAO" , "2024-01-01"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-01-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-12-31"},
                { "ENDOSSOS_TIPO_ENDOSSO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0143B_V0HISCONPA", q1);

            #endregion

            #region R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_ORIG_PRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_DATA_VENCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINI01" , ""},
                { "WHOST_PERI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINI01" , ""},
                { "WHOST_DTTER01" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0410_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_PARCELA" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DTH_ULT_DIA_MES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q13);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Sort_VA0143B.txt")]
        public static void VA0143B_Tests_Theory_ReturnCode_0(string SVA0143B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0143B_FILE_NAME_P = $"{SVA0143B_FILE_NAME_P}_{timestamp}.txt";
            
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0143B_V0HISCONPA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "109319790324"},
                { "HISCONPA_COD_SUBGRUPO" , "1"},
                { "HISCONPA_NUM_CERTIFICADO" , "7420100826"},
                { "HISCONPA_NUM_PARCELA" , "1"},
                { "ENDOSSOS_NUM_APOLICE" , "109319790324"},
                { "ENDOSSOS_NUM_ENDOSSO" , "4574395"},
                { "ENDOSSOS_DATA_EMISSAO" , "2024-01-01"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-01-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-12-31"},
                { "ENDOSSOS_TIPO_ENDOSSO" , "1"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "109319790325"},
                { "HISCONPA_COD_SUBGRUPO" , "1"},
                { "HISCONPA_NUM_CERTIFICADO" , "7420100827"},
                { "HISCONPA_NUM_PARCELA" , "2"},
                { "ENDOSSOS_NUM_APOLICE" , "109319790324"},
                { "ENDOSSOS_NUM_ENDOSSO" , "4574395"},
                { "ENDOSSOS_DATA_EMISSAO" , "2024-01-01"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-01-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-12-31"},
                { "ENDOSSOS_TIPO_ENDOSSO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0143B_V0HISCONPA");
                AppSettings.TestSet.DynamicData.Add("VA0143B_V0HISCONPA", q1);

                #endregion
                #region R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q2);

                #endregion
                #region R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINI01" , "2024-01-01"},
                { "WHOST_PERI" , "12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1", q6);

                #endregion
                #region R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINI01" , "2024-01-01"},
                { "WHOST_DTTER01" , "2024-12-31"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_PARCELA" , "2"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2024-02-02"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2024-12-30"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q12);

                #endregion

                #endregion
                var program = new VA0143B();
                program.Execute(SVA0143B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("ENDOSSOS_NUM_APOLICE", out var val0r) && val0r.Contains("0109319790324"));
                Assert.True(envList0[1].TryGetValue("ENDOSSOS_NUM_ENDOSSO", out var val1r) && val1r.Contains("004574395"));

                //R0410_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R0410_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("ENDOSSOS_NUM_APOLICE", out var val2r) && val2r.Contains("0109319790324"));
                Assert.True(envList0[1].TryGetValue("ENDOSSOS_NUM_ENDOSSO", out var val3r) && val3r.Contains("004574395"));

                //R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("ENDOSSOS_DATA_INIVIGENCIA", out var val4r) && val4r.Contains("2024-02-02"));
                Assert.True(envList2[1].TryGetValue("ENDOSSOS_DATA_TERVIGENCIA", out var val5r) && val5r.Contains("2024-12-30"));
            }
        }
        [Theory]
        [InlineData("Sort_VA0143B.txt")]
        public static void VA0143B_Tests_Theory_ReturnCode_99(string SVA0143B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0143B_FILE_NAME_P = $"{SVA0143B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0143B_V0HISCONPA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "109319790324"},
                { "HISCONPA_COD_SUBGRUPO" , "1"},
                { "HISCONPA_NUM_CERTIFICADO" , "7420100826"},
                { "HISCONPA_NUM_PARCELA" , "1"},
                { "ENDOSSOS_NUM_APOLICE" , "109319790324"},
                { "ENDOSSOS_NUM_ENDOSSO" , "4574395"},
                { "ENDOSSOS_DATA_EMISSAO" , "2024-01-01"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-01-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-12-31"},
                { "ENDOSSOS_TIPO_ENDOSSO" , "1"},
            },new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VA0143B_V0HISCONPA");
                AppSettings.TestSet.DynamicData.Add("VA0143B_V0HISCONPA", q1);

                #endregion


                #endregion
                var program = new VA0143B();
                program.Execute(SVA0143B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}