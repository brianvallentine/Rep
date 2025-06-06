using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE,
            A.NUM_TERMO,
            A.COD_SUBGRUPO,
            A.DATA_ADESAO,
            A.COD_AGENCIA_OP,
            A.MODALIDADE_CAPITAL,
            A.TIPO_PLANO,
            A.COD_PLANO_VGAPC,
            A.COD_PLANO_APC,
            A.VAL_CONTRATADO,
            A.VAL_RCAP,
            A.QUANT_VIDAS,
            A.TIPO_COBERTURA,
            A.PERI_PAGAMENTO,
            A.COD_CLIENTE,
            B.NUM_PROPOSTA_SIVPF,
            B.DTH_DIA_DEBITO,
            B.COD_AGENCIA_DEB,
            B.OPERACAO_CONTA_DEB,
            B.NUM_CONTA_DEBITO,
            B.DIG_CONTA_DEBITO,
            B.NUM_CARTAO_CREDITO,
            C.OCORR_ENDERECO
            INTO :DCLTERMO-ADESAO.TERMOADE-NUM-APOLICE,
            :DCLTERMO-ADESAO.TERMOADE-NUM-TERMO,
            :DCLTERMO-ADESAO.TERMOADE-COD-SUBGRUPO,
            :DCLTERMO-ADESAO.TERMOADE-DATA-ADESAO,
            :DCLTERMO-ADESAO.TERMOADE-COD-AGENCIA-OP,
            :DCLTERMO-ADESAO.TERMOADE-MODALIDADE-CAPITAL,
            :DCLTERMO-ADESAO.TERMOADE-TIPO-PLANO,
            :DCLTERMO-ADESAO.TERMOADE-COD-PLANO-VGAPC,
            :DCLTERMO-ADESAO.TERMOADE-COD-PLANO-APC,
            :DCLTERMO-ADESAO.TERMOADE-VAL-CONTRATADO,
            :DCLTERMO-ADESAO.TERMOADE-VAL-RCAP:VIND-VLRCAP,
            :DCLTERMO-ADESAO.TERMOADE-QUANT-VIDAS,
            :DCLTERMO-ADESAO.TERMOADE-TIPO-COBERTURA,
            :DCLTERMO-ADESAO.TERMOADE-PERI-PAGAMENTO,
            :DCLTERMO-ADESAO.TERMOADE-COD-CLIENTE,
            :VGCOMTRO-NUM-PROPOSTA-SIVPF,
            :VGCOMTRO-DTH-DIA-DEBITO,
            :VGCOMTRO-COD-AGENCIA-DEB,
            :VGCOMTRO-OPERACAO-CONTA-DEB,
            :VGCOMTRO-NUM-CONTA-DEBITO,
            :VGCOMTRO-DIG-CONTA-DEBITO,
            :VGCOMTRO-NUM-CARTAO-CREDITO,
            :SUBGVGAP-OCORR-ENDERECO
            FROM SEGUROS.TERMO_ADESAO A,
            SEGUROS.VG_COMPL_TERMO B,
            SEGUROS.SUBGRUPOS_VGAP C
            WHERE A.NUM_TERMO =
            :DCLRELATORIOS.RELATORI-NUM-TITULO
            AND A.NUM_TERMO = B.NUM_TERMO
            AND A.NUM_APOLICE = C.NUM_APOLICE
            AND A.COD_SUBGRUPO = C.COD_SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE
							,
											A.NUM_TERMO
							,
											A.COD_SUBGRUPO
							,
											A.DATA_ADESAO
							,
											A.COD_AGENCIA_OP
							,
											A.MODALIDADE_CAPITAL
							,
											A.TIPO_PLANO
							,
											A.COD_PLANO_VGAPC
							,
											A.COD_PLANO_APC
							,
											A.VAL_CONTRATADO
							,
											A.VAL_RCAP
							,
											A.QUANT_VIDAS
							,
											A.TIPO_COBERTURA
							,
											A.PERI_PAGAMENTO
							,
											A.COD_CLIENTE
							,
											B.NUM_PROPOSTA_SIVPF
							,
											B.DTH_DIA_DEBITO
							,
											B.COD_AGENCIA_DEB
							,
											B.OPERACAO_CONTA_DEB
							,
											B.NUM_CONTA_DEBITO
							,
											B.DIG_CONTA_DEBITO
							,
											B.NUM_CARTAO_CREDITO
							,
											C.OCORR_ENDERECO
											FROM SEGUROS.TERMO_ADESAO A
							,
											SEGUROS.VG_COMPL_TERMO B
							,
											SEGUROS.SUBGRUPOS_VGAP C
											WHERE A.NUM_TERMO =
											'{this.RELATORI_NUM_TITULO}'
											AND A.NUM_TERMO = B.NUM_TERMO
											AND A.NUM_APOLICE = C.NUM_APOLICE
											AND A.COD_SUBGRUPO = C.COD_SUBGRUPO";

            return query;
        }
        public string TERMOADE_NUM_APOLICE { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string TERMOADE_COD_SUBGRUPO { get; set; }
        public string TERMOADE_DATA_ADESAO { get; set; }
        public string TERMOADE_COD_AGENCIA_OP { get; set; }
        public string TERMOADE_MODALIDADE_CAPITAL { get; set; }
        public string TERMOADE_TIPO_PLANO { get; set; }
        public string TERMOADE_COD_PLANO_VGAPC { get; set; }
        public string TERMOADE_COD_PLANO_APC { get; set; }
        public string TERMOADE_VAL_CONTRATADO { get; set; }
        public string TERMOADE_VAL_RCAP { get; set; }
        public string VIND_VLRCAP { get; set; }
        public string TERMOADE_QUANT_VIDAS { get; set; }
        public string TERMOADE_TIPO_COBERTURA { get; set; }
        public string TERMOADE_PERI_PAGAMENTO { get; set; }
        public string TERMOADE_COD_CLIENTE { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGCOMTRO_DTH_DIA_DEBITO { get; set; }
        public string VGCOMTRO_COD_AGENCIA_DEB { get; set; }
        public string VGCOMTRO_OPERACAO_CONTA_DEB { get; set; }
        public string VGCOMTRO_NUM_CONTA_DEBITO { get; set; }
        public string VGCOMTRO_DIG_CONTA_DEBITO { get; set; }
        public string VGCOMTRO_NUM_CARTAO_CREDITO { get; set; }
        public string SUBGVGAP_OCORR_ENDERECO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

        public static R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1 r1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.TERMOADE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_TERMO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.TERMOADE_DATA_ADESAO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_OP = result[i++].Value?.ToString();
            dta.TERMOADE_MODALIDADE_CAPITAL = result[i++].Value?.ToString();
            dta.TERMOADE_TIPO_PLANO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_PLANO_VGAPC = result[i++].Value?.ToString();
            dta.TERMOADE_COD_PLANO_APC = result[i++].Value?.ToString();
            dta.TERMOADE_VAL_CONTRATADO = result[i++].Value?.ToString();
            dta.TERMOADE_VAL_RCAP = result[i++].Value?.ToString();
            dta.VIND_VLRCAP = string.IsNullOrWhiteSpace(dta.TERMOADE_VAL_RCAP) ? "-1" : "0";
            dta.TERMOADE_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.TERMOADE_TIPO_COBERTURA = result[i++].Value?.ToString();
            dta.TERMOADE_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.VGCOMTRO_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.VGCOMTRO_DTH_DIA_DEBITO = result[i++].Value?.ToString();
            dta.VGCOMTRO_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.VGCOMTRO_OPERACAO_CONTA_DEB = result[i++].Value?.ToString();
            dta.VGCOMTRO_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VGCOMTRO_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VGCOMTRO_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.SUBGVGAP_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}