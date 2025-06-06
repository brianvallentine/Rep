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
using static Code.VG9550B;
using Sias.VidaEmGrupo.DB2.VG9550B;

namespace FileTests.Test
{
    [Collection("VG9550B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG9550B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1
            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-10"}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG9550B_CCURSOR

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                 { "SEGURVGA_TIPO_INCLUSAO" , "1"},
                { "SEGURVGA_COD_AGENCIADOR" , "1"},
                { "SEGURVGA_NUM_ITEM" , "1"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
                { "SEGURVGA_NUM_APOLICE" , "1"},
                { "SEGURVGA_COD_SUBGRUPO" , "6"},
                { "SEGURVGA_NUM_CERTIFICADO" , "1234567"},
                { "SEGURVGA_COD_FONTE" , "99"},
                { "SEGURVGA_SIT_REGISTRO" , "2"},
                { "SEGURVGA_COD_CLIENTE" , "876"},
                { "SEGURVGA_NUM_MATRICULA" , "0000999"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "2024-10-11"},
                { "SEGURVGA_NATURALIDADE" , "SÃO PAULO"},
                { "SEGURVGA_OCORR_ENDERECO" , "6"},
                { "SEGURVGA_TIPO_SEGURADO" , "6"},
            });
            AppSettings.TestSet.DynamicData.Add("VG9550B_CCURSOR", q1);

            #endregion

            #region VG9550B_CENDSBG

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "81010000001"},
                { "PROPOVA_COD_SUBGRUPO" , "12"},
                { "PROPOVA_NUM_CERTIFICADO" , "10026748673"},
                { "PROPOVA_COD_CLIENTE" , "37190090"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                { "PROPOVA_OCOREND" , "1"},
                { "ENDERECO_ENDERECO" , "RUA ABC"},
                { "ENDERECO_BAIRRO" , "JARDIM PAULISTA"},
                { "ENDERECO_CIDADE" , "SÃO PAULO"},
                { "ENDERECO_SIGLA_UF" , "SP"},
                { "ENDERECO_CEP" , "1455905"},
                { "ENDERECO_DDD" , "11"},
                { "ENDERECO_TELEFONE" , "1133334444"},
                { "ENDERECO_FAX" , "0"},
                { "ENDERECO_TELEX" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("VG9550B_CENDSBG", q2);

            #endregion

            #region R0040_00_VERIFICA_APOLICE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , "1"},
                { "PARAMRAM_RAMO_VG" , "2"},
                { "PARAMRAM_RAMO_AP" , "3"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "4"},
            });
            AppSettings.TestSet.DynamicData.Add("R0040_00_VERIFICA_APOLICE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0060_00_CANCELA_SEGURO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , "1.2"},
                { "V0COBA_PRMVG" , "1.3"},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_CANCELA_SEGURO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0060_10_CONTINUA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_10_CONTINUA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0060_10_CONTINUA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , "2"},
                { "SEGURVGA_COD_FONTE" , "4"},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_10_CONTINUA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0060_10_CONTINUA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
               { "SEGURVGA_NUM_APOLICE" , "1"},
                { "SEGURVGA_COD_SUBGRUPO" , "3"},
                { "SEGURVGA_COD_FONTE" , "1"},
                { "FONTES_ULT_PROP_AUTOMAT" , "1"},
                { "SEGURVGA_TIPO_SEGURADO" , "2"},
                { "SEGURVGA_NUM_CERTIFICADO" , "123"},
                { "SEGURVGA_TIPO_INCLUSAO" , "3"},
                { "SEGURVGA_COD_CLIENTE" , "78787"},
                { "SEGURVGA_COD_AGENCIADOR" , "5"},
                { "MOVIMVGA_PERI_PAGAMENTO" , "2024-04-04"},
                { "SEGURVGA_NATURALIDADE" , "SÃO PAULO"},
                { "SEGURVGA_OCORR_ENDERECO" , "3"},
                { "CONTACOR_COD_AGENCIA" , "0001"},
                { "SEGURVGA_NUM_MATRICULA" , "986756756"},
                { "CONTACOR_NUM_CTA_CORRENTE" , "123456"},
                { "CONTACOR_DAC_CTA_CORRENTE" , "1"},
                { "V0COBA_IMPMORNATU" , "1.2"},
                { "V0COBA_IMPMORACID" , "2.2"},
                { "V0COBA_IMPINVPERM" , "3.3"},
                { "V0COBA_IMPDIT" , "1.1"},
                { "V0COBA_PRMVG" , "123.23"},
                { "V0COBA_PRMAP" , "124.55"},
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-11-11"},
                { "MOVIMVGA_DATA_OPERACAO" , "2024-10-10"},
                { "DATA_REFERENCIA" , "2024-01-01"},
                { "MOVIMVGA_DATA_MOVIMENTO" , "2024-02-02"},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_10_CONTINUA_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R0060_00_CANCELA_SEGURO_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , "2"},
                { "V0COBA_PRMAP" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_CANCELA_SEGURO_DB_SELECT_2_Query1", q8);

            #endregion

            #region R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , "2.3"}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1", q9);

            #endregion

            #region R0060_00_CANCELA_SEGURO_DB_SELECT_4_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , "3.3"}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_CANCELA_SEGURO_DB_SELECT_4_Query1", q10);

            #endregion

            #region R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                 { "CONTACOR_COD_AGENCIA" , "1"},
                { "CONTACOR_NUM_CTA_CORRENTE" , "145452"},
                { "CONTACOR_DAC_CTA_CORRENTE" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1", q11);

            #endregion

            # region R0060_00_CANCELA_SEGURO_DB_SELECT_6_Query1
            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                 { "FONTES_ULT_PROP_AUTOMAT" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_CANCELA_SEGURO_DB_SELECT_6_Query1", q19);
            # endregion 
            #region VG9550B_CSEGURD

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "81010000001"},
                { "SEGURVGA_COD_SUBGRUPO" , "13"},
                { "SEGURVGA_NUM_CERTIFICADO" , "10026748673"},
                { "SEGURVGA_COD_CLIENTE" , "37190090"},
                { "SEGURVGA_OCORR_ENDERECO" , "RUA ABC"},
                { "SEGURVGA_OCORR_END_COBRAN" , "RUA XYZ"},
            });
            AppSettings.TestSet.DynamicData.Add("VG9550B_CSEGURD", q12);

            #endregion

            #region R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_CLIENTE" , "37190090"},
                { "PROPOVA_OCOREND" , "X"},
            });
            AppSettings.TestSet.DynamicData.Add("R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCOREND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "WS_MAX_OCOREND" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCOREND" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1", q16);

            #endregion


            #endregion
        }
        [Fact]
        public static void VG9550B_Tests_FactReturnCode_00()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();
                GE0510S_Tests.Load_Parameters();
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-10"}
            });
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                var program = new VG9550B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 00);

                //R0060_10_CONTINUA_Insert3
                var envList = AppSettings.TestSet.DynamicData["R0060_10_CONTINUA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("SEGURVGA_NUM_CERTIFICADO", out var val1r) && val1r.Contains("000000001234567"));
                Assert.True(envList[1].TryGetValue("SEGURVGA_COD_CLIENTE", out var val2r) && val2r.Contains("000000876"));

                //R0060_10_CONTINUA_Update2
                var envList2 = AppSettings.TestSet.DynamicData["R0060_10_CONTINUA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("SEGURVGA_COD_FONTE", out var val3r) && val3r.Contains("0099"));
                Assert.True(envList2[1].TryGetValue("FONTES_ULT_PROP_AUTOMAT", out var val4r) && val4r.Contains("000000003"));

                //R1060_00_UPDT_GE_CLIENTE_MOVTO_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("PROPOVA_COD_CLIENTE", out var val5r) && val5r.Contains("037190090"));
                Assert.True(envList3[1].TryGetValue("PROPOVA_OCOREND", out var val6r) && val6r.Contains("0001"));

                //R2070_00_INSERT_ENDERECO_SEG_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("SEGURVGA_COD_CLIENTE", out var val7r) && val7r.Contains("037190090"));
                Assert.True(envList4[1].TryGetValue("ENDERECO_CIDADE", out var val8r) && val8r.Contains("SÃO PAULO                                                               "));

                //R2080_00_UPDATE_ENDERECO_SEG_Update1
                var envList5 = AppSettings.TestSet.DynamicData["R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("SEGURVGA_NUM_CERTIFICADO", out var val9r) && val9r.Contains("000010026748673"));


            }
        }

        [Theory]
        [InlineData()]
        public static void VG9550B_Tests_FactReturnCode_99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                GE0510S_Tests.Load_Parameters();
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0000_00_PRINCIPAL_Query1

                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);
                #endregion
                #endregion
                var program = new VG9550B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}