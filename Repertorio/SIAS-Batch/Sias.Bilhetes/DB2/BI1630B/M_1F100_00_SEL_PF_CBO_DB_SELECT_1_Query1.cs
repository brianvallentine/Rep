using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1 : QueryBasis<M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_CBO
            INTO :BILHETE-PROFISSAO
            FROM SEGUROS.PF_CBO
            WHERE NUM_PROPOSTA_SIVPF = :PF062-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DES_CBO
											FROM SEGUROS.PF_CBO
											WHERE NUM_PROPOSTA_SIVPF = '{this.PF062_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string BILHETE_PROFISSAO { get; set; }
        public string PF062_NUM_PROPOSTA_SIVPF { get; set; }

        public static M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1 Execute(M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1 m_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1)
        {
            var ths = m_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_PROFISSAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}