using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2721B
{
    public class R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SIT_PROPOSTA,
            NUM_PROPOSTA_SIVPF
            INTO
            :PROPOFID-SIT-PROPOSTA,
            :PROPOFID-NUM-PROPOSTA-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :PROPOVA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SIT_PROPOSTA
							,
											NUM_PROPOSTA_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}