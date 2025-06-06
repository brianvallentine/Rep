using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.SI0134B;

namespace FileTests.Test
{
    [Collection("SI0134B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0134B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0134B_SINISTRO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0134B_SINISTRO", q0);

            #endregion

            #region R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIHABIT2_CODIGO_CH1_REC1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "AGTABCH1_DESCRICAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1", q3);

            #endregion

            #region R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_NOME_SEGURADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA_INI" , ""},
                { "WHOST_DT_HOJE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0134B_t1")]
        public static void SI0134B_Tests_Theory(string SAI0134B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0134B_FILE_NAME_P = $"{SAI0134B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region SI0134B_SINISTRO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , "Seguros" },
                { "SINISMES_NUM_APOLICE" , "123456789" },
                { "SINISMES_COD_SUBGRUPO" , "001" },
                { "SINISMES_NUM_CERTIFICADO" , "987654321" },
                { "SINISHIS_COD_USUARIO" , "USR001" },
                { "SINISHIS_VAL_OPERACAO" , "1500.00" },
                { "SINISHIS_DATA_MOVIMENTO" , "2023-12-01" },
                { "SINISHIS_DATA_LIM_CORRECAO" , "2023-12-15" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "123456789" },
                { "SINISHIS_COD_OPERACAO" , "OP123" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
            });
            AppSettings.TestSet.DynamicData.Remove("SI0134B_SINISTRO");
AppSettings.TestSet.DynamicData.Add("SI0134B_SINISTRO", q0);

                #endregion

                #region R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , "João Silva" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIHABIT2_CODIGO_CH1_REC1" , "CH1-001" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "AGTABCH1_DESCRICAO" , "Tabela de Códigos" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1", q3);

                #endregion

                #region R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_NOME_SEGURADO" , "Maria Oliveira" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , "Banco XYZ" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Empresa ABC Ltda" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-11-20" },
                { "WHOST_DATA_INI" , "2023-11-01" },
                { "WHOST_DT_HOJE" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new SI0134B();
                program.Execute(SAI0134B_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0134B_t2")]
        public static void SI0134B_Tests_Theory_ReturnCode99(string SAI0134B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0134B_FILE_NAME_P = $"{SAI0134B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region SI0134B_SINISTRO

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , "Seguros" },
                { "SINISMES_NUM_APOLICE" , "123456789" },
                { "SINISMES_COD_SUBGRUPO" , "001" },
                { "SINISMES_NUM_CERTIFICADO" , "987654321" },
                { "SINISHIS_COD_USUARIO" , "USR001" },
                { "SINISHIS_VAL_OPERACAO" , "1500.00" },
                { "SINISHIS_DATA_MOVIMENTO" , "2023-12-01" },
                { "SINISHIS_DATA_LIM_CORRECAO" , "2023-12-15" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "123456789" },
                { "SINISHIS_COD_OPERACAO" , "OP123" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0134B_SINISTRO");
                AppSettings.TestSet.DynamicData.Add("SI0134B_SINISTRO", q0);

                #endregion

                #region R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , "João Silva" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SIHABIT2_CODIGO_CH1_REC1" , "CH1-001" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "AGTABCH1_DESCRICAO" , "Tabela de Códigos" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1", q3);

                #endregion

                #region R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_NOME_SEGURADO" , "Maria Oliveira" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , "Banco XYZ" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Empresa ABC Ltda" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-11-20" },
                { "WHOST_DATA_INI" , "2023-11-01" },
                { "WHOST_DT_HOJE" , "2023-12-01" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new SI0134B();
                program.Execute(SAI0134B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}