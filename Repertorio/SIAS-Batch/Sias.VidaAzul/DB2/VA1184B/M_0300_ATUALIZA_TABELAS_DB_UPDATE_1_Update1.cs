using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class M_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1 : QueryBasis<M_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COBERPROPVA
				SET DTTERVIG =  '{this.RELATO_DTSOLICITACAO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.RELATO_NRCERTIF}'
				AND OCORHIST =  '{this.PROPVA_OCORHIST}'";

            return query;
        }
        public string RELATO_DTSOLICITACAO { get; set; }
        public string RELATO_NRCERTIF { get; set; }
        public string PROPVA_OCORHIST { get; set; }

        public static void Execute(M_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1 m_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1)
        {
            var ths = m_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}