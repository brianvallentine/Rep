using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1035_QUITA_PARCELA_DB_SELECT_3_Query1 : QueryBasis<M_1035_QUITA_PARCELA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRPARCEL,
            OCORRHISTCTA
            INTO :V0PARC-NRPARCEL,
            :V0HCTA-OCORHISTCTA
            FROM SEGUROS.V0HISTCONTAVA
            WHERE CODCONV = :WHOST-CODCONV
            AND NSAS = :V0HCTA-NSAS
            AND NSL = :V0HCTA-NSL
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NRPARCEL
							,
											OCORRHISTCTA
											FROM SEGUROS.V0HISTCONTAVA
											WHERE CODCONV = '{this.WHOST_CODCONV}'
											AND NSAS = '{this.V0HCTA_NSAS}'
											AND NSL = '{this.V0HCTA_NSL}'";

            return query;
        }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0HCTA_OCORHISTCTA { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string V0HCTA_NSAS { get; set; }
        public string V0HCTA_NSL { get; set; }

        public static M_1035_QUITA_PARCELA_DB_SELECT_3_Query1 Execute(M_1035_QUITA_PARCELA_DB_SELECT_3_Query1 m_1035_QUITA_PARCELA_DB_SELECT_3_Query1)
        {
            var ths = m_1035_QUITA_PARCELA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1035_QUITA_PARCELA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1035_QUITA_PARCELA_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCTA_OCORHISTCTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}