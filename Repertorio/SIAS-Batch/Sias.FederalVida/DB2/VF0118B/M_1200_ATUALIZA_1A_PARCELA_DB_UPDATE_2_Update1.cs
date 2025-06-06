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
    public class M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1 : QueryBasis<M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOBVA
				SET NRTIT =  '{this.CEDENT_NRTIT}',
				DTVENCTO =  '{this.PROPVA_DTVENCTO}',
				VLPRMTOT =  '{this.COBERP_VLPREMIO}',
				OPCAOPAG = '3' ,
				SITUACAO = '5' ,
				CODOPER = 141
				WHERE  NRCERTIF =  '{this.PROPVA_NRCERTIF}'
				AND NRPARCEL =  '{this.PROPVA_NRPARCEL}'";

            return query;
        }
        public string PROPVA_DTVENCTO { get; set; }
        public string COBERP_VLPREMIO { get; set; }
        public string CEDENT_NRTIT { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_NRPARCEL { get; set; }

        public static void Execute(M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1 m_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1)
        {
            var ths = m_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}