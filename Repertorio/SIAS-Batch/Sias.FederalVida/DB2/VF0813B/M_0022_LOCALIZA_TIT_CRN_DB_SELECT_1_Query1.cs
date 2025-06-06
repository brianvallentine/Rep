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
    public class M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1 : QueryBasis<M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRPARCEL
            INTO :V0HCTA-NRPARCEL
            FROM SEGUROS.V0HISTCONTAVA
            WHERE CODCONV = :WHOST-CODCONV
            AND NSAS = :V0HCTA-NSAS
            AND NSL = :V0HCTA-NSL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRPARCEL
											FROM SEGUROS.V0HISTCONTAVA
											WHERE CODCONV = '{this.WHOST_CODCONV}'
											AND NSAS = '{this.V0HCTA_NSAS}'
											AND NSL = '{this.V0HCTA_NSL}'";

            return query;
        }
        public string V0HCTA_NRPARCEL { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string V0HCTA_NSAS { get; set; }
        public string V0HCTA_NSL { get; set; }

        public static M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1 Execute(M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1 m_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1)
        {
            var ths = m_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCTA_NRPARCEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}