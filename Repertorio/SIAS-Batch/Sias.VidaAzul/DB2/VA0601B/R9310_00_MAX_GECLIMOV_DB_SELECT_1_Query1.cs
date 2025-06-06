using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 : QueryBasis<R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_HIST), 0)
            INTO :GECLIMOV-OCORR-HIST
            FROM SEGUROS.GE_CLIENTES_MOVTO
            WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_HIST)
							, 0)
											FROM SEGUROS.GE_CLIENTES_MOVTO
											WHERE COD_CLIENTE = '{this.GECLIMOV_COD_CLIENTE}'";

            return query;
        }
        public string GECLIMOV_OCORR_HIST { get; set; }
        public string GECLIMOV_COD_CLIENTE { get; set; }

        public static R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 Execute(R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1)
        {
            var ths = r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1();
            var i = 0;
            dta.GECLIMOV_OCORR_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}