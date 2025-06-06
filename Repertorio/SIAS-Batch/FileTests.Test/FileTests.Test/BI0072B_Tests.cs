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
using static Code.BI0072B;

namespace FileTests.Test
{
    [Collection("BI0072B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0072B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA S.A.                                                                                                               "}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region BI0072B_V0PRODUTO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI0072B_V0PRODUTO", q2);

            #endregion

            #region BI0072B_V0MOVIMCOB

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "WSHOST_DATA_INIVIGENCIA" , ""},
                { "WSHOST_DATA_TERVIGENCIA" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0072B_V0MOVIMCOB", q3);

            #endregion

            #region BI0072B_V0PARC

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_NRENDOS1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI0072B_V0PARC", q4);

            #endregion

            #region R1000_50_SAIDA_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_50_SAIDA_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PRFD_NUMPROPOSTA" , ""},
                { "V0PRFD_CODPROD" , ""},
                { "V0PRFD_NUMSICOB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1060_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PRFD_NUMPROPOSTA" , ""},
                { "V0PRFD_CODPROD" , ""},
                { "V0PRFD_NUMSICOB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V0BILH_NUMAPOL" , ""},
                { "V0BILH_CODCLIEN" , ""},
                { "V0BILH_AGECOBR" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0BILH_OPCAO_COB" , ""},
                { "V0BILH_NRMATRVEN" , ""},
                { "V0BILH_AGECTAVEN" , ""},
                { "V0BILH_OPRCTAVEN" , ""},
                { "V0BILH_NUMCTAVEN" , ""},
                { "V0BILH_DIGCTAVEN" , ""},
                { "V0BILH_AGECTADEB" , ""},
                { "V0BILH_OPRCTADEB" , ""},
                { "V0BILH_NUMCTADEB" , ""},
                { "V0BILH_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_SIT_COBRANCA" , ""},
                { "V1MVDB_COD_CONVENIO" , ""},
                { "V1MVDB_NUM_APOLICE" , ""},
                { "V1MVDB_NRPARCEL" , ""},
                { "V1MVDB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_NUM_APOLICE" , ""},
                { "V1MVDB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOLICE" , ""},
                { "V0PARC_NUM_ENDOSSO" , ""},
                { "V0PARC_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "NUMERAES_ENDOS_CANCELA" , ""},
                { "V0PCHS_NUM_APOLICE" , ""},
                { "V0PCHS_NUM_ENDOSSO" , ""},
                { "V0PCHS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_NUM_APOLICE" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANCELA" , ""},
                { "NUMERAES_ORGAO_EMISSOR" , ""},
                { "NUMERAES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_VLR_DEBITO" , ""},
                { "V1MVDB_DTCREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1", q17);

            #endregion

            #region R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_VLR_DEBITO" , ""},
                { "V1MVDB_DTCREDITO" , ""},
                { "V1MVDB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2_Query1", q18);

            #endregion

            #region R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_DTCREDITO" , ""},
                { "VIND_DTCREDITO" , ""},
                { "V1MVDB_SEQUENCIA" , ""},
                { "VIND_SEQUENCIA" , ""},
                { "V1MVDB_NUM_LOTE" , ""},
                { "VIND_NUM_LOTE" , ""},
                { "V1MVDB_SIT_COBRANCA" , ""},
                { "V1MVDB_COD_RET_CEF" , ""},
                { "V1MVDB_VLR_CREDITO" , ""},
                { "V1MVDB_DTRETORNO" , ""},
                { "V1MVDB_DTMOVTO" , ""},
                { "V1MVDB_COD_CONVENIO" , ""},
                { "V1MVDB_NUM_APOLICE" , ""},
                { "V1MVDB_NRPARCEL" , ""},
                { "V1MVDB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R3462_00_UPDATE_BILHETE_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0PRFD_NUMSICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3462_00_UPDATE_BILHETE_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WS_QTDBIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1", q21);

            #endregion

            #region R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0FOLL_NUMAPOL" , ""},
                { "V0FOLL_NRENDOS" , ""},
                { "V0FOLL_NRPARCEL" , ""},
                { "V0FOLL_DACPARC" , ""},
                { "V0FOLL_DTMOVTO" , ""},
                { "V0FOLL_HORAOPER" , ""},
                { "V0FOLL_VLPREMIO" , ""},
                { "V0FOLL_BCOAVISO" , ""},
                { "V0FOLL_AGEAVISO" , ""},
                { "V0FOLL_NRAVISO" , ""},
                { "V0FOLL_CODBAIXA" , ""},
                { "V0FOLL_CDERRO01" , ""},
                { "V0FOLL_CDERRO02" , ""},
                { "V0FOLL_CDERRO03" , ""},
                { "V0FOLL_CDERRO04" , ""},
                { "V0FOLL_CDERRO05" , ""},
                { "V0FOLL_CDERRO06" , ""},
                { "V0FOLL_SITUACAO" , ""},
                { "V0FOLL_SITCONTB" , ""},
                { "V0FOLL_OPERACAO" , ""},
                { "V0FOLL_DTLIBER" , ""},
                { "V0FOLL_DTQITBCO" , ""},
                { "V0FOLL_CODEMP" , ""},
                { "V0FOLL_ORDLIDER" , ""},
                { "V0FOLL_TIPSGU" , ""},
                { "V0FOLL_APOLIDER" , ""},
                { "V0FOLL_ENDOSLID" , ""},
                { "V0FOLL_CODLIDER" , ""},
                { "V0FOLL_FONTE" , ""},
                { "V0FOLL_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1", q22);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RBI0072B_FILE_NAME_P")]
        public static void BI0072B_Tests_Theory(string RBI0072B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RBI0072B_FILE_NAME_P = $"{RBI0072B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {

                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("BI0072B_V0MOVIMCOB");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "WSHOST_DATA_INIVIGENCIA" , ""},
                { "WSHOST_DATA_TERVIGENCIA" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , "02"},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("BI0072B_V0MOVIMCOB", q3);

                #endregion
                var program = new BI0072B();
                program.Execute(RBI0072B_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R1000_50_SAIDA_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);

                Assert.True(envList[1].TryGetValue("MOVIMCOB_SIT_REGISTRO", out string valor) && valor == "1");
                Assert.True(envList1[1].TryGetValue("V0BILH_SITUACAO", out valor) && valor == "8");
                Assert.True(envList2[1].TryGetValue("V1MVDB_SIT_COBRANCA", out valor) && valor == "6");
                Assert.True(envList3[1].TryGetValue("V1MVDB_NUM_APOLICE", out valor) && valor == "0000000000000");
                Assert.True(envList4[1].TryGetValue("V0PARC_NUM_APOLICE", out valor) && valor == "0000000000000");
                Assert.True(envList5[1].TryGetValue("NUMERAES_ENDOS_CANCELA", out valor) && valor == "000000001");
                Assert.True(envList6[1].TryGetValue("NUMERAES_ENDOS_CANCELA", out valor) && valor == "000000001");
                Assert.True(envList7[1].TryGetValue("V1MVDB_COD_CONVENIO", out valor) && valor == "000102837");
            }
        }
    }
}