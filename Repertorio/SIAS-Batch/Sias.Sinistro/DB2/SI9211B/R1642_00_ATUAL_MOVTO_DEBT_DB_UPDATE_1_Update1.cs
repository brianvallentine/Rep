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
    public class R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1 : QueryBasis<R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVTO_DEBITOCC_CEF
				SET NUM_ENDOSSO =  '{this.AUX_COD_OPERACAO}'
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'";

            return query;
        }
        public string AUX_COD_OPERACAO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static void Execute(R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1 r1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1)
        {
            var ths = r1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}