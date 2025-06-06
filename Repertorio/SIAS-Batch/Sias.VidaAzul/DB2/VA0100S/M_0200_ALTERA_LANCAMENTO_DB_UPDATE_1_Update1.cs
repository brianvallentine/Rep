using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0100S
{
    public class M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1 : QueryBasis<M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0SALCONTABAZ
				SET VLOPER =  '{this.VLOPER_W}',
				VLIOCC =  '{this.VLIOCC_W}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  DTMOVTO =  '{this.DTMOVTO}'
				AND CODPRODAZ =  '{this.CODPRODAZ}'
				AND CODOPER =  '{this.CODOPER}'
				AND NUM_FATURA IS NULL";

            return query;
        }
        public string VLOPER_W { get; set; }
        public string VLIOCC_W { get; set; }
        public string CODPRODAZ { get; set; }
        public string DTMOVTO { get; set; }
        public string CODOPER { get; set; }

        public static void Execute(M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1 m_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1)
        {
            var ths = m_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}