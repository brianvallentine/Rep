using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0605B;
using Sias.PessoaFisica.DB2.PF0605B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0605B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0605B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "79587"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region PF0605B_PROPOSTA_FIDELIZ

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , "80205060000023"},
                { "DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO" , "88142191"},
                { "DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_COD_PESSOA" , "17274014"},
                { "DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "95697378612"},
                { "DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA" , "2022-11-24"},
                { "DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF" , "6"},
                { "DCLPROPOSTA_FIDELIZ_AGECOBR" , "205"},
                { "DCLPROPOSTA_FIDELIZ_DIA_DEBITO" , "20"},
                { "DCLPROPOSTA_FIDELIZ_OPCAOPAG" , "1"},
                { "DCLPROPOSTA_FIDELIZ_AGECTADEB" , "205"},
                { "DCLPROPOSTA_FIDELIZ_OPRCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_NUMCTADEB" , "1864"},
                { "DCLPROPOSTA_FIDELIZ_DIGCTADEB" , "6"},
                { "DCLPROPOSTA_FIDELIZ_PERC_DESCONTO" , "0.00"},
                { "DCLPROPOSTA_FIDELIZ_NRMATRVEN" , "817698"},
                { "DCLPROPOSTA_FIDELIZ_AGECTAVEN" , "0"},
                { "DCLPROPOSTA_FIDELIZ_OPRCTAVEN" , "0"},
                { "DCLPROPOSTA_FIDELIZ_NUMCTAVEN" , "0"},
                { "DCLPROPOSTA_FIDELIZ_DIGCTAVEN" , "32"},
                { "DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE" , "0"},
                { "DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE" , "                                        "},
                { "DCLPROPOSTA_FIDELIZ_NRMATRCON" , "0"},
                { "DCLPROPOSTA_FIDELIZ_DTQITBCO" , "2022-11-24"},
                { "DCLPROPOSTA_FIDELIZ_VAL_PAGO" , "41.68"},
                { "DCLPROPOSTA_FIDELIZ_AGEPGTO" , "0"},
                { "DCLPROPOSTA_FIDELIZ_VAL_TARIFA" , "0.00"},
                { "DCLPROPOSTA_FIDELIZ_VAL_IOF" , "0.00"},
                { "DCLPROPOSTA_FIDELIZ_DATA_CREDITO" , "2022-11-28"},
                { "DCLPROPOSTA_FIDELIZ_VAL_COMISSAO" , "0.00"},
                { "DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA" , "EMT"},
                { "DCLPROPOSTA_FIDELIZ_COD_USUARIO" , "PF0709B "},
                { "DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA" , "8"},
                { "DCLPROPOSTA_FIDELIZ_NSAS_SIVPF" , "79445"},
                { "DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA" , "8"},
                { "DCLPROPOSTA_FIDELIZ_NSL" , "60842"},
                { "DCLPROPOSTA_FIDELIZ_NSAC_SIVPF" , "5721"},
                { "DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO" , "S"},
                { "DATA_LIB_STA_PEN" , "2023-03-05"},
                { "DCLPROPOSTA_FIDELIZ_COD_PLANO" , "0"},
                { "DCLIDENTIFICA_RELAC_IDENTREL_COD_RELAC" , "1"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , "80417060000011"},
                { "DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO" , "88142197"},
                { "DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_COD_PESSOA" , "25731209"},
                { "DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "95697376067"},
                { "DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA" , "2022-11-24"},
                { "DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF" , "6"},
                { "DCLPROPOSTA_FIDELIZ_AGECOBR" , "414"},
                { "DCLPROPOSTA_FIDELIZ_DIA_DEBITO" , "20"},
                { "DCLPROPOSTA_FIDELIZ_OPCAOPAG" , "1"},
                { "DCLPROPOSTA_FIDELIZ_AGECTADEB" , "3108"},
                { "DCLPROPOSTA_FIDELIZ_OPRCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_NUMCTADEB" , "1864"},
                { "DCLPROPOSTA_FIDELIZ_DIGCTADEB" , "6"},
                { "DCLPROPOSTA_FIDELIZ_PERC_DESCONTO" , "0.00"},
                { "DCLPROPOSTA_FIDELIZ_NRMATRVEN" , "817698"},
                { "DCLPROPOSTA_FIDELIZ_AGECTAVEN" , "0"},
                { "DCLPROPOSTA_FIDELIZ_OPRCTAVEN" , "0"},
                { "DCLPROPOSTA_FIDELIZ_NUMCTAVEN" , "0"},
                { "DCLPROPOSTA_FIDELIZ_DIGCTAVEN" , "32"},
                { "DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE" , "0"},
                { "DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE" , "                                        "},
                { "DCLPROPOSTA_FIDELIZ_NRMATRCON" , "0"},
                { "DCLPROPOSTA_FIDELIZ_DTQITBCO" , "2022-11-24"},
                { "DCLPROPOSTA_FIDELIZ_VAL_PAGO" , "41.68"},
                { "DCLPROPOSTA_FIDELIZ_AGEPGTO" , "0"},
                { "DCLPROPOSTA_FIDELIZ_VAL_TARIFA" , "0.00"},
                { "DCLPROPOSTA_FIDELIZ_VAL_IOF" , "0.00"},
                { "DCLPROPOSTA_FIDELIZ_DATA_CREDITO" , "2022-11-28"},
                { "DCLPROPOSTA_FIDELIZ_VAL_COMISSAO" , "0.00"},
                { "DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA" , "EMT"},
                { "DCLPROPOSTA_FIDELIZ_COD_USUARIO" , "PF0709B "},
                { "DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA" , "8"},
                { "DCLPROPOSTA_FIDELIZ_NSAS_SIVPF" , "79445"},
                { "DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA" , "8"},
                { "DCLPROPOSTA_FIDELIZ_NSL" , "60842"},
                { "DCLPROPOSTA_FIDELIZ_NSAC_SIVPF" , "5721"},
                { "DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO" , "S"},
                { "DATA_LIB_STA_PEN" , "2023-03-05"},
                { "DCLPROPOSTA_FIDELIZ_COD_PLANO" , "0"},
                { "DCLIDENTIFICA_RELAC_IDENTREL_COD_RELAC" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("PF0605B_PROPOSTA_FIDELIZ", q2);

            #endregion

            #region R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2_Update1", q4);

            #endregion

            #region R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""},
                { "PROPFIDH_DATA_SITUACAO" , ""},
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPFIDH_SIT_COBRANCA_SIVPF" , ""},
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , ""},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , ""},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1", q5);

            #endregion

            #region M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "COD_PRODUTO" , ""},
                { "APOLICES_NUM_APOLICE" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
                { "COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1", q6);

            #endregion

            #region PF0605B_ERROS_PROP_VIDAZUL

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_NUM_CERTIFICADO" , "95689840051"},
                { "ERRPROVI_COD_ERRO" , "6"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_NUM_CERTIFICADO" , "95702328762"},
                { "ERRPROVI_COD_ERRO" , "6"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_NUM_CERTIFICADO" , "84148370001311"},
                { "ERRPROVI_COD_ERRO" , "6"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0605B_ERROS_PROP_VIDAZUL", q7);

            #endregion

            #region R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ERROVDAZ_COD_ERRO" , ""},
                { "ERROVDAZ_COD_ERRO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1", q8);

            #endregion

            #region PF0605B_BILHETE_ERROS

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ERROSBIL_NUM_BILHETE" , ""},
                { "ERROSBIL_COD_ERRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0605B_BILHETE_ERROS", q9);

            #endregion

            #region R0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CODERRBI_COD_ERRO" , ""},
                { "CODERRBI_COD_ERRO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_DATA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_DATA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2_Query1", q12);

            #endregion

            #region R0220_00_LER_BILHETE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "50084506666825"},
                { "BILHETE_NUM_APOLICE" , "108209802928"},
                { "BILHETE_NUM_APOL_ANTERIOR" , "84621729338"},
                { "BILHETE_OPC_COBERTURA" , "1"},
                { "BILHETE_DATA_QUITACAO" , "2001-12-14"},
                { "BILHETE_VAL_RCAP" , "251.80"},
                { "BILHETE_RAMO" , "72"},
                { "BILHETE_SITUACAO" , "P"},
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_LER_BILHETE_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0230_00_LER_ENDOSSO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "108209802928"},
                { "ENDOSSOS_NUM_ENDOSSO" , "0"},
                { "ENDOSSOS_NUM_PROPOSTA" , "21027672"},
                { "ENDOSSOS_DATA_PROPOSTA" , "2007-09-18"},
                { "ENDOSSOS_DATA_EMISSAO" , "2007-09-18"},
                { "ENDOSSOS_NUM_RCAP" , "825929830"},
                { "ENDOSSOS_VAL_RCAP" , "66.30"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2007-07-19"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2008-07-19"},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_LER_ENDOSSO_DB_SELECT_1_Query1", q14);

            #endregion

            #region PF0605B_BILHETE_COBERTURA

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_COD_PRODUTO" , "7106"},
                { "BILCOBER_RAMO_COBERTURA" , "72"},
                { "BILCOBER_MODALI_COBERTURA" , "0"},
                { "BILCOBER_COD_OPCAO_PLANO" , "1"},
                { "BILCOBER_COD_COBERTURA" , "2000"},
                { "BILCOBER_DATA_INIVIGENCIA" , "1995-03-01"},
                { "BILCOBER_DATA_TERVIGENCIA" , "1996-10-17"},
                { "BILCOBER_IDE_COBERTURA" , "1"},
                { "BILCOBER_VAL_COBERTURA_IX" , "20000"},
                { "BILCOBER_PRM_TOTAL" , "41,6"},
                { "BILCOBER_PCT_IOCC" , "4"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0605B_BILHETE_COBERTURA", q15);

            #endregion

            #region PF0605B_BILHETE_COBER

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_COD_PRODUTO" , ""},
                { "BILCOBER_RAMO_COBERTURA" , ""},
                { "BILCOBER_MODALI_COBERTURA" , ""},
                { "BILCOBER_COD_OPCAO_PLANO" , ""},
                { "BILCOBER_COD_COBERTURA" , ""},
                { "BILCOBER_DATA_INIVIGENCIA" , ""},
                { "BILCOBER_DATA_TERVIGENCIA" , ""},
                { "BILCOBER_IDE_COBERTURA" , ""},
                { "BILCOBER_VAL_COBERTURA_IX" , ""},
                { "BILCOBER_PRM_TOTAL" , ""},
                { "BILCOBER_PCT_IOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0605B_BILHETE_COBER", q16);

            #endregion

            #region R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAP_DAC_CERTIFICADO" , ""},
                { "SEGVGAP_NUM_APOLICE" , "97010000889"},
                { "SEGVGAP_COD_SUBGRUPO" , "1949"},
                { "SEGVGAP_NUM_ITEM" , "874876"},
                { "SEGVGAP_OCORR_HISTORICO" , "2"},
                { "SEGVGAP_DATA_INIVIGENCIA" , "2001-12-14"},
                { "WDTA_TERVG_CALC" , "2002-12-14"},
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAP_DAC_CERTIFICADO" , ""},
                { "SEGVGAP_NUM_APOLICE" , "97010000889"},
                { "SEGVGAP_COD_SUBGRUPO" , "1949"},
                { "SEGVGAP_NUM_ITEM" , "874876"},
                { "SEGVGAP_OCORR_HISTORICO" , "2"},
                { "SEGVGAP_DATA_INIVIGENCIA" , "2001-12-14"},
                { "WDTA_TERVG_CALC" , "2002-12-14"},
            });
            AppSettings.TestSet.DynamicData.Add("R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_OPERACAO" , ""},
                { "SEGVGAPH_DATA_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0520_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , "50084506666825"},
                { "DATA_INIVIGENCIA" , "2001-12-14"},
                { "DATA_TERVIGENCIA" , "9999-12-31"},
                { "IMPSEGUR" , "40000.00"},
                { "IMP_MORNATU" , "40000.00"},
                { "IMPMORACID" , "80000.00"},
                { "IMPINVPERM" , "40000.00"},
                { "IMPAMDS" , "0"},
                { "IMPDH" , "0"},
                { "IMPDIT" , "0"},
                { "VLPREMIO" , "251.80"},
                { "PRMVG" , "176.30"},
                { "PRMAP" , "75.50"},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0523_00_ACESSA_PROP_SASSE_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_APOLICE" , "97010000889"},
                { "PROPSSVD_COD_SUBGRUPO" , "4190"},
            });
            AppSettings.TestSet.DynamicData.Add("R0523_00_ACESSA_PROP_SASSE_DB_SELECT_1_Query1", q20);

            #endregion

            #region R0525_00_ACESSA_APOLICE_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "97"}
            });
            q21.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "97"}
            });
            q21.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "97"}
            });
            AppSettings.TestSet.DynamicData.Add("R0525_00_ACESSA_APOLICE_DB_SELECT_1_Query1", q21);

            #endregion

            #region R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "7.00"}
            });
            q22.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "7.00"}
            });
            q22.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "7.00"}
            });
            q22.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "7.00"}
            });
            AppSettings.TestSet.DynamicData.Add("R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1", q22);

            #endregion

            #region R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "COD_PRODUTO" , "9705"},
                { "DATA_MOVIMENTO" , "2002-12-24"},
                { "IDE_SEXO" , "M"},
                { "COD_OPERACAO" , "403"},
                { "DATA_QUITACAO" , "2001-12-14"},
            });
            q23.AddDynamic(new Dictionary<string, string>{
                { "COD_PRODUTO" , "9705"},
                { "DATA_MOVIMENTO" , "2002-12-24"},
                { "IDE_SEXO" , "M"},
                { "COD_OPERACAO" , "403"},
                { "DATA_QUITACAO" , "2001-12-14"},
            });
            q23.AddDynamic(new Dictionary<string, string>{
                { "COD_PRODUTO" , "9705"},
                { "DATA_MOVIMENTO" , "2002-12-24"},
                { "IDE_SEXO" , "M"},
                { "COD_OPERACAO" , "403"},
                { "DATA_QUITACAO" , "2001-12-14"},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1", q23);

            #endregion

            #region R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "12"}
            });
            q24.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "12"}
            });
            q24.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "12"}
            });

            AppSettings.TestSet.DynamicData.Add("R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1", q24);

            #endregion

            #region R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "MOVVGAP_NUM_APOLICE" , "97010000889"},
                { "MOVVGAP_COD_SUBGRUPO" , "4190"},
                { "MOVVGAP_COD_FONTE" , "5"},
                { "MOVVGAP_NUM_PROPOSTA" , "9361427"},
                { "MOVVGAP_TIPO_SEGURADO" , "1"},
                { "MOVVGAP_NUM_CERTIFICADO" , "84820002055"},
                { "MOVVGAP_DAC_CERTIFICADO" , " "},
                { "MOVVGAP_IDE_SEXO" , "M"},
                { "MOVVGAP_PCT_CONJUGE_VG" , "0.00"},
                { "MOVVGAP_PCT_CONJUGE_AP" , "0.00"},
                { "MOVVGAP_QTD_SAL_MORNATU" , "0"},
                { "MOVVGAP_QTD_SAL_MORACID" , "0"},
                { "MOVVGAP_QTD_SAL_INVPERM" , "0"},
                { "MOVVGAP_TAXA_AP_MORACID" , "0.1000"},
                { "MOVVGAP_TAXA_AP_INVPERM" , "0.1000"},
                { "MOVVGAP_TAXA_AP_AMDS" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DH" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DIT" , "0.0000"},
                { "MOVVGAP_TAXA_VG" , "1.0473"},
                { "MOVVGAP_IMP_MORNATU_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORNATU_ATU" , "25000.00"},
                { "MOVVGAP_IMP_MORACID_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORACID_ATU" , "25000.00"},
                { "MOVVGAP_IMP_INVPERM_ANT" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ATU" , "25000.00"},
                { "MOVVGAP_IMP_AMDS_ANT" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ATU" , "0.00"},
                { "MOVVGAP_IMP_DH_ANT" , "0.00"},
                { "MOVVGAP_IMP_DH_ATU" , "0.00"},
                { "MOVVGAP_IMP_DIT_ANT" , "0.00"},
                { "MOVVGAP_IMP_DIT_ATU" , "0.00"},
                { "MOVVGAP_PRM_VG_ANT" , "0.00"},
                { "MOVVGAP_PRM_VG_ATU" , "26.00"},
                { "MOVVGAP_PRM_AP_ANT" , "0.00"},
                { "MOVVGAP_PRM_AP_ATU" , "5.00"},
                { "MOVVGAP_COD_OPERACAO" , "102"},
                { "MOVVGAP_DATA_OPERACAO" , "1998-11-27"},
                { "MOVVGAP_DATA_REFERENCIA" , "1998-12-01"},
                { "MOVVGAP_DATA_MOVIMENTO" , "1998-12-01"},
                { "MOVVGAP_COD_SUBGRUPO_TRANS" , "0"},
                { "MOVVGAP_SIT_REGISTRO" , "1"},
                { "MOVVGAP_COD_USUARIO" , "VA0118B"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "MOVVGAP_NUM_APOLICE" , "97010000889"},
                { "MOVVGAP_COD_SUBGRUPO" , "4190"},
                { "MOVVGAP_COD_FONTE" , "5"},
                { "MOVVGAP_NUM_PROPOSTA" , "9336276"},
                { "MOVVGAP_TIPO_SEGURADO" , "1"},
                { "MOVVGAP_NUM_CERTIFICADO" , "84820002055"},
                { "MOVVGAP_DAC_CERTIFICADO" , " "},
                { "MOVVGAP_IDE_SEXO" , "M"},
                { "MOVVGAP_PCT_CONJUGE_VG" , "0.00"},
                { "MOVVGAP_PCT_CONJUGE_AP" , "0.00"},
                { "MOVVGAP_QTD_SAL_MORNATU" , "0"},
                { "MOVVGAP_QTD_SAL_MORACID" , "0"},
                { "MOVVGAP_QTD_SAL_INVPERM" , "0"},
                { "MOVVGAP_TAXA_AP_MORACID" , "0.1000"},
                { "MOVVGAP_TAXA_AP_INVPERM" , "0.1000"},
                { "MOVVGAP_TAXA_AP_AMDS" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DH" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DIT" , "0.0000"},
                { "MOVVGAP_TAXA_VG" , "1.0473"},
                { "MOVVGAP_IMP_MORNATU_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORNATU_ATU" , "25000.00"},
                { "MOVVGAP_IMP_MORACID_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORACID_ATU" , "25000.00"},
                { "MOVVGAP_IMP_INVPERM_ANT" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ATU" , "25000.00"},
                { "MOVVGAP_IMP_AMDS_ANT" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ATU" , "0.00"},
                { "MOVVGAP_IMP_DH_ANT" , "0.00"},
                { "MOVVGAP_IMP_DH_ATU" , "0.00"},
                { "MOVVGAP_IMP_DIT_ANT" , "0.00"},
                { "MOVVGAP_IMP_DIT_ATU" , "0.00"},
                { "MOVVGAP_PRM_VG_ANT" , "0.00"},
                { "MOVVGAP_PRM_VG_ATU" , "26.00"},
                { "MOVVGAP_PRM_AP_ANT" , "0.00"},
                { "MOVVGAP_PRM_AP_ATU" , "5.00"},
                { "MOVVGAP_COD_OPERACAO" , "102"},
                { "MOVVGAP_DATA_OPERACAO" , "1998-11-27"},
                { "MOVVGAP_DATA_REFERENCIA" , "1998-12-01"},
                { "MOVVGAP_DATA_MOVIMENTO" , "1998-12-01"},
                { "MOVVGAP_COD_SUBGRUPO_TRANS" , "0"},
                { "MOVVGAP_SIT_REGISTRO" , "1"},
                { "MOVVGAP_COD_USUARIO" , "VA0118B"}
            });
            AppSettings.TestSet.DynamicData.Add("R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1", q25);

            #endregion

            #region R0586_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "MOVVGAP_NUM_APOLICE" , ""},
                { "MOVVGAP_COD_SUBGRUPO" , ""},
                { "MOVVGAP_COD_FONTE" , ""},
                { "MOVVGAP_NUM_PROPOSTA" , ""},
                { "MOVVGAP_TIPO_SEGURADO" , ""},
                { "MOVVGAP_NUM_CERTIFICADO" , ""},
                { "MOVVGAP_DAC_CERTIFICADO" , ""},
                { "MOVVGAP_IDE_SEXO" , ""},
                { "MOVVGAP_PCT_CONJUGE_VG" , ""},
                { "MOVVGAP_PCT_CONJUGE_AP" , ""},
                { "MOVVGAP_QTD_SAL_MORNATU" , ""},
                { "MOVVGAP_QTD_SAL_MORACID" , ""},
                { "MOVVGAP_QTD_SAL_INVPERM" , ""},
                { "MOVVGAP_TAXA_AP_MORACID" , ""},
                { "MOVVGAP_TAXA_AP_INVPERM" , ""},
                { "MOVVGAP_TAXA_AP_AMDS" , ""},
                { "MOVVGAP_TAXA_AP_DH" , ""},
                { "MOVVGAP_TAXA_AP_DIT" , ""},
                { "MOVVGAP_TAXA_VG" , ""},
                { "MOVVGAP_IMP_MORNATU_ANT" , ""},
                { "MOVVGAP_IMP_MORNATU_ATU" , ""},
                { "MOVVGAP_IMP_MORACID_ANT" , ""},
                { "MOVVGAP_IMP_MORACID_ATU" , ""},
                { "MOVVGAP_IMP_INVPERM_ANT" , ""},
                { "MOVVGAP_IMP_INVPERM_ATU" , ""},
                { "MOVVGAP_IMP_AMDS_ANT" , ""},
                { "MOVVGAP_IMP_AMDS_ATU" , ""},
                { "MOVVGAP_IMP_DH_ANT" , ""},
                { "MOVVGAP_IMP_DH_ATU" , ""},
                { "MOVVGAP_IMP_DIT_ANT" , ""},
                { "MOVVGAP_IMP_DIT_ATU" , ""},
                { "MOVVGAP_PRM_VG_ANT" , ""},
                { "MOVVGAP_PRM_VG_ATU" , ""},
                { "MOVVGAP_PRM_AP_ANT" , ""},
                { "MOVVGAP_PRM_AP_ATU" , ""},
                { "MOVVGAP_COD_OPERACAO" , ""},
                { "MOVVGAP_DATA_OPERACAO" , ""},
                { "MOVVGAP_DATA_REFERENCIA" , ""},
                { "MOVVGAP_DATA_MOVIMENTO" , ""},
                { "MOVVGAP_COD_SUBGRUPO_TRANS" , ""},
                { "MOVVGAP_SIT_REGISTRO" , ""},
                { "MOVVGAP_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0586_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1", q26);

            #endregion

            #region R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , "97010000889"},
                { "APOLICOB_NUM_ITEM" , "0"},
                { "APOLICOB_NUM_ENDOSSO" , "200001"},
                { "APOLICOB_RAMO_COBERTURA" , "68"},
                { "APOLICOB_COD_COBERTURA" , "0"},
                { "APOLICOB_DATA_INIVIGENCIA" , "1999-01-01"},
                { "APOLICOB_DATA_TERVIGENCIA" , "1999-01-31"},
            });
            q27.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , "97010000889"},
                { "APOLICOB_NUM_ITEM" , "0"},
                { "APOLICOB_NUM_ENDOSSO" , "200001"},
                { "APOLICOB_RAMO_COBERTURA" , "68"},
                { "APOLICOB_COD_COBERTURA" , "0"},
                { "APOLICOB_DATA_INIVIGENCIA" , "1999-01-01"},
                { "APOLICOB_DATA_TERVIGENCIA" , "1999-01-31"},
            });
            AppSettings.TestSet.DynamicData.Add("R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1", q27);

            #endregion

            #region R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_APOL_ANTERIOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1", q28);

            #endregion

            #region R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q29);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q30);

            #endregion

            #endregion

            #region PARAMETERS_SUBVG0710S

            #region Execute_Query1
            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-09-02"},

            });
            AppSettings.TestSet.DynamicData.Add("Execute_Query1", q31);

            #endregion

            #region M_0040_ACESSA_COND_TEC_Query1
            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "0.0001"},
                { "TAXA_AP_INVPERM" , "0"},
                { "TAXA_AP_AMDS" , "0"},
                { "TAXA_AP_DH" , "0"},
                { "TAXA_AP_DIT" , "0"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "100"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},


            });
            AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TEC_Query1", q32);

            #endregion

            #region M_0070_ACESSA_APOLICE_Query1
            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0070_ACESSA_APOLICE_Query1", q33);

            #endregion


            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0605B.txt")]
        public static void PF0605B_Tests_Theory_Normal0(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0605B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                //R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val7r) && val7r.Contains("STASASSE"));
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val8r) && val8r.Contains("4"));
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out var val9r) && val9r.Contains("79588"));

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));

                
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);


                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("Saida_PF0605B.txt")]
        public static void PF0605B_Tests_Theory_Erro_9(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion

                var program = new PF0605B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("Saida_PF0605B.txt")]
        public static void PF0605B_Tests_Theory_Normal_0_SIVPF0(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                //Bilhete preenchido
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region PF0605B_PROPOSTA_FIDELIZ

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                        { "DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , "50084506666825"},
                        { "DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO" , "3663306"},
                        { "DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF" , "1"},
                        { "DCLPROPOSTA_FIDELIZ_COD_PESSOA" , "2321655"},
                        { "DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "50084506666825"},
                        { "DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA" , "2001-12-14"},
                        { "DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF" , "10"},
                        { "DCLPROPOSTA_FIDELIZ_AGECOBR" , "1594"},
                        { "DCLPROPOSTA_FIDELIZ_DIA_DEBITO" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_OPCAOPAG" , "1"},
                        { "DCLPROPOSTA_FIDELIZ_AGECTADEB" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_OPRCTADEB" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_NUMCTADEB" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_DIGCTADEB" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_PERC_DESCONTO" , "0.00"},
                        { "DCLPROPOSTA_FIDELIZ_NRMATRVEN" , "311651"},
                        { "DCLPROPOSTA_FIDELIZ_AGECTAVEN" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_OPRCTAVEN" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_NUMCTAVEN" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_DIGCTAVEN" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE" , "                                        "},
                        { "DCLPROPOSTA_FIDELIZ_NRMATRCON" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_DTQITBCO" , "2001-12-14"},
                        { "DCLPROPOSTA_FIDELIZ_VAL_PAGO" , "251.80"},
                        { "DCLPROPOSTA_FIDELIZ_AGEPGTO" , "1594"},
                        { "DCLPROPOSTA_FIDELIZ_VAL_TARIFA" , "1.30"},
                        { "DCLPROPOSTA_FIDELIZ_VAL_IOF" , "0.00"},
                        { "DCLPROPOSTA_FIDELIZ_DATA_CREDITO" , "2001-12-17"},
                        { "DCLPROPOSTA_FIDELIZ_VAL_COMISSAO" , "0.00"},
                        { "DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA" , "EMT"},
                        { "DCLPROPOSTA_FIDELIZ_COD_USUARIO" , "VA0118B "},
                        { "DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA" , "1"},
                        { "DCLPROPOSTA_FIDELIZ_NSAS_SIVPF" , "0"},
                        { "DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA" , "7"},
                        { "DCLPROPOSTA_FIDELIZ_NSL" , "1345"},
                        { "DCLPROPOSTA_FIDELIZ_NSAC_SIVPF" , "461"},
                        { "DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO" , "S"},
                        { "DATA_LIB_STA_PEN" , "2001-12-28"},
                        { "DCLPROPOSTA_FIDELIZ_COD_PLANO" , "0"},
                        { "DCLIDENTIFICA_RELAC_IDENTREL_COD_RELAC" , "8"}
                     });
                AppSettings.TestSet.DynamicData.Remove("PF0605B_PROPOSTA_FIDELIZ");
                AppSettings.TestSet.DynamicData.Add("PF0605B_PROPOSTA_FIDELIZ", q2);

                #endregion

                #endregion
                var program = new PF0605B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);


                //M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1

                //var envList = AppSettings.TestSet.DynamicData["M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList?.Count > 1);
                //Assert.True(envList[1].TryGetValue("NUM_PROPOSTA_SIVPF", out var val4r) && val4r.Contains("50084506666825"));
                //Assert.True(envList[1].TryGetValue("APOLICES_NUM_APOLICE", out var val5r) && val5r.Contains("97010000889"));

                ////R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2_Update1
                //var envList0 = AppSettings.TestSet.DynamicData["R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2_Update1"].DynamicList;
                //Assert.True(envList0[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var valor) && valor.Contains("79588"));
                //Assert.True(envList0[1].TryGetValue("PROPFIDH_NSL", out var val2r) && val2r.Contains("1"));
                

                ////R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1
                //var envList3 = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList3?.Count > 1);
                //Assert.True(envList3[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val7r) && val7r.Contains("STASASSE"));
                //Assert.True(envList3[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val8r) && val8r.Contains("4"));
                //Assert.True(envList3[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out var val9r) && val9r.Contains("79588"));


                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}