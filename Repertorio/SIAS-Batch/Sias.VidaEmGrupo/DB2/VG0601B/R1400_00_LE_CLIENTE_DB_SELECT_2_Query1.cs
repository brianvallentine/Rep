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
    public class R1400_00_LE_CLIENTE_DB_SELECT_2_Query1 : QueryBasis<R1400_00_LE_CLIENTE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF,
            NOME_RAZAO
            INTO :CLIENTES-CGCCPF,
            :CLIENTES-NOME-RAZAO
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
							,
											NOME_RAZAO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static R1400_00_LE_CLIENTE_DB_SELECT_2_Query1 Execute(R1400_00_LE_CLIENTE_DB_SELECT_2_Query1 r1400_00_LE_CLIENTE_DB_SELECT_2_Query1)
        {
            var ths = r1400_00_LE_CLIENTE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_LE_CLIENTE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_LE_CLIENTE_DB_SELECT_2_Query1();
            var i = 0;
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}