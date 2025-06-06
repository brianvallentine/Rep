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
    public class M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET CODOPER =  '{this.PROPVA_CODOPER}',
				DTPROXVEN =  '{this.PROPVA_DTPROXVEN}',
				SITUACAO =  '{this.PROPVA_SITUACAO}',
				NRPARCE =  '{this.PROPVA_NRPARCEL}',
				DTVENCTO =  '{this.PROPVA_DTVENCTO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string PROPVA_DTPROXVEN { get; set; }
        public string PROPVA_SITUACAO { get; set; }
        public string PROPVA_NRPARCEL { get; set; }
        public string PROPVA_DTVENCTO { get; set; }
        public string PROPVA_CODOPER { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}