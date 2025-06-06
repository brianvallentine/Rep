using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0911S
{
    public class R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1 : QueryBasis<R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0OUTROSBENS
            VALUES (:V0APOB-COD-EMPRESA,
            :V0APOB-FONTE ,
            :V0APOB-NRPROPOS ,
            :V0APOB-NRRISCO ,
            :V0APOB-DTINIVIG ,
            :V0APOB-DTTERVIG ,
            :V0APOB-NRBEM ,
            :V0APOB-DESCRBEM ,
            :V0APOB-NRSERIE ,
            :V0APOB-IMP-SEG-IX ,
            :V0APOB-NUM-APOL ,
            :V0APOB-NRENDOS ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0OUTROSBENS VALUES ({FieldThreatment(this.V0APOB_COD_EMPRESA)}, {FieldThreatment(this.V0APOB_FONTE)} , {FieldThreatment(this.V0APOB_NRPROPOS)} , {FieldThreatment(this.V0APOB_NRRISCO)} , {FieldThreatment(this.V0APOB_DTINIVIG)} , {FieldThreatment(this.V0APOB_DTTERVIG)} , {FieldThreatment(this.V0APOB_NRBEM)} , {FieldThreatment(this.V0APOB_DESCRBEM)} , {FieldThreatment(this.V0APOB_NRSERIE)} , {FieldThreatment(this.V0APOB_IMP_SEG_IX)} , {FieldThreatment(this.V0APOB_NUM_APOL)} , {FieldThreatment(this.V0APOB_NRENDOS)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0APOB_COD_EMPRESA { get; set; }
        public string V0APOB_FONTE { get; set; }
        public string V0APOB_NRPROPOS { get; set; }
        public string V0APOB_NRRISCO { get; set; }
        public string V0APOB_DTINIVIG { get; set; }
        public string V0APOB_DTTERVIG { get; set; }
        public string V0APOB_NRBEM { get; set; }
        public string V0APOB_DESCRBEM { get; set; }
        public string V0APOB_NRSERIE { get; set; }
        public string V0APOB_IMP_SEG_IX { get; set; }
        public string V0APOB_NUM_APOL { get; set; }
        public string V0APOB_NRENDOS { get; set; }

        public static void Execute(R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1 r2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1)
        {
            var ths = r2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}