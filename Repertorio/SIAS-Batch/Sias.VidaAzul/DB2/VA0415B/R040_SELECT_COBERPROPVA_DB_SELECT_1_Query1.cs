using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0415B
{
    public class R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 : QueryBasis<R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG + 3.74,
            IMPSEGAUXF,
            VLCUSTAUXF
            INTO :V0COBV-VLPREMIO,
            :V0COBV-IMPSEGAUXF:V0COBV-IMPSEGAUXF-I,
            :V0COBV-VLCUSTAUXF:V0COBV-VLCUSTAUXF-I
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND OCORHIST = :V0PROP-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG + 3.74
							,
											IMPSEGAUXF
							,
											VLCUSTAUXF
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND OCORHIST = '{this.V0PROP_OCORHIST}'";

            return query;
        }
        public string V0COBV_VLPREMIO { get; set; }
        public string V0COBV_IMPSEGAUXF { get; set; }
        public string V0COBV_IMPSEGAUXF_I { get; set; }
        public string V0COBV_VLCUSTAUXF { get; set; }
        public string V0COBV_VLCUSTAUXF_I { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_OCORHIST { get; set; }

        public static R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 Execute(R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1)
        {
            var ths = r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COBV_VLPREMIO = result[i++].Value?.ToString();
            dta.V0COBV_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.V0COBV_IMPSEGAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBV_IMPSEGAUXF) ? "-1" : "0";
            dta.V0COBV_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.V0COBV_VLCUSTAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBV_VLCUSTAUXF) ? "-1" : "0";
            return dta;
        }

    }
}