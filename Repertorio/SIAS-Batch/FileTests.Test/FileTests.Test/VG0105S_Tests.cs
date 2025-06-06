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
using static Code.VG0105S;

namespace FileTests.Test
{
    [Collection("VG0105S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VG0105S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "VG135_NUM_CERTIFICADO" , ""},
                { "VG135_COD_PLANO" , ""},
                { "VG135_COD_PRODUTO" , ""},
                { "VG135_STA_ACOPLADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData(123456789, 123456789, 123456789, 123456789, 123456789, 123456789, 123456789, 123456789, "LK_COD_USUARIO_P", 123456789, "LK_TRACE_P", 123456789, 123456789, "LK_OUT_MENSAGEM_P", "LK_OUT_SQLERRMC_P", "LK_OUT_SQLSTATE_P")]
        public static void VG0105S_Tests_Theory(int LK_NUM_PLANO_P, int LK_NUM_SERIE_P, int LK_NUM_TITULO_P, double LK_NUM_PROPOSTA_P, int LK_QTD_TITULOS_P, double LK_VLR_TITULO_P, int LK_EMP_PARCEIRA_P, int LK_COD_RAMO_P, string LK_COD_USUARIO_P, int LK_NUM_NSA_P, string LK_TRACE_P, int LK_OUT_COD_RETORNO_P, int LK_OUT_SQLCODE_P, string LK_OUT_MENSAGEM_P, string LK_OUT_SQLERRMC_P, string LK_OUT_SQLSTATE_P)
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
                SelectorBasis LK_TRACE = new SelectorBasis("009")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 LK-TRACE-ON          VALUE 'TRACE ON ' 'TRACEON  '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88 LK-TRACE-OFF         VALUE 'TRACE OFF' 'TRACEOFF '. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
                };

                StringBasis LK_TRACE_Param = new StringBasis();

                LK_TRACE_Param.Value = LK_TRACE.Items[0].Value;

                #endregion
                var program = new VG0105S();
                program.Execute(new IntBasis(null, LK_NUM_PLANO_P), new IntBasis(null, LK_NUM_SERIE_P), new IntBasis(null, LK_NUM_TITULO_P), new DoubleBasis(null, 2, LK_NUM_PROPOSTA_P), new IntBasis(null, LK_QTD_TITULOS_P), new DoubleBasis(null, 2, LK_VLR_TITULO_P), new IntBasis(null, LK_EMP_PARCEIRA_P), new IntBasis(null, LK_COD_RAMO_P), new StringBasis(null, LK_COD_USUARIO_P), new IntBasis(null, LK_NUM_NSA_P),  LK_TRACE_Param, new IntBasis(null, LK_OUT_COD_RETORNO_P), new IntBasis(null, LK_OUT_SQLCODE_P), new StringBasis(null, LK_OUT_MENSAGEM_P), new StringBasis(null, LK_OUT_SQLERRMC_P), new StringBasis(null, LK_OUT_SQLSTATE_P));

                var envList = AppSettings.TestSet.DynamicData["R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);
            }
        }
        [Theory]
        [InlineData(123456789, 123456789, 123456789, 123456789, 123456789, 123456789, 123456789, 123456789, "LK_COD_USUARIO_P", 123456789, "LK_TRACE_P", 123456789, 123456789, "LK_OUT_MENSAGEM_P", "LK_OUT_SQLERRMC_P", "LK_OUT_SQLSTATE_P")]
        public static void VG0105S_Tests_Theory_Return_Code99(int LK_NUM_PLANO_P, int LK_NUM_SERIE_P, int LK_NUM_TITULO_P, double LK_NUM_PROPOSTA_P, int LK_QTD_TITULOS_P, double LK_VLR_TITULO_P, int LK_EMP_PARCEIRA_P, int LK_COD_RAMO_P, string LK_COD_USUARIO_P, int LK_NUM_NSA_P, string LK_TRACE_P, int LK_OUT_COD_RETORNO_P, int LK_OUT_SQLCODE_P, string LK_OUT_MENSAGEM_P, string LK_OUT_SQLERRMC_P, string LK_OUT_SQLSTATE_P)
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
                
                IntBasis LK_NUM_SERIE_Param = new IntBasis();
                IntBasis LK_NUM_TITULO_Param = new IntBasis();

                LK_NUM_SERIE_Param.SetValue(00);
                LK_NUM_TITULO_Param.SetValue(00);

                #endregion
                var program = new VG0105S();
                program.Execute(new IntBasis(null, LK_NUM_PLANO_P), new IntBasis(null, LK_NUM_SERIE_Param), new IntBasis(null, LK_NUM_TITULO_Param), new DoubleBasis(null, 2, LK_NUM_PROPOSTA_P), new IntBasis(null, LK_QTD_TITULOS_P), new DoubleBasis(null, 2, LK_VLR_TITULO_P), new IntBasis(null, LK_EMP_PARCEIRA_P), new IntBasis(null, LK_COD_RAMO_P), new StringBasis(null, LK_COD_USUARIO_P), new IntBasis(null, LK_NUM_NSA_P), new StringBasis(null, LK_TRACE_P), new IntBasis(null, LK_OUT_COD_RETORNO_P), new IntBasis(null, LK_OUT_SQLCODE_P), new StringBasis(null, LK_OUT_MENSAGEM_P), new StringBasis(null, LK_OUT_SQLERRMC_P), new StringBasis(null, LK_OUT_SQLSTATE_P));
                
                Assert.Equal(99, program.RETURN_CODE);
            }
        }
    }
}