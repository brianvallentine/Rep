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
using static Code.PF2002B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("PF2002B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PF2002B_Tests_DB
    {

        [Fact]
        public static void PF2002B_Database()
        {
            var program = new PF2002B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0105_SELECT_V0RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0110_DECLARE_V0AGENCIAS_DB_DECLARE_1(); program.R0110_DECLARE_V0AGENCIAS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0150_DECLARE_V0PRDSIVPF_DB_DECLARE_1(); program.R0150_DECLARE_V0PRDSIVPF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0200_DECLARE_V0PRODUTO_DB_DECLARE_1(); program.R0200_DECLARE_V0PRODUTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0290_SELECT_MAX_TITULO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1750_SELECT_V0AGENCIAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2500_SELECT_V0AVISOCRED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2670_SELECT_RENOVACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V0MCOB_DTQITBCO.Value = "2022-01-01";
                program.V0MCOB_DTMOVTO.Value = "2021-01-01";
                program.R2690_INCLUI_V0MOVICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.R2710_SELECT_V0MESTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2720_SELECT_V0MESTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2850_SELECT_OPCPAGVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2900_SELECT_CONVERSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2901_SELECT_CONVERSAO2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP.Value = 149000300000459215;
                program.R3210_VER_MOVIMENTO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*17*/ program.R3222_SELECT_COBHISVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3224_SELECT_GE403_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R3226_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R3228_SELECT_MOVDEBCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R3230_SELECT_COBHISVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.V0MCOB_NRTIT.Value = 1;
                program.R3250_SELECT_V1ENDOSSO_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*23*/ program.R3300_SELECT_CBMALPAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R3400_SELECT_V0PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R3500_TRATA_ADESAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/
                program.V0RCAP_DTCADAST.Value = "2022-01-01";
                program.V0RCAP_DTMOVTO.Value = "2023-01-01";
                program.R3700_INCLUI_V0RCAP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*27*/ program.R3710_SELECT_V1RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                program.V0RCOM_DTMOVTO.Value = "2022-01-01";
                program.V0RCOM_HORAOPER.Value = "12:12:12";
                program.V0RCOM_DATARCAP.Value = "2022-01-01";
                program.V0RCOM_DTCADAST.Value = "2022-01-01";
                program.R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*29*/
                program.V0FILT_DTMOVTO.Value = "2022-01-01";
                program.V0FILT_DTQITBCO.Value = "2022-01-01";
                program.R3800_INCLUI_CONVERSAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*30*/ program.R3860_UPDATE_V0RCAP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R3860_UPDATE_V0RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R3860_UPDATE_V0RCAP_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/
                program.CONVSICOB_DTQITBCO.Value = "2021-02-02";
                program.R3950_UPDATE_CONVERSAO_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*34*/ program.R3950_UPDATE_CONVERSAO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/
                program.V0FOLL_DTMOVTO.Value = "2023-02-02";
                program.V0FOLL_HORAOPER.Value = "12:12:12";
                program.V0FOLL_DTLIBER.Value = "2023-01-01";
                program.V0FOLL_DTQITBCO.Value = "2022-01-05";
                program.R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*36*/
                program.V0AVIS_DTMOVTO.Value = "2021-01-02";
                program.V0AVIS_DTAVISO.Value = "2022-02-02";
                program.R4550_INCLUI_V0AVISOCRED_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*37*/

                program.V0SALD_DTAVISO.Value = "2022-01-01";
                program.V0SALD_DTMOVTO.Value = "2023-01-01";
                program.R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*38*/
                program.V0CNAB_DTMOVTO.Value = "2021-02-02";
                program.V0CNAB_DATCEF.Value = "2023-01-01";
                program.R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*39*/
                program.V0TRBL_DTMOVTO.Value = "2023-01-01";
                program.R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*40*/ program.R7050_SELECT_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R7050_SELECT_PROPOSTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R7500_UPDATE_V0CEDENTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R8455_SELECT_MAX_AVISO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/

                program.V0DPCF_DTMOVTO.Value = "2023-12-12";
                program.V0DPCF_DTAVISO.Value = "2022-12-12";
                program.R8700_INCLUI_DESPESAS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}