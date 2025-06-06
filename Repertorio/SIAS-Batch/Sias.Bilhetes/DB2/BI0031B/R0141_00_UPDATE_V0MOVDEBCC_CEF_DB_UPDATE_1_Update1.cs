using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 : QueryBasis<R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVDEBCC_CEF
				SET SIT_COBRANCA = '1' ,
				DTMOVTO =  '{this.V1SISTE_DTMOVABE}',
				DTENVIO = CURRENT DATE,
				NSAS =  '{this.V0PARAMC_NSAS}',
				COD_USUARIO = 'BI0031B' ,
				DIG_CONTA_DEB =  '{this.V0MOVDE_DIG_CONTA_DEB}',
				NUM_REQUISICAO =  '{this.V0MOVDE_REQUISICAO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V0MOVDE_NUM_APOLICE}'
				AND NRENDOS =  '{this.V0MOVDE_NRENDOS}'
				AND NRPARCEL =  '{this.V0MOVDE_NRPARCEL}'
				AND SIT_COBRANCA IN ( '0' , ' ' )
				AND DTVENCTO <=  '{this.V0MOVDE_DTVENCTO}'
				AND COD_CONVENIO =  '{this.V0MOVDE_COD_CONVENIO}'
				AND COD_RETORNO_CEF IS NULL";

            return query;
        }
        public string V0MOVDE_DIG_CONTA_DEB { get; set; }
        public string V0MOVDE_REQUISICAO { get; set; }
        public string V1SISTE_DTMOVABE { get; set; }
        public string V0PARAMC_NSAS { get; set; }
        public string V0MOVDE_COD_CONVENIO { get; set; }
        public string V0MOVDE_NUM_APOLICE { get; set; }
        public string V0MOVDE_NRPARCEL { get; set; }
        public string V0MOVDE_DTVENCTO { get; set; }
        public string V0MOVDE_NRENDOS { get; set; }

        public static void Execute(R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 r0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1)
        {
            var ths = r0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}