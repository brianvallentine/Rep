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
    public class M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1 : QueryBasis<M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTABILVA
				SET PRMVG =  '{this.COBERP_PRMVG}',
				PRMAP =  '{this.COBERP_PRMAP}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.PROPVA_NRCERTIF}'
				AND NRPARCEL = 1
				AND SITUACAO = '0'";

            return query;
        }
        public string COBERP_PRMVG { get; set; }
        public string COBERP_PRMAP { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1 m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1)
        {
            var ths = m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}