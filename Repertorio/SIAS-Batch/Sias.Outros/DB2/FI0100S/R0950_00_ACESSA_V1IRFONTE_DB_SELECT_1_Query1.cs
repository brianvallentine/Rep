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
    public class R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1 : QueryBasis<R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ALQIPT,
            VALDDU
            INTO :V1IRF-ALQIPT,
            :V1IRF-VALDDU
            FROM SEGUROS.V1IRFONTE
            WHERE (:V1SIST-DTMOVABE BETWEEN DTINIVIG
            AND DTTERVIG)
            AND (:V2IRF-VALBRU BETWEEN LIMINF
            AND LIMSUP)
            AND TPPESSOA = :V1FAVO-TPPESSOA
            AND CODVIN = :V2FAVO-CODVIN
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT ALQIPT
							,
											VALDDU
											FROM SEGUROS.V1IRFONTE
											WHERE ('{this.V1SIST_DTMOVABE}' BETWEEN DTINIVIG
											AND DTTERVIG)
											AND ('{this.V2IRF_VALBRU}' BETWEEN LIMINF
											AND LIMSUP)
											AND TPPESSOA = '{this.V1FAVO_TPPESSOA}'
											AND CODVIN = '{this.V2FAVO_CODVIN}'";

            return query;
        }
        public string V1IRF_ALQIPT { get; set; }
        public string V1IRF_VALDDU { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1FAVO_TPPESSOA { get; set; }
        public string V2FAVO_CODVIN { get; set; }
        public string V2IRF_VALBRU { get; set; }

        public static R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1 Execute(R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1 r0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1)
        {
            var ths = r0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1IRF_ALQIPT = result[i++].Value?.ToString();
            dta.V1IRF_VALDDU = result[i++].Value?.ToString();
            return dta;
        }

    }
}