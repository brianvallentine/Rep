using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R5000_00_BUSCA_VLPREMIO_Query2 : QueryBasis<R5000_00_BUSCA_VLPREMIO_Query2>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIO
            INTO :WHOST-VLPREMIO-REL
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTTERVIG = '9999-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VLPREMIO
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTTERVIG = '9999-12-31'
											WITH UR";

            return query;
        }
        public string WHOST_VLPREMIO_REL { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R5000_00_BUSCA_VLPREMIO_Query2 Execute(R5000_00_BUSCA_VLPREMIO_Query2 r5000_00_BUSCA_VLPREMIO_Query2)
        {
            var ths = r5000_00_BUSCA_VLPREMIO_Query2;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5000_00_BUSCA_VLPREMIO_Query2 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5000_00_BUSCA_VLPREMIO_Query2();
            var i = 0;
            dta.WHOST_VLPREMIO_REL = result[i++].Value?.ToString();
            return dta;
        }

    }
}