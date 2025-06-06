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
    public class R2000_00_LE_SUREG_DB_SELECT_3_Query1 : QueryBasis<R2000_00_LE_SUREG_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_SUREG_SASSE
            INTO :SUREGSAS-NOME-SUREG-SASSE
            FROM SEGUROS.SUREG_SASSE
            WHERE COD_SUREG_SASSE = :MALHACEF-COD-SUREG-SASSE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_SUREG_SASSE
											FROM SEGUROS.SUREG_SASSE
											WHERE COD_SUREG_SASSE = '{this.MALHACEF_COD_SUREG_SASSE}'";

            return query;
        }
        public string SUREGSAS_NOME_SUREG_SASSE { get; set; }
        public string MALHACEF_COD_SUREG_SASSE { get; set; }

        public static R2000_00_LE_SUREG_DB_SELECT_3_Query1 Execute(R2000_00_LE_SUREG_DB_SELECT_3_Query1 r2000_00_LE_SUREG_DB_SELECT_3_Query1)
        {
            var ths = r2000_00_LE_SUREG_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_LE_SUREG_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_LE_SUREG_DB_SELECT_3_Query1();
            var i = 0;
            dta.SUREGSAS_NOME_SUREG_SASSE = result[i++].Value?.ToString();
            return dta;
        }

    }
}