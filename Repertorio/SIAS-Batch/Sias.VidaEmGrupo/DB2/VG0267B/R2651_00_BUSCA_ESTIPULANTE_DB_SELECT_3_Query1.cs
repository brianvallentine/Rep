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
    public class R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1 : QueryBasis<R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP
            INTO :V0ENDE-ENDERECO-E,
            :V0ENDE-BAIRRO-E,
            :V0ENDE-CIDADE-E,
            :V0ENDE-UF-E,
            :V0ENDE-CEP-E
            FROM SEGUROS.V0ENDERECOS
            WHERE COD_CLIENTE = :V0SUBG-COD-CLIENTE
            AND OCORR_ENDERECO = :V0SUBG-OCOREND
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDERECO
							,
											BAIRRO
							,
											CIDADE
							,
											SIGLA_UF
							,
											CEP
											FROM SEGUROS.V0ENDERECOS
											WHERE COD_CLIENTE = '{this.V0SUBG_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.V0SUBG_OCOREND}'";

            return query;
        }
        public string V0ENDE_ENDERECO_E { get; set; }
        public string V0ENDE_BAIRRO_E { get; set; }
        public string V0ENDE_CIDADE_E { get; set; }
        public string V0ENDE_UF_E { get; set; }
        public string V0ENDE_CEP_E { get; set; }
        public string V0SUBG_COD_CLIENTE { get; set; }
        public string V0SUBG_OCOREND { get; set; }

        public static R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1 Execute(R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1 r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1)
        {
            var ths = r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0ENDE_ENDERECO_E = result[i++].Value?.ToString();
            dta.V0ENDE_BAIRRO_E = result[i++].Value?.ToString();
            dta.V0ENDE_CIDADE_E = result[i++].Value?.ToString();
            dta.V0ENDE_UF_E = result[i++].Value?.ToString();
            dta.V0ENDE_CEP_E = result[i++].Value?.ToString();
            return dta;
        }

    }
}