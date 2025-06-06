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
    public class R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1 : QueryBasis<R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLINCDESC
            VALUES (:V0APID-COD-EMPRESA ,
            :V0APID-NUM-APOL ,
            :V0APID-NRENDOS ,
            :V0APID-NUM-RISCO ,
            :V0APID-SUBRIS ,
            :V0APID-NRITEM ,
            :V0APID-PLANTA ,
            :V0APID-PCDESPRT ,
            :V0APID-TPDESCON ,
            :V0APID-PCDESTAR ,
            :V0APID-DESCDESCON ,
            :V0APID-DTINIVIG ,
            :V0APID-DTTERVIG ,
            :V0APID-SITUACAO ,
            CURRENT TIMESTAMP,
            :V0APID-OCORHIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLINCDESC VALUES ({FieldThreatment(this.V0APID_COD_EMPRESA)} , {FieldThreatment(this.V0APID_NUM_APOL)} , {FieldThreatment(this.V0APID_NRENDOS)} , {FieldThreatment(this.V0APID_NUM_RISCO)} , {FieldThreatment(this.V0APID_SUBRIS)} , {FieldThreatment(this.V0APID_NRITEM)} , {FieldThreatment(this.V0APID_PLANTA)} , {FieldThreatment(this.V0APID_PCDESPRT)} , {FieldThreatment(this.V0APID_TPDESCON)} , {FieldThreatment(this.V0APID_PCDESTAR)} , {FieldThreatment(this.V0APID_DESCDESCON)} , {FieldThreatment(this.V0APID_DTINIVIG)} , {FieldThreatment(this.V0APID_DTTERVIG)} , {FieldThreatment(this.V0APID_SITUACAO)} , CURRENT TIMESTAMP, {FieldThreatment(this.V0APID_OCORHIST)})";

            return query;
        }
        public string V0APID_COD_EMPRESA { get; set; }
        public string V0APID_NUM_APOL { get; set; }
        public string V0APID_NRENDOS { get; set; }
        public string V0APID_NUM_RISCO { get; set; }
        public string V0APID_SUBRIS { get; set; }
        public string V0APID_NRITEM { get; set; }
        public string V0APID_PLANTA { get; set; }
        public string V0APID_PCDESPRT { get; set; }
        public string V0APID_TPDESCON { get; set; }
        public string V0APID_PCDESTAR { get; set; }
        public string V0APID_DESCDESCON { get; set; }
        public string V0APID_DTINIVIG { get; set; }
        public string V0APID_DTTERVIG { get; set; }
        public string V0APID_SITUACAO { get; set; }
        public string V0APID_OCORHIST { get; set; }

        public static void Execute(R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1 r2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1)
        {
            var ths = r2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}