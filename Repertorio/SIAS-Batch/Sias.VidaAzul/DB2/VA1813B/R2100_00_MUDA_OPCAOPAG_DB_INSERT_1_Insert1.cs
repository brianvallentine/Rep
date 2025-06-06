using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1813B
{
    public class R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 : QueryBasis<R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1>
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
            DIGCTADEB,
            NUM_CARTAO_CREDITO)
            VALUES (:V0HCTA-NRCERTIF,
            :V0HCOB-DTVENCTO,
            '9999-12-31' ,
            :V0OPCP-OPCAOPAG,
            :V0OPCP-PERIPGTO,
            :V0OPCP-DIADEB,
            'VA1813B' ,
            CURRENT TIMESTAMP,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0OPCAOPAGVA (NRCERTIF, DTINIVIG, DTTERVIG, OPCAOPAG, PERIPGTO, DIA_DEBITO, CODUSU, TIMESTAMP, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, NUM_CARTAO_CREDITO) VALUES ({FieldThreatment(this.V0HCTA_NRCERTIF)}, {FieldThreatment(this.V0HCOB_DTVENCTO)}, '9999-12-31' , {FieldThreatment(this.V0OPCP_OPCAOPAG)}, {FieldThreatment(this.V0OPCP_PERIPGTO)}, {FieldThreatment(this.V0OPCP_DIADEB)}, 'VA1813B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_DIADEB { get; set; }

        public static void Execute(R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 r2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1)
        {
            var ths = r2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}