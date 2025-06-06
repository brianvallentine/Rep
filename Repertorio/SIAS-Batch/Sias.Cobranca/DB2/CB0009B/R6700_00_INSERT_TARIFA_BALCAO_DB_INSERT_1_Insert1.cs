using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1 : QueryBasis<R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.TARIFA_BALCAO_CEF
            VALUES (:V0TRBL-CODEMP ,
            :V0TRBL-MATRICULA ,
            :V0TRBL-TIPOFUNC ,
            :V0TRBL-NRCERTIF ,
            :V0TRBL-DTMOVTO ,
            :V0TRBL-CODPRODU ,
            :V0TRBL-SITUACAO ,
            :V0TRBL-FONTE ,
            :V0TRBL-ESCNEG ,
            :V0TRBL-AGECOBR ,
            :V0TRBL-BCOAVISO ,
            :V0TRBL-AGEAVISO ,
            :V0TRBL-NRAVISO ,
            :V0TRBL-TARIFA ,
            :V0TRBL-BALCAO ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.TARIFA_BALCAO_CEF VALUES ({FieldThreatment(this.V0TRBL_CODEMP)} , {FieldThreatment(this.V0TRBL_MATRICULA)} , {FieldThreatment(this.V0TRBL_TIPOFUNC)} , {FieldThreatment(this.V0TRBL_NRCERTIF)} , {FieldThreatment(this.V0TRBL_DTMOVTO)} , {FieldThreatment(this.V0TRBL_CODPRODU)} , {FieldThreatment(this.V0TRBL_SITUACAO)} , {FieldThreatment(this.V0TRBL_FONTE)} , {FieldThreatment(this.V0TRBL_ESCNEG)} , {FieldThreatment(this.V0TRBL_AGECOBR)} , {FieldThreatment(this.V0TRBL_BCOAVISO)} , {FieldThreatment(this.V0TRBL_AGEAVISO)} , {FieldThreatment(this.V0TRBL_NRAVISO)} , {FieldThreatment(this.V0TRBL_TARIFA)} , {FieldThreatment(this.V0TRBL_BALCAO)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0TRBL_CODEMP { get; set; }
        public string V0TRBL_MATRICULA { get; set; }
        public string V0TRBL_TIPOFUNC { get; set; }
        public string V0TRBL_NRCERTIF { get; set; }
        public string V0TRBL_DTMOVTO { get; set; }
        public string V0TRBL_CODPRODU { get; set; }
        public string V0TRBL_SITUACAO { get; set; }
        public string V0TRBL_FONTE { get; set; }
        public string V0TRBL_ESCNEG { get; set; }
        public string V0TRBL_AGECOBR { get; set; }
        public string V0TRBL_BCOAVISO { get; set; }
        public string V0TRBL_AGEAVISO { get; set; }
        public string V0TRBL_NRAVISO { get; set; }
        public string V0TRBL_TARIFA { get; set; }
        public string V0TRBL_BALCAO { get; set; }

        public static void Execute(R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1 r6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1)
        {
            var ths = r6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}