using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0010B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VG0010B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0010B_Tests
    {
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "V1SISTEMA_CURRDATE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PAR_RAMO_VG" , ""},
                { "V1PAR_RAMO_AP" , ""},
                { "V1PAR_RAMO_PST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EN_COD_MOEDA_IMP" , ""},
                { "DVLCRUZAD_IMP" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VG0010B_TMOVIMENTO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_FONTE" , "1"},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MDAC_CERTIFICADO" , ""},
                { "MTIPO_INCLUSAO" , ""},
                { "MCOD_CLIENTE" , ""},
                { "MCOD_AGENCIADOR" , ""},
                { "MCOD_CORRETOR" , ""},
                { "MCOD_PLANOVGAP" , ""},
                { "MCOD_PLANOAP" , ""},
                { "MFAIXA" , ""},
                { "MAUTOR_AUM_AUTOMAT" , ""},
                { "MTIPO_BENEFICIARIO" , "Teste"},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MCOD_OCUPACAO" , ""},
                { "MESTADO_CIVIL" , ""},
                { "MIDE_SEXO" , ""},
                { "MCOD_PROFISSAO" , ""},
                { "MNATURALIDADE" , ""},
                { "MOCORR_ENDERECO" , ""},
                { "MOCORR_END_COBRAN" , ""},
                { "MBCO_COBRANCA" , ""},
                { "MAGE_COBRANCA" , ""},
                { "MDAC_COBRANCA" , ""},
                { "MNUM_MATRICULA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MVAL_SALARIO" , ""},
                { "MTIPO_SALARIO" , ""},
                { "MTIPO_PLANO" , ""},
                { "MPCT_CONJUGE_VG" , ""},
                { "MPCT_CONJUGE_AP" , ""},
                { "MQTD_SAL_MORNATU" , ""},
                { "MQTD_SAL_MORACID" , ""},
                { "MQTD_SAL_INVPERM" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "MTAXA_VG" , ""},
                { "MIMP_MORNATU_ANT" , ""},
                { "MIMP_MORNATU_ATU" , "1"},
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
                { "MPRM_VG_ATU" , "1"},
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
                { "MDATA_RENOVACAO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "MLOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0010B_TMOVIMENTO", q3);

            #endregion

            #region M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0NUM_APOLICE" , ""},
                { "SNUM_ITEM" , ""},
                { "WNUM_ITEM" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SNUM_ITEM_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SNUM_ITEM_SEGUR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CDATA_NASCIMENTO" , ""},
                { "CWDATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "NUMCERVG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "DAC_CERTIFICADO" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "SNUM_ITEM" , ""},
                { "MTIPO_INCLUSAO" , ""},
                { "MCOD_CLIENTE" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MCOD_AGENCIADOR" , ""},
                { "MCOD_CORRETOR" , ""},
                { "MCOD_PLANOVGAP" , ""},
                { "MCOD_PLANOAP" , ""},
                { "MFAIXA" , ""},
                { "MAUTOR_AUM_AUTOMAT" , ""},
                { "MTIPO_BENEFICIARIO" , ""},
                { "SEGUR_OCORHIST" , ""},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MCOD_OCUPACAO" , ""},
                { "MESTADO_CIVIL" , ""},
                { "MIDE_SEXO" , ""},
                { "MCOD_PROFISSAO" , ""},
                { "MNATURALIDADE" , ""},
                { "MOCORR_ENDERECO" , ""},
                { "MOCORR_END_COBRAN" , ""},
                { "MBCO_COBRANCA" , ""},
                { "MAGE_COBRANCA" , ""},
                { "MDAC_COBRANCA" , ""},
                { "MNUM_MATRICULA" , ""},
                { "MVAL_SALARIO" , ""},
                { "MTIPO_SALARIO" , ""},
                { "MTIPO_PLANO" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "MPCT_CONJUGE_VG" , ""},
                { "MPCT_CONJUGE_AP" , ""},
                { "MQTD_SAL_MORNATU" , ""},
                { "MQTD_SAL_MORACID" , ""},
                { "MQTD_SAL_INVPERM" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "MTAXA_VG" , ""},
                { "MDATA_RENOVACAO" , ""},
                { "MDATA_NASCIMENTO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "MLOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1", q9);

            #endregion

            #region M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_DATA_ADMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "MPCT_CONJUGE_VG" , ""},
                { "MPCT_CONJUGE_AP" , ""},
                { "MNUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1", q11);

            #endregion

            #region M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "VGNUM_APOLICE" , ""},
                { "VGNRENDOS" , ""},
                { "VGNUM_ITEM" , ""},
                { "VGOCORHIST" , ""},
                { "VGRAMOFR" , ""},
                { "VGMODALIFR" , ""},
                { "VGCOD_COBERTURA" , ""},
                { "VGIMP_SEGURADA_IX" , ""},
                { "VGPRM_TARIFARIO_IX" , ""},
                { "VGIMP_SEGURADA_VAR" , ""},
                { "PRM_TARIFARIO_VAR" , ""},
                { "VGPCT_COBERTURA" , ""},
                { "VGFATOR_MULTIPLICA" , ""},
                { "VGDATA_INIVIGENCIA" , ""},
                { "VGDATA_TERVIGENCIA" , ""},
                { "MCOD_EMPRESA" , ""},
                { "VGCOD_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1", q12);

            #endregion

            #region M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "SNUM_ITEM" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V1SISTEMA_DTMOVABE" , ""},
                { "HHORA_OPERACAO" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "HOCORR_HISTORICO" , ""},
                { "HCOD_SUBGRUP_TRANS" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MCOD_USUARIO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "V1EN_COD_MOEDA_IMP" , ""},
                { "V1EN_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1", q13);

            #endregion

            #region M_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "MCOD_CLIENTE" , ""},
                { "MNUM_APOLICE" , ""},
                { "MBCO_COBRANCA" , ""},
                { "MAGE_COBRANCA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MCOD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1", q14);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "MDATA_NASCIMENTO" , ""},
                { "WDATA_NASCIMENTO" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1", q15);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "MNUM_APOLICE" , ""},
                { "V0RELA_NRCERTIF" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1", q16);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_3_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "MNUM_APOLICE" , ""},
                { "V0RELA_NRCERTIF" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_3_Insert1", q17);

            #endregion

            #region M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SNUM_ITEM" , ""},
                { "V0NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1", q18);

            #endregion

            #region VG0010B_TBENEFIPROP

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , ""},
                { "COD_SUBGRUPO" , ""},
                { "COD_FONTE" , ""},
                { "NUM_PROPOSTA" , ""},
                { "NUM_BENEFICIARIO" , ""},
                { "NOME_BENEFICIARIO" , ""},
                { "GRAU_PARENTESCO" , ""},
                { "PCT_PART_BENEFICIA" , ""},
                { "COD_USUARIO" , ""},
                { "COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0010B_TBENEFIPROP", q19);

            #endregion

            #region M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , ""},
                { "COD_SUBGRUPO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "DAC_CERTIFICADO" , ""},
                { "NUM_BENEFICIARIO" , ""},
                { "NOME_BENEFICIARIO" , ""},
                { "GRAU_PARENTESCO" , ""},
                { "PCT_PART_BENEFICIA" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "DTTERVIG" , ""},
                { "COD_USUARIO" , ""},
                { "COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1", q20);

            #endregion

            #region M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "H_NUM_CERTIFICADO" , ""},
                { "NUMCERVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1", q21);

            #endregion

            #region M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "H_NUM_CERTIFICADO" , ""},
                { "DAC_CERTIFICADO" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1", q22);

            #endregion

            #region M_600_000_GERA_TERVIG_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "WK_DATA_TERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_600_000_GERA_TERVIG_DB_SELECT_1_Query1", q23);

            #endregion

            #region M_600_010_GERA_TERVIG_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "WK_COD_CCT" , ""},
                { "WNUM_CCT" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PRODUVG_NOME_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_600_010_GERA_TERVIG_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_600_010_GERA_TERVIG_DB_SELECT_2_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "WK_DATA_TERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_600_010_GERA_TERVIG_DB_SELECT_2_Query1", q25);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("DSAIDA.txt", "SSAIDA.txt")]
        public static void VG0010B_Tests_Theory(string SAIDA_DVG0010D_FILE_NAME_P, string SAIDA_DVG0010S_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAIDA_DVG0010D_FILE_NAME_P = $"{SAIDA_DVG0010D_FILE_NAME_P}_{timestamp}.txt";
            SAIDA_DVG0010S_FILE_NAME_P = $"{SAIDA_DVG0010S_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                var program = new VG0010B();

                var fileName = Path.GetFileNameWithoutExtension(SAIDA_DVG0010D_FILE_NAME_P);
                SAIDA_DVG0010D_FILE_NAME_P = SAIDA_DVG0010D_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                Console.WriteLine($"#### Arquivo {SAIDA_DVG0010D_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                fileName = Path.GetFileNameWithoutExtension(SAIDA_DVG0010S_FILE_NAME_P);
                SAIDA_DVG0010S_FILE_NAME_P = SAIDA_DVG0010S_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                Console.WriteLine($"#### Arquivo {SAIDA_DVG0010S_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                AppSettings.TestSet.IsTest = true;

                Load_Parameters();

                program.Execute(SAIDA_DVG0010D_FILE_NAME_P, SAIDA_DVG0010S_FILE_NAME_P);

                Assert.True(File.Exists(program.DSAIDA.FilePath));
                Assert.True(new FileInfo(program.SSAIDA.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.DSAIDA.FilePath));
                Assert.True(new FileInfo(program.SSAIDA.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);

                Assert.True(envList[1].TryGetValue("MTIPO_BENEFICIARIO", out var valor) && valor == "T");
                Assert.True(envList1[1].TryGetValue("VGCOD_COBERTURA", out valor) && valor == "0011");
                Assert.True(envList2[1].TryGetValue("HOCORR_HISTORICO", out valor) && valor == "0001");

            }
        }
    }
}