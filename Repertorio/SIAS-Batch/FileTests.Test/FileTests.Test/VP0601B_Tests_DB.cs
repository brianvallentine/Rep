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
using Dclgens;
using Code;
using static Code.VP0601B;

namespace FileTests.Test_DB
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("VP0601B_Tests_DB")]
    public class VP0601B_Tests_DB
    {

        [Fact]
        public static void VP0601B_Database()
        {
            var program = new VP0601B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_INICIALIZA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_INICIALIZA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.JVBKINCL.JV_PRODUTOS.JVPRD7725.Value = 1;
                program.JVBKINCL.JV_PRODUTOS.JVPRD7733.Value = 1; 
                program.R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1(); program.R0900_00_DECLARE_PROPOSTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.RCAPS.DCLRCAPS.RCAPS_COD_FONTE.Value = 1;
                program.RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.Value = 1;
                program.R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1(); program.R1510_00_SELECT_RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.Value = 1;
                program.R0911_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.Value = 784;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 471;
                program.R0913_00_UPDATE_PROPOFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ 
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.Value = 1;    
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 245; 
                program.R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ 
                program.WS_NUM_PROPOSTA_AZUL.Value = 1; 
                program.R1000_CONSISTE_CX_TRAB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value =789 ;
                program.ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO.Value = 0;
                program.R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE.Value = 1;
                program.GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO.Value = 2;
                program.GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF.Value = 3;
                program.R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ 
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.Value = 1; 
                program.R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 821;
                program.R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ 
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.Value = 3;  
                program.R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "X";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 1; 
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-01-01"; 
                program.R1400_00_SELECT_PLANOS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value =2 ;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-01-01" ;
                program.WHOST_IDADE.Value = 4;
                program.R1400_00_SELECT_PLANOS_VA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "x";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value =3 ;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-01-01";
                program.WHOST_IDADE.Value = 0;
                program.R1401_00_SELECT_PLANOS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Value = "2020-01-01";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "x";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.Value = 4;
                program.WHOST_IDADE.Value = 1;
                program.R1410_00_SELECT_PLANOS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "X";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 2;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-10-10";
                program.WHOST_IDADE.Value =1;
                program.R1410_00_SELECT_PLANOS_VA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 2;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-01-01";
                program.WHOST_IDADE.Value = 1;
                program.R1420_00_SELECT_PLANOS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.Value = 3;
                program.RCAPS.DCLRCAPS.RCAPS_COD_FONTE.Value = 3;
                program.R1500_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.Value = 1;
                program.R1505_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.RCAPS.DCLRCAPS.RCAPS_COD_FONTE.Value = 1;
                program.RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.Value = 2;
                program.R1510_00_SELECT_RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ 
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1; 
                program.R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1(); program.R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.Value = 1;
                program.WHOST_SIT_PROPOSTA.Value = "x";
                program.WHOST_SIT_ENVIO.Value = "x" ;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 123;
                program.R1600_00_UPDATE_PROPFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.Value ="2020-01-01";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Value = "2020-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.Value = 12;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 12;
                program.R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 2;
                program.R2203_00_SELECT_CONDITEC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.Value = 1;
                program.R2205_00_SELECT_HISTCOBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2200_00_SELECT_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.Value = 2;
                program.R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.R2215_00_SELECT_PROPOVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.PROPVA.DCLPROPOSTAS_VA.OCOREND.Value = 1;   
                program.R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1(); program.R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1(); program.R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 1; 
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1(); program.R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1 ;
                program.R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/
                program.R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.Value = 1;
                program.R2240_00_SELECT_PROPFIDC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/
                program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 123;
                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = "2020-01-01";
                program.R2300_00_TRATA_CLIENTES_DB_DECLARE_1(); program.R2300_00_TRATA_CLIENTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/
                program.PROPVA_NRCERTIF.Value = 1;
                program.R2241_10_FETCH_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "X";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.Value = 4;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-01-01";
                program.WHOST_IDADE_2.Value = 1;
                program.R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "X";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-01-01";
                program.WHOST_IDADE_2.Value = 1;
                program.R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.Value = 1;
                program.R2247_CALCULO_IDADE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ 
                program.R2247_CALCULO_IDADE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/
                program.WS_DATA_NASCIMENTO.Value = "2020-01-01";
                program.R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1(); program.R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_NOME_FANTASIA.Value = "X" ;
                program.PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_CGC.Value = 1234;
                program.CLIENTE.DCLCLIENTES.DATA_NASCIMENTO.Value = "2020-01-01";
                program.R2310_00_INSERT_CLIENTES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.Value = "x";
                program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 123;
                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = "2020-01-01";
                program.VIND_DATA_NASCIMENTO.Value = 123;
                program.PESFIS.DCLPESSOA_FISICA.SEXO.Value = "M";
                program.PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.Value = "S";
                program.R2310_00_INSERT_CLIENTES_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/
                program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.Value = 1;
                program.R2315_00_INSERT_GE_DOC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/
                program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.Value = 1;
                program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO.Value = "x";
                program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP.Value =  "SSP";
                program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO.Value = "2020-01-01";
                program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF.Value = "1";
                program.VIND_UF_EXPEDIDORA.Value = 1;
                program.R2315_00_INSERT_GE_DOC_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/
                program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 123;
                program.R2350_00_TRATA_ERRO_1864_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/
                program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 123;
                program.R2350_00_TRATA_ERRO_1864_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/
                program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 123;
                program.R2350_00_TRATA_ERRO_1864_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/
                program.PESENDER.DCLPESSOA_ENDERECO.ENDERECO.Value = "Rua Fictícia";
                program.PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.Value = "SP";
                program.PESENDER.DCLPESSOA_ENDERECO.BAIRRO.Value = "Centro";
                program.PESENDER.DCLPESSOA_ENDERECO.CIDADE.Value = "São Paulo";
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.PESENDER.DCLPESSOA_ENDERECO.CEP.Value = 01000;
                program.R2400_00_TRATA_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/
                program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 123;
                program.R2350_00_TRATA_ERRO_1864_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/
                program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 123;
                program.R2350_00_TRATA_ERRO_1864_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.R2420_00_INSERT_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = 13;
                program.PESENDER.DCLPESSOA_ENDERECO.ENDERECO.Value = "x";
                program.PESENDER.DCLPESSOA_ENDERECO.BAIRRO.Value = "x";
                program.PESENDER.DCLPESSOA_ENDERECO.CIDADE.Value = "x";
                program.PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.Value = "SP";
                program.PESENDER.DCLPESSOA_ENDERECO.CEP.Value = 123;
                program.WHOST_DDD.Value = 11;
                program.WHOST_FONE.Value = 123;
                program.WHOST_FAX.Value = 123;
                program.WHOST_TELEX.Value = 123;
                program.R2420_00_INSERT_ENDERECOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.R2500_00_TRATA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/
                program.WHOST_EMAIL.Value = "x";
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.R2510_00_ALTERA_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*66*/
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.R2520_00_INSERT_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.Value = 1;
                program.WHOST_EMAIL.Value = "x";
                program.R2520_00_INSERT_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*68*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 11278;
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.Value = 2;
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 1;
                program.ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = 3;
                program.WHOST_FONTE.Value = 4;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.Value = 5;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "x";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2023-05-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.Value = 6;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.Value = 7;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.Value = 8;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.Value = 9;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.Value = 10;
                program.WHOST_PROFISSAO.Value = "x";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2023-04-15";
                program.WHOST_SIT_REGISTRO.Value = "A";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 1;
                program.WHOST_DTPROXVEN.Value = "2024-12-31";
                program.WHOST_IDADE.Value = 1;
                program.PESFIS.DCLPESSOA_FISICA.SEXO.Value = "1";
                program.PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.Value = "1";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.Value = "1";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.Value = "1";
                program.VIND_NOME_CONJUGE.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = "1985-07-20";
                program.VIND_DATA_NASC_CONJUGE.Value = 1;
                program.WHOST_PROFISSAO_CONJUGE.Value = "1";
                program.VIND_PROFISSAO_CONJUGE.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Value = "1";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.Value = "1";
                program.WHOST_INFO_COMPL.Value = "1";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.Value =1;
                program.VIND_CGC_CONVENENTE.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.Value = "1";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.Value = "1";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.Value = 2;
                program.VIND_NUM_CONTR.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.Value = 1;
                program.VIND_COD_CORRESP.Value = 2;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.Value = 2;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.Value = 1;
                program.VIND_NUM_PRAZO.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.Value = 2;
                program.VIND_COD_OPER_CRED.Value = 3;
                program.R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*69*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2023-05-01";
                program.WS_VALOR_IS_CDC.Value = 5000;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "x";
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM.Value = 10000;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS.Value = 1500;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH.Value = 200;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT.Value = 300;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT.Value = 1200;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG.Value = 5.5;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP.Value = 2.3;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP.Value = 10;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP.Value = 500;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP.Value = 50;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG.Value = 1200;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG.Value = 100;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF.Value = 200;
                program.VIND_IMPSEGAUXF.Value = 220;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF.Value = 60;
                program.VIND_VLCUSTAUXF.Value = 70;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT.Value = 3000;
                program.VIND_PRMDIT.Value = 3500;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT.Value = 50;
                program.VIND_QTDIT.Value = 55;
                program.R3100_00_INSERT_COBERPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2023-05-01";
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU.Value = 2;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "x";
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID.Value = 3;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM.Value =4;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS.Value = 5;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH.Value = 6;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT.Value = 7;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT.Value = 8;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG.Value = 1;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP.Value = 99;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP.Value = 10;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP.Value = 11;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP.Value = 12;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG.Value = 13;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG.Value = 14;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF.Value = 15;
                program.VIND_IMPSEGAUXF.Value = 1;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF.Value = 16;
                program.VIND_VLCUSTAUXF.Value = 17;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT.Value = 18;
                program.VIND_PRMDIT.Value = 119;
                program.PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT.Value = 20;
                program.VIND_QTDIT.Value = 21;
                program.R3100_00_INSERT_COBERPROPVA_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*71*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 12;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2023-06-15";
                program.R3101_00_PEGAR_TAXA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 0;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "x";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2023-07-01";
                program.WHOST_IDADE.Value = 30;
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.Value = 0;
                program.R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1(); program.R3150_00_DECLARE_VGPLAACES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*73*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.VGPLAR_NUM_RAMO.Value = 2;
                program.VGPLAR_NUM_COBERTURA.Value = 3;
                program.VGPLAR_QTD_COBERTURA.Value = 4;
                program.VGPLAR_IMPSEGURADA.Value =5;
                program.VGPLAR_CUSTO.Value = 6;
                program.VGPLAR_PREMIO.Value =7;
                program.R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*74*/
                program.R6000_00_DECLARE_AGENCEF_DB_DECLARE_1(); program.R6000_00_DECLARE_AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.VGPLAA_NUM_ACESSORIO.Value = 2;
                program.VGPLAA_QTD_COBERTURA.Value = 3;
                program.VGPLAA_IMPSEGURADA.Value = 4;
                program.VGPLAA_CUSTO.Value = 5;
                program.VGPLAA_PREMIO.Value = 6;
                program.R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*76*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2023-12-31";
                program.WHOST_OPCAOPAG.Value = "x";
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.Value = 2;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.Value = 4;
                program.VIND_AGECTADEB.Value = 5;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.Value = 6;
                program.VIND_OPRCTADEB.Value = 7;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.Value = 8;
                program.VIND_NUMCTADEB.Value = 9;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.Value = 10;
                program.VIND_DIGCTADEB.Value = 11;
                program.R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*77*/
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CERTIFICADO.Value = 1;
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_PARCELA.Value = 2;
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DTA_VENCIMENTO.Value = "2023-10-15";
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_VLR_PARCELA.Value = 3;
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_STA_REGISTRO.Value = "x";
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_IDLG.Value = "x";
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_RETORNO.Value = 4;
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DES_RETORNO.Value = "PARCELA REGISTRADA COM SUCESSO";
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_CONVENIO.Value = 5;
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_BANCO_DEBITO.Value = 6;
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_AGENCIA_DEBITO.Value = 7;
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CONTA_DEBITO.Value = 8;
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NOM_PROGRAMA.Value = "x";
                program.VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DTA_PROXIMA_COBRANCA.Value = "2023-11-15";
                program.R3210_INS_VG_MOVTO_PRET_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*78*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.WHOST_FONTE.Value = 2;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.Value = 3;
                program.RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.Value = 4;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_ADIANTAMENTO.Value = 5;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2023-09-01";
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_REGISTRO.Value = "x";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.Value = 6;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.Value = 7;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.Value = 8;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.Value =9;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.Value = 10;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_FENAE.Value = "x";
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMISSAO_VEN.Value = 11;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 12;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 13;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.ORDEM_PAGAMENTO.Value = 14;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_ENDOSSO.Value = 15;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_GERENTE.Value = 16;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_GERENTE.Value = 16;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_GERENTE.Value = 17;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_GERENTE.Value = 18;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_GERENTE.Value = 19;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_GERENTE.Value = 20;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_SUN.Value = 21;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_SUN.Value = 22;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_SUN.Value =23;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_SUN.Value = 24;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_SUN.Value = 25;
                program.COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_SUN.Value = 26;
                program.R3300_00_INSERT_COMISICOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*79*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2023-09-01";
                program.RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.Value = 2;
                program.PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP.Value = 3;
                program.PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA.Value = 4;
                program.WHOST_OPCAOPAG.Value = "x";
                program.PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO.Value = "x";
                program.PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO.Value = 5;
                program.R3400_00_INSERT_PARCELVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*80*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.Value = 1;
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.Value = 2;
                program.WS_DATA_QUITACAO.Value = "2023-09-01";
                program.RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.Value = 3;
                program.WHOST_OPCAOPAG.Value = "x";
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO.Value = "x";
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO.Value = 4;
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.Value = 5;
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO.Value = 6;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.Value = 7;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.Value = 8;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.Value = 9;
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP.Value = 10;
                program.R3500_00_INSERT_HISTCOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*81*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.Value =2;
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.Value = 3;
                program.CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.Value = 4;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 5;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value =6;
                program.WHOST_FONTE.Value = 77;
                program.HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO.Value = 8;
                program.RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.Value = 9;
                program.HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP.Value = 10;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2023-10-01";
                program.HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO.Value = "x";
                program.HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO.Value = 11;
                program.HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR.Value = "2023-09-01";
                program.VIND_DTFATUR.Value = 12;
                program.R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*82*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.R3700_00_INSERT_RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*83*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.R3700_00_INSERT_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*84*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 2;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 3;
                program.R3700_00_INSERT_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*85*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.Value = 2;
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 3;
                program.ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = 4;
                program.WHOST_FONTE.Value = 5;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.Value = 6;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.Value = "1";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2025-05-07";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.Value = 7;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.Value = 8;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.Value = 9;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.Value = 10;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.Value = 11;
                program.WHOST_PROFISSAO.Value = "1";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2025-05-01";
                program.WHOST_SIT_REGISTRO.Value = "1";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.Value = 12;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.Value = 13;
                program.WHOST_DTPROXVEN.Value = "2025-06-01";
                program.WHOST_IDADE.Value = 14;
                program.PESFIS.DCLPESSOA_FISICA.SEXO.Value = "M";
                program.PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.Value = "x";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.Value = "x";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.Value = "x";
                program.VIND_NOME_CONJUGE.Value = 15;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = "1988-09-12";
                program.VIND_DATA_NASC_CONJUGE.Value = 1;
                program.WHOST_PROFISSAO_CONJUGE.Value = "1";
                program.VIND_PROFISSAO_CONJUGE.Value = 1;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Value = "1";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.Value = "1";
                program.WHOST_INFO_COMPL.Value = "x";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.Value =2;
                program.VIND_CGC_CONVENENTE.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.Value = "1";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.Value = "1";
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.Value = 5;
                program.VIND_NUM_CONTR.Value = 6;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.Value =7;
                program.VIND_COD_CORRESP.Value = 8;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.Value =9;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.Value = 10;
                program.VIND_NUM_PRAZO.Value = 12;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.Value = 11;
                program.VIND_COD_OPER_CRED.Value = 13;
                program.R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*86*/
                program.PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO.Value = 1;
                program.R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*87*/
                program.WHOST_SIT_PROPOSTA.Value = "x";
                program.WHOST_SIT_ENVIO.Value = "x";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*88*/
                program.PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.Value = 1;
                program.R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*89*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = "1980-05-12";
                program.VIND_DATA_NASC_CONJUGE.Value = 1;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.Value =2;
                program.VIND_CGC_CONVENENTE.Value = 3;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.Value = "x";
                program.VIND_NOME_CONJUGE.Value = 4;
                program.WHOST_PROFISSAO_CONJUGE.Value = "x";
                program.VIND_PROFISSAO_CONJUGE.Value = 5;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.Value = 6;
                program.VIND_COD_OPER_CRED.Value = 7;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.Value = 8;
                program.VIND_COD_CORRESP.Value = 9;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.Value = 10;
                program.VIND_NUM_CONTR.Value = 11;
                program.PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.Value = 12;
                program.VIND_NUM_PRAZO.Value = 13;
                program.ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = 14;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.Value = 15;
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = 16;
                program.WHOST_SIT_REGISTRO.Value = "x";
                program.WHOST_INFO_COMPL.Value = "x";
                program.WHOST_PROFISSAO.Value = "x";
                program.WHOST_DTPROXVEN.Value = "2025-12-31";
                program.WHOST_FONTE.Value = 17;
                program.WHOST_IDADE.Value = 18;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 19;
                program.R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*90*/ 
                program.R6100_00_DECLARE_CBO_DB_DECLARE_1(); program.R6100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*91*/ 
                program.R6200_00_DECLARE_FONTES_DB_DECLARE_1(); program.R6200_00_DECLARE_FONTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*92*/
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.Value = 1;
                program.WHOST_OCORR_END_I.Value = 2;
                program.WHOST_OCORR_END_F.Value = 3;
                program.R9320_00_SELECT_GECLIMOV_DB_DECLARE_1(); program.R9320_00_SELECT_GECLIMOV_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*93*/
                program.NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value =1;
                program.R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*94*/
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.Value =1;
                program.R9310_00_MAX_GECLIMOV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*95*/
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.Value = "1";
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.Value = "2025-05-07";
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.Value = "1";
                program.VIND_NOME_RAZAO.Value = 2;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.Value = "1";
                program.VIND_TIPO_PESSOA.Value = 3;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.Value = "1";
                program.VIND_IDE_SEXO.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.Value = "1";
                program.VIND_EST_CIVIL.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.Value = 1;
                program.VIND_OCORR_END.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.Value = "1";
                program.VIND_ENDERECO.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.Value = "1";
                program.VIND_BAIRRO.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.Value = "1";
                program.VIND_CIDADE.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.Value = "1";
                program.VIND_SIGLA_UF.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.Value = 1;
                program.VIND_CEP.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.Value = 1;
                program.VIND_DDD.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.Value = 1;
                program.VIND_TELEFONE.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.Value =1;
                program.VIND_FAX.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.Value = 1;
                program.VIND_CGCCPF.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.Value = "1990-01-01";
                program.VIND_DTNASC.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.Value = "1";
                program.VIND_CODUSU.Value = 1;
                program.R9400_00_INSERT_GECLIMOV_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*96*/
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.Value = 1;
                program.VIND_OCORR_END.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.Value = "1";
                program.VIND_TIPO_PESSOA.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.Value = "1";
                program.VIND_EST_CIVIL.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.Value = "1990-01-01";
                program.VIND_DTNASC.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.Value = "1";
                program.VIND_NOME_RAZAO.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.Value = "1";
                program.VIND_IDE_SEXO.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.Value = "1";
                program.VIND_ENDERECO.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.Value = "SP";
                program.VIND_SIGLA_UF.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.Value = 1;
                program.VIND_TELEFONE.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.Value = "1";
                program.VIND_BAIRRO.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.Value = "1";
                program.VIND_CIDADE.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.Value = 1;
                program.VIND_CGCCPF.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.Value = "2025-05-07";
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.Value = "1";
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.Value = 1;
                program.VIND_CEP.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.Value = 1;
                program.VIND_DDD.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.Value = 1;
                program.VIND_FAX.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.Value = "1";
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.Value = 1;
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.Value = 1;

                program.R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}