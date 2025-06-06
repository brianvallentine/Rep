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
using static Code.VA0123B;

namespace FileTests.Test_DB
{
    [Collection("VA0123B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0123B_Tests_DB
    {
        private static string pData = "2020-01-01";

        [Fact]
        public static void VA0123B_Database()
        {
            var program = new VA0123B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = pData;
                program.SISTEMAS_DATA_MOV_ABERTO_40.Value = pData;
                program.R0300_00_OPEN_CURS01_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/ program.R2900_00_OPEN_CURS02_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0005_00_UPDATE_ESTOQUE_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0110_00_SELECT_RELATORI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1010_00_SELECT_SEGURVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1020_00_SELECT_SEGURHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1100_00_SELECT_SUBGVGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1111_00_SELECT_SUBGVGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1120_00_SELECT_PRODUVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1200_00_SELECT_HISCOBPR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1300_00_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Value = pData;
                program.R1400_00_SELECT_PLAVAVGA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*17*/ program.R1401_00_SELECT_PLAVAVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1405_00_VALIDA_AGRAVO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1450_00_SELECT_OPCPAGVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = pData;
                program.R1460_00_SELECT_OPCPAGVI_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*21*/ program.R1500_00_INSERT_OPCPAGVI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ 
                program.SISTEMAS_DATA_MOV_ABERTO_01.Value = pData;
                program.R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*23*/ program.R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1600_00_INSERT_HISCOBPR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1615_00_MAX_PARCEVID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ 
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Value = pData;
                program.R1620_00_INSERT_PARCEVID_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*29*/ program.R1630_00_INSERT_COBHISVI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1630_00_INSERT_COBHISVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1630_00_INSERT_COBHISVI_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1630_00_INSERT_COBHISVI_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R1630_00_INSERT_COBHISVI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1640_00_INSERT_HISLANCT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/
                program.OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.Value = "5200123456780000";
                program.R1640_00_INSERT_HISLANCT_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*36*/ program.R1630_00_INSERT_COBHISVI_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = pData;
                program.R1650_00_DEBITO_CARTAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*38*/ program.R1700_00_UPDATE_PROPOVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Value = pData;
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = pData;
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Value = pData;
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = pData;
                program.R1750_00_INSERT_RELATO_PF10_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*40*/ program.R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R1900_00_INSERT_SEGURHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R1910_00_SELECT_APOLICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = pData;
                program.R2200_00_UPDATE_RELATORI_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*44*/ program.R3100_00_INSERT_APOLICOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R3100_00_INSERT_APOLICOB_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R3200_00_UPDATE_APOLICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}