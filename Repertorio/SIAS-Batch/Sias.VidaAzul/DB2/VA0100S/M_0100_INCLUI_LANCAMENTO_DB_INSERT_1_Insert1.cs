using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0100S
{
    public class M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1 : QueryBasis<M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0SALCONTABAZ
            VALUES (:DTMOVTO,
            :CODPRODAZ,
            :CODOPER,
            :VLOPER,
            CURRENT TIMESTAMP,
            :NUMFAT:INDNUMFAT,
            :VLIOCC)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0SALCONTABAZ VALUES ({FieldThreatment(this.DTMOVTO)}, {FieldThreatment(this.CODPRODAZ)}, {FieldThreatment(this.CODOPER)}, {FieldThreatment(this.VLOPER)}, CURRENT TIMESTAMP,  {FieldThreatment((this.INDNUMFAT?.ToInt() == -1 ? null : this.NUMFAT))}, {FieldThreatment(this.VLIOCC)})";

            return query;
        }
        public string DTMOVTO { get; set; }
        public string CODPRODAZ { get; set; }
        public string CODOPER { get; set; }
        public string VLOPER { get; set; }
        public string NUMFAT { get; set; }
        public string INDNUMFAT { get; set; }
        public string VLIOCC { get; set; }

        public static void Execute(M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1 m_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1)
        {
            var ths = m_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}