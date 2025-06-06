using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R1025_00_SELECT_V0RCAP_Query1 : QueryBasis<R1025_00_SELECT_V0RCAP_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRRCAP
            , SITUACAO
            INTO :WHOST-NRRCAP
            , :WHOST-SITUACAO
            FROM SEGUROS.V0RCAP
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND OPERACAO >= 100
            AND OPERACAO <= 299
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NRRCAP
											, SITUACAO
											FROM SEGUROS.V0RCAP
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND OPERACAO >= 100
											AND OPERACAO <= 299";

            return query;
        }
        public string WHOST_NRRCAP { get; set; }
        public string WHOST_SITUACAO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1025_00_SELECT_V0RCAP_Query1 Execute(R1025_00_SELECT_V0RCAP_Query1 r1025_00_SELECT_V0RCAP_Query1)
        {
            var ths = r1025_00_SELECT_V0RCAP_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1025_00_SELECT_V0RCAP_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1025_00_SELECT_V0RCAP_Query1();
            var i = 0;
            dta.WHOST_NRRCAP = result[i++].Value?.ToString();
            dta.WHOST_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}