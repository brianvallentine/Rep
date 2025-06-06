using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9148B
{
    public class R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1 : QueryBasis<R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_AR_DETALHE
				SET QTD_REG_PROCESSADO =
				 '{this.GEARDETA_QTD_REG_PROCESSADO}'
				WHERE  NOM_ARQUIVO =  '{this.GEARDETA_NOM_ARQUIVO}'
				AND SEQ_GERACAO =  '{this.GEARDETA_SEQ_GERACAO}'";

            return query;
        }
        public string GEARDETA_QTD_REG_PROCESSADO { get; set; }
        public string GEARDETA_NOM_ARQUIVO { get; set; }
        public string GEARDETA_SEQ_GERACAO { get; set; }

        public static void Execute(R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1 r0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1)
        {
            var ths = r0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}