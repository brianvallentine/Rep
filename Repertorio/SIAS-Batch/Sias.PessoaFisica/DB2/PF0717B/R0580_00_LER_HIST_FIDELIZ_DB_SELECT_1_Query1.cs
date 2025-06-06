using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0717B
{
    public class R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO
            INTO :PROPFIDH-NUM-IDENTIFICACAO
            FROM SEGUROS.HIST_PROP_FIDELIZ
            WHERE NUM_IDENTIFICACAO =
            :PROPFIDH-NUM-IDENTIFICACAO
            AND DATA_SITUACAO =
            :PROPFIDH-DATA-SITUACAO
            AND SIT_PROPOSTA =
            :PROPFIDH-SIT-PROPOSTA
            AND SIT_MOTIVO_SIVPF =
            :PROPFIDH-SIT-MOTIVO-SIVPF
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
											AND SIT_MOTIVO_SIVPF =
											'{this.PROPFIDH_SIT_MOTIVO_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPFIDH_NUM_IDENTIFICACAO { get; set; }
        public string PROPFIDH_SIT_MOTIVO_SIVPF { get; set; }
        public string PROPFIDH_DATA_SITUACAO { get; set; }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }

        public static R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1 Execute(R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1 r0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPFIDH_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}