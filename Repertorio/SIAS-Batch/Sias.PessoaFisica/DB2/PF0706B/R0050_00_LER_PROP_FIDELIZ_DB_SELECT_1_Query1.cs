using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0706B
{
    public class R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1>
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
            SITUACAO_ENVIO
            INTO :PROPOFID-NUM-PROPOSTA-SIVPF,
            :PROPOFID-NUM-IDENTIFICACAO,
            :PROPOFID-COD-EMPRESA-SIVPF,
            :PROPOFID-COD-PESSOA,
            :PROPOFID-NUM-SICOB,
            :PROPOFID-DATA-PROPOSTA,
            :PROPOFID-COD-PRODUTO-SIVPF,
            :PROPOFID-AGECOBR,
            :PROPOFID-DIA-DEBITO,
            :PROPOFID-OPCAOPAG,
            :PROPOFID-AGECTADEB,
            :PROPOFID-OPRCTADEB,
            :PROPOFID-NUMCTADEB,
            :PROPOFID-DIGCTADEB,
            :PROPOFID-PERC-DESCONTO,
            :PROPOFID-NRMATRVEN,
            :PROPOFID-AGECTAVEN,
            :PROPOFID-OPRCTAVEN,
            :PROPOFID-NUMCTAVEN,
            :PROPOFID-DIGCTAVEN,
            :PROPOFID-CGC-CONVENENTE,
            :PROPOFID-NOME-CONVENENTE,
            :PROPOFID-NRMATRCON,
            :PROPOFID-DTQITBCO,
            :PROPOFID-VAL-PAGO,
            :PROPOFID-AGEPGTO,
            :PROPOFID-VAL-TARIFA,
            :PROPOFID-VAL-IOF,
            :PROPOFID-DATA-CREDITO,
            :PROPOFID-VAL-COMISSAO,
            :PROPOFID-SIT-PROPOSTA,
            :PROPOFID-COD-USUARIO,
            :PROPOFID-CANAL-PROPOSTA,
            :PROPOFID-NSAS-SIVPF,
            :PROPOFID-ORIGEM-PROPOSTA,
            :PROPOFID-NSL,
            :PROPOFID-NSAC-SIVPF,
            :PROPOFID-SITUACAO-ENVIO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB =
            :PROPOFID-NUM-SICOB
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
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB =
											'{this.PROPOFID_NUM_SICOB}'
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_AGECOBR { get; set; }
        public string PROPOFID_DIA_DEBITO { get; set; }
        public string PROPOFID_OPCAOPAG { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string PROPOFID_PERC_DESCONTO { get; set; }
        public string PROPOFID_NRMATRVEN { get; set; }
        public string PROPOFID_AGECTAVEN { get; set; }
        public string PROPOFID_OPRCTAVEN { get; set; }
        public string PROPOFID_NUMCTAVEN { get; set; }
        public string PROPOFID_DIGCTAVEN { get; set; }
        public string PROPOFID_CGC_CONVENENTE { get; set; }
        public string PROPOFID_NOME_CONVENENTE { get; set; }
        public string PROPOFID_NRMATRCON { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string PROPOFID_AGEPGTO { get; set; }
        public string PROPOFID_VAL_TARIFA { get; set; }
        public string PROPOFID_VAL_IOF { get; set; }
        public string PROPOFID_DATA_CREDITO { get; set; }
        public string PROPOFID_VAL_COMISSAO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_COD_USUARIO { get; set; }
        public string PROPOFID_CANAL_PROPOSTA { get; set; }
        public string PROPOFID_NSAS_SIVPF { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_NSL { get; set; }
        public string PROPOFID_NSAC_SIVPF { get; set; }
        public string PROPOFID_SITUACAO_ENVIO { get; set; }

        public static R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 Execute(R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 r0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PESSOA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_AGECOBR = result[i++].Value?.ToString();
            dta.PROPOFID_DIA_DEBITO = result[i++].Value?.ToString();
            dta.PROPOFID_OPCAOPAG = result[i++].Value?.ToString();
            dta.PROPOFID_AGECTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_OPRCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_NUMCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_DIGCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_PERC_DESCONTO = result[i++].Value?.ToString();
            dta.PROPOFID_NRMATRVEN = result[i++].Value?.ToString();
            dta.PROPOFID_AGECTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_OPRCTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_NUMCTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_DIGCTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_CGC_CONVENENTE = result[i++].Value?.ToString();
            dta.PROPOFID_NOME_CONVENENTE = result[i++].Value?.ToString();
            dta.PROPOFID_NRMATRCON = result[i++].Value?.ToString();
            dta.PROPOFID_DTQITBCO = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_PAGO = result[i++].Value?.ToString();
            dta.PROPOFID_AGEPGTO = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_TARIFA = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_IOF = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_CREDITO = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_COMISSAO = result[i++].Value?.ToString();
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_COD_USUARIO = result[i++].Value?.ToString();
            dta.PROPOFID_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NSAS_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NSL = result[i++].Value?.ToString();
            dta.PROPOFID_NSAC_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_SITUACAO_ENVIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}