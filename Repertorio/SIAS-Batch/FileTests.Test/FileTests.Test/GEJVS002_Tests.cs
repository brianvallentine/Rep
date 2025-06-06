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
using static Code.GEJVS002;

namespace FileTests.Test
{
    [Collection("GEJVS002_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class GEJVS002_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            //AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region GEJVS002_GE074_CURSOR

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , "1989-01-01"},
                { "PARAMGER_DATA_TERVIGENCIA" , "9999-12-31"},
                { "PARAMGER_COD_MOEDA" , "1"},
                { "PARAMGER_COD_BANCO" , "104"},
                { "PARAMGER_COD_AGENCIA" , "630"},
                { "PARAMGER_OPCAO_BANCO" , "1"},
                { "PARAMGER_DIF_PREMIOS" , "10.00000"},
                { "PARAMGER_FAIXA_APOL_MANUAL" , "99999999"},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , "999999"},
                { "PARAMGER_DATA_FATURAVG_AUT" , "1999-12-31"},
                { "PARAMGER_CAPITAL_SOCIAL" , "500000000.00"},
                { "PARAMGER_CAPITAL_REALIZADO" , "500000000.00"},
                { "PARAMGER_CAPITAL_VINCULADO" , "250000000.00"},
                { "PARAMGER_ULT_AVISO_CREDITO" , "0"},
                { "PARAMGER_CODIGO_LIDER" , "5631"},
                { "PARAMGER_NUM_RELACAO" , "96"},
                { "PARAMGER_COD_EMPRESA" , "0"},
                { "PARAMGER_COD_CGCCPF" , "34020354000110"},
                { "PARAMGER_COD_EMPRESA_CAP" , "1"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , "1989-01-01"},
                { "PARAMGER_DATA_TERVIGENCIA" , "9999-12-31"},
                { "PARAMGER_COD_MOEDA" , "1"},
                { "PARAMGER_COD_BANCO" , "104"},
                { "PARAMGER_COD_AGENCIA" , "630"},
                { "PARAMGER_OPCAO_BANCO" , "1"},
                { "PARAMGER_DIF_PREMIOS" , "10.00000"},
                { "PARAMGER_FAIXA_APOL_MANUAL" , "99999999"},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , "999999"},
                { "PARAMGER_DATA_FATURAVG_AUT" , "1999-12-31"},
                { "PARAMGER_CAPITAL_SOCIAL" , "500000000.00"},
                { "PARAMGER_CAPITAL_REALIZADO" , "500000000.00"},
                { "PARAMGER_CAPITAL_VINCULADO" , "250000000.00"},
                { "PARAMGER_ULT_AVISO_CREDITO" , "0"},
                { "PARAMGER_CODIGO_LIDER" , "8141"},
                { "PARAMGER_NUM_RELACAO" , "96"},
                { "PARAMGER_COD_EMPRESA" , "10"},
                { "PARAMGER_COD_CGCCPF" , "3730204000176"},
                { "PARAMGER_COD_EMPRESA_CAP" , "89"}
            });
            AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q0);

            #endregion

            #endregion
        }

        [Fact]
        public static void GEJVS002_Tests_Fact()
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
                #endregion
                var program = new GEJVS002();
                program.Execute(new GEJVW002(), new GEJVWCNT());

                Assert.True(true);
            }
        }
    }
}