using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1 : QueryBasis<R5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTAVA
            (NRCERTIF ,
            NRPARCEL ,
            OCORRHISTCTA ,
            AGECTADEB ,
            OPRCTADEB ,
            NUMCTADEB ,
            DIGCTADEB ,
            DTVENCTO ,
            VLPRMTOT ,
            SITUACAO ,
            TIPLANC ,
            TIMESTAMP ,
            OCORHIST ,
            CODCONV ,
            NSAS ,
            NSL ,
            NSAC ,
            CODRET ,
            CODUSU ,
            NUM_CARTAO_CREDITO)
            VALUES (:V0PROP-NRCERTIF,
            :V0PROP-NRPARCEL,
            1,
            :V0OPCP-AGECTADEB,
            :V0OPCP-OPRCTADEB,
            :V0OPCP-NUMCTADEB,
            :V0OPCP-DIGCTADEB,
            :V0PROP-DTVENCTO,
            :V0COBP-VLPREMIO,
            '0' ,
            '1' ,
            CURRENT TIMESTAMP,
            0,
            :V0CONV-CODCONV,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            0)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, 1, {FieldThreatment(this.V0OPCP_AGECTADEB)}, {FieldThreatment(this.V0OPCP_OPRCTADEB)}, {FieldThreatment(this.V0OPCP_NUMCTADEB)}, {FieldThreatment(this.V0OPCP_DIGCTADEB)}, {FieldThreatment(this.V0PROP_DTVENCTO)}, {FieldThreatment(this.V0COBP_VLPREMIO)}, '0' , '1' , CURRENT TIMESTAMP, 0, {FieldThreatment(this.V0CONV_CODCONV)}, NULL, NULL, NULL, NULL, NULL, 0)";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0OPCP_AGECTADEB { get; set; }
        public string V0OPCP_OPRCTADEB { get; set; }
        public string V0OPCP_NUMCTADEB { get; set; }
        public string V0OPCP_DIGCTADEB { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0COBP_VLPREMIO { get; set; }
        public string V0CONV_CODCONV { get; set; }

        public static void Execute(R5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1 r5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1)
        {
            var ths = r5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}