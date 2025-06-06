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
using static Code.VG0852B;
using Sias.VidaEmGrupo.DB2.VG0852B;

namespace FileTests.Test
{
    [Collection("VG0852B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0852B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1", q0);

            #endregion

            #region R100_00_PROCESSA_DATA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTVENFIM_VE" , ""},
                { "V1SIST_DTVENFIM_CN" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_00_PROCESSA_DATA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1", q2);

            #endregion

            #region R310_00_INSE_ARG_SIVPF_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R310_00_INSE_ARG_SIVPF_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_AP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q4);

            #endregion

            #region VG0852B_CHISTCB

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0852B_CHISTCB", q5);

            #endregion

            #region VG0852B_CONT_PEN

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_NUM_PARCELA" , ""},
                { "COBHISVI_OPCAO_PAGAMENTO" , ""},
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "COBHISVI_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0852B_CONT_PEN", q6);

            #endregion

            #region VG0852B_CSEGURA

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
                { "SEGURVGA_TIPO_INCLUSAO" , ""},
                { "SEGURVGA_COD_AGENCIADOR" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0852B_CSEGURA", q7);

            #endregion

            #region R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_NUM_PARCELA" , ""},
                { "COBHISVI_OPCAO_PAGAMENTO" , ""},
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "COBHISVI_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "COBHISVI_DATA_VENCIMENTO" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "COBHISVI_OPCAO_PAGAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2_Update1", q13);

            #endregion

            #region R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_TIPO_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1450_00_CANCELA_APOLICE_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_CANCELA_APOLICE_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R1600_00_CANCELA_ENDOSSO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SUBGRUPO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_CANCELA_ENDOSSO_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R1700_00_CANC_PARC_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_CANC_PARC_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R1700_00_CANC_PARC_DB_UPDATE_2_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_CANC_PARC_DB_UPDATE_2_Update1", q19);

            #endregion

            #region R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_NSL" , ""},
                { "HISPROFI_SIT_COBRANCA_SIVPF" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R2050_00_INSERT_MOV_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_TIPO_INCLUSAO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_COD_AGENCIADOR" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "CONTACOR_COD_AGENCIA" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "CONTACOR_NUM_CTA_CORRENTE" , ""},
                { "CONTACOR_DAC_CTA_CORRENTE" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_IMPINVPERM" , ""},
                { "V0COBA_IMPDIT" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "V0COBA_PRMAP" , ""},
                { "FATURCON_DATA_REFERENCIA" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2050_00_INSERT_MOV_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1_Query1", q24);

            #endregion

            #region R2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1_Update1", q25);

            #endregion

            #region R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1", q26);

            #endregion

            #region R2400_00_CONTA_CORRENTE_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_COD_AGENCIA" , ""},
                { "CONTACOR_NUM_CTA_CORRENTE" , ""},
                { "CONTACOR_DAC_CTA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_CONTA_CORRENTE_DB_SELECT_1_Query1", q27);

            #endregion

            #region R2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1_Query1", q28);

            #endregion

            #region R2600_00_IMP_SEGURADA_IX_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_IMP_SEGURADA_IX_DB_SELECT_1_Query1", q29);

            #endregion

            #region R2700_00_IMP_SEGURADA_IX2_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_IMP_SEGURADA_IX2_DB_SELECT_1_Query1", q30);

            #endregion

            #region R2800_00_V0COBA_IMPDIT_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_V0COBA_IMPDIT_DB_SELECT_1_Query1", q31);

            #endregion

            #region R2900_00_DATA_REFERENCIA_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_DATA_REFERENCIA_DB_SELECT_1_Query1", q32);

            #endregion

            #region R2900_00_DATA_REFERENCIA_DB_SELECT_2_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_DATA_REFERENCIA_DB_SELECT_2_Query1", q33);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("STSASSE_FILE_NAME_P")]
        public static void VG0852B_Tests_Theory(string STSASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            STSASSE_FILE_NAME_P = $"{STSASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("VG0852B_CHISTCB");
                
                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "123456"},
                { "PROPOVA_NUM_APOLICE" , "0000000001020"},
                { "PROPOVA_COD_SUBGRUPO" , "1111"},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , "2"},
                { "PRODUVG_ORIG_PRODU" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0852B_CHISTCB", q5);

                AppSettings.TestSet.DynamicData.Remove("VG0852B_CONT_PEN");
                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_NUM_PARCELA" , ""},
                { "COBHISVI_OPCAO_PAGAMENTO" , ""},
                { "COBHISVI_SIT_REGISTRO" , "2"},
                { "COBHISVI_DATA_VENCIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0852B_CONT_PEN", q6);

                AppSettings.TestSet.DynamicData.Remove("R100_00_PROCESSA_DATA_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTVENFIM_VE" , ""},
                { "V1SIST_DTVENFIM_CN" , "2024-11-22"},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R100_00_PROCESSA_DATA_DB_SELECT_1_Query1", q1);


                AppSettings.TestSet.DynamicData.Remove("R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "COBHISVI_NUM_PARCELA" , ""},
                    { "COBHISVI_OPCAO_PAGAMENTO" , ""},
                    { "COBHISVI_SIT_REGISTRO" , ""},
                    { "COBHISVI_DATA_VENCIMENTO" , "2020-11-22"},
                });
                AppSettings.TestSet.DynamicData.Add("R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1", q7);

                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1");
                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , "1"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1", q20);

                AppSettings.TestSet.DynamicData.Remove("VG0852B_CSEGURA");
                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , "2"},
                { "SEGURVGA_COD_FONTE" , ""},
                { "SEGURVGA_TIPO_INCLUSAO" , ""},
                { "SEGURVGA_COD_AGENCIADOR" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0852B_CSEGURA", q15);
                #endregion
                var program = new VG0852B();
                program.Execute(STSASSE_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R310_00_INSE_ARG_SIVPF_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2_Update1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R1700_00_CANC_PARC_DB_UPDATE_1_Update1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R1700_00_CANC_PARC_DB_UPDATE_2_Update1"].DynamicList;
                var envList8 = AppSettings.TestSet.DynamicData["R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1"].DynamicList;
                var envList9 = AppSettings.TestSet.DynamicData["R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
                var envList10 = AppSettings.TestSet.DynamicData["R2050_00_INSERT_MOV_DB_INSERT_1_Insert1"].DynamicList;
                var envList11 = AppSettings.TestSet.DynamicData["R2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);
                Assert.True(envList8?.Count > 1);
                Assert.True(envList9?.Count > 1);
                Assert.True(envList10?.Count > 1);
                Assert.True(envList11?.Count > 1);

                Assert.True(envList[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out string valor) && valor == "0004");
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out valor) && valor == "000000001");
                Assert.True(envList2[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out valor) && valor == "000000000123456");
                Assert.True(envList3[1].TryGetValue("PROPOVA_COD_SUBGRUPO", out valor) && valor == "1111");
                Assert.True(envList4[1].TryGetValue("PROPOVA_NUM_APOLICE", out valor) && valor == "0000000001020");
                Assert.True(envList5[1].TryGetValue("PROPOVA_NUM_APOLICE", out valor) && valor == "0000000001020");
                Assert.True(envList6[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out valor) && valor == "000000000123456");
                Assert.True(envList7[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out valor) && valor == "000000000123456");
                Assert.True(envList8[1].TryGetValue("PROPOFID_NUM_IDENTIFICACAO", out valor) && valor == "000000000000001");
                Assert.True(envList9[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out valor) && valor == "000000000123456");
                Assert.True(envList10[1].TryGetValue("SEGURVGA_NUM_CERTIFICADO", out valor) && valor == "000000000000002");
                Assert.True(envList11[1].TryGetValue("FONTES_ULT_PROP_AUTOMAT", out valor) && valor == "000000001");
            }
        }
    }
}