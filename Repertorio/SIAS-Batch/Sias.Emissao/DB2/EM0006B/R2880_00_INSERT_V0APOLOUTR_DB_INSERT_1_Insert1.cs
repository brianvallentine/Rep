using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1 : QueryBasis<R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLOUTINC
            VALUES (:V0APOU-COD-EMPRESA ,
            :V0APOU-NUM-APOL ,
            :V0APOU-NRENDOS ,
            :V0APOU-APOLIDER ,
            :V0APOU-CODLIDER ,
            :V0APOU-IMP-SEG-IX ,
            :V0APOU-DTINIVIG ,
            :V0APOU-DTTERVIG ,
            CURRENT TIMESTAMP,
            :V0APOU-OCORHIST )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLOUTINC VALUES ({FieldThreatment(this.V0APOU_COD_EMPRESA)} , {FieldThreatment(this.V0APOU_NUM_APOL)} , {FieldThreatment(this.V0APOU_NRENDOS)} , {FieldThreatment(this.V0APOU_APOLIDER)} , {FieldThreatment(this.V0APOU_CODLIDER)} , {FieldThreatment(this.V0APOU_IMP_SEG_IX)} , {FieldThreatment(this.V0APOU_DTINIVIG)} , {FieldThreatment(this.V0APOU_DTTERVIG)} , CURRENT TIMESTAMP, {FieldThreatment(this.V0APOU_OCORHIST)} )";

            return query;
        }
        public string V0APOU_COD_EMPRESA { get; set; }
        public string V0APOU_NUM_APOL { get; set; }
        public string V0APOU_NRENDOS { get; set; }
        public string V0APOU_APOLIDER { get; set; }
        public string V0APOU_CODLIDER { get; set; }
        public string V0APOU_IMP_SEG_IX { get; set; }
        public string V0APOU_DTINIVIG { get; set; }
        public string V0APOU_DTTERVIG { get; set; }
        public string V0APOU_OCORHIST { get; set; }

        public static void Execute(R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1 r2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1)
        {
            var ths = r2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}