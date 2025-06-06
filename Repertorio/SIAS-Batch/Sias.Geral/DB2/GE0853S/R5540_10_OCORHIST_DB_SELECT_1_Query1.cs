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
    public class R5540_10_OCORHIST_DB_SELECT_1_Query1 : QueryBasis<R5540_10_OCORHIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRCERTIF
            INTO :WHOST-NRCERTIF
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NRCERTIF = :V0HISC-NRCERTIF
            AND NRPARCEL = :V0HISC-NRPARCEL
            AND OCORRHISTCTA = :V0PARC-OCORHIST
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRCERTIF
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NRCERTIF = '{this.V0HISC_NRCERTIF}'
											AND NRPARCEL = '{this.V0HISC_NRPARCEL}'
											AND OCORRHISTCTA = '{this.V0PARC_OCORHIST}'
											WITH UR";

            return query;
        }
        public string WHOST_NRCERTIF { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }
        public string V0PARC_OCORHIST { get; set; }

        public static R5540_10_OCORHIST_DB_SELECT_1_Query1 Execute(R5540_10_OCORHIST_DB_SELECT_1_Query1 r5540_10_OCORHIST_DB_SELECT_1_Query1)
        {
            var ths = r5540_10_OCORHIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5540_10_OCORHIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5540_10_OCORHIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_NRCERTIF = result[i++].Value?.ToString();
            return dta;
        }

    }
}