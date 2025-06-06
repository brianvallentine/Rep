using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1139B
{
    public class R1210_00_ACUMULA_IS_DB_SELECT_1_Query1 : QueryBasis<R1210_00_ACUMULA_IS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPMORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT
            INTO :V0CBPR-IMPMORNATU,
            :V0CBPR-IMPMORACID,
            :V0CBPR-IMPINVPERM,
            :V0CBPR-IMPAMDS,
            :V0CBPR-IMPDH,
            :V0CBPR-IMPDIT
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTINIVIG <= :V0ENDO-DTTERVIG
            AND DTTERVIG >= :V0ENDO-DTTERVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPMORNATU
							,
											IMPMORACID
							,
											IMPINVPERM
							,
											IMPAMDS
							,
											IMPDH
							,
											IMPDIT
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTINIVIG <= '{this.V0ENDO_DTTERVIG}'
											AND DTTERVIG >= '{this.V0ENDO_DTTERVIG}'";

            return query;
        }
        public string V0CBPR_IMPMORNATU { get; set; }
        public string V0CBPR_IMPMORACID { get; set; }
        public string V0CBPR_IMPINVPERM { get; set; }
        public string V0CBPR_IMPAMDS { get; set; }
        public string V0CBPR_IMPDH { get; set; }
        public string V0CBPR_IMPDIT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0ENDO_DTTERVIG { get; set; }

        public static R1210_00_ACUMULA_IS_DB_SELECT_1_Query1 Execute(R1210_00_ACUMULA_IS_DB_SELECT_1_Query1 r1210_00_ACUMULA_IS_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_ACUMULA_IS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_ACUMULA_IS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_ACUMULA_IS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CBPR_IMPMORNATU = result[i++].Value?.ToString();
            dta.V0CBPR_IMPMORACID = result[i++].Value?.ToString();
            dta.V0CBPR_IMPINVPERM = result[i++].Value?.ToString();
            dta.V0CBPR_IMPAMDS = result[i++].Value?.ToString();
            dta.V0CBPR_IMPDH = result[i++].Value?.ToString();
            dta.V0CBPR_IMPDIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}