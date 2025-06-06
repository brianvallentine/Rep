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
    public class R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            MAX(B.NRENDOS)
            INTO :WS-ENDOSSO:WS-NULL-ENDOSSO
            FROM SEGUROS.V0PARCELA A,
            SEGUROS.V0HISTOPARC B,
            SEGUROS.ENDOSSOS C
            WHERE A.NUM_APOLICE = :V1BILH-NUM-APOL
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NRENDOS = A.NRENDOS
            AND B.NRPARCEL = A.NRPARCEL
            AND B.OCORHIST = A.OCORHIST
            AND B.OPERACAO BETWEEN 200 AND 299
            AND B.NUM_APOLICE = C.NUM_APOLICE
            AND B.NRENDOS = C.NUM_ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											MAX(B.NRENDOS)
											FROM SEGUROS.V0PARCELA A
							,
											SEGUROS.V0HISTOPARC B
							,
											SEGUROS.ENDOSSOS C
											WHERE A.NUM_APOLICE = '{this.V1BILH_NUM_APOL}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NRENDOS = A.NRENDOS
											AND B.NRPARCEL = A.NRPARCEL
											AND B.OCORHIST = A.OCORHIST
											AND B.OPERACAO BETWEEN 200 AND 299
											AND B.NUM_APOLICE = C.NUM_APOLICE
											AND B.NRENDOS = C.NUM_ENDOSSO";

            return query;
        }
        public string WS_ENDOSSO { get; set; }
        public string WS_NULL_ENDOSSO { get; set; }
        public string V1BILH_NUM_APOL { get; set; }

        public static R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1 Execute(R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1 r0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_ENDOSSO = result[i++].Value?.ToString();
            dta.WS_NULL_ENDOSSO = string.IsNullOrWhiteSpace(dta.WS_ENDOSSO) ? "-1" : "0";
            return dta;
        }

    }
}