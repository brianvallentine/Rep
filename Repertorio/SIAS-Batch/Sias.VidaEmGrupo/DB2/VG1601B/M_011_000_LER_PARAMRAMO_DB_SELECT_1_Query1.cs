using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1 : QueryBasis<M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_VGAPC,
            RAMO_VG,
            RAMO_AP,
            NUM_RAMO_PRSTMISTA
            INTO :PARAMRAM-RAMO-VGAPC,
            :PARAMRAM-RAMO-VG,
            :PARAMRAM-RAMO-AP,
            :PARAMRAM-NUM-RAMO-PRSTMISTA
            FROM SEGUROS.PARAMETROS_RAMOS
            WHERE
            1 = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_VGAPC
							,
											RAMO_VG
							,
											RAMO_AP
							,
											NUM_RAMO_PRSTMISTA
											FROM SEGUROS.PARAMETROS_RAMOS
											WHERE
											1 = 1";

            return query;
        }
        public string PARAMRAM_RAMO_VGAPC { get; set; }
        public string PARAMRAM_RAMO_VG { get; set; }
        public string PARAMRAM_RAMO_AP { get; set; }
        public string PARAMRAM_NUM_RAMO_PRSTMISTA { get; set; }

        public static M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1 Execute(M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1 m_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1)
        {
            var ths = m_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMRAM_RAMO_VGAPC = result[i++].Value?.ToString();
            dta.PARAMRAM_RAMO_VG = result[i++].Value?.ToString();
            dta.PARAMRAM_RAMO_AP = result[i++].Value?.ToString();
            dta.PARAMRAM_NUM_RAMO_PRSTMISTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}