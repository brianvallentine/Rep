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
    public class M_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1 : QueryBasis<M_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREJAZUL
            VALUES
            (:RESA-NRCERTIF,
            :HISR-NUM-PARCELA,
            :MVCOM-DATA-MOV,
            :HISR-CODOPER,
            :DTMOVABE,
            CURRENT TIMESTAMP,
            :MVCOM-NSAS,
            :MVCOM-NSL1,
            :SQL-NSAC,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREJAZUL VALUES ({FieldThreatment(this.RESA_NRCERTIF)}, {FieldThreatment(this.HISR_NUM_PARCELA)}, {FieldThreatment(this.MVCOM_DATA_MOV)}, {FieldThreatment(this.HISR_CODOPER)}, {FieldThreatment(this.DTMOVABE)}, CURRENT TIMESTAMP, {FieldThreatment(this.MVCOM_NSAS)}, {FieldThreatment(this.MVCOM_NSL1)}, {FieldThreatment(this.SQL_NSAC)}, NULL, NULL, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string RESA_NRCERTIF { get; set; }
        public string HISR_NUM_PARCELA { get; set; }
        public string MVCOM_DATA_MOV { get; set; }
        public string HISR_CODOPER { get; set; }
        public string DTMOVABE { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL1 { get; set; }
        public string SQL_NSAC { get; set; }

        public static void Execute(M_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1 m_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1)
        {
            var ths = m_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}