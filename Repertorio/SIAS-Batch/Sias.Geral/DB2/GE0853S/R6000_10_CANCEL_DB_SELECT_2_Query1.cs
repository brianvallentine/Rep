using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R6000_10_CANCEL_DB_SELECT_2_Query1 : QueryBasis<R6000_10_CANCEL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MIN(NRPARCEL)
            INTO :WHOST-NRPARCEL:VIND-NRPARCEL
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HISC-NRCERTIF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MIN(NRPARCEL)
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HISC_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string WHOST_NRPARCEL { get; set; }
        public string VIND_NRPARCEL { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static R6000_10_CANCEL_DB_SELECT_2_Query1 Execute(R6000_10_CANCEL_DB_SELECT_2_Query1 r6000_10_CANCEL_DB_SELECT_2_Query1)
        {
            var ths = r6000_10_CANCEL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_10_CANCEL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_10_CANCEL_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_NRPARCEL = result[i++].Value?.ToString();
            dta.VIND_NRPARCEL = string.IsNullOrWhiteSpace(dta.WHOST_NRPARCEL) ? "-1" : "0";
            return dta;
        }

    }
}