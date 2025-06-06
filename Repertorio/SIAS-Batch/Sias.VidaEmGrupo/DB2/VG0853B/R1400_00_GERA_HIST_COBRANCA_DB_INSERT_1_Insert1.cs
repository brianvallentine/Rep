using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 : QueryBasis<R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCOBVA
            VALUES (:V0PROP-NRCERTIF,
            :V0PROP-NRPARCEL,
            :WHOST-NRTIT,
            :V0HICB-DTVENCTO,
            :WHOST-VLPREMIO-W,
            :V0OPCP-OPCAOPAG,
            :V0HICB-SITUACAO,
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
				INSERT INTO SEGUROS.V0HISTCOBVA VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, {FieldThreatment(this.WHOST_NRTIT)}, {FieldThreatment(this.V0HICB_DTVENCTO)}, {FieldThreatment(this.WHOST_VLPREMIO_W)}, {FieldThreatment(this.V0OPCP_OPCAOPAG)}, {FieldThreatment(this.V0HICB_SITUACAO)}, {FieldThreatment(this.V0HICB_CODOPER)}, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string WHOST_NRTIT { get; set; }
        public string V0HICB_DTVENCTO { get; set; }
        public string WHOST_VLPREMIO_W { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0HICB_SITUACAO { get; set; }
        public string V0HICB_CODOPER { get; set; }

        public static void Execute(R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1)
        {
            var ths = r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}