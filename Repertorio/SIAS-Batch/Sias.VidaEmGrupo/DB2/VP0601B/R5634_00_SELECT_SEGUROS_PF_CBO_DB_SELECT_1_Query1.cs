using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1 : QueryBasis<R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_CBO
            INTO :PF062-DES-CBO
            FROM SEGUROS.PF_CBO
            WHERE NUM_PROPOSTA_SIVPF = :PF062-NUM-PROPOSTA-SIVPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DES_CBO
											FROM SEGUROS.PF_CBO
											WHERE NUM_PROPOSTA_SIVPF = '{this.PF062_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PF062_DES_CBO { get; set; }
        public string PF062_NUM_PROPOSTA_SIVPF { get; set; }

        public static R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1 Execute(R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1 r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1)
        {
            var ths = r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PF062_DES_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}