using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 : QueryBasis<R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(NUM_AVISO_CREDITO)
            INTO :V0AVIS-NRAVISO:VIND-NRAVISO
            FROM SEGUROS.AVISO_CREDITO
            WHERE BCO_AVISO = :V0AVIS-BCOAVISO
            AND AGE_AVISO = :V0AVIS-AGEAVISO
            AND NUM_AVISO_CREDITO >= 902800000
            AND NUM_AVISO_CREDITO <= 902899998
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(NUM_AVISO_CREDITO)
											FROM SEGUROS.AVISO_CREDITO
											WHERE BCO_AVISO = '{this.V0AVIS_BCOAVISO}'
											AND AGE_AVISO = '{this.V0AVIS_AGEAVISO}'
											AND NUM_AVISO_CREDITO >= 902800000
											AND NUM_AVISO_CREDITO <= 902899998
											WITH UR";

            return query;
        }
        public string V0AVIS_NRAVISO { get; set; }
        public string VIND_NRAVISO { get; set; }
        public string V0AVIS_BCOAVISO { get; set; }
        public string V0AVIS_AGEAVISO { get; set; }

        public static R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 Execute(R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 r2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1)
        {
            var ths = r2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0AVIS_NRAVISO = result[i++].Value?.ToString();
            dta.VIND_NRAVISO = string.IsNullOrWhiteSpace(dta.V0AVIS_NRAVISO) ? "-1" : "0";
            return dta;
        }

    }
}