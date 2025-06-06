using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1 : QueryBasis<B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RCAPCOMP
            (AGEAVISO,
            BCOAVISO,
            DATARCAP,
            DTCADAST,
            DTMOVTO,
            FONTE,
            HORAOPER,
            NRAVISO,
            NRRCAP,
            NRRCAPCO,
            OPERACAO,
            SITCONTB,
            SITUACAO,
            VLRCAP,
            TIMESTAMP)
            VALUES
            (:PCOM-AGEAVISO,
            :PCOM-BCOAVISO,
            :PCOM-DATARCAP,
            :PCOM-DTCADAST,
            :SIST-DTMOVABE,
            :PCOM-FONTE,
            :PCOM-HORAOPER,
            :PCOM-NRAVISO,
            :PCOM-NRRCAP,
            :PCOM-NRRCAPCO,
            :PCOM-OPERACAO,
            :PCOM-SITCONTB,
            :PCOM-SITUACAO,
            :PCOM-VLRCAP,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RCAPCOMP (AGEAVISO, BCOAVISO, DATARCAP, DTCADAST, DTMOVTO, FONTE, HORAOPER, NRAVISO, NRRCAP, NRRCAPCO, OPERACAO, SITCONTB, SITUACAO, VLRCAP, TIMESTAMP) VALUES ({FieldThreatment(this.PCOM_AGEAVISO)}, {FieldThreatment(this.PCOM_BCOAVISO)}, {FieldThreatment(this.PCOM_DATARCAP)}, {FieldThreatment(this.PCOM_DTCADAST)}, {FieldThreatment(this.SIST_DTMOVABE)}, {FieldThreatment(this.PCOM_FONTE)}, {FieldThreatment(this.PCOM_HORAOPER)}, {FieldThreatment(this.PCOM_NRAVISO)}, {FieldThreatment(this.PCOM_NRRCAP)}, {FieldThreatment(this.PCOM_NRRCAPCO)}, {FieldThreatment(this.PCOM_OPERACAO)}, {FieldThreatment(this.PCOM_SITCONTB)}, {FieldThreatment(this.PCOM_SITUACAO)}, {FieldThreatment(this.PCOM_VLRCAP)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string PCOM_AGEAVISO { get; set; }
        public string PCOM_BCOAVISO { get; set; }
        public string PCOM_DATARCAP { get; set; }
        public string PCOM_DTCADAST { get; set; }
        public string SIST_DTMOVABE { get; set; }
        public string PCOM_FONTE { get; set; }
        public string PCOM_HORAOPER { get; set; }
        public string PCOM_NRAVISO { get; set; }
        public string PCOM_NRRCAP { get; set; }
        public string PCOM_NRRCAPCO { get; set; }
        public string PCOM_OPERACAO { get; set; }
        public string PCOM_SITCONTB { get; set; }
        public string PCOM_SITUACAO { get; set; }
        public string PCOM_VLRCAP { get; set; }

        public static void Execute(B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1 b2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1)
        {
            var ths = b2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}