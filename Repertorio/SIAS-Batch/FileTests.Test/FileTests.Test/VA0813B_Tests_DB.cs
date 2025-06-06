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
using static Code.VA0813B;

namespace FileTests.Test_DB
{
    [Collection("VA0813B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0813B_Tests_DB
    {

        [Fact]
        public static void VA0813B_Database()
        {
            var program = new VA0813B();
            var pData = "2025-03-07";
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            
            try
            {
                /*1*/
                program.M_0000_PRINCIPAL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*2*/
                program.V0HCTA_NRCERTIF.Value = 7457254811;
                program.V0HCTA_NRPARCEL.Value = 2;

                program.R0020_00_PROCESSA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*3*/
                program.R0020_00_PROCESSA_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*4*/
                program.R0020_00_PROCESSA_DB_SELECT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*5*/
                program.R0020_00_PROCESSA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*6*/
                program.R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*7*/
                program.R0020_00_PROCESSA_DB_UPDATE_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*8*/
                program.R0020_00_PROCESSA_DB_SELECT_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*9*/
                program.R0020_00_PROCESSA_DB_UPDATE_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*10*/
                program.R0020_00_PROCESSA_DB_UPDATE_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*11*/
                program.R0020_00_PROCESSA_DB_SELECT_5();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*12*/
                program.R0030_00_ACESSO_CERTIF_DB_DECLARE_1();
                program.R0030_00_ACESSO_CERTIF_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*13*/
                program.V0HCTA_AGECTADEB.Value = 1372;
                program.V0HCTA_OPRCTADEB.Value = 1;
                program.V0HCTA_NUMCTADEB.Value = 7286;
                program.V0HCTA_CODCONV.Value = 6088;
                program.V0HCTA_NSAS.Value = 27159;
                program.V0HCTA_VLPRMTOT.Value = 38.68;

                program.R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1();
                program.R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*14*/
                program.R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();
                program.R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*15*/
                program.V0HCTA_NSL.Value = 6088;
                program.R0036_00_ACESSO_NSAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*16*/
                program.R0040_00_SEL_V0HISTCOBVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*17*/
                program.R0041_00_SEL_V0HISTCOBVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*18*/
                program.R0042_00_SEL_V0HISTCOBVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*19*/
                program.R0042_00_SEL_V0HISTCOBVA_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*20*/
                program.R0050_00_GERA_FITACEF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*21*/
                program.V0FTCF_DTRET2.Value = "2025-03-06";

                program.R0053_00_UPDATE_FITACEF_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*22*/
                program.V0FTCF_NSAC.Value = new Random().Next(1000, 9999);

                program.R0055_00_INSERT_FITACEF_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*23*/
                program.V0AVIS_DTMOVTO.Value = pData;
                program.V0AVIS_DTAVISO.Value = pData;
                program.V0AVIS_BCOAVISO.Value = new Random().Next(0, 9999);

                program.V0AVIS_AGEAVISO.Value = new Random().Next(0, 9999);
                program.V0AVIS_NRAVISO.Value = new Random().Next(0, 9999);
                program.V0AVIS_NRSEQ.Value = new Random().Next(0, 9999);
                program.V0AVIS_OPERACAO.Value = 100;
                program.V0AVIS_TIPAVI.Value = "P";
                program.V0AVIS_VLIOCC.Value = 0;
                program.V0AVIS_VLDESPES.Value = 0;
                program.V0AVIS_PRECED.Value = 0;
                program.V0AVIS_VLPRMLIQ.Value = 0;
                program.V0AVIS_VLPRMTOT.Value = 0;
                program.V0AVIS_SITCONTB.Value = "0";
                program.V0AVIS_CODEMP.Value = 0;
                program.VIND_CODEMP.Value = 0;
                program.V0AVIS_ORIGAVISO.Value = 0;
                program.VIND_ORIGAVISO.Value = 0;
                program.V0AVIS_VALADT.Value = 0;
                program.VIND_VALADT.Value = 0;
                program.V0AVIS_SITDEPTER.Value = "P";

                program.R0100_00_INSERT_AVISOS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*24*/
                program.V0SALD_CODEMP.Value = new Random().Next(100, 9999);
                program.V0SALD_BCOAVISO.Value = new Random().Next(100, 9999);
                program.V0SALD_AGEAVISO.Value = new Random().Next(100, 9999);
                program.V0SALD_TIPSGU.Value = "";
                program.V0SALD_NRAVISO.Value = new Random().Next(100, 9999);
                program.V0SALD_DTAVISO.Value = "2025-05-02";
                program.V0SALD_DTMOVTO.Value = "2025-05-02";

                program.R0100_00_INSERT_AVISOS_DB_INSERT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*25*/
                program.R1000_00_QUITA_PARCELA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*26*/
                program.R1000_00_QUITA_PARCELA_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*27*/
                program.R0060_00_GERA_NOVO_NRTIT_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*28*/
                program.R0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*29*/
                program.R1000_00_QUITA_PARCELA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*30*/
                program.R1000_00_QUITA_PARCELA_DB_SELECT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*31*/
                program.R1000_00_QUITA_PARCELA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*32*/
                program.R1000_00_QUITA_PARCELA_DB_UPDATE_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*33*/
                program.R1000_00_QUITA_PARCELA_DB_SELECT_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*34*/
                program.R1000_00_QUITA_PARCELA_DB_UPDATE_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*35*/
                program.R1000_00_QUITA_PARCELA_DB_UPDATE_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*36*/
                program.R1000_00_QUITA_PARCELA_DB_SELECT_5();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*37*/
                program.R1000_00_QUITA_PARCELA_DB_UPDATE_5();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*38*/
                program.R1050_00_LOOP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*39*/
                program.R1000_00_QUITA_PARCELA_DB_SELECT_6();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*40*/
                program.R1000_00_QUITA_PARCELA_DB_UPDATE_6();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*41*/
                program.R1000_00_QUITA_PARCELA_DB_SELECT_7();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*42*/
                program.R1000_00_QUITA_PARCELA_DB_UPDATE_7();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*43*/
                program.V0RCDG_DTREFER.Value = pData;
                program.V0PROP_CODCLIEN.Value = new Random().Next(1000, 99999);

                program.R1099_00_INCLUI_CDG_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*44*/
                program.R1000_00_QUITA_PARCELA_DB_SELECT_8();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*45*/
                program.R1100_00_REPASSA_CDG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*46*/
                program.R1100_00_REPASSA_CDG_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*47*/
                program.V0RSAF_DTREFER.Value = pData;

                program.R1199_00_INCLUI_SAF_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*48*/
                program.R1199_00_INCLUI_SAF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*49*/
                program.R1199_00_INCLUI_SAF_DB_INSERT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*50*/
                program.R1200_00_REPASSA_SAF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*51*/
                program.R1200_00_REPASSA_SAF_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*52*/
                program.R2000_00_REJEITA_PARCELA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*53*/
                program.R2000_CONTINUA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*54*/
                program.R2000_CONTINUA_DB_UPDATE_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*55*/
                program.R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*56*/
                program.R2000_CONTINUA_DB_UPDATE_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {

                /*57*/
                program.V0OPCP_DTINIVIG.Value = pData;
                program.V0HCTA_NRCERTIF.Value = new Random().Next(1000, 99999);

                program.R2100_00_MUDA_OPCAOPAG_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*58*/
                program.R2100_00_MUDA_OPCAOPAG_DB_UPDATE_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*59*/
                program.R2000_CONTINUA_DB_UPDATE_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {

                /*60*/
                program.R2000_CONTINUA_DB_UPDATE_5();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*61*/
                program.R6900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1();
                program.R6900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*62*/
                program.R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*63*/
                program.R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*64*/
                program.R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*65*/
                program.V0COMI_DATCLO.Value = pData;
                program.VIND_DTMOVTO.Value = -1;
                program.VIND_DATSEL.Value = -1;
                program.VIND_DTQITBCO.Value = -1;

                program.R0400_00_INSERT_COMISSAO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*66*/
                program.R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*67*/
                program.R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*68*/
                program.R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*69*/
                program.R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*70*/
                program.R6920_00_SELECT_HISCOBPR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*71*/
                program.R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*72*/
                program.R7170_00_SELECT_CONDITEC_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*73*/
                program.R7200_00_INSERT_VGHISTCONT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*74*/
                program.R8010_00_VER_PRODUTO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*75*/
                program.V0DPCF_DTMOVTO.Value = "2025-03-02";
                program.V0DPCF_DTAVISO.Value = "2025-03-02";

                program.R8700_00_INSERT_DESPESAS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*76*/
                program.R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}