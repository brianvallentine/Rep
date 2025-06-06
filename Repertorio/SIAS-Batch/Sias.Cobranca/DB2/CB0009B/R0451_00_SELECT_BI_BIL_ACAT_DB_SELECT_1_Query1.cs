using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1 : QueryBasis<R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO
            INTO :BI-COD-USUARIO
            FROM SEGUROS.BI_BILHETE_ACATADO
            WHERE NUM_BILHETE = :V0BILH-NUMBIL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
											FROM SEGUROS.BI_BILHETE_ACATADO
											WHERE NUM_BILHETE = '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string BI_COD_USUARIO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1 Execute(R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1 r0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1)
        {
            var ths = r0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1();
            var i = 0;
            dta.BI_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}