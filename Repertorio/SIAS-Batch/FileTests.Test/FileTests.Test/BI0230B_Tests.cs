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
using static Code.BI0230B;

namespace FileTests.Test
{
    [Collection("BI0230B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0230B_Tests
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

            #region R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
            { "RELATORI_COD_USUARIO" , "BI0230B1"},
            { "RELATORI_DATA_SOLICITACAO" , "2018-05-18"},
            { "RELATORI_IDE_SISTEMA" , "BI"},
            { "RELATORI_COD_RELATORIO" , "BI0230B1"},
            { "RELATORI_NUM_COPIAS" , "0" },
            { "RELATORI_QUANTIDADE" , "0" },
            { "RELATORI_PERI_INICIAL" , "2019-04-01"},
            { "RELATORI_PERI_FINAL" , "2019-04-30"},
            { "RELATORI_9" , "2019-05-01"},
            { "RELATORI_DATA_REFERENCIA" , "2019-06-29"},
            { "RELATORI_MES_REFERENCIA" , "0"},
            { "RELATORI_ANO_REFERENCIA" , "0"},
            { "RELATORI_ORGAO_EMISSOR" , "10"},
            { "RELATORI_COD_FONTE" , "21"},
            { "RELATORI_COD_PRODUTOR" , "0"},
            { "RELATORI_RAMO_EMISSOR" , "69"},
            { "RELATORI_COD_MODALIDADE" , "0" },
            { "RELATORI_COD_CONGENERE" , "0" },
            { "RELATORI_NUM_APOLICE" , "108199999998"},
            { "RELATORI_NUM_ENDOSSO" , "14"},
            { "RELATORI_NUM_PARCELA" , "1"},
            { "RELATORI_NUM_CERTIFICADO" , "0"},
            { "RELATORI_NUM_TITULO" , "0"},
            { "RELATORI_COD_SUBGRUPO" , "0"},
            { "RELATORI_COD_OPERACAO" , "0"},
            { "RELATORI_COD_PLANO" , "6920"},
            { "RELATORI_OCORR_HISTORICO" , "0"},
            { "RELATORI_NUM_APOL_LIDER" , "               "},
            { "RELATORI_ENDOS_LIDER" , "               "},
            { "RELATORI_NUM_PARC_LIDER" , "0"},
            { "RELATORI_NUM_SINISTRO" , "0"},
            { "RELATORI_NUM_SINI_LIDER" , "               "},
            { "RELATORI_NUM_ORDEM" , "0"},
            { "RELATORI_COD_MOEDA" , "0"},
            { "RELATORI_TIPO_CORRECAO" , " "},
            { "RELATORI_SIT_REGISTRO" , "0"},
            { "RELATORI_IND_PREV_DEFINIT" , " "},
            { "RELATORI_IND_ANAL_RESUMO" , " "},
            { "RELATORI_COD_EMPRESA" , "0"},
            { "RELATORI_PERI_RENOVACAO" , "0"},
            { "RELATORI_PCT_AUMENTO" , "0.00"   },
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DTH_ULT_DIA_MES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1", q2);

            #endregion

            #region BI0230B_V0CBCONDEV

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
            { "CBCONDEV_COD_EMPRESA" , "0"},
            { "CBCONDEV_TIPO_MOVIMENTO" , "A"},
            { "CBCONDEV_NUM_CHEQUE_INTERNO" , "0"},
            { "CBCONDEV_DIG_CHEQUE_INTERNO" , "0"},
            { "CBCONDEV_DATA_MOVIMENTO" , "2019-09-23"},
            { "CBCONDEV_NUM_SEQUENCIA" , "168"},
            { "CBCONDEV_NUM_TITULO" , "95596434541"},
            { "CBCONDEV_COD_FONTE" , "5"},
            { "CBCONDEV_NUM_APOLICE" , "106900013375"},
            { "CBCONDEV_NUM_ENDOSSO" , "0"},
            { "CBCONDEV_NUM_PARCELA" , "0"},
            { "CBCONDEV_COD_SUBGRUPO" , "0"},
            { "CBCONDEV_NUM_CERTIFICADO" , "0"},
            { "CBCONDEV_NUM_MATRICULA" , "29999060139573"},
            { "CBCONDEV_RAMO_EMISSOR" , "69"},
            { "CBCONDEV_COD_PRODUTO" , "6922"},
            { "CBCONDEV_TIPO_FAVORECIDO" , "2"},
            { "CBCONDEV_COD_FAVORECIDO" , "14293265"},
            { "CBCONDEV_COD_ENDERECO" , "0"},
            { "CBCONDEV_OCORR_ENDERECO" , "1"},
            { "CBCONDEV_SIT_REGISTRO" , "0"},
            { "CBCONDEV_DATA_QUITACAO" , "2016-08-31"},
            { "CBCONDEV_VAL_TITULO" , "38.50"},
            { "CBCONDEV_VAL_DESCONTO" , "0.15"},
            { "CBCONDEV_VAL_OPERACAO" , "38.50"},
            { "CBCONDEV_COD_SISTEMA" , "7" }
            });
            AppSettings.TestSet.DynamicData.Add("BI0230B_V0CBCONDEV", q3);

            #endregion

            #region R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R1250_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1250_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_ENDERECO" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2420_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2420_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2430_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2430_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q11);

            #endregion

            #region R5000_00_INSERT_RELATORI_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_MES_REFERENCIA" , ""},
                { "RELATORI_ANO_REFERENCIA" , ""},
                { "RELATORI_ORGAO_EMISSOR" , ""},
                { "RELATORI_COD_FONTE" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_COD_MODALIDADE" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_PLANO" , ""},
                { "RELATORI_OCORR_HISTORICO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
                { "RELATORI_ENDOS_LIDER" , ""},
                { "RELATORI_NUM_PARC_LIDER" , ""},
                { "RELATORI_NUM_SINISTRO" , ""},
                { "RELATORI_NUM_SINI_LIDER" , ""},
                { "RELATORI_NUM_ORDEM" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
                { "RELATORI_COD_EMPRESA" , ""},
                { "RELATORI_PERI_RENOVACAO" , ""},
                { "RELATORI_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_RELATORI_DB_INSERT_1_Insert1", q12);

            #endregion

            #region load_GE0350S
            GE0350S_Tests.Load_Parameters();
            #endregion
            #endregion
        }

        [Theory]
        [InlineData("Saida01_BO0230B", "Saida02_BO0230B")]
        public static void BI0230B_Tests_Theory_CodigoSistema7_ReturnCode_00(string MOVSIG01_FILE_NAME_P, string MOVSIG02_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVSIG01_FILE_NAME_P = $"{MOVSIG01_FILE_NAME_P}_{timestamp}.txt";
            MOVSIG02_FILE_NAME_P = $"{MOVSIG02_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region BI0230B_LK_PARAM
                var inputParam = new BI0230B_LK_PARAM()
                {
                    LK_P_DATA_VENCIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(010)."),
                        Value = "2024-10-11"
                    }
                };
                #endregion

                #region BI0230B_V0CBCONDEV

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_COD_EMPRESA" , "0"},
                { "CBCONDEV_TIPO_MOVIMENTO" , "A"},
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , "0"},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , "0"},
                { "CBCONDEV_DATA_MOVIMENTO" , "2019-09-23"},
                { "CBCONDEV_NUM_SEQUENCIA" , "168"},
                { "CBCONDEV_NUM_TITULO" , "95596434541"},
                { "CBCONDEV_COD_FONTE" , "5"},
                { "CBCONDEV_NUM_APOLICE" , "106900013375"},
                { "CBCONDEV_NUM_ENDOSSO" , "0"},
                { "CBCONDEV_NUM_PARCELA" , "0"},
                { "CBCONDEV_COD_SUBGRUPO" , "0"},
                { "CBCONDEV_NUM_CERTIFICADO" , "0"},
                { "CBCONDEV_NUM_MATRICULA" , "29999060139573"},
                { "CBCONDEV_RAMO_EMISSOR" , "69"},
                { "CBCONDEV_COD_PRODUTO" , "6922"},
                { "CBCONDEV_TIPO_FAVORECIDO" , "2"},
                { "CBCONDEV_COD_FAVORECIDO" , "14293265"},
                { "CBCONDEV_COD_ENDERECO" , "0"},
                { "CBCONDEV_OCORR_ENDERECO" , "1"},
                { "CBCONDEV_SIT_REGISTRO" , "0"},
                { "CBCONDEV_DATA_QUITACAO" , "2016-08-31"},
                { "CBCONDEV_VAL_TITULO" , "38.50"},
                { "CBCONDEV_VAL_DESCONTO" , "0.15"},
                { "CBCONDEV_VAL_OPERACAO" , "38.50"},
                { "CBCONDEV_COD_SISTEMA" , "7" }
                });
                AppSettings.TestSet.DynamicData.Remove("BI0230B_V0CBCONDEV");
                AppSettings.TestSet.DynamicData.Add("BI0230B_V0CBCONDEV", q3);
                #endregion
                #endregion
                var program = new BI0230B();
                program.Execute(inputParam, MOVSIG01_FILE_NAME_P, MOVSIG02_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                //R1250_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R1250_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0.Count > 1);
                Assert.True(envList0[1].TryGetValue("MOVIMCOB_DATA_MOVIMENTO", out var val0r) && val0r.Contains("2024-01-01"));
                Assert.True(envList0[1].TryGetValue("MOVIMCOB_NOME_SEGURADO", out var val1r) && val1r.Contains("016912596000136WEB PREMIOS TURISMO      "));
                Assert.True(envList0[1].TryGetValue("MOVIMCOB_NUM_APOLICE", out var val2r) && val2r.Contains("0108199999998"));

                //R5000_00_INSERT_RELATORI_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R5000_00_INSERT_RELATORI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("RELATORI_COD_USUARIO", out var val3r) && val3r.Contains("BI0230B1"));
                Assert.True(envList1[1].TryGetValue("RELATORI_COD_FONTE", out var val4r) && val4r.Contains("0021"));
                Assert.True(envList1[1].TryGetValue("RELATORI_RAMO_EMISSOR", out var val5r) && val5r.Contains("0069"));

                //R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("CBCONDEV_NUM_CERTIFICADO", out var val6r) && val6r.Contains("202401010000017"));

            }
        }
        [Theory]
        [InlineData("Saida01_BO0230B", "Saida02_BO0230B")]
        public static void BI0230B_Tests_Theory_InvalidCursor_ReturnCode_99(string MOVSIG01_FILE_NAME_P, string MOVSIG02_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVSIG01_FILE_NAME_P = $"{MOVSIG01_FILE_NAME_P}_{timestamp}.txt";
            MOVSIG02_FILE_NAME_P = $"{MOVSIG02_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region BI0230B_LK_PARAM
                var inputParam = new BI0230B_LK_PARAM();
                inputParam.LK_P_DATA_VENCIMENTO.Value = "2024-10-11";
                #endregion

                #region BI0230B_V0CBCONDEV

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_COD_EMPRESA" , "0"},
                { "CBCONDEV_TIPO_MOVIMENTO" , "A"},
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , "0"},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , "0"},
                { "CBCONDEV_DATA_MOVIMENTO" , "2019-09-23"},
                { "CBCONDEV_NUM_SEQUENCIA" , "168"},
                { "CBCONDEV_NUM_TITULO" , "19790324"},
                { "CBCONDEV_COD_FONTE" , "5"},
                { "CBCONDEV_NUM_APOLICE" , "106900013375"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0230B_V0CBCONDEV");
                AppSettings.TestSet.DynamicData.Add("BI0230B_V0CBCONDEV", q3);
                #endregion
                #endregion
                var program = new BI0230B();
                program.Execute(inputParam, MOVSIG01_FILE_NAME_P, MOVSIG02_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}