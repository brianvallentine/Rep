using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R1000_00_LEITURA_DB_UPDATE_1_Update1 : QueryBasis<R1000_00_LEITURA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SIT_PROPOSTA =  '{this.WHOST_SIT_PROP_SIVPF}',
				SITUACAO_ENVIO = 'S' ,
				COD_USUARIO = 'BI6005B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_SICOB =  '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string WHOST_SIT_PROP_SIVPF { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R1000_00_LEITURA_DB_UPDATE_1_Update1 r1000_00_LEITURA_DB_UPDATE_1_Update1)
        {
            var ths = r1000_00_LEITURA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_LEITURA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}