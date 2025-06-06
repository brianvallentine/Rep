using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 : QueryBasis<R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FOLLOWUP
            VALUES (:V0FOLP-NUM-APOL,
            :V0FOLP-NRENDOS,
            :V0FOLP-NRPARCEL,
            :V0FOLP-DACPARC,
            :V0FOLP-DTMOVTO,
            :V0FOLP-HORAOPER,
            :V0FOLP-VLPREMIO,
            :V0FOLP-BCOAVISO,
            :V0FOLP-AGEAVISO,
            :V0FOLP-NRAVISO,
            :V0FOLP-CODBAIXA,
            :V0FOLP-CDERRO01,
            :V0FOLP-CDERRO02,
            :V0FOLP-CDERRO03,
            :V0FOLP-CDERRO04,
            :V0FOLP-CDERRO05,
            :V0FOLP-CDERRO06,
            :V0FOLP-SITUACAO,
            :V0FOLP-SITCONTB,
            :V0FOLP-OPERACAO,
            :V0FOLP-DTLIBER:VIND-DTLIBER,
            :V0FOLP-DTQITBCO,
            :V0FOLP-COD-EMPRESA,
            CURRENT TIMESTAMP,
            NULL,
            '1' ,
            NULL,
            NULL,
            NULL,
            :V1ENDO-FONTE,
            :V0FOLP-NRRCAP,
            :V0FOLP-NUM-NOSSO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FOLLOWUP VALUES ({FieldThreatment(this.V0FOLP_NUM_APOL)}, {FieldThreatment(this.V0FOLP_NRENDOS)}, {FieldThreatment(this.V0FOLP_NRPARCEL)}, {FieldThreatment(this.V0FOLP_DACPARC)}, {FieldThreatment(this.V0FOLP_DTMOVTO)}, {FieldThreatment(this.V0FOLP_HORAOPER)}, {FieldThreatment(this.V0FOLP_VLPREMIO)}, {FieldThreatment(this.V0FOLP_BCOAVISO)}, {FieldThreatment(this.V0FOLP_AGEAVISO)}, {FieldThreatment(this.V0FOLP_NRAVISO)}, {FieldThreatment(this.V0FOLP_CODBAIXA)}, {FieldThreatment(this.V0FOLP_CDERRO01)}, {FieldThreatment(this.V0FOLP_CDERRO02)}, {FieldThreatment(this.V0FOLP_CDERRO03)}, {FieldThreatment(this.V0FOLP_CDERRO04)}, {FieldThreatment(this.V0FOLP_CDERRO05)}, {FieldThreatment(this.V0FOLP_CDERRO06)}, {FieldThreatment(this.V0FOLP_SITUACAO)}, {FieldThreatment(this.V0FOLP_SITCONTB)}, {FieldThreatment(this.V0FOLP_OPERACAO)},  {FieldThreatment((this.VIND_DTLIBER?.ToInt() == -1 ? null : this.V0FOLP_DTLIBER))}, {FieldThreatment(this.V0FOLP_DTQITBCO)}, {FieldThreatment(this.V0FOLP_COD_EMPRESA)}, CURRENT TIMESTAMP, NULL, '1' , NULL, NULL, NULL, {FieldThreatment(this.V1ENDO_FONTE)}, {FieldThreatment(this.V0FOLP_NRRCAP)}, {FieldThreatment(this.V0FOLP_NUM_NOSSO)})";

            return query;
        }
        public string V0FOLP_NUM_APOL { get; set; }
        public string V0FOLP_NRENDOS { get; set; }
        public string V0FOLP_NRPARCEL { get; set; }
        public string V0FOLP_DACPARC { get; set; }
        public string V0FOLP_DTMOVTO { get; set; }
        public string V0FOLP_HORAOPER { get; set; }
        public string V0FOLP_VLPREMIO { get; set; }
        public string V0FOLP_BCOAVISO { get; set; }
        public string V0FOLP_AGEAVISO { get; set; }
        public string V0FOLP_NRAVISO { get; set; }
        public string V0FOLP_CODBAIXA { get; set; }
        public string V0FOLP_CDERRO01 { get; set; }
        public string V0FOLP_CDERRO02 { get; set; }
        public string V0FOLP_CDERRO03 { get; set; }
        public string V0FOLP_CDERRO04 { get; set; }
        public string V0FOLP_CDERRO05 { get; set; }
        public string V0FOLP_CDERRO06 { get; set; }
        public string V0FOLP_SITUACAO { get; set; }
        public string V0FOLP_SITCONTB { get; set; }
        public string V0FOLP_OPERACAO { get; set; }
        public string V0FOLP_DTLIBER { get; set; }
        public string VIND_DTLIBER { get; set; }
        public string V0FOLP_DTQITBCO { get; set; }
        public string V0FOLP_COD_EMPRESA { get; set; }
        public string V1ENDO_FONTE { get; set; }
        public string V0FOLP_NRRCAP { get; set; }
        public string V0FOLP_NUM_NOSSO { get; set; }

        public static void Execute(R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 r5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1)
        {
            var ths = r5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}