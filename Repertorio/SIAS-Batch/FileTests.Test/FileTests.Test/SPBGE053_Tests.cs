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
using static Code.SPBGE053;
using Microsoft.AspNetCore.Mvc.Localization;

namespace FileTests.Test
{
    [Collection("SPBGE053_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SPBGE053_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SPBGE053_CSR_NOM_SOCIAL

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_CPF" , "03574845928"},
                { "DTH_OPERACAO" , "2024-06-04 21:17:05.975"},
                { "CASE_IND_USA_NOME_SOCIAL" , "NOME SOCIAL TESTE"},
                { "IND_TIPO_ACAO" , "I"},
                { "IND_USA_NOME_SOCIAL" , "S"},
                { "IFNULL_" , ""},
                { "COD_CANAL_ORIGEM" , "0007      "},
                { "NUM_MATRICULA" , "SPBGE052            "},
                { "NOM_PROGRAMA" , "SPBGE053  "},
                { "DTH_CADASTRAMENTO" , "2024-06-04 21:17:05.975"},
            });
            AppSettings.TestSet.DynamicData.Add("SPBGE053_CSR_NOM_SOCIAL", q0);

            #endregion

            #region P1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2000-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("P1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region P2020_INSERE_GE149_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE149_NUM_CPF" , ""},
                { "GE149_DTH_OPERACAO" , ""},
                { "GE149_NOM_SOCIAL" , ""},
                { "GE149_IND_TIPO_ACAO" , ""},
                { "GE149_IND_USA_NOME_SOCIAL" , ""},
                { "GE149_COD_TP_PES_NEGOCIO" , ""},
                { "GE149_NUM_PROPOSTA" , ""},
                { "GE149_COD_CANAL_ORIGEM" , ""},
                { "GE149_NUM_MATRICULA" , ""},
                { "GE149_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2020_INSERE_GE149_DB_INSERT_1_Insert1", q2);

            #endregion

            #region P2030_CONSULTA_GE149_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE149_NUM_CPF" , ""},
                { "GE149_DTH_OPERACAO" , ""},
                { "GE149_NOM_SOCIAL" , ""},
                { "GE149_IND_TIPO_ACAO" , ""},
                { "GE149_IND_USA_NOME_SOCIAL" , ""},
                { "GE149_COD_TP_PES_NEGOCIO" , ""},
                { "GE149_NUM_PROPOSTA" , ""},
                { "GE149_COD_CANAL_ORIGEM" , ""},
                { "GE149_NUM_MATRICULA" , ""},
                { "GE149_NOM_PROGRAMA" , ""},
                { "GE149_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2030_CONSULTA_GE149_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        [Fact]
        public static void SPBGE053_Tests_Fact()
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
                var param = new SPGE053W();
                param.LK_GE053_E_TRACE.Value = "S";
                param.LK_GE053_E_IND_OPERACAO.Value = 1;
                param.LK_GE053_I_NUM_CPF.Value = 2095520939;
                param.LK_GE053_I_DTH_OPERACAO.Value = "2024-06-04 21:17:05.975";
                param.LK_GE053_I_IND_TIPO_ACAO.Value = "I";
                param.LK_GE053_I_IND_USA_NOME_SOCIAL.Value = "S";
                param.LK_GE053_I_NUM_PROPOSTA.Value = 80012090323343;
                param.LK_GE053_I_COD_CANAL_ORIGEM.Value = "8";
                param.LK_GE053_I_NUM_MATRICULA.Value = "PF0600B             ";

                #endregion
                var program = new SPBGE053();
                program.Execute(param);

                Assert.True(program.SPGE053W.LK_GE053_ID_ERRO.Value == 0);

                //P2020_INSERE_GE149_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["P2020_INSERE_GE149_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("GE149_NUM_PROPOSTA", out var val0r) && val0r.Contains("000080012090323343"));
                Assert.True(envList0.Count > 1);

            }
        }
        [Fact]
        public static void SPBGE053_Tests_Fact_CpfNaoInformado_Erro_5()
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
                var param = new SPGE053W();
                param.LK_GE053_E_TRACE.Value = "S";
                param.LK_GE053_E_IND_OPERACAO.Value = 1;
                #endregion
                var program = new SPBGE053();
                program.Execute(param);

                Assert.True(program.SPGE053W.LK_GE053_ID_ERRO.Value == 5);
            }
        }
    }
}