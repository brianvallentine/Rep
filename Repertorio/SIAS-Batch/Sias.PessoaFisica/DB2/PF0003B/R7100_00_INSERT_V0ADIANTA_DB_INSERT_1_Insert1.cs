using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0003B
{
    public class R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1 : QueryBasis<R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.V0ADIANTA
            VALUES (:V0ADIA-CODPDT ,
            :V0ADIA-FONTE ,
            :V0ADIA-NUMOPG ,
            :V0ADIA-VALADT ,
            :V0ADIA-QTPRESTA ,
            :V0ADIA-NRPROPOS ,
            :V0ADIA-NUMAPOL ,
            :V0ADIA-NRENDOS ,
            :V0ADIA-NRPARCEL ,
            :V0ADIA-DTMOVTO ,
            :V0ADIA-SITUACAO ,
            :V0ADIA-CODEMP:VIND-CODEMP ,
            CURRENT TIMESTAMP ,
            :V0ADIA-TIPO:VIND-TIPO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0ADIANTA VALUES ({FieldThreatment(this.V0ADIA_CODPDT)} , {FieldThreatment(this.V0ADIA_FONTE)} , {FieldThreatment(this.V0ADIA_NUMOPG)} , {FieldThreatment(this.V0ADIA_VALADT)} , {FieldThreatment(this.V0ADIA_QTPRESTA)} , {FieldThreatment(this.V0ADIA_NRPROPOS)} , {FieldThreatment(this.V0ADIA_NUMAPOL)} , {FieldThreatment(this.V0ADIA_NRENDOS)} , {FieldThreatment(this.V0ADIA_NRPARCEL)} , {FieldThreatment(this.V0ADIA_DTMOVTO)} , {FieldThreatment(this.V0ADIA_SITUACAO)} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0ADIA_CODEMP))} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_TIPO?.ToInt() == -1 ? null : this.V0ADIA_TIPO))})";

            return query;
        }
        public string V0ADIA_CODPDT { get; set; }
        public string V0ADIA_FONTE { get; set; }
        public string V0ADIA_NUMOPG { get; set; }
        public string V0ADIA_VALADT { get; set; }
        public string V0ADIA_QTPRESTA { get; set; }
        public string V0ADIA_NRPROPOS { get; set; }
        public string V0ADIA_NUMAPOL { get; set; }
        public string V0ADIA_NRENDOS { get; set; }
        public string V0ADIA_NRPARCEL { get; set; }
        public string V0ADIA_DTMOVTO { get; set; }
        public string V0ADIA_SITUACAO { get; set; }
        public string V0ADIA_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }
        public string V0ADIA_TIPO { get; set; }
        public string VIND_TIPO { get; set; }

        public static void Execute(R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1 r7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1)
        {
            var ths = r7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}