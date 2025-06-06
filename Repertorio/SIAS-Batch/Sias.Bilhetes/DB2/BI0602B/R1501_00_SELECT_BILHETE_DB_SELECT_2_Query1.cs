using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0602B
{
    public class R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1 : QueryBasis<R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            CGCCPF
            INTO
            :CLIENTES-CGCCPF
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :WS-CLIENTE-AUX
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											CGCCPF
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.WS_CLIENTE_AUX}'";

            return query;
        }
        public string CLIENTES_CGCCPF { get; set; }
        public string WS_CLIENTE_AUX { get; set; }

        public static R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1 Execute(R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1 r1501_00_SELECT_BILHETE_DB_SELECT_2_Query1)
        {
            var ths = r1501_00_SELECT_BILHETE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1();
            var i = 0;
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}