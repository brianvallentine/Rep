using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R2400_00_LE_SINIITEM_DB_SELECT_1_Query1 : QueryBasis<R2400_00_LE_SINIITEM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.SINISTRO_ITEM A,
            SEGUROS.CLIENTES B
            WHERE A.NUM_APOL_SINISTRO
            = :SINISHIS-NUM-APOL-SINISTRO
            AND A.COD_CLIENTE = B.COD_CLIENTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.NOME_RAZAO
											FROM SEGUROS.SINISTRO_ITEM A
							,
											SEGUROS.CLIENTES B
											WHERE A.NUM_APOL_SINISTRO
											= '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND A.COD_CLIENTE = B.COD_CLIENTE";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R2400_00_LE_SINIITEM_DB_SELECT_1_Query1 Execute(R2400_00_LE_SINIITEM_DB_SELECT_1_Query1 r2400_00_LE_SINIITEM_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_LE_SINIITEM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_LE_SINIITEM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_LE_SINIITEM_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}