using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0619B
{
    public class R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 : QueryBasis<R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :DCLCONVERSAO-SICOB.NUM-SICOB
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF =
            :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string NUM_SICOB { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 Execute(R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 r3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1)
        {
            var ths = r3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_SICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}