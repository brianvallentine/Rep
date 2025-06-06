using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1 : QueryBasis<R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1>
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
            :V0HICB-DTVENCTO,
            :WHOST-VLPREMIO-W,
            '0' ,
            '1' ,
            CURRENT TIMESTAMP,
            0,
            :HOST-CODCONV,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            :V0OPCP-CARTAO-CRED)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, 1, {FieldThreatment(this.V0OPCP_AGECTADEB)}, {FieldThreatment(this.V0OPCP_OPRCTADEB)}, {FieldThreatment(this.V0OPCP_NUMCTADEB)}, {FieldThreatment(this.V0OPCP_DIGCTADEB)}, {FieldThreatment(this.V0HICB_DTVENCTO)}, {FieldThreatment(this.WHOST_VLPREMIO_W)}, '0' , '1' , CURRENT TIMESTAMP, 0, {FieldThreatment(this.HOST_CODCONV)}, NULL, NULL, NULL, NULL, NULL, {FieldThreatment(this.V0OPCP_CARTAO_CRED)})";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0OPCP_AGECTADEB { get; set; }
        public string V0OPCP_OPRCTADEB { get; set; }
        public string V0OPCP_NUMCTADEB { get; set; }
        public string V0OPCP_DIGCTADEB { get; set; }
        public string V0HICB_DTVENCTO { get; set; }
        public string WHOST_VLPREMIO_W { get; set; }
        public string HOST_CODCONV { get; set; }
        public string V0OPCP_CARTAO_CRED { get; set; }

        public static void Execute(R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1 r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1)
        {
            var ths = r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}