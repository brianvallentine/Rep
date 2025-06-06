using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0005S
{
    public class P8000_05_INICIO_DB_INSERT_1_Insert1 : QueryBasis<P8000_05_INICIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIST_PROP_FIDELIZ
            ( NUM_IDENTIFICACAO
            ,DATA_SITUACAO
            ,NSAS_SIVPF
            ,NSL
            ,SIT_PROPOSTA
            ,SIT_COBRANCA_SIVPF
            ,SIT_MOTIVO_SIVPF
            ,COD_EMPRESA_SIVPF
            ,COD_PRODUTO_SIVPF
            ,IND_TP_ACAO
            ,IND_TP_SENSIBILIZACAO
            ,IND_ENVIO
            ,DTA_INI_VIGENCIA
            ,DTA_FIM_VIGENCIA
            ,NUM_PARCELA
            ,COD_TP_LANCAMENTO
            ,VLR_PREMIO
            ,COD_ERRO
            ,COD_USUARIO
            ,NOM_PROGRAMA
            ,DTH_CADASTRAMENTO
            ,DTA_PROCESSAMENTO_CEF )
            VALUES
            ( :HISPROFI-NUM-IDENTIFICACAO
            ,:HISPROFI-DATA-SITUACAO
            ,:HISPROFI-NSAS-SIVPF
            ,:HISPROFI-NSL
            ,:HISPROFI-SIT-PROPOSTA
            ,:HISPROFI-SIT-COBRANCA-SIVPF
            :NU006-SIT-COBRANCA-SIVPF
            ,:HISPROFI-SIT-MOTIVO-SIVPF
            ,:HISPROFI-COD-EMPRESA-SIVPF
            ,:HISPROFI-COD-PRODUTO-SIVPF
            ,:HISPROFI-IND-TP-ACAO
            ,:HISPROFI-IND-TP-SENSIBILIZACAO
            ,:HISPROFI-IND-ENVIO
            ,:HISPROFI-DTA-INI-VIGENCIA:NU006-DTA-INI-VIGENCIA
            ,:HISPROFI-DTA-FIM-VIGENCIA:NU006-DTA-FIM-VIGENCIA
            ,:HISPROFI-NUM-PARCELA:NU006-NUM-PARCELA
            ,:HISPROFI-COD-TP-LANCAMENTO:NU006-COD-TP-LANCAMENTO
            ,:HISPROFI-VLR-PREMIO:NU006-VLR-PREMIO
            ,:HISPROFI-COD-ERRO:NU006-COD-ERRO
            ,:HISPROFI-COD-USUARIO
            ,:HISPROFI-NOM-PROGRAMA
            ,CURRENT_TIMESTAMP
            ,:HISPROFI-DTA-PROCESSAMENTO-CEF
            :NU006-DTA-PROCESSAMENTO-CEF )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_PROP_FIDELIZ ( NUM_IDENTIFICACAO ,DATA_SITUACAO ,NSAS_SIVPF ,NSL ,SIT_PROPOSTA ,SIT_COBRANCA_SIVPF ,SIT_MOTIVO_SIVPF ,COD_EMPRESA_SIVPF ,COD_PRODUTO_SIVPF ,IND_TP_ACAO ,IND_TP_SENSIBILIZACAO ,IND_ENVIO ,DTA_INI_VIGENCIA ,DTA_FIM_VIGENCIA ,NUM_PARCELA ,COD_TP_LANCAMENTO ,VLR_PREMIO ,COD_ERRO ,COD_USUARIO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ,DTA_PROCESSAMENTO_CEF ) VALUES ( {FieldThreatment(this.HISPROFI_NUM_IDENTIFICACAO)} ,{FieldThreatment(this.HISPROFI_DATA_SITUACAO)} ,{FieldThreatment(this.HISPROFI_NSAS_SIVPF)} ,{FieldThreatment(this.HISPROFI_NSL)} ,{FieldThreatment(this.HISPROFI_SIT_PROPOSTA)} , {FieldThreatment((this.NU006_SIT_COBRANCA_SIVPF?.ToInt() == -1 ? null : this.HISPROFI_SIT_COBRANCA_SIVPF))} ,{FieldThreatment(this.HISPROFI_SIT_MOTIVO_SIVPF)} ,{FieldThreatment(this.HISPROFI_COD_EMPRESA_SIVPF)} ,{FieldThreatment(this.HISPROFI_COD_PRODUTO_SIVPF)} ,{FieldThreatment(this.HISPROFI_IND_TP_ACAO)} ,{FieldThreatment(this.HISPROFI_IND_TP_SENSIBILIZACAO)} ,{FieldThreatment(this.HISPROFI_IND_ENVIO)} , {FieldThreatment((this.NU006_DTA_INI_VIGENCIA?.ToInt() == -1 ? null : this.HISPROFI_DTA_INI_VIGENCIA))} , {FieldThreatment((this.NU006_DTA_FIM_VIGENCIA?.ToInt() == -1 ? null : this.HISPROFI_DTA_FIM_VIGENCIA))} , {FieldThreatment((this.NU006_NUM_PARCELA?.ToInt() == -1 ? null : this.HISPROFI_NUM_PARCELA))} , {FieldThreatment((this.NU006_COD_TP_LANCAMENTO?.ToInt() == -1 ? null : this.HISPROFI_COD_TP_LANCAMENTO))} , {FieldThreatment((this.NU006_VLR_PREMIO?.ToInt() == -1 ? null : this.HISPROFI_VLR_PREMIO))} , {FieldThreatment((this.NU006_COD_ERRO?.ToInt() == -1 ? null : this.HISPROFI_COD_ERRO))} ,{FieldThreatment(this.HISPROFI_COD_USUARIO)} ,{FieldThreatment(this.HISPROFI_NOM_PROGRAMA)} ,CURRENT_TIMESTAMP , {FieldThreatment((this.NU006_DTA_PROCESSAMENTO_CEF?.ToInt() == -1 ? null : this.HISPROFI_DTA_PROCESSAMENTO_CEF))} )";

            return query;
        }
        public string HISPROFI_NUM_IDENTIFICACAO { get; set; }
        public string HISPROFI_DATA_SITUACAO { get; set; }
        public string HISPROFI_NSAS_SIVPF { get; set; }
        public string HISPROFI_NSL { get; set; }
        public string HISPROFI_SIT_PROPOSTA { get; set; }
        public string HISPROFI_SIT_COBRANCA_SIVPF { get; set; }
        public string NU006_SIT_COBRANCA_SIVPF { get; set; }
        public string HISPROFI_SIT_MOTIVO_SIVPF { get; set; }
        public string HISPROFI_COD_EMPRESA_SIVPF { get; set; }
        public string HISPROFI_COD_PRODUTO_SIVPF { get; set; }
        public string HISPROFI_IND_TP_ACAO { get; set; }
        public string HISPROFI_IND_TP_SENSIBILIZACAO { get; set; }
        public string HISPROFI_IND_ENVIO { get; set; }
        public string HISPROFI_DTA_INI_VIGENCIA { get; set; }
        public string NU006_DTA_INI_VIGENCIA { get; set; }
        public string HISPROFI_DTA_FIM_VIGENCIA { get; set; }
        public string NU006_DTA_FIM_VIGENCIA { get; set; }
        public string HISPROFI_NUM_PARCELA { get; set; }
        public string NU006_NUM_PARCELA { get; set; }
        public string HISPROFI_COD_TP_LANCAMENTO { get; set; }
        public string NU006_COD_TP_LANCAMENTO { get; set; }
        public string HISPROFI_VLR_PREMIO { get; set; }
        public string NU006_VLR_PREMIO { get; set; }
        public string HISPROFI_COD_ERRO { get; set; }
        public string NU006_COD_ERRO { get; set; }
        public string HISPROFI_COD_USUARIO { get; set; }
        public string HISPROFI_NOM_PROGRAMA { get; set; }
        public string HISPROFI_DTA_PROCESSAMENTO_CEF { get; set; }
        public string NU006_DTA_PROCESSAMENTO_CEF { get; set; }

        public static void Execute(P8000_05_INICIO_DB_INSERT_1_Insert1 p8000_05_INICIO_DB_INSERT_1_Insert1)
        {
            var ths = p8000_05_INICIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P8000_05_INICIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}