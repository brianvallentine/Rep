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
using static Code.GE0502B;

namespace FileTests.Test
{
    [Collection("GE0502B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0502B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-25"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-26"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-26"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , "1"},
                { "OD001_DTH_CADASTRAMENTO" , "2009-10-09 08:20:52.437"},
                { "OD001_NUM_DV_PESSOA" , "9"},
                { "OD001_IND_PESSOA" , "J"},
                { "OD001_STA_INF_INTEGRA" , "S"},
                { "OD007_SEQ_ENDERECO" , "3"},
                { "OD007_DTH_CADASTRAMENTO" , "2007-08-05 05:06:51.788"},
                { "OD007_IND_ENDERECO" , "C"},
                { "OD007_STA_ENDERECO" , "A"},
                { "OD007_NOM_LOGRADOURO" , "SCN QUADRA 1                                                            "},
                { "OD007_DES_NUM_IMOVEL" , ""},
                { "OD007_DES_COMPL_ENDERECO" , "ED NUMBER ONE 11 ANDAR                                                  "},
                { "OD007_NOM_BAIRRO" , "ASA NORTE                                                               "},
                { "OD007_NOM_CIDADE" , "BRASILIA                                                                "},
                { "OD007_COD_CEP" , "70711000"},
                { "OD007_COD_UF" , "UF"},
                { "OD007_STA_CORRESPONDER" , "N"},
                { "OD007_STA_PROPAGANDA" , "N"},
            });
            AppSettings.TestSet.DynamicData.Add("R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R100_INSERT_ENDERECO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "OD007_SEQ_ENDERECO" , "1308"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "OD007_SEQ_ENDERECO" , "1308"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "OD007_SEQ_ENDERECO" , "1308"}
            });
            AppSettings.TestSet.DynamicData.Add("R100_INSERT_ENDERECO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R100_INSERT_ENDERECO_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "OD007_NUM_PESSOA" , ""},
                { "OD007_SEQ_ENDERECO" , ""},
                { "OD007_DTH_CADASTRAMENTO" , ""},
                { "OD007_IND_ENDERECO" , ""},
                { "OD007_STA_ENDERECO" , ""},
                { "OD007_NOM_LOGRADOURO" , ""},
                { "OD007_DES_NUM_IMOVEL" , ""},
                { "OD007_DES_COMPL_ENDERECO" , ""},
                { "OD007_NOM_BAIRRO" , ""},
                { "OD007_NOM_CIDADE" , ""},
                { "OD007_COD_CEP" , ""},
                { "OD007_COD_UF" , ""},
                { "OD007_STA_CORRESPONDER" , ""},
                { "OD007_STA_PROPAGANDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_INSERT_ENDERECO_DB_INSERT_1_Insert1", q3);

            #endregion

            #region GE0502B_V0ENDERECO

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , "1"},
                { "OD001_DTH_CADASTRAMENTO" , "2009-10-09 08:20:52.437"},
                { "OD001_NUM_DV_PESSOA" , "9"},
                { "OD001_IND_PESSOA" , "J"},
                { "OD001_STA_INF_INTEGRA" , "S"},
                { "OD007_SEQ_ENDERECO" , "3"},
                { "OD007_DTH_CADASTRAMENTO" , "2007-08-05 05:06:51.788"},
                { "OD007_IND_ENDERECO" , "C"},
                { "OD007_STA_ENDERECO" , "A"},
                { "OD007_NOM_LOGRADOURO" , "SCN QUADRA 1                                                            "},
                { "OD007_DES_NUM_IMOVEL" , ""},
                { "OD007_DES_COMPL_ENDERECO" , "ED NUMBER ONE 11 ANDAR                                                  "},
                { "OD007_NOM_BAIRRO" , "ASA NORTE                                                               "},
                { "OD007_NOM_CIDADE" , "BRASILIA                                                                "},
                { "OD007_COD_CEP" , "70711000"},
                { "OD007_COD_UF" , "UF"},
                { "OD007_STA_CORRESPONDER" , "N"},
                { "OD007_STA_PROPAGANDA" , "N"},
            });
            AppSettings.TestSet.DynamicData.Add("GE0502B_V0ENDERECO", q4);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0502B_Tests_Fact()
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
                var program = new GE0502B();
                program.Execute(new GE0502B_LINK_PARAMETRO());

                Assert.True(true);
            }
        }
    }
}