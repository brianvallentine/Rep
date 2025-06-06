using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRPROPOS
            INTO :V0ENDO-NRPROPOS
            FROM SEGUROS.V0ENDOSSO
            WHERE FONTE = :V0ENDO-FONTE
            AND NRPROPOS = :V1FONT-PROPAUTOM
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRPROPOS
											FROM SEGUROS.V0ENDOSSO
											WHERE FONTE = '{this.V0ENDO_FONTE}'
											AND NRPROPOS = '{this.V1FONT_PROPAUTOM}'";

            return query;
        }
        public string V0ENDO_NRPROPOS { get; set; }
        public string V1FONT_PROPAUTOM { get; set; }
        public string V0ENDO_FONTE { get; set; }

        public static R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1 Execute(R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1 r1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_NRPROPOS = result[i++].Value?.ToString();
            return dta;
        }

    }
}