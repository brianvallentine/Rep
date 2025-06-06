using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 : QueryBasis<R2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU
            INTO :V0MSIN-CODPRODU:VIND-CODPRODU
            FROM SEGUROS.V0MESTSINI
            WHERE NUM_APOL_SINISTRO = :V0MSIN-NUMAPOL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
											FROM SEGUROS.V0MESTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V0MSIN_NUMAPOL}'
											WITH UR";

            return query;
        }
        public string V0MSIN_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string V0MSIN_NUMAPOL { get; set; }

        public static R2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 Execute(R2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 r2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1)
        {
            var ths = r2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0MSIN_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.V0MSIN_CODPRODU) ? "-1" : "0";
            return dta;
        }

    }
}