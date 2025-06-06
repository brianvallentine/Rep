using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6248B
{
    public class R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1 : QueryBasis<R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :BILHETE-NUM-BILHETE
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF = '{this.CONVERSI_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }

        public static R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1 Execute(R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1 r6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1)
        {
            var ths = r6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            return dta;
        }

    }
}