using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6248B
{
    public class R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.BILHETE
            (NUM_BILHETE ,
            NUM_APOLICE ,
            FONTE ,
            AGE_COBRANCA ,
            NUM_MATRICULA ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            COD_CLIENTE ,
            PROFISSAO ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            OCORR_ENDERECO ,
            COD_AGENCIA_DEB ,
            OPERACAO_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            OPC_COBERTURA ,
            DATA_QUITACAO ,
            VAL_RCAP ,
            RAMO ,
            DATA_VENDA ,
            DATA_MOVIMENTO ,
            NUM_APOL_ANTERIOR ,
            SITUACAO ,
            TIP_CANCELAMENTO ,
            SIT_SINISTRO ,
            COD_USUARIO ,
            TIMESTAMP ,
            DATA_CANCELAMENTO ,
            BI_FAIXA_RENDA_IND ,
            BI_FAIXA_RENDA_FAM)
            VALUES
            (:BILHETE-NUM-BILHETE ,
            :BILHETE-NUM-APOLICE ,
            :BILHETE-FONTE ,
            :BILHETE-AGE-COBRANCA ,
            :BILHETE-NUM-MATRICULA ,
            :BILHETE-COD-AGENCIA ,
            :BILHETE-OPERACAO-CONTA ,
            :BILHETE-NUM-CONTA ,
            :BILHETE-DIG-CONTA ,
            :BILHETE-COD-CLIENTE ,
            :BILHETE-PROFISSAO ,
            :BILHETE-IDE-SEXO ,
            :BILHETE-ESTADO-CIVIL ,
            :BILHETE-OCORR-ENDERECO ,
            :BILHETE-COD-AGENCIA-DEB ,
            :BILHETE-OPERACAO-CONTA-DEB ,
            :BILHETE-NUM-CONTA-DEB ,
            :BILHETE-DIG-CONTA-DEB ,
            :BILHETE-OPC-COBERTURA ,
            :BILHETE-DATA-QUITACAO ,
            :BILHETE-VAL-RCAP ,
            :BILHETE-RAMO ,
            :BILHETE-DATA-VENDA ,
            :BILHETE-DATA-MOVIMENTO ,
            :BILHETE-NUM-APOL-ANTERIOR ,
            :BILHETE-SITUACAO ,
            :BILHETE-TIP-CANCELAMENTO ,
            :BILHETE-SIT-SINISTRO ,
            :BILHETE-COD-USUARIO ,
            :BILHETE-TIMESTAMP ,
            :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 ,
            :BILHETE-BI-FAIXA-RENDA-IND ,
            :BILHETE-BI-FAIXA-RENDA-FAM)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.BILHETE (NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND , BI_FAIXA_RENDA_FAM) VALUES ({FieldThreatment(this.BILHETE_NUM_BILHETE)} , {FieldThreatment(this.BILHETE_NUM_APOLICE)} , {FieldThreatment(this.BILHETE_FONTE)} , {FieldThreatment(this.BILHETE_AGE_COBRANCA)} , {FieldThreatment(this.BILHETE_NUM_MATRICULA)} , {FieldThreatment(this.BILHETE_COD_AGENCIA)} , {FieldThreatment(this.BILHETE_OPERACAO_CONTA)} , {FieldThreatment(this.BILHETE_NUM_CONTA)} , {FieldThreatment(this.BILHETE_DIG_CONTA)} , {FieldThreatment(this.BILHETE_COD_CLIENTE)} , {FieldThreatment(this.BILHETE_PROFISSAO)} , {FieldThreatment(this.BILHETE_IDE_SEXO)} , {FieldThreatment(this.BILHETE_ESTADO_CIVIL)} , {FieldThreatment(this.BILHETE_OCORR_ENDERECO)} , {FieldThreatment(this.BILHETE_COD_AGENCIA_DEB)} , {FieldThreatment(this.BILHETE_OPERACAO_CONTA_DEB)} , {FieldThreatment(this.BILHETE_NUM_CONTA_DEB)} , {FieldThreatment(this.BILHETE_DIG_CONTA_DEB)} , {FieldThreatment(this.BILHETE_OPC_COBERTURA)} , {FieldThreatment(this.BILHETE_DATA_QUITACAO)} , {FieldThreatment(this.BILHETE_VAL_RCAP)} , {FieldThreatment(this.BILHETE_RAMO)} , {FieldThreatment(this.BILHETE_DATA_VENDA)} , {FieldThreatment(this.BILHETE_DATA_MOVIMENTO)} , {FieldThreatment(this.BILHETE_NUM_APOL_ANTERIOR)} , {FieldThreatment(this.BILHETE_SITUACAO)} , {FieldThreatment(this.BILHETE_TIP_CANCELAMENTO)} , {FieldThreatment(this.BILHETE_SIT_SINISTRO)} , {FieldThreatment(this.BILHETE_COD_USUARIO)} , {FieldThreatment(this.BILHETE_TIMESTAMP)} ,  {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : this.BILHETE_DATA_CANCELAMENTO))} , {FieldThreatment(this.BILHETE_BI_FAIXA_RENDA_IND)} , {FieldThreatment(this.BILHETE_BI_FAIXA_RENDA_FAM)})";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_FONTE { get; set; }
        public string BILHETE_AGE_COBRANCA { get; set; }
        public string BILHETE_NUM_MATRICULA { get; set; }
        public string BILHETE_COD_AGENCIA { get; set; }
        public string BILHETE_OPERACAO_CONTA { get; set; }
        public string BILHETE_NUM_CONTA { get; set; }
        public string BILHETE_DIG_CONTA { get; set; }
        public string BILHETE_COD_CLIENTE { get; set; }
        public string BILHETE_PROFISSAO { get; set; }
        public string BILHETE_IDE_SEXO { get; set; }
        public string BILHETE_ESTADO_CIVIL { get; set; }
        public string BILHETE_OCORR_ENDERECO { get; set; }
        public string BILHETE_COD_AGENCIA_DEB { get; set; }
        public string BILHETE_OPERACAO_CONTA_DEB { get; set; }
        public string BILHETE_NUM_CONTA_DEB { get; set; }
        public string BILHETE_DIG_CONTA_DEB { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_VAL_RCAP { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_DATA_VENDA { get; set; }
        public string BILHETE_DATA_MOVIMENTO { get; set; }
        public string BILHETE_NUM_APOL_ANTERIOR { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string BILHETE_TIP_CANCELAMENTO { get; set; }
        public string BILHETE_SIT_SINISTRO { get; set; }
        public string BILHETE_COD_USUARIO { get; set; }
        public string BILHETE_TIMESTAMP { get; set; }
        public string BILHETE_DATA_CANCELAMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string BILHETE_BI_FAIXA_RENDA_IND { get; set; }
        public string BILHETE_BI_FAIXA_RENDA_FAM { get; set; }

        public static void Execute(R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1 r1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}