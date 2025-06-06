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
using static Code.VE0123B;

namespace FileTests.Test_DB
{
    [Collection("VE0123B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE0123B_Tests_DB
    {

        [Fact]
        public static void VE0123B_Database()
        {
            var program = new VE0123B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            program.InitializeGetQuery();

            try { /*1*/
                /* PROPOVA_DATA_QUITACAO { get; set; }
         public string PROPOVA_DATA_VENCIMENTO { get; set; }
         public string PROPOVA_DTPROXVEN { get; set; }*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTFENAE.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_ADMISSAO.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTA_DECLINIO.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTFENAE.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DPS_TITULAR.Value = fullDataMock;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_TIMESTAMP.Value = fullDataMock;
                


                program.R0300_00_OPEN_CURS01_DB_OPEN_1(); }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0250_00_APURAR_INDICE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0200_00_VERIFICA_COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2000_10_FIM_CORRECAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2500_00_INSERE_MOVIMVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2500_00_INSERE_MOVIMVGA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R8000_00_SELECT_HISCOBPR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R8000_00_SELECT_HISCOBPR_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R8100_00_SELECT_OPCPAGVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R8200_00_INSERT_OPCPAGVI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R8300_00_INSERT_HISCOBPR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R8400_00_GRAVA_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}