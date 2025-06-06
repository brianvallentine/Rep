using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1 : QueryBasis<R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SI_RESSARC_PARCELA
				SET DTH_PAGAMENTO =  '{this.MOVIMCOB_DATA_QUITACAO}',
				IND_FORMA_BAIXA = '1'
				WHERE  NUM_APOL_SINISTRO =  '{this.SI111_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO =  '{this.SI111_OCORR_HISTORICO}'";

            return query;
        }
        public string MOVIMCOB_DATA_QUITACAO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_OCORR_HISTORICO { get; set; }

        public static void Execute(R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1 r1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1)
        {
            var ths = r1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}