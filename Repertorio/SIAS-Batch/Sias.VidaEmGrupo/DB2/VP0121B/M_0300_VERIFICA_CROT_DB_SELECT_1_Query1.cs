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
    public class M_0300_VERIFICA_CROT_DB_SELECT_1_Query1 : QueryBasis<M_0300_VERIFICA_CROT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF
            INTO :CLIENT-CGCCPF
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :PROPVA-CODCLIEN
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.PROPVA_CODCLIEN}'
											WITH UR";

            return query;
        }
        public string CLIENT_CGCCPF { get; set; }
        public string PROPVA_CODCLIEN { get; set; }

        public static M_0300_VERIFICA_CROT_DB_SELECT_1_Query1 Execute(M_0300_VERIFICA_CROT_DB_SELECT_1_Query1 m_0300_VERIFICA_CROT_DB_SELECT_1_Query1)
        {
            var ths = m_0300_VERIFICA_CROT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0300_VERIFICA_CROT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0300_VERIFICA_CROT_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENT_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}