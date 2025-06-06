using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1 : QueryBasis<R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SIT_PROPOSTA
            , DATA_SITUACAO
            INTO
            :PROPFIDH-SIT-PROPOSTA
            ,:PROPFIDH-DATA-SITUACAO
            FROM SEGUROS.HIST_PROP_FIDELIZ
            WHERE NUM_IDENTIFICACAO = :PROPOFID-NUM-IDENTIFICACAO
            AND SIT_MOTIVO_SIVPF = :PROPFIDH-SIT-MOTIVO-SIVPF
            ORDER BY DATA_SITUACAO DESC
            FETCH FIRST 1 ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SIT_PROPOSTA
											, DATA_SITUACAO
											FROM SEGUROS.HIST_PROP_FIDELIZ
											WHERE NUM_IDENTIFICACAO = '{this.PROPOFID_NUM_IDENTIFICACAO}'
											AND SIT_MOTIVO_SIVPF = '{this.PROPFIDH_SIT_MOTIVO_SIVPF}'
											ORDER BY DATA_SITUACAO DESC
											FETCH FIRST 1 ROWS ONLY";

            return query;
        }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }
        public string PROPFIDH_DATA_SITUACAO { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPFIDH_SIT_MOTIVO_SIVPF { get; set; }

        public static R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1 Execute(R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1 r1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1)
        {
            var ths = r1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPFIDH_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPFIDH_DATA_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}