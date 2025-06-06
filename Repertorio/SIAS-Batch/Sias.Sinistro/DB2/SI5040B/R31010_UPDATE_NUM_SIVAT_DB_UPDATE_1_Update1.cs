using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5040B
{
    public class R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1 : QueryBasis<R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RALACAO_CHEQ_DOCTO
				SET
				NUMERO_SIVAT =  '{this.RALCHEDO_NUMERO_SIVAT}',
				DV_SIVAT =  '{this.RALCHEDO_DV_SIVAT}',
				DATA_SIVAT =  '{this.SISTEMAS_DATA_MOV_ABERTO}'
				WHERE 
				NUM_CHEQUE_INTERNO =  '{this.CHEQUEMI_NUM_CHEQUE_INTERNO}'
				AND DIG_CHEQUE_INTERNO =  '{this.CHEQUEMI_DIG_CHEQUE_INTERNO}'
				AND NUM_DOCUMENTO =  '{this.RALCHEDO_NUM_DOCUMENTO}'
				AND AGENCIA_CONTRATO =  '{this.RALCHEDO_AGENCIA_CONTRATO}'
				AND AGE_CENTRAL_PROD01 =  '{this.RALCHEDO_AGE_CENTRAL_PROD01}'
				AND OCORR_HISTORICO =  '{this.RALCHEDO_OCORR_HISTORICO}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RALCHEDO_NUMERO_SIVAT { get; set; }
        public string RALCHEDO_DV_SIVAT { get; set; }
        public string CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; }
        public string CHEQUEMI_DIG_CHEQUE_INTERNO { get; set; }
        public string RALCHEDO_AGE_CENTRAL_PROD01 { get; set; }
        public string RALCHEDO_AGENCIA_CONTRATO { get; set; }
        public string RALCHEDO_OCORR_HISTORICO { get; set; }
        public string RALCHEDO_NUM_DOCUMENTO { get; set; }

        public static void Execute(R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1 r31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1)
        {
            var ths = r31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}