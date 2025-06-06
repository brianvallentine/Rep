using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1 : QueryBasis<R1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RALACAO_CHEQ_DOCTO
				SET OCORR_HISTORICO =  '{this.SI111_OCORR_HISTORICO}'
				WHERE  NUMDOC_NUM01 =  '{this.SI111_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO =  '{this.HOST_MIN_OCORR_HISTORICO}'";

            return query;
        }
        public string SI111_OCORR_HISTORICO { get; set; }
        public string HOST_MIN_OCORR_HISTORICO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }

        public static void Execute(R1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1 r1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1)
        {
            var ths = r1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}