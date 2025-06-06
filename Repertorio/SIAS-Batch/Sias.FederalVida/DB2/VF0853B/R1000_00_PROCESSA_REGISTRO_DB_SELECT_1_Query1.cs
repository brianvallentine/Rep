using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0853B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA + 7 MONTHS,
            DATA_INIVIGENCIA + 11 MONTHS,
            DATA_INIVIGENCIA + 3 MONTHS,
            DATA_INIVIGENCIA + 7 MONTHS
            INTO :V0SEGU-DTINISAF,
            :V0SEGU-DTINIRTO,
            :V0SEGU-DTINIDIT,
            :V0SEGU-DTINIDFT
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA + 7 MONTHS
							,
											DATA_INIVIGENCIA + 11 MONTHS
							,
											DATA_INIVIGENCIA + 3 MONTHS
							,
											DATA_INIVIGENCIA + 7 MONTHS
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string V0SEGU_DTINISAF { get; set; }
        public string V0SEGU_DTINIRTO { get; set; }
        public string V0SEGU_DTINIDIT { get; set; }
        public string V0SEGU_DTINIDFT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SEGU_DTINISAF = result[i++].Value?.ToString();
            dta.V0SEGU_DTINIRTO = result[i++].Value?.ToString();
            dta.V0SEGU_DTINIDIT = result[i++].Value?.ToString();
            dta.V0SEGU_DTINIDFT = result[i++].Value?.ToString();
            return dta;
        }

    }
}