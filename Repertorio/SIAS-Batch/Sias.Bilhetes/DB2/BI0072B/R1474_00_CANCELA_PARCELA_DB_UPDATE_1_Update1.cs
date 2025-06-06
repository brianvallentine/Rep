using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1 : QueryBasis<R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS
				SET SIT_REGISTRO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP,
				OCORR_HISTORICO = (
				SELECT MAX(OCORR_HISTORICO)
				FROM SEGUROS.PARCELA_HISTORICO
				WHERE  NUM_APOLICE =  '{this.V0PARC_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.V0PARC_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.V0PARC_NUM_PARCELA}')
				WHERE  NUM_APOLICE =  '{this.V0PARC_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.V0PARC_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.V0PARC_NUM_PARCELA}'";

            return query;
        }
        public string V0PARC_NUM_APOLICE { get; set; }
        public string V0PARC_NUM_ENDOSSO { get; set; }
        public string V0PARC_NUM_PARCELA { get; set; }

        public static void Execute(R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1 r1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1)
        {
            var ths = r1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}