using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1 : QueryBasis<R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_DOC_CLIENTE
				SET COD_IDENTIFICACAO =  '{this.GEDOCCLI_COD_IDENTIFICACAO}'
				, NOM_ORGAO_EXP =  '{this.GEDOCCLI_NOM_ORGAO_EXP}'
				, DTH_EXPEDICAO =  '{this.GEDOCCLI_DTH_EXPEDICAO}'
				, COD_UF =  {FieldThreatment((this.VIND_UF_EXPEDIDORA?.ToInt() == -1 ? null : $"{this.GEDOCCLI_COD_UF}"))}
				WHERE  COD_CLIENTE =  '{this.GEDOCCLI_COD_CLIENTE}'";

            return query;
        }
        public string GEDOCCLI_COD_UF { get; set; }
        public string VIND_UF_EXPEDIDORA { get; set; }
        public string GEDOCCLI_COD_IDENTIFICACAO { get; set; }
        public string GEDOCCLI_NOM_ORGAO_EXP { get; set; }
        public string GEDOCCLI_DTH_EXPEDICAO { get; set; }
        public string GEDOCCLI_COD_CLIENTE { get; set; }

        public static void Execute(R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1 r2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1)
        {
            var ths = r2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}