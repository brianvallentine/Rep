using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 : QueryBasis<R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVDEBCC_CEF
				SET COD_RETORNO_CEF =  '{this.V1MVDB_COD_RET_CEF}',
				DTMOVTO =  '{this.V1MVDB_DTMOVTO}' ,
				DTRETORNO =  '{this.V1MVDB_DTRETORNO}' ,
				DTCREDITO =  {FieldThreatment((this.VIND_DTCREDITO?.ToInt() == -1 ? null : $"{this.V1MVDB_DTCREDITO}"))},
				SIT_COBRANCA =  '{this.V1MVDB_SIT_COBRANCA}',
				VLR_CREDITO =  '{this.V1MVDB_VLR_CREDITO}' ,
				COD_USUARIO = 'BI0072B' ,
				SEQUENCIA =  {FieldThreatment((this.VIND_SEQUENCIA?.ToInt() == -1 ? null : $"{this.V1MVDB_SEQUENCIA}"))} ,
				NUM_LOTE =  {FieldThreatment((this.VIND_NUM_LOTE?.ToInt() == -1 ? null : $"{this.V1MVDB_NUM_LOTE}"))}
				WHERE  NUM_APOLICE =  '{this.V1MVDB_NUM_APOLICE}'
				AND NRENDOS =  '{this.V1MVDB_NRENDOS}'
				AND NRPARCEL =  '{this.V1MVDB_NRPARCEL}'
				AND COD_CONVENIO =  '{this.V1MVDB_COD_CONVENIO}'";

            return query;
        }
        public string V1MVDB_DTCREDITO { get; set; }
        public string VIND_DTCREDITO { get; set; }
        public string V1MVDB_SEQUENCIA { get; set; }
        public string VIND_SEQUENCIA { get; set; }
        public string V1MVDB_NUM_LOTE { get; set; }
        public string VIND_NUM_LOTE { get; set; }
        public string V1MVDB_SIT_COBRANCA { get; set; }
        public string V1MVDB_COD_RET_CEF { get; set; }
        public string V1MVDB_VLR_CREDITO { get; set; }
        public string V1MVDB_DTRETORNO { get; set; }
        public string V1MVDB_DTMOVTO { get; set; }
        public string V1MVDB_COD_CONVENIO { get; set; }
        public string V1MVDB_NUM_APOLICE { get; set; }
        public string V1MVDB_NRPARCEL { get; set; }
        public string V1MVDB_NRENDOS { get; set; }

        public static void Execute(R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 r3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1)
        {
            var ths = r3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}