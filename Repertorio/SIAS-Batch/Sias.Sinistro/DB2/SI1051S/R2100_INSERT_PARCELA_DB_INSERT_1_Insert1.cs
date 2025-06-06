using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1051S
{
    public class R2100_INSERT_PARCELA_DB_INSERT_1_Insert1 : QueryBasis<R2100_INSERT_PARCELA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.SI_RESSARC_PARCELA
            (NUM_APOL_SINISTRO ,
            OCORR_HISTORICO ,
            COD_OPERACAO ,
            NUM_RESSARC ,
            SEQ_RESSARC ,
            NUM_PARCELA ,
            COD_AGENCIA_CEDENT ,
            COD_SISTEMA_ORIGEM ,
            NUM_CEDENTE ,
            NUM_CEDENTE_DV ,
            DTH_VENCIMENTO ,
            NUM_NOSSO_TITULO ,
            DTH_CADASTRAMENTO ,
            PCT_OPERACAO ,
            IND_FORMA_BAIXA ,
            NOM_PROGRAMA ,
            DTH_PAGAMENTO ,
            IND_INTEGRACAO ,
            NUM_TITULO_SIGCB )
            VALUES (:SI111-NUM-APOL-SINISTRO,
            :SI111-OCORR-HISTORICO,
            :SI111-COD-OPERACAO,
            :SI111-NUM-RESSARC,
            :SI111-SEQ-RESSARC,
            :SI111-NUM-PARCELA,
            :SI111-COD-AGENCIA-CEDENT,
            :SI111-COD-SISTEMA-ORIGEM,
            :SI111-NUM-CEDENTE,
            :SI111-NUM-CEDENTE-DV,
            :SI111-DTH-VENCIMENTO,
            :SI111-NUM-NOSSO-TITULO,
            CURRENT TIMESTAMP,
            :SI111-PCT-OPERACAO,
            :SI111-IND-FORMA-BAIXA,
            'SI1051S' ,
            :SI111-DTH-PAGAMENTO,
            :SI111-IND-INTEGRACAO,
            :SI111-NUM-TITULO-SIGCB)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_RESSARC_PARCELA (NUM_APOL_SINISTRO , OCORR_HISTORICO , COD_OPERACAO , NUM_RESSARC , SEQ_RESSARC , NUM_PARCELA , COD_AGENCIA_CEDENT , COD_SISTEMA_ORIGEM , NUM_CEDENTE , NUM_CEDENTE_DV , DTH_VENCIMENTO , NUM_NOSSO_TITULO , DTH_CADASTRAMENTO , PCT_OPERACAO , IND_FORMA_BAIXA , NOM_PROGRAMA , DTH_PAGAMENTO , IND_INTEGRACAO , NUM_TITULO_SIGCB ) VALUES ({FieldThreatment(this.SI111_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SI111_OCORR_HISTORICO)}, {FieldThreatment(this.SI111_COD_OPERACAO)}, {FieldThreatment(this.SI111_NUM_RESSARC)}, {FieldThreatment(this.SI111_SEQ_RESSARC)}, {FieldThreatment(this.SI111_NUM_PARCELA)}, {FieldThreatment(this.SI111_COD_AGENCIA_CEDENT)}, {FieldThreatment(this.SI111_COD_SISTEMA_ORIGEM)}, {FieldThreatment(this.SI111_NUM_CEDENTE)}, {FieldThreatment(this.SI111_NUM_CEDENTE_DV)}, {FieldThreatment(this.SI111_DTH_VENCIMENTO)}, {FieldThreatment(this.SI111_NUM_NOSSO_TITULO)}, CURRENT TIMESTAMP, {FieldThreatment(this.SI111_PCT_OPERACAO)}, {FieldThreatment(this.SI111_IND_FORMA_BAIXA)}, 'SI1051S' , {FieldThreatment(this.SI111_DTH_PAGAMENTO)}, {FieldThreatment(this.SI111_IND_INTEGRACAO)}, {FieldThreatment(this.SI111_NUM_TITULO_SIGCB)})";

            return query;
        }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_OCORR_HISTORICO { get; set; }
        public string SI111_COD_OPERACAO { get; set; }
        public string SI111_NUM_RESSARC { get; set; }
        public string SI111_SEQ_RESSARC { get; set; }
        public string SI111_NUM_PARCELA { get; set; }
        public string SI111_COD_AGENCIA_CEDENT { get; set; }
        public string SI111_COD_SISTEMA_ORIGEM { get; set; }
        public string SI111_NUM_CEDENTE { get; set; }
        public string SI111_NUM_CEDENTE_DV { get; set; }
        public string SI111_DTH_VENCIMENTO { get; set; }
        public string SI111_NUM_NOSSO_TITULO { get; set; }
        public string SI111_PCT_OPERACAO { get; set; }
        public string SI111_IND_FORMA_BAIXA { get; set; }
        public string SI111_DTH_PAGAMENTO { get; set; }
        public string SI111_IND_INTEGRACAO { get; set; }
        public string SI111_NUM_TITULO_SIGCB { get; set; }

        public static void Execute(R2100_INSERT_PARCELA_DB_INSERT_1_Insert1 r2100_INSERT_PARCELA_DB_INSERT_1_Insert1)
        {
            var ths = r2100_INSERT_PARCELA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_INSERT_PARCELA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}