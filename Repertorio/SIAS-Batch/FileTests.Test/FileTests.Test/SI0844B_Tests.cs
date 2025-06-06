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
using static Code.SI0844B;

namespace FileTests.Test
{
    [Collection("SI0844B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0844B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_CODRELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q3);

            #endregion

            #region SI0844B_SINISTRO

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_NUM_APOL" , ""},
                { "V1HSIN_DTMOVTO" , ""},
                { "V1HSIN_NUM_SINI" , ""},
                { "V1MSIN_RAMO" , ""},
                { "V1MSIN_FONTE" , ""},
                { "V1MSIN_CODCAU" , ""},
                { "V1HSIN_VAL_OPERACAO" , ""},
                { "V1HSIN_CODUSU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0844B_SINISTRO", q4);

            #endregion

            #region R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1SCAU_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0844B_OUTPUT_202504040000")]
        public static void SI0844B_Tests_Theory(string RSI0844B_FILE_NAME_P)
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
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA S.A."}
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1", q2);
                #endregion
                var program = new SI0844B();
                program.LK_LINK.LK_TAMANHO.Value = +40;
                program.Execute(RSI0844B_FILE_NAME_P);

                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1"].DynamicList.ToList());

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0844B_OUTPUT_202504040001")]
        public static void SI0844B_Tests_Theory_Return_Error_Code_99(string RSI0844B_FILE_NAME_P)
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
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , ""},
                    { "V1SIST_DTCURRENT" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new SI0844B();
                program.Execute(RSI0844B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}