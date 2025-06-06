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
using static Code.SI0201B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0201B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0201B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_CURRENT_DATE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0201B_XXXXX

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_HOJE_MENOS_05_DIAS" , ""},
                { "HOST_DATA_HOJE_MENOS_40_DIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0201B_XXXXX", q1);

            #endregion

            #region SI0201B_C01_SINISHIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
                { "SINISCAU_GRUPO_CAUSAS" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0201B_C01_SINISHIS", q2);

            #endregion

            #region R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_TOTAL_PRE_LIBERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_TOTAL_CANC_PRE_LIBERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1", q4);

            #endregion

            #region R210_LE_ESTORNO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R210_LE_ESTORNO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1", q6);

            #endregion

            #region R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1", q7);

            #endregion

            #region R121_SELECT_AGENCIAS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "UNIDACEF_CIDADE" , ""},
                { "UNIDACEF_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R121_SELECT_AGENCIAS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R130_LE_APOLICRE_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""},
                { "APOLICRE_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R130_LE_APOLICRE_DB_SELECT_1_Query1", q9);

            #endregion

            #region R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789")]
        public static void SI0201B_Tests_Theory_ReturnCode00(string SI0201A_FILE_NAME_P)
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
                #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_CURRENT_DATE" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0201B_XXXXX

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_HOJE_MENOS_05_DIAS" , ""},
                { "HOST_DATA_HOJE_MENOS_40_DIAS" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0201B_XXXXX");
                AppSettings.TestSet.DynamicData.Add("SI0201B_XXXXX", q1);

                #endregion

                #region SI0201B_C01_SINISHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
                { "SINISCAU_GRUPO_CAUSAS" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0201B_C01_SINISHIS");
                AppSettings.TestSet.DynamicData.Add("SI0201B_C01_SINISHIS", q2);

                #endregion

                #region R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_TOTAL_PRE_LIBERACAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_TOTAL_CANC_PRE_LIBERACAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1", q4);

                #endregion

                #region R210_LE_ESTORNO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R210_LE_ESTORNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R210_LE_ESTORNO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1", q6);

                #endregion

                #region R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1", q7);

                #endregion

                #region R121_SELECT_AGENCIAS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "UNIDACEF_CIDADE" , ""},
                { "UNIDACEF_UF" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R121_SELECT_AGENCIAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R121_SELECT_AGENCIAS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R130_LE_APOLICRE_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""},
                { "APOLICRE_CGCCPF" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R130_LE_APOLICRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_LE_APOLICRE_DB_SELECT_1_Query1", q9);

                #endregion

                #region R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1", q10);

                #endregion
                #endregion
                var program = new SI0201B();
                program.Execute(new SI0201B_LINK_PARM_DE_EXECUCAO(), SI0201A_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("123456789")]
        public static void SI0201B_Tests_Theory_ReturnCode99(string SI0201A_FILE_NAME_P)
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
                #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_CURRENT_DATE" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0201B_XXXXX

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_HOJE_MENOS_05_DIAS" , ""},
                { "HOST_DATA_HOJE_MENOS_40_DIAS" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0201B_XXXXX");
                AppSettings.TestSet.DynamicData.Add("SI0201B_XXXXX", q1);

                #endregion

                #region SI0201B_C01_SINISHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
                { "SINISCAU_GRUPO_CAUSAS" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0201B_C01_SINISHIS");
                AppSettings.TestSet.DynamicData.Add("SI0201B_C01_SINISHIS", q2);

                #endregion

                #region R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_TOTAL_PRE_LIBERACAO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_TOTAL_CANC_PRE_LIBERACAO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1", q4);

                #endregion

                #region R210_LE_ESTORNO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R210_LE_ESTORNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R210_LE_ESTORNO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1", q6);

                #endregion

                #region R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1", q7);

                #endregion

                #region R121_SELECT_AGENCIAS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "UNIDACEF_CIDADE" , ""},
                { "UNIDACEF_UF" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R121_SELECT_AGENCIAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R121_SELECT_AGENCIAS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R130_LE_APOLICRE_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""},
                { "APOLICRE_CGCCPF" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R130_LE_APOLICRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_LE_APOLICRE_DB_SELECT_1_Query1", q9);

                #endregion

                #region R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1", q10);

                #endregion
                #endregion
                var program = new SI0201B();
                program.Execute(new SI0201B_LINK_PARM_DE_EXECUCAO(), SI0201A_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}