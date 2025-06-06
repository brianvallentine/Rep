using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0619B
{
    public class R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 : QueryBasis<R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROPOSTA_FIDELIZ
            ( NUM_PROPOSTA_SIVPF
            ,NUM_IDENTIFICACAO
            ,COD_EMPRESA_SIVPF
            ,COD_PESSOA
            ,NUM_SICOB
            ,DATA_PROPOSTA
            ,COD_PRODUTO_SIVPF
            ,AGECOBR
            ,DIA_DEBITO
            ,OPCAOPAG
            ,AGECTADEB
            ,OPRCTADEB
            ,NUMCTADEB
            ,DIGCTADEB
            ,PERC_DESCONTO
            ,NRMATRVEN
            ,AGECTAVEN
            ,OPRCTAVEN
            ,NUMCTAVEN
            ,DIGCTAVEN
            ,CGC_CONVENENTE
            ,NOME_CONVENENTE
            ,NRMATRCON
            ,DTQITBCO
            ,VAL_PAGO
            ,AGEPGTO
            ,VAL_TARIFA
            ,VAL_IOF
            ,DATA_CREDITO
            ,VAL_COMISSAO
            ,SIT_PROPOSTA
            ,COD_USUARIO
            ,CANAL_PROPOSTA
            ,NSAS_SIVPF
            ,ORIGEM_PROPOSTA
            ,TIMESTAMP
            ,NSL
            ,NSAC_SIVPF
            ,SITUACAO_ENVIO
            ,OPCAO_COBER
            ,COD_PLANO
            ,NOME_CONJUGE
            ,DATA_NASC_CONJUGE
            ,PROFISSAO_CONJUGE
            ,FAIXA_RENDA_IND
            ,FAIXA_RENDA_FAM
            ,IND_TP_PROPOSTA
            ,IND_TIPO_CONTA
            )
            VALUES
            (:DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF,
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
            CURRENT TIMESTAMP,
            :DCLPROPOSTA-FIDELIZ.NSL,
            :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF,
            :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO,
            :DCLPROPOSTA-FIDELIZ.OPCAO-COBER,
            :DCLPROPOSTA-FIDELIZ.COD-PLANO,
            :DCLPROPOSTA-FIDELIZ.NOME-CONJUGE,
            :DCLPROPOSTA-FIDELIZ.DATA-NASC-CONJUGE:VIND-DTNASC-ESPOSA,
            :DCLPROPOSTA-FIDELIZ.PROFISSAO-CONJUGE,
            :DCLPROPOSTAS-VA.FAIXA-RENDA-IND
            :VIND-FAIXA-RENDA-IND,
            :DCLPROPOSTAS-VA.FAIXA-RENDA-FAM
            :VIND-FAIXA-RENDA-FAM,
            NULL,
            :DCLPROPOSTA-FIDELIZ.IND-TIPO-CONTA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF ,NUM_IDENTIFICACAO ,COD_EMPRESA_SIVPF ,COD_PESSOA ,NUM_SICOB ,DATA_PROPOSTA ,COD_PRODUTO_SIVPF ,AGECOBR ,DIA_DEBITO ,OPCAOPAG ,AGECTADEB ,OPRCTADEB ,NUMCTADEB ,DIGCTADEB ,PERC_DESCONTO ,NRMATRVEN ,AGECTAVEN ,OPRCTAVEN ,NUMCTAVEN ,DIGCTAVEN ,CGC_CONVENENTE ,NOME_CONVENENTE ,NRMATRCON ,DTQITBCO ,VAL_PAGO ,AGEPGTO ,VAL_TARIFA ,VAL_IOF ,DATA_CREDITO ,VAL_COMISSAO ,SIT_PROPOSTA ,COD_USUARIO ,CANAL_PROPOSTA ,NSAS_SIVPF ,ORIGEM_PROPOSTA ,TIMESTAMP ,NSL ,NSAC_SIVPF ,SITUACAO_ENVIO ,OPCAO_COBER ,COD_PLANO ,NOME_CONJUGE ,DATA_NASC_CONJUGE ,PROFISSAO_CONJUGE ,FAIXA_RENDA_IND ,FAIXA_RENDA_FAM ,IND_TP_PROPOSTA ,IND_TIPO_CONTA ) VALUES ({FieldThreatment(this.NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.NUM_IDENTIFICACAO)}, {FieldThreatment(this.COD_EMPRESA_SIVPF)}, {FieldThreatment(this.COD_PESSOA)}, {FieldThreatment(this.NUM_SICOB)}, {FieldThreatment(this.DATA_PROPOSTA)}, {FieldThreatment(this.COD_PRODUTO_SIVPF)}, {FieldThreatment(this.AGECOBR)}, {FieldThreatment(this.DIA_DEBITO)}, {FieldThreatment(this.OPCAOPAG)}, {FieldThreatment(this.AGECTADEB)}, {FieldThreatment(this.OPRCTADEB)}, {FieldThreatment(this.NUMCTADEB)}, {FieldThreatment(this.DIGCTADEB)}, {FieldThreatment(this.PERC_DESCONTO)}, {FieldThreatment(this.NRMATRVEN)}, {FieldThreatment(this.AGECTAVEN)}, {FieldThreatment(this.OPRCTAVEN)}, {FieldThreatment(this.NUMCTAVEN)}, {FieldThreatment(this.DIGCTAVEN)}, {FieldThreatment(this.CGC_CONVENENTE)}, {FieldThreatment(this.NOME_CONVENENTE)}, {FieldThreatment(this.NRMATRCON)}, {FieldThreatment(this.DTQITBCO)}, {FieldThreatment(this.VAL_PAGO)}, {FieldThreatment(this.AGEPGTO)}, {FieldThreatment(this.VAL_TARIFA)}, {FieldThreatment(this.VAL_IOF)}, {FieldThreatment(this.DATA_CREDITO)}, {FieldThreatment(this.VAL_COMISSAO)}, {FieldThreatment(this.SIT_PROPOSTA)}, {FieldThreatment(this.COD_USUARIO)}, {FieldThreatment(this.CANAL_PROPOSTA)}, {FieldThreatment(this.NSAS_SIVPF)}, {FieldThreatment(this.ORIGEM_PROPOSTA)}, CURRENT TIMESTAMP, {FieldThreatment(this.NSL)}, {FieldThreatment(this.NSAC_SIVPF)}, {FieldThreatment(this.SITUACAO_ENVIO)}, {FieldThreatment(this.OPCAO_COBER)}, {FieldThreatment(this.COD_PLANO)}, {FieldThreatment(this.NOME_CONJUGE)},  {FieldThreatment((this.VIND_DTNASC_ESPOSA?.ToInt() == -1 ? null : this.DATA_NASC_CONJUGE))}, {FieldThreatment(this.PROFISSAO_CONJUGE)},  {FieldThreatment((this.VIND_FAIXA_RENDA_IND?.ToInt() == -1 ? null : this.FAIXA_RENDA_IND))},  {FieldThreatment((this.VIND_FAIXA_RENDA_FAM?.ToInt() == -1 ? null : this.FAIXA_RENDA_FAM))}, NULL, {FieldThreatment(this.IND_TIPO_CONTA)})";

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
        public string NOME_CONJUGE { get; set; }
        public string DATA_NASC_CONJUGE { get; set; }
        public string VIND_DTNASC_ESPOSA { get; set; }
        public string PROFISSAO_CONJUGE { get; set; }
        public string FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA_IND { get; set; }
        public string FAIXA_RENDA_FAM { get; set; }
        public string VIND_FAIXA_RENDA_FAM { get; set; }
        public string IND_TIPO_CONTA { get; set; }

        public static void Execute(R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1)
        {
            var ths = r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}