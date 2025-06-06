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
using static Code.AU2055B;

namespace FileTests.Test
{
    [Collection("AU2055B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AU2055B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region AU2055B_C01_PROPOSTA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_COD_FONTE" , ""},
                { "PROPOSTA_NUM_PROPOSTA" , ""},
                { "PROPOSTA_NUM_RCAP" , ""},
                { "PROPCOBR_TIPO_COBRANCA" , ""},
                { "AU085_IND_FORMA_PAGTO_AD" , ""},
                { "PROPOSTA_DATA_INIVIGENCIA" , ""},
                { "PROPOSTA_NUM_APOL_ANTERIOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AU2055B_C01_PROPOSTA", q1);

            #endregion

            #region AU2055B_C01_MOVIMCOB

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
                { "PROPOSTA_DATA_INIVIGENCIA" , ""},
                { "PROPOSTA_NUM_APOL_ANTERIOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AU2055B_C01_MOVIMCOB", q2);

            #endregion

            #region R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_PROPOSTA" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOAUT_COD_FONTE" , ""},
                { "PROPOAUT_NUM_PROPOSTA" , ""},
                { "PROPOAUT_TIPO_COBRANCA" , ""},
                { "PROPOAUT_NUM_RECIBO_CONV" , ""},
                { "PROPOAUT_IND_TP_RENOVACAO" , ""},
                { "PROPOAUT_NUM_PROPOSTA_CONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_NUM_PROPOSTA" , ""},
                { "PROPOSTA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_SIT_REGISTRO" , ""},
                { "PROPCOBR_TIPO_COBRANCA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R3215_00_SELECT_AU085_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "AU085_IND_FORMA_PAGTO_AD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3215_00_SELECT_AU085_DB_SELECT_1_Query1", q7);

            #endregion

            #region R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_NUM_PROPOSTA" , ""},
                { "PROPOSTA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOAUT_NUM_PROPOSTA_CONV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1", q10);

            #endregion

            #region R5030_00_SELECT_AU055_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "AU055_DTH_OPERACAO" , ""},
                { "AU055_NUM_ARQUIVO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5030_00_SELECT_AU055_DB_SELECT_1_Query1", q11);

            #endregion

            #region R5040_00_INSERT_AU055_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "AU055_SEQ_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5040_00_INSERT_AU055_DB_SELECT_1_Query1", q12);

            #endregion

            #region R5040_00_INSERT_AU055_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "AU055_NUM_PROPOSTA_VC" , ""},
                { "AU055_SEQ_HISTORICO" , ""},
                { "AU055_NOM_PROGRAMA" , ""},
                { "AU055_DTH_OPERACAO" , ""},
                { "AU055_IND_OPERACAO" , ""},
                { "AU055_DTH_MOVTO_ARQUIVO" , ""},
                { "AU055_NUM_ARQUIVO" , ""},
                { "AU055_STA_ERRO" , ""},
                { "WHOST_CONGENERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5040_00_INSERT_AU055_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "AU055_IND_OPERACAO" , ""},
                { "AU055_NOM_PROGRAMA" , ""},
                { "AU055_NUM_PROPOSTA_VC" , ""},
                { "AU055_DTH_OPERACAO" , ""},
                { "WHOST_CONGENERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "AU057_NUM_PROPOSTA" , ""},
                { "AU057_IND_OPERACAO" , ""},
                { "AU057_COD_FONTE" , ""},
                { "WHOST_PROPOSTA_VC" , ""},
                { "WHOST_CONGENERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1", q15);

            #endregion

            #endregion
        }

        [Fact]
        public static void AU2055B_Tests_Fact_Erro99()
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

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion

                #endregion
                var program = new AU2055B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void AU2055B_Tests_Fact()
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
                var program = new AU2055B();
                program.Execute();

                //R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PROPOSTA_NUM_PROPOSTA", out var valor) && valor.Contains("0"));
                Assert.True(envList.Count > 1);            

                //R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("MOVIMCOB_NUM_ENDOSSO", out var valor1) && valor1.Contains("0"));
                Assert.True(envList1.Count > 1);            

                //R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PROPOSTA_COD_FONTE", out var valor2) && valor2.Contains("0"));
                Assert.True(envList2.Count > 1);            

                //R5040_00_INSERT_AU055_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R5040_00_INSERT_AU055_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("AU055_NOM_PROGRAMA", out var valor3) && valor3.Contains("AU2055B"));
                Assert.True(envList3.Count > 1);            

                //R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("WHOST_CONGENERE", out var valor4) && valor4.Contains("5631"));
                Assert.True(envList4.Count > 1);            

                //R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1
                var envList5 = AppSettings.TestSet.DynamicData["R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("WHOST_CONGENERE", out var valor5) && valor5.Contains("5631"));
                Assert.True(envList5.Count > 1);            


                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}