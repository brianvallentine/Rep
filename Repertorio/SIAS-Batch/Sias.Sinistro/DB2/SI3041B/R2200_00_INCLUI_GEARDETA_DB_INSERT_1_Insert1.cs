using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI3041B
{
    public class R2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 : QueryBasis<R2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_AR_DETALHE
            (NOM_ARQUIVO,
            SEQ_GERACAO,
            DTH_ANO_REFERENCIA,
            DTH_MES_REFERENCIA,
            DTH_MOVIMENTO,
            DTH_GERACAO,
            DTH_RECEPCAO,
            IND_MEIO_ENVIO,
            STA_ENVIO_RECEPCAO,
            COD_TIPO_ARQUIVO,
            QTD_REG_PROCESSADO,
            QTD_REG_REJEITADOS,
            QTD_REG_ACEITOS,
            DTH_TIMESTAMP)
            VALUES (:GEARDETA-NOM-ARQUIVO,
            :GEARDETA-SEQ-GERACAO,
            :HOST-ANO-MOV-ABERTO,
            :HOST-MES-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
            :GEARDETA-DTH-GERACAO,
            :SISTEMAS-DATA-MOV-ABERTO,
            :GEARDETA-IND-MEIO-ENVIO,
            :GEARDETA-STA-ENVIO-RECEPCAO,
            :GEARDETA-COD-TIPO-ARQUIVO,
            :GEARDETA-QTD-REG-PROCESSADO,
            :GEARDETA-QTD-REG-REJEITADOS,
            :GEARDETA-QTD-REG-ACEITOS,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO, SEQ_GERACAO, DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA, DTH_MOVIMENTO, DTH_GERACAO, DTH_RECEPCAO, IND_MEIO_ENVIO, STA_ENVIO_RECEPCAO, COD_TIPO_ARQUIVO, QTD_REG_PROCESSADO, QTD_REG_REJEITADOS, QTD_REG_ACEITOS, DTH_TIMESTAMP) VALUES ({FieldThreatment(this.GEARDETA_NOM_ARQUIVO)}, {FieldThreatment(this.GEARDETA_SEQ_GERACAO)}, {FieldThreatment(this.HOST_ANO_MOV_ABERTO)}, {FieldThreatment(this.HOST_MES_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.GEARDETA_DTH_GERACAO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.GEARDETA_IND_MEIO_ENVIO)}, {FieldThreatment(this.GEARDETA_STA_ENVIO_RECEPCAO)}, {FieldThreatment(this.GEARDETA_COD_TIPO_ARQUIVO)}, {FieldThreatment(this.GEARDETA_QTD_REG_PROCESSADO)}, {FieldThreatment(this.GEARDETA_QTD_REG_REJEITADOS)}, {FieldThreatment(this.GEARDETA_QTD_REG_ACEITOS)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string GEARDETA_NOM_ARQUIVO { get; set; }
        public string GEARDETA_SEQ_GERACAO { get; set; }
        public string HOST_ANO_MOV_ABERTO { get; set; }
        public string HOST_MES_MOV_ABERTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string GEARDETA_DTH_GERACAO { get; set; }
        public string GEARDETA_IND_MEIO_ENVIO { get; set; }
        public string GEARDETA_STA_ENVIO_RECEPCAO { get; set; }
        public string GEARDETA_COD_TIPO_ARQUIVO { get; set; }
        public string GEARDETA_QTD_REG_PROCESSADO { get; set; }
        public string GEARDETA_QTD_REG_REJEITADOS { get; set; }
        public string GEARDETA_QTD_REG_ACEITOS { get; set; }

        public static void Execute(R2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 r2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1)
        {
            var ths = r2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}