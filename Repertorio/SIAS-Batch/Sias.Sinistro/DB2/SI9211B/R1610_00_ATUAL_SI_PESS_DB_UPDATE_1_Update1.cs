using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1 : QueryBasis<R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SI_PESS_SINISTRO
				SET COD_OPERACAO =  '{this.SINISHIS_COD_OPERACAO}'
				WHERE  NUM_APOL_SINISTRO =  '{this.SINISHIS_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO =  '{this.SINISHIS_OCORR_HISTORICO}'
				AND COD_OPERACAO =  '{this.SIARDEVC_COD_OPERACAO}'";

            return query;
        }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_COD_OPERACAO { get; set; }

        public static void Execute(R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1 r1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1)
        {
            var ths = r1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}