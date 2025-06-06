using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0217B
{
    public class R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1 : QueryBasis<R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COSSEGURO_HIST_SIN
				SET VAL_OPERACAO =  '{this.VALOR_AJUSTADO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_SINISTRO =  '{this.SINISTRO_ANT}'
				AND COD_CONGENERE =  '{this.CONGENERE_ANT}'
				AND OCORR_HISTORICO =  '{this.OCOR_HIS_ANT}'
				AND COD_OPERACAO =  '{this.COD_OPER_ANT}'
				AND DATA_MOVIMENTO =  '{this.DT_MOVTO_ANT}'
				AND TIPO_SEGURO = '1'
				AND SIT_REGISTRO = '0'
				AND SIT_LIBRECUP = '0'";

            return query;
        }
        public string VALOR_AJUSTADO { get; set; }
        public string CONGENERE_ANT { get; set; }
        public string SINISTRO_ANT { get; set; }
        public string OCOR_HIS_ANT { get; set; }
        public string COD_OPER_ANT { get; set; }
        public string DT_MOVTO_ANT { get; set; }

        public static void Execute(R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1 r1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1)
        {
            var ths = r1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}