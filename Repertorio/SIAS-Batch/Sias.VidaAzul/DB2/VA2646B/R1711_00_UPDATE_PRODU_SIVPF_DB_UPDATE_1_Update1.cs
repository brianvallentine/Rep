using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1 : QueryBasis<R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PRODUTOS_SIVPF
				SET SEQ_PRD_PROPOSTA =  '{this.PRDSIVPF_SEQ_PRD_PROPOSTA}'
				WHERE  COD_PRODUTO_SIVPF =  '{this.PROPOFID_COD_PRODUTO_SIVPF}'
				AND COD_PRODUTO =  '{this.PROPOVA_COD_PRODUTO}'";

            return query;
        }
        public string PRDSIVPF_SEQ_PRD_PROPOSTA { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }

        public static void Execute(R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1 r1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1)
        {
            var ths = r1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}