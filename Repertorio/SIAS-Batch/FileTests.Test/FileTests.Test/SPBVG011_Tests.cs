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
using static Code.SPBVG011;

namespace FileTests.Test
{
    [Collection("SPBVG011_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SPBVG011_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SPBVG011_TCOTAC

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , ""},
                { "MOEDACOT_VAL_VENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SPBVG011_TCOTAC", q0);

            #endregion

            #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region P0302_05_INICIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WSNOVO_DIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0302_05_INICIO_DB_SELECT_1_Query1", q2);

            #endregion

            #region P3021_05_INICIO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VG077_COD_MOEDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P3021_05_INICIO_DB_SELECT_1_Query1", q3);

            #endregion

            #region P3022_05_INICIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE252_COD_MOEDA" , ""},
                { "GE252_PCT_JUROS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P3022_05_INICIO_DB_SELECT_1_Query1", q4);

            #endregion

            #endregion
        }

        [Fact]
        public static void SPBVG011_Tests_Fact()
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
                SPVG011W SPVG011W_P = new SPVG011W();

                StringBasis LK_VG011_E_COD_USUARIO  = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                StringBasis LK_VG011_E_NOM_PROGRAMA = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                IntBasis LK_VG011_E_TIPO_ACAO  = new IntBasis(new PIC("S9", "4", "S9(004)"));
                IntBasis LK_VG011_E_COD_PRODUTO = new IntBasis(new PIC("S9", "4", "S9(004)"));
                StringBasis LK_VG011_E_DTA_INI_CALCULO = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                StringBasis LK_VG011_E_DTA_FIM_CALCULO = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                StringBasis LK_VG011_E_DTA_DECLINIO = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                DoubleBasis LK_VG011_E_VL_ORIGINAL  = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
                IntBasis LK_VG011_E_QTD_DIA_PGMNTO  = new IntBasis(new PIC("S9", "4", "S9(004)"));
                IntBasis LK_VG011_E_NUM_APOLICE = new IntBasis(new PIC("S9", "18", "S9(18)"));

                LK_VG011_E_COD_USUARIO.Value ="2";
                LK_VG011_E_NOM_PROGRAMA.Value = "NOME DO PROGRAMA";
                LK_VG011_E_TIPO_ACAO.Value = 3;
                LK_VG011_E_COD_PRODUTO.Value = 1;
                LK_VG011_E_DTA_INI_CALCULO.Value = "2025-01-04";
                LK_VG011_E_DTA_FIM_CALCULO.Value = "2025-01-05";
                LK_VG011_E_DTA_DECLINIO.Value = "2025-01-06";
                LK_VG011_E_VL_ORIGINAL.Value = 1.01;
                LK_VG011_E_QTD_DIA_PGMNTO.Value = 1;
                LK_VG011_E_NUM_APOLICE.Value= 1;

                SPVG011W_P.LK_VG011_E_COD_USUARIO = LK_VG011_E_COD_USUARIO;
                SPVG011W_P.LK_VG011_E_NOM_PROGRAMA = LK_VG011_E_NOM_PROGRAMA;
                SPVG011W_P.LK_VG011_E_TIPO_ACAO = LK_VG011_E_TIPO_ACAO;
                SPVG011W_P.LK_VG011_E_COD_PRODUTO = LK_VG011_E_COD_PRODUTO;
                SPVG011W_P.LK_VG011_E_DTA_INI_CALCULO = LK_VG011_E_DTA_INI_CALCULO;
                SPVG011W_P.LK_VG011_E_DTA_FIM_CALCULO = LK_VG011_E_DTA_FIM_CALCULO;
                SPVG011W_P.LK_VG011_E_DTA_DECLINIO = LK_VG011_E_DTA_DECLINIO;
                SPVG011W_P.LK_VG011_E_VL_ORIGINAL = LK_VG011_E_VL_ORIGINAL;
                SPVG011W_P.LK_VG011_E_QTD_DIA_PGMNTO = LK_VG011_E_QTD_DIA_PGMNTO;
                SPVG011W_P.LK_VG011_E_NUM_APOLICE = LK_VG011_E_NUM_APOLICE;

                #endregion
                var program = new SPBVG011();
                program.Execute(SPVG011W_P);

                var envList = AppSettings.TestSet.DynamicData["P0050_05_INICIO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);

            }
        }
    }
}