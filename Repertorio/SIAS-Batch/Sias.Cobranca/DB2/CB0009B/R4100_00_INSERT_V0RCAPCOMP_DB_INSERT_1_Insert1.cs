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
    public class R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 : QueryBasis<R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RCAPCOMP
            VALUES (:V0RCOM-FONTE ,
            :V0RCOM-NRRCAP ,
            :V0RCOM-NRRCAPCO ,
            :V0RCOM-OPERACAO ,
            :V0RCOM-DTMOVTO ,
            CURRENT TIME ,
            :V0RCOM-SITUACAO ,
            :V0FOLL-BCOAVISO ,
            :V0FOLL-AGEAVISO ,
            :V0FOLL-NRAVISO ,
            :V0FOLL-VLPREMIO ,
            :V0FOLL-DTQITBCO ,
            :V0RCOM-DTCADAST ,
            :V0RCOM-SITCONTB ,
            :V0RCOM-CODEMP:VIND-CODEMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RCAPCOMP VALUES ({FieldThreatment(this.V0RCOM_FONTE)} , {FieldThreatment(this.V0RCOM_NRRCAP)} , {FieldThreatment(this.V0RCOM_NRRCAPCO)} , {FieldThreatment(this.V0RCOM_OPERACAO)} , {FieldThreatment(this.V0RCOM_DTMOVTO)} , CURRENT TIME , {FieldThreatment(this.V0RCOM_SITUACAO)} , {FieldThreatment(this.V0FOLL_BCOAVISO)} , {FieldThreatment(this.V0FOLL_AGEAVISO)} , {FieldThreatment(this.V0FOLL_NRAVISO)} , {FieldThreatment(this.V0FOLL_VLPREMIO)} , {FieldThreatment(this.V0FOLL_DTQITBCO)} , {FieldThreatment(this.V0RCOM_DTCADAST)} , {FieldThreatment(this.V0RCOM_SITCONTB)} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0RCOM_CODEMP))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0RCOM_FONTE { get; set; }
        public string V0RCOM_NRRCAP { get; set; }
        public string V0RCOM_NRRCAPCO { get; set; }
        public string V0RCOM_OPERACAO { get; set; }
        public string V0RCOM_DTMOVTO { get; set; }
        public string V0RCOM_SITUACAO { get; set; }
        public string V0FOLL_BCOAVISO { get; set; }
        public string V0FOLL_AGEAVISO { get; set; }
        public string V0FOLL_NRAVISO { get; set; }
        public string V0FOLL_VLPREMIO { get; set; }
        public string V0FOLL_DTQITBCO { get; set; }
        public string V0RCOM_DTCADAST { get; set; }
        public string V0RCOM_SITCONTB { get; set; }
        public string V0RCOM_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }

        public static void Execute(R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 r4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1)
        {
            var ths = r4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}