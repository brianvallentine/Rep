using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class R1300_00_SELECT_V0ENDERECO_Query1 : QueryBasis<R1300_00_SELECT_V0ENDERECO_Query1>
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
            INTO :V0ENDE-ENDERECO,
            :V0ENDE-BAIRRO,
            :V0ENDE-CIDADE,
            :V0ENDE-UF,
            :V0ENDE-CEP
            FROM SEGUROS.V0ENDERECOS
            WHERE COD_CLIENTE = :V0HIST-CDCLIENTE
            AND OCORR_ENDERECO = 1
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
											WHERE COD_CLIENTE = '{this.V0HIST_CDCLIENTE}'
											AND OCORR_ENDERECO = 1";

            return query;
        }
        public string V0ENDE_ENDERECO { get; set; }
        public string V0ENDE_BAIRRO { get; set; }
        public string V0ENDE_CIDADE { get; set; }
        public string V0ENDE_UF { get; set; }
        public string V0ENDE_CEP { get; set; }
        public string V0HIST_CDCLIENTE { get; set; }

        public static R1300_00_SELECT_V0ENDERECO_Query1 Execute(R1300_00_SELECT_V0ENDERECO_Query1 r1300_00_SELECT_V0ENDERECO_Query1)
        {
            var ths = r1300_00_SELECT_V0ENDERECO_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0ENDERECO_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0ENDERECO_Query1();
            var i = 0;
            dta.V0ENDE_ENDERECO = result[i++].Value?.ToString();
            dta.V0ENDE_BAIRRO = result[i++].Value?.ToString();
            dta.V0ENDE_CIDADE = result[i++].Value?.ToString();
            dta.V0ENDE_UF = result[i++].Value?.ToString();
            dta.V0ENDE_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}