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
using static Code.FC0105S;

namespace FileTests.Test
{
    [Collection("FC0105S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class FC0105S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region FDRCAP_FCATN061_Call1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LK_COD_USUARIO_N061" , "123456"},
                { "LK_COD_PROG_ORIGEM_N061" , "10"},
                { "LK_SIGLA_UNID_NEG_N061" , "2"},
                { "LK_COD_MSG_LANG_N061" , "Mensage,"},
                { "LK_IND_TIPO_PROC_N061" , "1"},
                { "LK_EMP_PARCEIRA" , "2"},
                { "LK_NUM_PLANO" , "1234"},
                { "LK_NUM_SERIE" , "45677"},
                { "LK_NUM_TITULO" , "123456"},
                { "LK_COD_RAMO" , "12"},
                { "LK_NUM_PROPOSTA" , "12345"},
                { "LK_QTD_TITULOS" , "2"},
                { "LK_VLR_TITULO" , "200000"},
                { "LK_NUM_ORDEM_N061" , "1234354"},
                { "W77_NUM_NSA" , "31"},
                { "LK_COD_EMPRESA_N061" , "12"},
                { "LK_IND_ERRO_N061" , "0"},
                { "LK_MSG_RET_N061" , ""},
                { "LK_NM_TAB_N061" , ""},
                { "LK_SQLCODE_N061" , ""},
                { "LK_SQLERRMC_N061" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FDRCAP_FCATN061_Call1", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData(1234, 4532, 000045252, 000082599762440, 0000, 0000, 123456789, 123456789, 123456789, "TRACE OFF", 0000, 0000, "LK_OUT_MENSAGEM_P", "LK_OUT_SQLERRMC_P", "LK_OUT_SQLSTATE_P")]
        public static void FC0105S_Tests_Theory(int LK_NUM_PLANO_P, int LK_NUM_SERIE_P, int LK_NUM_TITULO_P, double LK_NUM_PROPOSTA_P, int LK_QTD_TITULOS_P, double LK_VLR_TITULO_P, int LK_EMP_PARCEIRA_P, int LK_COD_RAMO_P, int LK_NUM_NSA_P, string LK_TRACE_P, int LK_OUT_COD_RETORNO_P, int LK_OUT_SQLCODE_P, string LK_OUT_MENSAGEM_P, string LK_OUT_SQLERRMC_P, string LK_OUT_SQLSTATE_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            LK_OUT_MENSAGEM_P = $"{LK_OUT_MENSAGEM_P}_{timestamp}.txt";
            LK_OUT_SQLERRMC_P = $"{LK_OUT_SQLERRMC_P}_{timestamp}.txt";
            LK_OUT_SQLSTATE_P = $"{LK_OUT_SQLSTATE_P}_{timestamp}.txt";
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
                var program = new FC0105S();
                program.Execute(new IntBasis(null, LK_NUM_PLANO_P), new IntBasis(null, LK_NUM_SERIE_P), new IntBasis(null, LK_NUM_TITULO_P), new DoubleBasis(null, 2, LK_NUM_PROPOSTA_P), new IntBasis(null, LK_QTD_TITULOS_P), new DoubleBasis(null, 2, LK_VLR_TITULO_P), new IntBasis(null, LK_EMP_PARCEIRA_P), new IntBasis(null, LK_COD_RAMO_P), new IntBasis(null, LK_NUM_NSA_P), new StringBasis(null, LK_TRACE_P), new IntBasis(null, LK_OUT_COD_RETORNO_P), new IntBasis(null, LK_OUT_SQLCODE_P), new StringBasis(null, LK_OUT_MENSAGEM_P), new StringBasis(null, LK_OUT_SQLERRMC_P), new StringBasis(null, LK_OUT_SQLSTATE_P));

                //Chamada Procedure
                Assert.True(program.W77_SQLCODE == 0);
                Assert.True(program.LK_COD_USUARIO_N061 == 123456);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData(1234, 4532, 000045252, 000082599762440, 0000, 0000, 123456789, 123456789, 123456789, "TRACE OFF", 0000, 0000, "LK_OUT_MENSAGEM_P", "LK_OUT_SQLERRMC_P", "LK_OUT_SQLSTATE_P")]
        public static void FC0105S_Tests_TheoryErroTRACEON(int LK_NUM_PLANO_P, int LK_NUM_SERIE_P, int LK_NUM_TITULO_P, double LK_NUM_PROPOSTA_P, int LK_QTD_TITULOS_P, double LK_VLR_TITULO_P, int LK_EMP_PARCEIRA_P, int LK_COD_RAMO_P, int LK_NUM_NSA_P, string LK_TRACE_P, int LK_OUT_COD_RETORNO_P, int LK_OUT_SQLCODE_P, string LK_OUT_MENSAGEM_P, string LK_OUT_SQLERRMC_P, string LK_OUT_SQLSTATE_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            LK_OUT_MENSAGEM_P = $"{LK_OUT_MENSAGEM_P}_{timestamp}.txt";
            LK_OUT_SQLERRMC_P = $"{LK_OUT_SQLERRMC_P}_{timestamp}.txt";
            LK_OUT_SQLSTATE_P = $"{LK_OUT_SQLSTATE_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region FDRCAP_FCATN061_Call1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "LK_COD_USUARIO_N061" , "123456"},
                    { "LK_COD_PROG_ORIGEM_N061" , "10"},
                    { "LK_SIGLA_UNID_NEG_N061" , "2"},
                    { "LK_COD_MSG_LANG_N061" , "Mensage,"},
                    { "LK_IND_TIPO_PROC_N061" , "1"},
                    { "LK_EMP_PARCEIRA" , "2"},
                    { "LK_NUM_PLANO" , "1234"},
                    { "LK_NUM_SERIE" , "45677"},
                    { "LK_NUM_TITULO" , "123456"},
                    { "LK_COD_RAMO" , "12"},
                    { "LK_NUM_PROPOSTA" , "12345"},
                    { "LK_QTD_TITULOS" , "2"},
                    { "LK_VLR_TITULO" , "200000"},
                    { "LK_NUM_ORDEM_N061" , "1234354"},
                    { "W77_NUM_NSA" , "31"},
                    { "LK_COD_EMPRESA_N061" , "12"},
                    { "LK_IND_ERRO_N061" , "8"},
                    { "LK_MSG_RET_N061" , "Erro"},
                    { "LK_NM_TAB_N061" , "Tabela"},
                    { "LK_SQLCODE_N061" , "8"},
                    { "LK_SQLERRMC_N061" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("FDRCAP_FCATN061_Call1");
                AppSettings.TestSet.DynamicData.Add("FDRCAP_FCATN061_Call1", q0);

                #endregion
                #endregion
                var program = new FC0105S();
                program.Execute(new IntBasis(null, LK_NUM_PLANO_P), new IntBasis(null, LK_NUM_SERIE_P), new IntBasis(null, LK_NUM_TITULO_P), new DoubleBasis(null, 2, LK_NUM_PROPOSTA_P), new IntBasis(null, LK_QTD_TITULOS_P), new DoubleBasis(null, 2, LK_VLR_TITULO_P), new IntBasis(null, LK_EMP_PARCEIRA_P), new IntBasis(null, LK_COD_RAMO_P), new IntBasis(null, LK_NUM_NSA_P), new StringBasis(null, LK_TRACE_P), new IntBasis(null, LK_OUT_COD_RETORNO_P), new IntBasis(null, LK_OUT_SQLCODE_P), new StringBasis(null, LK_OUT_MENSAGEM_P), new StringBasis(null, LK_OUT_SQLERRMC_P), new StringBasis(null, LK_OUT_SQLSTATE_P));

                //Chamada Procedure com erro
                Assert.True(program.W77_SQLCODE == 8);

                Assert.True(program.LK_COD_USUARIO_N061 == 123456);
                Assert.Contains("Erro", program.W77_MENSAGEM.Value);

                Assert.True(program.LK_OUT_COD_RETORNO == 99);
            }
        }
    }
}