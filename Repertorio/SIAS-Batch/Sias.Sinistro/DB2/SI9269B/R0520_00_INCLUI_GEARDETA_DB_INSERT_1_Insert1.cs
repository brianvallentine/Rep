using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9269B
{
    public class R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 : QueryBasis<R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1>
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
            :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
            'E' ,
            'E' ,
            'TXT' ,
            :GEARDETA-QTD-REG-PROCESSADO,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO, SEQ_GERACAO, DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA, DTH_MOVIMENTO, DTH_GERACAO, DTH_RECEPCAO, IND_MEIO_ENVIO, STA_ENVIO_RECEPCAO, COD_TIPO_ARQUIVO, QTD_REG_PROCESSADO, QTD_REG_REJEITADOS, QTD_REG_ACEITOS, DTH_TIMESTAMP) VALUES ({FieldThreatment(this.GEARDETA_NOM_ARQUIVO)}, {FieldThreatment(this.GEARDETA_SEQ_GERACAO)}, {FieldThreatment(this.HOST_ANO_MOV_ABERTO)}, {FieldThreatment(this.HOST_MES_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 'E' , 'E' , 'TXT' , {FieldThreatment(this.GEARDETA_QTD_REG_PROCESSADO)}, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string GEARDETA_NOM_ARQUIVO { get; set; }
        public string GEARDETA_SEQ_GERACAO { get; set; }
        public string HOST_ANO_MOV_ABERTO { get; set; }
        public string HOST_MES_MOV_ABERTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string GEARDETA_QTD_REG_PROCESSADO { get; set; }

        public static void Execute(R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 r0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1)
        {
            var ths = r0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}