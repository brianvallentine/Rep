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
using static Code.BI0003S;

namespace FileTests.Test
{
    [Collection("BI0003S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0003S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1", q1);

            #endregion

            #region M_31000_00_INS_PESSOA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_31000_00_INS_PESSOA_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_USUARIO" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1", q3);

            #endregion

            #region M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""},
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "COD_USUARIO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "ORGAO_EXPEDIDOR" , ""},
                { "UF_EXPEDIDORA" , ""},
                { "DATA_EXPEDICAO" , ""},
                { "COD_CBO" , ""},
                { "TIPO_IDENT_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1", q4);

            #endregion

            #region M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1", q5);

            #endregion

            #region M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIDADE" , ""},
                { "ORGAO_EXPEDIDOR" , ""},
                { "UF_EXPEDIDORA" , ""},
                { "DATA_EXPEDICAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ORGAO_EXPEDIDOR" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "DATA_EXPEDICAO" , ""},
                { "UF_EXPEDIDORA" , ""},
                { "WS_COD_PES_ATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1", q7);

            #endregion

            #region M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1", q9);

            #endregion

            #region M_51000_00_GRAVA_TELEFONE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_51000_00_GRAVA_TELEFONE_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""},
                { "IND_TEL" , ""},
                { "WS_MAX_SEQ_TEL" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1", q11);

            #endregion

            #region M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_EMA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1", q13);

            #endregion

            #region M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""},
                { "WS_MAX_SEQ_EMA" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1", q14);

            #endregion

            #region M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CEP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1", q16);

            #endregion

            #region M_91000_00_INS_ENDERECO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_91000_00_INS_ENDERECO_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""},
                { "WS_MAX_OCO_END" , ""},
                { "ENDERECO" , ""},
                { "TIPO_ENDER" , ""},
                { "BAIRRO" , ""},
                { "CEP" , ""},
                { "CIDADE" , ""},
                { "SIGLA_UF" , ""},
                { "SITUACAO_ENDERECO" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1", q18);

            #endregion

            #region B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1", q19);

            #endregion

            #region B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "CEP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1", q20);

            #endregion

            #region B1000_00_INS_ENDERECO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B1000_00_INS_ENDERECO_DB_SELECT_1_Query1", q21);

            #endregion

            #region B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , ""},
                { "WS_MAX_OCO_END" , ""},
                { "ENDERECO" , ""},
                { "TIPO_ENDER" , ""},
                { "BAIRRO" , ""},
                { "CEP" , ""},
                { "CIDADE" , ""},
                { "SIGLA_UF" , ""},
                { "SITUACAO_ENDERECO" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1", q22);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI0003S_Tests_Fact_Erro999()
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

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{ });
                AppSettings.TestSet.DynamicData.Remove("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion

                var program = new BI0003S();
                var parm = new BI0003S_BI0003L_LINKAGE();

                parm.BI0003L_E_PESSOA.BI0003L_E_TIP_PES.Value = 1;
                parm.BI0003L_E_PESSOA.BI0003L_E_NOM_PES.Value = "Teste";
                parm.BI0003L_E_FISICA.BI0003L_E_NUM_CPF.Value = 1;

                program.Execute(parm);

                Assert.True(program.BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR == 999);
                Assert.True(program.WS_WORKING.WS_AUXILIARES.WS_SQLCODE == 999);
            }
        }

        [Fact]
        public static void BI0003S_Tests_Fact_InsertPF()
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
                var program = new BI0003S();
                var parm = new BI0003S_BI0003L_LINKAGE();

                parm.BI0003L_E_PESSOA.BI0003L_E_TIP_PES.Value = 1;
                parm.BI0003L_E_PESSOA.BI0003L_E_NOM_PES.Value = "Teste Insert PF";
                parm.BI0003L_E_FISICA.BI0003L_E_NUM_CPF.Value = 1;
                parm.BI0003L_E_TELEFONE[1].BI0003L_E_DDI.Value = 55;
                parm.BI0003L_E_TELEFONE[1].BI0003L_E_DDD.Value = 11;
                parm.BI0003L_E_TELEFONE[1].BI0003L_E_NUM_FON.Value = 40000000;
                parm.BI0003L_E_EMAIL.BI0003L_E_LIT_EMA.Value = "contato@foursys.com.br";
                parm.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_END_F.Value = "Rua PF";
                parm.BI0003L_E_ENDERECO_FIS.BI0003L_E_COD_CEP_F.Value = 1001;
                parm.BI0003L_E_FISICA.BI0003L_E_DAT_NAS.Value = "2000-01-01";

                program.Execute(parm);

                //M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PESSOA_NOME_PESSOA", out var valor) && valor.Contains("Teste"));
                Assert.True(envList.Count > 1);

                //M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("DATA_NASCIMENTO", out var valor2) && valor2.Contains("2000-01-01"));
                Assert.True(envList2.Count > 1);

                //M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1"].DynamicList;
                //Assert.True(envList4[1].TryGetValue("VG097_COD_PRODUTO", out var valor4) && valor4.Contains("7732"));
                //Assert.True(envList4.Count > 1);

                //M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("DDD", out var valor5) && valor5.Contains("11"));
                Assert.True(envList5.Count > 1);

                //M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("EMAIL", out var valor6) && valor6.Contains("contato@foursys.com.br"));
                Assert.True(envList6.Count > 1);

                //M_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["M_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("ENDERECO", out var valor7) && valor7.Contains("Rua PF"));
                Assert.True(envList7.Count > 1);

                Assert.True(program.WS_WORKING.WS_AUXILIARES.WS_SQLCODE == 00);
                Assert.True(program.BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR == 0);
            }
        }

        [Fact]
        public static void BI0003S_Tests_Fact_InsertPJ()
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
                var program = new BI0003S();
                var parm = new BI0003S_BI0003L_LINKAGE();

                parm.BI0003L_E_PESSOA.BI0003L_E_TIP_PES.Value = 2;
                parm.BI0003L_E_PESSOA.BI0003L_E_NOM_PES.Value = "Teste Insert PJ";
                parm.BI0003L_E_JURIDICA.BI0003L_E_NOM_FAN.Value = "Teste Insert PJ";
                parm.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC.Value = 1;
                parm.BI0003L_E_TELEFONE[1].BI0003L_E_DDI.Value = 55;
                parm.BI0003L_E_TELEFONE[1].BI0003L_E_DDD.Value = 11;
                parm.BI0003L_E_TELEFONE[1].BI0003L_E_NUM_FON.Value = 40000000;
                parm.BI0003L_E_EMAIL.BI0003L_E_LIT_EMA.Value = "contato@foursys.com.br";
                parm.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_END_J.Value = "Rua PJ";
                parm.BI0003L_E_ENDERECO_JUR.BI0003L_E_COD_CEP_J.Value = 1002;


                program.Execute(parm);

                //M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PESSOA_NOME_PESSOA", out var valor) && valor.Contains("Teste Insert PJ"));
                Assert.True(envList.Count > 1);

                //M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("NOME_FANTASIA", out var valor3) && valor3.Contains("Teste Insert PJ"));
                Assert.True(envList3.Count > 1);

                //M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1"].DynamicList;
                //Assert.True(envList4[1].TryGetValue("VG097_COD_PRODUTO", out var valor4) && valor4.Contains("7732"));
                //Assert.True(envList4.Count > 1);

                //M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("DDD", out var valor5) && valor5.Contains("11"));
                Assert.True(envList5.Count > 1);

                //M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("EMAIL", out var valor6) && valor6.Contains("contato@foursys.com.br"));
                Assert.True(envList6.Count > 1);

                //B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1
                var envList8 = AppSettings.TestSet.DynamicData["B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("ENDERECO", out var valor8) && valor8.Contains("Rua PJ"));
                Assert.True(envList8.Count > 1);

                Assert.True(program.WS_WORKING.WS_AUXILIARES.WS_SQLCODE == 00);
                Assert.True(program.BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR == 0);
            }
        }

        [Fact]
        public static void BI0003S_Tests_Fact_UpdatePF()
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

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_ATU" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new BI0003S();
                var parm = new BI0003S_BI0003L_LINKAGE();

                parm.BI0003L_E_PESSOA.BI0003L_E_TIP_PES.Value = 1;
                parm.BI0003L_E_PESSOA.BI0003L_E_NOM_PES.Value = "Teste Insert PF";
                parm.BI0003L_E_FISICA.BI0003L_E_NUM_CPF.Value = 1;
                parm.BI0003L_E_TELEFONE[0].BI0003L_E_DDI.Value = 55;
                parm.BI0003L_E_TELEFONE[0].BI0003L_E_DDD.Value = 11;
                parm.BI0003L_E_TELEFONE[0].BI0003L_E_NUM_FON.Value = 40000000;
                parm.BI0003L_E_EMAIL.BI0003L_E_LIT_EMA.Value = "contato@foursys.com.br";
                parm.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_END_F.Value = "Rua PF";
                parm.BI0003L_E_ENDERECO_FIS.BI0003L_E_COD_CEP_F.Value = 1001;
                parm.BI0003L_E_FISICA.BI0003L_E_DAT_NAS.Value = "2000-01-01";

                program.Execute(parm);

                //M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("UF_EXPEDIDORA", out var valor4) && valor4.Contains("NI"));
                Assert.True(envList4.Count > 1);

                Assert.True(program.WS_WORKING.WS_AUXILIARES.WS_SQLCODE == 00);
                Assert.True(program.BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR == 0);
            }
        }
    }
}