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
    public class R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1 : QueryBasis<R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0BENSCOBER
            VALUES (:V0APBC-COD-EMPRESA:VIND-COD-EMP,
            :V0APBC-FONTE ,
            :V0APBC-NRPROPOS ,
            :V0APBC-NRRISCO ,
            :V0APBC-COD-COBER ,
            :V0APBC-NRBEM ,
            :V0APBC-NUM-APOL ,
            :V0APBC-NRENDOS ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0BENSCOBER VALUES ( {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0APBC_COD_EMPRESA))}, {FieldThreatment(this.V0APBC_FONTE)} , {FieldThreatment(this.V0APBC_NRPROPOS)} , {FieldThreatment(this.V0APBC_NRRISCO)} , {FieldThreatment(this.V0APBC_COD_COBER)} , {FieldThreatment(this.V0APBC_NRBEM)} , {FieldThreatment(this.V0APBC_NUM_APOL)} , {FieldThreatment(this.V0APBC_NRENDOS)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0APBC_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V0APBC_FONTE { get; set; }
        public string V0APBC_NRPROPOS { get; set; }
        public string V0APBC_NRRISCO { get; set; }
        public string V0APBC_COD_COBER { get; set; }
        public string V0APBC_NRBEM { get; set; }
        public string V0APBC_NUM_APOL { get; set; }
        public string V0APBC_NRENDOS { get; set; }

        public static void Execute(R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1 r2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1)
        {
            var ths = r2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}