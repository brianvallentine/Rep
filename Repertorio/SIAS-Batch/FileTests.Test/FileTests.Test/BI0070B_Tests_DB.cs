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
using static Code.BI0070B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("BI0070B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0070B_Tests_DB
    {

        [Fact]
        public static void BI0070B_Database()
        {
            var program = new BI0070B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0110_00_SELECT_COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0130_00_DECLARE_V0COTACAO_DB_DECLARE_1(); program.R0130_00_DECLARE_V0COTACAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0210_00_DECLARE_MOVDEBCE_DB_DECLARE_1(); program.R0210_00_DECLARE_MOVDEBCE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*5*/
                program.WIND2.Value = 2;
                program.WIND3.Value = 3;
                program.WIND.Value = 1;
                program.R0240_00_SELECT_BILHETE_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*6*/
                program.WSGER00_DATA_INIVIGENCIA.Value = "2025-01-08";
                program.R0250_00_SELECT_RAMOCOMP_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
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
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.Value = "2025-01-08";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.Value = "2025-01-08";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.Value = "2025-01-08";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = "2025-01-08";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Value = "2025-01-08";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.Value = "2025-01-08";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.Value = "2025-01-08";

                program.R1520_00_INSERT_ENDOSSOS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1530_00_INSERT_PARCELAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*18*/ 
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = "2025-01-08";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = "2025-01-08";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = "2025-01-08";
                program.R1550_00_INSERT_PARCEHIS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*19*/
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.Value = "2025-01-08";
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Value = "2025-01-08";
                program.R1570_00_INSERT_APOLICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1750_00_UPDATE_BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2010_00_SELECT_V0RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*23*/
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.Value = "2025-01-08";
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA.Value = "2025-01-08";
                 program.R2100_00_INSERT_APOLICOR_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*24*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = "2025-01-08";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = "2025-01-08";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.Value = "2025-01-08";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = "2025-01-08";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = "2025-01-08";
                program.R3100_00_INSERT_MOVDEBCE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R4000_00_INSERT_RELATORI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}