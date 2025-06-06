using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1 : QueryBasis<R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CHEQUES
            VALUES (:V0CHEQ-TPMOVTO ,
            :V0CHEQ-FONTE ,
            :V0CHEQ-NUMDOC ,
            :V0CHEQ-NOMFAV ,
            :V0CHEQ-VALCHQ ,
            :V0CHEQ-DTMOVTO ,
            NULL ,
            :V0CHEQ-CHQINT ,
            :V0CHEQ-DIGINT ,
            :V0CHEQ-SITUACAO,
            :V0CHEQ-TIPPAG ,
            :V0CHEQ-DATCMP ,
            :V0CHEQ-PRAPAG ,
            :V0CHEQ-NUMREC ,
            :V0CHEQ-OCORHIST,
            :V0CHEQ-OPERACAO,
            :V0CHEQ-CODDSA ,
            :V0CHEQ-VALIRF ,
            :V0CHEQ-VALISS ,
            :V0CHEQ-VALIAP ,
            :V0CHEQ-CODLAN ,
            :V0CHEQ-DATLAN ,
            :V0CHEQ-EMPRESA ,
            CURRENT TIMESTAMP,
            :V0CHEQ-CODFAV ,
            :V0CHEQ-VALINSS)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CHEQUES VALUES ({FieldThreatment(this.V0CHEQ_TPMOVTO)} , {FieldThreatment(this.V0CHEQ_FONTE)} , {FieldThreatment(this.V0CHEQ_NUMDOC)} , {FieldThreatment(this.V0CHEQ_NOMFAV)} , {FieldThreatment(this.V0CHEQ_VALCHQ)} , {FieldThreatment(this.V0CHEQ_DTMOVTO)} , NULL , {FieldThreatment(this.V0CHEQ_CHQINT)} , {FieldThreatment(this.V0CHEQ_DIGINT)} , {FieldThreatment(this.V0CHEQ_SITUACAO)}, {FieldThreatment(this.V0CHEQ_TIPPAG)} , {FieldThreatment(this.V0CHEQ_DATCMP)} , {FieldThreatment(this.V0CHEQ_PRAPAG)} , {FieldThreatment(this.V0CHEQ_NUMREC)} , {FieldThreatment(this.V0CHEQ_OCORHIST)}, {FieldThreatment(this.V0CHEQ_OPERACAO)}, {FieldThreatment(this.V0CHEQ_CODDSA)} , {FieldThreatment(this.V0CHEQ_VALIRF)} , {FieldThreatment(this.V0CHEQ_VALISS)} , {FieldThreatment(this.V0CHEQ_VALIAP)} , {FieldThreatment(this.V0CHEQ_CODLAN)} , {FieldThreatment(this.V0CHEQ_DATLAN)} , {FieldThreatment(this.V0CHEQ_EMPRESA)} , CURRENT TIMESTAMP, {FieldThreatment(this.V0CHEQ_CODFAV)} , {FieldThreatment(this.V0CHEQ_VALINSS)})";

            return query;
        }
        public string V0CHEQ_TPMOVTO { get; set; }
        public string V0CHEQ_FONTE { get; set; }
        public string V0CHEQ_NUMDOC { get; set; }
        public string V0CHEQ_NOMFAV { get; set; }
        public string V0CHEQ_VALCHQ { get; set; }
        public string V0CHEQ_DTMOVTO { get; set; }
        public string V0CHEQ_CHQINT { get; set; }
        public string V0CHEQ_DIGINT { get; set; }
        public string V0CHEQ_SITUACAO { get; set; }
        public string V0CHEQ_TIPPAG { get; set; }
        public string V0CHEQ_DATCMP { get; set; }
        public string V0CHEQ_PRAPAG { get; set; }
        public string V0CHEQ_NUMREC { get; set; }
        public string V0CHEQ_OCORHIST { get; set; }
        public string V0CHEQ_OPERACAO { get; set; }
        public string V0CHEQ_CODDSA { get; set; }
        public string V0CHEQ_VALIRF { get; set; }
        public string V0CHEQ_VALISS { get; set; }
        public string V0CHEQ_VALIAP { get; set; }
        public string V0CHEQ_CODLAN { get; set; }
        public string V0CHEQ_DATLAN { get; set; }
        public string V0CHEQ_EMPRESA { get; set; }
        public string V0CHEQ_CODFAV { get; set; }
        public string V0CHEQ_VALINSS { get; set; }

        public static void Execute(R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1 r1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1)
        {
            var ths = r1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}