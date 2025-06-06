using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI3605B
{
    public class R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIGEM_PROPOSTA
            INTO :ORIGEM-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORIGEM_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.CONVERSI_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string ORIGEM_PROPOSTA { get; set; }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }

        public static R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 Execute(R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 r0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}