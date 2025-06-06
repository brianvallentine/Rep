using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1 : QueryBasis<R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS
            VALUES(:V0AVSD-COD-EMPRESA ,
            :V0AVSD-BCOAVISO ,
            :V0AVSD-AGEAVISO ,
            :V0AVSD-TIPSGU ,
            :V0AVSD-NRAVISO ,
            :V0AVSD-DTAVISO ,
            :V0AVSD-DTMOVTO ,
            :V0AVSD-SDOATU ,
            :V0AVSD-SITUACAO ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0AVISOS_SALDOS VALUES({FieldThreatment(this.V0AVSD_COD_EMPRESA)} , {FieldThreatment(this.V0AVSD_BCOAVISO)} , {FieldThreatment(this.V0AVSD_AGEAVISO)} , {FieldThreatment(this.V0AVSD_TIPSGU)} , {FieldThreatment(this.V0AVSD_NRAVISO)} , {FieldThreatment(this.V0AVSD_DTAVISO)} , {FieldThreatment(this.V0AVSD_DTMOVTO)} , {FieldThreatment(this.V0AVSD_SDOATU)} , {FieldThreatment(this.V0AVSD_SITUACAO)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0AVSD_COD_EMPRESA { get; set; }
        public string V0AVSD_BCOAVISO { get; set; }
        public string V0AVSD_AGEAVISO { get; set; }
        public string V0AVSD_TIPSGU { get; set; }
        public string V0AVSD_NRAVISO { get; set; }
        public string V0AVSD_DTAVISO { get; set; }
        public string V0AVSD_DTMOVTO { get; set; }
        public string V0AVSD_SDOATU { get; set; }
        public string V0AVSD_SITUACAO { get; set; }

        public static void Execute(R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1 r2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1)
        {
            var ths = r2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}