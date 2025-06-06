using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1 : QueryBasis<R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MOVIMENTO
            , COD_RETORNO
            INTO :GE409-COD-MOVIMENTO
            , :GE409-COD-RETORNO
            FROM SEGUROS.GE_DES_RETORNO_CIELO
            WHERE COD_MOVIMENTO = :GE409-COD-MOVIMENTO
            AND COD_RETORNO = :GE409-COD-RETORNO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_MOVIMENTO
											, COD_RETORNO
											FROM SEGUROS.GE_DES_RETORNO_CIELO
											WHERE COD_MOVIMENTO = '{this.GE409_COD_MOVIMENTO}'
											AND COD_RETORNO = '{this.GE409_COD_RETORNO}'
											WITH UR";

            return query;
        }
        public string GE409_COD_MOVIMENTO { get; set; }
        public string GE409_COD_RETORNO { get; set; }

        public static R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1 Execute(R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1 r0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1)
        {
            var ths = r0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE409_COD_MOVIMENTO = result[i++].Value?.ToString();
            dta.GE409_COD_RETORNO = result[i++].Value?.ToString();
            return dta;
        }

    }
}