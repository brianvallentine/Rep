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
using static Code.EM0229B;

namespace FileTests.Test
{
    [Collection("EM0229B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0229B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PARR_RAMO_VG" , ""},
                { "V1PARR_RAMO_AP" , ""},
                { "V1PARR_RAMO_VGAPC" , ""},
                { "V1PARR_RAMO_SAUDE" , ""},
                { "V1PARR_RAMO_EDUCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q1);

            #endregion

            #region EM0229B_V1EMIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EDIA_NUMAPOL" , ""},
                { "V1EDIA_NRENDOS" , ""},
                { "V1EDIA_NRPARCEL" , ""},
                { "V1EDIA_CODRELAT" , ""},
                { "V1EDIA_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0229B_V1EMIS", q2);

            #endregion

            #region EM0229B_V1PARCELA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRTIT" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_OTNTOTAL" , ""},
                { "V0PARC_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0229B_V1PARCELA", q3);

            #endregion

            #region R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_IDLG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUMAPOL" , ""},
                { "V1ENDO_NRENDOS" , ""},
                { "V1ENDO_FONTE" , ""},
                { "V1ENDO_NRPROPOS" , ""},
                { "V1ENDO_QTPARCEL" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CORRECAO" , ""},
                { "V1ENDO_CODUNIMO" , ""},
                { "V1ENDO_CODCLIEN" , ""},
                { "V1ENDO_OCORR_END" , ""},
                { "V1ENDO_CODSUBES" , ""},
                { "V1ENDO_CODPRODU" , ""},
                { "V1ENDO_TIPAPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q5);

            #endregion

            #region EM0229B_V1RELATORIOS

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_NUM_APOL" , ""},
                { "V1RELA_NRENDOS" , ""},
                { "V1RELA_NRPARCEL" , ""},
                { "V1RELA_DTSOLIC" , ""},
                { "V1RELA_ORGAO" , ""},
                { "V1RELA_RAMO" , ""},
                { "V1RELA_FONTE" , ""},
                { "V1RELA_CONGENER" , ""},
                { "V1RELA_CODPDT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0229B_V1RELATORIOS", q6);

            #endregion

            #region R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0TOMA_CODCLIEN" , ""},
                { "V0TOMA_OCORR_END" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1SUBG_CODCLIEN" , ""},
                { "V1SUBG_OCORR_END" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0ESIC_NRTIT" , ""},
                { "V0ESIC_CODCDT" , ""},
                { "V0ESIC_NUMAPOL" , ""},
                { "V0ESIC_NRENDOS" , ""},
                { "V0ESIC_NRCERTIF" , ""},
                { "V0ESIC_FONTE" , ""},
                { "V0ESIC_NRPROPOS" , ""},
                { "V0ESIC_NRCARNE" , ""},
                { "V0ESIC_NRPARCEL" , ""},
                { "V0ESIC_QTPARCEL" , ""},
                { "V0ESIC_DTVENCTO" , ""},
                { "V0ESIC_NRDOCTO" , ""},
                { "V0ESIC_DTDOCTO" , ""},
                { "V0ESIC_CORRECAO" , ""},
                { "V0ESIC_CODUNIMO" , ""},
                { "V0ESIC_VL_PRM_IX" , ""},
                { "V0ESIC_VL_PRM_VAR" , ""},
                { "V0ESIC_RECVENCTO" , ""},
                { "V0ESIC_IOFINCLUSO" , ""},
                { "V0ESIC_RECIOF" , ""},
                { "V0ESIC_CODCLIEN" , ""},
                { "V0ESIC_OCORR_END" , ""},
                { "V0ESIC_CODPRODU" , ""},
                { "V0ESIC_CODPGM" , ""},
                { "V0ESIC_CODMENS" , ""},
                { "V0ESIC_SITUACAO" , ""},
                { "V0ESIC_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1", q9);

            #endregion

            #region S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1EDIA_CODRELAT" , ""},
                { "V1EDIA_NUMAPOL" , ""},
                { "V1EDIA_NRENDOS" , ""},
                { "V1EDIA_NRPARCEL" , ""},
                { "V1EDIA_DTMOVTO" , ""},
                { "V1EDIA_ORGAO" , ""},
                { "V1EDIA_RAMO" , ""},
                { "V1EDIA_FONTE" , ""},
                { "V1EDIA_CONGENER" , ""},
                { "V1EDIA_CODCORR" , ""},
                { "V1EDIA_SITUACAO" , ""},
                { "V1EDIA_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1", q10);

            #endregion

            #region S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

            #endregion

            #endregion
        }


        [Fact]
        public static void EM0229B_Tests_Fact()
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

                AppSettings.TestSet.DynamicData.Remove("EM0229B_V1EMIS");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1EDIA_NUMAPOL" , ""},
                { "V1EDIA_NRENDOS" , ""},
                { "V1EDIA_NRPARCEL" , ""},
                { "V1EDIA_CODRELAT" , ""},
                { "V1EDIA_RAMO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("EM0229B_V1EMIS", q2);

                AppSettings.TestSet.DynamicData.Remove("R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1", q4);

                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                var q5 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUMAPOL" , ""},
                { "V1ENDO_NRENDOS" , ""},
                { "V1ENDO_FONTE" , ""},
                { "V1ENDO_NRPROPOS" , ""},
                { "V1ENDO_QTPARCEL" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CORRECAO" , "1"},
                { "V1ENDO_CODUNIMO" , ""},
                { "V1ENDO_CODCLIEN" , ""},
                { "V1ENDO_OCORR_END" , ""},
                { "V1ENDO_CODSUBES" , ""},
                { "V1ENDO_CODPRODU" , ""},
                { "V1ENDO_TIPAPO" , "5"},
                });
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q5);

                AppSettings.TestSet.DynamicData.Remove("EM0229B_V1PARCELA");
                var q3 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRTIT" , "5500000000001"},
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_OTNTOTAL" , ""},
                { "V0PARC_VLPRMTOT" , "1"},
                });
                AppSettings.TestSet.DynamicData.Add("EM0229B_V1PARCELA", q3);

                #endregion
                var program = new EM0229B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("V1EDIA_CODRELAT", out string valor) && valor == "EM0230B2");
                Assert.True(envList[1].TryGetValue("V1EDIA_NUMAPOL", out valor) && valor == "0000000000000");

            }
        }
    }
}