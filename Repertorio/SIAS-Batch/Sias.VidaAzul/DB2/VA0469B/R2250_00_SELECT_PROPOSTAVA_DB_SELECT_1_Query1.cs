using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO,
            COD_PRODUTO
            INTO :PROPOVA-SIT-REGISTRO,
            :PROPOVA-COD-PRODUTO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
							,
											COD_PRODUTO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 Execute(R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 r2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = r2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}