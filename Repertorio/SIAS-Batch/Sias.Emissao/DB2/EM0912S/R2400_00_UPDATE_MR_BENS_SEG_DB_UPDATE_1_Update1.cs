using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0912S
{
    public class R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1 : QueryBasis<R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MR_BENS_SEGURADO
				SET NUM_APOLICE =  '{this.WHOST_NUM_APOL}',
				NUM_ENDOSSO =  '{this.WHOST_NRENDOS}',
				DTH_TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_FONTE =  '{this.WHOST_FONTE}'
				AND NUM_PROPOSTA =  '{this.WHOST_NRPROPOS}'";

            return query;
        }
        public string WHOST_NUM_APOL { get; set; }
        public string WHOST_NRENDOS { get; set; }
        public string WHOST_NRPROPOS { get; set; }
        public string WHOST_FONTE { get; set; }

        public static void Execute(R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1 r2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1)
        {
            var ths = r2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}