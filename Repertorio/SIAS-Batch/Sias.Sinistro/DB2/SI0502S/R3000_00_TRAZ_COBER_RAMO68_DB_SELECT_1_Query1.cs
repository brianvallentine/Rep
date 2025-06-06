using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0502S
{
    public class R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1 : QueryBasis<R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_COBERTURA
            INTO :SINIHAB1-COD-COBERTURA
            FROM SEGUROS.SINISTRO_HABIT01
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_COBERTURA
											FROM SEGUROS.SINISTRO_HABIT01
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINIHAB1_COD_COBERTURA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1 Execute(R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1 r3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1)
        {
            var ths = r3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIHAB1_COD_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}