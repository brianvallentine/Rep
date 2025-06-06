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
    public class R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1 : QueryBasis<R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0OUTROSAPOL
            VALUES (:V0APOU-COD-EMPRESA,
            :V0APOU-FONTE ,
            :V0APOU-NRPROPOS ,
            :V0APOU-NRRISCO ,
            :V0APOU-CODCLIEN ,
            :V0APOU-OCORR-END ,
            :V0APOU-PROPRIET ,
            :V0APOU-COD-LOGRAD ,
            :V0APOU-NUM-APOL ,
            :V0APOU-NRENDOS ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0OUTROSAPOL VALUES ({FieldThreatment(this.V0APOU_COD_EMPRESA)}, {FieldThreatment(this.V0APOU_FONTE)} , {FieldThreatment(this.V0APOU_NRPROPOS)} , {FieldThreatment(this.V0APOU_NRRISCO)} , {FieldThreatment(this.V0APOU_CODCLIEN)} , {FieldThreatment(this.V0APOU_OCORR_END)} , {FieldThreatment(this.V0APOU_PROPRIET)} , {FieldThreatment(this.V0APOU_COD_LOGRAD)} , {FieldThreatment(this.V0APOU_NUM_APOL)} , {FieldThreatment(this.V0APOU_NRENDOS)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0APOU_COD_EMPRESA { get; set; }
        public string V0APOU_FONTE { get; set; }
        public string V0APOU_NRPROPOS { get; set; }
        public string V0APOU_NRRISCO { get; set; }
        public string V0APOU_CODCLIEN { get; set; }
        public string V0APOU_OCORR_END { get; set; }
        public string V0APOU_PROPRIET { get; set; }
        public string V0APOU_COD_LOGRAD { get; set; }
        public string V0APOU_NUM_APOL { get; set; }
        public string V0APOU_NRENDOS { get; set; }

        public static void Execute(R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1 r2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1)
        {
            var ths = r2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}