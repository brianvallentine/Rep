using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1 : QueryBasis<R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_CONTROLE_SIGCB_HIST
            VALUES (
            :GE403-NUM-PROPOSTA ,
            :GE403-NUM-CERTIFICADO ,
            :GE403-NUM-PARCELA ,
            :GE403-NUM-APOLICE ,
            :GE403-NUM-ENDOSSO ,
            :GE403-SEQ-CONTROLE-SIGCB ,
            :WS-SEQ-CONTROLE-HIST ,
            :GE403-COD-SITUACAO ,
            :GE404-COD-REJEICAO :WS-IND-COD-REJEICAO,
            :GE403-IDE-SISTEMA ,
            :GE403-COD-USUARIO ,
            CURRENT_TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CONTROLE_SIGCB_HIST VALUES ( {FieldThreatment(this.GE403_NUM_PROPOSTA)} , {FieldThreatment(this.GE403_NUM_CERTIFICADO)} , {FieldThreatment(this.GE403_NUM_PARCELA)} , {FieldThreatment(this.GE403_NUM_APOLICE)} , {FieldThreatment(this.GE403_NUM_ENDOSSO)} , {FieldThreatment(this.GE403_SEQ_CONTROLE_SIGCB)} , {FieldThreatment(this.WS_SEQ_CONTROLE_HIST)} , {FieldThreatment(this.GE403_COD_SITUACAO)} ,  {FieldThreatment((this.WS_IND_COD_REJEICAO?.ToInt() == -1 ? null : this.GE404_COD_REJEICAO))}, {FieldThreatment(this.GE403_IDE_SISTEMA)} , {FieldThreatment(this.GE403_COD_USUARIO)} , CURRENT_TIMESTAMP)";

            return query;
        }
        public string GE403_NUM_PROPOSTA { get; set; }
        public string GE403_NUM_CERTIFICADO { get; set; }
        public string GE403_NUM_PARCELA { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }
        public string GE403_SEQ_CONTROLE_SIGCB { get; set; }
        public string WS_SEQ_CONTROLE_HIST { get; set; }
        public string GE403_COD_SITUACAO { get; set; }
        public string GE404_COD_REJEICAO { get; set; }
        public string WS_IND_COD_REJEICAO { get; set; }
        public string GE403_IDE_SISTEMA { get; set; }
        public string GE403_COD_USUARIO { get; set; }

        public static void Execute(R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1 r2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1)
        {
            var ths = r2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}