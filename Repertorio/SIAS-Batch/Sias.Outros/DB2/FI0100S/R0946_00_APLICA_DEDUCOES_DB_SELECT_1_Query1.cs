using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0100S
{
    public class R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1 : QueryBasis<R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALDEP,
            LIMSUP
            INTO :V3IRF-VALDEP,
            :V4IRF-LIMSUP
            FROM SEGUROS.V1IRFONTE
            WHERE (:V1SIST-DTMOVABE BETWEEN DTINIVIG
            AND DTTERVIG)
            AND LIMINF = 0.00
            AND TPPESSOA = :V1FAVO-TPPESSOA
            AND CODVIN = :V2FAVO-CODVIN
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALDEP
							,
											LIMSUP
											FROM SEGUROS.V1IRFONTE
											WHERE ('{this.V1SIST_DTMOVABE}' BETWEEN DTINIVIG
											AND DTTERVIG)
											AND LIMINF = 0.00
											AND TPPESSOA = '{this.V1FAVO_TPPESSOA}'
											AND CODVIN = '{this.V2FAVO_CODVIN}'";

            return query;
        }
        public string V3IRF_VALDEP { get; set; }
        public string V4IRF_LIMSUP { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1FAVO_TPPESSOA { get; set; }
        public string V2FAVO_CODVIN { get; set; }

        public static R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1 Execute(R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1 r0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1)
        {
            var ths = r0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V3IRF_VALDEP = result[i++].Value?.ToString();
            dta.V4IRF_LIMSUP = result[i++].Value?.ToString();
            return dta;
        }

    }
}