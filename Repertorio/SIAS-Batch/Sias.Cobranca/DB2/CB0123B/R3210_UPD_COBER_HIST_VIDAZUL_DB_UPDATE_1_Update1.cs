using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0123B
{
    public class R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1 : QueryBasis<R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COBER_HIST_VIDAZUL
				SET NUM_AVISO_CREDITO =  '{this.MOVIMCOB_NUM_AVISO}'
				, BCO_AVISO =  '{this.MOVIMCOB_COD_BANCO}'
				, AGE_AVISO =  '{this.MOVIMCOB_COD_AGENCIA}'
				WHERE  NUM_CERTIFICADO =  '{this.HISCONPA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.HISCONPA_NUM_PARCELA}'
				AND SIT_REGISTRO = '1'";

            return query;
        }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static void Execute(R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1 r3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1)
        {
            var ths = r3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}