using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1 : QueryBasis<R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_PROPOSTA
            INTO :PROPFIDH-SIT-PROPOSTA
            FROM SEGUROS.HIST_PROP_FIDELIZ
            WHERE NUM_IDENTIFICACAO =
            :PROPFIDH-NUM-IDENTIFICACAO
            AND SIT_PROPOSTA = 'EMT'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_PROPOSTA
											FROM SEGUROS.HIST_PROP_FIDELIZ
											WHERE NUM_IDENTIFICACAO =
											'{this.PROPFIDH_NUM_IDENTIFICACAO}'
											AND SIT_PROPOSTA = 'EMT'
											WITH UR";

            return query;
        }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }
        public string PROPFIDH_NUM_IDENTIFICACAO { get; set; }

        public static R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1 Execute(R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1 r0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPFIDH_SIT_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}