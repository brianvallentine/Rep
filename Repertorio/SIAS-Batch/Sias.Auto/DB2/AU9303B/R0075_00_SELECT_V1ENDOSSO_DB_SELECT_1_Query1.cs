using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU9303B
{
    public class R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V1ENDO-SITUACAO
            FROM SEGUROS.V1ENDOSSO
            WHERE NUM_APOLICE = :V1AUTA-NUM-APOLICE
            AND NRENDOS = :V1AUTA-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V1ENDOSSO
											WHERE NUM_APOLICE = '{this.V1AUTA_NUM_APOLICE}'
											AND NRENDOS = '{this.V1AUTA_NRENDOS}'";

            return query;
        }
        public string V1ENDO_SITUACAO { get; set; }
        public string V1AUTA_NUM_APOLICE { get; set; }
        public string V1AUTA_NRENDOS { get; set; }

        public static R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 Execute(R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 r0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}