using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1139B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DTINIVIG,
            DTTERVIG
            INTO
            :V0COBP-DTINIVIG-ENDO,
            :V0COBP-DTTERVIG-ENDO
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0HCTB-NRCERTIF
            AND OCORHIST = :V0PROP-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DTINIVIG
							,
											DTTERVIG
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0HCTB_NRCERTIF}'
											AND OCORHIST = '{this.V0PROP_OCORHIST}'";

            return query;
        }
        public string V0COBP_DTINIVIG_ENDO { get; set; }
        public string V0COBP_DTTERVIG_ENDO { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0PROP_OCORHIST { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1();
            var i = 0;
            dta.V0COBP_DTINIVIG_ENDO = result[i++].Value?.ToString();
            dta.V0COBP_DTTERVIG_ENDO = result[i++].Value?.ToString();
            return dta;
        }

    }
}