using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9102B
{
    public class R1100_00_LE_SINISMES_DB_SELECT_1_Query1 : QueryBasis<R1100_00_LE_SINISMES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO,
            COD_CAUSA,
            COD_PRODUTO
            INTO :SINISMES-SIT-REGISTRO,
            :SINISMES-COD-CAUSA,
            :SINISMES-COD-PRODUTO
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
							,
											COD_CAUSA
							,
											COD_PRODUTO
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINISMES_SIT_REGISTRO { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }

        public static R1100_00_LE_SINISMES_DB_SELECT_1_Query1 Execute(R1100_00_LE_SINISMES_DB_SELECT_1_Query1 r1100_00_LE_SINISMES_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_LE_SINISMES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_LE_SINISMES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_LE_SINISMES_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}