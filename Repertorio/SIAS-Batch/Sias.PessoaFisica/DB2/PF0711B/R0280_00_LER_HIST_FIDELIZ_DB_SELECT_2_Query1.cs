using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0711B
{
    public class R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1 : QueryBasis<R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1>
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
            AND DATA_SITUACAO =
            :DCLHIST-PROP-FIDELIZ.PROPFIDH-DATA-SITUACAO
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
											AND DATA_SITUACAO =
											'{this.PROPFIDH_DATA_SITUACAO}'
											AND SIT_PROPOSTA =
											'{this.PROPFIDH_SIT_PROPOSTA}'
											WITH UR";

            return query;
        }
        public string PROPFIDH_NUM_IDENTIFICACAO { get; set; }
        public string PROPFIDH_DATA_SITUACAO { get; set; }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }

        public static R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1 Execute(R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1 r0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1)
        {
            var ths = r0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1();
            var i = 0;
            dta.PROPFIDH_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}