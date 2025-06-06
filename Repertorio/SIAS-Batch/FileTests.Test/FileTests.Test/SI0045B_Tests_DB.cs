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
using static Code.SI0045B;

namespace FileTests.Test_DB
{
    [Collection("SI0045B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0045B_Tests_DB
    {

        [Fact]
        public static void SI0045B_Database()
        {
            var program = new SI0045B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
            var hourMock = DateTime.Now.AddDays(-100).ToString("hh:mm:ss");

            try
            { /*1*/
                program.R0500_00_LE_SISTEMAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.R0900_00_DECLARA_JOIN_DB_DECLARE_1();
                program.R0900_00_DECLARA_JOIN_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R2900_00_INSERE_FASE_SINIST_DB_DECLARE_1();
                program.R2900_00_INSERE_FASE_SINIST_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R1502_00_LEITURA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Value = fullDataMock;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO.Value = fullDataMock;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.Value = fullDataMock;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO.Value = hourMock;

                program.R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.R2810_00_MAX_SISINACO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_HORA_OPERACAO.Value = hourMock;
                program.SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DATA_OPERACAO.Value = fullDataMock;

                program.R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.R4200_00_ACESSA_USUARIOS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*21*/
                program.R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}