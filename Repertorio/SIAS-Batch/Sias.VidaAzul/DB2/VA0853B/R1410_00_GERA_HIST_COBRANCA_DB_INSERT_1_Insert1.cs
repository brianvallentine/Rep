using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 : QueryBasis<R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCOBVA
            VALUES (:V0PROP-NRCERTIF,
            :V0RELA-NRPARCEL,
            :W-TITULO,
            :V0PARC-DTVENCTO,
            :WHOST-VLPREMIO-W,
            :V0OPCP-OPCAOPAG,
            :V0PARC-SITUACAO1,
            :V0HICB-CODOPER,
            0,
            0,
            0,
            0,
            0,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCOBVA VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0RELA_NRPARCEL)}, {FieldThreatment(this.W_TITULO)}, {FieldThreatment(this.V0PARC_DTVENCTO)}, {FieldThreatment(this.WHOST_VLPREMIO_W)}, {FieldThreatment(this.V0OPCP_OPCAOPAG)}, {FieldThreatment(this.V0PARC_SITUACAO1)}, {FieldThreatment(this.V0HICB_CODOPER)}, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0RELA_NRPARCEL { get; set; }
        public string W_TITULO { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string WHOST_VLPREMIO_W { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0PARC_SITUACAO1 { get; set; }
        public string V0HICB_CODOPER { get; set; }

        public static void Execute(R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 r1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1)
        {
            var ths = r1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}