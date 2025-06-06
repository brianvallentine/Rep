using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTTEXTOS
{
    public class R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_CARTA_TEXTO
            (NUM_CARTA,
            TEXTO_CARTA,
            TIMESTAMP)
            VALUES (:GECARTEX-NUM-CARTA,
            :GECARTEX-TEXTO-CARTA,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CARTA_TEXTO (NUM_CARTA, TEXTO_CARTA, TIMESTAMP) VALUES ({FieldThreatment(this.GECARTEX_NUM_CARTA)}, {FieldThreatment(this.GECARTEX_TEXTO_CARTA)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string GECARTEX_NUM_CARTA { get; set; }
        public string GECARTEX_TEXTO_CARTA { get; set; }

        public static void Execute(R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1 r1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}