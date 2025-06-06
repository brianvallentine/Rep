using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1610B
{
    public class M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1 : QueryBasis<M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROPOSTA_FIDELIZ
            (
            NUM_PROPOSTA_SIVPF
            , NUM_IDENTIFICACAO
            , COD_EMPRESA_SIVPF
            , COD_PESSOA
            , NUM_SICOB
            , DATA_PROPOSTA
            , COD_PRODUTO_SIVPF
            , AGECOBR
            , DIA_DEBITO
            , OPCAOPAG
            , AGECTADEB
            , OPRCTADEB
            , NUMCTADEB
            , DIGCTADEB
            , PERC_DESCONTO
            , NRMATRVEN
            , AGECTAVEN
            , OPRCTAVEN
            , NUMCTAVEN
            , DIGCTAVEN
            , CGC_CONVENENTE
            , NOME_CONVENENTE
            , NRMATRCON
            , DTQITBCO
            , VAL_PAGO
            , AGEPGTO
            , VAL_TARIFA
            , VAL_IOF
            , DATA_CREDITO
            , VAL_COMISSAO
            , SIT_PROPOSTA
            , COD_USUARIO
            , CANAL_PROPOSTA
            , NSAS_SIVPF
            , ORIGEM_PROPOSTA
            , TIMESTAMP
            , NSL
            , NSAC_SIVPF
            , SITUACAO_ENVIO
            , OPCAO_COBER
            , COD_PLANO
            , NOME_CONJUGE
            , DATA_NASC_CONJUGE
            , PROFISSAO_CONJUGE
            , FAIXA_RENDA_IND
            , FAIXA_RENDA_FAM
            , IND_TP_PROPOSTA
            , IND_TIPO_CONTA
            )
            VALUES
            (
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-IDENTIFICACAO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-EMPRESA-SIVPF,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAOPAG,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-PERC-DESCONTO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONVENENTE,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRCON,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-TARIFA,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-IOF,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-COMISSAO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-USUARIO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-CANAL-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA,
            CURRENT TIMESTAMP,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NSL,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAC-SIVPF,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-SITUACAO-ENVIO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE
            :VIND-DAT-NAS,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-PROFISSAO-CONJUGE
            :VIND-CBO-CON,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM,
            NULL,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TIPO-CONTA)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO , COD_EMPRESA_SIVPF , COD_PESSOA , NUM_SICOB , DATA_PROPOSTA , COD_PRODUTO_SIVPF , AGECOBR , DIA_DEBITO , OPCAOPAG , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , PERC_DESCONTO , NRMATRVEN , AGECTAVEN , OPRCTAVEN , NUMCTAVEN , DIGCTAVEN , CGC_CONVENENTE , NOME_CONVENENTE , NRMATRCON , DTQITBCO , VAL_PAGO , AGEPGTO , VAL_TARIFA , VAL_IOF , DATA_CREDITO , VAL_COMISSAO , SIT_PROPOSTA , COD_USUARIO , CANAL_PROPOSTA , NSAS_SIVPF , ORIGEM_PROPOSTA , TIMESTAMP , NSL , NSAC_SIVPF , SITUACAO_ENVIO , OPCAO_COBER , COD_PLANO , NOME_CONJUGE , DATA_NASC_CONJUGE , PROFISSAO_CONJUGE , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , IND_TP_PROPOSTA , IND_TIPO_CONTA ) VALUES ( {FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.PROPOFID_NUM_IDENTIFICACAO)}, {FieldThreatment(this.PROPOFID_COD_EMPRESA_SIVPF)}, {FieldThreatment(this.PROPOFID_COD_PESSOA)}, {FieldThreatment(this.PROPOFID_NUM_SICOB)}, {FieldThreatment(this.PROPOFID_DATA_PROPOSTA)}, {FieldThreatment(this.PROPOFID_COD_PRODUTO_SIVPF)}, {FieldThreatment(this.PROPOFID_AGECOBR)}, {FieldThreatment(this.PROPOFID_DIA_DEBITO)}, {FieldThreatment(this.PROPOFID_OPCAOPAG)}, {FieldThreatment(this.PROPOFID_AGECTADEB)}, {FieldThreatment(this.PROPOFID_OPRCTADEB)}, {FieldThreatment(this.PROPOFID_NUMCTADEB)}, {FieldThreatment(this.PROPOFID_DIGCTADEB)}, {FieldThreatment(this.PROPOFID_PERC_DESCONTO)}, {FieldThreatment(this.PROPOFID_NRMATRVEN)}, {FieldThreatment(this.PROPOFID_AGECTAVEN)}, {FieldThreatment(this.PROPOFID_OPRCTAVEN)}, {FieldThreatment(this.PROPOFID_NUMCTAVEN)}, {FieldThreatment(this.PROPOFID_DIGCTAVEN)}, {FieldThreatment(this.PROPOFID_CGC_CONVENENTE)}, {FieldThreatment(this.PROPOFID_NOME_CONVENENTE)}, {FieldThreatment(this.PROPOFID_NRMATRCON)}, {FieldThreatment(this.PROPOFID_DTQITBCO)}, {FieldThreatment(this.PROPOFID_VAL_PAGO)}, {FieldThreatment(this.PROPOFID_AGEPGTO)}, {FieldThreatment(this.PROPOFID_VAL_TARIFA)}, {FieldThreatment(this.PROPOFID_VAL_IOF)}, {FieldThreatment(this.PROPOFID_DATA_CREDITO)}, {FieldThreatment(this.PROPOFID_VAL_COMISSAO)}, {FieldThreatment(this.PROPOFID_SIT_PROPOSTA)}, {FieldThreatment(this.PROPOFID_COD_USUARIO)}, {FieldThreatment(this.PROPOFID_CANAL_PROPOSTA)}, {FieldThreatment(this.PROPOFID_NSAS_SIVPF)}, {FieldThreatment(this.PROPOFID_ORIGEM_PROPOSTA)}, CURRENT TIMESTAMP, {FieldThreatment(this.PROPOFID_NSL)}, {FieldThreatment(this.PROPOFID_NSAC_SIVPF)}, {FieldThreatment(this.PROPOFID_SITUACAO_ENVIO)}, {FieldThreatment(this.PROPOFID_OPCAO_COBER)}, {FieldThreatment(this.PROPOFID_COD_PLANO)}, {FieldThreatment(this.PROPOFID_NOME_CONJUGE)},  {FieldThreatment((this.VIND_DAT_NAS?.ToInt() == -1 ? null : this.PROPOFID_DATA_NASC_CONJUGE))},  {FieldThreatment((this.VIND_CBO_CON?.ToInt() == -1 ? null : this.PROPOFID_PROFISSAO_CONJUGE))}, {FieldThreatment(this.PROPOFID_FAIXA_RENDA_IND)}, {FieldThreatment(this.PROPOFID_FAIXA_RENDA_FAM)}, NULL, {FieldThreatment(this.PROPOFID_IND_TIPO_CONTA)})";

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
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string PROPOFID_NOME_CONJUGE { get; set; }
        public string PROPOFID_DATA_NASC_CONJUGE { get; set; }
        public string VIND_DAT_NAS { get; set; }
        public string PROPOFID_PROFISSAO_CONJUGE { get; set; }
        public string VIND_CBO_CON { get; set; }
        public string PROPOFID_FAIXA_RENDA_IND { get; set; }
        public string PROPOFID_FAIXA_RENDA_FAM { get; set; }
        public string PROPOFID_IND_TIPO_CONTA { get; set; }

        public static void Execute(M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1 m_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1)
        {
            var ths = m_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}