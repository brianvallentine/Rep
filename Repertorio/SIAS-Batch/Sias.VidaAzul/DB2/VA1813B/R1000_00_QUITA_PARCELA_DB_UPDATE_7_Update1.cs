using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1813B
{
    public class R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1 : QueryBasis<R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FITASASSE
				SET TOT_DEB_EFET = TOT_DEB_EFET +  '{this.V0HCTA_VLPRMTOT}',
				QTDE_LANC_DEB_RET =
				QTDE_LANC_DEB_RET + 1
				WHERE  COD_CONVENIO =  '{this.WHOST_CODCONV}'
				AND NSAS =  '{this.V0HCTA_NSAS}'";

            return query;
        }
        public string V0HCTA_VLPRMTOT { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string V0HCTA_NSAS { get; set; }

        public static void Execute(R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1 r1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1)
        {
            var ths = r1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}