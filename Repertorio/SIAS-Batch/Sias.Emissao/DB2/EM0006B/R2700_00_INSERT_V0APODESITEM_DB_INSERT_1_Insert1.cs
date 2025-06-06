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
    public class R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1 : QueryBasis<R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APODESITEM
            VALUES (:V0APDI-COD-EMPRESA ,
            :V0APDI-NUM-APOL ,
            :V0APDI-NRENDOS ,
            :V0APDI-NUM-RISCO ,
            :V0APDI-NRITEM ,
            :V0APDI-COD-PLANTA ,
            :V0APDI-NRLINHA ,
            :V0APDI-DESC-LINHA ,
            :V0APDI-DTINIVIG ,
            :V0APDI-DTTERVIG ,
            CURRENT TIMESTAMP ,
            :V0APDI-OCORHIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APODESITEM VALUES ({FieldThreatment(this.V0APDI_COD_EMPRESA)} , {FieldThreatment(this.V0APDI_NUM_APOL)} , {FieldThreatment(this.V0APDI_NRENDOS)} , {FieldThreatment(this.V0APDI_NUM_RISCO)} , {FieldThreatment(this.V0APDI_NRITEM)} , {FieldThreatment(this.V0APDI_COD_PLANTA)} , {FieldThreatment(this.V0APDI_NRLINHA)} , {FieldThreatment(this.V0APDI_DESC_LINHA)} , {FieldThreatment(this.V0APDI_DTINIVIG)} , {FieldThreatment(this.V0APDI_DTTERVIG)} , CURRENT TIMESTAMP , {FieldThreatment(this.V0APDI_OCORHIST)})";

            return query;
        }
        public string V0APDI_COD_EMPRESA { get; set; }
        public string V0APDI_NUM_APOL { get; set; }
        public string V0APDI_NRENDOS { get; set; }
        public string V0APDI_NUM_RISCO { get; set; }
        public string V0APDI_NRITEM { get; set; }
        public string V0APDI_COD_PLANTA { get; set; }
        public string V0APDI_NRLINHA { get; set; }
        public string V0APDI_DESC_LINHA { get; set; }
        public string V0APDI_DTINIVIG { get; set; }
        public string V0APDI_DTTERVIG { get; set; }
        public string V0APDI_OCORHIST { get; set; }

        public static void Execute(R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1 r2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1)
        {
            var ths = r2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}