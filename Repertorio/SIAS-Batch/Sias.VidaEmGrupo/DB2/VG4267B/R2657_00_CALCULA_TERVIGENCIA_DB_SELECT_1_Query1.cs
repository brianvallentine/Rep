using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG4267B
{
    public class R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1 : QueryBasis<R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:WS-DTINIVIG-PARC)
            + (:V0OPCP-PERIPGTO) MONTHS,
            DATE(:WS-DTINIVIG-PARC)
            + (:V0OPCP-PERIPGTO) MONTHS
            - 1 DAYS
            - DATE(:WS-DTCALC-PARC)
            INTO :WS-DTTERVIG-PARC,
            :WS-QTD-DIAS-PARC
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VG'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.WS_DTINIVIG_PARC}')
											+ ({this.V0OPCP_PERIPGTO}) MONTHS
							,
											DATE('{this.WS_DTINIVIG_PARC}')
											+ ({this.V0OPCP_PERIPGTO}) MONTHS
											- 1 DAYS
											- DATE('{this.WS_DTCALC_PARC}')
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VG'
											WITH UR";

            return query;
        }
        public string WS_DTTERVIG_PARC { get; set; }
        public string WS_QTD_DIAS_PARC { get; set; }
        public string WS_DTINIVIG_PARC { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string WS_DTCALC_PARC { get; set; }

        public static R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1 Execute(R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1 r2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = r2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DTTERVIG_PARC = result[i++].Value?.ToString();
            dta.WS_QTD_DIAS_PARC = result[i++].Value?.ToString();
            return dta;
        }

    }
}