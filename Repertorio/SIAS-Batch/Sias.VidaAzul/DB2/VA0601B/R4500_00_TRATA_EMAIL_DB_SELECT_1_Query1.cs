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
    public class R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1 : QueryBasis<R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT EMAIL
            INTO :CLIENEMA-EMAIL
            FROM SEGUROS.CLIENTE_EMAIL
            WHERE COD_CLIENTE = :WHOST-COD-CLIENTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT EMAIL
											FROM SEGUROS.CLIENTE_EMAIL
											WHERE COD_CLIENTE = '{this.WHOST_COD_CLIENTE}'";

            return query;
        }
        public string CLIENEMA_EMAIL { get; set; }
        public string WHOST_COD_CLIENTE { get; set; }

        public static R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1 Execute(R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1 r4500_00_TRATA_EMAIL_DB_SELECT_1_Query1)
        {
            var ths = r4500_00_TRATA_EMAIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENEMA_EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}