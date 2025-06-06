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
    public class R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1 : QueryBasis<R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            CGCCPF
            INTO :V0CLIE-NOME-RAZAO-E,
            :V0CLIE-CNPJ-E
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0SUBG-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											CGCCPF
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0SUBG_COD_CLIENTE}'";

            return query;
        }
        public string V0CLIE_NOME_RAZAO_E { get; set; }
        public string V0CLIE_CNPJ_E { get; set; }
        public string V0SUBG_COD_CLIENTE { get; set; }

        public static R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1 Execute(R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1 r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1)
        {
            var ths = r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0CLIE_NOME_RAZAO_E = result[i++].Value?.ToString();
            dta.V0CLIE_CNPJ_E = result[i++].Value?.ToString();
            return dta;
        }

    }
}