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
using static Code.VA0812B;

namespace FileTests.Test_DB
{
    [Collection("VA0812B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA0812B_Tests_DB
    {
        private static string pData = "2020-01-02";

        [Fact]
        public static void VA0812B_Database()
        {
            var program = new VA0812B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0032_LOCALIZA_COMISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0033_LOCALIZA_RESSARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.FITCEF_DTRET.Value = pData;
                program.M_0033_LOCALIZA_RESSARC_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/ program.M_0033_LOCALIZA_RESSARC_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0034_LOCALIZA_PREMIACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ 
                program.MVCOM_DATA_MOV.Value = pData;
                program.DTMOVABE.Value = pData;
                program.M_0033_LOCALIZA_RESSARC_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/ program.M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_0033_LOCALIZA_RESSARC_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_0034_LOCALIZA_PREMIACAO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_0033_LOCALIZA_RESSARC_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.M_0036_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_0036_INSERT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_0036_INSERT_HISTCONTABILVA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_0036_INSERT_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                program.WHOST_DTVENCTO1.Value = pData;
                program.M_0037_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1(); 
                program.M_0037_00_DECLARE_VGRAMOCOMP_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*28*/ program.M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1(); program.M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ 
                program.PROP_DTVENCTO.Value = pData;
                program.M_0036_INSERT_HISTCONTABILVA_DB_SELECT_5(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*30*/ program.M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.M_0041_LOCALIZA_6039_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.M_0042_00_INSERT_VGHISTCONT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.M_0050_GERA_FITACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.M_0053_UPDATE_FITACEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ 
                program.FITCEF_DTRET.Value = pData;
                program.M_0055_INSERT_FITACEF_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*36*/ program.M_0060_LOCALIZA_6075_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ 
                program.V0RESG_DTCREDITO.Value = pData;
                program.M_0061_QUITA_RESGATE_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*38*/ program.M_0062_REJEITA_RESGATE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.M_0075_SOLICITA_RELAT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ 
                program.V0AVIS_DTMOVTO.Value = pData;
                program.V0AVIS_DTAVISO.Value = pData;
                program.M_0100_INSERT_AVISOS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*41*/
                program.V0SALD_DTMOVTO.Value = pData;
                program.V0SALD_DTAVISO.Value = pData;
                program.M_0100_INSERT_AVISOS_DB_INSERT_2();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*42*/ program.M_1132_QUITA_COMISSAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.M_1232_REJEITA_COMISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.M_1332_ATUALIZA_CONTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.M_1432_REJEITA_COMISSAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.M_1532_GERA_RETCOMIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ 
                program.MVCOM_DATA_MOV.Value = pData;
                program.M_1532_GERA_RETCOMIS_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*48*/ program.M_1141_QUITA_COMISSAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.M_1241_REJEITA_COMISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.M_1241_REJEITA_COMISSAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.M_1241_REJEITA_COMISSAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/
                program.M_1241_REJEITA_COMISSAO_DB_SELECT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*53*/ program.M_1241_REJEITA_COMISSAO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.M_1241_REJEITA_COMISSAO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1(); program.R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.R8010_00_VER_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/
                program.V0DPCF_DTMOVTO.Value = pData;
                program.V0DPCF_DTAVISO.Value = pData;
                program.R8700_00_INSERT_DESPESAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}