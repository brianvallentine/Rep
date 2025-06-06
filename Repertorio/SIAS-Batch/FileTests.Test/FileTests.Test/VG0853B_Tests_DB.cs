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
using static Code.VG0853B;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FileTests.Test_DB
{
    [Collection("VG0853B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0853B_Tests_DB
    {
        private static string pData = "2021-02-20";

        [Fact]
        public static void VG0853B_Database()
        {
            var program = new VG0853B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_00_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.WHOST_MIN_DTPROXVEN.Value = pData;
                program.V1SIST_DT_23_CYRELA.Value = pData;
                program.R0000_00_PRINCIPAL_DB_DECLARE_1(); 
                program.R0000_00_PRINCIPAL_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1000_10_LEITURA_RAMO_DB_DECLARE_1(); program.R1000_10_LEITURA_RAMO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0000_00_PRINCIPAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0000_00_PRINCIPAL_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0000_00_PRINCIPAL_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.HISCOBPR_DATA_INIVIGENCIA.Value = pData;
                program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.R1000_10_LEITURA_RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1000_10_LEITURA_RAMO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1240_00_SELECT_MIGRACAO_DB_DECLARE_1(); program.R1240_00_SELECT_MIGRACAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1000_90_LEITURA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.V0PROP_DTPROXVEN.Value = pData;
                program.V0PROP_DTVENCTO.Value = pData;
                program.R1000_10_LEITURA_RAMO_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/ program.R1000_10_LEITURA_RAMO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1100_00_LE_OPCAOPAG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ 
                program.V1SIST_DTMOVABE.Value = pData;
                program.R1200_00_GERA_PARCELAS_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*21*/ program.R1200_10_GERA_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1200_00_GERA_PARCELAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1200_10_GERA_PARCELAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1200_10_GERA_PARCELAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ 
                program.V0PROP_DTQITBCO.Value = pData;
                program.R1200_10_GERA_PARCELAS_DB_SELECT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*26*/ program.R1200_10_GERA_PARCELAS_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1200_10_GERA_PARCELAS_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R1200_10_GERA_PARCELAS_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1200_10_GERA_PARCELAS_DB_INSERT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1200_00_GERA_PARCELAS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1220_00_SELECT_TERMOADE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1230_00_SELECT_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R1250_00_SELECT_MIGRACAO_DB_DECLARE_1(); program.R1250_00_SELECT_MIGRACAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1(); program.R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1260_00_CONSULTA_SITUACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/
                program.V0HICB_DTVENCTO.Value = pData;
                program.V0OPCP_CARTAO_CRED.Value = "5211222244447777";
                program.R1300_00_GERA_DEBITO_DB_INSERT_1(); }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*37*/ program.R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R1420_00_GERA_NUM_TITULO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R1420_00_GERA_NUM_TITULO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ 
                program.V0PROP_DTVENCTO_2M.Value = pData;
                program.V0PROP_DTVENCTO.Value = pData;
                program.R2000_00_RECOMANDAR_DEB_ANT_DB_DECLARE_1(); 
                program.R2000_00_RECOMANDAR_DEB_ANT_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*41*/ program.R1500_10_UPDATE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R1600_00_VERIFICA_REPASSE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R1600_00_VERIFICA_REPASSE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R1600_00_VERIFICA_REPASSE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ 
                program.V0RCDG_DTREFER.Value = pData;
                program.R1650_00_REPASSA_CDG_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*46*/ program.R1650_00_REPASSA_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/
                program.V0RSAF_DTREFER.Value = pData;
                program.R1670_00_REPASSA_SAF_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*48*/ program.R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R1700_10_LOOP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R1700_10_LOOP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ 
                program.V0PARC_DTVENCTO_PAR.Value = pData;
                program.R1700_10_LOOP_DB_SELECT_3(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*52*/ program.R1700_10_LOOP_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ 
                program.WHOST_DTTERVIG.Value = pData;
                program.R1700_10_LOOP_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*54*/
                program.HISCOBPR_DATA_INIVIGENCIA.Value = pData;
                program.HISCOBPR_DATA_TERVIGENCIA.Value = pData;
                program.R1700_10_LOOP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*55*/ program.R1700_10_LOOP_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R1700_10_LOOP_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ 
                program.V0PARC_DTVENCTO_PAR.Value = pData;
                program.R1700_10_LOOP_DB_SELECT_7(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*58*/ program.R1700_10_LOOP_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.R2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.R5000_00_BUSCA_VLPREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.R5000_00_BUSCA_VLPREMIO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}