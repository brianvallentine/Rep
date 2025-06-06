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
    public class P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1 : QueryBasis<P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CHEQUES_EMITIDOS
            ( TIPO_MOVIMENTO
            ,COD_FONTE
            ,NUM_DOCUMENTO
            ,NOME_FAVORECIDO
            ,VAL_CHEQUE
            ,DATA_MOVIMENTO
            ,DATA_EMISSAO
            ,NUM_CHEQUE_INTERNO
            ,DIG_CHEQUE_INTERNO
            ,SIT_REGISTRO
            ,TIPO_PAGAMENTO
            ,DATA_COMPETENCIA
            ,PRACA_PAGAMENTO
            ,NUM_RECIBO
            ,OCORR_HISTORICO
            ,COD_OPERACAO
            ,COD_DESPESA
            ,VAL_IRF
            ,VAL_ISS
            ,VAL_IAPAS
            ,COD_LANCAMENTO
            ,DATA_LANCAMENTO
            ,COD_EMPRESA
            ,TIMESTAMP
            ,COD_FAVORECIDO
            ,VAL_INSS
            )
            VALUES
            (:CHEQUEMI-TIPO-MOVIMENTO
            ,:CHEQUEMI-COD-FONTE
            ,:CHEQUEMI-NUM-DOCUMENTO
            ,:CHEQUEMI-NOME-FAVORECIDO
            ,:CHEQUEMI-VAL-CHEQUE
            ,:CHEQUEMI-DATA-MOVIMENTO
            ,:CHEQUEMI-DATA-EMISSAO:VIND-DTEMIS
            ,:CHEQUEMI-NUM-CHEQUE-INTERNO
            ,:CHEQUEMI-DIG-CHEQUE-INTERNO
            ,:CHEQUEMI-SIT-REGISTRO
            ,:CHEQUEMI-TIPO-PAGAMENTO
            ,:CHEQUEMI-DATA-COMPETENCIA
            ,:CHEQUEMI-PRACA-PAGAMENTO
            ,:CHEQUEMI-NUM-RECIBO
            ,:CHEQUEMI-OCORR-HISTORICO
            ,:CHEQUEMI-COD-OPERACAO
            ,:CHEQUEMI-COD-DESPESA
            ,:CHEQUEMI-VAL-IRF
            ,:CHEQUEMI-VAL-ISS
            ,:CHEQUEMI-VAL-IAPAS
            ,:CHEQUEMI-COD-LANCAMENTO
            ,:CHEQUEMI-DATA-LANCAMENTO
            ,:CHEQUEMI-COD-EMPRESA:VIND-CODEMP
            , CURRENT TIMESTAMP
            ,:CHEQUEMI-COD-FAVORECIDO:VIND-CODFAV
            ,:CHEQUEMI-VAL-INSS:VIND-VLINSS
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CHEQUES_EMITIDOS ( TIPO_MOVIMENTO ,COD_FONTE ,NUM_DOCUMENTO ,NOME_FAVORECIDO ,VAL_CHEQUE ,DATA_MOVIMENTO ,DATA_EMISSAO ,NUM_CHEQUE_INTERNO ,DIG_CHEQUE_INTERNO ,SIT_REGISTRO ,TIPO_PAGAMENTO ,DATA_COMPETENCIA ,PRACA_PAGAMENTO ,NUM_RECIBO ,OCORR_HISTORICO ,COD_OPERACAO ,COD_DESPESA ,VAL_IRF ,VAL_ISS ,VAL_IAPAS ,COD_LANCAMENTO ,DATA_LANCAMENTO ,COD_EMPRESA ,TIMESTAMP ,COD_FAVORECIDO ,VAL_INSS ) VALUES ({FieldThreatment(this.CHEQUEMI_TIPO_MOVIMENTO)} ,{FieldThreatment(this.CHEQUEMI_COD_FONTE)} ,{FieldThreatment(this.CHEQUEMI_NUM_DOCUMENTO)} ,{FieldThreatment(this.CHEQUEMI_NOME_FAVORECIDO)} ,{FieldThreatment(this.CHEQUEMI_VAL_CHEQUE)} ,{FieldThreatment(this.CHEQUEMI_DATA_MOVIMENTO)} , {FieldThreatment((this.VIND_DTEMIS?.ToInt() == -1 ? null : this.CHEQUEMI_DATA_EMISSAO))} ,{FieldThreatment(this.CHEQUEMI_NUM_CHEQUE_INTERNO)} ,{FieldThreatment(this.CHEQUEMI_DIG_CHEQUE_INTERNO)} ,{FieldThreatment(this.CHEQUEMI_SIT_REGISTRO)} ,{FieldThreatment(this.CHEQUEMI_TIPO_PAGAMENTO)} ,{FieldThreatment(this.CHEQUEMI_DATA_COMPETENCIA)} ,{FieldThreatment(this.CHEQUEMI_PRACA_PAGAMENTO)} ,{FieldThreatment(this.CHEQUEMI_NUM_RECIBO)} ,{FieldThreatment(this.CHEQUEMI_OCORR_HISTORICO)} ,{FieldThreatment(this.CHEQUEMI_COD_OPERACAO)} ,{FieldThreatment(this.CHEQUEMI_COD_DESPESA)} ,{FieldThreatment(this.CHEQUEMI_VAL_IRF)} ,{FieldThreatment(this.CHEQUEMI_VAL_ISS)} ,{FieldThreatment(this.CHEQUEMI_VAL_IAPAS)} ,{FieldThreatment(this.CHEQUEMI_COD_LANCAMENTO)} ,{FieldThreatment(this.CHEQUEMI_DATA_LANCAMENTO)} , {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.CHEQUEMI_COD_EMPRESA))} , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_CODFAV?.ToInt() == -1 ? null : this.CHEQUEMI_COD_FAVORECIDO))} , {FieldThreatment((this.VIND_VLINSS?.ToInt() == -1 ? null : this.CHEQUEMI_VAL_INSS))} )";

            return query;
        }
        public string CHEQUEMI_TIPO_MOVIMENTO { get; set; }
        public string CHEQUEMI_COD_FONTE { get; set; }
        public string CHEQUEMI_NUM_DOCUMENTO { get; set; }
        public string CHEQUEMI_NOME_FAVORECIDO { get; set; }
        public string CHEQUEMI_VAL_CHEQUE { get; set; }
        public string CHEQUEMI_DATA_MOVIMENTO { get; set; }
        public string CHEQUEMI_DATA_EMISSAO { get; set; }
        public string VIND_DTEMIS { get; set; }
        public string CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; }
        public string CHEQUEMI_DIG_CHEQUE_INTERNO { get; set; }
        public string CHEQUEMI_SIT_REGISTRO { get; set; }
        public string CHEQUEMI_TIPO_PAGAMENTO { get; set; }
        public string CHEQUEMI_DATA_COMPETENCIA { get; set; }
        public string CHEQUEMI_PRACA_PAGAMENTO { get; set; }
        public string CHEQUEMI_NUM_RECIBO { get; set; }
        public string CHEQUEMI_OCORR_HISTORICO { get; set; }
        public string CHEQUEMI_COD_OPERACAO { get; set; }
        public string CHEQUEMI_COD_DESPESA { get; set; }
        public string CHEQUEMI_VAL_IRF { get; set; }
        public string CHEQUEMI_VAL_ISS { get; set; }
        public string CHEQUEMI_VAL_IAPAS { get; set; }
        public string CHEQUEMI_COD_LANCAMENTO { get; set; }
        public string CHEQUEMI_DATA_LANCAMENTO { get; set; }
        public string CHEQUEMI_COD_EMPRESA { get; set; }
        public string VIND_CODEMP { get; set; }
        public string CHEQUEMI_COD_FAVORECIDO { get; set; }
        public string VIND_CODFAV { get; set; }
        public string CHEQUEMI_VAL_INSS { get; set; }
        public string VIND_VLINSS { get; set; }

        public static void Execute(P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1 p22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1)
        {
            var ths = p22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}