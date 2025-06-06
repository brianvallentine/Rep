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
using static Code.CB0124B;

namespace FileTests.Test_DB
{
    [Collection("CB0124B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class CB0124B_Tests_DB
    {

        [Fact]
        public static void CB0124B_Database()
        {
            var program = new CB0124B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
            var dayDataMock = DateTime.Now.AddDays(-100).Day;
            var hourDataMock = DateTime.Now.AddDays(-100).ToString("HH:mm:ss");

            program.InitializeGetQuery();

            try { /*1*/ program.R0130_00_BUSCAR_PRODUTOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R7100_00_TRATA_DEVOL_PARC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0110_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0120_00_SELECT_AVISOCRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R3005_00_VERIFICAR_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R3006_00_VERIFICAR_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R3007_00_VERIFICAR_CREDITO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R3020_00_UPDATE_PARCEVID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R3030_00_UPDATE_COBHISVI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R3040_00_UPDATE_COBHISVI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO.Value = fullDataMock;
                program.HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR.Value = fullDataMock;
                program.AREA_DE_WORK.VIND_DTFATUR.Value = dayDataMock;

                program.R3150_00_INSERT_HISCONPA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R4010_00_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R4015_00_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*22*/
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.Value = fullDataMock;
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.Value = fullDataMock;

                program.R4025_00_INSERT_MOV_COBR_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*26*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = fullDataMock;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO.Value = hourDataMock;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = fullDataMock;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = fullDataMock;
                program.AREA_DE_WORK.VIND_DTQITBCO.Value = dayDataMock;

                program.R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*29*/
                program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.Value = fullDataMock;
                program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO.Value = fullDataMock;

                program.R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*30*/
                program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO.Value = fullDataMock;
                program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.Value = fullDataMock;

                program.R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*31*/
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO.Value = fullDataMock;
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO.Value = fullDataMock;

                program.R5500_00_INSERT_DESPESAS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R7060_10_INSERT_MOVIMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}