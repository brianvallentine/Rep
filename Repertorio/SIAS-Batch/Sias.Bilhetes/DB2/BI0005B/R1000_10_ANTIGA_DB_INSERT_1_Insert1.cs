using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R1000_10_ANTIGA_DB_INSERT_1_Insert1 : QueryBasis<R1000_10_ANTIGA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLCORRET
            VALUES (:V0APCR-NUM-APOL ,
            :V0APCR-RAMOFR ,
            :V0APCR-MODALIFR ,
            :V0APCR-CODCORR ,
            :V0APCR-CODSUBES ,
            :V0APCR-DTINIVIG ,
            :V0APCR-DTTERVIG ,
            :V0APCR-PCPARCOR ,
            :V0APCR-PCCOMCOR ,
            :V0APCR-TIPCOM ,
            :V0APCR-INDCRT ,
            :V0APCR-COD-EMPRESA ,
            CURRENT TIMESTAMP ,
            :V0APCR-COD-USUARIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCORRET VALUES ({FieldThreatment(this.V0APCR_NUM_APOL)} , {FieldThreatment(this.V0APCR_RAMOFR)} , {FieldThreatment(this.V0APCR_MODALIFR)} , {FieldThreatment(this.V0APCR_CODCORR)} , {FieldThreatment(this.V0APCR_CODSUBES)} , {FieldThreatment(this.V0APCR_DTINIVIG)} , {FieldThreatment(this.V0APCR_DTTERVIG)} , {FieldThreatment(this.V0APCR_PCPARCOR)} , {FieldThreatment(this.V0APCR_PCCOMCOR)} , {FieldThreatment(this.V0APCR_TIPCOM)} , {FieldThreatment(this.V0APCR_INDCRT)} , {FieldThreatment(this.V0APCR_COD_EMPRESA)} , CURRENT TIMESTAMP , {FieldThreatment(this.V0APCR_COD_USUARIO)})";

            return query;
        }
        public string V0APCR_NUM_APOL { get; set; }
        public string V0APCR_RAMOFR { get; set; }
        public string V0APCR_MODALIFR { get; set; }
        public string V0APCR_CODCORR { get; set; }
        public string V0APCR_CODSUBES { get; set; }
        public string V0APCR_DTINIVIG { get; set; }
        public string V0APCR_DTTERVIG { get; set; }
        public string V0APCR_PCPARCOR { get; set; }
        public string V0APCR_PCCOMCOR { get; set; }
        public string V0APCR_TIPCOM { get; set; }
        public string V0APCR_INDCRT { get; set; }
        public string V0APCR_COD_EMPRESA { get; set; }
        public string V0APCR_COD_USUARIO { get; set; }

        public static void Execute(R1000_10_ANTIGA_DB_INSERT_1_Insert1 r1000_10_ANTIGA_DB_INSERT_1_Insert1)
        {
            var ths = r1000_10_ANTIGA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_10_ANTIGA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}