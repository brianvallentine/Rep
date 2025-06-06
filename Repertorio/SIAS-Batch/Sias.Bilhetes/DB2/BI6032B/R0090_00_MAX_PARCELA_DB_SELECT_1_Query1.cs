using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6032B
{
    public class R0090_00_MAX_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R0090_00_MAX_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            MAX(B.NRPARCEL)
            INTO :WS-PARCELA:WS-NULL-PARCEL
            FROM SEGUROS.V0PARCELA A,
            SEGUROS.V0HISTOPARC B
            WHERE A.NUM_APOLICE = :V1BILH-NUM-APOL
            AND A.NRENDOS = 0
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NRENDOS = A.NRENDOS
            AND B.NRPARCEL = A.NRPARCEL
            AND B.OCORHIST = A.OCORHIST
            AND B.OPERACAO BETWEEN 200 AND 299
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											MAX(B.NRPARCEL)
											FROM SEGUROS.V0PARCELA A
							,
											SEGUROS.V0HISTOPARC B
											WHERE A.NUM_APOLICE = '{this.V1BILH_NUM_APOL}'
											AND A.NRENDOS = 0
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NRENDOS = A.NRENDOS
											AND B.NRPARCEL = A.NRPARCEL
											AND B.OCORHIST = A.OCORHIST
											AND B.OPERACAO BETWEEN 200 AND 299";

            return query;
        }
        public string WS_PARCELA { get; set; }
        public string WS_NULL_PARCEL { get; set; }
        public string V1BILH_NUM_APOL { get; set; }

        public static R0090_00_MAX_PARCELA_DB_SELECT_1_Query1 Execute(R0090_00_MAX_PARCELA_DB_SELECT_1_Query1 r0090_00_MAX_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r0090_00_MAX_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0090_00_MAX_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0090_00_MAX_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_PARCELA = result[i++].Value?.ToString();
            dta.WS_NULL_PARCEL = string.IsNullOrWhiteSpace(dta.WS_PARCELA) ? "-1" : "0";
            return dta;
        }

    }
}