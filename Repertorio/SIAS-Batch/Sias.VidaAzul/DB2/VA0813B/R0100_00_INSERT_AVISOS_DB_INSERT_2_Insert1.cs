using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1 : QueryBasis<R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0AVISOS_SALDOS
            VALUES (:V0SALD-CODEMP ,
            :V0SALD-BCOAVISO ,
            :V0SALD-AGEAVISO ,
            :V0SALD-TIPSGU ,
            :V0SALD-NRAVISO ,
            :V0SALD-DTAVISO ,
            :V0SALD-DTMOVTO ,
            :V0SALD-SDOATU ,
            :V0SALD-SITUACAO ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0AVISOS_SALDOS VALUES ({FieldThreatment(this.V0SALD_CODEMP)} , {FieldThreatment(this.V0SALD_BCOAVISO)} , {FieldThreatment(this.V0SALD_AGEAVISO)} , {FieldThreatment(this.V0SALD_TIPSGU)} , {FieldThreatment(this.V0SALD_NRAVISO)} , {FieldThreatment(this.V0SALD_DTAVISO)} , {FieldThreatment(this.V0SALD_DTMOVTO)} , {FieldThreatment(this.V0SALD_SDOATU)} , {FieldThreatment(this.V0SALD_SITUACAO)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0SALD_CODEMP { get; set; }
        public string V0SALD_BCOAVISO { get; set; }
        public string V0SALD_AGEAVISO { get; set; }
        public string V0SALD_TIPSGU { get; set; }
        public string V0SALD_NRAVISO { get; set; }
        public string V0SALD_DTAVISO { get; set; }
        public string V0SALD_DTMOVTO { get; set; }
        public string V0SALD_SDOATU { get; set; }
        public string V0SALD_SITUACAO { get; set; }

        public static void Execute(R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1 r0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1)
        {
            var ths = r0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}