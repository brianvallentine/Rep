using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6253B
{
    public class R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 : QueryBasis<R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS
				SET SIT_REGISTRO =  '{this.PARCELAS_SIT_REGISTRO}',
				OCORR_HISTORICO =  '{this.PARCELAS_OCORR_HISTORICO}'
				WHERE  NUM_APOLICE =  '{this.PARCELAS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.PARCELAS_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.PARCELAS_NUM_PARCELA}'";

            return query;
        }
        public string PARCELAS_OCORR_HISTORICO { get; set; }
        public string PARCELAS_SIT_REGISTRO { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }

        public static void Execute(R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 r1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1)
        {
            var ths = r1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}