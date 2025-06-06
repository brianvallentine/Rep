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
    public class M_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1 : QueryBasis<M_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0DIFPARCELVA
				SET SITUACAO = ' '
				WHERE  NRCERTIF =  '{this.V0HCTA_NRCERTIF}'
				AND NRPARCELDIF =  '{this.V0CMPT_NRPARCEL}'
				AND CODOPER =  '{this.V0CMPT_CODOPER}'";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0CMPT_NRPARCEL { get; set; }
        public string V0CMPT_CODOPER { get; set; }

        public static void Execute(M_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1 m_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1)
        {
            var ths = m_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}