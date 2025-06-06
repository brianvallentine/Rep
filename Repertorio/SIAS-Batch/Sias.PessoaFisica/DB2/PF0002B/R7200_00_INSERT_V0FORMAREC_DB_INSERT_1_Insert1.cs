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
    public class R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1 : QueryBasis<R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.V0FORMAREC
            VALUES (:V0FREC-CODPDT ,
            :V0FREC-FONTE ,
            :V0FREC-NUMOPG ,
            :V0FREC-NRPROPOS ,
            :V0FREC-NUMAPOL ,
            :V0FREC-NRENDOS ,
            :V0FREC-NRPARCEL ,
            :V0FREC-NUMPTC ,
            :V0FREC-VALRCP ,
            :V0FREC-PCGACM ,
            :V0FREC-SITUACAO ,
            :V0FREC-VALSDO ,
            :V0FREC-DTMOVTO ,
            :V0FREC-DTVENCTO:VIND-DTVENCTO ,
            :V0FREC-CODEMP:VIND-CODEMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FORMAREC VALUES ({FieldThreatment(this.V0FREC_CODPDT)} , {FieldThreatment(this.V0FREC_FONTE)} , {FieldThreatment(this.V0FREC_NUMOPG)} , {FieldThreatment(this.V0FREC_NRPROPOS)} , {FieldThreatment(this.V0FREC_NUMAPOL)} , {FieldThreatment(this.V0FREC_NRENDOS)} , {FieldThreatment(this.V0FREC_NRPARCEL)} , {FieldThreatment(this.V0FREC_NUMPTC)} , {FieldThreatment(this.V0FREC_VALRCP)} , {FieldThreatment(this.V0FREC_PCGACM)} , {FieldThreatment(this.V0FREC_SITUACAO)} , {FieldThreatment(this.V0FREC_VALSDO)} , {FieldThreatment(this.V0FREC_DTMOVTO)} ,  {FieldThreatment((this.VIND_DTVENCTO?.ToInt() == -1 ? null : this.V0FREC_DTVENCTO))} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0FREC_CODEMP))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0FREC_CODPDT { get; set; }
        public string V0FREC_FONTE { get; set; }
        public string V0FREC_NUMOPG { get; set; }
        public string V0FREC_NRPROPOS { get; set; }
        public string V0FREC_NUMAPOL { get; set; }
        public string V0FREC_NRENDOS { get; set; }
        public string V0FREC_NRPARCEL { get; set; }
        public string V0FREC_NUMPTC { get; set; }
        public string V0FREC_VALRCP { get; set; }
        public string V0FREC_PCGACM { get; set; }
        public string V0FREC_SITUACAO { get; set; }
        public string V0FREC_VALSDO { get; set; }
        public string V0FREC_DTMOVTO { get; set; }
        public string V0FREC_DTVENCTO { get; set; }
        public string VIND_DTVENCTO { get; set; }
        public string V0FREC_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }

        public static void Execute(R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1 r7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1)
        {
            var ths = r7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}