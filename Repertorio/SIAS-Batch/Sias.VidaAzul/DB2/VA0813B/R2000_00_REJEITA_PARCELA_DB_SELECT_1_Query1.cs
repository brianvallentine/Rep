using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODRET
            INTO :V0HCTA-CODRET:VIND-CODRET
            FROM SEGUROS.V0HISTCONTAVA
            WHERE CODCONV = :WHOST-CODCONV
            AND NSAS = :V0HCTA-NSAS
            AND NSL = :V0HCTA-NSL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODRET
											FROM SEGUROS.V0HISTCONTAVA
											WHERE CODCONV = '{this.WHOST_CODCONV}'
											AND NSAS = '{this.V0HCTA_NSAS}'
											AND NSL = '{this.V0HCTA_NSL}'
											WITH UR";

            return query;
        }
        public string V0HCTA_CODRET { get; set; }
        public string VIND_CODRET { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string V0HCTA_NSAS { get; set; }
        public string V0HCTA_NSL { get; set; }

        public static R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1 Execute(R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1 r2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCTA_CODRET = result[i++].Value?.ToString();
            dta.VIND_CODRET = string.IsNullOrWhiteSpace(dta.V0HCTA_CODRET) ? "-1" : "0";
            return dta;
        }

    }
}