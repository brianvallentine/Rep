using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0009B
{
    public class R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1 : QueryBasis<R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.COSSEGURO_PREMIOS
				SET SIT_REGISTRO =  '{this.WHOST_SIT_REGT}',
				OCORR_HISTORICO =  '{this.WHOST_OCORHIST}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  TIPO_SEGURO =  '{this.COSHISPR_TIPO_SEGURO}'
				AND COD_CONGENERE =  '{this.COSHISPR_COD_CONGENERE}'
				AND NUM_ORDEM =  '{this.ORDEMCOS_ORDEM_CEDIDO}'
				AND NUM_APOLICE =  '{this.COSHISPR_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.COSHISPR_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.COSHISPR_NUM_PARCELA}'";

            return query;
        }
        public string WHOST_SIT_REGT { get; set; }
        public string WHOST_OCORHIST { get; set; }
        public string COSHISPR_COD_CONGENERE { get; set; }
        public string ORDEMCOS_ORDEM_CEDIDO { get; set; }
        public string COSHISPR_TIPO_SEGURO { get; set; }
        public string COSHISPR_NUM_APOLICE { get; set; }
        public string COSHISPR_NUM_ENDOSSO { get; set; }
        public string COSHISPR_NUM_PARCELA { get; set; }

        public static void Execute(R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1 r3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1)
        {
            var ths = r3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}