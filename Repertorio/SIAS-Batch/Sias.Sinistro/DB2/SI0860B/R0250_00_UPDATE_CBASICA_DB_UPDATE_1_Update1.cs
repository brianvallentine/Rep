using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0860B
{
    public class R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1 : QueryBasis<R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.SINI_BENEF_CBASICA
				SET SIT_REGISTRO = '1' ,
				DATA_INDENIZACAO =  '{this.SINBENCB_DATA_INDENIZACAO}'
				WHERE  NUM_APOLICE =  '{this.SINBENCB_NUM_APOLICE}'
				AND NUM_SINISTRO =  '{this.SINBENCB_NUM_SINISTRO}'
				AND NUM_BILHETE =  '{this.SINBENCB_NUM_BILHETE}'
				AND OCORR_HISTORICO =  '{this.SINBENCB_OCORR_HISTORICO}'";

            return query;
        }
        public string SINBENCB_DATA_INDENIZACAO { get; set; }
        public string SINBENCB_OCORR_HISTORICO { get; set; }
        public string SINBENCB_NUM_SINISTRO { get; set; }
        public string SINBENCB_NUM_APOLICE { get; set; }
        public string SINBENCB_NUM_BILHETE { get; set; }

        public static void Execute(R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1 r0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1)
        {
            var ths = r0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}