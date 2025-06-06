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
    public class R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1 : QueryBasis<R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(ESTADO_CIVIL, ' ' )
            INTO :DCLCLIENTES.ESTADO-CIVIL
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(ESTADO_CIVIL
							, ' ' )
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.COD_CLIENTE}'";

            return query;
        }
        public string ESTADO_CIVIL { get; set; }
        public string COD_CLIENTE { get; set; }

        public static R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1 Execute(R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1 r2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1)
        {
            var ths = r2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.ESTADO_CIVIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}