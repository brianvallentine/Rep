using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1473B
{
    public class M_0000_PRINCIPAL_DB_INSERT_1_Insert1 : QueryBasis<M_0000_PRINCIPAL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_AR_DETALHE
            (NOM_ARQUIVO ,
            SEQ_GERACAO ,
            DTH_ANO_REFERENCIA ,
            DTH_MES_REFERENCIA ,
            DTH_MOVIMENTO ,
            DTH_GERACAO ,
            DTH_RECEPCAO ,
            IND_MEIO_ENVIO ,
            STA_ENVIO_RECEPCAO ,
            COD_TIPO_ARQUIVO ,
            QTD_REG_PROCESSADO ,
            QTD_REG_REJEITADOS ,
            QTD_REG_ACEITOS ,
            DTH_TIMESTAMP ,
            NOM_DATASET ,
            QTD_REG_INF ,
            IND_OPERACAO ,
            COD_ULT_REGISTRO
            )
            VALUES (:GEARDETA-NOM-ARQUIVO ,
            :GEARDETA-SEQ-GERACAO ,
            :GEARDETA-DTH-ANO-REFERENCIA,
            :GEARDETA-DTH-MES-REFERENCIA,
            CURRENT_DATE ,
            CURRENT_DATE ,
            CURRENT_DATE ,
            :GEARDETA-IND-MEIO-ENVIO ,
            :GEARDETA-STA-ENVIO-RECEPCAO,
            :GEARDETA-COD-TIPO-ARQUIVO ,
            :GEARDETA-QTD-REG-PROCESSADO,
            :GEARDETA-QTD-REG-REJEITADOS,
            :GEARDETA-QTD-REG-ACEITOS ,
            CURRENT_TIMESTAMP ,
            NULL ,
            0 ,
            NULL ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO , SEQ_GERACAO , DTH_ANO_REFERENCIA , DTH_MES_REFERENCIA , DTH_MOVIMENTO , DTH_GERACAO , DTH_RECEPCAO , IND_MEIO_ENVIO , STA_ENVIO_RECEPCAO , COD_TIPO_ARQUIVO , QTD_REG_PROCESSADO , QTD_REG_REJEITADOS , QTD_REG_ACEITOS , DTH_TIMESTAMP , NOM_DATASET , QTD_REG_INF , IND_OPERACAO , COD_ULT_REGISTRO ) VALUES ({FieldThreatment(this.GEARDETA_NOM_ARQUIVO)} , {FieldThreatment(this.GEARDETA_SEQ_GERACAO)} , {FieldThreatment(this.GEARDETA_DTH_ANO_REFERENCIA)}, {FieldThreatment(this.GEARDETA_DTH_MES_REFERENCIA)}, CURRENT_DATE , CURRENT_DATE , CURRENT_DATE , {FieldThreatment(this.GEARDETA_IND_MEIO_ENVIO)} , {FieldThreatment(this.GEARDETA_STA_ENVIO_RECEPCAO)}, {FieldThreatment(this.GEARDETA_COD_TIPO_ARQUIVO)} , {FieldThreatment(this.GEARDETA_QTD_REG_PROCESSADO)}, {FieldThreatment(this.GEARDETA_QTD_REG_REJEITADOS)}, {FieldThreatment(this.GEARDETA_QTD_REG_ACEITOS)} , CURRENT_TIMESTAMP , NULL , 0 , NULL , NULL)";

            return query;
        }
        public string GEARDETA_NOM_ARQUIVO { get; set; }
        public string GEARDETA_SEQ_GERACAO { get; set; }
        public string GEARDETA_DTH_ANO_REFERENCIA { get; set; }
        public string GEARDETA_DTH_MES_REFERENCIA { get; set; }
        public string GEARDETA_IND_MEIO_ENVIO { get; set; }
        public string GEARDETA_STA_ENVIO_RECEPCAO { get; set; }
        public string GEARDETA_COD_TIPO_ARQUIVO { get; set; }
        public string GEARDETA_QTD_REG_PROCESSADO { get; set; }
        public string GEARDETA_QTD_REG_REJEITADOS { get; set; }
        public string GEARDETA_QTD_REG_ACEITOS { get; set; }

        public static void Execute(M_0000_PRINCIPAL_DB_INSERT_1_Insert1 m_0000_PRINCIPAL_DB_INSERT_1_Insert1)
        {
            var ths = m_0000_PRINCIPAL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0000_PRINCIPAL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}