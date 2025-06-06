using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.CB0123B;

namespace FileTests.Test_DB
{
    [Collection("CB0123B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class CB0123B_Tests_DB
    {

        [Fact]
        public static void CB0123B_Database()
        {
            var program = new CB0123B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
            var yearMock = DateTime.Now.AddDays(-100).Year;
            var monthMock = DateTime.Now.AddDays(-100).Month;
            var hourMock = DateTime.Now.AddDays(-100).ToString("HH:mm:ss");

            program.InitializeGetQuery();

            try { /*1*/ program.R0130_00_BUSCAR_PRODUTOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0110_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0120_00_SELECT_AVISOCRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0305_00_VERIFICAR_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0310_00_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.AREA_DE_WORK.WS_DATA_GERACAO_PARCELA.Value = fullDataMock;
                program.R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.REG_CIELO.MCIELO_DATA_VENCIMENTO.Value = fullDataMock;

                program.R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.Value = fullDataMock;
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.Value = fullDataMock;

                program.R0353_00_INSERT_MOV_COBR_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.Value = fullDataMock;
                program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO.Value = fullDataMock;

                program.R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO.Value = fullDataMock;
                program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.Value = fullDataMock;

                program.R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA.Value = yearMock;
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA.Value = monthMock;
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO.Value = fullDataMock;
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO.Value = fullDataMock;

                program.R3800_00_INSERT_DESPESAS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = fullDataMock;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO.Value = hourMock;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = fullDataMock;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = fullDataMock;
                program.AREA_DE_WORK.VIND_DTQITBCO.Value = yearMock;

                program.R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}