using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2853B
{
    public class R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1 : QueryBasis<R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTTERVIG
            INTO :V0ENDO-DTTERVIG
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTTERVIG
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND NRENDOS = 0";

            return query;
        }
        public string V0ENDO_DTTERVIG { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }

        public static R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1 Execute(R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1 r1000_10_LEITURA_RAMO_DB_SELECT_2_Query1)
        {
            var ths = r1000_10_LEITURA_RAMO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0ENDO_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}