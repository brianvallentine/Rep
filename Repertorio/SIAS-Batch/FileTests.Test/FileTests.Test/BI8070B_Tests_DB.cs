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
using static Code.BI8070B;

namespace FileTests.Test_DB
{
    [Collection("BI8070B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI8070B_Tests_DB
    {
        private static string pData = "2020-01-01";
        [Fact]
        public static void BI8070B_Database()
        {
            var program = new BI8070B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0110_00_SELECT_COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0130_00_DECLARE_V0COTACAO_DB_DECLARE_1(); program.R0130_00_DECLARE_V0COTACAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.SISTEMA_DTTERCOT.Value = pData;
                program.SISTEMA_DTMOV20D.Value = pData;
                program.R0210_00_DECLARE_MOVDEBCE_DB_DECLARE_1();
                program.R0210_00_DECLARE_MOVDEBCE_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.Value = 0;
                program.R0240_00_SELECT_BILHETE_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*6*/
                program.WSGER00_DATA_INIVIGENCIA.Value = pData;
                program.R0250_00_SELECT_RAMOCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R0260_00_SELECT_APOLCOBR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0280_00_SELECT_PROPOFID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0600_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0640_00_SELECT_APOLICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0660_00_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1200_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1210_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1250_00_UPDATE_FONTES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.Value = pData;
                program.R1520_00_INSERT_ENDOSSOS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*17*/ program.R1530_00_INSERT_PARCELAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = pData;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = pData;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = pData;
                program.R1550_00_INSERT_PARCEHIS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*19*/
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.Value = pData;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Value = pData;
                program.R1570_00_INSERT_APOLICOB_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*20*/ program.R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.Value = 0;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.Value = 0;
                program.R1750_00_UPDATE_BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*22*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = pData;
                program.R3100_00_INSERT_MOVDEBCE_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*23*/
                program.SISTEMA_DTMOVABE.Value = pData;
                program.R4000_00_INSERT_RELATORI_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*24*/
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.Value = pData;
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA.Value = pData;
                program.R5100_00_INSERT_APOLICOR_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*25*/ program.R5120_00_SELECT_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R5150_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R5200_00_UPDATE_ENDOSSOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R5300_00_UPDATE_APOLICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}