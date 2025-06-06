using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0706B
{
    public class R0060_00_LER_HISTORICO_DB_SELECT_1_Query1 : QueryBasis<R0060_00_LER_HISTORICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSAS_SIVPF
            INTO :PROPFIDH-NSAS-SIVPF
            FROM SEGUROS.HIST_PROP_FIDELIZ
            WHERE NUM_IDENTIFICACAO =
            :PROPFIDH-NUM-IDENTIFICACAO
            AND DATA_SITUACAO =
            :PROPFIDH-DATA-SITUACAO
            AND SIT_PROPOSTA =
            :PROPFIDH-SIT-PROPOSTA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NSAS_SIVPF
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
        public string PROPFIDH_NSAS_SIVPF { get; set; }
        public string PROPFIDH_NUM_IDENTIFICACAO { get; set; }
        public string PROPFIDH_DATA_SITUACAO { get; set; }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }

        public static R0060_00_LER_HISTORICO_DB_SELECT_1_Query1 Execute(R0060_00_LER_HISTORICO_DB_SELECT_1_Query1 r0060_00_LER_HISTORICO_DB_SELECT_1_Query1)
        {
            var ths = r0060_00_LER_HISTORICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_00_LER_HISTORICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_00_LER_HISTORICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPFIDH_NSAS_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}