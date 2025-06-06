using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1 : QueryBasis<M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMPDT
            INTO
            :PRODUTOR-NOMPDT
            FROM
            SEGUROS.V1PRODUTOR
            WHERE
            CODPDT = :APDCORR-CODCORR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMPDT
											FROM
											SEGUROS.V1PRODUTOR
											WHERE
											CODPDT = '{this.APDCORR_CODCORR}'";

            return query;
        }
        public string PRODUTOR_NOMPDT { get; set; }
        public string APDCORR_CODCORR { get; set; }

        public static M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1 Execute(M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1 m_345_000_LER_PRODUTOR_DB_SELECT_1_Query1)
        {
            var ths = m_345_000_LER_PRODUTOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTOR_NOMPDT = result[i++].Value?.ToString();
            return dta;
        }

    }
}