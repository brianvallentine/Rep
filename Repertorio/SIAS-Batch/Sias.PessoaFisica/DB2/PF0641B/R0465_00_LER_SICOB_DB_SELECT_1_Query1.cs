using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0641B
{
    public class R0465_00_LER_SICOB_DB_SELECT_1_Query1 : QueryBasis<R0465_00_LER_SICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF,
            NUM_IDENTIFICACAO,
            COD_EMPRESA_SIVPF,
            COD_PESSOA,
            NUM_SICOB,
            DATA_PROPOSTA,
            COD_PRODUTO_SIVPF,
            AGECOBR,
            DIA_DEBITO,
            OPCAOPAG,
            AGECTADEB,
            OPRCTADEB,
            NUMCTADEB,
            DIGCTADEB,
            PERC_DESCONTO,
            NRMATRVEN,
            AGECTAVEN,
            OPRCTAVEN,
            NUMCTAVEN,
            DIGCTAVEN,
            CGC_CONVENENTE,
            NOME_CONVENENTE,
            NRMATRCON,
            DTQITBCO,
            VAL_PAGO,
            AGEPGTO,
            VAL_TARIFA,
            VAL_IOF,
            DATA_CREDITO,
            VAL_COMISSAO,
            SIT_PROPOSTA,
            COD_USUARIO,
            CANAL_PROPOSTA,
            NSAS_SIVPF,
            ORIGEM_PROPOSTA,
            NSL,
            NSAC_SIVPF,
            SITUACAO_ENVIO,
            OPCAO_COBER,
            COD_PLANO
            INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF,
            :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO,
            :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF,
            :DCLPROPOSTA-FIDELIZ.COD-PESSOA,
            :DCLPROPOSTA-FIDELIZ.NUM-SICOB,
            :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF,
            :DCLPROPOSTA-FIDELIZ.AGECOBR,
            :DCLPROPOSTA-FIDELIZ.DIA-DEBITO,
            :DCLPROPOSTA-FIDELIZ.OPCAOPAG,
            :DCLPROPOSTA-FIDELIZ.AGECTADEB,
            :DCLPROPOSTA-FIDELIZ.OPRCTADEB,
            :DCLPROPOSTA-FIDELIZ.NUMCTADEB,
            :DCLPROPOSTA-FIDELIZ.DIGCTADEB,
            :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO,
            :DCLPROPOSTA-FIDELIZ.NRMATRVEN,
            :DCLPROPOSTA-FIDELIZ.AGECTAVEN,
            :DCLPROPOSTA-FIDELIZ.OPRCTAVEN,
            :DCLPROPOSTA-FIDELIZ.NUMCTAVEN,
            :DCLPROPOSTA-FIDELIZ.DIGCTAVEN,
            :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE,
            :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE,
            :DCLPROPOSTA-FIDELIZ.NRMATRCON,
            :DCLPROPOSTA-FIDELIZ.DTQITBCO,
            :DCLPROPOSTA-FIDELIZ.VAL-PAGO,
            :DCLPROPOSTA-FIDELIZ.AGEPGTO,
            :DCLPROPOSTA-FIDELIZ.VAL-TARIFA,
            :DCLPROPOSTA-FIDELIZ.VAL-IOF,
            :DCLPROPOSTA-FIDELIZ.DATA-CREDITO,
            :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO,
            :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.COD-USUARIO,
            :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF,
            :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.NSL,
            :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF,
            :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO,
            :DCLPROPOSTA-FIDELIZ.OPCAO-COBER,
            :DCLPROPOSTA-FIDELIZ.COD-PLANO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :DCLPROPOSTA-FIDELIZ.NUM-SICOB
            AND NUM_SICOB > 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
							,
											NUM_IDENTIFICACAO
							,
											COD_EMPRESA_SIVPF
							,
											COD_PESSOA
							,
											NUM_SICOB
							,
											DATA_PROPOSTA
							,
											COD_PRODUTO_SIVPF
							,
											AGECOBR
							,
											DIA_DEBITO
							,
											OPCAOPAG
							,
											AGECTADEB
							,
											OPRCTADEB
							,
											NUMCTADEB
							,
											DIGCTADEB
							,
											PERC_DESCONTO
							,
											NRMATRVEN
							,
											AGECTAVEN
							,
											OPRCTAVEN
							,
											NUMCTAVEN
							,
											DIGCTAVEN
							,
											CGC_CONVENENTE
							,
											NOME_CONVENENTE
							,
											NRMATRCON
							,
											DTQITBCO
							,
											VAL_PAGO
							,
											AGEPGTO
							,
											VAL_TARIFA
							,
											VAL_IOF
							,
											DATA_CREDITO
							,
											VAL_COMISSAO
							,
											SIT_PROPOSTA
							,
											COD_USUARIO
							,
											CANAL_PROPOSTA
							,
											NSAS_SIVPF
							,
											ORIGEM_PROPOSTA
							,
											NSL
							,
											NSAC_SIVPF
							,
											SITUACAO_ENVIO
							,
											OPCAO_COBER
							,
											COD_PLANO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.NUM_SICOB}'
											AND NUM_SICOB > 0
											WITH UR";

            return query;
        }
        public string NUM_PROPOSTA_SIVPF { get; set; }
        public string NUM_IDENTIFICACAO { get; set; }
        public string COD_EMPRESA_SIVPF { get; set; }
        public string COD_PESSOA { get; set; }
        public string NUM_SICOB { get; set; }
        public string DATA_PROPOSTA { get; set; }
        public string COD_PRODUTO_SIVPF { get; set; }
        public string AGECOBR { get; set; }
        public string DIA_DEBITO { get; set; }
        public string OPCAOPAG { get; set; }
        public string AGECTADEB { get; set; }
        public string OPRCTADEB { get; set; }
        public string NUMCTADEB { get; set; }
        public string DIGCTADEB { get; set; }
        public string PERC_DESCONTO { get; set; }
        public string NRMATRVEN { get; set; }
        public string AGECTAVEN { get; set; }
        public string OPRCTAVEN { get; set; }
        public string NUMCTAVEN { get; set; }
        public string DIGCTAVEN { get; set; }
        public string CGC_CONVENENTE { get; set; }
        public string NOME_CONVENENTE { get; set; }
        public string NRMATRCON { get; set; }
        public string DTQITBCO { get; set; }
        public string VAL_PAGO { get; set; }
        public string AGEPGTO { get; set; }
        public string VAL_TARIFA { get; set; }
        public string VAL_IOF { get; set; }
        public string DATA_CREDITO { get; set; }
        public string VAL_COMISSAO { get; set; }
        public string SIT_PROPOSTA { get; set; }
        public string COD_USUARIO { get; set; }
        public string CANAL_PROPOSTA { get; set; }
        public string NSAS_SIVPF { get; set; }
        public string ORIGEM_PROPOSTA { get; set; }
        public string NSL { get; set; }
        public string NSAC_SIVPF { get; set; }
        public string SITUACAO_ENVIO { get; set; }
        public string OPCAO_COBER { get; set; }
        public string COD_PLANO { get; set; }

        public static R0465_00_LER_SICOB_DB_SELECT_1_Query1 Execute(R0465_00_LER_SICOB_DB_SELECT_1_Query1 r0465_00_LER_SICOB_DB_SELECT_1_Query1)
        {
            var ths = r0465_00_LER_SICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0465_00_LER_SICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0465_00_LER_SICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.COD_PESSOA = result[i++].Value?.ToString();
            dta.NUM_SICOB = result[i++].Value?.ToString();
            dta.DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.AGECOBR = result[i++].Value?.ToString();
            dta.DIA_DEBITO = result[i++].Value?.ToString();
            dta.OPCAOPAG = result[i++].Value?.ToString();
            dta.AGECTADEB = result[i++].Value?.ToString();
            dta.OPRCTADEB = result[i++].Value?.ToString();
            dta.NUMCTADEB = result[i++].Value?.ToString();
            dta.DIGCTADEB = result[i++].Value?.ToString();
            dta.PERC_DESCONTO = result[i++].Value?.ToString();
            dta.NRMATRVEN = result[i++].Value?.ToString();
            dta.AGECTAVEN = result[i++].Value?.ToString();
            dta.OPRCTAVEN = result[i++].Value?.ToString();
            dta.NUMCTAVEN = result[i++].Value?.ToString();
            dta.DIGCTAVEN = result[i++].Value?.ToString();
            dta.CGC_CONVENENTE = result[i++].Value?.ToString();
            dta.NOME_CONVENENTE = result[i++].Value?.ToString();
            dta.NRMATRCON = result[i++].Value?.ToString();
            dta.DTQITBCO = result[i++].Value?.ToString();
            dta.VAL_PAGO = result[i++].Value?.ToString();
            dta.AGEPGTO = result[i++].Value?.ToString();
            dta.VAL_TARIFA = result[i++].Value?.ToString();
            dta.VAL_IOF = result[i++].Value?.ToString();
            dta.DATA_CREDITO = result[i++].Value?.ToString();
            dta.VAL_COMISSAO = result[i++].Value?.ToString();
            dta.SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.COD_USUARIO = result[i++].Value?.ToString();
            dta.CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.NSAS_SIVPF = result[i++].Value?.ToString();
            dta.ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.NSL = result[i++].Value?.ToString();
            dta.NSAC_SIVPF = result[i++].Value?.ToString();
            dta.SITUACAO_ENVIO = result[i++].Value?.ToString();
            dta.OPCAO_COBER = result[i++].Value?.ToString();
            dta.COD_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}