using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1 : QueryBasis<M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.NOME_RAZAO
            INTO :CLIE-NOME-RAZAO
            FROM SEGUROS.V0SINI_ITEM S,
            SEGUROS.V0CLIENTE C
            WHERE S.NUM_APOL_SINISTRO = :RELSIN-APOL-SINI
            AND C.COD_CLIENTE = S.COD_CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT C.NOME_RAZAO
											FROM SEGUROS.V0SINI_ITEM S
							,
											SEGUROS.V0CLIENTE C
											WHERE S.NUM_APOL_SINISTRO = '{this.RELSIN_APOL_SINI}'
											AND C.COD_CLIENTE = S.COD_CLIENTE";

            return query;
        }
        public string CLIE_NOME_RAZAO { get; set; }
        public string RELSIN_APOL_SINI { get; set; }

        public static M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1 Execute(M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1 m_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1)
        {
            var ths = m_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIE_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}