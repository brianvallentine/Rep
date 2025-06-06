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
    public class M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1 : QueryBasis<M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME,
            PCTCED
            INTO :APOL-NOME,
            :APOL-PCTCED
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :MEST-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME
							,
											PCTCED
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.MEST_NUM_APOL}'";

            return query;
        }
        public string APOL_NOME { get; set; }
        public string APOL_PCTCED { get; set; }
        public string MEST_NUM_APOL { get; set; }

        public static M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1 Execute(M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1 m_240_000_LER_TAPOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_240_000_LER_TAPOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOL_NOME = result[i++].Value?.ToString();
            dta.APOL_PCTCED = result[i++].Value?.ToString();
            return dta;
        }

    }
}