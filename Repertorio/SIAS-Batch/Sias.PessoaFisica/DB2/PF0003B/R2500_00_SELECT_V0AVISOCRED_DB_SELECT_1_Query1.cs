using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0003B
{
    public class R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1 : QueryBasis<R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT-AVS:VIND-COUNT
            FROM SEGUROS.V0AVISOCRED
            WHERE AGEAVISO = :V0AVIS-AGEAVISO
            AND NRAVISO = :V0AVIS-NRAVISO
            AND NRSEQ = :V0AVIS-NRSEQ
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.V0AVISOCRED
											WHERE AGEAVISO = '{this.V0AVIS_AGEAVISO}'
											AND NRAVISO = '{this.V0AVIS_NRAVISO}'
											AND NRSEQ = '{this.V0AVIS_NRSEQ}'
											WITH UR";

            return query;
        }
        public string WHOST_COUNT_AVS { get; set; }
        public string VIND_COUNT { get; set; }
        public string V0AVIS_AGEAVISO { get; set; }
        public string V0AVIS_NRAVISO { get; set; }
        public string V0AVIS_NRSEQ { get; set; }

        public static R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1 Execute(R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1 r2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT_AVS = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.WHOST_COUNT_AVS) ? "-1" : "0";
            return dta;
        }

    }
}