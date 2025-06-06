using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1 : QueryBasis<R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_NUM_LOTE
            (COD_FONTE,
            NUM_LOTE,
            TIMESTAMP)
            VALUES (:SINNUMLO-COD-FONTE,
            :SINNUMLO-NUM-LOTE,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_NUM_LOTE (COD_FONTE, NUM_LOTE, TIMESTAMP) VALUES ({FieldThreatment(this.SINNUMLO_COD_FONTE)}, {FieldThreatment(this.SINNUMLO_NUM_LOTE)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string SINNUMLO_COD_FONTE { get; set; }
        public string SINNUMLO_NUM_LOTE { get; set; }

        public static void Execute(R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1 r1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1)
        {
            var ths = r1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}