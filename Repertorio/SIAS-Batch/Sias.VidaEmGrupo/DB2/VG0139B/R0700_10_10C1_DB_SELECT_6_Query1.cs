using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R0700_10_10C1_DB_SELECT_6_Query1 : QueryBasis<R0700_10_10C1_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG
            ,(DTINIVIG + :V0OPCP-PERIPGTO MONTHS)
            INTO :WHOST-DTINIVIG
            ,:WHOST-DTENDFIM
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE
            AND NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
											,(DTINIVIG + {this.V0OPCP_PERIPGTO} MONTHS)
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V0HCTB_NUM_APOLICE}'
											AND NRENDOS = 0";

            return query;
        }
        public string WHOST_DTINIVIG { get; set; }
        public string WHOST_DTENDFIM { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }

        public static R0700_10_10C1_DB_SELECT_6_Query1 Execute(R0700_10_10C1_DB_SELECT_6_Query1 r0700_10_10C1_DB_SELECT_6_Query1)
        {
            var ths = r0700_10_10C1_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_10_10C1_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_10_10C1_DB_SELECT_6_Query1();
            var i = 0;
            dta.WHOST_DTINIVIG = result[i++].Value?.ToString();
            dta.WHOST_DTENDFIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}