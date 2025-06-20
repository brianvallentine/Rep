using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class M_070_000_VE_FATURAS_DB_SELECT_1_Query1 : QueryBasis<M_070_000_VE_FATURAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            TIPAPO
            INTO
            :ATIPO-APOL
            FROM
            SEGUROS.V0APOLICE
            WHERE
            NUM_APOLICE = :R-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											TIPAPO
											FROM
											SEGUROS.V0APOLICE
											WHERE
											NUM_APOLICE = '{this.R_NUM_APOLICE}'";

            return query;
        }
        public string ATIPO_APOL { get; set; }
        public string R_NUM_APOLICE { get; set; }

        public static M_070_000_VE_FATURAS_DB_SELECT_1_Query1 Execute(M_070_000_VE_FATURAS_DB_SELECT_1_Query1 m_070_000_VE_FATURAS_DB_SELECT_1_Query1)
        {
            var ths = m_070_000_VE_FATURAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_070_000_VE_FATURAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_070_000_VE_FATURAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ATIPO_APOL = result[i++].Value?.ToString();
            return dta;
        }

    }
}