using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1 : QueryBasis<R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0APOLACESS
            VALUES (:V0APAC-NUM-APOL,
            :V0APAC-NRITEM,
            :V0APAC-NRENDOS,
            :V0APAC-CDACESS,
            :V0APAC-DTINIVIG,
            :V0APAC-DTTERVIG,
            :V0APAC-VRACESS,
            :V0APAC-VRPLACES,
            :V0APAC-VRPAACES,
            :V0APAC-VRPLAACE,
            :V0APAC-VRPRBACE,
            :V0APAC-TTXISACE,
            :V0APAC-TPMOVTO,
            :V0APAC-OTNACE,
            :V0APAC-PREACEBT,
            :V0APAC-COD-EMPRESA,
            CURRENT TIMESTAMP,
            :V0APAC-IDEACESS:VIND-IDEACESS)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLACESS VALUES ({FieldThreatment(this.V0APAC_NUM_APOL)}, {FieldThreatment(this.V0APAC_NRITEM)}, {FieldThreatment(this.V0APAC_NRENDOS)}, {FieldThreatment(this.V0APAC_CDACESS)}, {FieldThreatment(this.V0APAC_DTINIVIG)}, {FieldThreatment(this.V0APAC_DTTERVIG)}, {FieldThreatment(this.V0APAC_VRACESS)}, {FieldThreatment(this.V0APAC_VRPLACES)}, {FieldThreatment(this.V0APAC_VRPAACES)}, {FieldThreatment(this.V0APAC_VRPLAACE)}, {FieldThreatment(this.V0APAC_VRPRBACE)}, {FieldThreatment(this.V0APAC_TTXISACE)}, {FieldThreatment(this.V0APAC_TPMOVTO)}, {FieldThreatment(this.V0APAC_OTNACE)}, {FieldThreatment(this.V0APAC_PREACEBT)}, {FieldThreatment(this.V0APAC_COD_EMPRESA)}, CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_IDEACESS?.ToInt() == -1 ? null : this.V0APAC_IDEACESS))})";

            return query;
        }
        public string V0APAC_NUM_APOL { get; set; }
        public string V0APAC_NRITEM { get; set; }
        public string V0APAC_NRENDOS { get; set; }
        public string V0APAC_CDACESS { get; set; }
        public string V0APAC_DTINIVIG { get; set; }
        public string V0APAC_DTTERVIG { get; set; }
        public string V0APAC_VRACESS { get; set; }
        public string V0APAC_VRPLACES { get; set; }
        public string V0APAC_VRPAACES { get; set; }
        public string V0APAC_VRPLAACE { get; set; }
        public string V0APAC_VRPRBACE { get; set; }
        public string V0APAC_TTXISACE { get; set; }
        public string V0APAC_TPMOVTO { get; set; }
        public string V0APAC_OTNACE { get; set; }
        public string V0APAC_PREACEBT { get; set; }
        public string V0APAC_COD_EMPRESA { get; set; }
        public string V0APAC_IDEACESS { get; set; }
        public string VIND_IDEACESS { get; set; }

        public static void Execute(R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1 r2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1)
        {
            var ths = r2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}