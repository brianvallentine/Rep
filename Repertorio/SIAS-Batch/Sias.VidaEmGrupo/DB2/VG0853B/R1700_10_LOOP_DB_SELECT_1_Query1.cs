using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1700_10_LOOP_DB_SELECT_1_Query1 : QueryBasis<R1700_10_LOOP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DTINIVIG
            INTO
            :WHOST-DTINIVIG
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND OCORHIST = :V0PROP-NRPARCEL-NEW
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DTINIVIG
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND OCORHIST = '{this.V0PROP_NRPARCEL_NEW}'";

            return query;
        }
        public string WHOST_DTINIVIG { get; set; }
        public string V0PROP_NRPARCEL_NEW { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1700_10_LOOP_DB_SELECT_1_Query1 Execute(R1700_10_LOOP_DB_SELECT_1_Query1 r1700_10_LOOP_DB_SELECT_1_Query1)
        {
            var ths = r1700_10_LOOP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_10_LOOP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_10_LOOP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}