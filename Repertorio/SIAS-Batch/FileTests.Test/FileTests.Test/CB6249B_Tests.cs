using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.CB6249B;
using Sias.Cobranca.DB2.CB6249B;

namespace FileTests.Test
{
    [Collection("CB6249B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB6249B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""},
                { "CEDENTE_NUM_TITULO_MAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "CONVERSI_NUM_SICOB" , ""},
                { "CONVERSI_COD_EMPRESA_SIVPF" , ""},
                { "CONVERSI_COD_PRODUTO_SIVPF" , ""},
                { "CONVERSI_AGEPGTO" , ""},
                { "CONVERSI_DATA_OPERACAO" , ""},
                { "CONVERSI_DATA_QUITACAO" , ""},
                { "CONVERSI_VAL_RCAP" , ""},
                { "CONVERSI_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_COD_OPERACAO" , ""},
                { "AVISOCRE_TIPO_AVISO" , ""},
                { "AVISOCRE_DATA_AVISO" , ""},
                { "AVISOCRE_VAL_IOCC" , ""},
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_COSSEGURO_CED" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , ""},
                { "AVISOCRE_SIT_CONTABIL" , ""},
                { "AVISOCRE_COD_EMPRESA" , ""},
                { "AVISOCRE_ORIGEM_AVISO" , ""},
                { "AVISOCRE_VAL_ADIANTAMENTO" , ""},
                { "AVISOCRE_STA_DEPOSITO_TER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_COD_OPERACAO" , ""},
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , ""},
                { "AVISOSAL_BCO_AVISO" , ""},
                { "AVISOSAL_AGE_AVISO" , ""},
                { "AVISOSAL_TIPO_SEGURO" , ""},
                { "AVISOSAL_NUM_AVISO_CREDITO" , ""},
                { "AVISOSAL_DATA_AVISO" , ""},
                { "AVISOSAL_DATA_MOVIMENTO" , ""},
                { "AVISOSAL_SALDO_ATUAL" , ""},
                { "AVISOSAL_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_SALDO_ATUAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1", q12);

            #endregion

            #region R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_SALDO_ATUAL" , ""},
                { "AVISOSAL_NUM_AVISO_CREDITO" , ""},
                { "AVISOSAL_DATA_MOVIMENTO" , ""},
                { "AVISOSAL_TIPO_SEGURO" , ""},
                { "AVISOSAL_AGE_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1", q13);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.EM.D240905.EM8009B.CP912014.txt")]
        public static void CB6249B_Tests_TheoryERRO99(string MOVIMENTO_FILE_NAME_P)
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

                #region R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion                
                #endregion
                var program = new CB6249B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("PRD.EM.D240905.EM8009B.CP911334.txt")]
        public static void CB6249B_Tests_Theory(string MOVIMENTO_FILE_NAME_P)
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
                var program = new CB6249B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                //R4000_00_INSERT_MOVIMCOB_Insert1
                //verifica se o insert ou update foi realizado
                var envList = AppSettings.TestSet.DynamicData["R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("MOVIMCOB_COD_BANCO", out var valOr) && valOr == "0104");
                Assert.True(envList[1].TryGetValue("MOVIMCOB_NUM_FITA", out var valSivpf) && valSivpf == "000000898");

                //R4700_00_UPDATE_AVISOCRED_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("AVISOCRE_BCO_AVISO", out var val2r) && val2r == "0104");

                //R5000_00_UPDATE_AVISOSAL_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("AVISOSAL_NUM_AVISO_CREDITO", out var val4r) && val4r == "908700898");
                Assert.True(envList2[1].TryGetValue("AVISOSAL_AGE_AVISO", out var val5r) && val5r == "8010");

                Assert.True(program.RETURN_CODE == 0);

            }
        }
    }
}