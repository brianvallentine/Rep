using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 : QueryBasis<M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0OPCAOPAGVA
            (NRCERTIF,
            DTINIVIG,
            DTTERVIG,
            OPCAOPAG,
            PERIPGTO,
            DIA_DEBITO,
            CODUSU,
            TIMESTAMP,
            AGECTADEB,
            OPRCTADEB,
            NUMCTADEB,
            DIGCTADEB)
            VALUES
            (:V1SEGV-NRCERTIF,
            :V1SEGV-DTINIVIG,
            '9999-12-31' ,
            :HOST-OPCAOPAG,
            :HOST-PERIPGTO,
            :V0CCOR-DIA-DEBITO,
            'VA0010B' ,
            CURRENT TIMESTAMP,
            :V0CCOR-COD-AGENCIA:HOST-IND,
            :HOST-OPRCTADEB:HOST-IND,
            :HOST-NUMCTADEB:HOST-IND,
            :HOST-DIGCTADEB:HOST-IND)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0OPCAOPAGVA (NRCERTIF, DTINIVIG, DTTERVIG, OPCAOPAG, PERIPGTO, DIA_DEBITO, CODUSU, TIMESTAMP, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB) VALUES ({FieldThreatment(this.V1SEGV_NRCERTIF)}, {FieldThreatment(this.V1SEGV_DTINIVIG)}, '9999-12-31' , {FieldThreatment(this.HOST_OPCAOPAG)}, {FieldThreatment(this.HOST_PERIPGTO)}, {FieldThreatment(this.V0CCOR_DIA_DEBITO)}, 'VA0010B' , CURRENT TIMESTAMP,  {FieldThreatment((this.HOST_IND?.ToInt() == -1 ? null : this.V0CCOR_COD_AGENCIA))},  {FieldThreatment((this.HOST_IND?.ToInt() == -1 ? null : this.HOST_OPRCTADEB))},  {FieldThreatment((this.HOST_IND?.ToInt() == -1 ? null : this.HOST_NUMCTADEB))},  {FieldThreatment((this.HOST_IND?.ToInt() == -1 ? null : this.HOST_DIGCTADEB))})";

            return query;
        }
        public string V1SEGV_NRCERTIF { get; set; }
        public string V1SEGV_DTINIVIG { get; set; }
        public string HOST_OPCAOPAG { get; set; }
        public string HOST_PERIPGTO { get; set; }
        public string V0CCOR_DIA_DEBITO { get; set; }
        public string V0CCOR_COD_AGENCIA { get; set; }
        public string HOST_IND { get; set; }
        public string HOST_OPRCTADEB { get; set; }
        public string HOST_NUMCTADEB { get; set; }
        public string HOST_DIGCTADEB { get; set; }

        public static void Execute(M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 m_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1)
        {
            var ths = m_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}