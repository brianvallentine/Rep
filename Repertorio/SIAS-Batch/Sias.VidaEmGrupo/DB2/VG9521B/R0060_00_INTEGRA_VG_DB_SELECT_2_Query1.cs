using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0060_00_INTEGRA_VG_DB_SELECT_2_Query1 : QueryBasis<R0060_00_INTEGRA_VG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(
            VALUE(DATA_NASCIMENTO, DATE( '1900-01-01' )))
            INTO
            CLIENTES-DATA-NASCIMENTO
            FROM
            SEGUROS.CLIENTES
            WHERE
            NOME_RAZAO = :CLIENTES-NOME-RAZAO
            AND CGCCPF = :CLIENTES-CGCCPF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MAX(
											VALUE(DATA_NASCIMENTO
							, DATE( '1900-01-01' )))
											FROM
											SEGUROS.CLIENTES
											WHERE
											NOME_RAZAO = '{this.CLIENTES_NOME_RAZAO}'
											AND CGCCPF = '{this.CLIENTES_CGCCPF}'";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }

        public static R0060_00_INTEGRA_VG_DB_SELECT_2_Query1 Execute(R0060_00_INTEGRA_VG_DB_SELECT_2_Query1 r0060_00_INTEGRA_VG_DB_SELECT_2_Query1)
        {
            var ths = r0060_00_INTEGRA_VG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_00_INTEGRA_VG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_00_INTEGRA_VG_DB_SELECT_2_Query1();
            var i = 0;
            return dta;
        }

    }
}