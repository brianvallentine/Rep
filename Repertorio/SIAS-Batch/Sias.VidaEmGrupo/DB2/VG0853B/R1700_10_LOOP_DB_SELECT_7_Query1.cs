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
    public class R1700_10_LOOP_DB_SELECT_7_Query1 : QueryBasis<R1700_10_LOOP_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DTINIVIG,
            DTTERVIG,
            DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH - 1 DAY,
            DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH,
            CASE WHEN
            DTTERVIG <> '9999-12-31'
            THEN (DTTERVIG + 1 DAY)
            ELSE DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH
            END
            INTO
            :WHOST-DTINIVIG,
            :WHOST-DTTERVIG-ORIG,
            :WHOST-DTTERVIG,
            :WHOST-DTINIVIG-NEW,
            :WHOST-DTINIVIG-NEW2
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTINIVIG <= :V0PARC-DTVENCTO-PAR
            AND DTTERVIG >= :V0PARC-DTVENCTO-PAR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DTINIVIG
							,
											DTTERVIG
							,
											DTINIVIG + {this.V0OPCP_PERIPGTO_ANT} MONTH - 1 DAY
							,
											DTINIVIG + {this.V0OPCP_PERIPGTO_ANT} MONTH
							,
											CASE WHEN
											DTTERVIG <> '9999-12-31'
											THEN (DTTERVIG + 1 DAY)
											ELSE DTINIVIG + {this.V0OPCP_PERIPGTO_ANT} MONTH
											END
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTINIVIG <= '{this.V0PARC_DTVENCTO_PAR}'
											AND DTTERVIG >= '{this.V0PARC_DTVENCTO_PAR}'";

            return query;
        }
        public string WHOST_DTINIVIG { get; set; }
        public string WHOST_DTTERVIG_ORIG { get; set; }
        public string WHOST_DTTERVIG { get; set; }
        public string WHOST_DTINIVIG_NEW { get; set; }
        public string WHOST_DTINIVIG_NEW2 { get; set; }
        public string V0PARC_DTVENCTO_PAR { get; set; }
        public string V0OPCP_PERIPGTO_ANT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1700_10_LOOP_DB_SELECT_7_Query1 Execute(R1700_10_LOOP_DB_SELECT_7_Query1 r1700_10_LOOP_DB_SELECT_7_Query1)
        {
            var ths = r1700_10_LOOP_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_10_LOOP_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_10_LOOP_DB_SELECT_7_Query1();
            var i = 0;
            dta.WHOST_DTINIVIG = result[i++].Value?.ToString();
            dta.WHOST_DTTERVIG_ORIG = result[i++].Value?.ToString();
            dta.WHOST_DTTERVIG = result[i++].Value?.ToString();
            dta.WHOST_DTINIVIG_NEW = result[i++].Value?.ToString();
            dta.WHOST_DTINIVIG_NEW2 = result[i++].Value?.ToString();
            return dta;
        }

    }
}