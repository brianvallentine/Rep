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
using static Code.VG1853B;

namespace FileTests.Test_DB
{
    [Collection("VG1853B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG1853B_Tests_DB
    {

        [Fact]
        public static void VG1853B_Database()
        {
            var program = new VG1853B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_00_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.WHOST_MIN_DTPROXVEN.Value = "2021-01-01";
                program.R0000_00_PRINCIPAL_DB_DECLARE_1();
                program.R0000_00_PRINCIPAL_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/ program.R1000_10_LEITURA_RAMO_DB_DECLARE_1(); program.R1000_10_LEITURA_RAMO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0000_00_PRINCIPAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0000_00_PRINCIPAL_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0000_00_PRINCIPAL_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1000_10_LEITURA_RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1000_10_LEITURA_RAMO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/

                program.V0PROP_DTVENCTO.Value = "2022-01-01";
                program.R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1();
                program.R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*13*/
                program.V0PROP_DTPROXVEN.Value = "2022-01-01";
                program.R1000_10_LEITURA_RAMO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/ program.R1000_10_LEITURA_RAMO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1200_00_GERA_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1200_10_GERA_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.V0PROP_DTVENCTO.Value = "2023-02-03";
                program.R1200_10_GERA_PARCELAS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*19*/
                program.R1200_00_GERA_PARCELAS_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*20*/
                program.R1200_00_GERA_PARCELAS_DB_SELECT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*21*/
                program.V0HICB_DTVENCTO.Value = "2021-05-05";
                program.V0OPCP_NUMCTADEB.Value = "1";
                program.V0OPCP_CARTAO_CRED.Value = "1";
                program.R1300_00_GERA_DEBITO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*22*/ program.R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*23*/
                program.R1500_10_UPDATE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1600_00_VERIFICA_REPASSE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1600_00_VERIFICA_REPASSE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1600_00_VERIFICA_REPASSE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*27*/
                program.V0RCDG_DTREFER.Value = "2023-01-01";
                program.R1650_00_REPASSA_CDG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*28*/
                program.V1SIST_DTMOVABE.Value = "2023-01-01";
                program.R1650_00_REPASSA_CDG_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*29*/
                program.V0RSAF_DTREFER.Value = "2023-01-01";
                program.R1670_00_REPASSA_SAF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*30*/ program.R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1700_10_LOOP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1700_10_LOOP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*33*/
                program.V0PARC_DTVENCTO_PAR.Value = "2021-01-01";
                program.R1700_10_LOOP_DB_SELECT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*34*/
                program.V0OPCP_PERIPGTO_ANT.Value = 12;
                program.R1700_10_LOOP_DB_SELECT_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*35*/
                program.R1700_10_LOOP_DB_SELECT_5();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*36*/
                program.WHOST_DTTERVIG.Value = "2021-01-01";
                program.R1700_10_LOOP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*37*/
                program.HISCOBPR_DATA_INIVIGENCIA.Value = "2021-01-01";
                program.HISCOBPR_DATA_TERVIGENCIA.Value = "2021-01-01";
                program.R1700_10_LOOP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*38*/
                program.V0PARC_DTVENCTO_PAR.Value = "2021-01-01";
                program.R1700_10_LOOP_DB_SELECT_6();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*39*/ program.R1700_10_LOOP_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}