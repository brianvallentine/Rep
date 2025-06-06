using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1 : QueryBasis<R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :DCLCLIENTES.COD-CLIENTE
            FROM SEGUROS.CLIENTES
            WHERE CGCCPF = :DCLCLIENTES.CGCCPF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.CLIENTES
											WHERE CGCCPF = '{this.CGCCPF}'
											WITH UR";

            return query;
        }
        public string COD_CLIENTE { get; set; }
        public string CGCCPF { get; set; }

        public static R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1 Execute(R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1 r4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1)
        {
            var ths = r4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}