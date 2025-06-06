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
using static Code.VG0035B;

namespace FileTests.Test
{
    [Collection("VG0035B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0035B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0120_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0035B_PROPOSTA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_COD_FONTE" , "7910"},
                { "RELATORI_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0035B_PROPOSTA", q1);

            #endregion

            #region R1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PRODUVG_NOME_PRODUTO" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_APOLICE" , "19790324"},
                { "MOVIMVGA_COD_SUBGRUPO" , ""},
                { "MOVIMVGA_COD_FONTE" , ""},
                { "MOVIMVGA_NUM_PROPOSTA" , ""},
                { "MOVIMVGA_TIPO_SEGURADO" , ""},
                { "MOVIMVGA_NUM_CERTIFICADO" , ""},
                { "MOVIMVGA_DAC_CERTIFICADO" , ""},
                { "MOVIMVGA_TIPO_INCLUSAO" , ""},
                { "MOVIMVGA_COD_CLIENTE" , ""},
                { "MOVIMVGA_COD_AGENCIADOR" , ""},
                { "MOVIMVGA_COD_CORRETOR" , ""},
                { "MOVIMVGA_COD_PLANOVGAP" , ""},
                { "MOVIMVGA_COD_PLANOAP" , ""},
                { "MOVIMVGA_FAIXA" , ""},
                { "MOVIMVGA_AUTOR_AUM_AUTOMAT" , ""},
                { "MOVIMVGA_TIPO_BENEFICIARIO" , ""},
                { "MOVIMVGA_PERI_PAGAMENTO" , ""},
                { "MOVIMVGA_PERI_RENOVACAO" , ""},
                { "MOVIMVGA_COD_OCUPACAO" , ""},
                { "MOVIMVGA_ESTADO_CIVIL" , ""},
                { "MOVIMVGA_IDE_SEXO" , ""},
                { "MOVIMVGA_COD_PROFISSAO" , ""},
                { "MOVIMVGA_NATURALIDADE" , ""},
                { "MOVIMVGA_OCORR_ENDERECO" , ""},
                { "MOVIMVGA_OCORR_END_COBRAN" , ""},
                { "MOVIMVGA_BCO_COBRANCA" , ""},
                { "MOVIMVGA_AGE_COBRANCA" , ""},
                { "MOVIMVGA_DAC_COBRANCA" , ""},
                { "MOVIMVGA_NUM_MATRICULA" , ""},
                { "MOVIMVGA_NUM_CTA_CORRENTE" , ""},
                { "MOVIMVGA_DAC_CTA_CORRENTE" , ""},
                { "MOVIMVGA_VAL_SALARIO" , ""},
                { "MOVIMVGA_TIPO_SALARIO" , ""},
                { "MOVIMVGA_TIPO_PLANO" , ""},
                { "MOVIMVGA_PCT_CONJUGE_VG" , ""},
                { "MOVIMVGA_PCT_CONJUGE_AP" , ""},
                { "MOVIMVGA_QTD_SAL_MORNATU" , ""},
                { "MOVIMVGA_QTD_SAL_MORACID" , ""},
                { "MOVIMVGA_QTD_SAL_INVPERM" , ""},
                { "MOVIMVGA_TAXA_AP_MORACID" , ""},
                { "MOVIMVGA_TAXA_AP_INVPERM" , ""},
                { "MOVIMVGA_TAXA_AP_AMDS" , ""},
                { "MOVIMVGA_TAXA_AP_DH" , ""},
                { "MOVIMVGA_TAXA_AP_DIT" , ""},
                { "MOVIMVGA_TAXA_VG" , ""},
                { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                { "MOVIMVGA_IMP_MORACID_ANT" , ""},
                { "MOVIMVGA_IMP_MORACID_ATU" , ""},
                { "MOVIMVGA_IMP_INVPERM_ANT" , ""},
                { "MOVIMVGA_IMP_INVPERM_ATU" , ""},
                { "MOVIMVGA_IMP_AMDS_ANT" , ""},
                { "MOVIMVGA_IMP_AMDS_ATU" , ""},
                { "MOVIMVGA_IMP_DH_ANT" , ""},
                { "MOVIMVGA_IMP_DH_ATU" , ""},
                { "MOVIMVGA_IMP_DIT_ANT" , ""},
                { "MOVIMVGA_IMP_DIT_ATU" , ""},
                { "MOVIMVGA_PRM_VG_ANT" , ""},
                { "MOVIMVGA_PRM_VG_ATU" , ""},
                { "MOVIMVGA_PRM_AP_ANT" , ""},
                { "MOVIMVGA_PRM_AP_ATU" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
                { "MOVIMVGA_DATA_OPERACAO" , ""},
                { "MOVIMVGA_COD_SUBGRUPO_TRANS" , ""},
                { "MOVIMVGA_SIT_REGISTRO" , ""},
                { "MOVIMVGA_COD_USUARIO" , ""},
                { "MOVIMVGA_DATA_AVERBACAO" , ""},
                { "MOVIMVGA_DATA_ADMISSAO" , ""},
                { "MOVIMVGA_DATA_INCLUSAO" , ""},
                { "MOVIMVGA_DATA_NASCIMENTO" , ""},
                { "MOVIMVGA_DATA_FATURA" , ""},
                { "MOVIMVGA_DATA_REFERENCIA" , ""},
                { "MOVIMVGA_DATA_MOVIMENTO" , ""},
                { "MOVIMVGA_COD_EMPRESA" , ""},
                { "MOVIMVGA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1600_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_APOLICE" , "19790324"},
                { "MOVIMVGA_COD_SUBGRUPO" , ""},
                { "MOVIMVGA_COD_FONTE" , ""},
                { "MOVIMVGA_NUM_PROPOSTA" , ""},
                { "MOVIMVGA_TIPO_SEGURADO" , ""},
                { "MOVIMVGA_NUM_CERTIFICADO" , ""},
                { "MOVIMVGA_DAC_CERTIFICADO" , ""},
                { "MOVIMVGA_TIPO_INCLUSAO" , ""},
                { "MOVIMVGA_COD_CLIENTE" , ""},
                { "MOVIMVGA_COD_AGENCIADOR" , ""},
                { "MOVIMVGA_COD_CORRETOR" , ""},
                { "MOVIMVGA_COD_PLANOVGAP" , ""},
                { "MOVIMVGA_COD_PLANOAP" , ""},
                { "MOVIMVGA_FAIXA" , ""},
                { "MOVIMVGA_AUTOR_AUM_AUTOMAT" , ""},
                { "MOVIMVGA_TIPO_BENEFICIARIO" , ""},
                { "MOVIMVGA_PERI_PAGAMENTO" , ""},
                { "MOVIMVGA_PERI_RENOVACAO" , ""},
                { "MOVIMVGA_COD_OCUPACAO" , ""},
                { "MOVIMVGA_ESTADO_CIVIL" , ""},
                { "MOVIMVGA_IDE_SEXO" , ""},
                { "MOVIMVGA_COD_PROFISSAO" , ""},
                { "MOVIMVGA_NATURALIDADE" , ""},
                { "MOVIMVGA_OCORR_ENDERECO" , ""},
                { "MOVIMVGA_OCORR_END_COBRAN" , ""},
                { "MOVIMVGA_BCO_COBRANCA" , ""},
                { "MOVIMVGA_AGE_COBRANCA" , ""},
                { "MOVIMVGA_DAC_COBRANCA" , ""},
                { "MOVIMVGA_NUM_MATRICULA" , ""},
                { "MOVIMVGA_NUM_CTA_CORRENTE" , ""},
                { "MOVIMVGA_DAC_CTA_CORRENTE" , ""},
                { "MOVIMVGA_VAL_SALARIO" , ""},
                { "MOVIMVGA_TIPO_SALARIO" , ""},
                { "MOVIMVGA_TIPO_PLANO" , ""},
                { "MOVIMVGA_PCT_CONJUGE_VG" , ""},
                { "MOVIMVGA_PCT_CONJUGE_AP" , ""},
                { "MOVIMVGA_QTD_SAL_MORNATU" , ""},
                { "MOVIMVGA_QTD_SAL_MORACID" , ""},
                { "MOVIMVGA_QTD_SAL_INVPERM" , ""},
                { "MOVIMVGA_TAXA_AP_MORACID" , ""},
                { "MOVIMVGA_TAXA_AP_INVPERM" , ""},
                { "MOVIMVGA_TAXA_AP_AMDS" , ""},
                { "MOVIMVGA_TAXA_AP_DH" , ""},
                { "MOVIMVGA_TAXA_AP_DIT" , ""},
                { "MOVIMVGA_TAXA_VG" , ""},
                { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                { "MOVIMVGA_IMP_MORACID_ANT" , ""},
                { "MOVIMVGA_IMP_MORACID_ATU" , ""},
                { "MOVIMVGA_IMP_INVPERM_ANT" , ""},
                { "MOVIMVGA_IMP_INVPERM_ATU" , ""},
                { "MOVIMVGA_IMP_AMDS_ANT" , ""},
                { "MOVIMVGA_IMP_AMDS_ATU" , ""},
                { "MOVIMVGA_IMP_DH_ANT" , ""},
                { "MOVIMVGA_IMP_DH_ATU" , ""},
                { "MOVIMVGA_IMP_DIT_ANT" , ""},
                { "MOVIMVGA_IMP_DIT_ATU" , ""},
                { "MOVIMVGA_PRM_VG_ANT" , ""},
                { "MOVIMVGA_PRM_VG_ATU" , ""},
                { "MOVIMVGA_PRM_AP_ANT" , ""},
                { "MOVIMVGA_PRM_AP_ATU" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
                { "MOVIMVGA_DATA_OPERACAO" , ""},
                { "MOVIMVGA_COD_SUBGRUPO_TRANS" , ""},
                { "MOVIMVGA_SIT_REGISTRO" , ""},
                { "MOVIMVGA_COD_USUARIO" , ""},
                { "MOVIMVGA_DATA_AVERBACAO" , ""},
                { "MOVIMVGA_DATA_ADMISSAO" , ""},
                { "MOVIMVGA_DATA_INCLUSAO" , ""},
                { "MOVIMVGA_DATA_NASCIMENTO" , ""},
                { "MOVIMVGA_DATA_FATURA" , ""},
                { "MOVIMVGA_DATA_REFERENCIA" , ""},
                { "MOVIMVGA_DATA_MOVIMENTO" , ""},
                { "MOVIMVGA_COD_EMPRESA" , ""},
                { "MOVIMVGA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1700_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_APOLICE" , ""},
                { "MOVIMVGA_COD_SUBGRUPO" , ""},
                { "MOVIMVGA_COD_FONTE" , ""},
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "MOVIMVGA_TIPO_SEGURADO" , ""},
                { "MOVIMVGA_NUM_CERTIFICADO" , ""},
                { "MOVIMVGA_DAC_CERTIFICADO" , ""},
                { "MOVIMVGA_TIPO_INCLUSAO" , ""},
                { "MOVIMVGA_COD_CLIENTE" , ""},
                { "MOVIMVGA_COD_AGENCIADOR" , ""},
                { "MOVIMVGA_COD_CORRETOR" , ""},
                { "MOVIMVGA_COD_PLANOVGAP" , ""},
                { "MOVIMVGA_COD_PLANOAP" , ""},
                { "MOVIMVGA_FAIXA" , ""},
                { "MOVIMVGA_AUTOR_AUM_AUTOMAT" , ""},
                { "MOVIMVGA_TIPO_BENEFICIARIO" , ""},
                { "MOVIMVGA_PERI_PAGAMENTO" , ""},
                { "MOVIMVGA_PERI_RENOVACAO" , ""},
                { "MOVIMVGA_COD_OCUPACAO" , ""},
                { "MOVIMVGA_ESTADO_CIVIL" , ""},
                { "MOVIMVGA_IDE_SEXO" , ""},
                { "MOVIMVGA_COD_PROFISSAO" , ""},
                { "MOVIMVGA_NATURALIDADE" , ""},
                { "MOVIMVGA_OCORR_ENDERECO" , ""},
                { "MOVIMVGA_OCORR_END_COBRAN" , ""},
                { "MOVIMVGA_BCO_COBRANCA" , ""},
                { "MOVIMVGA_AGE_COBRANCA" , ""},
                { "MOVIMVGA_DAC_COBRANCA" , ""},
                { "MOVIMVGA_NUM_MATRICULA" , ""},
                { "MOVIMVGA_NUM_CTA_CORRENTE" , ""},
                { "MOVIMVGA_DAC_CTA_CORRENTE" , ""},
                { "MOVIMVGA_VAL_SALARIO" , ""},
                { "MOVIMVGA_TIPO_SALARIO" , ""},
                { "MOVIMVGA_TIPO_PLANO" , ""},
                { "MOVIMVGA_PCT_CONJUGE_VG" , ""},
                { "MOVIMVGA_PCT_CONJUGE_AP" , ""},
                { "MOVIMVGA_QTD_SAL_MORNATU" , ""},
                { "MOVIMVGA_QTD_SAL_MORACID" , ""},
                { "MOVIMVGA_QTD_SAL_INVPERM" , ""},
                { "MOVIMVGA_TAXA_AP_MORACID" , ""},
                { "MOVIMVGA_TAXA_AP_INVPERM" , ""},
                { "MOVIMVGA_TAXA_AP_AMDS" , ""},
                { "MOVIMVGA_TAXA_AP_DH" , ""},
                { "MOVIMVGA_TAXA_AP_DIT" , ""},
                { "MOVIMVGA_TAXA_VG" , ""},
                { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                { "MOVIMVGA_IMP_MORACID_ANT" , ""},
                { "MOVIMVGA_IMP_MORACID_ATU" , ""},
                { "MOVIMVGA_IMP_INVPERM_ANT" , ""},
                { "MOVIMVGA_IMP_INVPERM_ATU" , ""},
                { "MOVIMVGA_IMP_AMDS_ANT" , ""},
                { "MOVIMVGA_IMP_AMDS_ATU" , ""},
                { "MOVIMVGA_IMP_DH_ANT" , ""},
                { "MOVIMVGA_IMP_DH_ATU" , ""},
                { "MOVIMVGA_IMP_DIT_ANT" , ""},
                { "MOVIMVGA_IMP_DIT_ATU" , ""},
                { "MOVIMVGA_PRM_VG_ANT" , ""},
                { "MOVIMVGA_PRM_VG_ATU" , ""},
                { "MOVIMVGA_PRM_AP_ANT" , ""},
                { "MOVIMVGA_PRM_AP_ATU" , ""},
                { "MOVIMVGA_COD_SUBGRUPO_TRANS" , ""},
                { "MOVIMVGA_SIT_REGISTRO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "MOVIMVGA_DATA_ADMISSAO" , ""},
                { "MOVIMVGA_DATA_NASCIMENTO" , ""},
                { "MOVIMVGA_COD_EMPRESA" , ""},
                { "MOVIMVGA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1800_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , "791245"}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_FONTES_DB_SELECT_1_Query1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("DVG0035B_FILE_NAME_P")]
        public static void VG0035B_Tests_Theory_ReturnCode_00(string DVG0035B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DVG0035B_FILE_NAME_P = $"{DVG0035B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                SQLCA sQLCA = new SQLCA();
                sQLCA.SQLCODE.SetValue(100);

                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1");
                var q5 = new DynamicData();

                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1", q5);

                #endregion
                var program = new VG0035B();
                program.Execute(DVG0035B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R1700_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R1700_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("MOVIMVGA_NUM_APOLICE", out string valor) && valor == "0000019790324");

                //R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("PROPOVA_COD_FONTE", out valor) && valor == "7910");

            }
        }
        [Theory]
        [InlineData("DVG0035B_FILE_NAME_P")]
        public static void VG0035B_Tests_Theory_ReturnCode_99(string DVG0035B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DVG0035B_FILE_NAME_P = $"{DVG0035B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q2);
                #endregion

                #endregion
                var program = new VG0035B();
                program.Execute(DVG0035B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}