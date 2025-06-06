using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF
            INTO :CLIENTES-CGCCPF
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :V0PROP-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.V0PROP_CODCLIEN}'";

            return query;
        }
        public string CLIENTES_CGCCPF { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

        public static R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1 Execute(R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1 r1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}