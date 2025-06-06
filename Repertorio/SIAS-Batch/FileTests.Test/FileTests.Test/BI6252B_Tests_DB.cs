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
using static Code.BI6252B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("BI6252B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI6252B_Tests_DB
    {
        private static string pData = "2020-02-03";
        private static string pDataM = "2020-02-04";

        [Fact]
        public static void BI6252B_Database()
        {
            var program = new BI6252B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.WSHOST_DTINICOT.Value = pData;
                program.R0120_00_DECLARE_COTACAO_DB_DECLARE_1(); 
                program.R0120_00_DECLARE_COTACAO_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1(); program.R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0360_00_SELECT_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0510_00_SELECT_AGENCIACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0520_00_SELECT_AGENCIAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Value = pData;
                program.R1050_00_SELECT_PESSOFIS_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*8*/ program.R1150_00_INSERT_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1150_00_INSERT_PESSOA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_NASCIMENTO.Value = pData;
                program.PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_EXPEDICAO.Value = pData;
                program.R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.R1200_00_SELECT_RTPRELAC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1250_00_INSERT_RTPRELAC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1350_00_INSERT_IDENTREL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1350_00_INSERT_IDENTREL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1400_00_SELECT_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Value = pData;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.Value = pData;
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = pData;
                program.R1450_00_INSERT_FIDELIZ_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*17*/ program.R1500_00_UPDATE_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ 
                program.BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_DATA_INIVIGENCIA.Value = pData;
                program.BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_DATA_TERVIGENCIA.Value = pData;
                program.R1700_00_SELECT_BILHECOB_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*19*/ 
                program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = pData;
                program.R1800_00_SELECT_CALENDAR_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*20*/ program.R1850_00_SELECT_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2550_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R3050_00_SELECT_NUMERAES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ 
                program.APOLICES.DCLAPOLICES.APOLICES_DATA_SORTEIO.Value = pData;
                program.R3150_00_INSERT_APOLICES_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*25*/ program.R3250_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R3300_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R3350_00_UPDATE_FONTES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ 
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Value = pDataM;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.Value = pData;
                program.R3520_00_INSERT_ENDOSSOS_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*29*/ program.R3530_00_INSERT_PARCELAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = pData;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = pData;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = pData;
                program.R3550_00_INSERT_PARCEHIS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*31*/
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.Value = pData;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Value = pData;
                program.R3600_00_INSERT_APOLICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*32*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = pData;
                program.R5100_00_INSERT_MOVDEBCE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*33*/ program.R5210_00_SELECT_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R6200_00_INSERT_APOLICOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.Value = pData;
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA.Value = pData;
                program.R6200_00_INSERT_APOLICOR_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*36*/ 
                program.BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.Value = pData;
                program.R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*37*/ program.R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}