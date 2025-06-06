using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1 : QueryBasis<R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET SIT_REGISTRO = '3'
				, COD_USUARIO = 'CB0124B'
				WHERE  NUM_CERTIFICADO =  '{this.HISLANCT_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.HISLANCT_NUM_PARCELA}'
				AND OCORR_HISTORICOCTA =  '{this.HISLANCT_OCORR_HISTORICOCTA}'
				AND SIT_REGISTRO = ' '";

            return query;
        }
        public string HISLANCT_OCORR_HISTORICOCTA { get; set; }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }

        public static void Execute(R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1 r3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1)
        {
            var ths = r3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}