using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1 : QueryBasis<M_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCOBVA
            VALUES (:PROPVA-NRCERTIF,
            :PROPVA-NRPARCEL,
            :CEDENT-NRTIT,
            :PROPVA-DTVENCTO,
            :COBERP-VLPREMIO,
            :OPCAOP-OPCAOPAG,
            :HISTCB-SITUACAO,
            :HISTCB-CODOPER,
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
				INSERT INTO SEGUROS.V0HISTCOBVA VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, {FieldThreatment(this.PROPVA_NRPARCEL)}, {FieldThreatment(this.CEDENT_NRTIT)}, {FieldThreatment(this.PROPVA_DTVENCTO)}, {FieldThreatment(this.COBERP_VLPREMIO)}, {FieldThreatment(this.OPCAOP_OPCAOPAG)}, {FieldThreatment(this.HISTCB_SITUACAO)}, {FieldThreatment(this.HISTCB_CODOPER)}, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_NRPARCEL { get; set; }
        public string CEDENT_NRTIT { get; set; }
        public string PROPVA_DTVENCTO { get; set; }
        public string COBERP_VLPREMIO { get; set; }
        public string OPCAOP_OPCAOPAG { get; set; }
        public string HISTCB_SITUACAO { get; set; }
        public string HISTCB_CODOPER { get; set; }

        public static void Execute(M_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1 m_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1)
        {
            var ths = m_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}