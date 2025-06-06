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
using static Code.GE0355S;

namespace FileTests.Test
{
    [Collection("GE0355S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0355S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_FATOR_VENC" , "3"}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0355S_Tests_Fact_FatorVencimento5_ReturnCode_00()
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
                var inputParam = new GE0355S_REGISTRO_LINKAGE_GE0355S();
                inputParam.LK_GE355_IN_BANCO.Value = 0;
                inputParam.LK_GE355_IN_COD_BENEFICIARIO.Value = "1234";
                inputParam.LK_GE355_IN_DATA_VENCIMENTO.Value = "2024-05-05";
                inputParam.LK_GE355_IN_MOEDA.Value = 1;
                inputParam.LK_GE355_IN_NOSSO_NUMERO.Value = 034143211234567800;
                inputParam.LK_GE355_IN_VLR_BOLETO.Value = 100;

                #region R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WS_FATOR_VENC" , "5"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new GE0355S();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_COD_RETORNO == 00);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_NOSSO_NUMERO == 034143211234567800);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_FATOR_VENCIMENTO == 5);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_MENSAGEM.LK_GE355_OUT_SQLCODE == 0);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_LINHA_DIGITAVEL.Substring(41, 4) == "0005");
            }
        }

        [Fact]
        public static void GE0355S_Tests_Fact_FatorVencimento0_ReturnCode_00()
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
                var inputParam = new GE0355S_REGISTRO_LINKAGE_GE0355S();
                inputParam.LK_GE355_IN_BANCO.Value = 0;
                inputParam.LK_GE355_IN_COD_BENEFICIARIO.Value = "1234";
                inputParam.LK_GE355_IN_MOEDA.Value = 1;
                inputParam.LK_GE355_IN_NOSSO_NUMERO.Value = 023743255293877800;
                inputParam.LK_GE355_IN_VLR_BOLETO.Value = 100;

                #region R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WS_FATOR_VENC" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new GE0355S();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_COD_RETORNO == 00);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_NOSSO_NUMERO == 023743255293877800);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_FATOR_VENCIMENTO == 0);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_MENSAGEM.LK_GE355_OUT_SQLCODE == 0);
                Assert.True(program.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_LINHA_DIGITAVEL.Substring(41, 4) == "0000");

            }
        }
    }
}