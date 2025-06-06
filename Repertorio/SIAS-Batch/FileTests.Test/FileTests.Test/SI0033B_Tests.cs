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
using static Code.SI0033B;

namespace FileTests.Test
{
    [Collection("SI0033B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0033B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1", q2);

            #endregion

            #region SI0033B_LISTA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""},
                { "SIDOCPAR_COD_TIPO_CARTA" , ""},
                { "SIEVETIP_DESCR_EVENTO" , ""},
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIMOVSIN_COD_SUBESTIPULANTE" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
                { "GERECADE_COD_DESTINATARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0033B_LISTA", q3);

            #endregion

            #region R1100_00_LE_CLIENTES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_CLIENTES_DB_SELECT_1_Query1", q4);

            #endregion

            #region R3100_00_LE_USUARIOS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_LE_USUARIOS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GEDESTIN_NOME_DESTINATARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1", q6);

            #endregion

            #region R5100_00_LE_SISINACO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_DATA_MOVTO_SINIACO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5100_00_LE_SISINACO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R5200_00_LE_SINISMES_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_IRB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5200_00_LE_SINISMES_DB_SELECT_1_Query1", q8);

            #endregion

            #region R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0033B_t1")]
        public static void SI0033B_Tests_Theory_ReturnCode00(string SI0033B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0033B1_FILE_NAME_P = $"{SI0033B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1", q2);

                #endregion

                #region SI0033B_LISTA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""},
                { "SIDOCPAR_COD_TIPO_CARTA" , ""},
                { "SIEVETIP_DESCR_EVENTO" , ""},
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIMOVSIN_COD_SUBESTIPULANTE" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
                { "GERECADE_COD_DESTINATARIO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0033B_LISTA");
                AppSettings.TestSet.DynamicData.Add("SI0033B_LISTA", q3);

                #endregion

                #region R1100_00_LE_CLIENTES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_CLIENTES_DB_SELECT_1_Query1", q4);

                #endregion

                #region R3100_00_LE_USUARIOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_LE_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_LE_USUARIOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GEDESTIN_NOME_DESTINATARIO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1", q6);

                #endregion

                #region R5100_00_LE_SISINACO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_DATA_MOVTO_SINIACO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R5100_00_LE_SISINACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5100_00_LE_SISINACO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R5200_00_LE_SINISMES_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_IRB" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R5200_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5200_00_LE_SINISMES_DB_SELECT_1_Query1", q8);

                #endregion

                #region R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1", q10);

                #endregion
                #endregion
                var program = new SI0033B();
                program.Execute(SI0033B1_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True((AppSettings.TestSet.DynamicData["R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList).Count > 1);

                Assert.True(selects.Count > (allSelects.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0033B_t2")]
        public static void SI0033B_Tests_Theory_ReturnCode99(string SI0033B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0033B1_FILE_NAME_P = $"{SI0033B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1", q2);

                #endregion

                #region SI0033B_LISTA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""},
                { "SIDOCPAR_COD_TIPO_CARTA" , ""},
                { "SIEVETIP_DESCR_EVENTO" , ""},
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIMOVSIN_COD_SUBESTIPULANTE" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
                { "GERECADE_COD_DESTINATARIO" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0033B_LISTA");
                AppSettings.TestSet.DynamicData.Add("SI0033B_LISTA", q3);

                #endregion

                #region R1100_00_LE_CLIENTES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_CLIENTES_DB_SELECT_1_Query1", q4);

                #endregion

                #region R3100_00_LE_USUARIOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3100_00_LE_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_LE_USUARIOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GEDESTIN_NOME_DESTINATARIO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1", q6);

                #endregion

                #region R5100_00_LE_SISINACO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_DATA_MOVTO_SINIACO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R5100_00_LE_SISINACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5100_00_LE_SISINACO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R5200_00_LE_SINISMES_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_IRB" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R5200_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5200_00_LE_SINISMES_DB_SELECT_1_Query1", q8);

                #endregion

                #region R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1", q10);

                #endregion
                #endregion
                var program = new SI0033B();
                program.Execute(SI0033B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}