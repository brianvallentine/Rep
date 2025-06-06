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
    public class R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 : QueryBasis<R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA,
            DATA_ADMISSAO
            INTO :V0SEGVG-DTINIVIG,
            :V0SEGVG-DTRENOVA:V0SEGVG-DTRENOVA-IND
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
							,
											DATA_ADMISSAO
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string V0SEGVG_DTINIVIG { get; set; }
        public string V0SEGVG_DTRENOVA { get; set; }
        public string V0SEGVG_DTRENOVA_IND { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 Execute(R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 r1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1)
        {
            var ths = r1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SEGVG_DTINIVIG = result[i++].Value?.ToString();
            dta.V0SEGVG_DTRENOVA = result[i++].Value?.ToString();
            dta.V0SEGVG_DTRENOVA_IND = string.IsNullOrWhiteSpace(dta.V0SEGVG_DTRENOVA) ? "-1" : "0";
            return dta;
        }

    }
}