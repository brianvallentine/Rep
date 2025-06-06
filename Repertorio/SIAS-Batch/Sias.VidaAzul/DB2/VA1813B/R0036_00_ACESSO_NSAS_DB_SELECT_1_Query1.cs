using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1813B
{
    public class R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1 : QueryBasis<R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRCERTIF,
            NRPARCEL,
            OCORRHISTCTA,
            TIPLANC
            INTO :V0HCTA-NRCERTIF,
            :V0HCTA-NRPARCEL,
            :V0HCTA-OCORHISTCTA,
            :V0HCTA-TIPLANC
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NSAS = :V0HCTA-NSAS
            AND NSL = :V0HCTA-NSL
            AND TIPLANC = '1'
            AND CODCONV = :V0HCTA-CODCONV
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRCERTIF
							,
											NRPARCEL
							,
											OCORRHISTCTA
							,
											TIPLANC
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NSAS = '{this.V0HCTA_NSAS}'
											AND NSL = '{this.V0HCTA_NSL}'
											AND TIPLANC = '1'
											AND CODCONV = '{this.V0HCTA_CODCONV}'";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }
        public string V0HCTA_OCORHISTCTA { get; set; }
        public string V0HCTA_TIPLANC { get; set; }
        public string V0HCTA_CODCONV { get; set; }
        public string V0HCTA_NSAS { get; set; }
        public string V0HCTA_NSL { get; set; }

        public static R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1 Execute(R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1 r0036_00_ACESSO_NSAS_DB_SELECT_1_Query1)
        {
            var ths = r0036_00_ACESSO_NSAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCTA_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HCTA_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCTA_OCORHISTCTA = result[i++].Value?.ToString();
            dta.V0HCTA_TIPLANC = result[i++].Value?.ToString();
            return dta;
        }

    }
}