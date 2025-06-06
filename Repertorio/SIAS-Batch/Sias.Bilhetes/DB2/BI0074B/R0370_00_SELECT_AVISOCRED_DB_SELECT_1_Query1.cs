using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0074B
{
    public class R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1 : QueryBasis<R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_AVISO_CREDITO
            INTO :AVISOCRE-NUM-AVISO-CREDITO
            FROM SEGUROS.AVISO_CREDITO
            WHERE BCO_AVISO =
            :AVISOCRE-BCO-AVISO
            AND AGE_AVISO =
            :AVISOCRE-AGE-AVISO
            AND NUM_AVISO_CREDITO =
            :AVISOCRE-NUM-AVISO-CREDITO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_AVISO_CREDITO
											FROM SEGUROS.AVISO_CREDITO
											WHERE BCO_AVISO =
											'{this.AVISOCRE_BCO_AVISO}'
											AND AGE_AVISO =
											'{this.AVISOCRE_AGE_AVISO}'
											AND NUM_AVISO_CREDITO =
											'{this.AVISOCRE_NUM_AVISO_CREDITO}'
											WITH UR";

            return query;
        }
        public string AVISOCRE_NUM_AVISO_CREDITO { get; set; }
        public string AVISOCRE_BCO_AVISO { get; set; }
        public string AVISOCRE_AGE_AVISO { get; set; }

        public static R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1 Execute(R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1 r0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1)
        {
            var ths = r0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1();
            var i = 0;
            dta.AVISOCRE_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}