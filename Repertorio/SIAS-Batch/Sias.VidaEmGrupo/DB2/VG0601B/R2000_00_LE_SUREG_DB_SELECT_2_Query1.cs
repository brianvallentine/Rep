using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0601B
{
    public class R2000_00_LE_SUREG_DB_SELECT_2_Query1 : QueryBasis<R2000_00_LE_SUREG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SUREG_SASSE
            INTO :MALHACEF-COD-SUREG-SASSE
            FROM SEGUROS.MALHA_CEF
            WHERE COD_SUREG = :AGENCCEF-COD-ESCNEG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SUREG_SASSE
											FROM SEGUROS.MALHA_CEF
											WHERE COD_SUREG = '{this.AGENCCEF_COD_ESCNEG}'";

            return query;
        }
        public string MALHACEF_COD_SUREG_SASSE { get; set; }
        public string AGENCCEF_COD_ESCNEG { get; set; }

        public static R2000_00_LE_SUREG_DB_SELECT_2_Query1 Execute(R2000_00_LE_SUREG_DB_SELECT_2_Query1 r2000_00_LE_SUREG_DB_SELECT_2_Query1)
        {
            var ths = r2000_00_LE_SUREG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_LE_SUREG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_LE_SUREG_DB_SELECT_2_Query1();
            var i = 0;
            dta.MALHACEF_COD_SUREG_SASSE = result[i++].Value?.ToString();
            return dta;
        }

    }
}