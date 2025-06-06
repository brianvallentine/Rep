using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3159S
{
    public class R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1 : QueryBasis<R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.LT_SOLICITA_PARAM
				SET PARAM_CHAR04 =  '{this.LTSOLPAR_PARAM_CHAR04}'
				,PARAM_INTG01 =  '{this.LTSOLPAR_PARAM_INTG01}'
				,PARAM_DATE03 =  '{this.LTSOLPAR_PARAM_DATE03}'
				WHERE  COD_PROGRAMA =  '{this.LTSOLPAR_COD_PROGRAMA}'
				AND PARAM_SMINT01 =  '{this.LTSOLPAR_PARAM_SMINT01}'
				AND SIT_SOLICITACAO =  '{this.LTSOLPAR_SIT_SOLICITACAO}'
				AND  '{this.WS_DTINIVIG_PROPOSTA}' BETWEEN PARAM_DATE01
				AND PARAM_DATE02";

            return query;
        }
        public string LTSOLPAR_PARAM_CHAR04 { get; set; }
        public string LTSOLPAR_PARAM_INTG01 { get; set; }
        public string LTSOLPAR_PARAM_DATE03 { get; set; }
        public string LTSOLPAR_SIT_SOLICITACAO { get; set; }
        public string LTSOLPAR_PARAM_SMINT01 { get; set; }
        public string LTSOLPAR_COD_PROGRAMA { get; set; }
        public string WS_DTINIVIG_PROPOSTA { get; set; }

        public static void Execute(R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1 r1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1)
        {
            var ths = r1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}