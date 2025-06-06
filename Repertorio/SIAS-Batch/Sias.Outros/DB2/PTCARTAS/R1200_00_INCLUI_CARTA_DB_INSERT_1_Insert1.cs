using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTCARTAS
{
    public class R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_CARTA
            (NUM_CARTA,
            NUM_CARTA_REITERA,
            COD_USUARIO,
            TIMESTAMP,
            SEQ_CARTA_REITERA)
            VALUES (:GECARTA-NUM-CARTA,
            :GECARTA-NUM-CARTA-REITERA:VIND-NUM-CARTA-REITERA,
            :GECARTA-COD-USUARIO,
            CURRENT TIMESTAMP,
            :GECARTA-SEQ-CARTA-REITERA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CARTA (NUM_CARTA, NUM_CARTA_REITERA, COD_USUARIO, TIMESTAMP, SEQ_CARTA_REITERA) VALUES ({FieldThreatment(this.GECARTA_NUM_CARTA)},  {FieldThreatment((this.VIND_NUM_CARTA_REITERA?.ToInt() == -1 ? null : this.GECARTA_NUM_CARTA_REITERA))}, {FieldThreatment(this.GECARTA_COD_USUARIO)}, CURRENT TIMESTAMP, {FieldThreatment(this.GECARTA_SEQ_CARTA_REITERA)})";

            return query;
        }
        public string GECARTA_NUM_CARTA { get; set; }
        public string GECARTA_NUM_CARTA_REITERA { get; set; }
        public string VIND_NUM_CARTA_REITERA { get; set; }
        public string GECARTA_COD_USUARIO { get; set; }
        public string GECARTA_SEQ_CARTA_REITERA { get; set; }

        public static void Execute(R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1 r1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}