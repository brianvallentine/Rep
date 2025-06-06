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
    public class R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 : QueryBasis<R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COBER_HIST_VIDAZUL
				SET SIT_REGISTRO =  '{this.COBHISVI_SIT_REGISTRO}'
				, OCORR_HISTORICO = OCORR_HISTORICO + 1
				WHERE  NUM_CERTIFICADO =  '{this.COBHISVI_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.COBHISVI_NUM_PARCELA}'
				AND SIT_REGISTRO IN ( '0' , 'A' )";

            return query;
        }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string COBHISVI_NUM_CERTIFICADO { get; set; }
        public string COBHISVI_NUM_PARCELA { get; set; }

        public static void Execute(R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 r3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1)
        {
            var ths = r3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}