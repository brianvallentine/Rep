using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1 : QueryBasis<P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CB_APOLICE_VIGPROP
				SET SITUACAO = '2'
				WHERE  NUM_APOLICE =  '{this.CBAPOVIG_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.CBAPOVIG_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.CBAPOVIG_NUM_PARCELA}'";

            return query;
        }
        public string CBAPOVIG_NUM_APOLICE { get; set; }
        public string CBAPOVIG_NUM_ENDOSSO { get; set; }
        public string CBAPOVIG_NUM_PARCELA { get; set; }

        public static void Execute(P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1 p2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1)
        {
            var ths = p2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}