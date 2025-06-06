using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 : QueryBasis<R0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.HIST_CONT_PARCELVA
				SET NUM_TITULO =  '{this.HISCONPA_NUM_TITULO}'
				WHERE  NUM_CERTIFICADO =  '{this.HISCONPA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.HISCONPA_NUM_PARCELA}'
				AND OCORR_HISTORICO =  '{this.HISCONPA_OCORR_HISTORICO}'";

            return query;
        }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static void Execute(R0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 r0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1)
        {
            var ths = r0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}