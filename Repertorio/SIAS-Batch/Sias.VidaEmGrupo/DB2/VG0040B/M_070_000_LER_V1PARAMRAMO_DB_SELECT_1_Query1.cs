using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0040B
{
    public class M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 : QueryBasis<M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA
            INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP,
            :V1PAR-RAMO-PST
            FROM SEGUROS.V1PARAMRAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_VG
							, RAMO_AP
							, NUM_RAMO_PRSTMISTA
											FROM SEGUROS.V1PARAMRAMO";

            return query;
        }
        public string V1PAR_RAMO_VG { get; set; }
        public string V1PAR_RAMO_AP { get; set; }
        public string V1PAR_RAMO_PST { get; set; }

        public static M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 Execute(M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1)
        {
            var ths = m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PAR_RAMO_VG = result[i++].Value?.ToString();
            dta.V1PAR_RAMO_AP = result[i++].Value?.ToString();
            dta.V1PAR_RAMO_PST = result[i++].Value?.ToString();
            return dta;
        }

    }
}