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
    public class R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1 : QueryBasis<R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLDESCOBER
            VALUES (:V0APDC-COD-EMPRESA ,
            :V0APDC-NUM-APOL ,
            :V0APDC-NRENDOS ,
            :V0APDC-NUM-RISCO ,
            :V0APDC-SUBRIS ,
            :V0APDC-NRITEM ,
            :V0APDC-DESCR-BENS ,
            :V0APDC-IMP-SEG-IX ,
            :V0APDC-DTINIVIG ,
            :V0APDC-DTTERVIG ,
            :V0APDC-SITUACAO ,
            CURRENT TIMESTAMP,
            :V0APDC-OCORHIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLDESCOBER VALUES ({FieldThreatment(this.V0APDC_COD_EMPRESA)} , {FieldThreatment(this.V0APDC_NUM_APOL)} , {FieldThreatment(this.V0APDC_NRENDOS)} , {FieldThreatment(this.V0APDC_NUM_RISCO)} , {FieldThreatment(this.V0APDC_SUBRIS)} , {FieldThreatment(this.V0APDC_NRITEM)} , {FieldThreatment(this.V0APDC_DESCR_BENS)} , {FieldThreatment(this.V0APDC_IMP_SEG_IX)} , {FieldThreatment(this.V0APDC_DTINIVIG)} , {FieldThreatment(this.V0APDC_DTTERVIG)} , {FieldThreatment(this.V0APDC_SITUACAO)} , CURRENT TIMESTAMP, {FieldThreatment(this.V0APDC_OCORHIST)})";

            return query;
        }
        public string V0APDC_COD_EMPRESA { get; set; }
        public string V0APDC_NUM_APOL { get; set; }
        public string V0APDC_NRENDOS { get; set; }
        public string V0APDC_NUM_RISCO { get; set; }
        public string V0APDC_SUBRIS { get; set; }
        public string V0APDC_NRITEM { get; set; }
        public string V0APDC_DESCR_BENS { get; set; }
        public string V0APDC_IMP_SEG_IX { get; set; }
        public string V0APDC_DTINIVIG { get; set; }
        public string V0APDC_DTTERVIG { get; set; }
        public string V0APDC_SITUACAO { get; set; }
        public string V0APDC_OCORHIST { get; set; }

        public static void Execute(R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1 r2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1)
        {
            var ths = r2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}