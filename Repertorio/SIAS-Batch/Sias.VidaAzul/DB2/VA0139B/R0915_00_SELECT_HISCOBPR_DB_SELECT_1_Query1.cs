using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
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
            IMPDIT,
            PRMDIT
            INTO :V0CBPR-IMPMORNATU ,
            :V0CBPR-IMPMORACID ,
            :V0CBPR-IMPINVPERM ,
            :V0CBPR-IMPAMDS ,
            :V0CBPR-IMPDH ,
            :V0CBPR-IMPDIT ,
            :V0CBPR-PRMDIT:V0CBPR-PRMDIT-I
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0HCTB-NRCERTIF
            AND OCORHIST = :V0PROP-OCORHIST
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
							,
											PRMDIT
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0HCTB_NRCERTIF}'
											AND OCORHIST = '{this.V0PROP_OCORHIST}'";

            return query;
        }
        public string V0CBPR_IMPMORNATU { get; set; }
        public string V0CBPR_IMPMORACID { get; set; }
        public string V0CBPR_IMPINVPERM { get; set; }
        public string V0CBPR_IMPAMDS { get; set; }
        public string V0CBPR_IMPDH { get; set; }
        public string V0CBPR_IMPDIT { get; set; }
        public string V0CBPR_PRMDIT { get; set; }
        public string V0CBPR_PRMDIT_I { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0PROP_OCORHIST { get; set; }

        public static R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CBPR_IMPMORNATU = result[i++].Value?.ToString();
            dta.V0CBPR_IMPMORACID = result[i++].Value?.ToString();
            dta.V0CBPR_IMPINVPERM = result[i++].Value?.ToString();
            dta.V0CBPR_IMPAMDS = result[i++].Value?.ToString();
            dta.V0CBPR_IMPDH = result[i++].Value?.ToString();
            dta.V0CBPR_IMPDIT = result[i++].Value?.ToString();
            dta.V0CBPR_PRMDIT = result[i++].Value?.ToString();
            dta.V0CBPR_PRMDIT_I = string.IsNullOrWhiteSpace(dta.V0CBPR_PRMDIT) ? "-1" : "0";
            return dta;
        }

    }
}