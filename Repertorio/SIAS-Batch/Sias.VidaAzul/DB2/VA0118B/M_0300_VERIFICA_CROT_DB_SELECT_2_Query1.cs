using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0300_VERIFICA_CROT_DB_SELECT_2_Query1 : QueryBasis<M_0300_VERIFICA_CROT_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :CLIROT-DTMOVABE
            FROM SEGUROS.V1CLIENTE_CROT
            WHERE CGCCPF = :CLIENT-CGCCPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1CLIENTE_CROT
											WHERE CGCCPF = '{this.CLIENT_CGCCPF}'";

            return query;
        }
        public string CLIROT_DTMOVABE { get; set; }
        public string CLIENT_CGCCPF { get; set; }

        public static M_0300_VERIFICA_CROT_DB_SELECT_2_Query1 Execute(M_0300_VERIFICA_CROT_DB_SELECT_2_Query1 m_0300_VERIFICA_CROT_DB_SELECT_2_Query1)
        {
            var ths = m_0300_VERIFICA_CROT_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0300_VERIFICA_CROT_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0300_VERIFICA_CROT_DB_SELECT_2_Query1();
            var i = 0;
            dta.CLIROT_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}