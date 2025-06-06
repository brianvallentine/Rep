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
using static Code.BI1630B;
using Dclgens;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Collection("BI1630B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI1630B_Tests_DB
    {

        [Fact]
        public static void BI1630B_Database()
        {
            var program = new BI1630B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_70000_00_INICIAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_70000_00_INICIAL_DB_DECLARE_1(); program.M_70000_00_INICIAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_70000_00_INICIAL_DB_DECLARE_2(); program.M_70000_00_INICIAL_DB_OPEN_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_70000_00_INICIAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_70000_00_INICIAL_DB_DECLARE_3(); program.M_70000_00_INICIAL_DB_OPEN_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.Value = 10;
                program.M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.Value = "2021-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2021-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.Value = 100;
                program.WS_WORKING.WS_AUXILIARES.WS_SIT_ATU_BIL.Value = "A";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.M_11000_00_ATUALIZA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.Value = "2021-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2021-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.Value = 100;
                program.WS_WORKING.WS_AUXILIARES.WS_SIT_ATU_BIL.Value = "A";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.M_11000_00_ATUALIZA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                 program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.Value = 123 ;
                 program.RCAPS.DCLRCAPS.RCAPS_COD_FONTE.Value =  123;
                 program.M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 123;
                program.M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.Value = 1;
                program.M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.Value = "2020-01-01";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF.Value= 123456;
                program.M_19000_00_TRATA_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value =1454845 ;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_PESSOA.Value = "X";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF.Value = 312929024;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.Value = "2020-01-01";
                program.WS_WORKING.WS_AUXILIARES.VIND_DAT_NAS.Value = 20200101;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO.Value = "M";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.Value = "S";
                program.M_19100_00_INS_CLIENTES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 1;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NUM_IDENT.Value = "123";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ORGAO_EXPED.Value = "Y";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_EXPED.Value = "2020-01-01";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_UF_EXPEDIDORA.Value = "SP";
                program.WS_WORKING.WS_AUXILIARES.VIND_UF_EXP.Value = 1;
                program.M_19300_00_INS_GE_DOC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 132;
                program.M_1B000_00_TRATA_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 123;
                program.WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.Value = 123;
                program.M_1B000_00_TRATA_ENDERECO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 123458;
                program.WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.Value = 69845 ;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_R.Value = "X";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_R.Value = "X";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_R.Value = "X";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_R.Value = "SP";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R.Value = 123456;
                program.ENDERECO.DCLENDERECOS.ENDERECO_DDD.Value = 123;
                program.ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE.Value = 123456;
                program.ENDERECO.DCLENDERECOS.ENDERECO_FAX.Value = 1234656 ;
                program.ENDERECO.DCLENDERECOS.ENDERECO_TELEX.Value = 123456;
                program.M_1B100_00_INS_ENDERECO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 1;
                program.M_1C000_00_TRATA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 1;
                program.WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU.Value = 1;
                program.M_1C000_00_TRATA_EMAIL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 123;
                program.WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU.Value = 1;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL.Value = "X";
                program.M_1C100_00_INS_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL.Value = "X";
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 1;
                program.WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU.Value = 1;
                program.M_1C300_00_UPD_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value =1 ;
                program.M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 1;
                program.WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU.Value = 1;
                program.WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.Value = "2020-01-01";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_PESSOA.Value = "x";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL06.Value = 1;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA.Value = "F";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL07.Value = 3;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO.Value = "S";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL08.Value = 1;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.Value = "S";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL09.Value = 4;
                program.WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.Value = 41;
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL10.Value = 5;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_R.Value ="X";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL11.Value = 6;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_R.Value ="X";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL12.Value = 7;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_R.Value ="X";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL13.Value = 8;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_R.Value = "SP";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL14.Value = 9;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R.Value = 10;
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL15.Value = 11;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.Value = 12;
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL16.Value = 13;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.Value = 14;
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL17.Value = 15;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.Value = 16;
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL18.Value = 17;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF.Value = 18;
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL19.Value = 19;
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.Value = "20-01-01";
                program.WS_WORKING.WS_AUXILIARES.VIND_NULL20.Value = 21;
                program.M_1D100_00_INS_GECLIMOV_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 123;
                program.WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU.Value = 123;
                program.M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.Value = 78;
                program.BILHETE.DCLBILHETE.BILHETE_FONTE.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.Value = 123;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.Value = 100;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.Value = 123;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.Value = 123;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.Value = 23;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.Value = 12;
                program.WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.Value = 2;
                program.BILHETE.DCLBILHETE.BILHETE_PROFISSAO.Value = "X";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO.Value = "M";
                program.BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.Value ="S" ;
                program.WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.Value = 2;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.Value = 4;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.Value = 5;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.Value = 3;
                program.BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA.Value = 7;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.Value = 100;
                program.BILHETE.DCLBILHETE.BILHETE_RAMO.Value = 123;
                program.WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.Value = "2020-01-01";
                program.BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR.Value = 100;
                program.WS_WORKING.WS_AUXILIARES.WS_SIT_BIL.Value = "X";
                program.BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND.Value = 0;
                program.BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM.Value = 1;
                program.PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO.Value = 1;
                program.M_1F000_00_INSERT_BILHETE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ 
                program.PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.Value = 1;
                program.M_1F100_00_SEL_PF_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                program.WS_WORKING.WS_AUXILIARES.WS_SIT_PRO.Value = "A";
                program.WS_WORKING.WS_AUXILIARES.WS_SIT_ENV.Value = "X";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 100;
                program.M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.Value = 1;
                program.WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.Value = "2020-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.Value = 1;
                program.M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                program.WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.Value = "2020-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.Value = 123;
                program.M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value = 123;
                program.M_80000_00_FINAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}