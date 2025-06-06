using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5000B
{
    public class R220_GRAVA_RESSARC_DB_INSERT_1_Insert1 : QueryBasis<R220_GRAVA_RESSARC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.SI_RESSARC_ACORDO
            (NUM_APOL_SINISTRO,
            NUM_RESSARC,
            SEQ_RESSARC,
            COD_SISTEMA_ORIGEM,
            IND_PESSOA_ACORDO,
            NUM_CPFCGC_ACORDO,
            NOM_RESP_ACORDO,
            STA_ACORDO,
            DTH_ACORDO,
            QTD_PARCELAS,
            COD_CONDICAO,
            VLR_INDENIZACAO,
            DTH_INDENIZACAO,
            VLR_PART_TERCEIROS,
            COD_MOEDA_ACORDO,
            VLR_DIVIDA,
            PCT_DESCONTO,
            VLR_TOTAL_ACORDO,
            COD_FORNECEDOR,
            DTH_CADASTRAMENTO,
            NOM_PROGRAMA,
            DTH_CANCELA_ACORDO)
            VALUES (:SI112-NUM-APOL-SINISTRO,
            :SI112-NUM-RESSARC,
            :SI112-SEQ-RESSARC,
            :SI112-COD-SISTEMA-ORIGEM,
            :SI112-IND-PESSOA-ACORDO,
            :SI112-NUM-CPFCGC-ACORDO,
            :SI112-NOM-RESP-ACORDO,
            :SI112-STA-ACORDO,
            :SI112-DTH-ACORDO,
            :SI112-QTD-PARCELAS,
            :SI112-COD-CONDICAO,
            :SI112-VLR-INDENIZACAO,
            :SI112-DTH-INDENIZACAO,
            :SI112-VLR-PART-TERCEIROS,
            :SI112-COD-MOEDA-ACORDO,
            :SI112-VLR-DIVIDA,
            :SI112-PCT-DESCONTO,
            :SI112-VLR-TOTAL-ACORDO,
            :SI112-COD-FORNECEDOR,
            CURRENT TIMESTAMP,
            'SI5000B' ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_RESSARC_ACORDO (NUM_APOL_SINISTRO, NUM_RESSARC, SEQ_RESSARC, COD_SISTEMA_ORIGEM, IND_PESSOA_ACORDO, NUM_CPFCGC_ACORDO, NOM_RESP_ACORDO, STA_ACORDO, DTH_ACORDO, QTD_PARCELAS, COD_CONDICAO, VLR_INDENIZACAO, DTH_INDENIZACAO, VLR_PART_TERCEIROS, COD_MOEDA_ACORDO, VLR_DIVIDA, PCT_DESCONTO, VLR_TOTAL_ACORDO, COD_FORNECEDOR, DTH_CADASTRAMENTO, NOM_PROGRAMA, DTH_CANCELA_ACORDO) VALUES ({FieldThreatment(this.SI112_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SI112_NUM_RESSARC)}, {FieldThreatment(this.SI112_SEQ_RESSARC)}, {FieldThreatment(this.SI112_COD_SISTEMA_ORIGEM)}, {FieldThreatment(this.SI112_IND_PESSOA_ACORDO)}, {FieldThreatment(this.SI112_NUM_CPFCGC_ACORDO)}, {FieldThreatment(this.SI112_NOM_RESP_ACORDO)}, {FieldThreatment(this.SI112_STA_ACORDO)}, {FieldThreatment(this.SI112_DTH_ACORDO)}, {FieldThreatment(this.SI112_QTD_PARCELAS)}, {FieldThreatment(this.SI112_COD_CONDICAO)}, {FieldThreatment(this.SI112_VLR_INDENIZACAO)}, {FieldThreatment(this.SI112_DTH_INDENIZACAO)}, {FieldThreatment(this.SI112_VLR_PART_TERCEIROS)}, {FieldThreatment(this.SI112_COD_MOEDA_ACORDO)}, {FieldThreatment(this.SI112_VLR_DIVIDA)}, {FieldThreatment(this.SI112_PCT_DESCONTO)}, {FieldThreatment(this.SI112_VLR_TOTAL_ACORDO)}, {FieldThreatment(this.SI112_COD_FORNECEDOR)}, CURRENT TIMESTAMP, 'SI5000B' , NULL)";

            return query;
        }
        public string SI112_NUM_APOL_SINISTRO { get; set; }
        public string SI112_NUM_RESSARC { get; set; }
        public string SI112_SEQ_RESSARC { get; set; }
        public string SI112_COD_SISTEMA_ORIGEM { get; set; }
        public string SI112_IND_PESSOA_ACORDO { get; set; }
        public string SI112_NUM_CPFCGC_ACORDO { get; set; }
        public string SI112_NOM_RESP_ACORDO { get; set; }
        public string SI112_STA_ACORDO { get; set; }
        public string SI112_DTH_ACORDO { get; set; }
        public string SI112_QTD_PARCELAS { get; set; }
        public string SI112_COD_CONDICAO { get; set; }
        public string SI112_VLR_INDENIZACAO { get; set; }
        public string SI112_DTH_INDENIZACAO { get; set; }
        public string SI112_VLR_PART_TERCEIROS { get; set; }
        public string SI112_COD_MOEDA_ACORDO { get; set; }
        public string SI112_VLR_DIVIDA { get; set; }
        public string SI112_PCT_DESCONTO { get; set; }
        public string SI112_VLR_TOTAL_ACORDO { get; set; }
        public string SI112_COD_FORNECEDOR { get; set; }

        public static void Execute(R220_GRAVA_RESSARC_DB_INSERT_1_Insert1 r220_GRAVA_RESSARC_DB_INSERT_1_Insert1)
        {
            var ths = r220_GRAVA_RESSARC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R220_GRAVA_RESSARC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}