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
    public class M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 : QueryBasis<M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT NOME_AGENCIA,
            AGE_CENTRAL_PROD01
            INTO :V0AG-NOME-AGENCIA,
            :V0AG-AGE-CENTRAL-PROD01
            FROM SEGUROS.V0AGENCIACEF
            WHERE COD_AGENCIA = :V0AG-COD-AGENCIA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DISTINCT NOME_AGENCIA
							,
											AGE_CENTRAL_PROD01
											FROM SEGUROS.V0AGENCIACEF
											WHERE COD_AGENCIA = '{this.V0AG_COD_AGENCIA}'";

            return query;
        }
        public string V0AG_NOME_AGENCIA { get; set; }
        public string V0AG_AGE_CENTRAL_PROD01 { get; set; }
        public string V0AG_COD_AGENCIA { get; set; }

        public static M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 Execute(M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 m_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1)
        {
            var ths = m_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0AG_NOME_AGENCIA = result[i++].Value?.ToString();
            dta.V0AG_AGE_CENTRAL_PROD01 = result[i++].Value?.ToString();
            return dta;
        }

    }
}