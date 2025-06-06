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
    public class R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 : QueryBasis<R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1>
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
            :V0RCOM-HORAOPER ,
            :V0RCOM-SITUACAO ,
            :V0RCOM-BCOAVISO ,
            :V0RCOM-AGEAVISO ,
            :V0RCOM-NRAVISO ,
            :V0RCOM-VLRCAP ,
            :V0RCOM-DATARCAP ,
            :V0RCOM-DTCADAST ,
            :V0RCOM-SITCONTB ,
            :V0RCOM-CODEMP:VIND-CODEMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RCAPCOMP VALUES ({FieldThreatment(this.V0RCOM_FONTE)} , {FieldThreatment(this.V0RCOM_NRRCAP)} , {FieldThreatment(this.V0RCOM_NRRCAPCO)} , {FieldThreatment(this.V0RCOM_OPERACAO)} , {FieldThreatment(this.V0RCOM_DTMOVTO)} , {FieldThreatment(this.V0RCOM_HORAOPER)} , {FieldThreatment(this.V0RCOM_SITUACAO)} , {FieldThreatment(this.V0RCOM_BCOAVISO)} , {FieldThreatment(this.V0RCOM_AGEAVISO)} , {FieldThreatment(this.V0RCOM_NRAVISO)} , {FieldThreatment(this.V0RCOM_VLRCAP)} , {FieldThreatment(this.V0RCOM_DATARCAP)} , {FieldThreatment(this.V0RCOM_DTCADAST)} , {FieldThreatment(this.V0RCOM_SITCONTB)} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0RCOM_CODEMP))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0RCOM_FONTE { get; set; }
        public string V0RCOM_NRRCAP { get; set; }
        public string V0RCOM_NRRCAPCO { get; set; }
        public string V0RCOM_OPERACAO { get; set; }
        public string V0RCOM_DTMOVTO { get; set; }
        public string V0RCOM_HORAOPER { get; set; }
        public string V0RCOM_SITUACAO { get; set; }
        public string V0RCOM_BCOAVISO { get; set; }
        public string V0RCOM_AGEAVISO { get; set; }
        public string V0RCOM_NRAVISO { get; set; }
        public string V0RCOM_VLRCAP { get; set; }
        public string V0RCOM_DATARCAP { get; set; }
        public string V0RCOM_DTCADAST { get; set; }
        public string V0RCOM_SITCONTB { get; set; }
        public string V0RCOM_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }

        public static void Execute(R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 r3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1)
        {
            var ths = r3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}