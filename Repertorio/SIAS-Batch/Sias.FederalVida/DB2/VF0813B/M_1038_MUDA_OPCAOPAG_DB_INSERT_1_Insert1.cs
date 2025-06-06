using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 : QueryBasis<M_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1>
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
            VALUES (:V0HCTA-NRCERTIF,
            :V0HCOB-DTVENCTO,
            '9999-12-31' ,
            '3' ,
            :V0OPCP-PERIPGTO,
            :V0OPCP-DIADEB,
            'VF0813B' ,
            CURRENT TIMESTAMP,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0OPCAOPAGVA (NRCERTIF, DTINIVIG, DTTERVIG, OPCAOPAG, PERIPGTO, DIA_DEBITO, CODUSU, TIMESTAMP, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB) VALUES ({FieldThreatment(this.V0HCTA_NRCERTIF)}, {FieldThreatment(this.V0HCOB_DTVENCTO)}, '9999-12-31' , '3' , {FieldThreatment(this.V0OPCP_PERIPGTO)}, {FieldThreatment(this.V0OPCP_DIADEB)}, 'VF0813B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_DIADEB { get; set; }

        public static void Execute(M_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 m_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1)
        {
            var ths = m_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}