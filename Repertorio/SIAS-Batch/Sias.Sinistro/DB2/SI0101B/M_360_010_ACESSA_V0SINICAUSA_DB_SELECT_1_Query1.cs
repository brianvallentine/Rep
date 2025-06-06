using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0101B
{
    public class M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1 : QueryBasis<M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCAU
            INTO :SCAU-DESCAU
            FROM SEGUROS.V0SINICAUSA
            WHERE
            RAMO = :MEST-RAMO
            AND CODCAU = :MEST-CODCAU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCAU
											FROM SEGUROS.V0SINICAUSA
											WHERE
											RAMO = '{this.MEST_RAMO}'
											AND CODCAU = '{this.MEST_CODCAU}'";

            return query;
        }
        public string SCAU_DESCAU { get; set; }
        public string MEST_CODCAU { get; set; }
        public string MEST_RAMO { get; set; }

        public static M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1 Execute(M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1 m_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1)
        {
            var ths = m_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SCAU_DESCAU = result[i++].Value?.ToString();
            return dta;
        }

    }
}