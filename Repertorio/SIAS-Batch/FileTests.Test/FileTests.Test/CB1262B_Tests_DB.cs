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
using static Code.CB1262B;

namespace FileTests.Test_DB
{
    [Collection("CB1262B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB1262B_Tests_DB
    {

        [Fact]
        public static void CB1262B_Database()
        {
            var program = new CB1262B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/ program.R0900_00_DECLARE_PARCEHIS_DB_DECLARE_1(); program.R0900_00_DECLARE_PARCEHIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.R1500_00_DECLARE_PARCEHIS_DB_DECLARE_1(); program.R1500_00_DECLARE_PARCEHIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*4*/
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO.Value = "2";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 0107100070673;
                program.R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.R2100_00_DECLARE_MOVDEBCE_DB_DECLARE_1(); program.R2100_00_DECLARE_MOVDEBCE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*6*/
                program.CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO.Value = "2";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 0107100070673;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 000000001;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.Value = 1;
                program.R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO.Value = "0";
                program.CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO.Value = "2025-01-01";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 0107100070673;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 000000001;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.Value = 0001;
                program.R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2025-01-27";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.Value = 000000001;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.Value = 0107100070673;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.Value = 000000001;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.Value = 0001;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.Value = 0001;
                program.R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.Value = 0107100070673;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.Value = 000000001;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.Value = 0001;
                program.R2400_00_UPDATE_PARCELAS_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}