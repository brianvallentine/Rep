using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0300B
{
    public class R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1 : QueryBasis<R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_BOLETO_RESSARC_SINI
            ( NUM_OCORR_MOVTO ,
            NUM_APOL_SINISTRO ,
            COD_OPERACAO ,
            NUM_OCORR_HISTORICO,
            NUM_RESSARC ,
            SEQ_RESSARC ,
            NUM_PARCELA ,
            NUM_NOSSO_TITULO ,
            NSAS ,
            IDE_SISTEMA ,
            DTH_CADASTRAMENTO )
            VALUES
            (:GE098-NUM-OCORR-MOVTO ,
            :GE098-NUM-APOL-SINISTRO ,
            :GE098-COD-OPERACAO ,
            :GE098-NUM-OCORR-HISTORICO ,
            :GE098-NUM-RESSARC ,
            :GE098-SEQ-RESSARC ,
            :GE098-NUM-PARCELA ,
            :GE098-NUM-NOSSO-TITULO ,
            :GE098-NSAS ,
            :GE098-IDE-SISTEMA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_BOLETO_RESSARC_SINI ( NUM_OCORR_MOVTO , NUM_APOL_SINISTRO , COD_OPERACAO , NUM_OCORR_HISTORICO, NUM_RESSARC , SEQ_RESSARC , NUM_PARCELA , NUM_NOSSO_TITULO , NSAS , IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES ({FieldThreatment(this.GE098_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE098_NUM_APOL_SINISTRO)} , {FieldThreatment(this.GE098_COD_OPERACAO)} , {FieldThreatment(this.GE098_NUM_OCORR_HISTORICO)} , {FieldThreatment(this.GE098_NUM_RESSARC)} , {FieldThreatment(this.GE098_SEQ_RESSARC)} , {FieldThreatment(this.GE098_NUM_PARCELA)} , {FieldThreatment(this.GE098_NUM_NOSSO_TITULO)} , {FieldThreatment(this.GE098_NSAS)} , {FieldThreatment(this.GE098_IDE_SISTEMA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string GE098_NUM_OCORR_MOVTO { get; set; }
        public string GE098_NUM_APOL_SINISTRO { get; set; }
        public string GE098_COD_OPERACAO { get; set; }
        public string GE098_NUM_OCORR_HISTORICO { get; set; }
        public string GE098_NUM_RESSARC { get; set; }
        public string GE098_SEQ_RESSARC { get; set; }
        public string GE098_NUM_PARCELA { get; set; }
        public string GE098_NUM_NOSSO_TITULO { get; set; }
        public string GE098_NSAS { get; set; }
        public string GE098_IDE_SISTEMA { get; set; }

        public static void Execute(R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1 r1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1)
        {
            var ths = r1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}