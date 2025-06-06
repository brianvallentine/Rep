using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 : QueryBasis<R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.APOLICE_COBERTURAS
				SET DATA_TERVIGENCIA =  '{this.SISTEMAS_DATA_MOV_ABERTO_01}'
				WHERE  NUM_APOLICE =  '{this.APOLICOB_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.APOLICOB_NUM_ENDOSSO}'
				AND NUM_ITEM =  '{this.APOLICOB_NUM_ITEM}'
				AND RAMO_COBERTURA =  '{this.APOLICOB_RAMO_COBERTURA}'
				AND COD_COBERTURA =  '{this.APOLICOB_COD_COBERTURA}'
				AND MODALI_COBERTURA =  '{this.APOLICOB_MODALI_COBERTURA}'
				AND OCORR_HISTORICO =  '{this.APOLICOB_OCORR_HISTORICO}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO_01 { get; set; }
        public string APOLICOB_MODALI_COBERTURA { get; set; }
        public string APOLICOB_OCORR_HISTORICO { get; set; }
        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_NUM_ENDOSSO { get; set; }
        public string APOLICOB_NUM_ITEM { get; set; }

        public static void Execute(R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 r3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1)
        {
            var ths = r3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}