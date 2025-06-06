using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0FORMAREC
            VALUES (:V0FORM-CODPDT ,
            :V0FORM-FONTE ,
            :V0FORM-NUMOPG ,
            :V0FORM-NRPROPOS ,
            :V0FORM-NUM-APOL ,
            :V0FORM-NRENDOS ,
            :V0FORM-NRPARCEL ,
            :V0FORM-NUMPTC ,
            :V0FORM-VALRCP ,
            :V0FORM-PCGACM ,
            :V0FORM-SITUACAO ,
            :V0FORM-VALSDO ,
            :V0FORM-DTMOVTO ,
            :V0FORM-DTVENCTO ,
            :V0FORM-COD-EMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FORMAREC VALUES ({FieldThreatment(this.V0FORM_CODPDT)} , {FieldThreatment(this.V0FORM_FONTE)} , {FieldThreatment(this.V0FORM_NUMOPG)} , {FieldThreatment(this.V0FORM_NRPROPOS)} , {FieldThreatment(this.V0FORM_NUM_APOL)} , {FieldThreatment(this.V0FORM_NRENDOS)} , {FieldThreatment(this.V0FORM_NRPARCEL)} , {FieldThreatment(this.V0FORM_NUMPTC)} , {FieldThreatment(this.V0FORM_VALRCP)} , {FieldThreatment(this.V0FORM_PCGACM)} , {FieldThreatment(this.V0FORM_SITUACAO)} , {FieldThreatment(this.V0FORM_VALSDO)} , {FieldThreatment(this.V0FORM_DTMOVTO)} , {FieldThreatment(this.V0FORM_DTVENCTO)} , {FieldThreatment(this.V0FORM_COD_EMP)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0FORM_CODPDT { get; set; }
        public string V0FORM_FONTE { get; set; }
        public string V0FORM_NUMOPG { get; set; }
        public string V0FORM_NRPROPOS { get; set; }
        public string V0FORM_NUM_APOL { get; set; }
        public string V0FORM_NRENDOS { get; set; }
        public string V0FORM_NRPARCEL { get; set; }
        public string V0FORM_NUMPTC { get; set; }
        public string V0FORM_VALRCP { get; set; }
        public string V0FORM_PCGACM { get; set; }
        public string V0FORM_SITUACAO { get; set; }
        public string V0FORM_VALSDO { get; set; }
        public string V0FORM_DTMOVTO { get; set; }
        public string V0FORM_DTVENCTO { get; set; }
        public string V0FORM_COD_EMP { get; set; }

        public static void Execute(R1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1 r1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}