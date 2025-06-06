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
using static Code.LT2036B;

namespace FileTests.Test
{
    [Collection("LT2036B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT2036B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region LT2036B_C1RELATO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0LOT_COD_LOT_FENAL" , ""},
                { "V0APO_NUM_APOLICE" , ""},
                { "V0APO_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("LT2036B_C1RELATO", q1);

            #endregion

            #region LT2036B_IMPSEG

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0IMP_COD_COBERTURA" , ""},
                { "V0IMP_IMP_SEG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("LT2036B_IMPSEG", q2);

            #endregion

            #region R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1", q3);

            #endregion

            #region R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0LOT_COD_LOT_FENAL" , ""},
                { "V0LOT_COD_LOT_CEF" , ""},
                { "V0LOT_NUM_APOLICE" , ""},
                { "LOTERI01_AGENCIA" , ""},
                { "LOTERI01_OPERACAO_CONTA" , ""},
                { "LOTERI01_NUMERO_CONTA" , ""},
                { "LOTERI01_DV_CONTA" , ""},
                { "V0LOT_COD_CLIENTE" , ""},
                { "LOTERI01_ENDERECO" , ""},
                { "LOTERI01_COMPL_ENDERECO" , ""},
                { "LOTERI01_BAIRRO" , ""},
                { "LOTERI01_CEP" , ""},
                { "LOTERI01_CIDADE" , ""},
                { "LOTERI01_SIGLA_UF" , ""},
                { "LOTERI01_DDD" , ""},
                { "LOTERI01_NUM_FONE" , ""},
                { "LOTERI01_DES_EMAIL" , ""},
                { "LOTERI01_NUM_FAX" , ""},
                { "V0LOT_DTINIVIG" , ""},
                { "V0LOT_DTTERVIG" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1", q5);

            #endregion

            #region R0180_SELECT_APOLICE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0APO_DTINIVIG" , ""},
                { "V0APO_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0180_SELECT_APOLICE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0180_SELECT_APOLICE_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0APO_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0180_SELECT_APOLICE_DB_SELECT_2_Query1", q7);

            #endregion

            #region R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1", q8);

            #endregion

            #region LT2036B_CURS02

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OUTROCOB_COD_COBERTURA" , ""},
                { "OUTROCOB_IMP_SEGURADA_IX" , ""},
                { "OUTROCOB_PRM_TARIFARIO_IX" , ""},
                { "OUTROCOB_VAL_FRANQ_OBR_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("LT2036B_CURS02", q9);

            #endregion

            #region LT2036B_BONUS

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0BON_TIPO_BONUS" , ""},
                { "V0BON_PERCENT_BONUS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("LT2036B_BONUS", q10);

            #endregion

            #region R8901_00_INSERT_RELATORIO_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , ""},
                { "V0RELA_DATA_SOLICITACAO" , ""},
                { "V0RELA_IDSISTEM" , ""},
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_NRCOPIAS" , ""},
                { "V0RELA_QUANTIDADE" , ""},
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_DATA_REFERENCIA" , ""},
                { "V0RELA_MES_REFERENCIA" , ""},
                { "V0RELA_ANO_REFERENCIA" , ""},
                { "V0RELA_ORGAO" , ""},
                { "V0RELA_FONTE" , ""},
                { "V0RELA_CODPDT" , ""},
                { "V0RELA_RAMO" , ""},
                { "V0RELA_MODALIDA" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_NUM_APOLICE" , ""},
                { "V0RELA_NRENDOS" , ""},
                { "V0RELA_NRPARCEL" , ""},
                { "V0RELA_NRCERTIF" , ""},
                { "V0RELA_NRTIT" , ""},
                { "V0RELA_CODSUBES" , ""},
                { "V0RELA_OPERACAO" , ""},
                { "V0RELA_COD_PLANO" , ""},
                { "V0RELA_OCORHIST" , ""},
                { "V0RELA_APOLIDER" , ""},
                { "V0RELA_ENDOSLID" , ""},
                { "V0RELA_NUM_PARC_LIDER" , ""},
                { "V0RELA_NUM_SINISTRO" , ""},
                { "V0RELA_NUM_SINI_LIDER" , ""},
                { "V0RELA_NUM_ORDEM" , ""},
                { "V0RELA_CODUNIMO" , ""},
                { "V0RELA_CORRECAO" , ""},
                { "V0RELA_SITUACAO" , ""},
                { "V0RELA_PREVIA_DEFINITIVA" , ""},
                { "V0RELA_ANAL_RESUMO" , ""},
                { "V0RELA_COD_EMPRESA" , ""},
                { "V0RELA_PERI_RENOVACAO" , ""},
                { "V0RELA_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8901_00_INSERT_RELATORIO_DB_INSERT_1_Insert1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SaidaMOV2036B.txt", "SaidaRLT2036B.txt", "ARQSORT_FILE_NAME_P")]
        public static void LT2036B_Tests_Theory_DataDiferente_ReturnCode_0(string MOV2036B_FILE_NAME_P, string RLT2036B_FILE_NAME_P, string ARQSORT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV2036B_FILE_NAME_P = $"{MOV2036B_FILE_NAME_P}_{timestamp}.txt";
            RLT2036B_FILE_NAME_P = $"{RLT2036B_FILE_NAME_P}_{timestamp}.txt";
            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2024-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new LT2036B();
                program.Execute(MOV2036B_FILE_NAME_P, RLT2036B_FILE_NAME_P, ARQSORT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1
                var envList0 = AppSettings.TestSet.DynamicData["R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1"].DynamicList;
                Assert.True(envList0?.Count == 0);

            }
        }
        [Theory]
        [InlineData("SaidaMOV2036B.txt", "SaidaRLT2036B.txt", "ARQSORT_FILE_NAME_P")]
        public static void LT2036B_Tests_Theory_DataMov_ReturnCode_0(string MOV2036B_FILE_NAME_P, string RLT2036B_FILE_NAME_P, string ARQSORT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV2036B_FILE_NAME_P = $"{MOV2036B_FILE_NAME_P}_{timestamp}.txt";
            RLT2036B_FILE_NAME_P = $"{RLT2036B_FILE_NAME_P}_{timestamp}.txt";
            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2007-08-27"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new LT2036B();
                program.Execute(MOV2036B_FILE_NAME_P, RLT2036B_FILE_NAME_P, ARQSORT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R8901_00_INSERT_RELATORIO_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R8901_00_INSERT_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0RELA_DATA_SOLICITACAO", out var valor0) && valor0.Contains("2007-08-27"));
                Assert.True(envList0.Count > 1);

            }
        }
        [Theory]
        [InlineData("SaidaMOV2036B.txt", "SaidaRLT2036B.txt", "ARQSORT_FILE_NAME_P")]
        public static void LT2036B_Tests_Theory_SistemaNaoInformado_FimNormal_ReturnCode_0(string MOV2036B_FILE_NAME_P, string RLT2036B_FILE_NAME_P, string ARQSORT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV2036B_FILE_NAME_P = $"{MOV2036B_FILE_NAME_P}_{timestamp}.txt";
            RLT2036B_FILE_NAME_P = $"{RLT2036B_FILE_NAME_P}_{timestamp}.txt";
            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new LT2036B();
                program.Execute(MOV2036B_FILE_NAME_P, RLT2036B_FILE_NAME_P, ARQSORT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("SaidaMOV2036B.txt", "SaidaRLT2036B.txt", "ARQSORT_FILE_NAME_P")]
        public static void LT2036B_Tests_Theory_ReturnCode_99(string MOV2036B_FILE_NAME_P, string RLT2036B_FILE_NAME_P, string ARQSORT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV2036B_FILE_NAME_P = $"{MOV2036B_FILE_NAME_P}_{timestamp}.txt";
            RLT2036B_FILE_NAME_P = $"{RLT2036B_FILE_NAME_P}_{timestamp}.txt";
            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2007-08-27"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region LT2036B_C1RELATO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0LOT_COD_LOT_FENAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("LT2036B_C1RELATO");
                AppSettings.TestSet.DynamicData.Add("LT2036B_C1RELATO", q1);

                #endregion
                #endregion
                var program = new LT2036B();
                program.Execute(MOV2036B_FILE_NAME_P, RLT2036B_FILE_NAME_P, ARQSORT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}