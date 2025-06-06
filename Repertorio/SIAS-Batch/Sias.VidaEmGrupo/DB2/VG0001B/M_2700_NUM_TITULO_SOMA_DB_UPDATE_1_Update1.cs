using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1 : QueryBasis<M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BANCOS
				SET NUM_TITULO =  '{this.BANCOS_NUM_TITULO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_BANCO = 104";

            return query;
        }
        public string BANCOS_NUM_TITULO { get; set; }

        public static void Execute(M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1 m_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1)
        {
            var ths = m_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}