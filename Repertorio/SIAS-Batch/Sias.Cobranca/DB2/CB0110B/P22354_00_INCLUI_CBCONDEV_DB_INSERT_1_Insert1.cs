using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1 : QueryBasis<P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CB_CONTR_DEVPREMIO
            ( COD_EMPRESA
            ,TIPO_MOVIMENTO
            ,NUM_CHEQUE_INTERNO
            ,DIG_CHEQUE_INTERNO
            ,DATA_MOVIMENTO
            ,NUM_SEQUENCIA
            ,NUM_TITULO
            ,COD_FONTE
            ,NUM_RCAP
            ,NUM_RCAP_COMPLEMEN
            ,NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,COD_SUBGRUPO
            ,NUM_CERTIFICADO
            ,DATA_OCORRENCIA
            ,HORA_OPERACAO
            ,NUM_MATRICULA
            ,RAMO_EMISSOR
            ,COD_PRODUTO
            ,COD_FILIAL
            ,COD_ESCNEG
            ,AGE_COBRANCA
            ,TIPO_FAVORECIDO
            ,COD_FAVORECIDO
            ,COD_ENDERECO
            ,OCORR_ENDERECO
            ,COD_AGENCIA
            ,OPERACAO_CONTA
            ,NUM_CONTA
            ,DIG_CONTA
            ,SIT_REGISTRO
            ,DATA_QUITACAO
            ,VAL_TITULO
            ,VAL_DESCONTO
            ,VAL_OPERACAO
            ,COD_DESPESA
            ,COD_DEVOLUCAO
            ,COD_SISTEMA
            ,COD_USU_SOLICITA
            ,TIMESTAMP
            ,DATA_CANCELAMENTO
            ,COD_USU_CANCELA
            )
            VALUES
            (:CBCONDEV-COD-EMPRESA
            ,:CBCONDEV-TIPO-MOVIMENTO
            ,:CBCONDEV-NUM-CHEQUE-INTERNO
            ,:CBCONDEV-DIG-CHEQUE-INTERNO
            ,:CBCONDEV-DATA-MOVIMENTO
            ,:CBCONDEV-NUM-SEQUENCIA
            ,:CBCONDEV-NUM-TITULO
            ,:CBCONDEV-COD-FONTE
            ,:CBCONDEV-NUM-RCAP
            ,:CBCONDEV-NUM-RCAP-COMPLEMEN
            ,:CBCONDEV-NUM-APOLICE
            ,:CBCONDEV-NUM-ENDOSSO
            ,:CBCONDEV-NUM-PARCELA
            ,:CBCONDEV-COD-SUBGRUPO
            ,:CBCONDEV-NUM-CERTIFICADO
            ,:CBCONDEV-DATA-OCORRENCIA
            ,:CBCONDEV-HORA-OPERACAO
            ,:CBCONDEV-NUM-MATRICULA
            ,:CBCONDEV-RAMO-EMISSOR
            ,:CBCONDEV-COD-PRODUTO
            ,:CBCONDEV-COD-FILIAL
            ,:CBCONDEV-COD-ESCNEG
            ,:CBCONDEV-AGE-COBRANCA
            ,:CBCONDEV-TIPO-FAVORECIDO
            ,:CBCONDEV-COD-FAVORECIDO
            ,:CBCONDEV-COD-ENDERECO
            ,:CBCONDEV-OCORR-ENDERECO
            ,:CBCONDEV-COD-AGENCIA
            ,:CBCONDEV-OPERACAO-CONTA
            ,:CBCONDEV-NUM-CONTA
            ,:CBCONDEV-DIG-CONTA
            ,:CBCONDEV-SIT-REGISTRO
            ,:CBCONDEV-DATA-QUITACAO
            ,:CBCONDEV-VAL-TITULO
            ,:CBCONDEV-VAL-DESCONTO
            ,:CBCONDEV-VAL-OPERACAO
            ,:CBCONDEV-COD-DESPESA
            ,:CBCONDEV-COD-DEVOLUCAO
            ,:CBCONDEV-COD-SISTEMA
            ,:CBCONDEV-COD-USU-SOLICITA
            , CURRENT TIMESTAMP
            ,:CBCONDEV-DATA-CANCELAMENTO:VIND-DTCANCEL
            ,:CBCONDEV-COD-USU-CANCELA:VIND-CODUSU
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CB_CONTR_DEVPREMIO ( COD_EMPRESA ,TIPO_MOVIMENTO ,NUM_CHEQUE_INTERNO ,DIG_CHEQUE_INTERNO ,DATA_MOVIMENTO ,NUM_SEQUENCIA ,NUM_TITULO ,COD_FONTE ,NUM_RCAP ,NUM_RCAP_COMPLEMEN ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,COD_SUBGRUPO ,NUM_CERTIFICADO ,DATA_OCORRENCIA ,HORA_OPERACAO ,NUM_MATRICULA ,RAMO_EMISSOR ,COD_PRODUTO ,COD_FILIAL ,COD_ESCNEG ,AGE_COBRANCA ,TIPO_FAVORECIDO ,COD_FAVORECIDO ,COD_ENDERECO ,OCORR_ENDERECO ,COD_AGENCIA ,OPERACAO_CONTA ,NUM_CONTA ,DIG_CONTA ,SIT_REGISTRO ,DATA_QUITACAO ,VAL_TITULO ,VAL_DESCONTO ,VAL_OPERACAO ,COD_DESPESA ,COD_DEVOLUCAO ,COD_SISTEMA ,COD_USU_SOLICITA ,TIMESTAMP ,DATA_CANCELAMENTO ,COD_USU_CANCELA ) VALUES ({FieldThreatment(this.CBCONDEV_COD_EMPRESA)} ,{FieldThreatment(this.CBCONDEV_TIPO_MOVIMENTO)} ,{FieldThreatment(this.CBCONDEV_NUM_CHEQUE_INTERNO)} ,{FieldThreatment(this.CBCONDEV_DIG_CHEQUE_INTERNO)} ,{FieldThreatment(this.CBCONDEV_DATA_MOVIMENTO)} ,{FieldThreatment(this.CBCONDEV_NUM_SEQUENCIA)} ,{FieldThreatment(this.CBCONDEV_NUM_TITULO)} ,{FieldThreatment(this.CBCONDEV_COD_FONTE)} ,{FieldThreatment(this.CBCONDEV_NUM_RCAP)} ,{FieldThreatment(this.CBCONDEV_NUM_RCAP_COMPLEMEN)} ,{FieldThreatment(this.CBCONDEV_NUM_APOLICE)} ,{FieldThreatment(this.CBCONDEV_NUM_ENDOSSO)} ,{FieldThreatment(this.CBCONDEV_NUM_PARCELA)} ,{FieldThreatment(this.CBCONDEV_COD_SUBGRUPO)} ,{FieldThreatment(this.CBCONDEV_NUM_CERTIFICADO)} ,{FieldThreatment(this.CBCONDEV_DATA_OCORRENCIA)} ,{FieldThreatment(this.CBCONDEV_HORA_OPERACAO)} ,{FieldThreatment(this.CBCONDEV_NUM_MATRICULA)} ,{FieldThreatment(this.CBCONDEV_RAMO_EMISSOR)} ,{FieldThreatment(this.CBCONDEV_COD_PRODUTO)} ,{FieldThreatment(this.CBCONDEV_COD_FILIAL)} ,{FieldThreatment(this.CBCONDEV_COD_ESCNEG)} ,{FieldThreatment(this.CBCONDEV_AGE_COBRANCA)} ,{FieldThreatment(this.CBCONDEV_TIPO_FAVORECIDO)} ,{FieldThreatment(this.CBCONDEV_COD_FAVORECIDO)} ,{FieldThreatment(this.CBCONDEV_COD_ENDERECO)} ,{FieldThreatment(this.CBCONDEV_OCORR_ENDERECO)} ,{FieldThreatment(this.CBCONDEV_COD_AGENCIA)} ,{FieldThreatment(this.CBCONDEV_OPERACAO_CONTA)} ,{FieldThreatment(this.CBCONDEV_NUM_CONTA)} ,{FieldThreatment(this.CBCONDEV_DIG_CONTA)} ,{FieldThreatment(this.CBCONDEV_SIT_REGISTRO)} ,{FieldThreatment(this.CBCONDEV_DATA_QUITACAO)} ,{FieldThreatment(this.CBCONDEV_VAL_TITULO)} ,{FieldThreatment(this.CBCONDEV_VAL_DESCONTO)} ,{FieldThreatment(this.CBCONDEV_VAL_OPERACAO)} ,{FieldThreatment(this.CBCONDEV_COD_DESPESA)} ,{FieldThreatment(this.CBCONDEV_COD_DEVOLUCAO)} ,{FieldThreatment(this.CBCONDEV_COD_SISTEMA)} ,{FieldThreatment(this.CBCONDEV_COD_USU_SOLICITA)} , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_DTCANCEL?.ToInt() == -1 ? null : this.CBCONDEV_DATA_CANCELAMENTO))} , {FieldThreatment((this.VIND_CODUSU?.ToInt() == -1 ? null : this.CBCONDEV_COD_USU_CANCELA))} )";

            return query;
        }
        public string CBCONDEV_COD_EMPRESA { get; set; }
        public string CBCONDEV_TIPO_MOVIMENTO { get; set; }
        public string CBCONDEV_NUM_CHEQUE_INTERNO { get; set; }
        public string CBCONDEV_DIG_CHEQUE_INTERNO { get; set; }
        public string CBCONDEV_DATA_MOVIMENTO { get; set; }
        public string CBCONDEV_NUM_SEQUENCIA { get; set; }
        public string CBCONDEV_NUM_TITULO { get; set; }
        public string CBCONDEV_COD_FONTE { get; set; }
        public string CBCONDEV_NUM_RCAP { get; set; }
        public string CBCONDEV_NUM_RCAP_COMPLEMEN { get; set; }
        public string CBCONDEV_NUM_APOLICE { get; set; }
        public string CBCONDEV_NUM_ENDOSSO { get; set; }
        public string CBCONDEV_NUM_PARCELA { get; set; }
        public string CBCONDEV_COD_SUBGRUPO { get; set; }
        public string CBCONDEV_NUM_CERTIFICADO { get; set; }
        public string CBCONDEV_DATA_OCORRENCIA { get; set; }
        public string CBCONDEV_HORA_OPERACAO { get; set; }
        public string CBCONDEV_NUM_MATRICULA { get; set; }
        public string CBCONDEV_RAMO_EMISSOR { get; set; }
        public string CBCONDEV_COD_PRODUTO { get; set; }
        public string CBCONDEV_COD_FILIAL { get; set; }
        public string CBCONDEV_COD_ESCNEG { get; set; }
        public string CBCONDEV_AGE_COBRANCA { get; set; }
        public string CBCONDEV_TIPO_FAVORECIDO { get; set; }
        public string CBCONDEV_COD_FAVORECIDO { get; set; }
        public string CBCONDEV_COD_ENDERECO { get; set; }
        public string CBCONDEV_OCORR_ENDERECO { get; set; }
        public string CBCONDEV_COD_AGENCIA { get; set; }
        public string CBCONDEV_OPERACAO_CONTA { get; set; }
        public string CBCONDEV_NUM_CONTA { get; set; }
        public string CBCONDEV_DIG_CONTA { get; set; }
        public string CBCONDEV_SIT_REGISTRO { get; set; }
        public string CBCONDEV_DATA_QUITACAO { get; set; }
        public string CBCONDEV_VAL_TITULO { get; set; }
        public string CBCONDEV_VAL_DESCONTO { get; set; }
        public string CBCONDEV_VAL_OPERACAO { get; set; }
        public string CBCONDEV_COD_DESPESA { get; set; }
        public string CBCONDEV_COD_DEVOLUCAO { get; set; }
        public string CBCONDEV_COD_SISTEMA { get; set; }
        public string CBCONDEV_COD_USU_SOLICITA { get; set; }
        public string CBCONDEV_DATA_CANCELAMENTO { get; set; }
        public string VIND_DTCANCEL { get; set; }
        public string CBCONDEV_COD_USU_CANCELA { get; set; }
        public string VIND_CODUSU { get; set; }

        public static void Execute(P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1 p22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1)
        {
            var ths = p22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}