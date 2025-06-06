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
    public class M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1 : QueryBasis<M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0SALCONTABAZFIL
            VALUES (:NUM-APOLICE,
            :FONTE,
            :COD-SUBGRUPO,
            :CODOPER,
            :VLOPER,
            :DTMOVTO,
            :NUMFAT:INDNUMFAT,
            CURRENT TIMESTAMP,
            :VLIOCC)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0SALCONTABAZFIL VALUES ({FieldThreatment(this.NUM_APOLICE)}, {FieldThreatment(this.FONTE)}, {FieldThreatment(this.COD_SUBGRUPO)}, {FieldThreatment(this.CODOPER)}, {FieldThreatment(this.VLOPER)}, {FieldThreatment(this.DTMOVTO)},  {FieldThreatment((this.INDNUMFAT?.ToInt() == -1 ? null : this.NUMFAT))}, CURRENT TIMESTAMP, {FieldThreatment(this.VLIOCC)})";

            return query;
        }
        public string NUM_APOLICE { get; set; }
        public string FONTE { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string CODOPER { get; set; }
        public string VLOPER { get; set; }
        public string DTMOVTO { get; set; }
        public string NUMFAT { get; set; }
        public string INDNUMFAT { get; set; }
        public string VLIOCC { get; set; }

        public static void Execute(M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1 m_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1)
        {
            var ths = m_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}