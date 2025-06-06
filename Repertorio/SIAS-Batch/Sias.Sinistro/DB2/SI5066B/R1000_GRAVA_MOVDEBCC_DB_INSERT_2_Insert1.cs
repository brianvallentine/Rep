using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1 : QueryBasis<R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_MOVTO_CONTA
            ( NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_PARCELA,
            COD_CONVENIO,
            NSAS ,
            COD_AGENCIA ,
            COD_BANCO ,
            NUM_CONTA_CNB,
            NUM_DV_CONTA_CNB,
            IND_CONTA_BANCARIA)
            VALUES (:GE369-NUM-APOLICE,
            :GE369-NUM-ENDOSSO,
            :GE369-NUM-PARCELA,
            :GE369-COD-CONVENIO,
            :GE369-NSAS ,
            :GE369-COD-AGENCIA ,
            :GE369-COD-BANCO ,
            :GE369-NUM-CONTA-CNB,
            :GE369-NUM-DV-CONTA-CNB,
            :GE369-IND-CONTA-BANCARIA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_MOVTO_CONTA ( NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, COD_CONVENIO, NSAS , COD_AGENCIA , COD_BANCO , NUM_CONTA_CNB, NUM_DV_CONTA_CNB, IND_CONTA_BANCARIA) VALUES ({FieldThreatment(this.GE369_NUM_APOLICE)}, {FieldThreatment(this.GE369_NUM_ENDOSSO)}, {FieldThreatment(this.GE369_NUM_PARCELA)}, {FieldThreatment(this.GE369_COD_CONVENIO)}, {FieldThreatment(this.GE369_NSAS)} , {FieldThreatment(this.GE369_COD_AGENCIA)} , {FieldThreatment(this.GE369_COD_BANCO)} , {FieldThreatment(this.GE369_NUM_CONTA_CNB)}, {FieldThreatment(this.GE369_NUM_DV_CONTA_CNB)}, {FieldThreatment(this.GE369_IND_CONTA_BANCARIA)})";

            return query;
        }
        public string GE369_NUM_APOLICE { get; set; }
        public string GE369_NUM_ENDOSSO { get; set; }
        public string GE369_NUM_PARCELA { get; set; }
        public string GE369_COD_CONVENIO { get; set; }
        public string GE369_NSAS { get; set; }
        public string GE369_COD_AGENCIA { get; set; }
        public string GE369_COD_BANCO { get; set; }
        public string GE369_NUM_CONTA_CNB { get; set; }
        public string GE369_NUM_DV_CONTA_CNB { get; set; }
        public string GE369_IND_CONTA_BANCARIA { get; set; }

        public static void Execute(R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1 r1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1)
        {
            var ths = r1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}