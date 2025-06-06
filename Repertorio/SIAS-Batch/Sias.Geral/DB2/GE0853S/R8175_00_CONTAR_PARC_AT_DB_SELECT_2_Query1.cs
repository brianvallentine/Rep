using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1 : QueryBasis<R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(DTCREDITO, '0001-01-01' )
            INTO :MOVDEBCE-DTCREDITO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :WS-NUM-TITULO-AT
            AND NUM_PARCELA = :WS-NUM-PARC-AT
            AND NUM_REQUISICAO = :V0HCTA-NSL
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(DTCREDITO
							, '0001-01-01' )
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.WS_NUM_TITULO_AT}'
											AND NUM_PARCELA = '{this.WS_NUM_PARC_AT}'
											AND NUM_REQUISICAO = '{this.V0HCTA_NSL}'
											WITH UR";

            return query;
        }
        public string MOVDEBCE_DTCREDITO { get; set; }
        public string WS_NUM_TITULO_AT { get; set; }
        public string WS_NUM_PARC_AT { get; set; }
        public string V0HCTA_NSL { get; set; }

        public static R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1 Execute(R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1 r8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1)
        {
            var ths = r8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOVDEBCE_DTCREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}