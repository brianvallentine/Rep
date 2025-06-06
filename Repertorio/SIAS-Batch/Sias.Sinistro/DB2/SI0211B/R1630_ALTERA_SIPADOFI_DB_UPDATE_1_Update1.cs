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
    public class R1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1 : QueryBasis<R1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SI_PAGA_DOC_FISCAL
				SET OCORR_HISTORICO =  '{this.SI111_OCORR_HISTORICO}'
				WHERE  COD_OPERACAO =  '{this.H_SINISHIS_COD_OPERACAO}'
				AND NUM_APOL_SINISTRO =  '{this.SI111_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO =  '{this.HOST_MIN_OCORR_HISTORICO}'";

            return query;
        }
        public string SI111_OCORR_HISTORICO { get; set; }
        public string HOST_MIN_OCORR_HISTORICO { get; set; }
        public string H_SINISHIS_COD_OPERACAO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }

        public static void Execute(R1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1 r1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1)
        {
            var ths = r1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}