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
using static Code.PF0003B;

namespace FileTests.Test_DB
{
    [Collection("PF0003B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PF0003B_Tests_DB
    {

        [Fact]
        public static void PF0003B_Database()
        {
            var program = new PF0003B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0110_00_DECLARE_V0AGENCIAS_DB_DECLARE_1(); program.R0110_00_DECLARE_V0AGENCIAS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0150_00_DECLARE_V0PRDSIVPF_DB_DECLARE_1(); program.R0150_00_DECLARE_V0PRDSIVPF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1(); program.R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0265_00_DECLARE_V0BILCOBER_DB_DECLARE_1(); program.R0265_00_DECLARE_V0BILCOBER_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0290_00_SELECT_V0CEDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0940_00_SELECT_V0CONTROLE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1030_00_SELECT_BILHEFAI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2850_00_SELECT_OPCPAGVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2900_00_SELECT_CONVERSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*14*/
                program.V0RCAP_DTCADAST.Value = "2025-01-15";
                program.V0RCAP_DTMOVTO.Value = "2025-01-15";
                program.R3700_00_INSERT_V0RCAP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3710_00_SELECT_V1RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*16*/
                program.V0RCOM_DTMOVTO.Value = "2025-01-15";
                program.V0RCOM_HORAOPER.Value = "00:00:00";
                program.V0RCOM_DATARCAP.Value = "2025-01-15";
                program.V0RCOM_DTCADAST.Value = "2025-01-15";

                program.R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*17*/
                program.V0FILT_DTMOVTO.Value = "2025-01-15";
                program.V0FILT_DTQITBCO.Value = "2025-01-15";
                program.R3800_00_INSERT_CONVERSAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*20*/
                program.V0MCOB_DTMOVTO.Value = "2025-01-15";
                program.V0MCOB_DTQITBCO.Value = "2025-01-15";
                program.R4050_00_INSERT_V0MOVICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*21*/
                program.V0FOLL_DTMOVTO.Value = "2025-01-15";
                program.V0FOLL_HORAOPER.Value = "00:00:00";
                program.V0FOLL_DTLIBER.Value = "2025-01-15";
                program.V0FOLL_DTQITBCO.Value = "2025-01-15";
                
                program.R4100_00_INSERT_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*22*/
                program.V0AVIS_DTMOVTO.Value = "2025-01-15";
                program.V0AVIS_DTAVISO.Value = "2025-01-15";
                program.R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*23*/
                program.V0SALD_DTAVISO.Value = "2025-01-15";
                program.V0SALD_DTMOVTO.Value = "2025-01-15";
                program.R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*24*/
                program.V0CNAB_DTMOVTO.Value = "2025-01-15";
                program.V0CNAB_DATCEF.Value = "2025-01-15";
                program.R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*25*/
                program.V0CFEN_DTCREDITO.Value = "2025-01-15";
                program.V0CFEN_DTQITBCO.Value = "2025-01-15";
                program.V0CFEN_DTMOVTO.Value = "2025-01-15";
                program.V0CFEN_DTPAGGER.Value = "2025-01-15";
                program.V0CFEN_DTCANCEL.Value = "2025-01-15";
                program.V0CFEN_DTPAGSUN.Value = "2025-01-15"; 
                program.R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*26*/
                program.V0VEND_DTQITBCO.Value = "2025-01-15";
                program.V0VEND_DTMOVTO.Value = "2025-01-15";
                program.R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*27*/
                program.V0TRBL_DTMOVTO.Value = "2025-01-15";
                program.R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*28*/
                program.V0ADIA_DTMOVTO.Value = "2025-01-15"; 
                program.R7100_00_INSERT_V0ADIANTA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*29*/
                program.V0FREC_DTMOVTO.Value = "2025-01-15";
                program.V0FREC_DTVENCTO.Value = "2025-01-15";
                program.R7200_00_INSERT_V0FORMAREC_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*30*/
                program.V0HREC_DTMOVTO.Value = "2025-01-15";
                program.V0HREC_HORSIS.Value = "00:00:00"; 
                program.R7300_00_INSERT_V0HISTOREC_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R8150_00_SELECT_V0BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*33*/
                program.V0DPCF_DTMOVTO.Value = "2025-01-15";
                program.V0DPCF_DTAVISO.Value = "2025-01-15";
                program.R8700_00_INSERT_DESPESAS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*34*/
                program.V0SICB_DTCREDITO.Value = "2025-01-15";
                program.V0SICB_DTQITBCO.Value = "2025-01-15";
                program.V0SICB_DTMOVTO.Value = "2025-01-15";
                program.R8850_00_INSERT_V0COMISICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}