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
using static Code.VA0152B;

namespace FileTests.Test
{
    [Collection("VA0152B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0152B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0152B_CMOVIM

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NRCERTIF" , ""},
                { "DTMOVTO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0152B_CMOVIM", q1);

            #endregion

            #region M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DTMAXCAN" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_1100_ESTORNA_COMISSAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VALADT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_ESTORNA_COMISSAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CODPRODU" , ""},
                { "FONTE" , ""},
                { "AGENCIA" , ""},
                { "CODCLIEN" , ""},
                { "NRMATRVEN" , ""},
                { "VALBASVG" , ""},
                { "VALBASAP" , ""},
                { "VLCOMISVG" , ""},
                { "VLCOMISAP" , ""},
                { "DTQITBCO" , ""},
                { "PCCOMIND" , ""},
                { "PCCOMGER" , ""},
                { "PCCOMSUP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CODPRODU" , ""},
                { "NRCERTIF" , ""},
                { "FONTE" , ""},
                { "AGENCIA" , ""},
                { "CODCLIEN" , ""},
                { "NRMATRVEN" , ""},
                { "VALBASVG" , ""},
                { "VALBASAP" , ""},
                { "VLCOMISVG" , ""},
                { "VLCOMISAP" , ""},
                { "DTQITBCO" , ""},
                { "PCCOMIND" , ""},
                { "PCCOMGER" , ""},
                { "PCCOMSUP" , ""},
                { "DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1", q6);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0152B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA0152B();
                program.Execute();
                //
                var envList = AppSettings.TestSet.DynamicData["M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
            }
        }
    }
}