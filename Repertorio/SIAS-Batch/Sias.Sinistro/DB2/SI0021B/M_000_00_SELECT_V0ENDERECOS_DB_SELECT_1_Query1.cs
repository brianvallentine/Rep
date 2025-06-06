using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 : QueryBasis<M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF
            INTO :V0ENDERECOS-ENDERECO,
            :V0ENDERECOS-BAIRRO,
            :V0ENDERECOS-CIDADE,
            :V0ENDERECOS-SIGLA-UF
            FROM SEGUROS.V0ENDERECOS
            WHERE COD_CLIENTE = :V1APOL-CODCLIEN
            AND OCORR_ENDERECO = 1
            END-EXEC
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
											FROM SEGUROS.V0ENDERECOS
											WHERE COD_CLIENTE = '{this.V1APOL_CODCLIEN}'
											AND OCORR_ENDERECO = 1";

            return query;
        }
        public string V0ENDERECOS_ENDERECO { get; set; }
        public string V0ENDERECOS_BAIRRO { get; set; }
        public string V0ENDERECOS_CIDADE { get; set; }
        public string V0ENDERECOS_SIGLA_UF { get; set; }
        public string V1APOL_CODCLIEN { get; set; }

        public static M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 Execute(M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 m_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1)
        {
            var ths = m_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDERECOS_ENDERECO = result[i++].Value?.ToString();
            dta.V0ENDERECOS_BAIRRO = result[i++].Value?.ToString();
            dta.V0ENDERECOS_CIDADE = result[i++].Value?.ToString();
            dta.V0ENDERECOS_SIGLA_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}