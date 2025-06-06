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
    public class R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1 : QueryBasis<R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_AUTO1
            (NUM_APOLICE,
            NUM_APOL_SINISTRO,
            NUM_ITEM,
            RAMO,
            SIT_REGISTRO,
            TIMESTAMP)
            VALUES (:SIARDEVC-NUM-APOLICE,
            :SINISMES-NUM-APOL-SINISTRO,
            :APOLIAUT-NUM-ITEM,
            :SIARDEVC-COD-RAMO,
            ' ' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_AUTO1 (NUM_APOLICE, NUM_APOL_SINISTRO, NUM_ITEM, RAMO, SIT_REGISTRO, TIMESTAMP) VALUES ({FieldThreatment(this.SIARDEVC_NUM_APOLICE)}, {FieldThreatment(this.SINISMES_NUM_APOL_SINISTRO)}, {FieldThreatment(this.APOLIAUT_NUM_ITEM)}, {FieldThreatment(this.SIARDEVC_COD_RAMO)}, ' ' , CURRENT TIMESTAMP)";

            return query;
        }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string APOLIAUT_NUM_ITEM { get; set; }
        public string SIARDEVC_COD_RAMO { get; set; }

        public static void Execute(R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1 r2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1)
        {
            var ths = r2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}