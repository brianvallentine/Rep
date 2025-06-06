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
using static Code.FI0007B;

namespace FileTests.Test
{
    [Collection("FI0007B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class FI0007B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE_FI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NUM_CHQINT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1", q2);

            #endregion

            #region FI0007B_COSCEDCHEQUE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , ""},
                { "V0CCHQ_CONGENER" , ""},
                { "V0CCHQ_DTMOVTO_AC" , ""},
                { "V0CCHQ_VLPREMIO" , ""},
                { "V0CCHQ_VLRDESCON" , ""},
                { "V0CCHQ_VLRADIFRA" , ""},
                { "V0CCHQ_VLRCOMIS" , ""},
                { "V0CCHQ_VLRSINI" , ""},
                { "V0CCHQ_VLDESPESA" , ""},
                { "V0CCHQ_VLRHONOR" , ""},
                { "V0CCHQ_VLRSALVD" , ""},
                { "V0CCHQ_VLRESSARC" , ""},
                { "V0CCHQ_VALOR_EDI" , ""},
                { "V0CCHQ_VALOR_USS" , ""},
                { "V0CCHQ_VLEQPVNDA" , ""},
                { "V0CCHQ_VLDESPADM" , ""},
                { "V0CCHQ_OUTRDEBIT" , ""},
                { "V0CCHQ_OUTRCREDT" , ""},
                { "V0CCHQ_VLRSLDANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FI0007B_COSCEDCHEQUE", q3);

            #endregion

            #region R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1CONG_NOMECONG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0CHEQ_TPMOVTO" , ""},
                { "V0CHEQ_FONTE" , ""},
                { "V0CHEQ_NUMDOC" , ""},
                { "V0CHEQ_NOMFAV" , ""},
                { "V0CHEQ_VALCHQ" , ""},
                { "V0CHEQ_DTMOVTO" , ""},
                { "V0CHEQ_CHQINT" , ""},
                { "V0CHEQ_DIGINT" , ""},
                { "V0CHEQ_SITUACAO" , ""},
                { "V0CHEQ_TIPPAG" , ""},
                { "V0CHEQ_DATCMP" , ""},
                { "V0CHEQ_PRAPAG" , ""},
                { "V0CHEQ_NUMREC" , ""},
                { "V0CHEQ_OCORHIST" , ""},
                { "V0CHEQ_OPERACAO" , ""},
                { "V0CHEQ_CODDSA" , ""},
                { "V0CHEQ_VALIRF" , ""},
                { "V0CHEQ_VALISS" , ""},
                { "V0CHEQ_VALIAP" , ""},
                { "V0CHEQ_CODLAN" , ""},
                { "V0CHEQ_DATLAN" , ""},
                { "V0CHEQ_EMPRESA" , ""},
                { "V0CHEQ_CODFAV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCHE_CHQINT" , ""},
                { "V0HCHE_DIGINT" , ""},
                { "V0HCHE_DTMOVTO" , ""},
                { "V0HCHE_HORAOPER" , ""},
                { "V0HCHE_OPERACAO" , ""},
                { "V0HCHE_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_NRCHEQUE" , ""},
                { "V0CCHQ_DVCHEQUE" , ""},
                { "V1SIST_DTMOVABE_FI" , ""},
                { "V0CCHQ_COD_EMPR" , ""},
                { "V0CCHQ_CONGENER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void FI0007B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE


    #region R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE_FI" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NUM_CHQINT" , "123456789" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1", q2);

                #endregion

                #region FI0007B_COSCEDCHEQUE

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "001" },
                { "V0CCHQ_CONGENER" , "002" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-15" },
                { "V0CCHQ_VLPREMIO" , "1500.00" },
                { "V0CCHQ_VLRDESCON" , "50.00" },
                { "V0CCHQ_VLRADIFRA" , "90000.00" },
                { "V0CCHQ_VLRCOMIS" , "200.00" },
                { "V0CCHQ_VLRSINI" , "300.00" },
                { "V0CCHQ_VLDESPESA" , "400.00" },
                { "V0CCHQ_VLRHONOR" , "500.00" },
                { "V0CCHQ_VLRSALVD" , "600.00" },
                { "V0CCHQ_VLRESSARC" , "700.00" },
                { "V0CCHQ_VALOR_EDI" , "800.00" },
                { "V0CCHQ_VALOR_USS" , "900.00" },
                { "V0CCHQ_VLEQPVNDA" , "1000.00" },
                { "V0CCHQ_VLDESPADM" , "1100.00" },
                { "V0CCHQ_OUTRDEBIT" , "1200.00" },
                { "V0CCHQ_OUTRCREDT" , "1300.00" },
                { "V0CCHQ_VLRSLDANT" , "1400.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("FI0007B_COSCEDCHEQUE");
AppSettings.TestSet.DynamicData.Add("FI0007B_COSCEDCHEQUE", q3);

                #endregion

                #region R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1CONG_NOMECONG" , "Conglomerado XYZ" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0CHEQ_TPMOVTO" , "Débito" },
                { "V0CHEQ_FONTE" , "Banco Central" },
                { "V0CHEQ_NUMDOC" , "987654321" },
                { "V0CHEQ_NOMFAV" , "Empresa ABC" },
                { "V0CHEQ_VALCHQ" , "1500.00" },
                { "V0CHEQ_DTMOVTO" , "2023-12-15" },
                { "V0CHEQ_CHQINT" , "123456789" },
                { "V0CHEQ_DIGINT" , "1" },
                { "V0CHEQ_SITUACAO" , "Ativo" },
                { "V0CHEQ_TIPPAG" , "Transferência" },
                { "V0CHEQ_DATCMP" , "2023-12-01" },
                { "V0CHEQ_PRAPAG" , "2023-12-20" },
                { "V0CHEQ_NUMREC" , "12345" },
                { "V0CHEQ_OCORHIST" , "Histórico de operações" },
                { "V0CHEQ_OPERACAO" , "Operação de teste" },
                { "V0CHEQ_CODDSA" , "DSA123" },
                { "V0CHEQ_VALIRF" , "300.00" },
                { "V0CHEQ_VALISS" , "200.00" },
                { "V0CHEQ_VALIAP" , "100.00" },
                { "V0CHEQ_CODLAN" , "LAN001" },
                { "V0CHEQ_DATLAN" , "2023-12-15" },
                { "V0CHEQ_EMPRESA" , "Empresa ABC" },
                { "V0CHEQ_CODFAV" , "FAV001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1", q5);

                #endregion

                #region R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCHE_CHQINT" , "123456789" },
                { "V0HCHE_DIGINT" , "1" },
                { "V0HCHE_DTMOVTO" , "2023-12-15" },
                { "V0HCHE_HORAOPER" , "14:30" },
                { "V0HCHE_OPERACAO" , "Operação de teste" },
                { "V0HCHE_EMPRESA" , "Empresa ABC" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1", q6);

                #endregion

                #region R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_NRCHEQUE" , "987654321" },
                { "V0CCHQ_DVCHEQUE" , "1" },
                { "V1SIST_DTMOVABE_FI" , "2023-12-01" },
                { "V0CCHQ_COD_EMPR" , "001" },
                { "V0CCHQ_CONGENER" , "002" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q7);

                #endregion


      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new FI0007B();
                program.Execute();

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

        [Fact]
        public static void FI0007B_Tests_Fact_Return99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE


                #region R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE_FI" , "2023-12-01" }
                        }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NUM_CHQINT" , "123456789" }
                        }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1", q2);

                #endregion

                #region FI0007B_COSCEDCHEQUE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "001" },
                { "V0CCHQ_CONGENER" , "002" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-15" },
                { "V0CCHQ_VLPREMIO" , "1500.00" },
                { "V0CCHQ_VLRDESCON" , "50.00" },
                { "V0CCHQ_VLRADIFRA" , "90000.00" },
                { "V0CCHQ_VLRCOMIS" , "200.00" },
                { "V0CCHQ_VLRSINI" , "300.00" },
                { "V0CCHQ_VLDESPESA" , "400.00" },
                { "V0CCHQ_VLRHONOR" , "500.00" },
                { "V0CCHQ_VLRSALVD" , "600.00" },
                { "V0CCHQ_VLRESSARC" , "700.00" },
                { "V0CCHQ_VALOR_EDI" , "800.00" },
                { "V0CCHQ_VALOR_USS" , "900.00" },
                { "V0CCHQ_VLEQPVNDA" , "1000.00" },
                { "V0CCHQ_VLDESPADM" , "1100.00" },
                { "V0CCHQ_OUTRDEBIT" , "1200.00" },
                { "V0CCHQ_OUTRCREDT" , "1300.00" },
                { "V0CCHQ_VLRSLDANT" , "1400.00" },
                        }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("FI0007B_COSCEDCHEQUE");
                AppSettings.TestSet.DynamicData.Add("FI0007B_COSCEDCHEQUE", q3);

                #endregion

                #region R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1CONG_NOMECONG" , "Conglomerado XYZ" }
                        }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0CHEQ_TPMOVTO" , "Débito" },
                { "V0CHEQ_FONTE" , "Banco Central" },
                { "V0CHEQ_NUMDOC" , "987654321" },
                { "V0CHEQ_NOMFAV" , "Empresa ABC" },
                { "V0CHEQ_VALCHQ" , "1500.00" },
                { "V0CHEQ_DTMOVTO" , "2023-12-15" },
                { "V0CHEQ_CHQINT" , "123456789" },
                { "V0CHEQ_DIGINT" , "1" },
                { "V0CHEQ_SITUACAO" , "Ativo" },
                { "V0CHEQ_TIPPAG" , "Transferência" },
                { "V0CHEQ_DATCMP" , "2023-12-01" },
                { "V0CHEQ_PRAPAG" , "2023-12-20" },
                { "V0CHEQ_NUMREC" , "12345" },
                { "V0CHEQ_OCORHIST" , "Histórico de operações" },
                { "V0CHEQ_OPERACAO" , "Operação de teste" },
                { "V0CHEQ_CODDSA" , "DSA123" },
                { "V0CHEQ_VALIRF" , "300.00" },
                { "V0CHEQ_VALISS" , "200.00" },
                { "V0CHEQ_VALIAP" , "100.00" },
                { "V0CHEQ_CODLAN" , "LAN001" },
                { "V0CHEQ_DATLAN" , "2023-12-15" },
                { "V0CHEQ_EMPRESA" , "Empresa ABC" },
                { "V0CHEQ_CODFAV" , "FAV001" },
                        }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1", q5);

                #endregion

                #region R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCHE_CHQINT" , "123456789" },
                { "V0HCHE_DIGINT" , "1" },
                { "V0HCHE_DTMOVTO" , "2023-12-15" },
                { "V0HCHE_HORAOPER" , "14:30" },
                { "V0HCHE_OPERACAO" , "Operação de teste" },
                { "V0HCHE_EMPRESA" , "Empresa ABC" },
                        }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1", q6);

                #endregion

                #region R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_NRCHEQUE" , "987654321" },
                { "V0CCHQ_DVCHEQUE" , "1" },
                { "V1SIST_DTMOVABE_FI" , "2023-12-01" },
                { "V0CCHQ_COD_EMPR" , "001" },
                { "V0CCHQ_CONGENER" , "002" },
                        }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q7);

                #endregion


                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new FI0007B();
                program.Execute();

                Assert.True(program.RETURN_CODE != 00);

            }
        }
    }
}