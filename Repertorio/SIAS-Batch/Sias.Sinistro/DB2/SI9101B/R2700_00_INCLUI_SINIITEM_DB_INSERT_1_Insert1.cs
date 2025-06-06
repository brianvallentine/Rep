using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1 : QueryBasis<R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_ITEM
            (NUM_APOL_SINISTRO,
            COD_CLIENTE,
            COD_FONTE)
            VALUES (:SINISMES-NUM-APOL-SINISTRO,
            :APOLICES-COD-CLIENTE,
            :ENDOSSOS-COD-FONTE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_ITEM (NUM_APOL_SINISTRO, COD_CLIENTE, COD_FONTE) VALUES ({FieldThreatment(this.SINISMES_NUM_APOL_SINISTRO)}, {FieldThreatment(this.APOLICES_COD_CLIENTE)}, {FieldThreatment(this.ENDOSSOS_COD_FONTE)})";

            return query;
        }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }

        public static void Execute(R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1 r2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1)
        {
            var ths = r2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}