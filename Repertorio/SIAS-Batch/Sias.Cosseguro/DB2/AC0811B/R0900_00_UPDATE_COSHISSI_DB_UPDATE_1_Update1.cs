using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0811B
{
    public class R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1 : QueryBasis<R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.COSSEGURO_HIST_SIN
				SET COD_EMPRESA =  '{this.PRODUTO_COD_EMPRESA}'
				WHERE  COD_CONGENERE =  '{this.COSHISSI_COD_CONGENERE}'
				AND NUM_SINISTRO =  '{this.COSHISSI_NUM_SINISTRO}'
				AND DATA_MOVIMENTO =  '{this.COSHISSI_DATA_MOVIMENTO}'
				AND OCORR_HISTORICO =  '{this.COSHISSI_OCORR_HISTORICO}'
				AND COD_OPERACAO =  '{this.COSHISSI_COD_OPERACAO}'
				AND TIPO_SEGURO =  '{this.COSHISSI_TIPO_SEGURO}'
				AND COD_EMPRESA =  '{this.COSHISSI_COD_EMPRESA}'";

            return query;
        }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string COSHISSI_OCORR_HISTORICO { get; set; }
        public string COSHISSI_DATA_MOVIMENTO { get; set; }
        public string COSHISSI_COD_CONGENERE { get; set; }
        public string COSHISSI_NUM_SINISTRO { get; set; }
        public string COSHISSI_COD_OPERACAO { get; set; }
        public string COSHISSI_TIPO_SEGURO { get; set; }
        public string COSHISSI_COD_EMPRESA { get; set; }

        public static void Execute(R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1 r0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1)
        {
            var ths = r0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}