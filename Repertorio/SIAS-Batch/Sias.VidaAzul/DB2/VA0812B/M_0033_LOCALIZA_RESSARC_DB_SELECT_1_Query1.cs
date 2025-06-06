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
    public class M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1 : QueryBasis<M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSAS,
            DATA_DEBITO,
            NUM_CERTIFICADO,
            DESCR_RESSARCI
            INTO :MVCOM-NSAS,
            :MVCOM-DATA-MOV,
            :RESA-NRCERTIF,
            :RESA-DESCR
            FROM SEGUROS.V0RESSARCIAZUL
            WHERE NSAS = :MVCOM-NSAS
            AND NSL = :MVCOM-NSL1
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NSAS
							,
											DATA_DEBITO
							,
											NUM_CERTIFICADO
							,
											DESCR_RESSARCI
											FROM SEGUROS.V0RESSARCIAZUL
											WHERE NSAS = '{this.MVCOM_NSAS}'
											AND NSL = '{this.MVCOM_NSL1}'
											WITH UR";

            return query;
        }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_DATA_MOV { get; set; }
        public string RESA_NRCERTIF { get; set; }
        public string RESA_DESCR { get; set; }
        public string MVCOM_NSL1 { get; set; }

        public static M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1 Execute(M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1 m_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1)
        {
            var ths = m_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.MVCOM_NSAS = result[i++].Value?.ToString();
            dta.MVCOM_DATA_MOV = result[i++].Value?.ToString();
            dta.RESA_NRCERTIF = result[i++].Value?.ToString();
            dta.RESA_DESCR = result[i++].Value?.ToString();
            return dta;
        }

    }
}