using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R1000_05_DELETE_DB_UPDATE_2_Update1 : QueryBasis<R1000_05_DELETE_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET OCORR_HISTORICO =  '{this.PROPOVA_OCORR_HISTORICO}',
				NUM_PARCELA =  '{this.WHOST_NUM_PARCELA}',
				DATA_VENCIMENTO =  '{this.WHOST_DATA_VENCIMENTO}',
				DTPROXVEN =  '{this.PROPOVA_DTPROXVEN}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string WHOST_DATA_VENCIMENTO { get; set; }
        public string WHOST_NUM_PARCELA { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1000_05_DELETE_DB_UPDATE_2_Update1 r1000_05_DELETE_DB_UPDATE_2_Update1)
        {
            var ths = r1000_05_DELETE_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_05_DELETE_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}