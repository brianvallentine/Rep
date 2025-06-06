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
    public class M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1 : QueryBasis<M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0SALCONTABAZFIL
				SET VAL_OPERACAO =  '{this.VLOPER_FIL}',
				VLIOCC =  '{this.VLIOCC_FIL}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.NUM_APOLICE}'
				AND COD_FONTE =  '{this.FONTE}'
				AND DTMOVTO =  '{this.DTMOVTO}'
				AND COD_SUBGRUPO =  '{this.COD_SUBGRUPO}'
				AND COD_OPERACAO =  '{this.CODOPER}'
				AND NUM_FATURA IS NULL";

            return query;
        }
        public string VLOPER_FIL { get; set; }
        public string VLIOCC_FIL { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string NUM_APOLICE { get; set; }
        public string DTMOVTO { get; set; }
        public string CODOPER { get; set; }
        public string FONTE { get; set; }

        public static void Execute(M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1 m_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1)
        {
            var ths = m_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}