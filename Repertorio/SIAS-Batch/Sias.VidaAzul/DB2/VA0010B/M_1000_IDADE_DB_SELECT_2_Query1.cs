using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_IDADE_DB_SELECT_2_Query1 : QueryBasis<M_1000_IDADE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DAY(DTVENCTO),
            DTVENCTO,
            DTVENCTO + :HOST-PERIPGTO MONTHS,
            PRMVG + PRMAP
            INTO :HOST-DIA-DEBITO,
            :HOST-DTVENCTO,
            :HOST-DTPROXVEN,
            :HOST-VALOPERACAO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V1SEGV-NRCERTIF
            AND NRPARCEL = :V1SEGV-NUM-CARNE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DAY(DTVENCTO)
							,
											DTVENCTO
							,
											DTVENCTO + {this.HOST_PERIPGTO} MONTHS
							,
											PRMVG + PRMAP
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V1SEGV_NRCERTIF}'
											AND NRPARCEL = '{this.V1SEGV_NUM_CARNE}'";

            return query;
        }
        public string HOST_DIA_DEBITO { get; set; }
        public string HOST_DTVENCTO { get; set; }
        public string HOST_DTPROXVEN { get; set; }
        public string HOST_VALOPERACAO { get; set; }
        public string V1SEGV_NUM_CARNE { get; set; }
        public string V1SEGV_NRCERTIF { get; set; }
        public string HOST_PERIPGTO { get; set; }

        public static M_1000_IDADE_DB_SELECT_2_Query1 Execute(M_1000_IDADE_DB_SELECT_2_Query1 m_1000_IDADE_DB_SELECT_2_Query1)
        {
            var ths = m_1000_IDADE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_IDADE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_IDADE_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_DIA_DEBITO = result[i++].Value?.ToString();
            dta.HOST_DTVENCTO = result[i++].Value?.ToString();
            dta.HOST_DTPROXVEN = result[i++].Value?.ToString();
            dta.HOST_VALOPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}