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
using static Code.SI1032S;

namespace FileTests.Test
{
    [Collection("SI1032S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI1032S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            
            #endregion
        }
        [Fact]
        public static void SI1032S_Tests_Fact_SomaValorApolice_1000()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var inputParam = new LBSI1001_SI1001S_PARAMETROS()
                {
                    SI1001S_ENTRADA = new LBSI1001_SI1001S_ENTRADA()
                    {
                        SI1001S_COD_FUNCAO = new IntBasis()
                        {
                            Pic = new PIC("S9", "9", "S9(009)"),
                            Value = 001
                        },
                        SI1001S_NUM_APOL_SINISTRO = new IntBasis()
                        {
                            Pic = new PIC("S9", "13", "S9(013)"),
                            Value = 0000019790324
                        },
                        SI1001S_COD_PRODUTO = new IntBasis()
                        {
                            Pic = new PIC("S9", "4", "S9(004)"),
                            Value = 0002
                        },
                        SI1001S_RAMO = new IntBasis()
                        {
                            Pic = new PIC("S9", "4", "S9(004)"),
                            Value = 0003
                        },
                        SI1001S_DATA_INICIO = new StringBasis()
                        {
                            Pic = new PIC("X", "10", "X(010)"),
                            Value = "2024-10-01"
                        },
                        SI1001S_DATA_FIM = new StringBasis()
                        {
                            Pic = new PIC("X", "10", "X(010)"),
                            Value = "2024-10-31"
                        }


                    }
                };
                #endregion
                var program = new SI1032S();
                program.Execute(inputParam);
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO == 500000);
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO == "0000019790324");
            }
        }
        [Fact]
        public static void SI1032S_Tests_Fact_SomaValorRamo_3000()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var inputParam = new LBSI1001_SI1001S_PARAMETROS()
                {
                    SI1001S_ENTRADA = new LBSI1001_SI1001S_ENTRADA()
                    {
                        SI1001S_COD_FUNCAO = new IntBasis()
                        {
                            Pic = new PIC("S9", "9", "S9(009)"),
                            Value = 001
                        },
                        SI1001S_NUM_APOL_SINISTRO = new IntBasis()
                        {
                            Pic = new PIC("S9", "13", "S9(013)"),
                            Value = 0
                        },
                        SI1001S_COD_PRODUTO = new IntBasis()
                        {
                            Pic = new PIC("S9", "4", "S9(004)"),
                            Value = 0
                        },
                        SI1001S_RAMO = new IntBasis()
                        {
                            Pic = new PIC("S9", "4", "S9(004)"),
                            Value = 0003
                        },
                        SI1001S_DATA_INICIO = new StringBasis()
                        {
                            Pic = new PIC("X", "10", "X(010)"),
                            Value = "2024-10-01"
                        },
                        SI1001S_DATA_FIM = new StringBasis()
                        {
                            Pic = new PIC("X", "10", "X(010)"),
                            Value = "2024-10-31"
                        }
                    }
                };
                #endregion
                var program = new SI1032S();
                program.Execute(inputParam);
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO == 20235659);
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_RAMO == 0003);
            }
        }
        [Fact]
        public static void SI1032S_Tests_Fact_Apolice_Produto_Ramo_Vazios()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                SI1000S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE
                var inputParam = new LBSI1001_SI1001S_PARAMETROS()
                {
                    SI1001S_ENTRADA = new LBSI1001_SI1001S_ENTRADA()
                    {
                        SI1001S_COD_FUNCAO = new IntBasis()
                        {
                            Pic = new PIC("S9", "9", "S9(009)"),
                            Value = 001
                        },
                        SI1001S_NUM_APOL_SINISTRO = new IntBasis()
                        {
                            Pic = new PIC("S9", "13", "S9(013)"),
                            Value = 0
                        },
                        SI1001S_COD_PRODUTO = new IntBasis()
                        {
                            Pic = new PIC("S9", "4", "S9(004)"),
                            Value = 0
                        },
                        SI1001S_RAMO = new IntBasis()
                        {
                            Pic = new PIC("S9", "4", "S9(004)"),
                            Value = 0
                        },
                        SI1001S_DATA_INICIO = new StringBasis()
                        {
                            Pic = new PIC("X", "10", "X(010)"),
                            Value = "2024-10-01"
                        },
                        SI1001S_DATA_FIM = new StringBasis()
                        {
                            Pic = new PIC("X", "10", "X(010)"),
                            Value = "2024-10-31"
                        }


                    }
                };
                #endregion
                var program = new SI1032S();
                program.Execute(inputParam);
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_PARAGRAFO == 010);
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_RAMO == 0);
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO == 0);
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_COD_PRODUTO == 0);
            }
        }

    }
}