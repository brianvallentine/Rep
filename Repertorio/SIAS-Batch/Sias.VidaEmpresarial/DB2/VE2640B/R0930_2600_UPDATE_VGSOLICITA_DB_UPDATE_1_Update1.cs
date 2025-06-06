using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1_Update1 : QueryBasis<R0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_SOLICITA_FATURA
				SET COD_USUARIO =  '{this.VGSOLFAT_COD_USUARIO}'
				WHERE  NUM_APOLICE =  '{this.VGSOLFAT_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.VGSOLFAT_COD_SUBGRUPO}'";

            return query;
        }
        public string VGSOLFAT_COD_USUARIO { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static void Execute(R0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1_Update1 r0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1_Update1)
        {
            var ths = r0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}