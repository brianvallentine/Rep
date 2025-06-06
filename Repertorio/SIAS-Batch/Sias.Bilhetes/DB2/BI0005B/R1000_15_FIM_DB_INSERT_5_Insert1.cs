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
    public class R1000_15_FIM_DB_INSERT_5_Insert1 : QueryBasis<R1000_15_FIM_DB_INSERT_5_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0HISTOREC
            VALUES (:V0HISR-CODPDT ,
            :V0HISR-FONTE ,
            :V0HISR-NUMOPG ,
            :V0HISR-NRPROPOS ,
            :V0HISR-NUM-APOL ,
            :V0HISR-NRENDOS ,
            :V0HISR-NRPARCEL ,
            :V0HISR-NUMPTC ,
            :V0HISR-VALRCP ,
            :V0HISR-NUMREC ,
            :V0HISR-DTMOVTO ,
            :V0HISR-OPERACAO ,
            CURRENT TIME,
            :V0HISR-COD-EMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTOREC VALUES ({FieldThreatment(this.V0HISR_CODPDT)} , {FieldThreatment(this.V0HISR_FONTE)} , {FieldThreatment(this.V0HISR_NUMOPG)} , {FieldThreatment(this.V0HISR_NRPROPOS)} , {FieldThreatment(this.V0HISR_NUM_APOL)} , {FieldThreatment(this.V0HISR_NRENDOS)} , {FieldThreatment(this.V0HISR_NRPARCEL)} , {FieldThreatment(this.V0HISR_NUMPTC)} , {FieldThreatment(this.V0HISR_VALRCP)} , {FieldThreatment(this.V0HISR_NUMREC)} , {FieldThreatment(this.V0HISR_DTMOVTO)} , {FieldThreatment(this.V0HISR_OPERACAO)} , CURRENT TIME, {FieldThreatment(this.V0HISR_COD_EMP)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0HISR_CODPDT { get; set; }
        public string V0HISR_FONTE { get; set; }
        public string V0HISR_NUMOPG { get; set; }
        public string V0HISR_NRPROPOS { get; set; }
        public string V0HISR_NUM_APOL { get; set; }
        public string V0HISR_NRENDOS { get; set; }
        public string V0HISR_NRPARCEL { get; set; }
        public string V0HISR_NUMPTC { get; set; }
        public string V0HISR_VALRCP { get; set; }
        public string V0HISR_NUMREC { get; set; }
        public string V0HISR_DTMOVTO { get; set; }
        public string V0HISR_OPERACAO { get; set; }
        public string V0HISR_COD_EMP { get; set; }

        public static void Execute(R1000_15_FIM_DB_INSERT_5_Insert1 r1000_15_FIM_DB_INSERT_5_Insert1)
        {
            var ths = r1000_15_FIM_DB_INSERT_5_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_15_FIM_DB_INSERT_5_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}