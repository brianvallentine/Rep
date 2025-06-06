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
using static Code.BI0005S;

namespace FileTests.Test
{
    [Collection("BI0005S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0005S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_NOME_PESSOA" , ""},
                { "BI0005L_S_TIPO_PESSOA" , ""},
                { "BI0005L_S_SIGLA_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_CPF" , ""},
                { "BI0005L_S_DATA_NASC" , ""},
                { "BI0005L_S_SEXO" , ""},
                { "BI0005L_S_ESTADO_CIVIL" , ""},
                { "BI0005L_S_NUM_IDENT" , ""},
                { "BI0005L_S_ORGAO_EXPED" , ""},
                { "BI0005L_S_UF_EXPEDIDORA" , ""},
                { "BI0005L_S_DATA_EXPED" , ""},
                { "BI0005L_S_COD_CBO" , ""},
                { "BI0005L_S_TIP_IDE_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1", q1);

            #endregion

            #region M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_CGC" , ""},
                { "BI0005L_S_NOME_FANTASIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1", q3);

            #endregion

            #region M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1", q4);

            #endregion

            #region M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_EMA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_EMAIL" , ""},
                { "BI0005L_S_SIT_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1", q6);

            #endregion

            #region M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_ENDERECO_R" , ""},
                { "BI0005L_S_OCC_END_R" , ""},
                { "BI0005L_S_TIPO_ENDER_R" , ""},
                { "BI0005L_S_COMPL_ENDER_R" , ""},
                { "BI0005L_S_BAIRRO_R" , ""},
                { "BI0005L_S_CEP_R" , ""},
                { "BI0005L_S_CIDADE_R" , ""},
                { "BI0005L_S_SIGLA_UF_R" , ""},
                { "BI0005L_S_SIT_ENDER_R" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1", q8);

            #endregion

            #region B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1", q9);

            #endregion

            #region B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_ENDERECO_C" , ""},
                { "BI0005L_S_OCC_END_C" , ""},
                { "BI0005L_S_TIPO_ENDER_C" , ""},
                { "BI0005L_S_COMPL_ENDER_C" , ""},
                { "BI0005L_S_BAIRRO_C" , ""},
                { "BI0005L_S_CEP_C" , ""},
                { "BI0005L_S_CIDADE_C" , ""},
                { "BI0005L_S_SIGLA_UF_C" , ""},
                { "BI0005L_S_SIT_ENDER_C" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1", q10);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI0005S_Tests_FactTipoPessoaF()
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

                #region M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_NOME_PESSOA" , "TESTE"},
                { "BI0005L_S_TIPO_PESSOA" , "F"},
                { "BI0005L_S_SIGLA_PESSOA" , "T"},
            });
                AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1");

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "1"}
            }); q2.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "1"}
            }); q2.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1
                AppSettings.TestSet.DynamicData.Remove("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1");

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
            }); q4.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
            }); q4.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1", q4);

                #endregion
                #region M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1");

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_EMA" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1", q5);

                #endregion
                #region M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1");

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1", q7);

                #endregion
                #region B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1");

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1", q9);

                #endregion
               
                #endregion
                var program = new BI0005S();
                var param = new BI0005S_BI0005L_LINKAGE();
                param.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.Value = 1;

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);
                
                var envList = AppSettings.TestSet.DynamicData["M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1"].DynamicList;
                Assert.NotEmpty(envList);
            }
        }
        [Fact]
        public static void BI0005S_Tests_Fact()
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

                #region M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_NOME_PESSOA" , "TESTE"},
                { "BI0005L_S_TIPO_PESSOA" , "T"},
                { "BI0005L_S_SIGLA_PESSOA" , "T"},
            });
                AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1");

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "1"}
            }); q2.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "1"}
            }); q2.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1
                AppSettings.TestSet.DynamicData.Remove("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1");

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
            }); q4.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
            }); q4.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1", q4);

                #endregion
                #region M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1");

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_EMA" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1", q5);

                #endregion
                #region M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1");

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1", q7);

                #endregion
                #region B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1");

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1", q9);

                #endregion
                #endregion
                var program = new BI0005S();
                var param = new BI0005S_BI0005L_LINKAGE();
                param.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.Value = 1;

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1"].DynamicList;
                Assert.Empty(envList);


            }
        }
    }
}