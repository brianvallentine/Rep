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
using static Code.VA2646B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VA2646B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA2646B_Tests_DB
    {

        [Fact]
        public static void VA2646B_Database()
        {
            var program = new VA2646B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var codPessoa = new Random().Next(10000, 99999);

            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*3*/
                program.R0900_00_DECLARE_PROPOVA_DB_DECLARE_1();
                program.R0900_00_DECLARE_PROPOVA_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*4*/
                program.R1011_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1();
                program.R1011_00_CURSOR_BENEFICIARIOS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*5*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 1023684651;
                program.R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*6*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.Value = 13;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.Value = 93010000890;

                program.R1010_00_SELECT_PRODUVG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*7*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 10026624526;

                program.R1015_SELECT_RELATORIOS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1016_SELECT_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1020_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.Value = 188;
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.Value = 0;

                program.R1030_00_SELECT_PROPFIDH_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*11*/
                program.R1050_ATUALIZA_RELATORIO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*12*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.Value = 84;

                program.R1100_00_SELECT_CLIENTES_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*13*/
                //program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.Value = ;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.Value = 1;

                program.R1200_00_SELECT_ENDERECO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1300_00_SELECT_OPCPAGVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1400_00_SELECT_CLIENEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1500_00_SELECT_HISCOBPR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1550_00_SELECT_AGENCCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1600_00_SELECT_PARCEVID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1700_00_SELECT_PLANOAGE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1800_00_SELECT_PESSOFIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1810_00_SELECT_PESSOJUR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1820_00_INSERT_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*25*/
                program.PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.Value = new Random().Next(100000, 99999999);
                program.R1820_00_INSERT_PESSOA_DB_INSERT_1();

            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*26*/
                program.PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_EXPEDICAO.Value = "2025-02-28";
                program.CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Value = "1997-05-08";

                program.R1830_00_INSERT_PESSOFIS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*27*/
                program.PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.Value = codPessoa;
                program.CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.Value = new Random().Next(10000, 99999);
                program.CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.Value = "FERNANDA SILVEIRA CUNHA";
                program.PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_COD_USUARIO.Value = new Random().Next(100000, 99999999).ToString();

                program.R1840_00_INSERT_PESSOJUR_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*28*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = new Random().Next(10000, 99999);

                program.R1900_00_SELECT_PROPOFID_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1910_00_UPDATE_PROPOFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1911_00_UPDATE_PROPOFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1913_00_UPDATE_PROPOFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R1915_00_SELECT_MAX_RELAC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*34*/
                program.PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.Value = codPessoa;
                program.IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC.Value = 1;

                program.R1915_00_SELECT_MAX_RELAC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*35*/
                program.IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC.Value = 1;
                program.IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_USUARIO.Value = "1";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.Value = new Random().Next(999999999);

                program.R1915_00_SELECT_MAX_RELAC_DB_INSERT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*36*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.Value = new Random().Next(999999);
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Value = "2025-02-28";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2025-02-28";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.Value = "2025-02-28";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = "1969-05-09";

                program.R1920_00_INSERT_PROPOFID_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R1921_00_INSERT_PROPOFID_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R8000_00_UPDATE_RELATORI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}