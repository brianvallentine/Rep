using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1 : QueryBasis<R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.V0HISTOREC
            VALUES (:V0HREC-CODPDT ,
            :V0HREC-FONTE ,
            :V0HREC-NUMOPG ,
            :V0HREC-NRPROPOS ,
            :V0HREC-NUMAPOL ,
            :V0HREC-NRENDOS ,
            :V0HREC-NRPARCEL ,
            :V0HREC-NUMPTC ,
            :V0HREC-VALRCP ,
            :V0HREC-NUMREC ,
            :V0HREC-DTMOVTO ,
            :V0HREC-OPERACAO ,
            :V0HREC-HORSIS ,
            :V0HREC-CODEMP:VIND-CODEMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTOREC VALUES ({FieldThreatment(this.V0HREC_CODPDT)} , {FieldThreatment(this.V0HREC_FONTE)} , {FieldThreatment(this.V0HREC_NUMOPG)} , {FieldThreatment(this.V0HREC_NRPROPOS)} , {FieldThreatment(this.V0HREC_NUMAPOL)} , {FieldThreatment(this.V0HREC_NRENDOS)} , {FieldThreatment(this.V0HREC_NRPARCEL)} , {FieldThreatment(this.V0HREC_NUMPTC)} , {FieldThreatment(this.V0HREC_VALRCP)} , {FieldThreatment(this.V0HREC_NUMREC)} , {FieldThreatment(this.V0HREC_DTMOVTO)} , {FieldThreatment(this.V0HREC_OPERACAO)} , {FieldThreatment(this.V0HREC_HORSIS)} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0HREC_CODEMP))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0HREC_CODPDT { get; set; }
        public string V0HREC_FONTE { get; set; }
        public string V0HREC_NUMOPG { get; set; }
        public string V0HREC_NRPROPOS { get; set; }
        public string V0HREC_NUMAPOL { get; set; }
        public string V0HREC_NRENDOS { get; set; }
        public string V0HREC_NRPARCEL { get; set; }
        public string V0HREC_NUMPTC { get; set; }
        public string V0HREC_VALRCP { get; set; }
        public string V0HREC_NUMREC { get; set; }
        public string V0HREC_DTMOVTO { get; set; }
        public string V0HREC_OPERACAO { get; set; }
        public string V0HREC_HORSIS { get; set; }
        public string V0HREC_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }

        public static void Execute(R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1 r7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1)
        {
            var ths = r7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}