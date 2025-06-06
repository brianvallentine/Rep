using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0000_PRINCIPAL_DB_SELECT_4_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT
            INTO :BANCOS-NRTIT
            FROM SEGUROS.V0BANCO
            WHERE BANCO = 104
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
											FROM SEGUROS.V0BANCO
											WHERE BANCO = 104";

            return query;
        }
        public string BANCOS_NRTIT { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_4_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_4_Query1 m_0000_PRINCIPAL_DB_SELECT_4_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_4_Query1();
            var i = 0;
            dta.BANCOS_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}