using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0445B
{
    public class R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP,
            DDD,
            TELEFONE
            INTO :V0ENDE-ENDERECO,
            :V0ENDE-BAIRRO,
            :V0ENDE-CIDADE,
            :V0ENDE-SIGLA-UF,
            :V0ENDE-CEP,
            :V0ENDE-DDD,
            :V0ENDE-TELEFONE
            FROM SEGUROS.V0ENDERECOS
            WHERE COD_CLIENTE = :V0PROP-CODCLIEN
            AND OCORR_ENDERECO = :V0PROP-OCOREND
            WITH UR
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
							,
											DDD
							,
											TELEFONE
											FROM SEGUROS.V0ENDERECOS
											WHERE COD_CLIENTE = '{this.V0PROP_CODCLIEN}'
											AND OCORR_ENDERECO = '{this.V0PROP_OCOREND}'
											WITH UR";

            return query;
        }
        public string V0ENDE_ENDERECO { get; set; }
        public string V0ENDE_BAIRRO { get; set; }
        public string V0ENDE_CIDADE { get; set; }
        public string V0ENDE_SIGLA_UF { get; set; }
        public string V0ENDE_CEP { get; set; }
        public string V0ENDE_DDD { get; set; }
        public string V0ENDE_TELEFONE { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_OCOREND { get; set; }

        public static R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 r1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDE_ENDERECO = result[i++].Value?.ToString();
            dta.V0ENDE_BAIRRO = result[i++].Value?.ToString();
            dta.V0ENDE_CIDADE = result[i++].Value?.ToString();
            dta.V0ENDE_SIGLA_UF = result[i++].Value?.ToString();
            dta.V0ENDE_CEP = result[i++].Value?.ToString();
            dta.V0ENDE_DDD = result[i++].Value?.ToString();
            dta.V0ENDE_TELEFONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}