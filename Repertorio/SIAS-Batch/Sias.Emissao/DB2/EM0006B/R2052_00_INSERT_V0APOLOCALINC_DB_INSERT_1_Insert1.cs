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
    public class R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1 : QueryBasis<R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLOCALINC
            VALUES (:V0APLI-COD-EMPRESA ,
            :V0APLI-NUM-APOL ,
            :V0APLI-NRENDOS ,
            :V0APLI-NUM-RISCO ,
            :V0APLI-COD-LOCAL ,
            :V0APLI-QTITENS ,
            :V0APLI-DTINIVIG ,
            :V0APLI-DTTERVIG ,
            :V0APLI-SITUACAO ,
            CURRENT TIMESTAMP,
            :V0APLI-OCORHIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLOCALINC VALUES ({FieldThreatment(this.V0APLI_COD_EMPRESA)} , {FieldThreatment(this.V0APLI_NUM_APOL)} , {FieldThreatment(this.V0APLI_NRENDOS)} , {FieldThreatment(this.V0APLI_NUM_RISCO)} , {FieldThreatment(this.V0APLI_COD_LOCAL)} , {FieldThreatment(this.V0APLI_QTITENS)} , {FieldThreatment(this.V0APLI_DTINIVIG)} , {FieldThreatment(this.V0APLI_DTTERVIG)} , {FieldThreatment(this.V0APLI_SITUACAO)} , CURRENT TIMESTAMP, {FieldThreatment(this.V0APLI_OCORHIST)})";

            return query;
        }
        public string V0APLI_COD_EMPRESA { get; set; }
        public string V0APLI_NUM_APOL { get; set; }
        public string V0APLI_NRENDOS { get; set; }
        public string V0APLI_NUM_RISCO { get; set; }
        public string V0APLI_COD_LOCAL { get; set; }
        public string V0APLI_QTITENS { get; set; }
        public string V0APLI_DTINIVIG { get; set; }
        public string V0APLI_DTTERVIG { get; set; }
        public string V0APLI_SITUACAO { get; set; }
        public string V0APLI_OCORHIST { get; set; }

        public static void Execute(R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1 r2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1)
        {
            var ths = r2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}