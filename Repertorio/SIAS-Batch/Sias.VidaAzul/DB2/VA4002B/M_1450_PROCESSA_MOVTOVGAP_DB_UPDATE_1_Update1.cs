using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1 : QueryBasis<M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVIMENTO
				SET DATA_INCLUSAO = CURRENT DATE,
				DATA_NASCIMENTO =  {FieldThreatment((this.WDATA_NASCIMENTO?.ToInt() == -1 ? null : $"{this.MOVIMVGA_DATA_NASCIMENTO}"))},
				DATA_REFERENCIA =  {FieldThreatment((this.WDATA_REFERENCIA?.ToInt() == -1 ? null : $"{this.MOVIMVGA_DATA_REFERENCIA}"))} ,
				COD_USUARIO = 'VA4002B'
				WHERE  NUM_CERTIFICADO =  '{this.MOVIMVGA_NUM_CERTIFICADO}'
				AND COD_OPERACAO =  '{this.MOVIMVGA_COD_OPERACAO}'
				AND DATA_INCLUSAO IS NULL
				AND DATA_AVERBACAO =  '{this.MOVIMVGA_DATA_AVERBACAO}'";

            return query;
        }
        public string MOVIMVGA_DATA_NASCIMENTO { get; set; }
        public string WDATA_NASCIMENTO { get; set; }
        public string MOVIMVGA_DATA_REFERENCIA { get; set; }
        public string WDATA_REFERENCIA { get; set; }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_DATA_AVERBACAO { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }

        public static void Execute(M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1 m_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1)
        {
            var ths = m_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}