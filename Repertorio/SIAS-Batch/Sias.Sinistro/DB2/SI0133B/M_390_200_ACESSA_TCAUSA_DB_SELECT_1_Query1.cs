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
    public class M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1 : QueryBasis<M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCAU
            INTO :CAUSA-DESCAU
            FROM SEGUROS.V1SINICAUSA
            WHERE RAMO = :MEST-RAMO
            AND CODCAU = :MEST-CODCAU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCAU
											FROM SEGUROS.V1SINICAUSA
											WHERE RAMO = '{this.MEST_RAMO}'
											AND CODCAU = '{this.MEST_CODCAU}'";

            return query;
        }
        public string CAUSA_DESCAU { get; set; }
        public string MEST_CODCAU { get; set; }
        public string MEST_RAMO { get; set; }

        public static M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1 Execute(M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1 m_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1)
        {
            var ths = m_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.CAUSA_DESCAU = result[i++].Value?.ToString();
            return dta;
        }

    }
}