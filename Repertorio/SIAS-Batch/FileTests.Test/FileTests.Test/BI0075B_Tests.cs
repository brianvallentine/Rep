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
using static Code.BI0075B;

namespace FileTests.Test
{
    [Collection("BI0075B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0075B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
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
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region BI0075B_V0PRODUTO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI0075B_V0PRODUTO", q2);

            #endregion

            #region BI0075B_V0MOVDE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_COD_CONVENIO" , ""},
                { "V1MVDB_DTVENCTO" , ""},
                { "V1MVDB_DTCREDITO" , ""},
                { "V1MVDB_VLR_DEBITO" , ""},
                { "V1MVDB_VLR_CREDITO" , ""},
                { "V1MVDB_NUM_APOLICE" , ""},
                { "V1MVDB_NRENDOS" , ""},
                { "V1MVDB_SEQUENCIA" , ""},
                { "V1MVDB_NUM_LOTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0075B_V0MOVDE", q3);

            #endregion

            #region R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PRFD_NUMPROPOSTA" , ""},
                { "V0PRFD_CODPROD" , ""},
                { "V0PRFD_NUMSICOB" , ""},
                { "V0PRFD_ORIGEM_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1170_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1170_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_SIT_COBRANCA" , ""},
                { "V1MVDB_COD_CONVENIO" , ""},
                { "V1MVDB_NUM_APOLICE" , ""},
                { "V1MVDB_NRPARCEL" , ""},
                { "V1MVDB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_NUM_APOLICE" , ""},
                { "V1MVDB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0AVIS_NRAVISO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0AVIS_BCOAVISO" , ""},
                { "V0AVIS_AGEAVISO" , ""},
                { "V0AVIS_NRAVISO" , ""},
                { "V0AVIS_NRSEQ" , ""},
                { "V0AVIS_DTMOVTO" , ""},
                { "V0AVIS_OPERACAO" , ""},
                { "V0AVIS_TIPAVI" , ""},
                { "V0AVIS_DTAVISO" , ""},
                { "V0AVIS_VLIOCC" , ""},
                { "V0AVIS_VLDESPES" , ""},
                { "V0AVIS_PRECED" , ""},
                { "V0AVIS_VLPRMLIQ" , ""},
                { "V0AVIS_VLPRMTOT" , ""},
                { "V0AVIS_SITCONTB" , ""},
                { "V0AVIS_COD_EMPRESA" , ""},
                { "V0AVIS_ORIGAVISO" , ""},
                { "V0AVIS_VALADT" , ""},
                { "V0AVIS_SITDEPTER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0AVSD_COD_EMPRESA" , ""},
                { "V0AVSD_BCOAVISO" , ""},
                { "V0AVSD_AGEAVISO" , ""},
                { "V0AVSD_TIPSGU" , ""},
                { "V0AVSD_NRAVISO" , ""},
                { "V0AVSD_DTAVISO" , ""},
                { "V0AVSD_DTMOVTO" , ""},
                { "V0AVSD_SDOATU" , ""},
                { "V0AVSD_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_SIT_COBRANCA" , ""},
                { "V0AVIS_NRAVISO" , ""},
                { "V1MVDB_COD_CONVENIO" , ""},
                { "V1MVDB_NUM_APOLICE" , ""},
                { "V1MVDB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WS_QTDBIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1", q14);

            #endregion

            #region R3500_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0MCOB_CODEMP" , ""},
                { "V0MCOB_CODMOV" , ""},
                { "V0MCOB_BANCO" , ""},
                { "V0MCOB_AGENCIA" , ""},
                { "V0MCOB_NRAVISO" , ""},
                { "V0MCOB_NUMFITA" , ""},
                { "V0MCOB_DTMOVTO" , ""},
                { "V0MCOB_DTQITBCO" , ""},
                { "V0MCOB_NRTIT" , ""},
                { "V0MCOB_NUMAPOL" , ""},
                { "V0MCOB_NRENDOS" , ""},
                { "V0MCOB_NRPARCEL" , ""},
                { "V0MCOB_VALTIT" , ""},
                { "V0MCOB_VLIOCC" , ""},
                { "V0MCOB_VALCDT" , ""},
                { "V0MCOB_SITUACAO" , ""},
                { "V0MCOB_NOME" , ""},
                { "V0MCOB_TIPOMOV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0COMI_NUMAPOL" , ""},
                { "V0COMI_NRENDOS" , ""},
                { "V0COMI_NRCERTIF" , ""},
                { "V0COMI_DIGCERT" , ""},
                { "V0COMI_IDTPSEGU" , ""},
                { "V0COMI_NRPARCEL" , ""},
                { "V0COMI_OPERACAO" , ""},
                { "V0COMI_CODPDT" , ""},
                { "V0COMI_RAMOFR" , ""},
                { "V0COMI_MODALIFR" , ""},
                { "V0COMI_OCORHIST" , ""},
                { "V0COMI_FONTE" , ""},
                { "V0COMI_CODCLIEN" , ""},
                { "V0COMI_VLCOMIS" , ""},
                { "V0COMI_DATCLO" , ""},
                { "V0COMI_NUMREC" , ""},
                { "V0COMI_VALBAS" , ""},
                { "V0COMI_TIPCOM" , ""},
                { "V0COMI_QTPARCEL" , ""},
                { "V0COMI_PCCOMCOR" , ""},
                { "V0COMI_PCDESCON" , ""},
                { "V0COMI_CODSUBES" , ""},
                { "V0COMI_DTMOVTO" , ""},
                { "V0COMI_DATSEL" , ""},
                { "V0COMI_CODEMP" , ""},
                { "V0COMI_CODPRP" , ""},
                { "V0COMI_NUMBIL" , ""},
                { "V0COMI_VLVARMON" , ""},
                { "V0COMI_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_VAL_MAX_COBER_BAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1", q17);

            #endregion

            #region R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "PARAMGER_COD_EMPRESA_CAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q20);

            #endregion

            #region R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0DPCF_CODEMP" , ""},
                { "V0DPCF_ANOREF" , ""},
                { "V0DPCF_MESREF" , ""},
                { "V0DPCF_BCOAVISO" , ""},
                { "V0DPCF_AGEAVISO" , ""},
                { "V0DPCF_NRAVISO" , ""},
                { "V0DPCF_CODPRODU" , ""},
                { "V0DPCF_TIPOREG" , ""},
                { "V0DPCF_SITUACAO" , ""},
                { "V0DPCF_TIPOCOB" , ""},
                { "V0DPCF_DTMOVTO" , ""},
                { "V0DPCF_DTAVISO" , ""},
                { "V0DPCF_QTDREG" , ""},
                { "V0DPCF_VLPRMTOT" , ""},
                { "V0DPCF_VLPRMLIQ" , ""},
                { "V0DPCF_VLTARIFA" , ""},
                { "V0DPCF_VLBALCAO" , ""},
                { "V0DPCF_VLIOCC" , ""},
                { "V0DPCF_VLDESCON" , ""},
                { "V0DPCF_VLJUROS" , ""},
                { "V0DPCF_VLMULTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q21);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI0075B_Tests_Fact()
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

                AppSettings.TestSet.DynamicData.Remove("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA S.A.                   "}
                });
                AppSettings.TestSet.DynamicData.Add("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q1);

                AppSettings.TestSet.DynamicData.Remove("BI0075B_V0MOVDE");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1MVDB_COD_CONVENIO" , ""},
                { "V1MVDB_DTVENCTO" , ""},
                { "V1MVDB_DTCREDITO" , ""},
                { "V1MVDB_VLR_DEBITO" , ""},
                { "V1MVDB_VLR_CREDITO" , ""},
                { "V1MVDB_NUM_APOLICE" , ""},
                { "V1MVDB_NRENDOS" , "15"},
                { "V1MVDB_SEQUENCIA" , ""},
                { "V1MVDB_NUM_LOTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("BI0075B_V0MOVDE", q3);

                AppSettings.TestSet.DynamicData.Remove("R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1");
                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_VAL_MAX_COBER_BAS" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1", q17);

                #endregion
                var program = new BI0075B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                var envList2 = AppSettings.TestSet.DynamicData["R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);

                var envList3 = AppSettings.TestSet.DynamicData["R3500_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);

                var envList4 = AppSettings.TestSet.DynamicData["R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4?.Count > 1);

                var envList5 = AppSettings.TestSet.DynamicData["R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5?.Count > 1);

                var envList6 = AppSettings.TestSet.DynamicData["R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0AVIS_BCOAVISO", out string valor) && valor == "0104");
                Assert.True(envList1[1].TryGetValue("V0AVSD_AGEAVISO", out valor) && valor == "9777");
                Assert.True(envList2[1].TryGetValue("V1MVDB_SIT_COBRANCA", out valor) && valor.Equals("2"));
                Assert.True(envList3[1].TryGetValue("V0MCOB_NRAVISO", out valor) && valor.Equals("902800001"));
                Assert.True(envList4[1].TryGetValue("V0BILH_NUMBIL", out valor) && valor.Equals("000000000000000"));
                Assert.True(envList5[1].TryGetValue("RELATORI_COD_RELATORIO", out valor) && valor.Equals("BI0075B1"));
                Assert.True(envList6[1].TryGetValue("V0DPCF_VLTARIFA", out valor) && valor.Equals("0000000000000.80"));
            }
        }
    }
}