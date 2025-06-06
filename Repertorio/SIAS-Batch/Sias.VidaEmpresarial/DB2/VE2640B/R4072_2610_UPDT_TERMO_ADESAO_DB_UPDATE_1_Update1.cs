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
    public class R4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1_Update1 : QueryBasis<R4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.TERMO_ADESAO
				SET SITUACAO =  '{this.TERMOADE_SITUACAO}'
				WHERE  NUM_TERMO =  '{this.NUMEROUT_NUM_CERT_VGAP}'";

            return query;
        }
        public string TERMOADE_SITUACAO { get; set; }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }

        public static void Execute(R4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1_Update1 r4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1_Update1)
        {
            var ths = r4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}