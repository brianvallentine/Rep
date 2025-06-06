using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1 : QueryBasis<R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA_FISICA
				SET ESTADO_CIVIL =  '{this.ESTADO_CIVIL}' ,
				NUM_IDENTIDADE =  '{this.NUM_IDENTIDADE}',
				ORGAO_EXPEDIDOR =  '{this.ORGAO_EXPEDIDOR}',
				UF_EXPEDIDORA =  '{this.UF_EXPEDIDORA}',
				DATA_EXPEDICAO =  '{this.WHOST_DATA_EXP_RG}' ,
				TIPO_IDENT_SIVPF = ' ' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_PESSOA =  '{this.COD_PESSOA}'";

            return query;
        }
        public string ORGAO_EXPEDIDOR { get; set; }
        public string NUM_IDENTIDADE { get; set; }
        public string UF_EXPEDIDORA { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string WHOST_DATA_EXP_RG { get; set; }
        public string COD_PESSOA { get; set; }

        public static void Execute(R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1 r0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1)
        {
            var ths = r0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}