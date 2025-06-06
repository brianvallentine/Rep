using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1 : QueryBasis<R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS
				SET SIT_REGISTRO = '1'
				, OCORR_HISTORICO =  '{this.PARCEHIS_OCORR_HISTORICO}'
				WHERE  NUM_APOLICE =  '{this.HISCONPA_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.HISCONPA_NUM_ENDOSSO}'";

            return query;
        }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }

        public static void Execute(R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1 r4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1)
        {
            var ths = r4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}