using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R3010_00_LER_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R3010_00_LER_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRPROPOS
            INTO :V0ENDO-NRPROPOS
            FROM SEGUROS.V1ENDOSSO
            WHERE FONTE = :V0BILH-FONTE
            AND NRPROPOS = :V1FONT-PROPAUTOM
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NRPROPOS
											FROM SEGUROS.V1ENDOSSO
											WHERE FONTE = '{this.V0BILH_FONTE}'
											AND NRPROPOS = '{this.V1FONT_PROPAUTOM}'";

            return query;
        }
        public string V0ENDO_NRPROPOS { get; set; }
        public string V1FONT_PROPAUTOM { get; set; }
        public string V0BILH_FONTE { get; set; }

        public static R3010_00_LER_ENDOSSO_DB_SELECT_1_Query1 Execute(R3010_00_LER_ENDOSSO_DB_SELECT_1_Query1 r3010_00_LER_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r3010_00_LER_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3010_00_LER_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3010_00_LER_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_NRPROPOS = result[i++].Value?.ToString();
            return dta;
        }

    }
}