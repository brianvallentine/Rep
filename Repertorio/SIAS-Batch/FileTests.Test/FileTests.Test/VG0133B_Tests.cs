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
using static Code.VG0133B;

namespace FileTests.Test
{
    [Collection("VG0133B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0133B_Tests
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

            #region VG0133B_RELATORIO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "R_NUM_APOLICE" , ""},
                { "R_COD_SUBGRUPO" , ""},
                { "R_IMP_MORNATU" , ""},
                { "R_IMP_MORACID" , ""},
                { "R_IMP_INVPERM" , ""},
                { "R_IMP_AMDS" , ""},
                { "R_IMP_DH" , ""},
                { "R_IMP_DIT" , ""},
                { "R_PRM_VG" , ""},
                { "R_PRM_AP" , ""},
                { "R_DATA_AUMENTO" , ""},
                { "R_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0133B_RELATORIO", q2);

            #endregion

            #region VG0133B_TSEGURAVG

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
            AppSettings.TestSet.DynamicData.Add("VG0133B_TSEGURAVG", q3);

            #endregion

            #region M_070_000_VE_FATURAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ATIPO_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_VE_FATURAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_070_000_VE_FATURAS_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "FDATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_VE_FATURAS_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_070_000_VE_FATURAS_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "NUM_FATURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_VE_FATURAS_DB_SELECT_3_Query1", q6);

            #endregion

            #region M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ECOD_MOEDA_IMP" , ""},
                { "ECOD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_270_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_IMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_270_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_PRM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1", q10);

            #endregion

            #region M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MDATA_INCLUSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1", q12);

            #endregion

            #region M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "SCOD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1", q14);

            #endregion

            #region M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "OCOD_CLIENTE" , ""},
                { "ONUM_APOLICE" , ""},
                { "NUM_CTA_CORRENTE" , ""},
                { "DAC_CTA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_700_000_UPDATE_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_700_000_UPDATE_DB_UPDATE_1_Update1", q16);

            #endregion

            #region M_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "XDATA_MOVIMENTO" , ""},
                { "ECOD_MOEDA_IMP" , ""},
                { "ECOD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_810_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_IMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_810_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_810_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_PRM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_810_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1", q19);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0133B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0133B();
                program.Execute();
                //Programa não chama o método INICIO-PROCESSO, por tanto, não possui acesso ao insert e update, contidos neste. obs: o arquivo cobol não faz perform neste método.
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void VG0133B_Tests_SemDados()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0133B();

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_030_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

                program.Execute();

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}