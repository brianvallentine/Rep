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
    public class R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 : QueryBasis<R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.HIST_CONT_PARCELVA
				SET COD_SUBGRUPO =  '{this.HISCONPA_COD_SUBGRUPO}'
				,NUM_ENDOSSO =  '{this.HISCONPA_NUM_ENDOSSO}'
				,SIT_REGISTRO =  '{this.HISCONPA_SIT_REGISTRO}'
				,DTFATUR =  {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : $"{this.HISCONPA_DTFATUR}"))}
				WHERE  NUM_CERTIFICADO =  '{this.HISCONPA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.HISCONPA_NUM_PARCELA}'
				AND NUM_TITULO =  '{this.HISCONPA_NUM_TITULO}'
				AND OCORR_HISTORICO =  '{this.HISCONPA_OCORR_HISTORICO}'";

            return query;
        }
        public string HISCONPA_DTFATUR { get; set; }
        public string VIND_NULL01 { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_SIT_REGISTRO { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }

        public static void Execute(R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 r4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1)
        {
            var ths = r4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}