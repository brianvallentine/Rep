using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0803B
{
    public class M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1 : QueryBasis<M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME
            INTO :APOL-NOME
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :RELSIN-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.RELSIN_APOLICE}'";

            return query;
        }
        public string APOL_NOME { get; set; }
        public string RELSIN_APOLICE { get; set; }

        public static M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1 Execute(M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1 m_580_000_LER_TAPOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_580_000_LER_TAPOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOL_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}