using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0715B
{
    public class R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 : QueryBasis<R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO
            INTO :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO
            FROM SEGUROS.HIST_PROP_FIDELIZ
            WHERE NUM_IDENTIFICACAO =
            :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO
            AND SIT_PROPOSTA =
            :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-PROPOSTA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_IDENTIFICACAO
											FROM SEGUROS.HIST_PROP_FIDELIZ
											WHERE NUM_IDENTIFICACAO =
											'{this.PROPFIDH_NUM_IDENTIFICACAO}'
											AND SIT_PROPOSTA =
											'{this.PROPFIDH_SIT_PROPOSTA}'
											WITH UR";

            return query;
        }
        public string PROPFIDH_NUM_IDENTIFICACAO { get; set; }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }

        public static R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 Execute(R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 r0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1)
        {
            var ths = r0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPFIDH_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}