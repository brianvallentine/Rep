using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1 : QueryBasis<R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROP_SASSE_BILHETE
				SET DATA_INCLUSAO =
				 {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : $"{this.SISTEMAS_DATA_MOV_ABERTO}"))},
				COD_USUARIO = 'PF0602B'
				WHERE  NUM_IDENTIFICACAO =
				 '{this.NUM_IDENTIFICACAO}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string VIND_DTMOVTO { get; set; }
        public string NUM_IDENTIFICACAO { get; set; }

        public static void Execute(R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1 r9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1)
        {
            var ths = r9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}