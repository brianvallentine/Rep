using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1180B
{
    public class R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1 : QueryBasis<R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA
            ( NUM_CERTIFICADO,
            COD_OPERACAO,
            COD_FONTE,
            NUM_PROPOSTA,
            DTMVFDCAP,
            NUM_PARCELA,
            QUANT_TIT_CAPITALI,
            VAL_CUSTO_CAPITALI,
            SITUACAO,
            NRTITFDCAP,
            NRMSCAP,
            NUM_SEQUENCIA,
            TIMESTAMP,
            CODPRODU)
            VALUES (:PROPOVA-NUM-CERTIFICADO,
            :MOVFEDCA-COD-OPERACAO,
            0,
            0,
            :PRODUVG-DTMVFDCAP,
            :PROPOVA-NUM-PARCELA,
            :MOVFEDCA-QUANT-TIT-CAPITALI,
            :MOVFEDCA-VAL-CUSTO-CAPITALI,
            '0' ,
            0,
            0,
            0,
            CURRENT TIMESTAMP,
            :PROPOVA-COD-PRODUTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO, COD_OPERACAO, COD_FONTE, NUM_PROPOSTA, DTMVFDCAP, NUM_PARCELA, QUANT_TIT_CAPITALI, VAL_CUSTO_CAPITALI, SITUACAO, NRTITFDCAP, NRMSCAP, NUM_SEQUENCIA, TIMESTAMP, CODPRODU) VALUES ({FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, {FieldThreatment(this.MOVFEDCA_COD_OPERACAO)}, 0, 0, {FieldThreatment(this.PRODUVG_DTMVFDCAP)}, {FieldThreatment(this.PROPOVA_NUM_PARCELA)}, {FieldThreatment(this.MOVFEDCA_QUANT_TIT_CAPITALI)}, {FieldThreatment(this.MOVFEDCA_VAL_CUSTO_CAPITALI)}, '0' , 0, 0, 0, CURRENT TIMESTAMP, {FieldThreatment(this.PROPOVA_COD_PRODUTO)})";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string MOVFEDCA_COD_OPERACAO { get; set; }
        public string PRODUVG_DTMVFDCAP { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string MOVFEDCA_QUANT_TIT_CAPITALI { get; set; }
        public string MOVFEDCA_VAL_CUSTO_CAPITALI { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }

        public static void Execute(R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1 r1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1)
        {
            var ths = r1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}