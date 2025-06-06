using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 : QueryBasis<M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAPS
				SET SIT_REGISTRO = '1' ,
				COD_OPERACAO = 220 ,
				NUM_APOLICE =  '{this.VGSOLFAT_NUM_APOLICE}',
				NUM_ENDOSSO = 0,
				NUM_PARCELA = 0,
				TIMESTAMP = CURRENT TIMESTAMP,
				CODIGO_PRODUTO =  '{this.PROPOVA_COD_PRODUTO}'
				WHERE  COD_FONTE =  '{this.RCAPS_COD_FONTE}'
				AND NUM_RCAP =  '{this.RCAPS_NUM_RCAP}'";

            return query;
        }
        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static void Execute(M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1)
        {
            var ths = m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}