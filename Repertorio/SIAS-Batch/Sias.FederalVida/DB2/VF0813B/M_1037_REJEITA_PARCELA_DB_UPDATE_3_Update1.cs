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
    public class M_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1 : QueryBasis<M_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOBVA
				SET SITUACAO = ' ' ,
				VLPRMTOT =  '{this.V0HCOB_VLPRMTOT}',
				OPCAOPAG =  '{this.V0OPCP_OPCAOPAG}'
				WHERE  NRCERTIF =  '{this.V0HCTA_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCOB_NRPARCEL}'
				AND NRTIT =  '{this.V0HCOB_NRTIT}'";

            return query;
        }
        public string V0HCOB_VLPRMTOT { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_NRTIT { get; set; }

        public static void Execute(M_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1 m_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1)
        {
            var ths = m_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}