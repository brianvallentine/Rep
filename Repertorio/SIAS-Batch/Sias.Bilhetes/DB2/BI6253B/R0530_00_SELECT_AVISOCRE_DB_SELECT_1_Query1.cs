using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6253B
{
    public class R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 : QueryBasis<R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(NUM_AVISO_CREDITO)
            INTO :AVISOCRE-NUM-AVISO-CREDITO:VIND-NRAVISO
            FROM SEGUROS.AVISO_CREDITO
            WHERE BCO_AVISO =
            :AVISOCRE-BCO-AVISO
            AND AGE_AVISO =
            :AVISOCRE-AGE-AVISO
            AND NUM_AVISO_CREDITO >= 802100000
            AND NUM_AVISO_CREDITO <= 802199999
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(NUM_AVISO_CREDITO)
											FROM SEGUROS.AVISO_CREDITO
											WHERE BCO_AVISO =
											'{this.AVISOCRE_BCO_AVISO}'
											AND AGE_AVISO =
											'{this.AVISOCRE_AGE_AVISO}'
											AND NUM_AVISO_CREDITO >= 802100000
											AND NUM_AVISO_CREDITO <= 802199999
											WITH UR";

            return query;
        }
        public string AVISOCRE_NUM_AVISO_CREDITO { get; set; }
        public string VIND_NRAVISO { get; set; }
        public string AVISOCRE_BCO_AVISO { get; set; }
        public string AVISOCRE_AGE_AVISO { get; set; }

        public static R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 Execute(R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 r0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1)
        {
            var ths = r0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.AVISOCRE_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.VIND_NRAVISO = string.IsNullOrWhiteSpace(dta.AVISOCRE_NUM_AVISO_CREDITO) ? "-1" : "0";
            return dta;
        }

    }
}