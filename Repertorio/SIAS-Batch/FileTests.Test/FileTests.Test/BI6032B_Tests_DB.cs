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
using static Code.BI6032B;

namespace FileTests.Test_DB
{

    [Collection("BI6032B_Tests_DB")]

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI6032B_Tests_DB
    {

        [Fact]
        public static void BI6032B_Database()
        {
            var program = new BI6032B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0010_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0015_00_MONTA_V1EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*3*/
                program.V0PARAMC_TIPO_MOVTOCC.Value = 1;
                program.V0PARAMC_SITUACAO.Value = "A";
                program.R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*4*/
                program.V0RELAT_CODRELAT.Value = "AU0010B1";
                program.R0030_00_DECLARE_V0RELATORIOS_DB_DECLARE_1(); program.R0030_00_DECLARE_V0RELATORIOS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*5*/
                program.V0MOVDE_NUM_APOLICE.Value = 82621886402;
                program.R0060_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1(); program.R0060_00_DECLARE_V0MOVDEBCC_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*6*/
                program.V0RELAT_QUANTIDADE.Value = 0;
                program.V0RELAT_SITUACAO.Value = "2";
                program.V0RELAT_NUM_APOLICE.Value = 108205214519;
                program.V0RELAT_CODRELAT.Value = "BI6401B1";
                program.V0RELAT_NRTIT.Value = 82581994471;
                program.R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R0200_00_CARREGA_ORIGEM_DB_DECLARE_1(); program.R0200_00_CARREGA_ORIGEM_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*8*/
                program.V1BILH_NUMBIL.Value = 8259298302;
                program.R0075_00_LE_V0BILHETE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*9*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 80021058960;
                program.R0076_00_LE_PROPOFID_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*10*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.Value = 80000000017;
                program.R0076_00_LE_PROPOFID_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*11*/
                program.V0RCAP_NRTIT.Value = 8211303130;
                program.R0077_00_LE_V0RCAP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*12*/
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.Value = 100001;
                program.R0078_00_LE_MOVIMCOB_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*13*/
                program.V1BILH_NUM_APOL.Value = 11001002790;
                program.R0090_00_MAX_PARCELA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*14*/
                program.V1BILH_NUM_APOL.Value = 66001000001;
                program.AREA_DE_WORK.WS_PARCELA.Value = 0;
                program.R0090_00_MAX_PARCELA_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*15*/
                program.V1BILH_NUM_APOL.Value = 6501000001;
                program.R0091_00_MAX_ENDOSSO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*16*/
                program.V1BILH_NUM_APOL.Value = 103100000002;
                program.AREA_DE_WORK.WS_ENDOSSO.Value = 0;
                program.R0091_00_MAX_ENDOSSO_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*17*/
                program.V1CLIEN_COD_CLIENTE.Value = 1;
                program.R0126_00_LE_V1CLIENTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*18*/
                program.V0PARAMC_NSAS.Value = 4485405;
                program.V0PARAMC_TIPO_MOVTOCC.Value = 1;
                program.V0PARAMC_COD_CONVENIO.Value = 123;
                program.V0PARAMC_SITUACAO.Value = "A";
                program.V0PARAMC_CODPRODU.Value = 123;
                program.R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*19*/
                program.V1BILH_NUM_APOL.Value = 0000000000105;
                program.AREA_DE_WORK.WS_ENDOSSO.Value = 000000105;
                program.AREA_DE_WORK.WS_PARCELA.Value = 12;
                program.V0MOVDE_DTVENCTO.Value = "2025-01-01";
                program.AREA_DE_WORK.WS_VLPREMIO.Value = 1255;
                program.V1SISTE_DTMOVABE.Value = "2025-01-01";
                program.V1BILH_AGENCIA_DEB.Value = 0000;
                program.V1BILH_OPERACAO_DEB.Value = 0000;
                program.V1BILH_CONTA_DEB.Value = 0000;
                program.V1BILH_DIGITO_DEB.Value = 0000;
                program.V0PARAMC_COD_CONVENIO.Value = 0000;
                program.V0PARAMC_NSAS.Value = 2;

                program.R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}