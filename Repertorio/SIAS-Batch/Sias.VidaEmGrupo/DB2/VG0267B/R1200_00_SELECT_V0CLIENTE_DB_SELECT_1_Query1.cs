using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            CGCCPF
            INTO :V0CLIE-NOME-RAZAO,
            :V0CLIE-CNPJ
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0HIST-CDCLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											CGCCPF
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0HIST_CDCLIENTE}'";

            return query;
        }
        public string V0CLIE_NOME_RAZAO { get; set; }
        public string V0CLIE_CNPJ { get; set; }
        public string V0HIST_CDCLIENTE { get; set; }

        public static R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CLIE_NOME_RAZAO = result[i++].Value?.ToString();
            dta.V0CLIE_CNPJ = result[i++].Value?.ToString();
            return dta;
        }

    }
}