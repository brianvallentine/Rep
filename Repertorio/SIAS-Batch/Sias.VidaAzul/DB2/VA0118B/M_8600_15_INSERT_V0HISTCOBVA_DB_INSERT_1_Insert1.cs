using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1 : QueryBasis<M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCOBVA
            VALUES (:PROPVA-NRCERTIF,
            1,
            :BANCOS-NRTIT,
            :HISTCB-DTVENCTO,
            :DESCON-VLPREMIO,
            :OPCAOP-OPCAOPAG,
            :HISTCB-SITUACAO,
            0,
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
				INSERT INTO SEGUROS.V0HISTCOBVA VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, 1, {FieldThreatment(this.BANCOS_NRTIT)}, {FieldThreatment(this.HISTCB_DTVENCTO)}, {FieldThreatment(this.DESCON_VLPREMIO)}, {FieldThreatment(this.OPCAOP_OPCAOPAG)}, {FieldThreatment(this.HISTCB_SITUACAO)}, 0, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string BANCOS_NRTIT { get; set; }
        public string HISTCB_DTVENCTO { get; set; }
        public string DESCON_VLPREMIO { get; set; }
        public string OPCAOP_OPCAOPAG { get; set; }
        public string HISTCB_SITUACAO { get; set; }

        public static void Execute(M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1 m_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1)
        {
            var ths = m_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}