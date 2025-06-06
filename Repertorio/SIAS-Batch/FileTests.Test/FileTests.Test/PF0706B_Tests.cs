using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0706B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0706B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0706B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2023-03-03"},
                { "WHOST_DATA_REF_CURSOR" , "2023-02-21"},
            });
            AppSettings.TestSet.DynamicData.Add("R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "1726"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region PF0706B_C01_BILHETE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                {"DCLBILHETE_BILHETE_NUM_BILHETE" ,"82620426840"},
                {"DCLBILHETE_BILHETE_NUM_APOLICE" ,"108103929617"},
                {"DCLBILHETE_BILHETE_FONTE" ,"15"},
                {"DCLBILHETE_BILHETE_AGE_COBRANCA" ,"910"},
                {"DCLBILHETE_BILHETE_NUM_MATRICULA" ,"1005927"},
                {"DCLBILHETE_BILHETE_COD_AGENCIA" ,"0"},
                {"DCLBILHETE_BILHETE_OPERACAO_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_NUM_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_DIG_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_COD_CLIENTE" ,"7261010"},
                {"DCLBILHETE_BILHETE_PROFISSAO" , "APOSENTADO EXCETO F "},
                {"DCLBILHETE_BILHETE_IDE_SEXO" , "M "},
                {"DCLBILHETE_BILHETE_ESTADO_CIVIL" , "C "},
                {"DCLBILHETE_BILHETE_OCORR_ENDERECO" ,"1"},
                {"DCLBILHETE_BILHETE_COD_AGENCIA_DEB" ,"910"},
                {"DCLBILHETE_BILHETE_OPERACAO_CONTA_DEB" ,"1"},
                {"DCLBILHETE_BILHETE_NUM_CONTA_DEB" ,"3457"},
                {"DCLBILHETE_BILHETE_DIG_CONTA_DEB" ,"1"},
                {"DCLBILHETE_BILHETE_OPC_COBERTURA" ,"11"},
                {"DCLBILHETE_BILHETE_DATA_QUITACAO" , "2022-11-12 "},
                {"DCLBILHETE_BILHETE_VAL_RCAP" ,"60.00"},
                {"DCLBILHETE_BILHETE_RAMO" ,"81"},
                {"DCLBILHETE_BILHETE_DATA_VENDA" , "2022-11-12 "},
                {"DCLBILHETE_BILHETE_DATA_MOVIMENTO" , "2022-08-05 "},
                {"DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR" ,"82619736440"},
                {"DCLBILHETE_BILHETE_SITUACAO" , "8 "},
                {"DCLBILHETE_BILHETE_TIP_CANCELAMENTO" , "1 "},
                {"DCLBILHETE_BILHETE_SIT_SINISTRO" , "0 "},
                {"DCLBILHETE_BILHETE_COD_USUARIO" , "CVT03203 "},
                {"WHOST_DATA_REFERENCIA" , "2023-03-03 "},
                {"DCLBILHETE_BILHETE_DATA_CANCELAMENTO" , "2023-03-04"} 
            });
            q3.AddDynamic(new Dictionary<string, string>{
                {"DCLBILHETE_BILHETE_NUM_BILHETE" ,"82620448941"},
                {"DCLBILHETE_BILHETE_NUM_APOLICE" ,"108211472078"},
                {"DCLBILHETE_BILHETE_FONTE" ,"15"},
                {"DCLBILHETE_BILHETE_AGE_COBRANCA" ,"910"},
                {"DCLBILHETE_BILHETE_NUM_MATRICULA" ,"518079"},
                {"DCLBILHETE_BILHETE_COD_AGENCIA" ,"0"},
                {"DCLBILHETE_BILHETE_OPERACAO_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_NUM_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_DIG_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_COD_CLIENTE" ,"7261010"},
                {"DCLBILHETE_BILHETE_PROFISSAO" , "APOSENTADO EXCETO F "},
                {"DCLBILHETE_BILHETE_IDE_SEXO" , "M "},
                {"DCLBILHETE_BILHETE_ESTADO_CIVIL" , "C "},
                {"DCLBILHETE_BILHETE_OCORR_ENDERECO" ,"1"},
                {"DCLBILHETE_BILHETE_COD_AGENCIA_DEB" ,"910"},
                {"DCLBILHETE_BILHETE_OPERACAO_CONTA_DEB" ,"1"},
                {"DCLBILHETE_BILHETE_NUM_CONTA_DEB" ,"3457"},
                {"DCLBILHETE_BILHETE_DIG_CONTA_DEB" ,"1"},
                {"DCLBILHETE_BILHETE_OPC_COBERTURA" ,"11"},
                {"DCLBILHETE_BILHETE_DATA_QUITACAO" , "2022-11-12 "},
                {"DCLBILHETE_BILHETE_VAL_RCAP" ,"60.00"},
                {"DCLBILHETE_BILHETE_RAMO" ,"81"},
                {"DCLBILHETE_BILHETE_DATA_VENDA" , "2022-11-12 "},
                {"DCLBILHETE_BILHETE_DATA_MOVIMENTO" , "2022-08-05 "},
                {"DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR" ,"82619736440"},
                {"DCLBILHETE_BILHETE_SITUACAO" , "8 "},
                {"DCLBILHETE_BILHETE_TIP_CANCELAMENTO" , "1 "},
                {"DCLBILHETE_BILHETE_SIT_SINISTRO" , "0 "},
                {"DCLBILHETE_BILHETE_COD_USUARIO" , "CVT03203 "},
                {"WHOST_DATA_REFERENCIA" , "2023-03-03 "},
                {"DCLBILHETE_BILHETE_DATA_CANCELAMENTO" , "2023-03-04"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                {"DCLBILHETE_BILHETE_NUM_BILHETE" ,"82620426830"},
                {"DCLBILHETE_BILHETE_NUM_APOLICE" ,"108211472078"},
                {"DCLBILHETE_BILHETE_FONTE" ,"15"},
                {"DCLBILHETE_BILHETE_AGE_COBRANCA" ,"4146"},
                {"DCLBILHETE_BILHETE_NUM_MATRICULA" ,"518079"},
                {"DCLBILHETE_BILHETE_COD_AGENCIA" ,"0"},
                {"DCLBILHETE_BILHETE_OPERACAO_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_NUM_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_DIG_CONTA" ,"0"},
                {"DCLBILHETE_BILHETE_COD_CLIENTE" ,"7261010"},
                {"DCLBILHETE_BILHETE_PROFISSAO" , "APOSENTADO EXCETO F "},
                {"DCLBILHETE_BILHETE_IDE_SEXO" , "M "},
                {"DCLBILHETE_BILHETE_ESTADO_CIVIL" , "C "},
                {"DCLBILHETE_BILHETE_OCORR_ENDERECO" ,"1"},
                {"DCLBILHETE_BILHETE_COD_AGENCIA_DEB" ,"910"},
                {"DCLBILHETE_BILHETE_OPERACAO_CONTA_DEB" ,"1"},
                {"DCLBILHETE_BILHETE_NUM_CONTA_DEB" ,"3457"},
                {"DCLBILHETE_BILHETE_DIG_CONTA_DEB" ,"1"},
                {"DCLBILHETE_BILHETE_OPC_COBERTURA" ,"11"},
                {"DCLBILHETE_BILHETE_DATA_QUITACAO" , "2022-11-12 "},
                {"DCLBILHETE_BILHETE_VAL_RCAP" ,"60.00"},
                {"DCLBILHETE_BILHETE_RAMO" ,"81"},
                {"DCLBILHETE_BILHETE_DATA_VENDA" , "2022-11-12 "},
                {"DCLBILHETE_BILHETE_DATA_MOVIMENTO" , "2022-08-05 "},
                {"DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR" ,"82619736440"},
                {"DCLBILHETE_BILHETE_SITUACAO" , "8 "},
                {"DCLBILHETE_BILHETE_TIP_CANCELAMENTO" , "1 "},
                {"DCLBILHETE_BILHETE_SIT_SINISTRO" , "0 "},
                {"DCLBILHETE_BILHETE_COD_USUARIO" , "CVT03203 "},
                {"WHOST_DATA_REFERENCIA" , "2023-03-03 "},
                {"DCLBILHETE_BILHETE_DATA_CANCELAMENTO" , "2023-03-04"}
            });
            AppSettings.TestSet.DynamicData.Add("PF0706B_C01_BILHETE", q3);

            #endregion

            #region R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                {"PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058940"},
                {"PROPOFID_NUM_IDENTIFICACAO" , "1"},
                {"PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                {"PROPOFID_COD_PESSOA" , "1"},
                {"PROPOFID_NUM_SICOB" , "80000000017"},
                {"PROPOFID_DATA_PROPOSTA" ,  "2000-02-14 "},
                {"PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                {"PROPOFID_AGECOBR" , "55"},
                {"PROPOFID_DIA_DEBITO" , "14"},
                {"PROPOFID_OPCAOPAG" ,  "1 "},
                {"PROPOFID_AGECTADEB" , "55"},
                {"PROPOFID_OPRCTADEB" , "1"},
                {"PROPOFID_NUMCTADEB" , "47247"},
                {"PROPOFID_DIGCTADEB" , "4"},
                {"PROPOFID_PERC_DESCONTO" , "0.00"},
                {"PROPOFID_NRMATRVEN" , "262131"},
                {"PROPOFID_AGECTAVEN" , "55"},
                {"PROPOFID_OPRCTAVEN" , "1"},
                {"PROPOFID_NUMCTAVEN" , "42953"},
                {"PROPOFID_DIGCTAVEN" , "6"},
                {"PROPOFID_CGC_CONVENENTE" , "0"},
                {"PROPOFID_NOME_CONVENENTE" ,  "                                         "},
                {"PROPOFID_NRMATRCON" , "0"},
                {"PROPOFID_DTQITBCO" ,  "2000-02-14 "},
                {"PROPOFID_VAL_PAGO" , "300.00"},
                {"PROPOFID_AGEPGTO" , "55"},
                {"PROPOFID_VAL_TARIFA" , "3.30"},
                {"PROPOFID_VAL_IOF" , "0.00"},
                {"PROPOFID_DATA_CREDITO" ,  "2000-02-15 "},
                {"PROPOFID_VAL_COMISSAO" , "0.00"},
                {"PROPOFID_SIT_PROPOSTA" ,  "EMT "},
                {"PROPOFID_COD_USUARIO" ,  "PF0600B  "},
                {"PROPOFID_CANAL_PROPOSTA" , "1"},
                {"PROPOFID_NSAS_SIVPF" , "835"},
                {"PROPOFID_ORIGEM_PROPOSTA" , "6"},
                {"PROPOFID_NSL" , "5520"},
                {"PROPOFID_NSAC_SIVPF" , "4"},
                {"PROPOFID_SITUACAO_ENVIO" ,  "R "}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                {"PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058941"},
                {"PROPOFID_NUM_IDENTIFICACAO" , "1"},
                {"PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                {"PROPOFID_COD_PESSOA" , "1"},
                {"PROPOFID_NUM_SICOB" , "80000000017"},
                {"PROPOFID_DATA_PROPOSTA" ,  "2000-02-14 "},
                {"PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                {"PROPOFID_AGECOBR" , "55"},
                {"PROPOFID_DIA_DEBITO" , "14"},
                {"PROPOFID_OPCAOPAG" ,  "1 "},
                {"PROPOFID_AGECTADEB" , "55"},
                {"PROPOFID_OPRCTADEB" , "1"},
                {"PROPOFID_NUMCTADEB" , "47247"},
                {"PROPOFID_DIGCTADEB" , "4"},
                {"PROPOFID_PERC_DESCONTO" , "0.00"},
                {"PROPOFID_NRMATRVEN" , "262131"},
                {"PROPOFID_AGECTAVEN" , "55"},
                {"PROPOFID_OPRCTAVEN" , "1"},
                {"PROPOFID_NUMCTAVEN" , "42953"},
                {"PROPOFID_DIGCTAVEN" , "6"},
                {"PROPOFID_CGC_CONVENENTE" , "0"},
                {"PROPOFID_NOME_CONVENENTE" ,  "                                         "},
                {"PROPOFID_NRMATRCON" , "0"},
                {"PROPOFID_DTQITBCO" ,  "2000-02-14 "},
                {"PROPOFID_VAL_PAGO" , "300.00"},
                {"PROPOFID_AGEPGTO" , "55"},
                {"PROPOFID_VAL_TARIFA" , "3.30"},
                {"PROPOFID_VAL_IOF" , "0.00"},
                {"PROPOFID_DATA_CREDITO" ,  "2000-02-15 "},
                {"PROPOFID_VAL_COMISSAO" , "0.00"},
                {"PROPOFID_SIT_PROPOSTA" ,  "EMT "},
                {"PROPOFID_COD_USUARIO" ,  "PF0600B  "},
                {"PROPOFID_CANAL_PROPOSTA" , "1"},
                {"PROPOFID_NSAS_SIVPF" , "835"},
                {"PROPOFID_ORIGEM_PROPOSTA" , "6"},
                {"PROPOFID_NSL" , "5520"},
                {"PROPOFID_NSAC_SIVPF" , "4"},
                {"PROPOFID_SITUACAO_ENVIO" ,  "R "}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                {"PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058942"},
                {"PROPOFID_NUM_IDENTIFICACAO" , "1"},
                {"PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                {"PROPOFID_COD_PESSOA" , "1"},
                {"PROPOFID_NUM_SICOB" , "80000000017"},
                {"PROPOFID_DATA_PROPOSTA" ,  "2000-02-14 "},
                {"PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                {"PROPOFID_AGECOBR" , "55"},
                {"PROPOFID_DIA_DEBITO" , "14"},
                {"PROPOFID_OPCAOPAG" ,  "1 "},
                {"PROPOFID_AGECTADEB" , "55"},
                {"PROPOFID_OPRCTADEB" , "1"},
                {"PROPOFID_NUMCTADEB" , "47247"},
                {"PROPOFID_DIGCTADEB" , "4"},
                {"PROPOFID_PERC_DESCONTO" , "0.00"},
                {"PROPOFID_NRMATRVEN" , "262131"},
                {"PROPOFID_AGECTAVEN" , "55"},
                {"PROPOFID_OPRCTAVEN" , "1"},
                {"PROPOFID_NUMCTAVEN" , "42953"},
                {"PROPOFID_DIGCTAVEN" , "6"},
                {"PROPOFID_CGC_CONVENENTE" , "0"},
                {"PROPOFID_NOME_CONVENENTE" ,  "                                         "},
                {"PROPOFID_NRMATRCON" , "0"},
                {"PROPOFID_DTQITBCO" ,  "2000-02-14 "},
                {"PROPOFID_VAL_PAGO" , "300.00"},
                {"PROPOFID_AGEPGTO" , "55"},
                {"PROPOFID_VAL_TARIFA" , "3.30"},
                {"PROPOFID_VAL_IOF" , "0.00"},
                {"PROPOFID_DATA_CREDITO" ,  "2000-02-15 "},
                {"PROPOFID_VAL_COMISSAO" , "0.00"},
                {"PROPOFID_SIT_PROPOSTA" ,  "EMT "},
                {"PROPOFID_COD_USUARIO" ,  "PF0600B  "},
                {"PROPOFID_CANAL_PROPOSTA" , "1"},
                {"PROPOFID_NSAS_SIVPF" , "835"},
                {"PROPOFID_ORIGEM_PROPOSTA" , "6"},
                {"PROPOFID_NSL" , "5520"},
                {"PROPOFID_NSAC_SIVPF" , "4"},
                {"PROPOFID_SITUACAO_ENVIO" ,  "R "}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0055_00_LER_ENDOSSO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "108211472078"},
                { "ENDOSSOS_NUM_ENDOSSO" , "565204"},
                { "ENDOSSOS_NUM_PROPOSTA" , "35298210"},
                { "ENDOSSOS_DATA_PROPOSTA" , "2023-03-03"},
                { "ENDOSSOS_DATA_EMISSAO" , "2023-03-03"},
                { "ENDOSSOS_NUM_RCAP" , "0"},
                { "ENDOSSOS_VAL_RCAP" , "0"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-03-03"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-11-15"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "108211472078"},
                { "ENDOSSOS_NUM_ENDOSSO" , "565204"},
                { "ENDOSSOS_NUM_PROPOSTA" , "35298210"},
                { "ENDOSSOS_DATA_PROPOSTA" , "2023-03-03"},
                { "ENDOSSOS_DATA_EMISSAO" , "2023-03-03"},
                { "ENDOSSOS_NUM_RCAP" , "0"},
                { "ENDOSSOS_VAL_RCAP" , "0"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-03-03"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-11-15"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "108211472078"},
                { "ENDOSSOS_NUM_ENDOSSO" , "565204"},
                { "ENDOSSOS_NUM_PROPOSTA" , "35298210"},
                { "ENDOSSOS_DATA_PROPOSTA" , "2023-03-03"},
                { "ENDOSSOS_DATA_EMISSAO" , "2023-03-03"},
                { "ENDOSSOS_NUM_RCAP" , "0"},
                { "ENDOSSOS_VAL_RCAP" , "0"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-03-03"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-11-15"},
            });
            AppSettings.TestSet.DynamicData.Add("R0055_00_LER_ENDOSSO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0056_00_LER_ENDOSSO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "108211472078"},
                { "ENDOSSOS_NUM_ENDOSSO" , "565204"},
                { "ENDOSSOS_NUM_PROPOSTA" , "35298210"},
                { "ENDOSSOS_DATA_PROPOSTA" , "2023-03-03"},
                { "ENDOSSOS_DATA_EMISSAO" , "2023-03-03"},
                { "ENDOSSOS_NUM_RCAP" , "0"},
                { "ENDOSSOS_VAL_RCAP" , "0"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-03-03"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-11-15"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "108211472078"},
                { "ENDOSSOS_NUM_ENDOSSO" , "565204"},
                { "ENDOSSOS_NUM_PROPOSTA" , "35298210"},
                { "ENDOSSOS_DATA_PROPOSTA" , "2023-03-03"},
                { "ENDOSSOS_DATA_EMISSAO" , "2023-03-03"},
                { "ENDOSSOS_NUM_RCAP" , "0"},
                { "ENDOSSOS_VAL_RCAP" , "0"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-03-03"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-11-15"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "108211472078"},
                { "ENDOSSOS_NUM_ENDOSSO" , "565204"},
                { "ENDOSSOS_NUM_PROPOSTA" , "35298210"},
                { "ENDOSSOS_DATA_PROPOSTA" , "2023-03-03"},
                { "ENDOSSOS_DATA_EMISSAO" , "2023-03-03"},
                { "ENDOSSOS_NUM_RCAP" , "0"},
                { "ENDOSSOS_VAL_RCAP" , "0"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2023-03-03"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2023-11-15"},
            });
            AppSettings.TestSet.DynamicData.Add("R0056_00_LER_ENDOSSO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0060_00_LER_HISTORICO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , "12354"}
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , "12354"}
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , "12354"}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_LER_HISTORICO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1_Update1", q9);

            #endregion

            #region PF0706B_BILHETE_COBERTURA

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("PF0706B_BILHETE_COBERTURA", q10);

            #endregion

            #region R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , "1974-07-31"}
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , "1974-07-31"}
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , "1974-07-31"}
            });
            AppSettings.TestSet.DynamicData.Add("R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0125_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "3"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "2"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "4"}
            });
            AppSettings.TestSet.DynamicData.Add("R0125_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0125_00_LER_H_PROP_FIDEL_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1"}
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1"}
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R0125_00_LER_H_PROP_FIDEL_DB_SELECT_2_Query1", q13);

            #endregion

            #region R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_VAL_OPERACAO" , "38.50"}
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_VAL_OPERACAO" , "38.50"}

            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_VAL_OPERACAO" , "38.50"}
            });
            AppSettings.TestSet.DynamicData.Add("R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q16);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0706B_00.txt")]
        public static void PF0706B_Tests_Theory_HISTORICO_SIM(string MOVTO_STA_BILHETE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_BILHETE_FILE_NAME_P = $"{MOVTO_STA_BILHETE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0706B();
                program.Execute(MOVTO_STA_BILHETE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(File.Exists(program.MOVTO_STA_BILHETE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_BILHETE.FilePath)?.Length > 0);

                //R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

                var envList1 = AppSettings.TestSet.DynamicData["R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val8r) && val8r.Contains("STASASSE"));
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val9r) && val9r.Contains("4"));
                                
            }
        }

        [Theory]
        [InlineData("Saida_PF0706B_01.txt")]
        public static void PF0706B_Tests_Theory1_HISTORICO_NAO(string MOVTO_STA_BILHETE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_BILHETE_FILE_NAME_P = $"{MOVTO_STA_BILHETE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0060_00_LER_HISTORICO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0060_00_LER_HISTORICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0060_00_LER_HISTORICO_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new PF0706B();
                program.Execute(MOVTO_STA_BILHETE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(File.Exists(program.MOVTO_STA_BILHETE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_BILHETE.FilePath)?.Length > 0);

                //R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1_Update1

                var envList = AppSettings.TestSet.DynamicData["R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList[1].TryGetValue("PROPFIDH_SIT_PROPOSTA", out var val4r) && val4r.Contains("CAN"));
                Assert.True(envList[1].TryGetValue("PROPOFID_NSAS_SIVPF", out var val5r) && val5r.Contains("835"));

                //R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

                var envList1 = AppSettings.TestSet.DynamicData["R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val8r) && val8r.Contains("STASASSE"));
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val9r) && val9r.Contains("4"));

            }
        }
        [Theory]
        [InlineData("Saida_PF0706B_02.txt")]
        public static void PF0706B_Tests_Theory1_Erro_99(string MOVTO_STA_BILHETE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_BILHETE_FILE_NAME_P = $"{MOVTO_STA_BILHETE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new PF0706B();
                program.Execute(MOVTO_STA_BILHETE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);



            }
        }


    }
}