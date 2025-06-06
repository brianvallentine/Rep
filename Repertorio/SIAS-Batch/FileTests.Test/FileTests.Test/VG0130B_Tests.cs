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
using static Code.VG0130B;

namespace FileTests.Test
{
    [Collection("VG0130B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0130B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_030_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_040_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PAR_RAMO_VG" , ""},
                { "V1PAR_RAMO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_040_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q1);

            #endregion

            #region VG0130B_RELATORIO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "R_IDSISTEM" , "VG"},
                { "R_CODRELAT" , "VG0130B"},
                { "R_NUM_APOLICE" , "97010000889"},
                { "R_CODSUBES" , "263"},
                { "R_OPERACAO" , "0"},
                { "R_DATA_REFERENCIA" , "2024-11-03"},
                { "R_SITUACAO" , "0 "},
                { "R_PERI_RENOVACAO" , "12"},
                { "R_PCT_AUMENTO" , ""},
                { "R_CODUSU" , "VE0100B"},
                { "R_CORRECAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0130B_RELATORIO", q2);

            #endregion

            #region VG0130B_TSEGURAVG

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SNUM_APOLICE" , ""},
                { "SCOD_SUBGRUPO" , ""},
                { "SNUM_CERTIFICADO" , ""},
                { "SDAC_CERTIFICADO" , ""},
                { "STIPO_SEGURADO" , ""},
                { "SNUM_ITEM" , ""},
                { "STIPO_INCLUSAO" , ""},
                { "SCOD_CLIENTE" , ""},
                { "SCOD_FONTE" , ""},
                { "SNUM_PROPOSTA" , ""},
                { "SCOD_AGENCIADOR" , ""},
                { "SCOD_CORRETOR" , ""},
                { "SCOD_PLANOVGAP" , ""},
                { "SCOD_PLANOAP" , ""},
                { "SFAIXA" , ""},
                { "SAUTOR_AUM_AUTOMAT" , ""},
                { "STIPO_BENEFICIARIO" , ""},
                { "SOCORR_HISTORICO" , ""},
                { "SPERI_PAGAMENTO" , ""},
                { "SPERI_RENOVACAO" , ""},
                { "SNUM_CARNE" , ""},
                { "SCOD_OCUPACAO" , ""},
                { "SESTADO_CIVIL" , ""},
                { "SIDE_SEXO" , ""},
                { "SCOD_PROFISSAO" , ""},
                { "SNATURALIDADE" , ""},
                { "SOCORR_ENDERECO" , ""},
                { "SOCORR_END_COBRAN" , ""},
                { "SBCO_COBRANCA" , ""},
                { "SAGE_COBRANCA" , ""},
                { "SDAC_COBRANCA" , ""},
                { "SNUM_MATRICULA" , ""},
                { "SVAL_SALARIO" , ""},
                { "STIPO_SALARIO" , ""},
                { "STIPO_PLANO" , ""},
                { "SDATA_INIVIGENCIA" , ""},
                { "SPCT_CONJUGE_VG" , ""},
                { "SPCT_CONJUGE_AP" , ""},
                { "SQTD_SAL_MORNATU" , ""},
                { "SQTD_SAL_MORACID" , ""},
                { "SQTD_SAL_INVPERM" , ""},
                { "STAXA_AP_MORACID" , ""},
                { "STAXA_AP_INVPERM" , ""},
                { "STAXA_AP_AMDS" , ""},
                { "STAXA_AP_DH" , ""},
                { "STAXA_AP_DIT" , ""},
                { "STAXA_AP" , ""},
                { "STAXA_VG" , ""},
                { "SSIT_REGISTRO" , ""},
                { "SDATA_ADMISSAO" , ""},
                { "SDATA_NASCIMENTO" , ""},
                { "SCOD_EMPRESA" , ""},
                { "SLOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0130B_TSEGURAVG", q3);

            #endregion

            #region M_070_000_VE_FATURAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FDATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_VE_FATURAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_070_000_VE_FATURAS_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "NUM_FATURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_VE_FATURAS_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CNUM_APOLICE" , ""},
                { "CNRENDOS" , ""},
                { "CNUM_ITEM" , ""},
                { "COCORHIST" , ""},
                { "CRAMOFR" , ""},
                { "CMODALIFR" , ""},
                { "CCOD_COBERTURA" , ""},
                { "CIMP_SEGURADA_IX" , ""},
                { "CPRM_TARIFARIO_IX" , ""},
                { "CFATOR_MULTIPLICA" , ""},
                { "CDATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HNUM_APOLICE" , ""},
                { "HCOD_SUBGRUPO" , ""},
                { "HNUM_ITEM" , ""},
                { "XDATA_MOVIMENTO" , ""},
                { "ECOD_MOEDA_IMP" , ""},
                { "ECOD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_270_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_IMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_270_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_PRM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1", q9);

            #endregion

            #region M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MDATA_INCLUSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SNUM_APOLICE" , ""},
                { "SCOD_SUBGRUPO" , ""},
                { "SCOD_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "STIPO_SEGURADO" , ""},
                { "SNUM_CERTIFICADO" , ""},
                { "SDAC_CERTIFICADO" , ""},
                { "STIPO_INCLUSAO" , ""},
                { "SCOD_CLIENTE" , ""},
                { "SCOD_AGENCIADOR" , ""},
                { "SCOD_CORRETOR" , ""},
                { "SCOD_PLANOVGAP" , ""},
                { "SCOD_PLANOAP" , ""},
                { "SFAIXA" , ""},
                { "SAUTOR_AUM_AUTOMAT" , ""},
                { "STIPO_BENEFICIARIO" , ""},
                { "SPERI_PAGAMENTO" , ""},
                { "SPERI_RENOVACAO" , ""},
                { "SCOD_OCUPACAO" , ""},
                { "SESTADO_CIVIL" , ""},
                { "SIDE_SEXO" , ""},
                { "SCOD_PROFISSAO" , ""},
                { "SNATURALIDADE" , ""},
                { "SOCORR_ENDERECO" , ""},
                { "SOCORR_END_COBRAN" , ""},
                { "SBCO_COBRANCA" , ""},
                { "SAGE_COBRANCA" , ""},
                { "SDAC_COBRANCA" , ""},
                { "SNUM_MATRICULA" , ""},
                { "NUM_CTA_CORRENTE" , ""},
                { "DAC_CTA_CORRENTE" , ""},
                { "SVAL_SALARIO" , ""},
                { "STIPO_SALARIO" , ""},
                { "STIPO_PLANO" , ""},
                { "SPCT_CONJUGE_VG" , ""},
                { "SPCT_CONJUGE_AP" , ""},
                { "SQTD_SAL_MORNATU" , ""},
                { "SQTD_SAL_MORACID" , ""},
                { "SQTD_SAL_INVPERM" , ""},
                { "STAXA_AP_MORACID" , ""},
                { "STAXA_AP_INVPERM" , ""},
                { "STAXA_AP_AMDS" , ""},
                { "STAXA_AP_DH" , ""},
                { "STAXA_AP_DIT" , ""},
                { "STAXA_VG" , ""},
                { "MIMP_MORNATU_ANT" , ""},
                { "MIMP_MORNATU_ATU" , ""},
                { "MIMP_MORACID_ANT" , ""},
                { "MIMP_MORACID_ATU" , ""},
                { "MIMP_INVPERM_ANT" , ""},
                { "MIMP_INVPERM_ATU" , ""},
                { "MIMP_AMDS_ANT" , ""},
                { "MIMP_AMDS_ATU" , ""},
                { "MIMP_DH_ANT" , ""},
                { "MIMP_DH_ATU" , ""},
                { "MIMP_DIT_ANT" , ""},
                { "MIMP_DIT_ATU" , ""},
                { "MPRM_VG_ANT" , ""},
                { "MPRM_VG_ATU" , ""},
                { "MPRM_AP_ANT" , ""},
                { "MPRM_AP_ATU" , ""},
                { "MCOD_OPERACAO" , ""},
                { "MDATA_OPERACAO" , ""},
                { "COD_SUBGRUPO_TRANS" , ""},
                { "MSIT_REGISTRO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MDATA_AVERBACAO" , ""},
                { "MDATA_ADMISSAO" , ""},
                { "MDATA_INCLUSAO" , ""},
                { "MDATA_NASCIMENTO" , ""},
                { "MDATA_FATURA" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "SLOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1", q11);

            #endregion

            #region M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "SCOD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1", q13);

            #endregion

            #region M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "OCOD_CLIENTE" , ""},
                { "ONUM_APOLICE" , ""},
                { "NUM_CTA_CORRENTE" , ""},
                { "DAC_CTA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_700_000_UPDATE_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "R_NUM_APOLICE" , ""},
                { "R_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_700_000_UPDATE_DB_UPDATE_1_Update1", q15);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0130B_Tests_Fact_ReturnCode_0()
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
                #region M_070_000_VE_FATURAS_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_070_000_VE_FATURAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_070_000_VE_FATURAS_DB_SELECT_2_Query1", q5);

                #endregion
                #region M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "CNUM_APOLICE" , "1119790324"},
                { "CNRENDOS" , "1"},
                { "CNUM_ITEM" , "1"},
                { "COCORHIST" , "1"},
                { "CRAMOFR" , "3"},
                { "CMODALIFR" , "2"},
                { "CCOD_COBERTURA" , "22"},
                { "CIMP_SEGURADA_IX" , "1"},
                { "CPRM_TARIFARIO_IX" , "1"},
                { "CFATOR_MULTIPLICA" , "1"},
                { "CDATA_INIVIGENCIA" , "2024-10-31"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "HNUM_APOLICE" , "123456789"},
                { "HCOD_SUBGRUPO" , "11"},
                { "HNUM_ITEM" , "1"},
                { "XDATA_MOVIMENTO" , "2024-02-05"},
                { "ECOD_MOEDA_IMP" , "1"},
                { "ECOD_MOEDA_PRM" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1", q7);

                #endregion
                #region M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "3"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1", q12);

                #endregion
                #region VG0130B_TSEGURAVG

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SNUM_APOLICE" , "123419790324"},
                { "SCOD_SUBGRUPO" , "11"},
                { "SNUM_CERTIFICADO" , ""},
                { "SDAC_CERTIFICADO" , ""},
                { "STIPO_SEGURADO" , ""},
                { "SNUM_ITEM" , ""},
                { "STIPO_INCLUSAO" , ""},
                { "SCOD_CLIENTE" , ""},
                { "SCOD_FONTE" , "10"},
                { "SNUM_PROPOSTA" , ""},
                { "SCOD_AGENCIADOR" , ""},
                { "SCOD_CORRETOR" , ""},
                { "SCOD_PLANOVGAP" , ""},
                { "SCOD_PLANOAP" , ""},
                { "SFAIXA" , ""},
                { "SAUTOR_AUM_AUTOMAT" , ""},
                { "STIPO_BENEFICIARIO" , ""},
                { "SOCORR_HISTORICO" , ""},
                { "SPERI_PAGAMENTO" , ""},
                { "SPERI_RENOVACAO" , ""},
                { "SNUM_CARNE" , ""},
                { "SCOD_OCUPACAO" , ""},
                { "SESTADO_CIVIL" , ""},
                { "SIDE_SEXO" , ""},
                { "SCOD_PROFISSAO" , ""},
                { "SNATURALIDADE" , ""},
                { "SOCORR_ENDERECO" , ""},
                { "SOCORR_END_COBRAN" , ""},
                { "SBCO_COBRANCA" , ""},
                { "SAGE_COBRANCA" , ""},
                { "SDAC_COBRANCA" , ""},
                { "SNUM_MATRICULA" , ""},
                { "SVAL_SALARIO" , ""},
                { "STIPO_SALARIO" , ""},
                { "STIPO_PLANO" , ""},
                { "SDATA_INIVIGENCIA" , ""},
                { "SPCT_CONJUGE_VG" , ""},
                { "SPCT_CONJUGE_AP" , ""},
                { "SQTD_SAL_MORNATU" , ""},
                { "SQTD_SAL_MORACID" , ""},
                { "SQTD_SAL_INVPERM" , ""},
                { "STAXA_AP_MORACID" , ""},
                { "STAXA_AP_INVPERM" , ""},
                { "STAXA_AP_AMDS" , ""},
                { "STAXA_AP_DH" , ""},
                { "STAXA_AP_DIT" , ""},
                { "STAXA_AP" , ""},
                { "STAXA_VG" , ""},
                { "SSIT_REGISTRO" , ""},
                { "SDATA_ADMISSAO" , ""},
                { "SDATA_NASCIMENTO" , ""},
                { "SCOD_EMPRESA" , ""},
                { "SLOT_EMP_SEGURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0130B_TSEGURAVG");
                AppSettings.TestSet.DynamicData.Add("VG0130B_TSEGURAVG", q3);

                #endregion

                #endregion
                var program = new VG0130B();
                program.Execute();

                //M_700_000_UPDATE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_700_000_UPDATE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("R_NUM_APOLICE", out var val0r) && val0r.Contains("0097010000889"));

                //M_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("SCOD_FONTE", out var val1r) && val1r.Contains("0010"));

                //M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("SNUM_APOLICE", out var val2r) && val2r.Contains("123419790324"));
                Assert.True(envList2.Count > 1);

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Fact]
        public static void VG0130B_Tests_Fact_ReturnCode_9()
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
                #region VG0130B_RELATORIO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "R_IDSISTEM" , "VG"},
                { "R_CODRELAT" , "VG0130B"},
                { "R_NUM_APOLICE" , "97010000889"},
                { "R_CODSUBES" , "263"},
                { "R_OPERACAO" , "0"},
                { "R_DATA_REFERENCIA" , "2024-11-03"},
                { "R_SITUACAO" , "0 "},
                { "R_PERI_RENOVACAO" , "12"},
                { "R_PCT_AUMENTO" , ""},
                { "R_CODUSU" , "VE0100B"},
                { "R_CORRECAO" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VG0130B_RELATORIO");
                AppSettings.TestSet.DynamicData.Add("VG0130B_RELATORIO", q2);

                #endregion
                #endregion
                var program = new VG0130B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);

            }
        }
        [Fact]
        public static void VG0130B_Tests_Fact_SemMovimento_ReturnCode_0()
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
                #region VG0130B_RELATORIO

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG0130B_RELATORIO");
                AppSettings.TestSet.DynamicData.Add("VG0130B_RELATORIO", q2);

                #endregion
                #endregion
                var program = new VG0130B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

            }
        }
    }
}