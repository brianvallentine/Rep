using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0814B
{
    public class M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1 : QueryBasis<M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG
            INTO :ENDO-DTINIVIG
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :MEST-APOLICE
            AND NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.MEST_APOLICE}'
											AND NRENDOS = 0";

            return query;
        }
        public string ENDO_DTINIVIG { get; set; }
        public string MEST_APOLICE { get; set; }

        public static M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1 Execute(M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1 m_610_000_LER_TENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = m_610_000_LER_TENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDO_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}