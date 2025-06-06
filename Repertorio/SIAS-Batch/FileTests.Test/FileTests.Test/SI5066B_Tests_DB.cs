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
using static Code.SI5066B;

namespace FileTests.Test_DB
{
    [Collection("SI5066B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI5066B_Tests_DB
    {

        [Fact]
        public static void SI5066B_Database()
        {
            var program = new SI5066B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.Execute_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0010_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.Execute_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0010_SELECT_SISTEMAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/
                program.HOST_SI_DATA_MOV_ABERTO.Value = "2020-02-02";
                program.AREA_DE_WORK.W_DIA01_MES_CORRENTE.Value = "2020-01-01";
                program.R0010_SELECT_SISTEMAS_DB_SELECT_3(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.Execute_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0020_DECLARE_PRINCIPAL_DB_DECLARE_1(); program.R0020_DECLARE_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0200_DECLARE_RALCHEDO_DB_DECLARE_1(); program.R0200_DECLARE_RALCHEDO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/
                program.RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_TIMESTAMP.Value = "1988-04-30";
                program.R0120_GRAVA_RALCHEDO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.R0310_SELECT_MAX_CHEQUES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/
                program.CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO.Value = "1988-04-30";
                program.CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO.Value = "1988-04-30";
                program.CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_COMPETENCIA.Value = "1988-04-30";
                program.CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_LANCAMENTO.Value = "1988-04-30";
                program.R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*13*/ program.R0350_MONTA_MOVDEBCC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "1988-04-30";
                program.R0355_GRAVA_PARAMCON_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/ program.R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*16*/
                program.HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_MOVIMENTO.Value = "1988-04-30";
                program.HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_HORA_OPERACAO.Value = "10:10:02";
                program.R0340_INSERT_HIST_CHEQUE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0410_UPDATE_RALCHEDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0420_UPDATE_HISTSINI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = "1988-04-30";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = "1988-04-30";
                program.R1000_GRAVA_MOVDEBCC_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*21*/ program.R1000_GRAVA_MOVDEBCC_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}