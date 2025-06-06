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
    public class R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WHOST-COUNT-DEB
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NRCERTIF = :V0HISC-NRCERTIF
            AND NRPARCEL = :V0HISC-NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NRCERTIF = '{this.V0HISC_NRCERTIF}'
											AND NRPARCEL = '{this.V0HISC_NRPARCEL}'
											WITH UR";

            return query;
        }
        public string WHOST_COUNT_DEB { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }

        public static R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1 Execute(R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1 r8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT_DEB = result[i++].Value?.ToString();
            return dta;
        }

    }
}