using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0125B
{
    public class R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 : QueryBasis<R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TERMO
            , COD_SUBGRUPO
            , DATA_ADESAO
            , COD_AGENCIA_OP
            , NUM_MATRICULA_VEN
            , CODPDTVEN
            , PCCOMVEN
            , PCADIANTVEN
            , COD_AGENCIA_VEN
            , OPERACAO_CONTA_VEN
            , NUM_CONTA_VEN
            , DIG_CONTA_VEN
            , NUM_MATRICULA_GER
            , CODPDTGER
            , PCCOMGER
            , COD_AGENCIA_GER
            , OPERACAO_CONTA_GER
            , NUM_CONTA_GER
            , DIG_CONTA_GER
            , NUM_MATRICULA_SUR
            , CODPDTSUR
            , PCCOMSUR
            , NUM_MATRICULA_GCO
            , CODPDTGCO
            , PCCOMGCO
            , MODALIDADE_CAPITAL
            , TIPO_PLANO
            , IND_PLANO_ASSOCIAD
            , COD_PLANO_VGAPC
            , COD_PLANO_APC
            , VAL_CONTRATADO
            , VAL_COMISSAO_ADIAN
            , QUANT_VIDAS
            , TIPO_COBERTURA
            , PERI_PAGAMENTO
            , TIPO_CORRECAO
            , PERIODO_CORRECAO
            , COD_MOEDA_IMP
            , COD_MOEDA_PRM
            , COD_CLIENTE
            , OCORR_ENDERECO
            , COD_CORRETOR
            , PCCOMCOR
            , COD_ADMINISTRADOR
            , PCCOMADM
            , COD_USUARIO
            , DATA_INCLUSAO
            , SITUACAO
            , NUM_PROPOSTA
            , NUM_RCAP
            , DATA_RCAP
            , VAL_RCAP
            , NUM_APOLICE
            INTO :TERMOADE-NUM-TERMO
            ,:TERMOADE-COD-SUBGRUPO
            ,:TERMOADE-DATA-ADESAO
            ,:TERMOADE-COD-AGENCIA-OP
            ,:TERMOADE-NUM-MATRICULA-VEN
            ,:TERMOADE-CODPDTVEN
            ,:TERMOADE-PCCOMVEN
            ,:TERMOADE-PCADIANTVEN
            ,:TERMOADE-COD-AGENCIA-VEN
            ,:TERMOADE-OPERACAO-CONTA-VEN
            ,:TERMOADE-NUM-CONTA-VEN
            ,:TERMOADE-DIG-CONTA-VEN
            ,:TERMOADE-NUM-MATRICULA-GER
            ,:TERMOADE-CODPDTGER
            ,:TERMOADE-PCCOMGER
            ,:TERMOADE-COD-AGENCIA-GER
            ,:TERMOADE-OPERACAO-CONTA-GER
            ,:TERMOADE-NUM-CONTA-GER
            ,:TERMOADE-DIG-CONTA-GER
            ,:TERMOADE-NUM-MATRICULA-SUR
            ,:TERMOADE-CODPDTSUR
            ,:TERMOADE-PCCOMSUR
            ,:TERMOADE-NUM-MATRICULA-GCO
            ,:TERMOADE-CODPDTGCO
            ,:TERMOADE-PCCOMGCO
            ,:TERMOADE-MODALIDADE-CAPITAL
            ,:TERMOADE-TIPO-PLANO
            ,:TERMOADE-IND-PLANO-ASSOCIAD
            ,:TERMOADE-COD-PLANO-VGAPC
            ,:TERMOADE-COD-PLANO-APC
            ,:TERMOADE-VAL-CONTRATADO
            ,:TERMOADE-VAL-COMISSAO-ADIAN
            ,:TERMOADE-QUANT-VIDAS
            ,:TERMOADE-TIPO-COBERTURA
            ,:TERMOADE-PERI-PAGAMENTO
            ,:TERMOADE-TIPO-CORRECAO
            ,:TERMOADE-PERIODO-CORRECAO
            ,:TERMOADE-COD-MOEDA-IMP
            ,:TERMOADE-COD-MOEDA-PRM
            ,:TERMOADE-COD-CLIENTE
            ,:TERMOADE-OCORR-ENDERECO
            ,:TERMOADE-COD-CORRETOR
            ,:TERMOADE-PCCOMCOR
            ,:TERMOADE-COD-ADMINISTRADOR
            ,:TERMOADE-PCCOMADM
            ,:TERMOADE-COD-USUARIO
            ,:TERMOADE-DATA-INCLUSAO
            ,:TERMOADE-SITUACAO
            ,:TERMOADE-NUM-PROPOSTA
            ,:TERMOADE-NUM-RCAP:VIND-RCAP
            ,:TERMOADE-DATA-RCAP:VIND-DATA-RCAP
            ,:TERMOADE-VAL-RCAP:VIND-VAL-RCAP
            ,:TERMOADE-NUM-APOLICE
            FROM SEGUROS.TERMO_ADESAO
            WHERE NUM_TERMO = :RELATORI-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TERMO
											, COD_SUBGRUPO
											, DATA_ADESAO
											, COD_AGENCIA_OP
											, NUM_MATRICULA_VEN
											, CODPDTVEN
											, PCCOMVEN
											, PCADIANTVEN
											, COD_AGENCIA_VEN
											, OPERACAO_CONTA_VEN
											, NUM_CONTA_VEN
											, DIG_CONTA_VEN
											, NUM_MATRICULA_GER
											, CODPDTGER
											, PCCOMGER
											, COD_AGENCIA_GER
											, OPERACAO_CONTA_GER
											, NUM_CONTA_GER
											, DIG_CONTA_GER
											, NUM_MATRICULA_SUR
											, CODPDTSUR
											, PCCOMSUR
											, NUM_MATRICULA_GCO
											, CODPDTGCO
											, PCCOMGCO
											, MODALIDADE_CAPITAL
											, TIPO_PLANO
											, IND_PLANO_ASSOCIAD
											, COD_PLANO_VGAPC
											, COD_PLANO_APC
											, VAL_CONTRATADO
											, VAL_COMISSAO_ADIAN
											, QUANT_VIDAS
											, TIPO_COBERTURA
											, PERI_PAGAMENTO
											, TIPO_CORRECAO
											, PERIODO_CORRECAO
											, COD_MOEDA_IMP
											, COD_MOEDA_PRM
											, COD_CLIENTE
											, OCORR_ENDERECO
											, COD_CORRETOR
											, PCCOMCOR
											, COD_ADMINISTRADOR
											, PCCOMADM
											, COD_USUARIO
											, DATA_INCLUSAO
											, SITUACAO
											, NUM_PROPOSTA
											, NUM_RCAP
											, DATA_RCAP
											, VAL_RCAP
											, NUM_APOLICE
											FROM SEGUROS.TERMO_ADESAO
											WHERE NUM_TERMO = '{this.RELATORI_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string TERMOADE_COD_SUBGRUPO { get; set; }
        public string TERMOADE_DATA_ADESAO { get; set; }
        public string TERMOADE_COD_AGENCIA_OP { get; set; }
        public string TERMOADE_NUM_MATRICULA_VEN { get; set; }
        public string TERMOADE_CODPDTVEN { get; set; }
        public string TERMOADE_PCCOMVEN { get; set; }
        public string TERMOADE_PCADIANTVEN { get; set; }
        public string TERMOADE_COD_AGENCIA_VEN { get; set; }
        public string TERMOADE_OPERACAO_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_CONTA_VEN { get; set; }
        public string TERMOADE_DIG_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_MATRICULA_GER { get; set; }
        public string TERMOADE_CODPDTGER { get; set; }
        public string TERMOADE_PCCOMGER { get; set; }
        public string TERMOADE_COD_AGENCIA_GER { get; set; }
        public string TERMOADE_OPERACAO_CONTA_GER { get; set; }
        public string TERMOADE_NUM_CONTA_GER { get; set; }
        public string TERMOADE_DIG_CONTA_GER { get; set; }
        public string TERMOADE_NUM_MATRICULA_SUR { get; set; }
        public string TERMOADE_CODPDTSUR { get; set; }
        public string TERMOADE_PCCOMSUR { get; set; }
        public string TERMOADE_NUM_MATRICULA_GCO { get; set; }
        public string TERMOADE_CODPDTGCO { get; set; }
        public string TERMOADE_PCCOMGCO { get; set; }
        public string TERMOADE_MODALIDADE_CAPITAL { get; set; }
        public string TERMOADE_TIPO_PLANO { get; set; }
        public string TERMOADE_IND_PLANO_ASSOCIAD { get; set; }
        public string TERMOADE_COD_PLANO_VGAPC { get; set; }
        public string TERMOADE_COD_PLANO_APC { get; set; }
        public string TERMOADE_VAL_CONTRATADO { get; set; }
        public string TERMOADE_VAL_COMISSAO_ADIAN { get; set; }
        public string TERMOADE_QUANT_VIDAS { get; set; }
        public string TERMOADE_TIPO_COBERTURA { get; set; }
        public string TERMOADE_PERI_PAGAMENTO { get; set; }
        public string TERMOADE_TIPO_CORRECAO { get; set; }
        public string TERMOADE_PERIODO_CORRECAO { get; set; }
        public string TERMOADE_COD_MOEDA_IMP { get; set; }
        public string TERMOADE_COD_MOEDA_PRM { get; set; }
        public string TERMOADE_COD_CLIENTE { get; set; }
        public string TERMOADE_OCORR_ENDERECO { get; set; }
        public string TERMOADE_COD_CORRETOR { get; set; }
        public string TERMOADE_PCCOMCOR { get; set; }
        public string TERMOADE_COD_ADMINISTRADOR { get; set; }
        public string TERMOADE_PCCOMADM { get; set; }
        public string TERMOADE_COD_USUARIO { get; set; }
        public string TERMOADE_DATA_INCLUSAO { get; set; }
        public string TERMOADE_SITUACAO { get; set; }
        public string TERMOADE_NUM_PROPOSTA { get; set; }
        public string TERMOADE_NUM_RCAP { get; set; }
        public string VIND_RCAP { get; set; }
        public string TERMOADE_DATA_RCAP { get; set; }
        public string VIND_DATA_RCAP { get; set; }
        public string TERMOADE_VAL_RCAP { get; set; }
        public string VIND_VAL_RCAP { get; set; }
        public string TERMOADE_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 Execute(R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 r0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1)
        {
            var ths = r0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.TERMOADE_NUM_TERMO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.TERMOADE_DATA_ADESAO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_OP = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_CODPDTVEN = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMVEN = result[i++].Value?.ToString();
            dta.TERMOADE_PCADIANTVEN = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_OPERACAO_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_DIG_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_CODPDTGER = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMGER = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_OPERACAO_CONTA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_CONTA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_DIG_CONTA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_SUR = result[i++].Value?.ToString();
            dta.TERMOADE_CODPDTSUR = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMSUR = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_GCO = result[i++].Value?.ToString();
            dta.TERMOADE_CODPDTGCO = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMGCO = result[i++].Value?.ToString();
            dta.TERMOADE_MODALIDADE_CAPITAL = result[i++].Value?.ToString();
            dta.TERMOADE_TIPO_PLANO = result[i++].Value?.ToString();
            dta.TERMOADE_IND_PLANO_ASSOCIAD = result[i++].Value?.ToString();
            dta.TERMOADE_COD_PLANO_VGAPC = result[i++].Value?.ToString();
            dta.TERMOADE_COD_PLANO_APC = result[i++].Value?.ToString();
            dta.TERMOADE_VAL_CONTRATADO = result[i++].Value?.ToString();
            dta.TERMOADE_VAL_COMISSAO_ADIAN = result[i++].Value?.ToString();
            dta.TERMOADE_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.TERMOADE_TIPO_COBERTURA = result[i++].Value?.ToString();
            dta.TERMOADE_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.TERMOADE_TIPO_CORRECAO = result[i++].Value?.ToString();
            dta.TERMOADE_PERIODO_CORRECAO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.TERMOADE_COD_MOEDA_PRM = result[i++].Value?.ToString();
            dta.TERMOADE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.TERMOADE_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_CORRETOR = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMCOR = result[i++].Value?.ToString();
            dta.TERMOADE_COD_ADMINISTRADOR = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMADM = result[i++].Value?.ToString();
            dta.TERMOADE_COD_USUARIO = result[i++].Value?.ToString();
            dta.TERMOADE_DATA_INCLUSAO = result[i++].Value?.ToString();
            dta.TERMOADE_SITUACAO = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_RCAP = result[i++].Value?.ToString();
            dta.VIND_RCAP = string.IsNullOrWhiteSpace(dta.TERMOADE_NUM_RCAP) ? "-1" : "0";
            dta.TERMOADE_DATA_RCAP = result[i++].Value?.ToString();
            dta.VIND_DATA_RCAP = string.IsNullOrWhiteSpace(dta.TERMOADE_DATA_RCAP) ? "-1" : "0";
            dta.TERMOADE_VAL_RCAP = result[i++].Value?.ToString();
            dta.VIND_VAL_RCAP = string.IsNullOrWhiteSpace(dta.TERMOADE_VAL_RCAP) ? "-1" : "0";
            dta.TERMOADE_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}