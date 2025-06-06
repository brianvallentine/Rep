using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0060_LOCALIZA_6075_DB_SELECT_1_Query1 : QueryBasis<M_0060_LOCALIZA_6075_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO,
            DTCREDITO,
            NSAC
            INTO :V0RESG-SITUACAO,
            :V0RESG-DTCREDITO:VIND-DTCREDITO,
            :V0RESG-NSAC:VIND-NSAC
            FROM SEGUROS.V0RESGATE_CAP_VG
            WHERE NRCERTIF = :V0RESG-NRCERTIF
            AND NSAS = :MVCOM-NSAS
            AND NSL = :MVCOM-NSL
            AND SITUACAO = '3'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
							,
											DTCREDITO
							,
											NSAC
											FROM SEGUROS.V0RESGATE_CAP_VG
											WHERE NRCERTIF = '{this.V0RESG_NRCERTIF}'
											AND NSAS = '{this.MVCOM_NSAS}'
											AND NSL = '{this.MVCOM_NSL}'
											AND SITUACAO = '3'
											WITH UR";

            return query;
        }
        public string V0RESG_SITUACAO { get; set; }
        public string V0RESG_DTCREDITO { get; set; }
        public string VIND_DTCREDITO { get; set; }
        public string V0RESG_NSAC { get; set; }
        public string VIND_NSAC { get; set; }
        public string V0RESG_NRCERTIF { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL { get; set; }

        public static M_0060_LOCALIZA_6075_DB_SELECT_1_Query1 Execute(M_0060_LOCALIZA_6075_DB_SELECT_1_Query1 m_0060_LOCALIZA_6075_DB_SELECT_1_Query1)
        {
            var ths = m_0060_LOCALIZA_6075_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0060_LOCALIZA_6075_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0060_LOCALIZA_6075_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RESG_SITUACAO = result[i++].Value?.ToString();
            dta.V0RESG_DTCREDITO = result[i++].Value?.ToString();
            dta.VIND_DTCREDITO = string.IsNullOrWhiteSpace(dta.V0RESG_DTCREDITO) ? "-1" : "0";
            dta.V0RESG_NSAC = result[i++].Value?.ToString();
            dta.VIND_NSAC = string.IsNullOrWhiteSpace(dta.V0RESG_NSAC) ? "-1" : "0";
            return dta;
        }

    }
}