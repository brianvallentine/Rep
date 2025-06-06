using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1 : QueryBasis<R1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_ITEM
            ( NUM_APOL_SINISTRO
            ,COD_CLIENTE
            ,COD_FONTE
            )
            VALUES
            (:SINIITEM-NUM-APOL-SINISTRO
            ,:SINIITEM-COD-CLIENTE
            ,:SINIITEM-COD-FONTE
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_ITEM ( NUM_APOL_SINISTRO ,COD_CLIENTE ,COD_FONTE ) VALUES ({FieldThreatment(this.SINIITEM_NUM_APOL_SINISTRO)} ,{FieldThreatment(this.SINIITEM_COD_CLIENTE)} ,{FieldThreatment(this.SINIITEM_COD_FONTE)} )";

            return query;
        }
        public string SINIITEM_NUM_APOL_SINISTRO { get; set; }
        public string SINIITEM_COD_CLIENTE { get; set; }
        public string SINIITEM_COD_FONTE { get; set; }

        public static void Execute(R1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1 r1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1)
        {
            var ths = r1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}