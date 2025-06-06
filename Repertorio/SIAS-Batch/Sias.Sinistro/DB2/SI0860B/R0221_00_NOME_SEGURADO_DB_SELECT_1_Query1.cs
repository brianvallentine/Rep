using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0860B
{
    public class R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.APOLICES A,
            SEGUROS.CLIENTES C
            WHERE A.NUM_APOLICE = :SINBENCB-NUM-APOLICE
            AND A.COD_CLIENTE = C.COD_CLIENTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT C.NOME_RAZAO
											FROM SEGUROS.APOLICES A
							,
											SEGUROS.CLIENTES C
											WHERE A.NUM_APOLICE = '{this.SINBENCB_NUM_APOLICE}'
											AND A.COD_CLIENTE = C.COD_CLIENTE";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string SINBENCB_NUM_APOLICE { get; set; }

        public static R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1 Execute(R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1 r0221_00_NOME_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = r0221_00_NOME_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}