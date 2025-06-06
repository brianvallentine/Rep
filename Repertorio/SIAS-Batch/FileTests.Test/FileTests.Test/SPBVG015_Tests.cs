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
using static Code.SPBVG015;

namespace FileTests.Test
{
    [Collection("SPBVG015_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SPBVG015_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SPBVG015_SPBVG015_SP015A

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "VG142_SEQ_PRODUTO_DPS" , "1234"},
                { "VG142_COD_PRODUTO" , ""},
                { "VG145_SEQ_DPS_REGRA" , ""},
                { "VG145_NOM_DPS_REGRA" , ""},
                { "VG145_IND_TP_REGRA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SPBVG015_SPBVG015_SP015A", q0);

            #endregion

            #region SPBVG015_SPBVG015_SP015B

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "VG141_SEQ_DPS_ITEM" , ""},
                { "VG141_VLR_NUMR_INICIAL" , "79"},
                { "VG141_VLR_NUMR_FINAL" , ""},
                { "VG141_VLR_ALFA_INICIAL" , "100"},
                { "VG141_VLR_ALFA_FINAL" , ""},
                { "VG141_COD_TP_COMPARACAO" , "EQ"},
                { "VG147_NOM_DPS_ITEM" , "VL_IS"},
                { "VG147_IND_TP_ITEM" , "N"},
            });
            AppSettings.TestSet.DynamicData.Add("SPBVG015_SPBVG015_SP015B", q1);

            #endregion

            #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q2);

            #endregion

            #region SEGUROS_SPBGE051_Call1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "LK_GE051_TRACE" , ""},
                { "LK_GE051_NUM_CPF_CNPJ" , "7985632401"},
                { "LK_GE051_S_QTD_CNTR_PREST" , ""},
                { "LK_GE051_S_VLR_IS_ACUM_PREST" , ""},
                { "LK_GE051_S_DTH_CAD_PREST" , ""},
                { "LK_GE051_S_QTD_CONTR_VIDA" , ""},
                { "LK_GE051_S_VLR_IS_ACUM_VIDA" , ""},
                { "LK_GE051_S_DTH_CAD_VIDA" , ""},
                { "LK_GE051_S_QTD_CNTR_PREV" , ""},
                { "LK_GE051_S_VLR_IS_ACUM_PREV" , ""},
                { "LK_GE051_S_DTH_CAD_PREV" , ""},
                { "LK_GE051_S_QTD_CONTR_HABIT" , ""},
                { "LK_GE051_S_VLR_IS_ACUM_HABIT" , ""},
                { "LK_GE051_S_DTH_CAD_HABIT" , ""},
                { "LK_GE051_S_QTD_TOTAL_CNTR" , ""},
                { "LK_GE051_S_VLR_TOTAL_CNTR" , ""},
                { "LK_GE051_S_DTH_CADASTRAMENTO" , ""},
                { "LK_GE051_IND_ERRO" , ""},
                { "LK_GE051_MSG_ERRO" , ""},
                { "LK_GE051_NOM_TABELA" , ""},
                { "LK_GE051_SQLCODE" , ""},
                { "LK_GE051_SQLERRMC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBGE051_Call1", q3);

            #endregion

            #endregion
        }

        [Fact]
        public static void SPBVG015_Tests_Fact_ReturnCallProcedureIsSucess()
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
                var param = new SPVG015W();
                param.LK_VG015_E_COD_PRODUTO.Value = 1;
                param.LK_VG015_E_TRACE.Value = "S";
                param.LK_VG015_E_IDE_SISTEMA.Value = "SPBVG015";
                param.LK_VG015_E_NUM_CPF_CNPJ.Value = 03574845928;
                param.LK_VG015_E_VLR_IS.Value = 79;
                param.LK_VG015_E_COD_USUARIO.Value = "USER001";
                param.LK_VG015_E_NOM_PROGRAMA.Value = "PGM";
                param.LK_VG015_E_TIPO_ACAO.Value = 01;
                #endregion
                var program = new SPBVG015();
                program.Execute(param);

                Assert.True(program.SPVG015W.LK_VG015_IND_ERRO.Value == 0);
                Assert.True(program.SPGE051W.LK_GE051_NUM_CPF_CNPJ.Value == 7985632401);
            }
        }
        [Fact]
        public static void SPBVG015_Tests_Fact_InvalidAction_ReturnError()
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
                var param = new SPVG015W();
                param.LK_VG015_E_COD_PRODUTO.Value = 1;
                param.LK_VG015_E_TRACE.Value = "S";
                param.LK_VG015_E_IDE_SISTEMA.Value = "SPBVG015";
                param.LK_VG015_E_NUM_CPF_CNPJ.Value = 03574845928;
                param.LK_VG015_E_VLR_IS.Value = 79;
                param.LK_VG015_E_COD_USUARIO.Value = "USER001";
                param.LK_VG015_E_NOM_PROGRAMA.Value = "PGM";
                param.LK_VG015_E_TIPO_ACAO.Value = 02;
                #endregion
                var program = new SPBVG015();
                program.Execute(param);

                Assert.True(program.SPVG015W.LK_VG015_IND_ERRO.Value == 1);
                Assert.True(program.SPVG015W.LK_VG015_E_TIPO_ACAO.Value == 2);
            }
        }
        [Fact]
        public static void SPBVG015_Tests_Fact_Empty_CpfCnpj_ReturnError()
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
                var param = new SPVG015W();
                param.LK_VG015_E_TRACE.Value = "S";
                param.LK_VG015_E_IDE_SISTEMA.Value = "SPBVG015";
                #endregion
                var program = new SPBVG015();
                program.Execute(param);

                Assert.True(program.SPVG015W.LK_VG015_IND_ERRO.Value == 1);
                Assert.True(program.SPVG015W.LK_VG015_E_NUM_CPF_CNPJ.IsEmpty());
            }
        }
    }
}