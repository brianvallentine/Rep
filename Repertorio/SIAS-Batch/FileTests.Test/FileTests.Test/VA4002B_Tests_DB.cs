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
using static Code.VA4002B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VA4002B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA4002B_Tests_DB
    {
        private static string pData = "2023-01-01";

        [Fact]
        public static void VA4002B_Database()
        {
            var program = new VA4002B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0000_PRINCIPAL_DB_DECLARE_1(); program.M_0000_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_1400_ATUALIZA_MOVIMENTO_DB_DECLARE_1(); program.M_1400_ATUALIZA_MOVIMENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0000_PRINCIPAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0000_PRINCIPAL_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0000_PRINCIPAL_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_1050_COUNT_ERRPROVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_1060_UPD_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_1200_CANCELA_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.WS_AUXILIARES_HOST.PROPVA_DTPROXVEN.Value = pData;
                program.M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_1330_COUNT_ERRO_OPC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_1340_PESQUISA_ERRO_2005_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_1360_UPDATE_PERIPGTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_1380_PESQUISA_APOLICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO.Value = pData;
                program.M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*23*/ program.M_2000_PESQUISA_OPCPAG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_2010_VERIFICA_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_3100_SELECT_V0APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_3200_UPDATE_V0APOLICE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.M_3300_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.M_3400_SELECT_SUBGRUPOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                program.SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_NASCIMENTO.Value = pData;
                program.WS_AUXILIARES_HOST.PROPVA_DTQITBCO.Value = pData;
                program.M_3500_INSERT_SEGURVGA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*30*/ 
                program.M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*31*/
                program.WS_AUXILIARES.WHOST_DATA_TERVIGENCIA.Value = pData;
                program.M_3700_00_INSERT_APOLICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*32*/ program.M_3750_00_GERA_TERVIG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ 
                program.WS_AUXILIARES_HOST.PROPVA_DTADMIS.Value = pData;
                program.WS_AUXILIARES_HOST.PROPVA_DTINCLUS.Value = pData;
                program.WS_AUXILIARES_HOST.CLIENT_DTNASC.Value = pData;
                program.FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA.Value = pData;
                program.M_3800_INSERT_MOVIMENTO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*34*/ program.M_3810_ACESSA_FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.M_3820_ATUALIZA_FONTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.M_3830_CONTA_CORRENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.M_3840_DATA_REFERENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.M_3840_DATA_REFERENCIA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.M_3850_DATA_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.M_3860_HIS_COBER_PROPOST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}