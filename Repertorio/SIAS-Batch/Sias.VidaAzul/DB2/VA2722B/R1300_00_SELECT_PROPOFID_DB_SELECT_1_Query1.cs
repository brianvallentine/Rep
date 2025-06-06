using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2722B
{
    public class R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SIT_PROPOSTA,
            DATA_PROPOSTA,
            NUM_IDENTIFICACAO
            INTO
            :PROPOFID-SIT-PROPOSTA,
            :PROPOFID-DATA-PROPOSTA,
            :PROPOFID-NUM-IDENTIFICACAO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SIT_PROPOSTA
							,
											DATA_PROPOSTA
							,
											NUM_IDENTIFICACAO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}